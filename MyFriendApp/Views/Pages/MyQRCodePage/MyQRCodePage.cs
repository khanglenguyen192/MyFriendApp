using MyFriendApp.Base.Pages;
using MyFriendApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFriendApp.Pages
{
    public class MyQRCodePage : BaseContentPage
    {
        public MyQRCodePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new MyQRCodePageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new MyQRCodePageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new MyQRCodePagePortrait();
        }
    }
}
