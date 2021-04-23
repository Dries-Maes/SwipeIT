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

        private ICollection<Recruiter> recruiters;

        public ICollection<Recruiter> Recruiters
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