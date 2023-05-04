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
        public async Task Initialize(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Izveidojam tabulas
            await this.CreateSchema<Country>(true, true, cancellationToken);
            await this.CreateSchema<City>(true, true, cancellationToken);
            await this.CreateSchema<Address>(true, true, cancellationToken);
            await this.CreateSchema<AppUser>(true, true, cancellationToken);
            await this.CreateSchema<UserRole>(true, true, cancellationToken);
            await this.CreateSchema<Specialization>(true, true, cancellationToken);
            await this.CreateSchema<MechanicSpecialization>(true, true, cancellationToken);
            await this.CreateSchema<Mechanic>(true, true, cancellationToken);
            await this.CreateSchema<InventoryCategory>(true, true, cancellationToken);
            await this.CreateSchema<InventoryItem>(true, true, cancellationToken);
            await this.CreateSchema<ItemManufacturer>(true, true, cancellationToken);
            await this.CreateSchema<Vehicle>(true, true, cancellationToken);
            await this.CreateSchema<MechanicTask>(true, true, cancellationToken);
            await this.CreateSchema<Customer>(true, true, cancellationToken);

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
                this.DataSet.Add(new AppUser() { Password = "parole123".ToSHA256(), Username = "tester", RoleId = role.Id });
                this.Update<AppUser>();
                this.DataSet.Select<AppUser>("Username = 'admin'").Count();
            }

            // Izveidot noklusēto noliktavas kategoriju, ja tāda neēksistē (-1 Ir root kategorija)
            if (this.DataSet.Query<InventoryCategory>(c => c.Name == "Parts").Count() <= 0)
            {
                this.DataSet.Add(new InventoryCategory() { Name = "Parts", ParentId = -1 });
                this.Update<InventoryCategory>();
            }

            this.DataSet.Add(new Country() { Name = "Latvia" });
            this.DataSet.Add(new Country() { Name = "Germany" });
            this.Update<Country>();
            this.DataSet.Add(new City() { Name = "Jelgava", CountryId = this.DataSet.Query<Country>(c => c.Name == "Latvia").First().Id });
            this.DataSet.Add(new City() { Name = "Berlin", CountryId = this.DataSet.Query<Country>(c => c.Name == "Germany").First().Id });
            this.DataSet.Add(new City() { Name = "Bremen", CountryId = this.DataSet.Query<Country>(c => c.Name == "Germany").First().Id });
            this.Update<City>();
            this.DataSet.Add(new Address() { Street = "Street1", CityId = this.DataSet.Query<City>(c => c.Name == "Bremen").First().Id });
            this.Update<Address>();
            this.DataSet.Add(new Customer() { Name = "Name1", Surname = "Surname1", AddressId = this.DataSet.Query<Address>(c => c.Street == "Street1").First().Id, Email = "test@test.com", PhoneNumber = "+37123232323" });
            this.DataSet.Add(new Customer() { Name = "Name2", Surname = "Surname2", AddressId = this.DataSet.Query<Address>(c => c.Street == "Street1").First().Id, Email = "test@test.com", PhoneNumber = "+37123232323" });
            
            this.Update<Customer>();
            this.DataSet.Add(new Vehicle() { VinNumber = "1234", Brand = "BMW", Model = "520i", OwnerId = this.DataSet.Query<Customer>(c => c.Name == "Name1" && c.Surname == "Surname1").First().Id });
            this.DataSet.Add(new Vehicle() { VinNumber = "5678", Brand = "BMW", Model = "530i", OwnerId = this.DataSet.Query<Customer>(c => c.Name == "Name1" && c.Surname == "Surname1").First().Id });
            this.DataSet.Add(new Vehicle() { VinNumber = "1111", Brand = "BMW", Model = "520i", OwnerId = this.DataSet.Query<Customer>(c => c.Name == "Name2" && c.Surname == "Surname2").First().Id });
            this.Update<Vehicle>();

            this.DataSet.Add(new Specialization() { Name = "TestSpec" });
            this.DataSet.Add(new Specialization() { Name = "TestSpec2" });
            this.Update<Specialization>();
            this.DataSet.Add(new Mechanic() { Name = "Name1", Surname = "Surname1", UserId = this.DataSet.Query<AppUser>(c => c.Username == "admin").First().Id });
            this.DataSet.Add(new Mechanic() { Name = "Name2", Surname = "Surname2", UserId = this.DataSet.Query<AppUser>(c => c.Username == "admin").First().Id });
            this.Update<Mechanic>();
            this.DataSet.Add(new MechanicSpecialization() { SpecializationId = this.DataSet.Query<Specialization>(c => c.Name == "TestSpec").First().Id, MechanicId = this.DataSet.Query<Mechanic>(c => c.Name == "Name1").First().Id });
            this.DataSet.Add(new MechanicSpecialization() { SpecializationId = this.DataSet.Query<Specialization>(c => c.Name == "TestSpec2").First().Id, MechanicId = this.DataSet.Query<Mechanic>(c => c.Name == "Name1").First().Id });
            this.DataSet.Add(new MechanicSpecialization() { SpecializationId = this.DataSet.Query<Specialization>(c => c.Name == "TestSpec2").First().Id, MechanicId = this.DataSet.Query<Mechanic>(c => c.Name == "Name2").First().Id });
            this.Update<MechanicSpecialization>();
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
