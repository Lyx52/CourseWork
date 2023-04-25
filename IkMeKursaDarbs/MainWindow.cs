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
            lstMainMenu.Items.Add(
                new ListViewItem
                {
                    Text = "User managment",
                    Tag = new List<ComponentTab>
                    {
                        new ComponentTab("Roles", new RoleManagmentComponent()),
                        new ComponentTab("Users", new EntityManagmentComponent(typeof(AppUser), "Username"))
                    }
                });
            lstMainMenu.Items.Add(
                new ListViewItem
                {
                    Text = "User roles123",
                    Tag = new List<ComponentTab>
                    {
                        new ComponentTab("Roles123", new RoleManagmentComponent())
                    }
                });
            UserContext.OnLoggedIn += OnLoggedIn;
        }
        public void OnLoggedIn()
        {
            this.mainContainer.Enabled = true;
            this.mainContainer.Visible = true;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Lietotājs jau ir autentificējies
            if (UserContext.IsAuthenticated())
                return;
            // Pieprasa autentificēties, savādāk beidz programmu.
            UserContext.LoginPrompt(this);
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
