using Backend.Models;
using Backend.TableModules;
using DesktopClient.ViewModels;
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
            
            var vm = new LoginViewModel(((App)App.Current).StorageContext);
            vm.OnRequestClose += (s, e) => this.Close();
            DataContext = vm;
            InitializeComponent();
        }


    }
}
