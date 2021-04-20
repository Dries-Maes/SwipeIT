using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SwipeIT.Services
{
    public class CurrentUserSingleton
    {
        private static CurrentUserSingleton instance;
        public Account CurrentUser { get; set; }

        private CurrentUserSingleton()
        {
            CurrentUser = new Recruiter
            {
                FirstName = "Pieter",
                Email = "Pieter@pietercorp.org",
                Image = "Icon27.png"
            };
        }

        public static CurrentUserSingleton GetSingleton()
        {
            if (instance == null)
            {
                instance = new CurrentUserSingleton();
            }
            return instance;
        }
    }
}