using Backend.Models;
using Backend.TableModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopClient
{
    /// <summary>
    /// Interakční logika pro Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uzivatel u = new Uzivatel();
            u.Username = username.Text;
            u.Password = password.Password;

            var gw = ((App)App.Current).UzivatelTableGateway;

            var uzivatelModule = new UzivatelTableModule(gw);
            Uzivatel sgn = uzivatelModule.TrySignIn(u);
            if (sgn != null && sgn.Role == 2)
            {
                MainWindow main = new MainWindow(sgn);

                main.Show();
                this.Close();
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
