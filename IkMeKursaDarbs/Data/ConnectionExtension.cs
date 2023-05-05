using IkMeKursaDarbs.Data.Entities;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (type == typeof(long)) return NpgsqlDbType.Bigint;
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
            if (type == typeof(long)) return 8;

            throw new ArgumentException($"No Postgres type mapping for type {type}");
        }
        private static async Task<bool> TableExists<TDataType>(this NpgsqlConnection connection) where TDataType : IdEntity
        {
            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"SELECT EXISTS (SELECT FROM information_schema.tables WHERE table_name = '{typeof(TDataType).Name.ToLower()}')";
                return (bool)await command.ExecuteScalarAsync();
            }
        }
        public static string GetPostgresTypeStr(Type type) => GetPostgresType(type).ToString();
        public static async Task AddRelations<TDataType>(this NpgsqlConnection connection) where TDataType : IdEntity
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                var tableExists = await connection.TableExists<TDataType>();
                foreach (var prop in typeof(TDataType).GetProperties())
                {
                    var relation = prop.GetCustomAttribute<TableRelationAttribute>();
                    if (relation != null && tableExists)
                    {
                        // Parent->Id related to Child->PropertyName
                        command.CommandText = $@"ALTER TABLE ""{relation.RelatedTo.Name}""
                                                 ADD CONSTRAINT ""{relation.RelatedTo.Name}_TO_{typeof(TDataType).Name}""
                                                 FOREIGN KEY (""Id"") REFERENCES 
                                                 ""{typeof(TDataType).Name}"" (""{prop.Name}"");";
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            await connection.CloseAsync();
        }

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
                columnsConstraints.Add($"{prop.Name} {constraintAttrib?.DataType ?? GetPostgresTypeStr(prop.PropertyType)} {constraintAttrib?.Constraint ?? string.Empty}");
                insertParameters.Add(new NpgsqlParameter(prop.Name, GetPostgresType(prop.PropertyType), GetPostgresTypeSize(prop.PropertyType), prop.Name));
                updateParameters.Add(new NpgsqlParameter(prop.Name, GetPostgresType(prop.PropertyType), GetPostgresTypeSize(prop.PropertyType), prop.Name));

                // Visas kolonas kas nav primārā atslēga
                if (constraintAttrib != null && constraintAttrib.Constraint.ToUpper() != "PRIMARY KEY")
                {
                    columns.Add(prop.Name);
                }
            }
            string createQuery = $"CREATE TABLE {clazz.Name} ({string.Join(",", columnsConstraints)})";
            string insertQuery = $"INSERT INTO {clazz.Name} ({string.Join(",", columns)}) VALUES ({string.Join(",", columns.Select(col => $"@{col}"))}) RETURNING Id";
            string deleteQuery = $"DELETE FROM {clazz.Name} WHERE Id = @Id";
            string updateQuery = $"UPDATE {clazz.Name} SET {string.Join(",", columns.Select(col => $"{col} = @{col}"))} WHERE Id = @Id RETURNING Id";
            bool tableExists = await connection.TableExists<TDataType>();
            
            if (createNewTable && tableExists)
            {
                using (var dropCmd = new NpgsqlCommand($"DROP TABLE {clazz.Name}", connection))
                {
                    await dropCmd.ExecuteNonQueryAsync(cancellationToken);
                }
                tableExists = false;
            }
            if (!tableExists)
            {
                using (var createCmd = new NpgsqlCommand(createQuery, connection))
                {
                    await createCmd.ExecuteNonQueryAsync(cancellationToken);
                }
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
