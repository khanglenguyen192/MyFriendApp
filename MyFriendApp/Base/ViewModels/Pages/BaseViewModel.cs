using MyFriendApp.Base.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFriendApp.Base.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public INavigationService _navigationService { get; }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
