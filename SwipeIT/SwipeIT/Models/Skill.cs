using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Skill : DateLogs
    {
        private int id;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        private string skillName;

        public string SkillName
        {
            get { return skillName; }
            set
            {
                skillName = value;
                OnPropertyChanged(nameof(SkillName));
            }
        }

        private bool isCreatedByUser;

        public bool IsCreatedByUser
        {
            get { return isCreatedByUser; }
            set
            {
                isCreatedByUser = value;
                OnPropertyChanged(nameof(IsCreatedByUser));
            }
        }

        public Skill()
        {
            DateCreated = DateTime.Now;
        }
    }
}