using System;

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