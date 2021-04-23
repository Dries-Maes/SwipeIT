using System;
using System.Collections.Generic;
using System.Text;

namespace SwipeIT.Models
{
    public class Province
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string locationName;

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
    }
}