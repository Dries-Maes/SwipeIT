using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class RecruiterRepo : GenericRepo<Recruiter>
    {
        public override async Task<List<Recruiter>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Recruiters.Include(x => x.Developers)
                                                 .Include(x => x.Skills)
                                                 .Include(x => x.AvailableLocations)
                                                 .Include(x => x.DateLog)
                                                 .ToListAsync();
            }
        }

        public override async Task<Recruiter> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Recruiters.Include(x => x.Developers)
                                                 .Include(x => x.Skills)
                                                 .Include(x => x.AvailableLocations)
                                                 .Include(x => x.DateLog)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}