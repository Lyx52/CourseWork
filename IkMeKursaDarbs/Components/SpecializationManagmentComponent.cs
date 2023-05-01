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
    public partial class SpecializationManagmentComponent : UserControl
    {
        private DataView _view;

        public SpecializationManagmentComponent()
        {
            InitializeComponent();
            this._view = new DataView(Program.DbContext[typeof(Specialization).Name]);
            this.dgwTable.DataSource = this._view;
            this.dgwTable.Columns[1].Visible = false;
            this.dgwTable.Columns[0].HeaderText = "Specialization name";
            this.dgwTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this._view.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            this._view.RowFilter = $"Name LIKE '%{txtSearch.Text.ToLower()}%'";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.DbContext.Update<Specialization>();
        }
    }
}
