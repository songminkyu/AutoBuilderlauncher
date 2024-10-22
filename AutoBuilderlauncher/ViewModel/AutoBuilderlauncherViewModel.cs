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
            LoadedCommand = new RelayCommand<object>(LoadedCommandExe);
            RequestCommand = new AsyncRelayCommand<object>(RequestCommandExe);
            CancelCommand = new RelayCommand<object>(CancelCommandExe);
            ProductCategories = new ObservableCollection<ProductInfo>();
            SelectedProductCategory = new ProductInfo();
        }
     
        private void LoadedCommandExe(object? arg)
        {
            ProductCategories.Add(new ProductInfo()
            {
                Path = "",
                OrganName = Enums.OrganCategory.AOS,
                ProductName = Enums.ProductCategory.FFR_Portable
            });
            ProductCategories.Add(new ProductInfo()
            {
                Path = "",
                OrganName = Enums.OrganCategory.AOS,
                ProductName = Enums.ProductCategory.FFR
            });            
            
        }
    
        private async Task RequestCommandExe(object? arg)
        {
            await Task.Run(async () =>
            {        
                if (SelectedProductCategory != null)
                {
                    HttpProvider httpProvider = new HttpProvider();
                    await httpProvider.HttpSendMessage<ProductInfo>(SelectedProductCategory, "http://localhost:5159/ProductInfo/run-file", "utf-8");
                }                
            });
        }
        private void CancelCommandExe(object? obj)
        {

        }
    }
}
