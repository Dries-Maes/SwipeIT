using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class AdminRepo : IDataStore<Admin>
    {
        private static AdminRepo instance;
        private List<Admin> admins { get; set; }

        private AdminRepo()
        {
            AddDummyData();
        }

        public static AdminRepo GetSingleton()
        {
            return instance ?? (instance = new AdminRepo());
        }

        public List<Admin> GetAdmins()
        {
            return admins;
        }

        public async Task<bool> AddItemAsync(Admin item)
        {
            admins.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetItemAsync(int id)
        {
            return await Task.FromResult(admins.FirstOrDefault(s => s.ID == id));
        }

        public Task<IEnumerable<Admin>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Admin item)
        {
            Admin oldItem = admins.FirstOrDefault(x => x == item);
            admins.Remove(oldItem);
            admins.Add(item);

            return await Task.FromResult(true);
        }

        public Task<Admin> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        private void AddDummyData()
        {
            admins = new List<Admin>
            {
                new Admin
                {
                    Email = "admin",
                    Password = "admin",
                },
            };
        }
    }
}