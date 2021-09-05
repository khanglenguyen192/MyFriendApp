using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using MyFriendApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFriendApp.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private const int MIN_PASSWORD_LENGTH = 6;
        private string Url = "https://myfriendapi.azurewebsites.net/api/accounts";

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }
        private string _account;
        public string Account
        {
            get { return _account; }
            set
            {
                SetProperty(ref _account, value);
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                SetProperty(ref _confirmPassword, value);
            }
        }

        public SignUpPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Name = "";
            Email = "";
            Account = "";
            Password = "";
            ConfirmPassword = "";
        }
        public ICommand NavigateSignUpCommand => new Command(async () =>
        {
            if (Name.Length == 0 || Email.Length == 0 || Account.Length == 0 || Password.Length == 0 || ConfirmPassword.Length == 0)
            {
                DependencyService.Get<IToastService>().Show("Please Fill All Information");
            }
            else if (!Equals(Password, ConfirmPassword))
            {
                DependencyService.Get<IToastService>().Show("Please check the Confirmed Password");
            }
            else if (Password.Length < MIN_PASSWORD_LENGTH)
            {
                DependencyService.Get<IToastService>().Show("Please Enter A Stronger Password");
            }
            else
            {
                Account newAccount = new Account(Name, Email, Account, Password);
                Name = "";
                Email = "";
                Account = "";
                Password = "";
                ConfirmPassword = "";
                PostAccount(newAccount, Url);
                DependencyService.Get<IToastService>().Show("Successful");
            }
        });

        public ICommand NavigateLoginCommand => new Command(async () =>
        {
            await _navigationService.GoBack();
        });

        protected async void PostAccount(Account account, string url)
        {
            var serializeItem = JsonConvert.SerializeObject(account);
            StringContent body = new StringContent(serializeItem, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            await client.PostAsync(url, body);
        }
    }
}
