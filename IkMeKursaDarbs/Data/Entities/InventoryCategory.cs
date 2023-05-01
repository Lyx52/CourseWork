using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class InventoryCategory : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Name { get; set; }

        [Constraint("DEFAULT NULL", "integer")]
        [TableRelation(typeof(InventoryCategory), false)]
        public int ParentId { get; set; }
    }
}
