using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsingApi.Models;

namespace UsingApi.Utils
{
    public class UtilsLocalDatabase
    {
        public static async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            users = await App.Database.GetAllAsync<UserModel>();
            return users;

        }
        public static async Task DeleteUsers()
        {         
             await App.Database.DeleteItemAsync<UserModel>();          

        }

        public static async Task<UserModel> GetUserById(int id)
        {
            return await App.Database.GetItemAsync<UserModel>(id.ToString());
        }
    }
}
