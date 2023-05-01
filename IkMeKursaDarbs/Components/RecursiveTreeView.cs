using IkMeKursaDarbs.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs.Components
{
    public class RecursiveTreeView<TDataType> : TreeView where TDataType : IdEntity
    {
        private DataTable _dataTable;
        private string _parentColumn;
        private string _displayMember;

        public RecursiveTreeView(DataTable dataTable, string parentColumn, string displayMember)
        {
            _dataTable = dataTable;
            _parentColumn = parentColumn;
            _displayMember = displayMember;

            // Set up the tree view
            this.LabelEdit = true;
            this.AfterSelect += RecursiveTreeView_AfterSelect;
            this.KeyDown += RecursiveTreeView_KeyDown;
            this.AfterLabelEdit += RecursiveTreeView_AfterLabelEdit;
            PopulateNodes(null, this.Nodes);
        }

        private void RecursiveTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.CancelEdit) return;
            var row = e.Node.Tag as DataRow;
            row[_displayMember] = e.Label;
            Program.DbContext.DataSet.Update<TDataType>(row.GetRowAsType<TDataType>());
            Program.DbContext.Update<TDataType>();
        }

        private void PopulateNodes(object parentId, TreeNodeCollection nodes)
        {
            // Get the child rows for the specified parent ID
            DataRow[] childRows = _dataTable.Select($"{_parentColumn} = '{parentId}'");

            // Add each child row as a new node
            foreach (DataRow row in childRows)
            {
                // Create a new node for the row
                TreeNode node = new TreeNode(row[_displayMember].ToString());
                node.Tag = row;

                // Add the node to the parent node's collection
                nodes.Add(node);

                // Recursively add child nodes for the new node
                PopulateNodes(row["Id"], node.Nodes);
            }
        }
        private void RecursiveTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
        private void RecursiveTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected row from the node's tag
            DataRow selectedRow = (e.Node.Tag as DataRow);

            // Do something with the selected row
            // For example, display the row's details in a separate form
            // MyDetailsForm.Show(selectedRow);
        }

        private void RecursiveTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            // If the F2 key is pressed, enable editing for the selected node
            if (e.KeyCode == Keys.F2)
            {
                if (this.SelectedNode != null)
                {
                    this.SelectedNode.BeginEdit();
                }
            }
        }

        public static RecursiveTreeView<TDataType> Create(
            Expression<Func<TDataType, object>> parentPropExpression, string displayMember = "Name"
        )
        {
            string parentProperty = Utils.GetMemberName(parentPropExpression);
            return new RecursiveTreeView<TDataType>(Program.DbContext[typeof(TDataType).Name], parentProperty, displayMember);
        }
    }

}
