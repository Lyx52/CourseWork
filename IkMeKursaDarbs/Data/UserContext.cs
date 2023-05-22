using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using IkMeKursaDarbs.Data;
using IkMeKursaDarbs.Data.Entities;
using IkMeKursaDarbs.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs
{
    public static class UserContext
    {
        public static Action OnLoggedIn { get; set; }
        public static Action OnLoggedOut { get; set; }
        public static AppUser CurrentUser
        {
            get => _currentUser;
        }
        private static UserRole _userRole;
        private static DateTime _lastActivityTime;
        public static AppUser _currentUser;
        public static void LoginPrompt(Form mainForm)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = mainForm;
            loginForm.OnLoggedIn += OnLogin;
            loginForm.Show();
        }
        public static void OnLogin(AppUser user)
        {
            user.Password = string.Empty;
            _currentUser = user;
            _userRole = Program.DbContext.DataSet.Query<UserRole>(r => r.Id == _currentUser.RoleId).FirstOrDefault();
            OnLoggedIn.Invoke();
        }
        public static void Logout()
        {
            _currentUser = null;
            OnLoggedOut?.Invoke();
        }
        public static bool IsAuthenticated() => CurrentUser != null && _userRole != null;
        public static bool HasAccess(RolePremissionType premission)
        {
            return IsAuthenticated() && (_userRole.Premissions & (int)premission) == (int)premission;
        }
    }
}
