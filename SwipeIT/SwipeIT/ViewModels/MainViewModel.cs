using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SwipeIT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public List<Developer> DevelopersResult { get; set; }

        public ICommand Like { get; }

        public MainViewModel()
        {
            DevelopersResult = new List<Developer>();
            GetMockData();
        }

        private void GetMockData()
        {
            DevelopersResult = developerRepo.GetDevelopers();
        }
    }
}