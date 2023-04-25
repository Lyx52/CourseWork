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
            this.cboxPremissions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cboxPremissions.FormattingEnabled = true;
            this.cboxPremissions.Location = new System.Drawing.Point(0, 58);
            this.cboxPremissions.Name = "cboxPremissions";
            this.cboxPremissions.Size = new System.Drawing.Size(461, 259);
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
            // RoleCreationComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.cboxPremissions);
            this.Controls.Add(this.txtRoleName);
            this.Name = "RoleCreationComponent";
            this.Size = new System.Drawing.Size(461, 317);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.CheckedListBox cboxPremissions;
        private System.Windows.Forms.Button btnAddRole;
    }
}
