using IkMeKursaDarbs.Components;
using IkMeKursaDarbs.Data;
using IkMeKursaDarbs.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IkMeKursaDarbs.Forms
{
    public partial class ServiceInputForm : Form
    {
        // Customer
        private Customer customer = new Customer();
        private Address customerAddress = new Address();
        private City customerCity = new City();
        private Country customerCountry = new Country();
        // Vehicle
        private Vehicle customerVehicle = new Vehicle();
        
        // Tasks
        private Mechanic taskMechanic = new Mechanic();
        private Specialization taskReqSpec = new Specialization();
        private MechanicTask task = new MechanicTask();

        bool IsVehPageEnabled = false;
        bool IsServicePageEnabled = false;
        int SelectedCustomer = -1;
        int SelectedVehicle = -1;
        public ServiceInputForm()
        {
            InitializeComponent();
            tabControl.Selecting += TabControl_Selecting;

            // Customer page
            UpdateNamesAndSurnamesColumn();
            txtCustomerName.DataBindings.Add("Text", customer, "Name");
            txtCustomerSurname.DataBindings.Add("Text", customer, "Surname");
            txtCustomerEmail.DataBindings.Add("Text", customer, "Email");
            txtCustomerPhoneNr.DataBindings.Add("Text", customer, "PhoneNumber");

            BindingSource customerBindingSource = new BindingSource();
            customerBindingSource.DataSource = Program.DbContext.DataSet;
            customerBindingSource.DataMember = typeof(Customer).Name;

            cbxCustomerSearch.DataSource = customerBindingSource;
            cbxCustomerSearch.DisplayMember = "NameAndSurname";
            cbxCustomerSearch.ValueMember = "Id";

            // Definejam valsts combobox
            BindingSource countryBindingSource = new BindingSource();
            countryBindingSource.DataSource = Program.DbContext.DataSet;
            countryBindingSource.DataMember = "Country";
            cbxCustomerCountry.DataSource = countryBindingSource;
            cbxCustomerCountry.DisplayMember = "Name";

            // Definejam pilsetas combobox
            BindingSource cityBindingSource = new BindingSource();
            cityBindingSource.DataSource = countryBindingSource;
            cityBindingSource.DataMember = Program.DbContext[typeof(Country).Name, typeof(City).Name].RelationName;
            cbxCustomerCity.DataSource = cityBindingSource;
            cbxCustomerCity.DisplayMember = "Name";

            // Veh info page
            BindingSource vehBindingSource = new BindingSource();
            vehBindingSource.DataSource = customerBindingSource;
            vehBindingSource.DataMember = Program.DbContext[typeof(Customer).Name, typeof(Vehicle).Name].RelationName;
            cbxVinSearch.DataSource = vehBindingSource;
            cbxVinSearch.DisplayMember = "VinNumber";
            txtVehicleModel.DataBindings.Add("Text", customerVehicle, "Model");
            txtVehicleBrand.DataBindings.Add("Text", customerVehicle, "Brand");
            txtVehicleVin.DataBindings.Add("Text", customerVehicle, "VinNumber");

            // Service page
            var trwTasks = RecursiveTreeView<MechanicTask>.Create<MechanicTask>(t => t.ParentTaskId, t => t.Name);
            trwTasks.Dock = DockStyle.Fill;
            trwPanel.Controls.Add(trwTasks);
            txtTaskName.DataBindings.Add("Text", task, "Name");
            txtTaskDescription.DataBindings.Add("Text", task, "Description");

            BindingSource reqSpecBindingSource = new BindingSource();
            reqSpecBindingSource.DataSource = Program.DbContext[typeof(Specialization).Name, typeof(Mechanic).Name].RelationName;
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!IsVehPageEnabled && e.TabPage == tabVehicleInformation) e.Cancel = true;
            if (!IsServicePageEnabled && e.TabPage == tabService) e.Cancel = true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (cbxCustomerSearch.SelectedItem is null) return;
            var rowCustomer  = (cbxCustomerSearch.SelectedItem as DataRowView).Row.GetRowAsType<Customer>();
            txtCustomerPhoneNr.Text = rowCustomer.PhoneNumber;
            txtCustomerEmail.Text = rowCustomer.Email;
            txtCustomerName.Text = rowCustomer.Name;
            txtCustomerSurname.Text = rowCustomer.Surname;
            if (rowCustomer.AddressId > 0)
            {
                customerAddress = Program.DbContext.DataSet.Query<Address>(a => a.Id == rowCustomer.AddressId).FirstOrDefault();
                customerCity = Program.DbContext.DataSet.Query<City>(a => a.Id == customerAddress?.CityId).FirstOrDefault();
                customerCountry = Program.DbContext.DataSet.Query<Country>(a => a.Id == customerCity?.CountryId).FirstOrDefault();
                txtCustomerStreet.Text = customerAddress?.Street ?? string.Empty;
                SelectByPrimaryKey(cbxCustomerCountry, customerCountry.Id);
                SelectByPrimaryKey(cbxCustomerCity, customerCity.Id);
            }
            SelectedCustomer = cbxCustomerSearch.SelectedIndex;
            customer = rowCustomer;

            btnCreateOrUpdateCustomer.Text = "Update customer";
        }
        private void SelectByPrimaryKey(System.Windows.Forms.ComboBox cbox, int pk)
        {
            foreach(DataRowView row in cbox.Items)
            {
                if ((int)row.Row["Id"] == pk)
                {
                    cbox.SelectedItem = row;
                    break;
                }
            }
        }
        private bool ValidateProperty<TDataType>(TDataType value, Expression<Func<TDataType, object>> expr)
        {
            object entityValue = expr.Compile()(value);
            if (entityValue?.GetType() == typeof(string) && string.IsNullOrEmpty((string)entityValue) || entityValue == null)
            {
                ShowValidationError($"Field {Utils.GetMemberName(expr)} is invalid or empty!");
                return true;
            }
            return false;
        }
        private void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCreateOrUpdate_Click(object sender, EventArgs e)
        {
            if (cbxCustomerCity.SelectedItem is null)
            {
                ShowValidationError("City not selected!");
                return;
            }
            if (cbxCustomerCountry.SelectedItem is null)
            {
                ShowValidationError("Country not selected!");
                return;
            }
            customerAddress.CityId = customerCity.Id;
            customerAddress.Street = txtCustomerStreet.Text;

            // Validate country and city
            if (ValidateProperty<Country>(customerCountry, c => c.Name)) return;
            if (ValidateProperty<City>(customerCity, c => c.Name)) return;
            if (ValidateProperty<Address>(customerAddress, c => c.Street)) return;

            if (ValidateProperty<Customer>(customer, c => c.Surname)) return;
            if (ValidateProperty<Customer>(customer, c => c.Name)) return;
            if (ValidateProperty<Customer>(customer, c => c.PhoneNumber)) return;
            if (ValidateProperty<Customer>(customer, c => c.Email)) return;
            
            // Add address if it has pk
            if (customerAddress.Id <= 0)
            {
                Program.DbContext.DataSet.Add<Address>(customerAddress);
                Program.DbContext.Update<Address>();
            }


            if (customerAddress.Id <= 0)
            {
                Program.DbContext.DataSet.Add<Customer>(customer);
                Program.DbContext.Update<Customer>();
            }

            // Update
            Program.DbContext.DataSet.Update<Address>(customerAddress);
            Program.DbContext.Update<Address>();
            customer.AddressId = customerAddress.Id;
            Program.DbContext.DataSet.Update<Customer>(customer);
            Program.DbContext.Update<Customer>();
            UpdateNamesAndSurnamesColumn();
            cbxCustomerSearch.SelectedIndex = SelectedCustomer < 0 ? cbxCustomerSearch.Items.Count - 1 : SelectedCustomer;
            IsVehPageEnabled = true;
            tabControl.SelectedTab = tabVehicleInformation;
        }
        private void UpdateNamesAndSurnamesColumn()
        {
            if (!Program.DbContext[typeof(Customer).Name].Columns.Contains("NameAndSurname"))
                Program.DbContext[typeof(Customer).Name].Columns.Add(new DataColumn() { ColumnName = "NameAndSurname", AllowDBNull = true });
            foreach (DataRow row in Program.DbContext[typeof(Customer).Name].Rows)
            {
                string name = row["Name"].ToString();
                string surname = row["Surname"].ToString();
                row["NameAndSurname"] = $"{name} {surname}";
            }
        }
        private void cbxCustomerCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string newInput = cbxCustomerCity.Text.Trim();

                if (!string.IsNullOrEmpty(newInput) && cbxCustomerCountry.SelectedItem != null)
                {
                    var country = (cbxCustomerCountry.SelectedItem as DataRowView).Row.GetRowAsType<Country>();
                    if (!cbxCustomerCity.Items.Contains(newInput) && country.Id > 0)
                    {
                        Program.DbContext.DataSet.Add<City>(new City()
                        {
                            CountryId = country.Id,
                            Name = newInput
                        });

                        Program.DbContext.Update<City>();
                        cbxCustomerCity.SelectedIndex = cbxCustomerCity.Items.Count - 1;
                    }
                }
            }
        }

        private void cbxCustomerCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string newInput = cbxCustomerCountry.Text.Trim();

                if (!string.IsNullOrEmpty(newInput))
                {
                    if (!cbxCustomerCity.Items.Contains(newInput))
                    {
                        Program.DbContext.DataSet.Add<Country>(new Country()
                        {
                            Name = newInput
                        });

                        Program.DbContext.Update<Country>();
                        cbxCustomerCountry.SelectedIndex = cbxCustomerCountry.Items.Count - 1;
                    }
                }
            }
        }

        private void cbxCustomerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCustomerCountry.SelectedItem is null) return;
            customerCountry = (cbxCustomerCountry.SelectedItem as DataRowView).Row.GetRowAsType<Country>();
        }

        private void cbxCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCustomerCity.SelectedItem is null) return;
            customerCity = (cbxCustomerCity.SelectedItem as DataRowView).Row.GetRowAsType<City>();
        }

        private void btnAddVeh_Click(object sender, EventArgs e)
        {
            if(cbxVinSearch.SelectedItem is null) return;
            var vehInfo = (cbxVinSearch.SelectedItem as DataRowView).Row.GetRowAsType<Vehicle>();
            txtVehicleVin.Text = vehInfo.VinNumber;
            txtVehicleBrand.Text = vehInfo.Brand;
            txtVehicleModel.Text = vehInfo.Model;
            customerVehicle = vehInfo;
            SelectedVehicle = cbxVinSearch.SelectedIndex;
            btnCreateOrUpdateVeh.Text = "Update vehicle";
        }

        private void btnCreateOrUpdateVeh_Click(object sender, EventArgs e)
        {
            // Add vehicle if it has pk
            if (customerVehicle.Id <= 0)
            {
                Program.DbContext.DataSet.Add<Vehicle>(customerVehicle);
                Program.DbContext.Update<Vehicle>();
            }

            // Update
            customerVehicle.OwnerId = customer.Id;
            Program.DbContext.DataSet.Update<Vehicle>(customerVehicle);
            Program.DbContext.Update<Vehicle>();
            UpdateNamesAndSurnamesColumn();
            cbxVinSearch.SelectedIndex = SelectedVehicle < 0 ? cbxVinSearch.Items.Count - 1 : SelectedVehicle;
            IsServicePageEnabled = true;
            tabControl.SelectedTab = tabService;
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            customer.Id = 0;
            SelectedCustomer = -1;
            cbxCustomerSearch.SelectedIndex = -1;
            txtCustomerEmail.Text = string.Empty;
            txtCustomerPhoneNr.Text = string.Empty;
            txtCustomerStreet.Text = string.Empty;
            txtCustomerSurname.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            cbxCustomerCountry.SelectedIndex = -1;
            cbxCustomerCity.SelectedIndex = -1;
            btnCreateOrUpdateCustomer.Text = "Create customer";
        }

        private void btnRemoveVeh_Click(object sender, EventArgs e)
        {
            customerVehicle.Id = 0;
            SelectedVehicle = -1;
            cbxVinSearch.SelectedIndex = -1;
            txtVehicleBrand.Text = string.Empty;
            txtVehicleModel.Text = string.Empty;
            txtVehicleVin.Text = string.Empty;
            btnCreateOrUpdateVeh.Text = "Create vehicle";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Program.DbContext.DataSet.Add(task);
            Program.DbContext.Update<Address>();
        }
    }
}
