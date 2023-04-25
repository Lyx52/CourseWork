using IkMeKursaDarbs.Data.Entities;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data
{
    public static class ConnectionExtension
    {
        public static NpgsqlDbType GetPostgresType(Type type)
        {
            if (type == typeof(int)) return NpgsqlDbType.Integer;
            if (type == typeof(string)) return NpgsqlDbType.Text;
            if (type == typeof(bool)) return NpgsqlDbType.Boolean;
            if (type == typeof(float)) return NpgsqlDbType.Real;
            if (type == typeof(double)) return NpgsqlDbType.Double;

            throw new ArgumentException($"No Postgres type mapping for type {type}");
        }
        public static int GetPostgresTypeSize(Type type)
        {
            if (type == typeof(int)) return 4;
            if (type == typeof(string)) return 1000;
            if (type == typeof(bool)) return 1;
            if (type == typeof(float)) return 4;
            if (type == typeof(double)) return 8;

            throw new ArgumentException($"No Postgres type mapping for type {type}");
        }
        public static string GetPostgresTypeStr(Type type) => GetPostgresType(type).ToString();
        public static async Task<NpgsqlDataAdapter> CreateTable<TDataType>(this NpgsqlConnection connection, bool createNewTable = false, CancellationToken cancellationToken = default(CancellationToken)) where TDataType : IdEntity
        {
            await connection.OpenAsync(cancellationToken);
            var clazz = typeof(TDataType);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter($"SELECT * FROM {clazz.Name}", connection);

            // Queries
            List<string> columnsConstraints = new List<string>();
            List<string> columns = new List<string>();
            // Commands
            var insertParameters = new List<NpgsqlParameter>();
            var updateParameters = new List<NpgsqlParameter>();
            foreach (var prop in clazz.GetProperties())
            {
                // Izdabūt atribūta custom ierbobežojumu/tipu
                var constraintAttrib = prop.GetCustomAttribute<ConstraintAttribute>();
                columnsConstraints.Add($"{prop.Name} {constraintAttrib.DataType ?? GetPostgresTypeStr(prop.PropertyType)} {constraintAttrib.Constraint ?? string.Empty}");
                insertParameters.Add(new NpgsqlParameter(prop.Name, GetPostgresType(prop.PropertyType), GetPostgresTypeSize(prop.PropertyType), prop.Name));
                updateParameters.Add(new NpgsqlParameter(prop.Name, GetPostgresType(prop.PropertyType), GetPostgresTypeSize(prop.PropertyType), prop.Name));

                // Visas kolonas kas nav primārā atslēga
                if (constraintAttrib.Constraint.ToUpper() != "PRIMARY KEY")
                {
                    columns.Add(prop.Name);
                }
            }
            string createQuery = $"CREATE TABLE {clazz.Name} ({string.Join(",", columnsConstraints)})";
            string insertQuery = $"INSERT INTO {clazz.Name} ({string.Join(",", columns)}) VALUES ({string.Join(",", columns.Select(col => $"@{col}"))}) RETURNING Id";
            string deleteQuery = $"DELETE FROM {clazz.Name} WHERE Id = @Id";
            string updateQuery = $"UPDATE {clazz.Name} SET {string.Join(",", columns.Select(col => $"{col} = @{col}"))} WHERE Id = @Id RETURNING Id";
            
            if (createNewTable)
            {
                try
                {
                    using (var dropCmd = new NpgsqlCommand($"DROP TABLE {clazz.Name}", connection))
                    {
                        await dropCmd.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
                catch (NpgsqlException e)
                {
                    Console.WriteLine("Cannot drop table, it does't exist!");
                }
            }
         
            try
            {
                using (var createCmd = new NpgsqlCommand(createQuery, connection))
                {
                    await createCmd.ExecuteNonQueryAsync(cancellationToken);
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("Cannot create table it already exists!");
            }
            adapter.DeleteCommand = new NpgsqlCommand(deleteQuery, connection);
            adapter.DeleteCommand.Parameters.Add(new NpgsqlParameter("Id", NpgsqlDbType.Integer, 4, "Id"));
           
            adapter.InsertCommand = new NpgsqlCommand(insertQuery, connection);
            adapter.InsertCommand.Parameters.AddRange(insertParameters.ToArray());

            adapter.UpdateCommand = new NpgsqlCommand(updateQuery, connection);
            adapter.UpdateCommand.Parameters.AddRange(updateParameters.ToArray());

            await connection.CloseAsync();
            return adapter;
        }
    }
}
