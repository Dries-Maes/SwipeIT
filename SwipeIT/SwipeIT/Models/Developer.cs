using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwipeIT.Models
{
    public class Developer : User
    {
        private string address;

        [MaxLength(100)]
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