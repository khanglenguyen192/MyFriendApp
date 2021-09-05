using MyFriendApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFriendApp.Base.Services.DatabaseServices
{
    public class SQLiteUserService : IUserService
    {
        private SQLiteAsyncConnection _database;

        public SQLiteUserService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserInfo>().Wait();
        }

        // Insert
        public async Task<bool> AddUserAsync(UserInfo user)
        {
            await _database.InsertAsync(user);
            return await Task.FromResult(true);
        }

        // Delete
        public async Task<bool> DeleteUserAsync(string account)
        {
            await _database.DeleteAsync<UserInfo>(account);
            return await Task.FromResult(true);
        }

        // Find User by Account
        public async Task<UserInfo> GetUserAsync(string account)
        {
            return await _database.Table<UserInfo>().FirstOrDefaultAsync(user => user.Account == account);
        }

        // Update User
        public async Task UpdateUserAsync(UserInfo user)
        {
            await _database.UpdateAsync(user);
        }
    }
}
