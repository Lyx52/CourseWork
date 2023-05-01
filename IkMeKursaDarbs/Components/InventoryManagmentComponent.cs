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
    public partial class InventoryManagmentComponent : UserControl
    {
        private InventoryCategory _selectedCategory;
        private DataView _view;
        public InventoryManagmentComponent()
        {
            InitializeComponent();
            this.dgwItems.Dock = DockStyle.Fill;
            this.dgwItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwItems.DataSource = Program.DbContext[typeof(InventoryItem).Name];
            this.dgwItems.Columns.Add(EntityRelationComboBoxColumn.Create<InventoryItem, ItemManufacturer>(c => c.Name, "Manufacturer"));
            this.dgwItems.Columns.Add(EntityRelationComboBoxColumn.Create<InventoryItem, InventoryCategory>(c => c.Name, "Category"));
            var trw = RecursiveTreeView<InventoryCategory>.Create<InventoryCategory>(c => c.ParentId, c => c.Name);
            trw.Dock = DockStyle.Fill;
            trw.AfterSelect += Category_AfterSelect;
            this.sContainer.Panel1.Controls.Add(trw);

            this._view = new DataView(Program.DbContext[typeof(InventoryItem).Name]);
            this.dgwItems.DataSource = this._view;
            this.dgwItems.SelectionChanged += DgwItems_SelectionChanged;
            this.dgwItems.Columns[0].HeaderText = "Name";
            this.dgwItems.Columns[1].HeaderText = "Part nr.";
            this.dgwItems.Columns[2].HeaderText = "Total count";
            this.dgwItems.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            this.dgwItems.Columns[3].Visible = false;
            this.dgwItems.Columns[4].Visible = false;
            this.dgwItems.Columns[5].Visible = false;
        }

        private void DgwItems_SelectionChanged(object sender, EventArgs e)
        {
            if (_selectedCategory == null) return;
            this.dgwItems.Rows[this.dgwItems.NewRowIndex].Cells["categoryid"].Value = _selectedCategory.Id;
        }

        private void Category_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is null || e.Node.Tag is null) return;
            _selectedCategory = (e.Node.Tag as DataRow).GetRowAsType<InventoryCategory>();
            this._view.RowFilter = $"CategoryId = {_selectedCategory.Id}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.DbContext.Update<InventoryCategory>();
            Program.DbContext.Update<InventoryItem>();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this._view.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            this._view.RowFilter = $"ItemName LIKE '%{txtSearch.Text.ToLower()}%'";
            // Filtrē'jam pēc kategorijām
            var categoryIds = Program.DbContext.DataSet.Query<InventoryCategory>(c => c.Name.ToLower().Contains(txtSearch.Text.ToLower())).Select(c => c.Id);
            if (categoryIds.Count() > 0)
                this._view.RowFilter += $" OR categoryid IN ({string.Join(",", categoryIds)})";
            // Filtrējam pēc ražotājiem
            var manufacturerIds = Program.DbContext.DataSet.Query<ItemManufacturer>(c => c.Name.ToLower().Contains(txtSearch.Text.ToLower())).Select(c => c.Id);
            if (manufacturerIds.Count() > 0)
                this._view.RowFilter += $" OR manufacturerid IN ({string.Join(",", manufacturerIds)})";
        }
    }
}
