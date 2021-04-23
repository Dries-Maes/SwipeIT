using System.Collections.Generic;

namespace SwipeIT.Models
{
    public class Developer : User
    {
        private string address;

        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private List<Recruiter> recruiters;

        public List<Recruiter> Recruiters
        {
            get => recruiters;
            set
            {
                recruiters = value;
                OnPropertyChanged(nameof(OnPropertyChanged));
            }
        }

        public Developer()
        {
            Recruiters = new List<Recruiter>();
        }
    }
}