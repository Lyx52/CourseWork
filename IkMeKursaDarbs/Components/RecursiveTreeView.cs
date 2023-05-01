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
        private string _parentColumn;
        private string _displayMember;
        private string _entityName;

        public RecursiveTreeView(string entityName, string parentColumn, string displayMember)
        {
            _parentColumn = parentColumn;
            _displayMember = displayMember;
            _entityName = entityName;

            // Set up the tree view
            this.LabelEdit = true;
            this.KeyDown += RecursiveTreeView_KeyDown;
            this.AfterLabelEdit += RecursiveTreeView_AfterLabelEdit;
            this.NodeMouseDoubleClick += RecursiveTreeView_NodeMouseDoubleClick;
            PopulateNodes(-1, this.Nodes);
        }


        private void RecursiveTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.CancelEdit || e.Label is null) return;
            var row = e.Node.Tag as DataRow;
            row[_displayMember] = e.Label;
            Program.DbContext.DataSet.Update<TDataType>(row.GetRowAsType<TDataType>());
            Program.DbContext.Update<TDataType>();
        }

        private void PopulateNodes(int parentId, TreeNodeCollection nodes)
        {
            DataRow[] childRows = Program.DbContext[_entityName].Select($"{_parentColumn} = '{parentId}'");

            // Add each child row as a new node
            foreach (DataRow row in childRows)
            {
                TreeNode node = new TreeNode(row[_displayMember].ToString());
                node.Tag = row;
                nodes.Add(node);

                // Recursively add child nodes for the new node
                PopulateNodes((int)row["Id"], node.Nodes);
            }
        }
        private void RecursiveTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null || e.Node.Text == "New") return;
            var parentRow = e.Node.Tag as DataRow;
            if (parentRow["Id"] is null) return;
            var row = Program.DbContext[_entityName].NewRow();
            row[_displayMember] = "New";
            row[_parentColumn] = parentRow["Id"];
            TreeNode node = new TreeNode(row[_displayMember].ToString());
            node.Tag = row;
            // Add the node to the parent node's collection
            e.Node.Nodes.Add(node);
            Program.DbContext[_entityName].Rows.Add(row);
        }

        private void RecursiveTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Rediģēt
                case Keys.F2:
                    {
                        if (this.SelectedNode != null)
                        {
                            this.SelectedNode.BeginEdit();
                        }
                } break;
                // Dzēst
                case Keys.Delete:
                    {
                        if (this.SelectedNode == null) return;

                        if (this.SelectedNode.Tag != null)
                        {
                            var row = this.SelectedNode.Tag as DataRow;
                            row.Delete();
                            Program.DbContext.Update(_entityName);
                        }
                        
                       this.Nodes.Remove(this.SelectedNode);
                 } break;
            }
        }

        public static RecursiveTreeView<TDataType> Create<TDataType>(
            Expression<Func<TDataType, object>> parentPropExp, Expression<Func<TDataType, object>> displayMemberExp
        ) where TDataType : IdEntity
        {
            string parentProperty = Utils.GetMemberName(parentPropExp);
            string displayMember = Utils.GetMemberName(displayMemberExp);
            return new RecursiveTreeView<TDataType>(typeof(TDataType).Name, parentProperty, displayMember);
        }
    }

}
