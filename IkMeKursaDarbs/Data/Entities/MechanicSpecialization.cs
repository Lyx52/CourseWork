using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class MechanicSpecialization : IdEntity
    {
        [Constraint("NOT NULL")]
        [TableRelation(typeof(Specialization), false)]
        public int SpecializationId { get; set; }
        [Constraint("NOT NULL")]
        [TableRelation(typeof(Mechanic), false)]
        public int MechanicId { get; set; }
    }
}
