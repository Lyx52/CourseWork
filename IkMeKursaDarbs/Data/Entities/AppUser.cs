using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class AppUser : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Username { get; set; }

        [Constraint("NOT NULL", "text")]
        public string Password { get; set; }

        [Constraint("NOT NULL", "integer")]
        [TableRelation(typeof(UserRole), false)]
        public int RoleId { get; set; }
    }
}
