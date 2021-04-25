using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SwipeIT.Models
{
    public class Recruiter : User
    {
        private string company;

        [MaxLength(75)]
        public string Company
        {
            get => company;
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        private ICollection<Developer> developers;

        public ICollection<Developer> Developers
        {
            get => developers;
            set
            {
                developers = value;
                OnPropertyChanged(nameof(Developers));
            }
        }

        public Recruiter()
        {
            Developers = new ObservableCollection<Developer>();
        }
    }
}