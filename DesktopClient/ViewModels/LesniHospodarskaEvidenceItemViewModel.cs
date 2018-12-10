using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class LesniHospodarskaEvidenceItemViewModel : BaseViewModel
    {

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

        private DateTime _datum;
        public DateTime Datum { get { return _datum; } set { _datum = value; OnPropertyChanged("Datum"); } }

        private Vykon _vykon;
        public Vykon Vykon { get { return _vykon; } set { _vykon = value; OnPropertyChanged("Vykon");  if (Vykon != null ) PodvykonList = podvykonTableModule.LoadPodvykony(value); } }

        private Podvykon _podvykon;
        public Podvykon Podvykon { get { return _podvykon; } set { _podvykon = value; OnPropertyChanged("Podvykon"); } }

        private DruhTezby _druhTezby;
        public DruhTezby DruhTezby { get { return _druhTezby; } set { _druhTezby = value; OnPropertyChanged("DruhTezby"); } }

        private Drevina _drevina;
        public Drevina Drevina { get { return _drevina; } set { _drevina = value; OnPropertyChanged("Drevina"); } }

        private double _plocha;
        public double Plocha { get { return _plocha; } set { _plocha = value; OnPropertyChanged("Plocha"); } }

        private double _mnozstvi;
        public double Mnozstvi { get { return _mnozstvi; } set { _mnozstvi = value; OnPropertyChanged("Mnozstvi"); } }

        private string _poznamka;
        public string Poznamka { get { return _poznamka; } set { _poznamka = value; OnPropertyChanged("Poznamka"); } }

        public ICommand AddEditCommand { get; set; }
        public ICommand StornoCommand { get; set; }

        private string _addEditLabel;
        public string AddEditLabel { get { return _addEditLabel; } set { _addEditLabel = value; OnPropertyChanged("AddEditLabel"); } }

        private string _windowLabel;
        public string WindowLabel { get { return _windowLabel; } set { _windowLabel = value; OnPropertyChanged("WindowLabel"); } }

        private PorostniSkupina psk;
        private LesniHospodarskaEvidence lheItem;

        public LesniHospodarskaEvidenceItemViewModel(IStorageContext db, PorostniSkupina psk, LesniHospodarskaEvidence lheItem = null)
        {
            this.psk = psk;
            this.lheItem = lheItem;

            vykonTableModule = new VykonTableModule(db);
            podvykonTableModule = new PodvykonTableModule(db);
            drevinaTableModule = new DrevinaTableModule(db);
            druhTezbyTableModule = new DruhTezbyTableModule(db);
            lheTableModule = new LesniHospodarskaEvidenceTableModule(db);

            VykonList = vykonTableModule.LoadVykony();
            DrevinaList = drevinaTableModule.LoadDreviny();
            DruhTezbyList = druhTezbyTableModule.LoadDruhyTezby();

            if (lheItem != null)
            {
                Datum = lheItem.Datum;
                Vykon = VykonList.Find(x => x.Id.Equals(lheItem.Podvykon.IdVykon));
                Podvykon = PodvykonList.Find(x => x.Id.Equals(lheItem.IdPodvykon));
                DruhTezby = DruhTezbyList.Find(x => x.Id.Equals(lheItem.IdDruhTezby));
                Drevina = DrevinaList.Find(x => x.Id.Equals(lheItem.IdDrevina));
                Plocha = lheItem.Plocha;
                Mnozstvi = lheItem.Mnozstvi;
                Poznamka = lheItem.Poznamka;

                AddEditCommand = new RelayCommand(EditButton_ClickCommand);
                AddEditLabel = "Aktualizovat";
                WindowLabel = "Aktualizovat záznam LHE";
            }
            else
            {
                AddEditCommand = new RelayCommand(AddButton_ClickCommand);
                AddEditLabel = "Přidat záznam";
                WindowLabel = "Přidat záznam LHE";
                Datum = DateTime.Now;
            }
            StornoCommand = new RelayCommand(StornoButton_ClickCommand);
        }

        public void AddButton_ClickCommand(object param)
        {
            if (Datum == null || Drevina == null || DruhTezby == null || Podvykon == null || Mnozstvi == null || Poznamka == null || Plocha == null)
            {
                MessageBox.Show("Vyplňte prosím všechny položky", "Chyba", MessageBoxButton.OK);
                return;
            }

            var lhe = new LesniHospodarskaEvidence
            {
                Id = DateTime.Now.ToBinary().ToString(),
                PorostniSkupina = psk,
                Datum = this.Datum,
                Drevina = this.Drevina,
                DruhTezby = this.DruhTezby,
                Podvykon = this.Podvykon,
                Mnozstvi = this.Mnozstvi,
                Poznamka = this.Poznamka,
                Plocha = this.Plocha
            };

            lheTableModule.AddLhe(lhe);
            LheObserver.Instance.NotifyLheTableChanged();
            Close();
        }

        public void EditButton_ClickCommand(object param)
        {
            var lhe = new LesniHospodarskaEvidence
            {
                Id = lheItem.Id,
                PorostniSkupina = psk,
                Datum = this.Datum,
                Drevina = this.Drevina,
                DruhTezby = this.DruhTezby,
                Podvykon = this.Podvykon,
                Mnozstvi = this.Mnozstvi,
                Poznamka = this.Poznamka,
                Plocha = this.Plocha
            };

            lheTableModule.UpdateLhe(lhe);
            LheObserver.Instance.NotifyLheTableChanged();
            Close();
        }

        public void StornoButton_ClickCommand(object param)
        {
            Close();
        }



    }
}
 