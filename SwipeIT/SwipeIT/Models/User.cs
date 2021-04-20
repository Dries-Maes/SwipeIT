using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class User : Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public int YearsOfExperience { get; set; }
        public List<Skill> Skills { get; set; }
        public List<String> Locations { get; set; }

        public User()
        {
            Skills = new List<Skill>();
            Locations = new List<string>();
        }
    }
}