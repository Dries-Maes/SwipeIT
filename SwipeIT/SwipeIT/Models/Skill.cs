using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Skill()
        {
            DateCreated = DateTime.Now;
        }
    }
}