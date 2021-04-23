using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class GenericRepo<T> : IGenericRepo<T> where T : ObservableObject
    {
        public async Task<bool> AddItemAsync(T item)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.Update(item);
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AddItemsAsync(IEnumerable<T> items)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.AddRange(items);
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                var item = await GetItemAsync(id);
                dbContext.Remove(item);
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<T>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.FindAsync<T>(id);
            }
        }
    }
}