using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFriendApp.ViewModels
{
    public class ScanQRCodePageViewModel : BaseViewModel
    {
        public ScanQRCodePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
