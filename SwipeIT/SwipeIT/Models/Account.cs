using SwipeIT.Services;
using System.ComponentModel.DataAnnotations;

namespace SwipeIT.Models
{
    public abstract class Account : ObservableObject
    {
        private int id;

        public int Id
        {
            get => id;
            set
            {
                id = value;
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

        private DateLog dateLog;

        public DateLog DateLog
        {
            get => dateLog;
            set => dateLog = value;
        }

        public Account()
        {
            DateLog = new DateLog();
        }
    }
}