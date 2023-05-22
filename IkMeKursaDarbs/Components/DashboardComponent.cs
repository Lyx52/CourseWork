using IkMeKursaDarbs.Data;
using IkMeKursaDarbs.Data.Entities;
using IkMeKursaDarbs.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IkMeKursaDarbs.Components
{
    public partial class DashboardComponent : UserControl
    {
        private List<MechanicTask> _mechanicTasks = new List<MechanicTask>();
        public DashboardComponent()
        {
            InitializeComponent();
            btnShowServiceDialog.Visible = UserContext.HasAccess(Data.Enums.RolePremissionType.ADD_MECHANIC_TASKS);
            _mechanicTasks = GetMechanicTasks();
            UpdateSchedule();
        }
        private void UpdateSchedule()
        {
            calSchedule.RemoveAllBoldedDates();
            lswTasks.Items.Clear();
            foreach (var task in _mechanicTasks)
            {
                calSchedule.AddBoldedDate(new DateTime(task.Due));
                ListViewItem item = new ListViewItem(task.Name);
                item.SubItems.Add((new DateTime(task.Due)).ToString("MM/dd/yyyy"));
                if (task.Completed)
                {
                    item.SubItems.Add("Yes", Color.Green, Color.WhiteSmoke, new Font("Arial", 10, FontStyle.Bold));
                } else
                {
                    item.SubItems.Add("No", Color.Red, Color.WhiteSmoke, new Font("Arial", 10, FontStyle.Bold));
                }
                
                item.Tag = task;
                lswTasks.Items.Add(item);
            }
        }
        private List<MechanicTask> GetMechanicTasks()
        {
           if (!UserContext.IsAuthenticated()) return new List<MechanicTask>();

            var mechanic = Program.DbContext.DataSet.Query<Mechanic>(m => m.UserId == UserContext.CurrentUser.Id).FirstOrDefault();
            if (mechanic is null) return new List<MechanicTask>();

            var mechanicSpecs = Program.DbContext.DataSet.Query<MechanicSpecialization>(ms => ms.MechanicId == mechanic.Id).Select(ms => ms.Id);

            return Program.DbContext.DataSet.Query<MechanicTask>(mt => mechanicSpecs.Contains(mt.MechSpecId)).ToList();
        }
        private void btnShowServiceDialog_Click(object sender, EventArgs e)
        {
            ServiceInputForm serviceForm = new ServiceInputForm();
            serviceForm.ShowDialog();
            _mechanicTasks = GetMechanicTasks();
            UpdateSchedule();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserContext.Logout();
        }

        private void btnMarkAsComplete_Click(object sender, EventArgs e)
        {
            if (lswTasks.SelectedItems is null || lswTasks.SelectedItems.Count == 0) return;
            foreach (ListViewItem item in lswTasks.SelectedItems)
            {
                var task = item.Tag as MechanicTask;
                task.Completed = true;
                Program.DbContext.DataSet.Update(task);
            }
            Program.DbContext.Update<MechanicTask>();
            UpdateSchedule();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (_mechanicTasks == null || _mechanicTasks.Count == 0) return;
            var reportName = $"{UserContext.CurrentUser.Username}_TaskReport_{DateTime.Now:MM_dd_yyyy}";
            Utils.SaveAsExcelReport(_mechanicTasks, reportName);
            try
            {
                System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}/Reports/{reportName}.xlsx");
            }
            catch
            {
                MessageBox.Show("No associated program found!", "No program found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
