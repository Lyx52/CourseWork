using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs.Components
{
    internal class ComponentTab : TabPage
    {
        public ComponentTab(string text, UserControl control)
        {
            Text = text;
            control.Dock = DockStyle.Fill;
            this.Controls.Add(control);
        }
    }
}
