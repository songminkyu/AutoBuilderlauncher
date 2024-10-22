using AutoBuilderlauncher.CommandServices;
using AutoBuilderlauncher.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AutoBuilderlauncher.ViewModel
{
    public class AutoBuilderlauncherViewModelBase : BindableBase
    {
        protected bool IsSelectedFF { get; set; }
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

        private IRelayCommand<object> _DiskProductChangedCommand { get; set; }
        public IRelayCommand<object> DiskProductChangedCommand
        {
            get { return _DiskProductChangedCommand; }
            set
            {
                if (_DiskProductChangedCommand == value) return;
                _DiskProductChangedCommand = value;
            }
        }


        private IRelayCommand<object> _MobileProductChangedCommand { get; set; }
        public IRelayCommand<object> MobileProductChangedCommand
        {
            get { return _MobileProductChangedCommand; }
            set
            {
                if (_MobileProductChangedCommand == value) return;
                _MobileProductChangedCommand = value;
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
    }
}
