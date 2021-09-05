using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using MyFriendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFriendApp.ViewModels
{
    public class MyQRCodePageViewModel : BaseViewModel
    {
        public Account MyAccount { get; set; }
        public MyQRCodePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            MyAccount = new Account("Khang Le", "khang.lenguyen192@gmail.com", "khang192", "123456");
        }

    }
}
