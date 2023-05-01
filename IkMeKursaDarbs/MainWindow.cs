using IkMeKursaDarbs.Components;
using IkMeKursaDarbs.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
            // Noklusēti viesiem lietotājiem ir dashboard
            lstMainMenu.Items.Add(
                new ListViewItem
                {
                    Text = "Dashboard",
                    Tag = new List<ComponentTab>
                    {
                        new ComponentTab("Dashboard", new DashboardComponent())
                    }
                });
            lstMainMenu.Items.Add(
                new ListViewItem
                {
                    Text = "User managment",
                    Tag = new List<ComponentTab>
                    {
                        new ComponentTab("Roles", new RoleManagmentComponent()),
                        new ComponentTab("Users", new UserManagmentComponent())
                    }
                });
            lstMainMenu.Items.Add(
                new ListViewItem
                {
                    Text = "Mechanic managment",
                    Tag = new List<ComponentTab>
                    {
                        new ComponentTab("Mechanics", new MechanicManagmentComponent()),
                        new ComponentTab("Specializations", new SpecializationManagmentComponent())
                    }
                });
            lstMainMenu.Items.Add(
                new ListViewItem
                {
                    Text = "Inventory managment",
                    Tag = new List<ComponentTab>
                    {
                        new ComponentTab("Inventory managment", new InventoryManagmentComponent())
                    }
                });
            UserContext.OnLoggedIn += OnLoggedIn;
        }
        public void OnLoggedIn()
        {
            this.mainContainer.Enabled = true;
            this.mainContainer.Visible = true;
        }
        public void Logout()
        {
            this.mainContainer.Enabled = false;
            this.mainContainer.Visible = false;
            UserContext.Logout();
            UserContext.LoginPrompt(this);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.mainContainer.Enabled = true;
            this.mainContainer.Visible = true;
            //// Lietotājs jau ir autentificējies
            //if (UserContext.IsAuthenticated())
            //    return;
            //// Pieprasa autentificēties, savādāk beidz programmu.
            //UserContext.LoginPrompt(this);
        }

        private void lstMainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMainMenu.SelectedItems.Count == 0) return;
            var controls = (List<ComponentTab>)lstMainMenu.SelectedItems[0].Tag;
            actionTabs.TabPages.Clear();
            actionTabs.TabPages.AddRange(controls.ToArray());
        }


    }
}
