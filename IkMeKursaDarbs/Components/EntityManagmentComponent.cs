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
    public partial class EntityManagmentComponent : UserControl
    {
        private DataView _view;
        private string _searchField { get; set; }
        private Type _entityType;
        public EntityManagmentComponent(Type type, string searchField)
        {
            InitializeComponent();
            this._view = new DataView(Program.DbContext.DataSet.Tables[type.Name]);
            this.dgwTable.DataSource = _view;
            this._entityType = type;
            this._searchField = searchField; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.DbContext.Update(_entityType.Name);
        }

        private void txtSearchbox_TextChanged(object sender, EventArgs e)
        {
            this._view.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(txtSearchbox.Text)) return;
            this._view.RowFilter = $"{_searchField} LIKE '%{txtSearchbox.Text.ToLower()}%'";
        }
    }
}
