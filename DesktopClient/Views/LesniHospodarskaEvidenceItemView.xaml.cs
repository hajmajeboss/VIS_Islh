using Backend.Models;
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

namespace DesktopClient.Views
{
    /// <summary>
    /// Interakční logika pro LesniHospodarskaEvidenceItemView.xaml
    /// </summary>
    public partial class LesniHospodarskaEvidenceItemView : Window
    {
        public LesniHospodarskaEvidenceItemView(PorostniSkupina psk, LesniHospodarskaEvidence lhe = null)
        {
            var vm = new LesniHospodarskaEvidenceItemViewModel(((App)App.Current).StorageContext, psk, lhe);
            DataContext = vm;
            vm.OnRequestClose += (s, e) => this.Close();
            InitializeComponent();
        }
    }
}
