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
        public string getUser()
        {
            return this.usr;
        }
        public string getFullName()
        {
            return this.fullName;
        }
        public string getEmail()
        {
            return this.email;
        }
        public int getManager()
        {
            return this.manager;
        }
    }
}