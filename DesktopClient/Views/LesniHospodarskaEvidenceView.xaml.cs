using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
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
    /// Interakční logika pro LesniHospodarskaEvidenceView.xaml
    /// </summary>
    public partial class LesniHospodarskaEvidenceView : Window
    {
        public LesniHospodarskaEvidenceView(Uzivatel uzivatel)
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
