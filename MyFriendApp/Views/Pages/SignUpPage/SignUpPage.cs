using MyFriendApp.Base.Pages;
using MyFriendApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFriendApp.Pages
{
    public class SignUpPage : BaseContentPage
    {
        public SignUpPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new SignUpPageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new SignUpPageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new SignUpPagePortrait();
        }
    }
}
