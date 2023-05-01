using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class Mechanic : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Name { get; set; }
        [Constraint("NOT NULL", "text")]
        public string Surname { get; set; }
        [Constraint("NOT NULL")]
        [TableRelation(typeof(Specialization), false)]
        public int SpecializationId { get; set; }
        [Constraint("DEFAULT NULL")]
        [TableRelation(typeof(AppUser), false)]
        public int UserId { get; set; }
    }
}
