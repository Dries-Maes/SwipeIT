using SwipeIT.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //[ForeignKey("DateLogId")]
        //public DateLog DateLog { get; set; }

        public Skill()
        {
            //DateLog = new DateLog();
        }
    }
}