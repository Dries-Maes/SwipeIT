using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class DateLog
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateLog()
        {
            DateCreated = DateTime.Now;
        }
    }
}