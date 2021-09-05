using MyFriendApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFriendApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePagePortrait : ContentView
    {
        private const string Url = "https://myfriendapi.azurewebsites.net/api/accounts";
        public ObservableCollection<Account> DataSource { get; set; }

        public HomePagePortrait()
        {
            InitializeComponent();
            GetListAccounts(Url);
        }

        async protected void GetListAccounts(string url)
        {
            HttpClient client = new HttpClient();
            string responseContent = await client.GetStringAsync(url);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(responseContent);
            DataSource = new ObservableCollection<Account>(accounts);
            AccountListView.ItemsSource = DataSource;
        }
    }
}