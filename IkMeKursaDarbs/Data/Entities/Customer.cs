using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Entities
{
    public class Customer : IdEntity
    {
        [Constraint("NOT NULL", "text")]
        public string Name { get; set; }
        [Constraint("NOT NULL", "text")]
        public string Surname { get; set; }
        [Constraint("NOT NULL", "text")]
        public string PhoneNumber { get; set; }
        [Constraint("NOT NULL", "text")]
        public string Email { get; set; }
        [Constraint("NOT NULL", "integer")]
        [TableRelation(typeof(Address), false)]
        public int AddressId { get; set; }
    }
}
