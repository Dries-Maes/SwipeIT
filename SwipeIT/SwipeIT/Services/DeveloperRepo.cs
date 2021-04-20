using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Services
{
    public class DeveloperRepo : IDataStore<Developer>
    {
        private static DeveloperRepo instance;

        private DeveloperRepo()
        {
            AddDummyData();
        }

        private List<Developer> developers { get; set; }

        public static DeveloperRepo GetSingleton()
        {
            if (instance == null)
            {
                instance = new DeveloperRepo();
            }
            return instance;
        }

        public List<Developer> GetDevelopers()
        {
            return developers;
        }

        public async Task<bool> AddItemAsync(Developer item)
        {
            developers.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Developer> GetItemAsync(int id)
        {
            return await Task.FromResult(developers.FirstOrDefault(s => s.ID == id));
        }

        public Task<IEnumerable<Developer>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Developer item)
        {
            Developer oldItem = developers.FirstOrDefault(x => x == item);
            developers.Remove(oldItem);
            developers.Add(item);

            return await Task.FromResult(true);
        }

        private void AddDummyData()
        {
            developers = new List<Developer>
            {
                new Developer
                {
                    ID = 420,
                    LastName = "Van Gelder",
                    FirstName = "Jens",
                    Image = "Icon15.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email ="jens.v.gelder@gmail.com",
                    Password ="DoNotDrag0n!"
                },
                new Developer
                {
                    ID = 1,
                    LastName = "Maes",
                    FirstName = "Dries",
                    Image = "Icon03.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email="dm.inbox@outlook.com",
                    Password ="P1ssM30ff"
                },
                new Developer
                {
                    ID = 2,
                    LastName = "Impe",
                    FirstName = "Ward",
                    Image = "Icon07.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email="ward@impesoft.com",
                    Password ="pass"
                },
                new Developer
                {
                    ID = 3,
                    LastName = "Kesteloot",
                    FirstName = "Sebastiaan-Willem",
                    Image = "Icon05.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email ="seba.kesteloot@gmail.com",
                    Password="r00t"
                },
                new Developer
                {
                    ID = 4,
                    LastName = "Van Tittelboom",
                    FirstName = "Simon",
                    Image = "Icon06.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email="simon.van.tittelboom@gmail.com",
                    Password ="R00T2.0"
                },
                new Developer
                {
                    ID = 5,
                    LastName = "Alfvoet",
                    FirstName = "Joyce",
                    Image = "Icon08.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email ="joyce.alfvoet@gmail.com",
                    Password = "Recruit#MeToo"
                },
                new Developer
                {
                    ID = 6,
                    LastName = "DeLobelle",
                    FirstName = "Kobe",
                    Image = "Icon10.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email = "delobellekobe@gmail.com",
                    Password ="IkWeetGeenPaswoordmeer"
                },
                new Developer
                {
                    ID = 7,
                    LastName = "Danckaert",
                    FirstName = "Emma",
                    Image = "Icon11.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email="emmadanckaert@hotmail.com",
                    Password = "DriesHeeftAltijdGelijk"
                },
                new Developer
                {
                    ID = 8,
                    LastName = "Stavropoulos",
                    FirstName = "Andreas",
                    Image = "Icon12.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email="anstavropoulos@gmail.com",
                    Password= "Gr33c3"
                },
                new Developer
                {
                    ID = 9,
                    LastName = "Van Durme",
                    FirstName = "Pieter",
                    Image = "Icon18.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email = "pieter_van_durme@hotmail.com",
                    Password ="Fr1tuur"
                },
                new Developer
                {
                    ID = 10,
                    LastName = "Van Royen",
                    FirstName = "Nick",
                    Image = "Icon19.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                    Email ="nvanroyen@gmail.com",
                    Password = "ILoveTinder"
                },
                new Developer
                {
                    ID = 11,
                    LastName = "Van Yperzele",
                    FirstName = "Diederick",
                    Image = "Icon20.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                },
                new Developer
                {
                    ID = 12,
                    LastName = "Verhulsdonck",
                    FirstName = "Marieke",
                    Image = "Icon22.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="Communication"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                },
                new Developer
                {
                    ID = 13,
                    LastName = "Wouters",
                    FirstName = "Michiel",
                    Image = "Icon24.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     Locations = new ObservableCollection<Location>
                    {
                        Location.Antwerpen,
                        Location.VlaamsBrabant,
                        Location.Henegouwen,
                    },
                },
            };
        }

        public Task<Developer> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}