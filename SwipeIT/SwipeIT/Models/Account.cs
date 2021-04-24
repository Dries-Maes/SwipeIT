using SwipeIT.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwipeIT.Models
{
    public class Account : ObservableObject
    {
        private int accountId;

        [Required]
        [Key]
        public int AccountId
        {
            get => accountId;
            set
            {
                accountId = value;
            }
        }

        private string email;

        [Required]
        [MaxLength(100)]
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        private string password;

        [Required]
        [MaxLength(50)]
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        [ForeignKey("DateLogId")]
        public DateLog DateLog { get; set; }

        public Account()
        {
            DateLog = new DateLog();
        }
    }
}