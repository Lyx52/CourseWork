using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs.Components
{
    public enum PremissionType
    {
        MANAGE_USERS,
        MANAGE_ROLES,
        MANAGE_DEPARTMENTS,
        MANAGE_ROOMS,
        MANAGE_PATIENTS,
    }
    public enum PremissionAllowedActions
    {
        READ = 1,
        WRITE = 2,
        DELETE = 3,
        CREATE = 4
    }
    public partial class RoleManagmentComponent : UserControl
    {
        
        public RoleManagmentComponent()
        {
            InitializeComponent();
            this.cboxPremissions.Items.AddRange(Enum.GetNames(typeof(PremissionType)));
        }
    }
}
