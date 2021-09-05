using System;
using System.Collections.Generic;
using System.Text;

namespace MyFriendApp.Models
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public Account()
        {

        }

        public Account(string fullName, string email, string userName, string password)
        {
            UserName = userName;
            Password = password;
            FullName = fullName;
            Email = email;
        }
    }
}
