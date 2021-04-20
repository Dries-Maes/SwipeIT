using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class RecruiterRepo : IDataStore<Recruiter>
    {
        private static RecruiterRepo instance;

        private List<Recruiter> recruiters { get; set; }

        private RecruiterRepo()
        {
            AddDummyData();
        }

        public static RecruiterRepo GetSingleton()
        {
            if (instance == null)
            {
                instance = new RecruiterRepo();
            }
            return instance;
        }

        public List<Recruiter> GetRecruiter()
        {
            return recruiters;
        }

        public async Task<bool> AddItemAsync(Recruiter item)
        {
            recruiters.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Recruiter> GetItemAsync(int id)
        {
            return await Task.FromResult(recruiters.FirstOrDefault(s => s.ID == id));
        }

        public Task<IEnumerable<Recruiter>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Recruiter item)
        {
            Recruiter oldItem = recruiters.FirstOrDefault(x => x == item);
            recruiters.Remove(oldItem);
            recruiters.Add(item);

            return await Task.FromResult(true);
        }

        private void AddDummyData()
        {
            recruiters = new List<Recruiter>
            {
                new Recruiter
                {
                    ID = 1,
                    LastName = "Jef",
                    FirstName = "Besos",
                    Company = "Bamazon",
                },
                new Recruiter
                {
                    ID = 2,
                    LastName = "Billy",
                    FirstName = "Gates",
                    Company = "Licrosoft",
                },
                new Recruiter
                {
                    ID = 3,
                    LastName = "Stefaan",
                    FirstName = "Jops",
                    Company = "Bapple",
                },
                new Recruiter
                {
                    ID = 4,
                    LastName = "Meloen",
                    FirstName = "Musk",
                    Company = "Teslaa",
                },
            };
        }

        public Task<Recruiter> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}