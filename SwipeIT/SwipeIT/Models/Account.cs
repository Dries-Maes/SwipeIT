using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class Account : DateLogs
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

        public Account()
        {
            DateCreated = DateTime.Now;
        }
    }
}