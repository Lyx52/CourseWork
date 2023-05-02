using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class City : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Name { get; set; }

        [Constraint("NOT NULL", "integer")]
        [TableRelation(typeof(Country), false)]
        public int CountryId { get; set; }
    }
}
