using SwipeIT.Services;
using System.ComponentModel.DataAnnotations;

namespace SwipeIT.Models
{
    public class Skill : ObservableObject
    {
        public int Id { get; set; }

        private string skillName;

        [MaxLength(50)]
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