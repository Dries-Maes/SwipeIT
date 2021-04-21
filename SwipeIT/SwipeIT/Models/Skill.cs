using System;
using System.Collections.Generic;
using System.Text;
using SwipeIT.Services;

namespace SwipeIT.Models
{
    public class Skill : ObservableObject
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

        private DateLog dateLog;

        public DateLog DateLog
        {
            get { return dateLog; }
            set
            {
                dateLog = value;
                OnPropertyChanged(nameof(DateLog));
            }
        }

        public Skill()
        {
            DateLog = new DateLog();
        }
    }
}