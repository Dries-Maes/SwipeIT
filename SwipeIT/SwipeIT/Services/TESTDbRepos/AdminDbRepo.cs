using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services.TESTDbRepos
{
    public class AdminDbRepo : IGenericRepo<Admin>
    {
        public async Task<bool> AddItemAsync(Admin admin)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                if (admin.ID == 0)
                {
                    await dbContext.AddAsync(admin);
                }
                else
                {
                    dbContext.Update(admin);
                }
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AddItemsAsync(IEnumerable<Admin> admins)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.AddRange(admins);
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

        public async Task<List<Admin>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Admins.ToListAsync();
            }
        }

        public async Task<Admin> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Admins.FindAsync(id);
            }
        }
    }
}