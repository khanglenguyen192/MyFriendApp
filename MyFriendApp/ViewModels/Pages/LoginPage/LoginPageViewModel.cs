using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using MyFriendApp.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFriendApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
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

        public LoginPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Account = String.Empty;
            Password = String.Empty;
        }

        public ICommand NavigateSignUpCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync(nameof(SignUpPage));
        });

        public ICommand NavigateLoginCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync(nameof(HomePage));
            Account = String.Empty;
            Password = String.Empty;
        });

        public ICommand NavigateForgotPasswordCommand => new Command(async () =>
        {
            DependencyService.Get<IToastService>().Show("FORGOT PASSWORD");
        });

        public ICommand NavigateGoogleCommand => new Command(async () =>
        {
            DependencyService.Get<IToastService>().Show("GOOGLE");
        });

        public ICommand NavigateFacebookCommand => new Command(async () =>
        {
            DependencyService.Get<IToastService>().Show("FACEBOOK");
        });

        public ICommand NavigateTwitterCommand => new Command(async () =>
        {
            DependencyService.Get<IToastService>().Show("TWITTER");
        });
    }
}
