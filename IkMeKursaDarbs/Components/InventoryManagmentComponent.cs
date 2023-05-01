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
        public InventoryManagmentComponent()
        {
            InitializeComponent();
            this.dgwItems.DataSource = Program.DbContext[typeof(InventoryItem).Name];
            this.dgwItems.Columns.Add(EntityRelationComboBoxColumn.Create<InventoryItem, InventoryCategory>(c => c.Name, "Category"));
            var trw = RecursiveTreeView<InventoryCategory>.Create(c => c.ParentId);
            this.sContainer.Panel1.Controls.Add(trw);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
