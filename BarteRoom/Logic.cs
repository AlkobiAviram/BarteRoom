using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Logic
    {
        private DB data;

        public Logic(){}

        public bool Login(String usr, String pass){

            data = new DB();

            if (data.loginCheck(usr, pass))
                return true;

            else
                return false;
        }

        /*
         *try to add a new user
         *if usr already exists return 1
         *if the adding failure from other resone return 2
         *else if the adding success return 0
        */
        public int SignUp(String usr, String first, String last, String password, String confirm, String email){

            String fullName = first + " " + last;
            
            data = new DB();

            if (data.isExists(usr))
            {
                return 1;
            }

            if (data.addNewUser(usr, password, fullName, email, 0))
                return 0;

            else
                return 2;
        }
    }
}