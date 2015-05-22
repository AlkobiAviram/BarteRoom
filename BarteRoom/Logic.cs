using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace BarteRoom
{
    public class Logic
    {
        private DB data;

        public Logic() { }

        public bool Login(String usr, String pass)
        {

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
        public int SignUp(String usr, String first, String last, String password, String confirm, String email)
        {

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

        public bool isManager(String usr)
        {
            data = new DB();

            if (data.isManager(usr))
                return true;

            else
                return false;
        }

        public void sendEmail(String usr, String first, String last, String sub, String msg, int flag)
        {
            String email = "barterroom@gmail.com";
            String message = msg;
            String fullName;

            if (flag == 0)
            {
                message = "Message from: " + first + " " + last + "\n\n" + msg;
            }

            else if (flag == 1)
            {
                data = new DB();
                fullName = data.getFullName(usr);
                message = "Message from: " + fullName + ", User Name: " + usr + "\n\n" + msg;
            }

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("barterroom@gmail.com", "barterroom123");
            MailMessage mail = new MailMessage("barterroom@gmail.com", email, sub, message);

            smtp.Send(mail);
        }
    }
}