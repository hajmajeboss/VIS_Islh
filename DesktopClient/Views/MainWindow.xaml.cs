using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopClient
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Uzivatel uzivatel)
        {
            var vm = new MainWindowViewModel(((App)App.Current).StorageContext, uzivatel);
            vm.OnRequestClose += (s, e) => this.Close();
            DataContext = vm;
            InitializeComponent();
        }

    }
}
