using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Recruiter : User
    {
        public string Company { get; set; }
        public List<Developer> LikedDevelopers { get; set; }
    }
}