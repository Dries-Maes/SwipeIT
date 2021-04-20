using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class DateLogs
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}