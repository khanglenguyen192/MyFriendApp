using MyFriendApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFriendApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanQRCodePagePortrait : ContentView
    {
        public ScanQRCodePagePortrait()
        {
            InitializeComponent();
            GoogleVisionBarCodeScanner.Methods.AskForRequiredPermission();
        }

        private string Url = "https://myfriendapi.azurewebsites.net/api/accounts";
        void CameraView_OnScan(System.Object sender, GoogleVisionBarCodeScanner.OnDetectedEventArg e)
        {
            var results = e.BarcodeResults;
            var resultString = string.Empty;
            foreach (var barcode in results)
            {
                resultString = barcode.DisplayValue;
            }

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
            Task.Delay(500);
            App.NavigationService.GoBack();
        }
    }
}