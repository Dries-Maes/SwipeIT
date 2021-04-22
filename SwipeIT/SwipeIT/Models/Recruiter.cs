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

        private ObservableCollection<Developer> selectedDevelopers;

        public ObservableCollection<Developer> SelectedDevelopers
        {
            get => selectedDevelopers;
            set
            {
                selectedDevelopers = value;
                OnPropertyChanged(nameof(SelectedDevelopers));
            }
        }

        public Recruiter()
        {
            SelectedDevelopers = new ObservableCollection<Developer>();
        }
    }
}