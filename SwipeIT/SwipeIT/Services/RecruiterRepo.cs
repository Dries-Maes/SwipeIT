using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //AddDummyData();
        }

        public static RecruiterRepo GetSingleton()
        {
            return instance ?? (instance = new RecruiterRepo());
        }

        public List<Recruiter> GetRecruiters()
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

        //private void AddDummyData()
        //{
        //    recruiters = new List<Recruiter>
        //    {
        //        new Recruiter
        //        {
        //            ID = 1,
        //            FirstName = "test",
        //            LastName = "test",
        //            Company = "test",
        //            Email = "test",
        //            Password = "test",
        //            Locations = new ObservableCollection<Location>
        //            {
        //                Location.Antwerpen,
        //                Location.VlaamsBrabant,
        //                Location.Henegouwen,
        //            },
        //        },
        //        new Recruiter
        //        {
        //            ID = 1,
        //           FirstName = "Jef",
        //            LastName = "Besos",
        //            Company = "Bamazon",
        //            Email = "jef@bamazon.com",
        //            Password = "B3505",
        //            Skills = new ObservableCollection<Skill>
        //            {
        //                new Skill
        //                {
        //                    SkillName="C#"
        //                },
        //            },
        //             Locations = new ObservableCollection<Location>
        //            {
        //                Location.Antwerpen,
        //                Location.VlaamsBrabant,
        //                Location.Henegouwen,
        //            },
        //        },
        //        new Recruiter
        //        {
        //            ID = 2,
        //            FirstName = "Billy",
        //            LastName = "Gates",
        //            Company = "Licrosoft",
        //            Email ="billygates@licrosoft.org",
        //            Password ="BgL003!?",
        //            Skills = new ObservableCollection<Skill>
        //            {
        //                new Skill
        //                {
        //                    SkillName="C#"
        //                },
        //            },
        //             Locations = new ObservableCollection<Location>
        //            {
        //                Location.Antwerpen,
        //                Location.VlaamsBrabant,
        //                Location.Henegouwen,
        //            },
        //        },
        //        new Recruiter
        //        {
        //            ID = 3,
        //            FirstName = "Stefaan",
        //            LastName = "Jops",
        //            Company = "Bapple",
        //            Email = "stefjops@bapple.io",
        //            Password = "Peer4TheWin",
        //            Skills = new ObservableCollection<Skill>
        //            {
        //                new Skill
        //                {
        //                    SkillName="C#"
        //                },
        //            },
        //             Locations = new ObservableCollection<Location>
        //            {
        //                Location.Antwerpen,
        //                Location.VlaamsBrabant,
        //                Location.Henegouwen,
        //            },
        //        },
        //        new Recruiter
        //        {
        //            ID = 4,
        //            FirstName = "Meloen",
        //            LastName = "Musk",
        //            Company = "Teslaa",
        //            Email ="muskmeloen@teslaa.be",
        //            Password ="Model3XS",
        //            Skills = new ObservableCollection<Skill>
        //            {
        //                new Skill
        //                {
        //                    SkillName="C#"
        //                },
        //            },
        //             Locations = new ObservableCollection<Location>
        //            {
        //                Location.Antwerpen,
        //                Location.VlaamsBrabant,
        //                Location.Henegouwen,
        //            },
        //        },
        //    };
        //}

        public Task<Recruiter> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}