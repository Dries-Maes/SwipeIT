using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class DeveloperDbRepo : IGenericRepo<Developer>
    {
        public async Task<bool> AddItemAsync(Developer developer)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                if (developer.ID == 0)
                {
                    await dbContext.AddAsync(developer);
                }
                else
                {
                    dbContext.Update(developer);
                }
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AddItemsAsync(IEnumerable<Developer> developers)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.AddRange(developers);
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

        public async Task<List<Developer>> GetAllItemsAsync()
        {
            //using (var dbContext = new SwipeITDBContext())
            //{
            //    return await dbContext.Developers.ToListAsync();
            //}
            throw new NotImplementedException();
        }

        public async Task<Developer> GetItemAsync(int id)
        {
            //using (var dbContext = new SwipeITDBContext())
            //{
            //    return await dbContext.Developers.FindAsync(id);
            //}
            throw new NotImplementedException();
        }
    }
}