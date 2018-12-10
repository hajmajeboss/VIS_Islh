using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using DesktopClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class LesniHospodarskaEvidenceViewModel : BaseViewModel
    {
        private IStorageContext db;
        LesniHospodarskaEvidenceTableModule lheTableModule;
        LesniHospodarskyCelekTableModule lhcTableModule;
        OddeleniTableModule oddTableModule;
        DilecTableModule dilTableModule;
        PorostTableModule porTableModule;
        PorostniSkupinaTableModule pskTableModule;

        public ICommand FilterCommand { get; set; }
        public ICommand AddLheCommand { get; set; }
        public ICommand EditLheCommand { get; set; }
        public ICommand RemoveLheCommand { get; set; }
        public ICommand UpdateLheCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private List<LesniHospodarskyCelek> _lhcList;
        public List<LesniHospodarskyCelek> LhcList { get { return _lhcList; } set { _lhcList = value; OnPropertyChanged("LhcList"); } }

        private LesniHospodarskyCelek _lhcListSelected;
        public LesniHospodarskyCelek LhcListSelected { get { return _lhcListSelected; } set { _lhcListSelected = value; OnPropertyChanged("LhcListSelected"); OddList = oddTableModule.LoadOddeleni(value); } }

        private List<Oddeleni> _oddList;
        public List<Oddeleni> OddList { get { return _oddList; } set { _oddList = value; DilList = null; OnPropertyChanged("OddList"); } }

        private Oddeleni _oddListSelected;
        public Oddeleni OddListSelected { get { return _oddListSelected; } set { _oddListSelected = value; OnPropertyChanged("OddListSelected"); DilList = dilTableModule.LoadDilce(value); } }

        private List<Dilec> _dilList;
        public List<Dilec> DilList { get { return _dilList; } set { _dilList = value; PorList = null; OnPropertyChanged("DilList"); } }

        private Dilec _dilListSelected;
        public Dilec DilListSelected { get { return _dilListSelected; } set { _dilListSelected = value; OnPropertyChanged("DilListSelected"); PorList = porTableModule.LoadPorosty(value); } }

        private List<Porost> _porList;
        public List<Porost> PorList { get { return _porList; } set { _porList = value; PskList = null; OnPropertyChanged("PorList"); } }

        private Porost _porListSelected;
        public Porost PorListSelected { get { return _porListSelected; } set { _porListSelected = value; OnPropertyChanged("PorListSelected"); PskList = pskTableModule.LoadPorostniSkupiny(value); } }

        private List<PorostniSkupina> _pskList;
        public List<PorostniSkupina> PskList { get { return _pskList; } set { _pskList = value; LheList = null; OnPropertyChanged("PskList"); } }

        private PorostniSkupina _pskListSelected;
        public PorostniSkupina PskListSelected { get { return _pskListSelected; } set { _pskListSelected = value; OnPropertyChanged("PskListSelected"); LheList = lheTableModule.LoadLhe(value); } }

        private List<LesniHospodarskaEvidence> _lheList;
        public List<LesniHospodarskaEvidence> LheList { get { return _lheList; } set { _lheList = value; OnPropertyChanged("LheList"); } }

        private LesniHospodarskaEvidence _lheSelected;
        public LesniHospodarskaEvidence LheSelected { get { return _lheSelected; } set { _lheSelected = value; OnPropertyChanged("LheSelected"); } }

        private string _numberOfEntries;
        public string NumberOfEntries { get { return _numberOfEntries; } set { _numberOfEntries = value; OnPropertyChanged("NumberOfEntries"); } }

        public LesniHospodarskaEvidenceViewModel(IStorageContext db, Uzivatel uzivatel)
        {
            this.db = db;
            lheTableModule = new LesniHospodarskaEvidenceTableModule(db);
            lhcTableModule = new LesniHospodarskyCelekTableModule(db);
            oddTableModule = new OddeleniTableModule(db);
            dilTableModule = new DilecTableModule(db);
            porTableModule = new PorostTableModule(db);
            pskTableModule = new PorostniSkupinaTableModule(db);

            FilterCommand = new RelayCommand(FilterButton_ClickCommand);
            AddLheCommand = new RelayCommand(AddLheButton_ClickCommand);
            EditLheCommand = new RelayCommand(EditLheButton_ClickCommand);
            RemoveLheCommand = new RelayCommand(RemoveLheButton_ClickCommand);
            UpdateLheCommand = new RelayCommand(UpdateLheButton_ClickCommand);
            CloseCommand = new RelayCommand(CloseButton_ClickCommand);

            LhcList = lhcTableModule.LoadLhc(uzivatel);
        }

        public void FilterButton_ClickCommand(object param)
        {
            var filterView = new LesniHospodarskaEvidenceFilterView();
            filterView.Show();
        }

        public void AddLheButton_ClickCommand(object param)
        {
            if (PskListSelected != null)
            {
                var addLheView = new LesniHospodarskaEvidenceItemView(PskListSelected);
                addLheView.Show();
            }
            else
            {
                MessageBox.Show("Vyberte prosím porostní skupinu.", "Chyba", MessageBoxButton.OK);
            }
        }

        public void EditLheButton_ClickCommand(object param)
        {
            if (PskListSelected != null) {
                if (LheSelected != null)
                {
                    var editLheView = new LesniHospodarskaEvidenceItemView(PskListSelected, LheSelected);
                    editLheView.Show();
                }
                else
                {
                    MessageBox.Show("Vyberte prosím záznam LHE.", "Chyba", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Vyberte prosím porostní skupinu.", "Chyba", MessageBoxButton.OK);
            }
        }

        public void RemoveLheButton_ClickCommand(object param)
        {
            if (PskListSelected != null)
            {
                if (LheSelected != null)
                {
                    var result = MessageBox.Show("Opravdu chcete smazat tento záznam?", "Smazat záznam", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        lheTableModule.RemoveLhe(LheSelected);
                        LheList = lheTableModule.LoadLhe(PskListSelected);
                    }
                }
                else
                {
                    MessageBox.Show("Vyberte prosím záznam LHE.", "Chyba", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Vyberte prosím porostní skupinu.", "Chyba", MessageBoxButton.OK);
            }
     
        }

        public void UpdateLheButton_ClickCommand(object param)
        {
            LheList = lheTableModule.LoadLhe(PskListSelected);
        }

        public void CloseButton_ClickCommand(object param)
        {
            Close();
        }
    }

}
