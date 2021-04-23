using System.Collections.Generic;
using System.Collections.ObjectModel;

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