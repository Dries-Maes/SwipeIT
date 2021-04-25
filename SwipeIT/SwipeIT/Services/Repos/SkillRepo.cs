using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class SkillRepo : GenericRepo<Skill>
    {
        public async Task<List<Skill>> GetAllUserCreatedSkillsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Skills.Where(x => x.IsCreatedByUser == true)
                                             .ToListAsync();
            }
        }
    }
}