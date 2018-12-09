using Backend.Models;
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
            InitializeComponent();
            userDetails.Content = uzivatel.Jmeno + ", " + uzivatel.Email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LesniHospodarskaEvidenceView lheview = new LesniHospodarskaEvidenceView();
            lheview.Show();

        }
    }
}
