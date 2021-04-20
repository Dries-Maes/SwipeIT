using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class DateLog
    {
        private DateTime dateCreated;

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set
            {
                dateCreated = value;
            }
        }

        private DateTime dateModified;

        public DateTime DateModified
        {
            get { return dateModified; }
            set
            {
                dateModified = value;
            }
        }

        public DateLog()
        {
            DateCreated = DateTime.Now;
        }
    }
}