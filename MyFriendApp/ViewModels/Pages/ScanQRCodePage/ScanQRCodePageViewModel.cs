using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using MyFriendApp.Models;
using MyFriendApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyFriendApp.ViewModels
{
    public class ScanQRCodePageViewModel : BaseViewModel
    {
        private string Url = "https://myfriendapi.azurewebsites.net/api/accounts";


        public ScanQRCodePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public ICommand NavigateScanQRCodeCommand => new Command(async () =>
        {
            var image = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (image == null)
            {
                return;
            }

            var stream = await image.OpenReadAsync();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, bytes.Length);
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            var results = await GoogleVisionBarCodeScanner.Methods.ScanFromImage(bytes);

            var resultString = string.Empty;
            foreach (var barcode in results)
            {
                resultString = barcode.DisplayValue;
            }

            if (!resultString.Equals(string.Empty))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Account acc = JsonConvert.DeserializeObject<Account>(resultString);

                    var serializeItem = JsonConvert.SerializeObject(acc);
                    StringContent body = new StringContent(serializeItem, Encoding.UTF8, "application/json");
                    HttpClient client = new HttpClient();
                    await client.PostAsync(Url, body);

                    //await App.Current.MainPage.DisplayAlert("Results", resultString, "OK");
                    //GoogleVisionBarCodeScanner.Methods.SetIsScanning(true);
                });
                await _navigationService.GoBack();
                
            }
            
        });

        public ICommand OnScanResult => new Command( () =>
        {

        });
    }
}
