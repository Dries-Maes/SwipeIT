using System;
using System.ComponentModel.DataAnnotations;

namespace SwipeIT.Models
{
    public class DateLog
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        public DateLog()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}