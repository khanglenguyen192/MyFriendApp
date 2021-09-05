using MyFriendApp.Base.Services;
using MyFriendApp.Base.Services.DatabaseServices;
using MyFriendApp.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFriendApp
{
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; } = new ViewNavigationService();

        private static IUserService _userService;
        public static IUserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = new SQLiteUserService(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDB"));
                }
                return _userService;
            }
        }

        public App()
        {
            InitializeComponent();
            NavigationService.Register(nameof(LoginPage), typeof(LoginPage));
            NavigationService.Register(nameof(SignUpPage), typeof(SignUpPage));
            NavigationService.Register(nameof(HomePage), typeof(HomePage));
            MainPage = ((ViewNavigationService)NavigationService).SetRootPage(nameof(LoginPage));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
