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

        private List<Recruiter> likedByRecruiters;

        public List<Recruiter> LikedByRecruiters
        {
            get => likedByRecruiters;
            set
            {
                likedByRecruiters = value;
                OnPropertyChanged(nameof(OnPropertyChanged));
            }
        }

        public Developer()
        {
            Role = Role.Developer;
            LikedByRecruiters = new List<Recruiter>();
        }
    }
}