using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Skill : DateLogs
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public bool IsCreatedByUser { get; set; }

        public Skill()
        {
            DateCreated = DateTime.Now;
        }
    }
}