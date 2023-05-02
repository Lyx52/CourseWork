using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class Address : IdEntity
    {
        [Constraint("NOT NULL", "integer")]
        [TableRelation(typeof(City), false)]
        public int CityId { get; set; }

        [Constraint("NOT NULL", "text")]
        public string Street { get; set; }
    }
}
