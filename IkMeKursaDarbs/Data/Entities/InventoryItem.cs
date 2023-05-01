using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class InventoryItem : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string ItemName { get; set; }
        [Constraint("DEFAULT NULL", "text")]
        public string PartNumber { get; set; }

        [Constraint("DEFAULT 0", "integer")]
        public int Count { get; set; }

        [Constraint("DEFAULT NULL", "integer")]
        [TableRelation(typeof(ItemManufacturer), false)]
        public int ManufacturerId { get; set; }

        [Constraint("NOT NULL", "integer")]
        [TableRelation(typeof(InventoryCategory), false)]
        public int CategoryId { get; set; }
    }
}
