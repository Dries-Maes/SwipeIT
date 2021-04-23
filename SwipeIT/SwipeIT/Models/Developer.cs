using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        private List<Recruiter> likedByRecruiters;

        [NotMapped]
        public List<Recruiter> LikedByRecruiters
        {
            get => likedByRecruiters;
            set
            {
                likedByRecruiters = value;
                OnPropertyChanged(nameof(OnPropertyChanged));
            }
        }

        private ObservableCollection<Like> likes;

        public ObservableCollection<Like> Likes
        {
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged(nameof(Likes));
            }
        }

        public Developer()
        {
            LikedByRecruiters = new List<Recruiter>();
            Likes = new ObservableCollection<Like>();
        }
    }
}