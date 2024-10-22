using AutoBuilderlauncher.Model;
using AutoBuilderlauncher.Service;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AutoBuilderlauncher.ViewModel
{
    public class AutoBuilderlauncherViewModel : AutoBuilderlauncherViewModelBase
    {
        public AutoBuilderlauncherViewModel()
        {
            IsSelectedFF = true;
            LoadedCommand = new RelayCommand<object>(LoadedCommandExe);
            RequestCommand = new AsyncRelayCommand<object>(RequestCommandExe);
            CancelCommand = new RelayCommand<object>(CancelCommandExe);
            DiskProductCategories = new ObservableCollection<ProductInfo>();
            SelectedDiskProductCategory = new ProductInfo();
            MobileProductCategories = new ObservableCollection<ProductInfo>();
            SelectedMobileProductCategory = new ProductInfo();

            DiskProductChangedCommand = new RelayCommand<object>(DiskProductChangedCommandExe);
            MobileProductChangedCommand = new RelayCommand<object>(MobileProductChangedCommandExe);
        }

        private void LoadedCommandExe(object? arg)
        {
            DiskProductCategories.Add(new ProductInfo()
            {
                Path = "",
                OrganName = Enums.OrganCategory.AOS,
                ProductName = Enums.ProductCategory.FFR_Portable
            });
            DiskProductCategories.Add(new ProductInfo()
            {
                Path = "",
                OrganName = Enums.OrganCategory.AOS,
                ProductName = Enums.ProductCategory.FFR
            });
            MobileProductCategories.Add(new ProductInfo()
            {
                Path = "",
                OrganName = Enums.OrganCategory.None,
                ProductName = Enums.ProductCategory.FMFR
            });
            MobileProductCategories.Add(new ProductInfo()
            {
                Path = "",
                OrganName = Enums.OrganCategory.None,
                ProductName = Enums.ProductCategory.FMLR
            });
        }
        private void DiskProductChangedCommandExe(object? obj)
        {
            IsSelectedFF = true;
        }

        private void MobileProductChangedCommandExe(object? obj)
        {
            IsSelectedFF = false;
        }

        private async Task RequestCommandExe(object? arg)
        {
            await Task.Run(async () =>
            {
                HttpProvider httpProvider = new HttpProvider();
                var selected = IsSelectedFF == true ? SelectedDiskProductCategory : SelectedMobileProductCategory;          
                await httpProvider.HttpSendMessage<ProductInfo>(selected, "http://172.16.10.86:5159/ProductInfo/run-file", "utf-8");
            });
        }
        private void CancelCommandExe(object? obj)
        {
            Environment.Exit(0);
        }
    }
}
