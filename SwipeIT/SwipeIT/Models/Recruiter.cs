using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Recruiter : User
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public List<Developer> LikedDevelopers { get; set; }
    }
}
