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
using System.Windows.Forms;

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
        public DataRelation this[string parent, string child]
        {
            get => DataSet.Relations[$"{parent}_TO_{child}"];
        }
        public DbContext()
        {
            this._connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=uzdevums");
            DataSet = new DataSet();
            Adapters = new Dictionary<string, NpgsqlDataAdapter>();
        }
        public async Task Initialize(bool rebuildTables = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Izveidojam tabulas
            await this.CreateSchema<Country>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<City>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<Address>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<AppUser>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<UserRole>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<Specialization>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<MechanicSpecialization>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<Mechanic>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<InventoryCategory>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<InventoryItem>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<ItemManufacturer>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<Vehicle>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<MechanicTask>(true, rebuildTables, cancellationToken);
            await this.CreateSchema<Customer>(true, rebuildTables, cancellationToken);

            // Izveidojam relacijas
            this.DataSet.AddRelations<AppUser>();
            this.DataSet.AddRelations<InventoryItem>();
            this.DataSet.AddRelations<City>();
            this.DataSet.AddRelations<Address>();
            this.DataSet.AddRelations<Vehicle>();
            this.DataSet.AddRelations<Customer>();
            this.DataSet.AddRelations<MechanicTask>();
            this.DataSet.AddRelations<MechanicSpecialization>();

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
                this.Update<AppUser>();
            }

            // Izveidot noklusēto noliktavas kategoriju, ja tāda neēksistē (-1 Ir root kategorija)
            if (this.DataSet.Query<InventoryCategory>(c => c.Name == "Parts").Count() <= 0)
            {
                this.DataSet.Add(new InventoryCategory() { Name = "Parts", ParentId = -1 });
                this.Update<InventoryCategory>();
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
            try
            {
                this.Adapters[tableName].Update(DataSet.Tables[tableName]);
            } catch (Exception e)
            {
                MessageBox.Show("Failed to save!", "Saving error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataSet.Tables[tableName].RejectChanges();
            }
        }
        public void Update<TDataType>() where TDataType : IdEntity => Update(typeof(TDataType).Name);
    }
}
