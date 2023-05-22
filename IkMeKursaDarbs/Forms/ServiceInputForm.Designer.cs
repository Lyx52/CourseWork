namespace IkMeKursaDarbs.Forms
{
    partial class ServiceInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.cbxCustomerSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomerStreet = new System.Windows.Forms.TextBox();
            this.btnCreateOrUpdateCustomer = new System.Windows.Forms.Button();
            this.cbxCustomerCity = new System.Windows.Forms.ComboBox();
            this.cbxCustomerCountry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerPhoneNr = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabVehicleInformation = new System.Windows.Forms.TabPage();
            this.btnRemoveVeh = new System.Windows.Forms.Button();
            this.cbxVinSearch = new System.Windows.Forms.ComboBox();
            this.btnAddVeh = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVehicleBrand = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCreateOrUpdateVeh = new System.Windows.Forms.Button();
            this.txtVehicleModel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVehicleVin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabService = new System.Windows.Forms.TabPage();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.trwPanel = new System.Windows.Forms.Panel();
            this.btnTaskSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbxTaskMechanic = new System.Windows.Forms.ComboBox();
            this.cbxTaskSpec = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.dtpTaskDue = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.tabControl.SuspendLayout();
            this.tabCustomer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabVehicleInformation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabService.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCustomer);
            this.tabControl.Controls.Add(this.tabVehicleInformation);
            this.tabControl.Controls.Add(this.tabService);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.btnDeleteCustomer);
            this.tabCustomer.Controls.Add(this.btnRemoveCustomer);
            this.tabCustomer.Controls.Add(this.cbxCustomerSearch);
            this.tabCustomer.Controls.Add(this.groupBox1);
            this.tabCustomer.Controls.Add(this.btnAddCustomer);
            this.tabCustomer.Controls.Add(this.label1);
            this.tabCustomer.Location = new System.Drawing.Point(4, 25);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomer.Size = new System.Drawing.Size(792, 421);
            this.tabCustomer.TabIndex = 0;
            this.tabCustomer.Text = "Customer info";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(417, 33);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCustomer.TabIndex = 25;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Location = new System.Drawing.Point(336, 33);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCustomer.TabIndex = 24;
            this.btnRemoveCustomer.Text = "Remove";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // cbxCustomerSearch
            // 
            this.cbxCustomerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCustomerSearch.FormattingEnabled = true;
            this.cbxCustomerSearch.Location = new System.Drawing.Point(11, 32);
            this.cbxCustomerSearch.Name = "cbxCustomerSearch";
            this.cbxCustomerSearch.Size = new System.Drawing.Size(238, 24);
            this.cbxCustomerSearch.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomerStreet);
            this.groupBox1.Controls.Add(this.btnCreateOrUpdateCustomer);
            this.groupBox1.Controls.Add(this.cbxCustomerCity);
            this.groupBox1.Controls.Add(this.cbxCustomerCountry);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCustomerEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCustomerPhoneNr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCustomerSurname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 353);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer information";
            // 
            // txtCustomerStreet
            // 
            this.txtCustomerStreet.Location = new System.Drawing.Point(429, 145);
            this.txtCustomerStreet.Name = "txtCustomerStreet";
            this.txtCustomerStreet.Size = new System.Drawing.Size(196, 23);
            this.txtCustomerStreet.TabIndex = 24;
            // 
            // btnCreateOrUpdateCustomer
            // 
            this.btnCreateOrUpdateCustomer.Location = new System.Drawing.Point(640, 22);
            this.btnCreateOrUpdateCustomer.Name = "btnCreateOrUpdateCustomer";
            this.btnCreateOrUpdateCustomer.Size = new System.Drawing.Size(127, 23);
            this.btnCreateOrUpdateCustomer.TabIndex = 7;
            this.btnCreateOrUpdateCustomer.Text = "Create customer";
            this.btnCreateOrUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnCreateOrUpdateCustomer.Click += new System.EventHandler(this.btnCreateOrUpdate_Click);
            // 
            // cbxCustomerCity
            // 
            this.cbxCustomerCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCustomerCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCustomerCity.FormattingEnabled = true;
            this.cbxCustomerCity.Location = new System.Drawing.Point(429, 98);
            this.cbxCustomerCity.Name = "cbxCustomerCity";
            this.cbxCustomerCity.Size = new System.Drawing.Size(196, 24);
            this.cbxCustomerCity.TabIndex = 22;
            this.cbxCustomerCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCustomerCity_KeyDown);
            // 
            // cbxCustomerCountry
            // 
            this.cbxCustomerCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCustomerCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCustomerCountry.FormattingEnabled = true;
            this.cbxCustomerCountry.Location = new System.Drawing.Point(429, 53);
            this.cbxCustomerCountry.Name = "cbxCustomerCountry";
            this.cbxCustomerCountry.Size = new System.Drawing.Size(196, 24);
            this.cbxCustomerCountry.TabIndex = 21;
            this.cbxCustomerCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCustomerCountry_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(322, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Street";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(322, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Country";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(113, 180);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(125, 23);
            this.txtCustomerEmail.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "E-mail";
            // 
            // txtCustomerPhoneNr
            // 
            this.txtCustomerPhoneNr.Location = new System.Drawing.Point(113, 137);
            this.txtCustomerPhoneNr.Mask = "+000 00000000";
            this.txtCustomerPhoneNr.Name = "txtCustomerPhoneNr";
            this.txtCustomerPhoneNr.Size = new System.Drawing.Size(125, 23);
            this.txtCustomerPhoneNr.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Phone number";
            // 
            // txtCustomerSurname
            // 
            this.txtCustomerSurname.Location = new System.Drawing.Point(113, 98);
            this.txtCustomerSurname.Name = "txtCustomerSurname";
            this.txtCustomerSurname.Size = new System.Drawing.Size(125, 23);
            this.txtCustomerSurname.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Surname";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(113, 54);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(125, 23);
            this.txtCustomerName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(255, 33);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomer.TabIndex = 5;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search customer(Name surname)";
            // 
            // tabVehicleInformation
            // 
            this.tabVehicleInformation.Controls.Add(this.btnRemoveVeh);
            this.tabVehicleInformation.Controls.Add(this.cbxVinSearch);
            this.tabVehicleInformation.Controls.Add(this.btnAddVeh);
            this.tabVehicleInformation.Controls.Add(this.label16);
            this.tabVehicleInformation.Controls.Add(this.groupBox2);
            this.tabVehicleInformation.Location = new System.Drawing.Point(4, 25);
            this.tabVehicleInformation.Name = "tabVehicleInformation";
            this.tabVehicleInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabVehicleInformation.Size = new System.Drawing.Size(792, 421);
            this.tabVehicleInformation.TabIndex = 1;
            this.tabVehicleInformation.Text = "Vehicle info";
            this.tabVehicleInformation.UseVisualStyleBackColor = true;
            // 
            // btnRemoveVeh
            // 
            this.btnRemoveVeh.Location = new System.Drawing.Point(336, 34);
            this.btnRemoveVeh.Name = "btnRemoveVeh";
            this.btnRemoveVeh.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveVeh.TabIndex = 25;
            this.btnRemoveVeh.Text = "Remove";
            this.btnRemoveVeh.UseVisualStyleBackColor = true;
            this.btnRemoveVeh.Click += new System.EventHandler(this.btnRemoveVeh_Click);
            // 
            // cbxVinSearch
            // 
            this.cbxVinSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxVinSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxVinSearch.FormattingEnabled = true;
            this.cbxVinSearch.Location = new System.Drawing.Point(11, 33);
            this.cbxVinSearch.Name = "cbxVinSearch";
            this.cbxVinSearch.Size = new System.Drawing.Size(238, 24);
            this.cbxVinSearch.TabIndex = 24;
            // 
            // btnAddVeh
            // 
            this.btnAddVeh.Location = new System.Drawing.Point(255, 33);
            this.btnAddVeh.Name = "btnAddVeh";
            this.btnAddVeh.Size = new System.Drawing.Size(75, 23);
            this.btnAddVeh.TabIndex = 10;
            this.btnAddVeh.Text = "Add";
            this.btnAddVeh.UseVisualStyleBackColor = true;
            this.btnAddVeh.Click += new System.EventHandler(this.btnAddVeh_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(216, 17);
            this.label16.TabIndex = 9;
            this.label16.Text = "Search customer vehicle VIN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVehicleBrand);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnCreateOrUpdateVeh);
            this.groupBox2.Controls.Add(this.txtVehicleModel);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtVehicleVin);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(11, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(773, 353);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vehicle information";
            // 
            // txtVehicleBrand
            // 
            this.txtVehicleBrand.Location = new System.Drawing.Point(426, 54);
            this.txtVehicleBrand.Name = "txtVehicleBrand";
            this.txtVehicleBrand.Size = new System.Drawing.Size(125, 23);
            this.txtVehicleBrand.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(319, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Brand";
            // 
            // btnCreateOrUpdateVeh
            // 
            this.btnCreateOrUpdateVeh.Location = new System.Drawing.Point(640, 22);
            this.btnCreateOrUpdateVeh.Name = "btnCreateOrUpdateVeh";
            this.btnCreateOrUpdateVeh.Size = new System.Drawing.Size(127, 23);
            this.btnCreateOrUpdateVeh.TabIndex = 7;
            this.btnCreateOrUpdateVeh.Text = "Create vehicle";
            this.btnCreateOrUpdateVeh.UseVisualStyleBackColor = true;
            this.btnCreateOrUpdateVeh.Click += new System.EventHandler(this.btnCreateOrUpdateVeh_Click);
            // 
            // txtVehicleModel
            // 
            this.txtVehicleModel.Location = new System.Drawing.Point(113, 98);
            this.txtVehicleModel.Name = "txtVehicleModel";
            this.txtVehicleModel.Size = new System.Drawing.Size(125, 23);
            this.txtVehicleModel.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Model";
            // 
            // txtVehicleVin
            // 
            this.txtVehicleVin.Location = new System.Drawing.Point(113, 54);
            this.txtVehicleVin.Name = "txtVehicleVin";
            this.txtVehicleVin.Size = new System.Drawing.Size(125, 23);
            this.txtVehicleVin.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "VIN Nr.";
            // 
            // tabService
            // 
            this.tabService.Controls.Add(this.lblNodeName);
            this.tabService.Controls.Add(this.trwPanel);
            this.tabService.Controls.Add(this.btnTaskSave);
            this.tabService.Controls.Add(this.groupBox3);
            this.tabService.Controls.Add(this.btnAddNewTask);
            this.tabService.Location = new System.Drawing.Point(4, 25);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(792, 421);
            this.tabService.TabIndex = 2;
            this.tabService.Text = "Service tasks";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // lblNodeName
            // 
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Location = new System.Drawing.Point(361, 15);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(0, 17);
            this.lblNodeName.TabIndex = 5;
            // 
            // trwPanel
            // 
            this.trwPanel.Location = new System.Drawing.Point(3, 6);
            this.trwPanel.Name = "trwPanel";
            this.trwPanel.Size = new System.Drawing.Size(343, 407);
            this.trwPanel.TabIndex = 4;
            // 
            // btnTaskSave
            // 
            this.btnTaskSave.Location = new System.Drawing.Point(614, 6);
            this.btnTaskSave.Name = "btnTaskSave";
            this.btnTaskSave.Size = new System.Drawing.Size(82, 23);
            this.btnTaskSave.TabIndex = 3;
            this.btnTaskSave.Text = "Save";
            this.btnTaskSave.UseVisualStyleBackColor = true;
            this.btnTaskSave.Click += new System.EventHandler(this.btnTaskSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cbxTaskMechanic);
            this.groupBox3.Controls.Add(this.cbxTaskSpec);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtTaskName);
            this.groupBox3.Controls.Add(this.dtpTaskDue);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTaskDescription);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(352, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 358);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Task information";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(231, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 17);
            this.label18.TabIndex = 16;
            this.label18.Text = "Assign mechanic";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 17);
            this.label17.TabIndex = 15;
            this.label17.Text = "Req. Specialization";
            // 
            // cbxTaskMechanic
            // 
            this.cbxTaskMechanic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTaskMechanic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTaskMechanic.FormattingEnabled = true;
            this.cbxTaskMechanic.Location = new System.Drawing.Point(234, 116);
            this.cbxTaskMechanic.Name = "cbxTaskMechanic";
            this.cbxTaskMechanic.Size = new System.Drawing.Size(189, 24);
            this.cbxTaskMechanic.TabIndex = 14;
            // 
            // cbxTaskSpec
            // 
            this.cbxTaskSpec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTaskSpec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTaskSpec.FormattingEnabled = true;
            this.cbxTaskSpec.Location = new System.Drawing.Point(9, 116);
            this.cbxTaskSpec.Name = "cbxTaskSpec";
            this.cbxTaskSpec.Size = new System.Drawing.Size(197, 24);
            this.cbxTaskSpec.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Name";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(9, 54);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(197, 23);
            this.txtTaskName.TabIndex = 3;
            // 
            // dtpTaskDue
            // 
            this.dtpTaskDue.Location = new System.Drawing.Point(9, 260);
            this.dtpTaskDue.Name = "dtpTaskDue";
            this.dtpTaskDue.Size = new System.Drawing.Size(200, 23);
            this.dtpTaskDue.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Due date";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(6, 179);
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(417, 52);
            this.txtTaskDescription.TabIndex = 7;
            this.txtTaskDescription.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Description";
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.Location = new System.Drawing.Point(702, 6);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(82, 23);
            this.btnAddNewTask.TabIndex = 1;
            this.btnAddNewTask.Text = "Add new";
            this.btnAddNewTask.UseVisualStyleBackColor = true;
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // ServiceInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "ServiceInputForm";
            this.Text = "Create service";
            this.tabControl.ResumeLayout(false);
            this.tabCustomer.ResumeLayout(false);
            this.tabCustomer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabVehicleInformation.ResumeLayout(false);
            this.tabVehicleInformation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabService.ResumeLayout(false);
            this.tabService.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabVehicleInformation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtCustomerPhoneNr;
        private System.Windows.Forms.ComboBox cbxCustomerCity;
        private System.Windows.Forms.ComboBox cbxCustomerCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateOrUpdateCustomer;
        private System.Windows.Forms.Button btnAddVeh;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCreateOrUpdateVeh;
        private System.Windows.Forms.TextBox txtVehicleModel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVehicleVin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVehicleBrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabService;
        private System.Windows.Forms.Button btnAddNewTask;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtTaskDescription;
        private System.Windows.Forms.DateTimePicker dtpTaskDue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button btnTaskSave;
        private System.Windows.Forms.ComboBox cbxCustomerSearch;
        private System.Windows.Forms.TextBox txtCustomerStreet;
        private System.Windows.Forms.ComboBox cbxVinSearch;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Panel trwPanel;
        private System.Windows.Forms.Button btnRemoveVeh;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbxTaskMechanic;
        private System.Windows.Forms.ComboBox cbxTaskSpec;
        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.Button btnDeleteCustomer;
    }
}