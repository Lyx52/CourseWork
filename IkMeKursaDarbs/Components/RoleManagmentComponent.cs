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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add new role
            UserRole role = new UserRole();
            role.RoleName = this.txtSearchRoleName.Text;
            role.Premissions = GetSelectedPremissions();
            Program.DbContext.DataSet.Add<UserRole>(role);
            Program.DbContext.Update<UserRole>();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this._selectedRole is null) return;
            // Update role
            if (!string.IsNullOrEmpty(this.txtSearchRoleName.Text))
                this._selectedRole.RoleName = this.txtSearchRoleName.Text;
            this._selectedRole.Premissions = GetSelectedPremissions();
            Program.DbContext.DataSet.Update<UserRole>(this._selectedRole);
            Program.DbContext.Update<UserRole>();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this._selectedRole is null) return;
            Program.DbContext.DataSet.Remove<UserRole>(this._selectedRole);
            Program.DbContext.Update<UserRole>();
        }
    }
}
