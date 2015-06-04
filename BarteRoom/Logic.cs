using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data;



namespace BarteRoom
{
    public class Logic
    {
        private DB data;
        private LinkedList<Item> itemList;
        private DataTable dtable;
        public Logic() {

        }

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
        public int SignUp(String usr, String first, String password, String confirm, String email)
        {
            int j = 0;
            String First = "";

            foreach (char i in first)
            {
                if (j == 0 && !Char.IsUpper(i))
                {
                    First += Char.ToUpper(i).ToString();
                }
                else
                {
                    if (j != 0 && Char.IsUpper(i))
                    {
                        First += Char.ToLower(i).ToString();
                    }
                    else
                        First += i;
                }

                j++;
            }
          
   
            String fullName = First;

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

        public void sendEmail(String usr, String first, String sub, String msg, int flag)
        {
            String email = "barterroom@gmail.com";
            String message = msg;
            String fullName;

            if (flag == 0)
            {
                message = "Message from: " + first + "\n\n" + msg;
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

        public String getName(String usr)
        {
            String fullname;
            String[] name;
            data = new DB();

            fullname = data.getFullName(usr);
            name = fullname.Split(' ');

            return name[0];
        }

        public bool isExist(String usr)
        {
            data = new DB();

            return data.isExists(usr); 
        }
/*
        public void uploadPic(string usr, byte[] image)
        {
          data = new DB();
           data.uploadPic(usr, image);
        }
        */
     //   public LinkedList<Item> fillUsrItemList(String usr)
     //   {
     //       data = new DB();

      //      return data.fillUsrItemList(usr);
      //  }
        public void addItem(Item item)
        {
            data = new DB();
            data.addItem(item);

        }
        public void removeItem(String id)
        {
            data = new DB();
            data.removeItem(id);

        }
        public void editItem(String name, String comments, String description, String id)
        {
            data = new DB();
            data.editItem(name,comments,description,id);

        }
        public DataTable getDataSourceForUsr(String usr)
        {
            data = new DB();
            return data.getDataSourceForUsr(usr);
        }

        public DataTable getDataSourceForItemsByChoice(int whichItems, string name, string clas)
        {
            data = new DB();
            return data.getDataSourceForItemsByChoice(whichItems, name,clas);
        }
        public int numOf(int user_manager)
        {
            data = new DB();

            if (user_manager == 1)
            {
                return data.numOf(1);
            }

            else if(user_manager == 0)
            {
                return data.numOf(0);
            }

            return -1;
        }

        public void addImage(string id, string path)
        {
            data = new DB();
            data.addImage(id, path);
        }

        public string setImagePath(String id)
        {
             data = new DB();
             return data.setImagePath(id);
        }


        ///transaction section
        public void addTransaction(Transaction transaction)
        {
            data = new DB();
            data.addTransaction(transaction);
        }

        public DataTable getDataSourceForSearch(string search, String catagory)
        {
            data = new DB();
            return data.getDataSourceForSearch(search, catagory);
        }

        public int numOfResults(String search, String catagory)
        {
            data = new DB();
            return data.numOfResults(search, catagory);
        }
        public DataTable getDataSourceForBids(string usr)
        {
            data = new DB();
            return data.getDataSourceForBids(usr);
        }

    }
}