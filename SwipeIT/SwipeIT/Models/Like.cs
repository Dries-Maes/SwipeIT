using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SwipeIT.Models
{
    public class Like
    {
        public int ID { get; set; }

        public Developer Developer { get; set; }
        public int DeveloperID { get; set; }

        public Recruiter Recruiter { get; set; }
        public int RecruiterID { get; set; }
    }
}