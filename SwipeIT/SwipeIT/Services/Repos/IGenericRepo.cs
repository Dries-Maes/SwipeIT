using SwipeIT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public interface IGenericRepo<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> AddItemsAsync(IEnumerable<T> item);

        Task<bool> UpdateItemsAsync(IEnumerable<T> items);

        Task<bool> DeleteItemAsync(int id);

        Task<List<T>> GetAllItemsAsync();

        Task<T> GetItemAsync(int id);
    }
}