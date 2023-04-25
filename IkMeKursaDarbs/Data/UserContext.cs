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
        public static Action OnLoggedIn { get; set; }
        public static AppUser CurrentUser
        {
            get => _currentUser;
            set {
                _currentUser = value;
                _lastActivityTime = DateTime.MinValue;
                if (_currentUser != null)
                {
                    _currentUser.Password = string.Empty;
                    _lastActivityTime = DateTime.UtcNow;
                }

            }
        }
        private static DateTime _lastActivityTime;
        private static AppUser _currentUser;
        public static void LoginPrompt(Form mainForm)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = mainForm;
            loginForm.OnLoggedIn += OnLogin;
            loginForm.Show();
        }
        public static void OnLogin(AppUser user)
        {
            CurrentUser = user;
            OnLoggedIn.Invoke();
        }
        public static void Logout() => CurrentUser = null;
        // Lietotājs nav autentificējies ja nav lietotājs vai nav atjaunots aktivitātes laiks
        public static bool IsAuthenticated() => CurrentUser != null && (DateTime.UtcNow - _lastActivityTime).TotalMinutes > 5;
        public static void UpdateActivity() => _lastActivityTime = DateTime.UtcNow;
    }
}
