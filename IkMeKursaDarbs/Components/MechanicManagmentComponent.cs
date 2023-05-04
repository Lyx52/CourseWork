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
        private Mechanic _selectedMechanic;
        public MechanicManagmentComponent()
        {
            InitializeComponent();
            this._view = new DataView(Program.DbContext[typeof(Mechanic).Name]);
            this.dgwTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwTable.DataSource = _view;
            this.dgwTable.Columns.Add(EntityRelationComboBoxColumn.Create<Mechanic, AppUser>(s => s.Username, "User account"));
            this.dgwTable.Columns[0].HeaderText = "Name";
            this.dgwTable.Columns[1].HeaderText = "Surname";
            this.dgwTable.Columns[2].Visible = false;
            this.dgwTable.Columns[3].Visible = false;

            this.cblSpecializations.DataSource = Program.DbContext[typeof(Specialization).Name];
            this.cblSpecializations.DisplayMember = "Name";
            this.cblSpecializations.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.DbContext.Update<Mechanic>();
            var mechSpec = Program.DbContext.DataSet.Query<MechanicSpecialization>(ms => ms.MechanicId == _selectedMechanic.Id).ToList();
            for (var i = 0; i < cblSpecializations.Items.Count; i++)
            {
                var spec = (cblSpecializations.Items[i] as DataRowView).Row.GetRowAsType<Specialization>();
                var tableMechSpec = mechSpec.FirstOrDefault(ms => ms.MechanicId == _selectedMechanic.Id && ms.SpecializationId == spec.Id);
                if (cblSpecializations.GetItemChecked(i) && tableMechSpec is null)
                {
                    Program.DbContext.DataSet.Add(new MechanicSpecialization() { SpecializationId = spec.Id, MechanicId = _selectedMechanic.Id });
                } 
                else if (!cblSpecializations.GetItemChecked(i) && tableMechSpec != null)
                {
                    Program.DbContext.DataSet.Remove(tableMechSpec);
                }
            }
            Program.DbContext.Update<MechanicSpecialization>();
            UpdateSpecializations();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this._view.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            this._view.RowFilter = $"Name LIKE '%{txtSearch.Text.ToLower()}%' OR Surname LIKE '%{txtSearch.Text.ToLower()}%'";
        }

        private void dgwTable_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgwTable.SelectedRows.Count == 0 || this.dgwTable.SelectedRows[0].IsNewRow) return;
            var row = ((this.dgwTable.SelectedRows[0] as DataGridViewRow).DataBoundItem as DataRowView).Row;
            _selectedMechanic = row.GetRowAsType<Mechanic>();
            UpdateSpecializations();
        }
        private void UpdateSpecializations()
        {
            if (_selectedMechanic is null || _selectedMechanic.Id <= 0) return;
            var mechSpec = Program.DbContext.DataSet.Query<MechanicSpecialization>(ms => ms.MechanicId == _selectedMechanic.Id).ToList(); 
            for (var i = 0; i < cblSpecializations.Items.Count; i++)
            {
                var spec = (cblSpecializations.Items[i] as DataRowView).Row.GetRowAsType<Specialization>();
                cblSpecializations.SetItemChecked(i, mechSpec.Any(ms => ms.SpecializationId == spec.Id));
            }
        }
    }
}
