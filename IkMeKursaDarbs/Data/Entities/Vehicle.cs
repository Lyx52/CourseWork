using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class Vehicle : IdEntity
    {
        [Constraint("NOT NULL")]
        public string VinNumber { get; set; }
        [Constraint("NOT NULL")]
        public string Model { get; set; }
        [Constraint("NOT NULL")]
        public string Brand { get; set; }
        [Constraint("NOT NULL")]
        [TableRelation(typeof(Customer), false)]
        public int OwnerId { get; set; }
    }
}
