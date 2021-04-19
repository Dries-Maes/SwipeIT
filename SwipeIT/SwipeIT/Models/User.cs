using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class User : Account
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<String> MyProperty { get; set; }
        public int YearsOfExperience { get; set; }
        public List<Skill> Skills { get; set; }
    }
}