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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleManagmentComponent));
            this.cboxPremissions = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtSearchRoleName = new System.Windows.Forms.ToolStripTextBox();
            this.btnAdd2 = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate2 = new System.Windows.Forms.ToolStripButton();
            this.btnRemove2 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxPremissions
            // 
            this.cboxPremissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxPremissions.FormattingEnabled = true;
            this.cboxPremissions.Location = new System.Drawing.Point(0, 0);
            this.cboxPremissions.Name = "cboxPremissions";
            this.cboxPremissions.Size = new System.Drawing.Size(318, 466);
            this.cboxPremissions.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboxPremissions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstRoles);
            this.splitContainer1.Size = new System.Drawing.Size(779, 466);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 3;
            // 
            // lstRoles
            // 
            this.lstRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(0, 0);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(457, 466);
            this.lstRoles.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.269155F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.73084F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 509);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearchRoleName,
            this.btnAdd2,
            this.btnUpdate2,
            this.btnRemove2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 37);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtSearchRoleName
            // 
            this.txtSearchRoleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchRoleName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchRoleName.Name = "txtSearchRoleName";
            this.txtSearchRoleName.Size = new System.Drawing.Size(100, 45);
            // 
            // btnAdd2
            // 
            this.btnAdd2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd2.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd2.Image")));
            this.btnAdd2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(33, 34);
            this.btnAdd2.Text = "Add";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate2
            // 
            this.btnUpdate2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdate2.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate2.Image")));
            this.btnUpdate2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate2.Name = "btnUpdate2";
            this.btnUpdate2.Size = new System.Drawing.Size(49, 42);
            this.btnUpdate2.Text = "Update";
            this.btnUpdate2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove2
            // 
            this.btnRemove2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemove2.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove2.Image")));
            this.btnRemove2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove2.Name = "btnRemove2";
            this.btnRemove2.Size = new System.Drawing.Size(54, 42);
            this.btnRemove2.Text = "Remove";
            this.btnRemove2.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // RoleManagmentComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RoleManagmentComponent";
            this.Size = new System.Drawing.Size(785, 509);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox cboxPremissions;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearchRoleName;
        private System.Windows.Forms.ToolStripButton btnAdd2;
        private System.Windows.Forms.ToolStripButton btnUpdate2;
        private System.Windows.Forms.ToolStripButton btnRemove2;
    }
}
