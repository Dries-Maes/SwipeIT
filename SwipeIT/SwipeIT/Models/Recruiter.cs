using System.Collections.Generic;

namespace SwipeIT.Models
{
    public class Recruiter : User
    {
        private string company;

        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        private List<Developer> selectedDevelopers;

        public List<Developer> SelectedDevelopers
        {
            get { return selectedDevelopers; }
            set
            {
                selectedDevelopers = value;
                OnPropertyChanged(nameof(SelectedDevelopers));
            }
        }

        public Recruiter()
        {
            Role = Role.Recruiter;
            SelectedDevelopers = new List<Developer>();
        }
    }
}