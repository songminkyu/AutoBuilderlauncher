using AutoBuilderlauncher.CommandServices;
using AutoBuilderlauncher.Model;
using AutoBuilderlauncher.Service;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilderlauncher.ViewModel
{
    public class AutoBuilderlauncherViewModel : AutoBuilderlauncherViewModelBase
    {
        public AutoBuilderlauncherViewModel()
        {
            LoadedCommand = new AsyncRelayCommand<object>(LoadedCommandExe);
        }

        private async Task LoadedCommandExe(object? arg)
        {
            await Task.Run(async () =>
            {
                /*
                 {
                    "path": "string",
                    "organName": "NEC",
                    "productName": "FFR"
                 }                 
                 */
                ProductInfo FileExeInfo = new ProductInfo()
                {
                    Path = "",
                    OrganName = Enums.OrganCategory.NEC,
                    ProductName = Enums.ProductCategory.FFR
                };

                HttpProvider httpProvider = new HttpProvider();                
                await httpProvider.HttpSendMessage<ProductInfo>(FileExeInfo, "http://localhost:5159/FileExecution/run-file", "utf-8");                 
            });
        }
    }
}
