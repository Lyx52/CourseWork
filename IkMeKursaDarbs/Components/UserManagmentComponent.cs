using IkMeKursaDarbs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using IkMeKursaDarbs.Data.Entities;

namespace IkMeKursaDarbs.Components
{
    public partial class UserManagmentComponent : UserControl
    {
        private DataView _view;
        public UserManagmentComponent()
        {
            InitializeComponent();
            this._view = new DataView(Program.DbContext.DataSet.Tables[typeof(AppUser).Name]);
            this.dgwTable.DataSource = _view;
            this.dgwTable.Columns.Insert(1, DataGridViewPasswordColumn.Create<AppUser>(user => user.Password));
            this.dgwTable.Columns.Insert(2, EntityRelationComboBoxColumn.Create<AppUser, UserRole>((role) => role.RoleName, "Role"));
            this.dgwTable.Columns[3].Visible = false;
            this.dgwTable.Columns[4].Visible = false;
            this.dgwTable.Columns[5].Visible = false;
            this.dgwTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.DbContext.Update(typeof(AppUser).Name);
        }

        private void txtSearchbox_TextChanged(object sender, EventArgs e)
        {
            this._view.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(txtSearchbox.Text)) return;
            this._view.RowFilter = $"Username LIKE '%{txtSearchbox.Text.ToLower()}%'";
        }
    }
}
