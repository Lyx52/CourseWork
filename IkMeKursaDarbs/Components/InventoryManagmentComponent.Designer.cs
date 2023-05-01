namespace IkMeKursaDarbs.Components
{
    partial class InventoryManagmentComponent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryManagmentComponent));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.sContainer = new System.Windows.Forms.SplitContainer();
            this.dgwItems = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sContainer)).BeginInit();
            this.sContainer.Panel2.SuspendLayout();
            this.sContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItems)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1034, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sContainer
            // 
            this.sContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sContainer.Location = new System.Drawing.Point(0, 25);
            this.sContainer.Name = "sContainer";
            // 
            // sContainer.Panel2
            // 
            this.sContainer.Panel2.Controls.Add(this.dgwItems);
            this.sContainer.Size = new System.Drawing.Size(1034, 470);
            this.sContainer.SplitterDistance = 276;
            this.sContainer.TabIndex = 2;
            // 
            // dgwItems
            // 
            this.dgwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwItems.Location = new System.Drawing.Point(0, 0);
            this.dgwItems.Name = "dgwItems";
            this.dgwItems.Size = new System.Drawing.Size(754, 470);
            this.dgwItems.TabIndex = 0;
            // 
            // InventoryManagmentComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "InventoryManagmentComponent";
            this.Size = new System.Drawing.Size(1034, 495);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.sContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sContainer)).EndInit();
            this.sContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.SplitContainer sContainer;
        private System.Windows.Forms.DataGridView dgwItems;
    }
}
