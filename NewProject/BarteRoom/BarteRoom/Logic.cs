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
    }
}