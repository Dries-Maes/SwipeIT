using SwipeIT.Models;
using System;
using System.Collections.Generic;
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
                    Name = "Van Gelder",
                    Surname = "Jens",
                    Image = "Icon15.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Haacht",
                        "Leuven",
                        "Mechelen",
                    },
                },
                new Developer
                {
                    ID = 1,
                    Name = "Maes",
                    Surname = "Dries",
                    Image = "Icon2.png",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 2,
                    Name = "Impe",
                    Surname = "Ward",
                    Image = "Icon3.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Evergem",
                    },
                },
                new Developer
                {
                    ID = 3,
                    Name = "Kesteloot",
                    Surname = "Sebastiaan-Willem",
                    Image = "Icon5.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 4,
                    Name = "Van Tittelboom",
                    Surname = "Simon",
                    Image = "Icon6.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 5,
                    Name = "Alfvoet",
                    Surname = "Joyce",
                    Image = "Icon7.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 6,
                    Name = "DeLobelle",
                    Surname = "Kobe",
                    Image = "Icon10.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 7,
                    Name = "Danckaert",
                    Surname = "Emma",
                    Image = "Icon11.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 8,
                    Name = "Stavropoulos",
                    Surname = "Andreas",
                    Image = "Icon16.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 9,
                    Name = "Van Durme",
                    Surname = "Pieter",
                    Image = "Icon14.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 10,
                    Name = "Van Royen",
                    Surname = "Nick",
                    Image = "Icon20.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 11,
                    Name = "Van Yperzele",
                    Surname = "Diederick",
                    Image = "Icon18.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Gent",
                    },
                },
                new Developer
                {
                    ID = 12,
                    Name = "Verhulsdonck",
                    Surname = "Marieke",
                    Image = "Icon4.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="Communication"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Holland",
                    },
                },
                new Developer
                {
                    ID = 13,
                    Name = "Wouters",
                    Surname = "Michiel",
                    Image = "Icon30.jpg",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                    Locations = new List<string>
                    {
                        "Limburg",
                        "Aalst",
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