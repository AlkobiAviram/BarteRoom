using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BarteRoom
{
    public class User
    {
        private String usr;
        private String password;
        private String fullName;
        private String email;
        private int manager;
        public User(String usr)
        {
            this.usr=usr;
        }
        public User(String usr, String password, String fullName, String email, int manager)
        {
            this.usr = usr;
            this.password = password;
            this.fullName = fullName;
            this.email = email;
            this.manager = manager;
        
         
        }

        public string Usr
        {
            get { return this.usr; }
            set { this.usr = value; }
        }
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        
        public int Manager
        {
            get { return this.manager; }
            set { this.manager = value; }
        }
        
    }
}