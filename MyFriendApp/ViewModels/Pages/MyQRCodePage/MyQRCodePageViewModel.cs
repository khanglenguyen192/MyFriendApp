using MyFriendApp.Base.Services;
using MyFriendApp.Base.ViewModels;
using MyFriendApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFriendApp.ViewModels
{
    public class MyQRCodePageViewModel : BaseViewModel
    {
        public Account _account { get; set; }
        public string MyAccount { get; set; }
        public MyQRCodePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _account = new Account("Le Van B", "lvb@gmail.com", "lvb123", "b123456");
            MyAccount = JsonConvert.SerializeObject(_account);
        }

    }
}
