using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class Account : ObservableObject
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

        private Role role;

        public Role Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private DateLog dateLog;

        public DateLog DateLog
        {
            get { return dateLog; }
            set { dateLog = value; }
        }

        public Account()
        {
            DateLog = new DateLog();
        }
    }
}