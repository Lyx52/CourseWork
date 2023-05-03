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
            this.cbxCustomerSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomerStreet = new System.Windows.Forms.TextBox();
            this.btnCreateOrUpdate = new System.Windows.Forms.Button();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.trwTasks = new System.Windows.Forms.TreeView();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.btnCreateOrUpdate);
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
            // btnCreateOrUpdate
            // 
            this.btnCreateOrUpdate.Location = new System.Drawing.Point(640, 22);
            this.btnCreateOrUpdate.Name = "btnCreateOrUpdate";
            this.btnCreateOrUpdate.Size = new System.Drawing.Size(127, 23);
            this.btnCreateOrUpdate.TabIndex = 7;
            this.btnCreateOrUpdate.Text = "Create or update";
            this.btnCreateOrUpdate.UseVisualStyleBackColor = true;
            this.btnCreateOrUpdate.Click += new System.EventHandler(this.btnCreateOrUpdate_Click);
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
            this.cbxCustomerCity.SelectedIndexChanged += new System.EventHandler(this.cbxCustomerCity_SelectedIndexChanged);
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
            this.cbxCustomerCountry.SelectedIndexChanged += new System.EventHandler(this.cbxCustomerCountry_SelectedIndexChanged);
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
            this.btnCreateOrUpdateVeh.Text = "Create or update";
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
            this.tabService.Controls.Add(this.btnSave);
            this.tabService.Controls.Add(this.groupBox3);
            this.tabService.Controls.Add(this.btnAddNew);
            this.tabService.Controls.Add(this.trwTasks);
            this.tabService.Location = new System.Drawing.Point(4, 25);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(792, 421);
            this.tabService.TabIndex = 2;
            this.tabService.Text = "Service tasks";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.dtpDueDate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.dtpCreatedDate);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.rtbDescription);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(352, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 358);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Task information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 23);
            this.txtName.TabIndex = 3;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(6, 256);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDueDate.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Due date";
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.CausesValidation = false;
            this.dtpCreatedDate.Location = new System.Drawing.Point(6, 190);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpCreatedDate.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Created";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(6, 98);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(417, 52);
            this.rtbDescription.TabIndex = 7;
            this.rtbDescription.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Description";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(702, 6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(82, 23);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // trwTasks
            // 
            this.trwTasks.Location = new System.Drawing.Point(8, 6);
            this.trwTasks.Name = "trwTasks";
            this.trwTasks.Size = new System.Drawing.Size(338, 407);
            this.trwTasks.TabIndex = 0;
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
        private System.Windows.Forms.Button btnCreateOrUpdate;
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
        private System.Windows.Forms.TreeView trwTasks;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxCustomerSearch;
        private System.Windows.Forms.TextBox txtCustomerStreet;
        private System.Windows.Forms.ComboBox cbxVinSearch;
        private System.Windows.Forms.Button btnRemoveCustomer;
    }
}