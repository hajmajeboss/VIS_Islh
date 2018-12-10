using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IStorageContext db;
        private Uzivatel uzivatel;

        private string _userInfo;
        public string UserInfo { get { return _userInfo; } set { _userInfo = value; OnPropertyChanged("UserInfo"); } }

        public ICommand OpenLheCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SignOffCommand { get; set; }

        public MainWindowViewModel(IStorageContext db, Uzivatel uzivatel)
        {
            this.db = db;
            this.uzivatel = uzivatel;
            OpenLheCommand = new RelayCommand(LheButton_ClickCommand);
            CloseCommand = new RelayCommand(CloseButton_ClickCommand);
            SignOffCommand = new RelayCommand(SignOffButton_ClickCommand);
            UserInfo = uzivatel.Jmeno + ", " + uzivatel.Email;
        }

        public void LheButton_ClickCommand(object param)
        {
            var lheView = new LesniHospodarskaEvidenceView(uzivatel);
            lheView.Show();
        }

        public void SignOffButton_ClickCommand(object param)
        {
            var loginView = new Login();
            loginView.Show();
            Close();
        }

        public void CloseButton_ClickCommand(object param)
        {
            Close();
        }
    }
}
