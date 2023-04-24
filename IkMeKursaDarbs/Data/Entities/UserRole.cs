using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class UserRole : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string RoleName { get; set; }
    }
}
