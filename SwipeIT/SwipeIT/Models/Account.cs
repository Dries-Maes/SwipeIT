using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public abstract class Account : DateLogs
    {
        public int ID { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Account()
        {
            DateCreated = DateTime.Now;
        }
    }
}