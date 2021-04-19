﻿using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SwipeIT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public List<Developer> DevelopersResult { get; }

        public MainViewModel()
        {
            DevelopersResult = new List<Developer>();
            GetMockData();
        }

        private void GetMockData()
        {
            throw new NotImplementedException();
        }
    }
}