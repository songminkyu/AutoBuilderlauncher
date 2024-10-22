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
        
        private ObservableCollection<ProductInfo> _ProductCategories { get; set; }
        public ObservableCollection<ProductInfo> ProductCategories
        {
            get { return _ProductCategories; }
            set
            {
                if (_ProductCategories == value) return;
                _ProductCategories = value;

                OnPropertyChanged("ProductCategories");
            }
        }
        private ProductInfo _SelectedProductCategory { get; set; }
        public ProductInfo SelectedProductCategory
        {
            get { return _SelectedProductCategory; }
            set
            {
                if (_SelectedProductCategory == value) return;
                _SelectedProductCategory = value;

                OnPropertyChanged("SelectedProductCategory");
            }
        }
        
    }
}
