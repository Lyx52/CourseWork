namespace IkMeKursaDarbs.Components
{
    partial class DashboardComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calSchedule = new System.Windows.Forms.MonthCalendar();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lswTasks = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShowServiceDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calSchedule
            // 
            this.calSchedule.Location = new System.Drawing.Point(773, 54);
            this.calSchedule.Name = "calSchedule";
            this.calSchedule.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(993, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(119, 29);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lswTasks
            // 
            this.lswTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.DueDate});
            this.lswTasks.HideSelection = false;
            this.lswTasks.Location = new System.Drawing.Point(14, 13);
            this.lswTasks.Name = "lswTasks";
            this.lswTasks.Size = new System.Drawing.Size(433, 203);
            this.lswTasks.TabIndex = 2;
            this.lswTasks.UseCompatibleStateImageBehavior = false;
            this.lswTasks.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 251;
            // 
            // DueDate
            // 
            this.DueDate.Text = "DueDate";
            this.DueDate.Width = 175;
            // 
            // btnShowServiceDialog
            // 
            this.btnShowServiceDialog.Location = new System.Drawing.Point(453, 13);
            this.btnShowServiceDialog.Name = "btnShowServiceDialog";
            this.btnShowServiceDialog.Size = new System.Drawing.Size(119, 29);
            this.btnShowServiceDialog.TabIndex = 3;
            this.btnShowServiceDialog.Text = "Open service form";
            this.btnShowServiceDialog.UseVisualStyleBackColor = true;
            this.btnShowServiceDialog.Click += new System.EventHandler(this.btnShowServiceDialog_Click);
            // 
            // DashboardComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnShowServiceDialog);
            this.Controls.Add(this.lswTasks);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.calSchedule);
            this.Size = new System.Drawing.Size(1121, 225);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calSchedule;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListView lswTasks;
        private System.Windows.Forms.Button btnShowServiceDialog;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader DueDate;
    }
}
