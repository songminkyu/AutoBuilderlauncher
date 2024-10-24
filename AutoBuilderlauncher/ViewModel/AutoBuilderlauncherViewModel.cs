using AutoBuilderlauncher.Model;
using AutoBuilderlauncher.Service;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AutoBuilderlauncher.ViewModel
{
    public class AutoBuilderlauncherViewModel : AutoBuilderlauncherViewModelBase
    {
        public AutoBuilderlauncherViewModel()
        {
            IsSelectedDisk = true;
            IsSelectedMobile = false;
            LoadedCommand = new RelayCommand<object>(LoadedCommandExe);
            RequestCommand = new AsyncRelayCommand<object>(RequestCommandExe);
            CancelCommand = new RelayCommand<object>(CancelCommandExe);
            DiskProductCategories = new ObservableCollection<ProductInfo>();
            SelectedDiskProductCategory = new ProductInfo();
            MobileProductCategories = new ObservableCollection<ProductInfo>();
            SelectedMobileProductCategory = new ProductInfo();       
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


        private async Task RequestCommandExe(object? arg)
        {          
            var selected = IsSelectedDisk == true ? SelectedDiskProductCategory : SelectedMobileProductCategory;
            HttpResultData<ProductInfo> res = new HttpResultData<ProductInfo>();
            await Task.Run(async () =>
            {
                HttpProvider httpProvider;
                if (IsSelectedDisk == true)
                    httpProvider = new HttpProvider(10);
                else
                    httpProvider = new HttpProvider(30); //FMF 장시간 빌드로 인해서 시간 다수 필요

                res = await httpProvider.HttpSendMessage<ProductInfo>(selected, "http://172.16.10.86:5159/ProductInfo/run-file", "utf-8");
            });
            if (res.HttpStatusCode >= 400 || res.HttpStatusCode == -1)
            {
                MessageBox.Show(res.ResponseData, "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string message = string.Format("{0} 빌드 완료 되었습니다.", selected.ProductName);
                MessageBox.Show(message, "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }                 
        }
        private void CancelCommandExe(object? obj)
        {
            Environment.Exit(0);
        }
    }
}
