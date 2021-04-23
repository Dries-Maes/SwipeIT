using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Services.TESTDbRepos
{
    public class SkillRepo : IGenericRepo<Skill>
    {
        public async Task<bool> AddItemAsync(Skill skill)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                if (skill.ID == 0)
                {
                    await dbContext.AddAsync(skill);
                }
                else
                {
                    dbContext.Update(skill);
                }
                await dbContext.SaveChangesAsync();
            }
            return true;
        }

        public Task<bool> AddItemsAsync(IEnumerable<Skill> item)
        {
            throw new NotImplementedException();
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

        public async Task<List<Skill>> GetAllItemsAsync()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Skills.ToListAsync();
            }
        }

        public async Task<Skill> GetItemAsync(int id)
        {
            using (var dbContext = new SwipeITDBContext())
            {
                return await dbContext.Skills.FindAsync(id);
            }
        }
    }
}