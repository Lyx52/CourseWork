using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class MechanicTask : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Name { get; set; }
        [Constraint("NOT NULL", "text")]
        public string Description { get; set; }
        [Constraint("NOT NULL")]
        [TableRelation(typeof(MechanicTask), false)]
        public int ParentTaskId { get; set; }
        [Constraint("NOT NULL")]
        [TableRelation(typeof(Mechanic), false)]
        public int MechanicId { get; set; }
        [Constraint("NOT NULL")]
        [TableRelation(typeof(Vehicle), false)]
        public int VehicleId { get; set; }

        [Constraint("NOT NULL")]
        public int Created { get; set; }
        [Constraint("DEFAULT -1")]
        public int Due { get; set; }
    }
}
