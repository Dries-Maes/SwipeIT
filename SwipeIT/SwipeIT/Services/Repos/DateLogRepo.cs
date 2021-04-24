using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services.Repos
{
    internal class DateLogRepo : GenericRepo<DateLog>
    {
        public async Task<List<DateLog>> GetLast10DateLogs()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.DateLogs.Include(x => x.Account)
                                               .Include(x => x.Skill)
                                               .OrderByDescending(x => x.DateModified)
                                               .Take(10)
                                               .ToListAsync();
            }
        }
    }
}