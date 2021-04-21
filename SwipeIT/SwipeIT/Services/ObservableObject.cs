﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace SwipeIT.Services
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged(string propertyName)
        {

            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }
        }
    }
}