using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services.TESTDbRepos
{
    public class DeveloperRepo : GenericRepo<Developer>, IGenericRepo<Developer>
    {
        public override async Task<List<Developer>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Developers.Include(x => x.Skills)
                                                 .Include(x => x.AvailableLocations)
                                                 .Include(x => x.Recruiters)
                                                 .Include(x => x.DateLog)
                                                 .ToListAsync();
            }
        }

        public override async Task<Developer> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Developers.Include(x => x.Skills)
                                                 .Include(x => x.AvailableLocations)
                                                 .Include(x => x.Recruiters)
                                                 .Include(x => x.DateLog)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}