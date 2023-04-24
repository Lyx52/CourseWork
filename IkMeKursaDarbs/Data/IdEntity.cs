using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data
{
    public class IdEntity : ICloneable
    {
        [Constraint("PRIMARY KEY", "serial")]
        public int Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
