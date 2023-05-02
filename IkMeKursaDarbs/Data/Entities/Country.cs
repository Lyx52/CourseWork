using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class Country : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Name { get; set; }
    }
}
