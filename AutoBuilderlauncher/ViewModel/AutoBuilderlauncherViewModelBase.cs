using AutoBuilderlauncher.CommandServices;
using AutoBuilderlauncher.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AutoBuilderlauncher.ViewModel
{
    public class AutoBuilderlauncherViewModelBase : BindableBase
    {
        private IRelayCommand<object> _LoadedCommand { get; set; }
        public IRelayCommand<object> LoadedCommand
        {
            get { return _LoadedCommand; }
            set
            {
                if (_LoadedCommand == value) return;
                _LoadedCommand = value;
            }
        }    
        private IAsyncRelayCommand<object> _RequestCommand { get; set; }
        public IAsyncRelayCommand<object> RequestCommand
        {
            get { return _RequestCommand; }
            set
            {
                if (_RequestCommand == value) return;
                _RequestCommand = value;
            }
        }
        private IRelayCommand<object> _CancelCommand { get; set; }
        public IRelayCommand<object> CancelCommand
        {
            get { return _CancelCommand; }
            set
            {
                if (_CancelCommand == value) return;
                _CancelCommand = value;
            }
        }
        private IAsyncRelayCommand<object> _VersionInfoCommand { get; set; }
        public IAsyncRelayCommand<object> VersionInfoCommand
        {
            get { return _VersionInfoCommand; }
            set
            {
                if (_VersionInfoCommand == value) return;
                _VersionInfoCommand = value;
            }
        }
        
        private ObservableCollection<ProductInfo> _DiskProductCategories { get; set; }
        public ObservableCollection<ProductInfo> DiskProductCategories
        {
            get { return _DiskProductCategories; }
            set
            {
                if (_DiskProductCategories == value) return;
                _DiskProductCategories = value;

                OnPropertyChanged("DiskProductCategories");
            }
        }
        private ProductInfo _SelectedDiskProductCategory { get; set; }
        public ProductInfo SelectedDiskProductCategory
        {
            get { return _SelectedDiskProductCategory; }
            set
            {
                if (_SelectedDiskProductCategory == value) return;
                _SelectedDiskProductCategory = value;

                OnPropertyChanged("SelectedDiskProductCategory");
            }
        }
        private ObservableCollection<ProductInfo> _MobileProductCategories { get; set; }
        public ObservableCollection<ProductInfo> MobileProductCategories
        {
            get { return _MobileProductCategories; }
            set
            {
                if (_MobileProductCategories == value) return;
                _MobileProductCategories = value;

                OnPropertyChanged("MobileProductCategories");
            }
        }
        private ProductInfo _SelectedMobileProductCategory { get; set; }
        public ProductInfo SelectedMobileProductCategory
        {
            get { return _SelectedMobileProductCategory; }
            set
            {
                if (_SelectedMobileProductCategory == value) return;
                _SelectedMobileProductCategory = value;

                OnPropertyChanged("SelectedMobileProductCategory");
            }
        }
        private bool _IsSelectedDisk { get; set; }
        public bool IsSelectedDisk
        {
            get { return _IsSelectedDisk; }
            set
            {
                if (_IsSelectedDisk == value) return;
                _IsSelectedDisk = value;

                OnPropertyChanged("IsSelectedDisk");
            }
        }
        private bool _IsSelectedMobile { get; set; }
        public bool IsSelectedMobile
        {
            get { return _IsSelectedMobile; }
            set
            {
                if (_IsSelectedMobile == value) return;
                _IsSelectedMobile = value;

                OnPropertyChanged("IsSelectedMobile");
            }
        }
        
    }
}
