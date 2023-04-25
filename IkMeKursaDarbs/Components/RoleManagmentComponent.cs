using IkMeKursaDarbs.Data;
using IkMeKursaDarbs.Data.Entities;
using IkMeKursaDarbs.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs.Components
{
    public partial class RoleManagmentComponent : UserControl
    {
        private UserRole _selectedRole = null;
        public RoleManagmentComponent()
        {
            InitializeComponent();
            this.cboxPremissions.Items.AddRange(Enum.GetNames(typeof(RolePremissionType)));
            this.lstRoles.DataSource = Program.DbContext[typeof(UserRole).Name];
            this.lstRoles.DisplayMember = "RoleName";
            this.lstRoles.SelectedIndexChanged += LstRoles_SelectedIndexChanged;
            this.btnAddRole.Click += BtnAddRole_Click;
        }

        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            if (this._selectedRole == null)
            {
                // Add new role
                UserRole role = new UserRole();
                role.RoleName = this.txtRoleName.Text;
                role.Premissions = GetSelectedPremissions();
                Program.DbContext[typeof(UserRole).Name].Rows.Add(role);
                this.lstRoles.DataSource = Program.DbContext[typeof(UserRole).Name];
                this.lstRoles.DisplayMember = "RoleName";
                this.lstRoles.SelectedItem = role;
            }
            else
            {
                // Update selected role
                this._selectedRole.RoleName = this.txtRoleName.Text;
                this._selectedRole.Premissions = GetSelectedPremissions();
                Program.DbContext.Update<UserRole>();
                this.lstRoles.DataSource = Program.DbContext[typeof(UserRole).Name];
                this.lstRoles.DisplayMember = "RoleName";
                this.lstRoles.SelectedItem = this._selectedRole;
            }
        }
        private int GetSelectedPremissions()
        {
            int premissions = 0;
            for (int i = 0; i < cboxPremissions.Items.Count; i++)
            {
                RolePremissionType premissionType = (RolePremissionType)Enum.Parse(typeof(RolePremissionType), cboxPremissions.Items[i].ToString());
                if (cboxPremissions.GetItemChecked(i))
                {
                    premissions |= (int)premissionType;
                }
            }
            return premissions;
        }
        private void LstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRoles.SelectedItem == null)
            {
                for (int i = 0; i < cboxPremissions.Items.Count; i++)
                {
                    cboxPremissions.SetItemChecked(i, false);
                }
                return;
            }
            DataRowView row = lstRoles.SelectedItem as DataRowView;
            _selectedRole = row.Row.GetRowAsType<UserRole>();
            for (int i = 0; i < cboxPremissions.Items.Count; i++)
            {
                RolePremissionType premissionType = (RolePremissionType)Enum.Parse(typeof(RolePremissionType), cboxPremissions.Items[i].ToString());
                cboxPremissions.SetItemChecked(i, (_selectedRole.Premissions & (int)premissionType) == (int)premissionType);
            }
        }
    }
}
