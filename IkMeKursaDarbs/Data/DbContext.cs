using IkMeKursaDarbs.Data;
using IkMeKursaDarbs.Data.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IkMeKursaDarbs.Data.Enums;
namespace IkMeKursaDarbs
{
    
    internal class DbContext
    {
        private readonly NpgsqlConnection _connection;
        public DataSet DataSet { get; set; }
        public Dictionary<string, NpgsqlDataAdapter> Adapters { get; set; }
        public DataTable this[string tableName]
        {
            get => DataSet.Tables[tableName];
        }
        public DataTable this[Type type]
        {
            get => DataSet.Tables[typeof(Type).Name];
        }
        public DbContext()
        {
            this._connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=uzdevums");
            DataSet = new DataSet();
            Adapters = new Dictionary<string, NpgsqlDataAdapter>();
        }
        public async Task Initialize(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Izveidojam tabulas
            await this.CreateSchema<AppUser>(true, true, cancellationToken);
            await this.CreateSchema<UserRole>(true, true, cancellationToken);

            // Izveidojam relacijas
            this.DataSet.AddRelations<AppUser>();

            // Izveidot admin lietotāju, ja tāds neēksistē
            if (this.DataSet.Query<UserRole>((role) => role.RoleName == "Administrator").Count() <= 0)
            {
                this.DataSet.Add(new UserRole() { RoleName = "Administrator", Premissions = Enum.GetValues(typeof(RolePremissionType)).Cast<int>().Sum() });
                this.Update<UserRole>();
            }

            if (this.DataSet.Select<AppUser>("Username IN ('admin', 'tester')").Count() <= 0)
            {
                var role = this.DataSet.Select<UserRole>("RoleName = 'Administrator'").FirstOrDefault();
                this.DataSet.Add(new AppUser() { Password = "parole123".ToSHA256(), Username = "admin", RoleId = role.Id });
                this.DataSet.Add(new AppUser() { Password = "parole123".ToSHA256(), Username = "tester", RoleId = role.Id });
                this.Update<AppUser>();
                this.DataSet.Select<AppUser>("Username = 'admin'").Count();
            }
        }
        public async Task CreateSchema<TDataType>(bool fillDataSet, bool createNewTable = false, CancellationToken cancellationToken = default(CancellationToken)) where TDataType : IdEntity
        {
            if (Adapters.ContainsKey(typeof(TDataType).Name))
                throw new ArgumentException("Entity schema already exists!");
            Adapters.Add(typeof(TDataType).Name, await this._connection.CreateTable<TDataType>(createNewTable, cancellationToken));
            if (fillDataSet)
                this.Adapters[typeof(TDataType).Name].Fill(DataSet, typeof(TDataType).Name);
        }
        public void Update(string tableName)
        {
            this.Adapters[tableName].Update(DataSet.Tables[tableName]);
        }
        public void Update<TDataType>() where TDataType : IdEntity => Update(typeof(TDataType).Name);
    }
}
