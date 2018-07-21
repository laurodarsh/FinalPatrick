﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPatrick.Classes
{
    public class User
    {

        private int id;
        private string name;
        private string password;
        private string email;
        private UserProfile userProfile;
        private bool active;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        internal UserProfile UserProfile
        {
            get
            {
                return userProfile;
            }

            set
            {
                userProfile = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        //    public int Id { get => id; set => id = value; }
        //    public string Name { get => name; set => name = value; }
        //    public string Password { get => password; set => password = value; }
        //    public string Email { get => email; set => email = value; }
        //    public UserProfile UserProfile { get => userProfile; set => userProfile = value; }
        //    public bool Active { get => active; set => active = value; }
        //
        public User(string name, string password, string email,UserProfile user, bool active )
        {

            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.UserProfile = userProfile;
            this.Active = active;


        }
        public User()
        {
        }

    }
}