using Service;
using GraphicalData.Model;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using GraphicalData.ViewDataStandard.MVVMLight;

namespace GraphicalData.ViewDataStandard
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DataRepository = new DataRepository();
            FetchDataCommand = new RelayCommand(() => DataRepository = new DataRepository());
            AddVendorCommand = new RelayCommand(AddVendor);
            RemoveVendorCommand = new RelayCommand(RemoveVendor);
            UpdateVendorCommand = new RelayCommand(UpdateVendor);
            InfoVendorCommand = new RelayCommand(GetInfo);

        }

        public ObservableCollection<Vendor> Vendors
        {
            get { return m_Vendors; }
            set
            {
                m_Vendors = value;
                RaisePropertyChanged();
            }
        }

        public Vendor Vendor
        {
            get { return m_Vendor; }
            set
            {
                m_Vendor = value;
                RaisePropertyChanged();
            }
        }

        public IDataRepository DataRepository
        {
            get { return m_DataRepository; }
            set
            {
                m_DataRepository = value;
                Task.Run(() =>
                {
                    Vendors = new ObservableCollection<Vendor>(value.GetAllVendors());
                });
            }
        }

        private string RandomStringGenerator(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void AddVendor()
        {
            Vendor vendor = new Vendor
            {
                BusinessEntityID = Id,
                Name = Name,
                AccountNumber = RandomStringGenerator(15),
                CreditRating = 1,
                PreferredVendorStatus = true,
                ActiveFlag = true,
                ModifiedDate = DateTime.Now
            };

            if (string.IsNullOrEmpty(Name))
            {
                ViewModelHelper.Show("Name cannot be empty", "AddVendor");
            }
            else if (vendor.Name.Length > 50)
            {
                ViewModelHelper.Show("Name cannot be longer than 50 char", "AddVendor");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataRepository.AddVendor(vendor);
                });
            }
        }

        public void RemoveVendor()
        {
            if (Id <= 0)
            {
                ViewModelHelper.Show("ID cannot be smaller or equal than 0", "RemoveVendor");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataRepository.DeleteVendor(Id);
                });
            }
        }

        public void GetInfo()
        {
            if (Id <= 0)
            {
                ViewModelHelper.Show("ID cannot be smaller or equal than 0", "GetInfoVendor");
            }
            else
            {
                Task.Run(() =>
                {
                    Vendors = new ObservableCollection<Vendor>();
                    Vendor = m_DataRepository.GetVendroById(Id);
                    Vendors.Add(Vendor);
                });
                ViewModelHelper.ShowInfo();
            }

        }

        public void UpdateVendor()
        {
            if (string.IsNullOrEmpty(Name) || Id == 0)
            {
                ViewModelHelper.Show("Wrong Vendor name|id", "UpdateVendor");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataRepository.UpdateVendorName(Name, Id);
                });
            }
        }

        public RelayCommand FetchDataCommand
        {
            get; private set;
        }

        public RelayCommand AddVendorCommand
        {
            get; private set;
        }

        public RelayCommand RemoveVendorCommand
        {
            get; private set;
        }

        public RelayCommand InfoVendorCommand
        {
            get; private set;
        }

        public RelayCommand UpdateVendorCommand
        {
            get; private set;
        }

        private IDataRepository m_DataRepository;
        private Vendor m_Vendor;
        private ObservableCollection<Vendor> m_Vendors;

        public IViewModelHelper ViewModelHelper { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

    }
}
