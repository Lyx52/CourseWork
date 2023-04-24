using IkMeKursaDarbs.Data.Entities;
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
        public static AppUser CurrentUser
        {
            get => _currentUser;
            set {
                _currentUser = value;
                _loginTime = DateTime.MinValue;
                if (_currentUser != null)
                {
                    _currentUser.Password = string.Empty;
                    _loginTime = new DateTime();
                }

            }
        }
        private static DateTime _loginTime;
        private static AppUser _currentUser;
        public static bool LoginPrompt(Form mainForm)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Parent = mainForm;
            loginForm.ShowDialog();
            CurrentUser = loginForm._user;
            return CurrentUser != null;
        }
        public static void Logout() => CurrentUser = null;
    }
}
