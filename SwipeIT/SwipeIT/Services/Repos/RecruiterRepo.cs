using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services.TESTDbRepos
{
    public class RecruiterRepo : IGenericRepo<Recruiter>
    {
        public async Task<bool> AddItemAsync(Recruiter recruiter)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                if (recruiter.ID == 0)
                {
                    await dbContext.AddAsync(recruiter);
                }
                else
                {
                    dbContext.Update(recruiter);
                }
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AddItemsAsync(IEnumerable<Recruiter> recruiters)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.AddRange(recruiters);
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

        public async Task<List<Recruiter>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Recruiters.Include(x => x.Developers)
                                                .Include(x => x.Skills)
                                                .Include(x => x.AvailableLocations)
                                                 .ToListAsync();
            }
        }

        public async Task<Recruiter> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Recruiters.Include(x => x.Developers)
                    .Include(x => x.Skills)
                    .Include(x => x.AvailableLocations)
                                                 .FirstOrDefaultAsync(x => x.ID == id);
            }
        }
    }
}