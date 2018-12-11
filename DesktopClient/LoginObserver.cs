using DesktopClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class LoginObserver
    {
        public static LoginObserver Instance { get; }

        static LoginObserver()
        {
            Instance = new LoginObserver();
        }


        public List<LoginViewModel> Listeners { get; set; }
        private LoginObserver()
        {
            Listeners = new List<LoginViewModel>();
        }

        public void NotifyPasswordChanged(string password)
        {
            foreach (var listener in Listeners)
            {
                listener.OnPasswordChanged(password);
            }
        }

    }
}
