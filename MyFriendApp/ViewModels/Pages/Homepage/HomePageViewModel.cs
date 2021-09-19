using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using MyFriendApp.Models;
using MyFriendApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFriendApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private const string Url = "https://myfriendapi.azurewebsites.net/api/accounts";
        public ObservableCollection<Account> DataSource { get; set; }

        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //GetAccountsFromApi(Url);

            //DataSource = new ObservableCollection<Account>();
            //DataSource.Add(new Account("Khang", "gmail", "username1", "pass1"));
            //DataSource.Add(new Account("Khang", "gmail", "username2", "pass2"));
            //DataSource.Add(new Account("Khang", "gmail", "username3", "pass3"));
            //DataSource.Add(new Account("Khang", "gmail", "username4", "pass4"));
        }

        async protected void GetListAccounts(string url)
        {
            HttpClient client = new HttpClient();
            string responseContent = await client.GetStringAsync(url);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(responseContent);
            DataSource = new ObservableCollection<Account>(accounts);
        }

        public ICommand NavigateBackCommand => new Command(async () =>
        {
            await _navigationService.GoBack();
        });

        public ICommand NavigateMyQRCodeCommand => new Command(async () =>
        {
            _navigationService.Register(nameof(MyQRCodePage), typeof(MyQRCodePage));
            await _navigationService.NavigateAsync(nameof(MyQRCodePage));
        });

        public ICommand NavigateScanQRCodeCommand => new Command(async () =>
        {
            _navigationService.Register(nameof(ScanQRCodePage), typeof(ScanQRCodePage));
            await _navigationService.NavigateAsync(nameof(ScanQRCodePage));
        });
    }
}
