using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkMeKursaDarbs.Data.Enums
{
    public enum RolePremissionType
    {
        MANAGE_USERS_AND_ROLES = 1,
        MANAGE_DEPARTMENTS = 2,
        SCHEDULE_MANAGER = 4,
        APPOINTMENT_MANAGER = 8,
        MANAGE_PATIENTS = 16,
    }
}
