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

namespace IkMeKursaDarbs.Components
{
    public partial class MechanicManagmentComponent : UserControl
    {
        private DataView _view;
        public MechanicManagmentComponent()
        {
            InitializeComponent();
            this._view = new DataView(Program.DbContext[typeof(Mechanic).Name]);
            this.dgwTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwTable.DataSource = _view;
            this.dgwTable.Columns.Add(EntityRelationComboBoxColumn.Create<Mechanic, Specialization>(s => s.Name, "Specialization"));
            this.dgwTable.Columns.Add(EntityRelationComboBoxColumn.Create<Mechanic, AppUser>(s => s.Username, "User account"));
            this.dgwTable.Columns[0].HeaderText = "Name";
            this.dgwTable.Columns[1].HeaderText = "Surname";
            this.dgwTable.Columns[2].Visible = false;
            this.dgwTable.Columns[3].Visible = false;
            this.dgwTable.Columns[4].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.DbContext.Update<Mechanic>();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this._view.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            this._view.RowFilter = $"Name LIKE '%{txtSearch.Text.ToLower()}%' OR Surname LIKE '%{txtSearch.Text.ToLower()}%'";
        }
    }
}
