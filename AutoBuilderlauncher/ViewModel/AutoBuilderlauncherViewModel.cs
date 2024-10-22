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
            LoadedCommand = new AsyncRelayCommand<object>(LoadedCommandExe);
            ProductCategories = new ObservableCollection<ProductInfo>();
            SelectedProductCategory = new ProductInfo();
        }

        private async Task LoadedCommandExe(object? arg)
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
            await Task.Run(async () =>
            {
                /*
                 {
                    "path": "string",
                    "organName": "NEC",
                    "productName": "FFR"
                 }                 
                 */
        
                HttpProvider httpProvider = new HttpProvider();                
                await httpProvider.HttpSendMessage<ProductInfo>(ProductCategories[0], "http://localhost:5159/ProductInfo/run-file", "utf-8");                 
            });
        }
    }
}
