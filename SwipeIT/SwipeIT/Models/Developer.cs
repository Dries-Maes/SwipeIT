using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Developer : User
    {
        public string Address { get; set; }
        public List<Recruiter> LikedByRecruiters { get; set; }

        public Developer()
        {
            Role = Role.Developer;
            LikedByRecruiters = new List<Recruiter>();
        }
    }
}