using System;
using System.Collections.Generic;
using System.Text;
using SwipeIT.Services;

namespace SwipeIT.Models
{
    public class Skill : ObservableObject
    {
        public int ID { get; set; }

        private string skillName;

        public string SkillName
        {
            get => skillName;
            set
            {
                skillName = value;
                OnPropertyChanged(nameof(SkillName));
            }
        }

        private bool isCreatedByUser;

        public bool IsCreatedByUser
        {
            get => isCreatedByUser;
            set
            {
                isCreatedByUser = value;
                OnPropertyChanged(nameof(IsCreatedByUser));
            }
        }

        private DateLog dateLog;

        public DateLog DateLog
        {
            get => dateLog;
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