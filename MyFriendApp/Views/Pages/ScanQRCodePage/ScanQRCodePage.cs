using MyFriendApp.Base.Pages;
using MyFriendApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFriendApp.Pages
{
    public class ScanQRCodePage : BaseContentPage
    {
        public ScanQRCodePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ScanQRCodePageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new ScanQRCodePageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new ScanQRCodePagePortrait();
        }
    }
}
