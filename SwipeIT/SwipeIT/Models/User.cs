using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class User : Account
    {
        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private int yearsOfExperience;

        public int YearsOfExperience
        {
            get { return yearsOfExperience; }
            set
            {
                yearsOfExperience = value;
                OnPropertyChanged(nameof(yearsOfExperience));
            }
        }

        private List<Skill> skills;

        public List<Skill> Skills
        {
            get { return skills; }
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        private List<string> locations;

        public List<string> Locations
        {
            get { return locations; }
            set
            {
                locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        public User()
        {
            Skills = new List<Skill>();
            Locations = new List<string>();
        }
    }
}