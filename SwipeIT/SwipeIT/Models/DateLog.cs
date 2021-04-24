using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwipeIT.Models
{
    [Owned]
    public class DateLog
    {
        [Key]
        public int DateLogId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public DateLog()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            Account = new Account();
        }
    }
}