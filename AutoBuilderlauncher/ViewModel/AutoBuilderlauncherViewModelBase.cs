using AutoBuilderlauncher.CommandServices;
using CommunityToolkit.Mvvm.Input;

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
    }
}
