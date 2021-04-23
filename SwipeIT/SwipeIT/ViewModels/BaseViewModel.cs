using SwipeIT.Models;
using SwipeIT.Services;
using SwipeIT.Services.TESTDbRepos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SwipeIT.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public CurrentUserSingleton CurrentUserSingleton { get; set; }

        public IGenericRepo<Developer> DeveloperRepo = new DeveloperRepo();
        public IGenericRepo<Recruiter> RecruiterRepo = new RecruiterRepo();
        public IGenericRepo<Skill> SkillsRepo = new GenericRepo<Skill>();
        public IGenericRepo<Admin> AdminRepo = new GenericRepo<Admin>();
        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        private bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string title = string.Empty;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public BaseViewModel()
        {
            CurrentUserSingleton = CurrentUserSingleton.GetSingleton();
        }

        internal void DeleteDb()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.DeleteDb();
            }
        }

        public async void AddDummyData()
        {
            List<Developer> temp = new List<Developer>
            {
                new Developer
                {
                    LastName = "Van Gelder",
                    FirstName = "Jens",
                    Image = "Icon15.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                        new Skill
                        {
                            SkillName="Google"
                        },
                        new Skill
                        {
                            SkillName=".NET"
                        },
                        new Skill
                        {
                            SkillName="Javascript"
                        },
                    },
                    AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen },
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Luik},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email ="jens.v.gelder@gmail.com",
                    Password ="DoNotDrag0n!",
                    Address = "Haacht neerstraat",
                },
                new Developer
                {
                    LastName = "Maes",
                    FirstName = "Dries",
                    Image = "Icon03.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen },
                    },
                    Email="dm.inbox@outlook.com",
                    Password ="P1ssM30ff"
                },
                new Developer
                {
                    LastName = "Impe",
                    FirstName = "Ward",
                    Image = "Icon07.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email="ward@impesoft.com",
                    Password ="pass"
                },
                new Developer
                {
                    LastName = "Kesteloot",
                    FirstName = "Sebastiaan-Willem",
                    Image = "Icon05.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email ="seba.kesteloot@gmail.com",
                    Password="r00t"
                },
                new Developer
                {
                    LastName = "Van Tittelboom",
                    FirstName = "Simon",
                    Image = "Icon06.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email="simon.van.tittelboom@gmail.com",
                    Password ="R00T2.0"
                },
                new Developer
                {
                    LastName = "Alfvoet",
                    FirstName = "Joyce",
                    Image = "Icon08.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email ="joyce.alfvoet@gmail.com",
                    Password = "Recruit#MeToo"
                },
                new Developer
                {
                    LastName = "DeLobelle",
                    FirstName = "Kobe",
                    Image = "Icon10.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email = "delobellekobe@gmail.com",
                    Password ="IkWeetGeenPaswoordmeer"
                },
                new Developer
                {
                    LastName = "Danckaert",
                    FirstName = "Emma",
                    Image = "Icon11.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email="emmadanckaert@hotmail.com",
                    Password = "DriesHeeftAltijdGelijk"
                },
                new Developer
                {
                    LastName = "Stavropoulos",
                    FirstName = "Andreas",
                    Image = "Icon12.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email="anstavropoulos@gmail.com",
                    Password= "Gr33c3"
                },
                new Developer
                {
                    LastName = "Van Durme",
                    FirstName = "Pieter",
                    Image = "Icon18.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email = "pieter_van_durme@hotmail.com",
                    Password ="Fr1tuur"
                },
                new Developer
                {
                    LastName = "Van Royen",
                    FirstName = "Nick",
                    Image = "Icon19.png",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                    Email ="nvanroyen@gmail.com",
                    Password = "ILoveTinder"
                },
            };
            await DeveloperRepo.AddItemsAsync(temp);

            var recruiters = new List<Recruiter>
            {
                new Recruiter
                {
                    FirstName = "test",
                    LastName = "test",
                    Company = "test",
                    Email = "test",
                    Password = "test",
                    AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                },
                new Recruiter
                {
                   FirstName = "Jef",
                    LastName = "Besos",
                    Company = "Bamazon",
                    Email = "jef@bamazon.com",
                    Password = "B3505",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                },
                new Recruiter
                {
                    FirstName = "Billy",
                    LastName = "Gates",
                    Company = "Licrosoft",
                    Email ="billygates@licrosoft.org",
                    Password ="BgL003!?",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                },
                new Recruiter
                {
                    FirstName = "Stefaan",
                    LastName = "Jops",
                    Company = "Bapple",
                    Email = "stefjops@bapple.io",
                    Password = "Peer4TheWin",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                },
                new Recruiter
                {
                    FirstName = "Meloen",
                    LastName = "Musk",
                    Company = "Teslaa",
                    Email ="muskmeloen@teslaa.be",
                    Password ="Model3XS",
                    Skills = new ObservableCollection<Skill>
                    {
                        new Skill
                        {
                            SkillName="C#"
                        },
                    },
                     AvailableLocations = new ObservableCollection<AvailableLocation>
                    {
                        new AvailableLocation{Province = Province.Antwerpen},
                        new AvailableLocation{Province = Province.VlaamsBrabant},
                        new AvailableLocation{Province = Province.Henegouwen},
                    },
                },
            };
            await RecruiterRepo.AddItemsAsync(recruiters);

            var admins = new List<Admin>
            {
                new Admin
                {
                    Email = "admin",
                    Password = "admin",
                },
            };
            await AdminRepo.AddItemsAsync(admins);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}