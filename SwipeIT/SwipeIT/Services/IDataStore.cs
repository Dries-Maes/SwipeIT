using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(int id);

        Task<T> GetItemAsync(int id);

        Task<T> GetAllItemsAsync();

        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}