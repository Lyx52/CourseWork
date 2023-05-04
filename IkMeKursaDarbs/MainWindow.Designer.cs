namespace IkMeKursaDarbs
{
    partial class MainWindow
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
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.lstMainMenu = new System.Windows.Forms.ListView();
            this.actionTabs = new System.Windows.Forms.TabControl();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Enabled = false;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.lstMainMenu);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.actionTabs);
            this.mainContainer.Size = new System.Drawing.Size(1288, 518);
            this.mainContainer.SplitterDistance = 135;
            this.mainContainer.TabIndex = 2;
            this.mainContainer.Visible = false;
            // 
            // lstMainMenu
            // 
            this.lstMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMainMenu.HideSelection = false;
            this.lstMainMenu.Location = new System.Drawing.Point(0, 0);
            this.lstMainMenu.MultiSelect = false;
            this.lstMainMenu.Name = "lstMainMenu";
            this.lstMainMenu.Size = new System.Drawing.Size(135, 518);
            this.lstMainMenu.TabIndex = 0;
            this.lstMainMenu.UseCompatibleStateImageBehavior = false;
            this.lstMainMenu.View = System.Windows.Forms.View.List;
            this.lstMainMenu.SelectedIndexChanged += new System.EventHandler(this.lstMainMenu_SelectedIndexChanged);
            // 
            // actionTabs
            // 
            this.actionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionTabs.Location = new System.Drawing.Point(0, 0);
            this.actionTabs.Name = "actionTabs";
            this.actionTabs.SelectedIndex = 0;
            this.actionTabs.Size = new System.Drawing.Size(1149, 518);
            this.actionTabs.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 518);
            this.Controls.Add(this.mainContainer);
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.Text = "Main window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TabControl actionTabs;
        private System.Windows.Forms.ListView lstMainMenu;
    }
}

