using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwipeIT.Models
{
    public class Recruiter : User
    {
        private string company;

        public string Company
        {
            get => company;
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        [NotMapped]
        private ObservableCollection<Developer> selectedDevelopers;

        [NotMapped]
        public ObservableCollection<Developer> SelectedDevelopers
        {
            get => selectedDevelopers;
            set
            {
                selectedDevelopers = value;
                OnPropertyChanged(nameof(SelectedDevelopers));
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

        public Recruiter()
        {
            SelectedDevelopers = new ObservableCollection<Developer>();
            Likes = new ObservableCollection<Like>();
        }
    }
}