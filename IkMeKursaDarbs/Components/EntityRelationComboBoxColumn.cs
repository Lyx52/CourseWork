using IkMeKursaDarbs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs.Components
{
    public class EntityRelationComboBoxColumn : DataGridViewComboBoxColumn
    {
        public EntityRelationComboBoxColumn()
        {
        }
        public static EntityRelationComboBoxColumn Create<TChildType, TParentType>(
            Expression<Func<TParentType, object>> displayMemberExpression, string headerText=null
        ) where TChildType : IdEntity where TParentType : IdEntity
        {
            var column = new EntityRelationComboBoxColumn();
            var relProperty = typeof(TChildType).GetProperties().FirstOrDefault((prop) =>
            {
                var attrib = prop.GetCustomAttribute<TableRelationAttribute>();
                if (attrib == null) return false;
                return attrib.RelatedTo == typeof(TParentType);
            });
            column.HeaderText = headerText ?? typeof(TParentType).Name;
            column.DataPropertyName = relProperty.Name;
            column.DataSource = Program.DbContext[typeof(TParentType).Name];
            column.DisplayMember = Utils.GetMemberName(displayMemberExpression);
            column.ValueMember = "Id";
            return column;
        }

    }
}
