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
        private MechanicTask task = new MechanicTask();
        private DataView mechComboboxView = new DataView(Program.DbContext[typeof(Mechanic).Name]); 
        private bool IsVehPageEnabled = false;
        private bool IsServicePageEnabled = false;
        private int SelectedCustomer = -1;
        private int SelectedVehicle = -1;
        private bool isUpdatingVehicle = false;
        private bool isUpdatingCustomer = false;
        private MechanicTask _parentTask = null;
        private TreeNode _selectedNode = null;
        private RecursiveTreeView<MechanicTask> trwTasks;
        private DateTime dueDate
        {
            get => new DateTime(task.Due);
            set => task.Due = value.Ticks;
        }
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
            this.trwTasks = RecursiveTreeView<MechanicTask>.Create<MechanicTask>(t => t.ParentTaskId, t => t.Name);
            this.trwTasks.Dock = DockStyle.Fill;
            this.trwTasks.NodeMouseClick += TrwTasks_NodeMouseClick;
            trwPanel.Controls.Add(this.trwTasks);
            dueDate = DateTime.UtcNow;
            cbxTaskMechanic.DataSource = mechComboboxView;
            cbxTaskMechanic.DisplayMember = "Name";
            cbxTaskMechanic.ValueMember = "Id";

            cbxTaskSpec.DataSource = Program.DbContext[typeof(Specialization).Name];
            cbxTaskSpec.DisplayMember = "Name";
            cbxTaskSpec.ValueMember = "Id";
            cbxTaskSpec.SelectedIndexChanged += (sender, e) =>
            {
                int selectedSpecializationId = (int)cbxTaskSpec.SelectedValue;
                var mechanics = Program.DbContext.DataSet.Query<MechanicSpecialization>(ms => ms.SpecializationId == selectedSpecializationId).Select(ms => ms.MechanicId);
                if (mechanics.Any())
                {
                    mechComboboxView.RowFilter = $"Id IN ({string.Join(",", mechanics)})";
                } else
                {
                    // Lai nerāda nevienu vērtību
                    mechComboboxView.RowFilter = "Id = -1";
                }
            };
            this.trwTasks.LostFocus += TrwTasks_LostFocus;
        }

        private void TrwTasks_LostFocus(object sender, EventArgs e)
        {
            lblNodeName.Text = this.task.Name;
        }

        private void TrwTasks_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
                var selectedTask = (e.Node.Tag as DataRow).GetRowAsType<MechanicTask>();

            txtTaskName.Text = selectedTask.Name;
            txtTaskDescription.Text = selectedTask.Description;
            dtpTaskDue.Value = selectedTask.Due > 0 ? new DateTime(selectedTask.Due) : DateTime.UtcNow;
            var mechSpec = Program.DbContext.DataSet.Query<MechanicSpecialization>(s => s.Id == selectedTask.MechSpecId).FirstOrDefault();
            if (mechSpec != null)
            {
                SelectByPrimaryKey(cbxTaskSpec, mechSpec.SpecializationId);
                SelectByPrimaryKey(cbxTaskMechanic, mechSpec.MechanicId);
            } else
            {
                cbxTaskSpec.SelectedIndex = 0;
                cbxTaskMechanic.SelectedIndex = 0;
            }
            this.task = selectedTask;
            lblNodeName.Text = this.task.Name;
            this._selectedNode = e.Node;
            if (e.Node.Parent != null && e.Node.Parent.Tag != null)
            {
                _parentTask = (e.Node.Parent.Tag as DataRow).GetRowAsType<MechanicTask>();
            }
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
                if (customerCountry != null) SelectByPrimaryKey(cbxCustomerCountry, customerCountry.Id);
                if (customerCity != null) SelectByPrimaryKey(cbxCustomerCity, customerCity.Id);
                if (customerAddress is null) customerAddress = new Address();
            }
            SelectedCustomer = cbxCustomerSearch.SelectedIndex;
            customer = rowCustomer;

            btnCreateOrUpdateCustomer.Text = "Update customer";
            isUpdatingCustomer = true;
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

            customerCity = (cbxCustomerCity.SelectedItem as DataRowView).Row.GetRowAsType<City>();
            customerCountry = (cbxCustomerCountry.SelectedItem as DataRowView).Row.GetRowAsType<Country>();
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
            var address = Program.DbContext.DataSet.Query<Address>(a => a.Id == customerAddress.Id).FirstOrDefault();
            customerAddress.Id = address?.Id ?? 0;

            // Add address if it has pk
            if (customerAddress.Id <= 0)
            {
                var row = Program.DbContext.DataSet.Add<Address>(customerAddress);
                Program.DbContext.Update<Address>();
                customerAddress = row.GetRowAsType<Address>();
            } else
            {
                // Update
                var row = Program.DbContext.DataSet.Update<Address>(customerAddress);
                Program.DbContext.Update<Address>();
                customerAddress = row.GetRowAsType<Address>();
            }
                
            customer.AddressId = customerAddress?.Id ?? 0;
            if (isUpdatingCustomer)
            {
                var row = Program.DbContext.DataSet.Update<Customer>(customer);
                Program.DbContext.Update<Customer>();
                customer = row.GetRowAsType<Customer>();
            } else
            {
                var row = Program.DbContext.DataSet.Add<Customer>(customer);
                Program.DbContext.Update<Customer>();
                customer = row.GetRowAsType<Customer>();
            }
            
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
            isUpdatingVehicle = true;
        }

        private void btnCreateOrUpdateVeh_Click(object sender, EventArgs e)
        {

            if (ValidateProperty<Vehicle>(customerVehicle, v => v.Model)) return;
            if (ValidateProperty<Vehicle>(customerVehicle, v => v.VinNumber)) return;
            if (ValidateProperty<Vehicle>(customerVehicle, v => v.Brand)) return;

            customerVehicle.OwnerId = customer?.Id ?? 0;

            // Add vehicle if it has pk
            if (isUpdatingVehicle)
            {
                // Update
                var row = Program.DbContext.DataSet.Update<Vehicle>(customerVehicle);
                Program.DbContext.Update<Vehicle>();
                customerVehicle = row.GetRowAsType<Vehicle>();
            } else
            {
                var row = Program.DbContext.DataSet.Add<Vehicle>(customerVehicle);
                Program.DbContext.Update<Vehicle>();
                customerVehicle = row.GetRowAsType<Vehicle>();
            }

            this.trwTasks.queryFilter = $" VehicleId = '{customerVehicle.Id}'";
            this.trwTasks.RefreshNodes();
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
            isUpdatingCustomer = false;
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
            isUpdatingVehicle = false;
        }
        private void AddOrUpdateNewTask(int parentId)
        {
            if (cbxTaskSpec.SelectedItem is null)
            {
                ShowValidationError("Mechanic Spec. not selected!");
                return;
            }
            if (cbxTaskMechanic.SelectedItem is null)
            {
                ShowValidationError("Mechanic not selected!");
                return;
            }

            var spec = (cbxTaskSpec.SelectedItem as DataRowView).Row.GetRowAsType<Specialization>();
            var mechanic = (cbxTaskMechanic.SelectedItem as DataRowView).Row.GetRowAsType<Mechanic>();
            var mechSpec = Program.DbContext.DataSet.Query<MechanicSpecialization>(ms => ms.MechanicId == mechanic.Id && ms.SpecializationId == spec.Id).FirstOrDefault();
            if (mechSpec is null)
            {
                ShowValidationError("Mechanic does not have this specialization!");
                return;
            }
            dueDate = dtpTaskDue.Value;
            task.Description = txtTaskDescription.Text;
            task.Name = txtTaskName.Text;
            if (ValidateProperty<MechanicTask>(task, t => t.Name)) return;
            if (ValidateProperty<MechanicTask>(task, t => t.Description)) return;
            if (ValidateProperty<MechanicTask>(task, t => t.Due > 0)) return;
            task.Created = DateTime.UtcNow.Ticks;
            task.MechSpecId = mechSpec.Id;
            if (task.Id <= 0)
            {
                if (_selectedNode != null && _selectedNode.Tag != null) 
                    (_selectedNode.Tag as DataRow).Delete();
                Program.DbContext[typeof(MechanicTask).Name].AcceptChanges();
                task.VehicleId = customerVehicle.Id;
                task.ParentTaskId = parentId;
                Program.DbContext.DataSet.Add(task);
            } else
            {
                Program.DbContext.DataSet.Update(task);
            }
            try
            {
                Program.DbContext.Update<MechanicTask>();
            } catch (Exception e)
            {
                MessageBox.Show("Must fill out each of the tasks before saving!", "Saving error!", MessageBoxButtons.OK);
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _selectedNode = null;
            _parentTask = null;
            task.Id = -1;
            AddOrUpdateNewTask(-1);
            this.trwTasks.RefreshNodes();
        }

        private void btnTaskSave_Click(object sender, EventArgs e)
        {
            if (_selectedNode == null) return;
            AddOrUpdateNewTask(_parentTask?.Id ?? -1);
            this.trwTasks.RefreshNodes();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (customer is null) return;
            Program.DbContext.DataSet.Remove<Customer>(customer);
            Program.DbContext.Update<Customer>();
        }
    }
}
