using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFriendApp.Models
{
    public class UserInfo
    {
        [PrimaryKey]
        public string Account { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserInfo()
        {
        }
        public UserInfo(string userName, string email, string account, string password)
        {
            this.Account = account;
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }
    }
}
