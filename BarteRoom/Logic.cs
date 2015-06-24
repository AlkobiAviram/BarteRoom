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

        public void sendEmail(String Email, String usr, String first, String sub, String msg, int flag)
        {
            String email = "barterroom@gmail.com";
            String message = msg;
            String fullName;

            //contact message from guest
            if (flag == 0)
            {
                message = "Message from: " + first + "\n\n" + msg;
            }

            //contact message from register user
            else if (flag == 1)
            {
                data = new DB();
                fullName = data.getFullName(usr);
                message = "Message from: " + fullName + ", User Name: " + usr + "\n\n" + msg;
            }

            //forgot password message
            else if (flag == 2)
            {
                email = Email;
                message = "Hello " + first + "\n" + "Your password to User Name " + usr + " account in Barteroom is: " + msg + ".";
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

        public string getEmail(string usr)
        {
            data = new DB();
            return data.getEmail(usr);
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
        public DataTable getAllSubCategory(string main_category)
        {
            data = new DB();
            return data.getAllSubCategory(main_category);
        }
        public LinkedList<string> getAllMainCategories()
        {
            data = new DB();
            return data.getAllMainCategories();
        }
        public void addImage(Imag img)
        {
            data = new DB();
            data.addImage(img);
        }
        public int numOfImages(string item_id)
        {

            data = new DB();
            return data.numOfImages(item_id);
        }
        public string setImagePath(String id)
        {
             data = new DB();
             return data.setImagePath(id);
        }
       

        ///transaction section
        ///
        public string getBidIdByBidderOrOwner(string item_id, string usr, string type)
        {
            data = new DB();
            return data.getBidIdByBidderOrOwner(item_id, usr, type);
        }

        public void addTransaction(Transaction transaction)
        {
            data = new DB();
            data.addTransaction(transaction);
        }
        public Boolean isItemAlreadyBiddedByUsrOrOfferedToUsr(string item_id, string usr, string type)
        {
            data = new DB();
            return data.isItemAlreadyBiddedByUsrOrOfferedToUsr(item_id, usr, type);
        }
        public DataTable getDataSourceForSearch(String usr, String search, String catagory)
        {
            data = new DB();
            return data.getDataSourceForSearch(usr, search, catagory);
        }

        public int numOfResults(String usr, String search, String catagory)
        {
            data = new DB();
            return data.numOfResults(usr, search, catagory);
        }
        public DataTable getDataSourceForBidsOrOffers(string usr, string bidOrOffer)
        {
            data = new DB();
            return data.getDataSourceForBidsOrOffers(usr,bidOrOffer);
        }
        public Item getItemById(string item_id)
        {
            data = new DB();
            return data.getItemById(item_id);
        }


        public LinkedList<Item> getAllItems()
        {
            data = new DB();
            return data.getAllItems();
        }
        public LinkedList<Imag> getAllImages()
        {
            data = new DB();
            return data.getAllImages();
        }
        public string getIdByImagePath(string path)
        {
            data = new DB();
            return data.getIdByImagePath(path);
        }

        public void deleteClass(string className)
        {
            data = new DB();
            data.deleteClass(className);
        }

        public int notReadNotes(string usr)
        {
            data = new DB();
            return data.notReadNotes(usr);
        }

        public DataTable getAllNotes(string usr)
        {
            data = new DB();
            return data.getAllNotes(usr);
        }

        public void MarkAsRead(string usr)
        {
            data = new DB();
            data.MarkAsRead(usr);
        }
        public Transaction getTransactionById(string id)
        {
            data = new DB();
            return data.getTransactionById(id);
        }
        public DataTable getDataSourceForBiddedItems(Transaction trns)
        {
            data = new DB();
            return data.getDataSourceForBiddedItems(trns);
        }
        public User getUserInformation(string user)
        {
            data = new DB();
            return data.getUserInformation(user);
        }
        public void removeTransaction(string bid_id)
        {
            data = new DB();
            data.removeTransaction(bid_id);
        }

        public void readIndex(string id)
        {
            data = new DB();
            data.readIndex(id);
        }

        public DataTable getAllMessages(string usr, int flag)
        {
            data = new DB();
            return data.getAllMessages(usr, flag);
        }

        public void addMessage(Message msg, int flag)
        {
            DateTime dt = DateTime.Now;
            string newDatetimeFormat = changeDateFormat(dt.ToString());

            data = new DB();

            data.addMessage(msg, newDatetimeFormat, flag);
        }

        public int notReadMsg(string usr)
        {
            data = new DB();
            return data.notReadMsg(usr);
        }

        public static string changeDateFormat(string dt)
        {
            string[] date = dt.Split(' ');

            string[] tmp = date[0].Split('/');

            string newFormat = tmp[2] + "-" + tmp[1] + "-" + tmp[0] + " " + date[1];

            return newFormat;
        }

        public string getPass(string usr)
        {
            data = new DB();
            return data.getPass(usr);
        }

        public bool isEmailExists(string email)
        {
            data = new DB();
            return data.isEmailExists(email);
        }

        public string getUserByEmail(string email)
        {
            data = new DB();
            return data.getUserByEmail(email);
        }

        public void msgMarkAsRead(string usr)
        {
            data = new DB();
            data.msgMarkAsRead(usr);
        }
        public DataTable getImagesOfItem(string item_id)
        {
            data = new DB();
            return data.getImagesOfItem(item_id);
        }

        public string getMsgById(string id)
        {
            data = new DB();
            return data.getMsgById(id);
        }

        public DataTable getAllSentMessages(string usr)
        {
            data = new DB();
            return data.getAllSentMessages(usr);
        }

        public void deleteMsg(string id)
        {
            data = new DB();
            data.deleteMsg(id);
        }

        public void deleteSentMsg(string id)
        {
            data = new DB();
            data.deleteSentMsg(id);
        }

        public void markAsStar(string id)
        {
            data = new DB();
            data.markAsStar(id);
        }

        public void setMsgAsRead(string id)
        {
            data = new DB();
            data.setMsgAsRead(id);
        }

        public DataTable getAllDrafts(string usr)
        {
            data = new DB();
            return data.getAllDrafts(usr);
        }

        public bool isMsgExists(string id)
        {
            data = new DB();
            return data.isMsgExists(id);
        }

        public DataTable getSentMessage(string id)
        {
            data = new DB();
            return data.getSentMessage(id);
        }

        public void markAsnotStar(string id)
        {
            data = new DB();
            data.markAsnotStar(id);
        }



        /////////////////////////////////////////////////////////
        //regarding most viewed items
        public void AddView(string item_id)
        {
            data = new DB();
            data.AddView(item_id);
        }
        public DataTable getDataSourceForMostViewedItems()
        {
            data = new DB();
            return data.getDataSourceForMostViewedItems();
        }
    }
}