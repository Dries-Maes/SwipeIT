using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class User : Account
    {
        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string image;

        public string Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private int yearsOfExperience;

        public int YearsOfExperience
        {
            get => yearsOfExperience;
            set
            {
                yearsOfExperience = value;
                OnPropertyChanged(nameof(yearsOfExperience));
            }
        }

        private ObservableCollection<Skill> skills;

        public ObservableCollection<Skill> Skills
        {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        private ObservableCollection<Location> locations;

        public ObservableCollection<Location> Locations
        {
            get => locations;
            set
            {
                locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        public User()
        {
            Skills = new ObservableCollection<Skill>();
            Locations = new ObservableCollection<Location>();
        }
    }
}