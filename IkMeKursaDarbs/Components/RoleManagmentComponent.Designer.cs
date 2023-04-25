namespace IkMeKursaDarbs.Components
{
    partial class RoleManagmentComponent
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
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.cboxPremissions = new System.Windows.Forms.CheckedListBox();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstRoles = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(3, 14);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(344, 20);
            this.txtRoleName.TabIndex = 0;
            // 
            // cboxPremissions
            // 
            this.cboxPremissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxPremissions.FormattingEnabled = true;
            this.cboxPremissions.Location = new System.Drawing.Point(0, 0);
            this.cboxPremissions.Name = "cboxPremissions";
            this.cboxPremissions.Size = new System.Drawing.Size(190, 274);
            this.cboxPremissions.TabIndex = 1;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(354, 14);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(104, 23);
            this.btnAddRole.TabIndex = 2;
            this.btnAddRole.Text = "Add role";
            this.btnAddRole.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboxPremissions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstRoles);
            this.splitContainer1.Size = new System.Drawing.Size(461, 274);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 3;
            // 
            // lstRoles
            // 
            this.lstRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(0, 0);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(267, 274);
            this.lstRoles.TabIndex = 0;
            // 
            // RoleManagmentComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.txtRoleName);
            this.Name = "RoleManagmentComponent";
            this.Size = new System.Drawing.Size(461, 317);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.CheckedListBox cboxPremissions;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstRoles;
    }
}
