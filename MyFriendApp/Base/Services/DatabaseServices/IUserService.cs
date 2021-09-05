using MyFriendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFriendApp.Base.Services.DatabaseServices
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(UserInfo user);
        Task UpdateUserAsync(UserInfo user);
        Task<bool> DeleteUserAsync(string account);
        Task<UserInfo> GetUserAsync(string account);
    }
}
