using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IStorageContext db;
        public event EventHandler OnRequestClose;

        public ICommand LoginClickedCommand { get; set; }

        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged("Username"); } }
        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged("Password"); } }


        public LoginViewModel(IStorageContext db)
        {
            this.db = db;
            LoginClickedCommand
        }

        public void Login_ClickedCommand(object sender, EventArgs args)
        {
            Uzivatel u = new Uzivatel();
            u.Username = Username;
            u.Password = Password;

            var uzivatelModule = new UzivatelTableModule(db);
            Uzivatel sgn = uzivatelModule.TrySignIn(u);
            if (sgn != null && sgn.Role == 2)
            {
                MainWindow main = new MainWindow(sgn);

                main.Show();
                OnRequestClose(this, new EventArgs());
            }
            else if (sgn != null && sgn.Role != 2)
            {
                MessageBox.Show("Přihlášení selhalo. Nejste registrován/a jako lesní hospodář.");
            }
            else
            {
                MessageBox.Show("Přihlášení selhalo. Zkontrolujte prosím své přihlašovací údaje.");
            }
        }
    }
}

