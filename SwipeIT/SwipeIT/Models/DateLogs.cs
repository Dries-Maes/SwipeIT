using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class DateLogs : ObservableObject
    {
        private DateTime dateCreated;

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set
            {
                dateCreated = value;
                OnPropertyChanged(nameof(DateCreated));
            }
        }

        private DateTime dateModified;

        public DateTime DateModified
        {
            get { return dateModified; }
            set
            {
                dateModified = value;
                OnPropertyChanged(nameof(DateModified));
            }
        }
    }
}