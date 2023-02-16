using Chazan.GamesCatalog.BL;
using Chazan.GamesCatalog.INTERFACES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;

namespace Chazan.GamesCatalog.UI.ViewModel
{
    public class ProducerListViewModel : ViewModelBase
    {
        public ObservableCollection<ProducerViewModel> Producers { get; set; } = new ObservableCollection<ProducerViewModel>();
        private ListCollectionView _view;
        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand
        {
            get => _filterDataCommand;
        }
        public string FilterValue { get; set; }

        private BL.DataAccess dataAccess = null;
        public ProducerListViewModel()
        {
            try
            {
                dataAccess = Singleton.Instance;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Creating DAO Failed!");
            }
            OnPropertyChanged("Producers");
            GetAllProducers();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Producers);
            _filterDataCommand = new RelayCommand(param => FilterData());
            _addNewProducerCommand = new RelayCommand(param => AddNewProducer(), param => CanAddNewProducer());
            _saveProducerCommand = new RelayCommand(param => SaveProducer(), param => CanSaveProducer());
            _deleteProducerCommand = new RelayCommand(param => DeleteProducer(), param => CanDeleteProducer());
            EditedProducer = null;
            SelectedProducer = EditedProducer;
        }
        private void GetAllProducers()
        {
            List<IProducer> producers = dataAccess.DAO.GetAllProducers().ToList();
            foreach (var producer in producers)
            {
                Producers.Add(new ProducerViewModel(producer));
            }
        }
        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (p) => ((ProducerViewModel)p).Name.Contains(FilterValue);
            }
        }
        private ProducerViewModel _editedProducer;
        public ProducerViewModel EditedProducer
        {
            get => _editedProducer;
            set
            {
                _editedProducer = value;
                OnPropertyChanged(nameof(EditedProducer));
            }
        }
        private ProducerViewModel _selectedProducer;
        public ProducerViewModel SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                EditedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }
        private RelayCommand _saveProducerCommand;
        public RelayCommand SaveProducerCommand
        {
            get => _saveProducerCommand;
        }
        private void SaveProducer()
        {
            if (!Producers.Contains(EditedProducer))
            {
                Producers.Add(EditedProducer);
                dataAccess.DAO.SaveProducer(EditedProducer.Producer);
                EditedProducer = null;
            }
            EditedProducer = null;
        }
        private bool CanSaveProducer()
        {
            if (EditedProducer != null && !EditedProducer.HasErrors)
            {
                return true;
            }
            return false;
        }
        private RelayCommand _addNewProducerCommand;
        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;
        }
        private void AddNewProducer()
        {
            IProducer newProducer = dataAccess.AddProducer();
            EditedProducer = new ProducerViewModel(newProducer);
            EditedProducer.Validate();
        }
        private bool CanAddNewProducer()
        {
            if (EditedProducer != null)
            {
                return false;
            }
            return true;
        }
        private RelayCommand _deleteProducerCommand;
        public RelayCommand DeleteProducerCommand
        {
            get => _deleteProducerCommand;
        }
        private void DeleteProducer()
        {
            if (Producers.Contains(SelectedProducer))
            {
                dataAccess.DAO.DeleteProducer(SelectedProducer.Producer);
                Producers.Remove(SelectedProducer);
                EditedProducer = null;
            }
            EditedProducer = null;
        }
        private bool CanDeleteProducer()
        {
            if (EditedProducer != null && !EditedProducer.HasErrors)
            {
                return true;
            }
            return false;
        }
    }
}
