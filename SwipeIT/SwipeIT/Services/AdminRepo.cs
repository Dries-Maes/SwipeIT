using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class AdminRepo : IDataStore<Admin>
    {
        public Task<Admin> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Admin>.AddItemAsync(Admin item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Admin>.DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Admin> IDataStore<Admin>.GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Admin>> IDataStore<Admin>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Admin>.UpdateItemAsync(Admin item)
        {
            throw new NotImplementedException();
        }
    }
}