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
                Name = "Pieter",
                Email = "Pieter2"
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