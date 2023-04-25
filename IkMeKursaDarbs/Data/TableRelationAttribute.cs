using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data
{
    public class TableRelationAttribute : Attribute
    {
        public Type RelatedTo { get; set; }
        public bool Constraint { get; set; }
        public TableRelationAttribute(Type relatedTo, bool constrain=true)
        {
            if (!typeof(IdEntity).IsAssignableFrom(relatedTo))
            {
                throw new ArgumentException("Entity type must be a child class of IdEntity");
            }
            RelatedTo = relatedTo;
            Constraint = constrain;
        }   
    }
}
