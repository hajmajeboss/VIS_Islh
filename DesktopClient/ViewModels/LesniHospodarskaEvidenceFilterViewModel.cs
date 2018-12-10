using Backend.Filters;
using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class LesniHospodarskaEvidenceFilterViewModel : BaseViewModel
    {
        IStorageContext db;

        private VykonTableModule vykonTableModule;
        private PodvykonTableModule podvykonTableModule;
        private DrevinaTableModule drevinaTableModule;
        private DruhTezbyTableModule druhTezbyTableModule;
        private LesniHospodarskaEvidenceTableModule lheTableModule;

        public List<Vykon> _vykonList;
        public List<Vykon> VykonList { get { return _vykonList; } set { _vykonList = value; OnPropertyChanged("VykonList"); } }

        public List<Podvykon> _podvykonList;
        public List<Podvykon> PodvykonList { get { return _podvykonList; } set { _podvykonList = value; OnPropertyChanged("PodvykonList"); } }

        public List<DruhTezby> _druhTezbyList;
        public List<DruhTezby> DruhTezbyList { get { return _druhTezbyList; } set { _druhTezbyList = value; OnPropertyChanged("DruhTezbyList"); } }

        public List<Drevina> _drevinaList;
        public List<Drevina> DrevinaList { get { return _drevinaList; } set { _drevinaList = value; OnPropertyChanged("DrevinaList"); } }


        private Vykon _vykon;
        public Vykon Vykon { get { return _vykon; } set { _vykon = value; OnPropertyChanged("Vykon"); if (Vykon!=null) PodvykonList = podvykonTableModule.LoadPodvykony(value); } }

        private Podvykon _podvykon;
        public Podvykon Podvykon { get { return _podvykon; } set { _podvykon = value; OnPropertyChanged("Podvykon"); } }

        private DruhTezby _druhTezby;
        public DruhTezby DruhTezby { get { return _druhTezby; } set { _druhTezby = value; OnPropertyChanged("DruhTezby"); } }

        private Drevina _drevina;
        public Drevina Drevina { get { return _drevina; } set { _drevina = value; OnPropertyChanged("Drevina"); } }

        public ICommand FilterCommand { get; set; }
        public ICommand ResetCommand { get; set; }


        public LesniHospodarskaEvidenceFilterViewModel(IStorageContext db)
        {
            this.db = db;
            vykonTableModule = new VykonTableModule(db);
            podvykonTableModule = new PodvykonTableModule(db);
            drevinaTableModule = new DrevinaTableModule(db);
            druhTezbyTableModule = new DruhTezbyTableModule(db);
            lheTableModule = new LesniHospodarskaEvidenceTableModule(db);

            VykonList = vykonTableModule.LoadVykony();
            DrevinaList = drevinaTableModule.LoadDreviny();
            DruhTezbyList = druhTezbyTableModule.LoadDruhyTezby();

            FilterCommand = new RelayCommand(FilterButton_ClickCommand);
            ResetCommand = new RelayCommand(ResetButton_ClickCommand);
        }

        public void FilterButton_ClickCommand(object param)
        {
            var cfg = new LheFilterConfig()
            {
                Vykon = this.Vykon,
                Podvykon = this.Podvykon,
                DruhTezby = this.DruhTezby,
                Drevina = this.Drevina
            };
            LheObserver.Instance.NotifyFilterConfigChanged(cfg);
            Close();
        }

        public void ResetButton_ClickCommand(object param)
        {
            Podvykon = null;
            Vykon = null;
            DruhTezby = null;
            Drevina = null;
        }
    }
}
