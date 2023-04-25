using IkMeKursaDarbs.Data;
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
using System.Security.Cryptography;
namespace IkMeKursaDarbs
{
    public partial class LoginForm : Form
    {
        public Action<AppUser> OnLoggedIn;
        public LoginForm()
        {
            InitializeComponent();
        }
        private bool ValidateInput(TextBox txtBox)
        {
            bool IsValid = true;
            IsValid &= !string.IsNullOrEmpty(txtBox.Text);
            IsValid &= txtBox.Text.Length > 4;

            txtBox.BackColor = Color.White;
            if (!IsValid)
            {
                txtBox.BackColor = Color.Red;
            }
            return IsValid;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(txtPassword) || !ValidateInput(txtUsername))
                return;
            string hashedPassword = txtPassword.Text.ToSHA256();
            AppUser user = Program.DbContext.DataSet.Query<AppUser>(usr => usr.Password == hashedPassword && usr.Username == txtUsername.Text).FirstOrDefault();
            lblError.Text = string.Empty;
            // Neveiksmīga autentifikācija
            if (user == null)
            {
                lblError.Text = "Autentifikācija neveiksmīga!";
                return;
            }
            OnLoggedIn.Invoke(new AppUser());
            this.Close();
        }
    }
}
