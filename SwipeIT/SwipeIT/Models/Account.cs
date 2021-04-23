using SwipeIT.Services;

namespace SwipeIT.Models
{
    public abstract class Account : ObservableObject
    {
        private int id;

        public int ID
        {
            get => id;
            set
            {
                id = value;
            }
        }

        private string email;

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