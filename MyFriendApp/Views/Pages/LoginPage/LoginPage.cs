using MyFriendApp.Base.Pages;
using MyFriendApp.Base.Services;
using MyFriendApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyFriendApp.Pages
{
    public class LoginPage : BaseContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LoginPageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new LoginPageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new LoginPagePortrait();
        }
    }
}