using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class GenericRepo<T> : IGenericRepo<T> where T : ObservableObject
    {
        public virtual async Task<bool> AddItemAsync(T item)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.Update(item);
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public virtual async Task<bool> AddItemsAsync(IEnumerable<T> items)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.AddRange(items);
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                var item = await GetItemAsync(id);
                dbContext.Remove(item);
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<Account>> GetAllAcountsAsync()
        {
            List<Account> results = new List<Account>();

            using (var dbContext = new SwipeITDBContext())
            {
                results.AddRange(await dbContext.Set<Admin>().ToListAsync());
                results.AddRange(await dbContext.Set<Developer>().ToListAsync());
                results.AddRange(await dbContext.Set<Recruiter>().ToListAsync());
            }
            return results;
        }

        public virtual async Task<List<T>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Set<T>().ToListAsync();
            }
        }

        public virtual async Task<T> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.FindAsync<T>(id);
            }
        }
    }
}