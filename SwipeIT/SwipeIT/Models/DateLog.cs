using SwipeIT.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwipeIT.Models
{
    public class DateLog : ObservableObject
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        //[ForeignKey("Id")]
        //public Account Account { get; set; }

        public DateLog()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}