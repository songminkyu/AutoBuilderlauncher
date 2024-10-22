using AutoBuilderlauncher.CommandServices;
using AutoBuilderlauncher.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AutoBuilderlauncher.ViewModel
{
    public class AutoBuilderlauncherViewModelBase : BindableBase
    {
        private IAsyncRelayCommand<object> _LoadedCommand { get; set; }
        public IAsyncRelayCommand<object> LoadedCommand
        {
            get { return _LoadedCommand; }
            set
            {
                if (_LoadedCommand == value) return;
                _LoadedCommand = value;
            }
        }

        private ObservableCollection<FileExeInfo> _ProductCategories
        public ObservableCollection<FileExeInfo> ProductCategories
        {
            get { return _ProductCategories; }
            set
            {
                if (_ProductCategories == value) return;
                _ProductCategories = value;

                OnPropertyChanged("ProductCategories");
            }
        }
    }
}
