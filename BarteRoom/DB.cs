using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace BarteRoom
{
    public class DB
    {
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataReader rdr;
        private string query;


        //constructor - initialize the connection to the Database
        public DB()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectToDb"].ConnectionString);
        }


        /*
         * adding new user to the Database
         * if the adding fails from some resion return false
         * if the adding success return true
        */
        public bool addNewUser(String usr, String password, String fullName, String email, int manager)
        {
            query = "insert into Users values('" + usr + "','" + password + "','" + fullName + "','" + email + "'," + manager + ");";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { return false; }

            return true;
        }

        //check if usr already exists
        public bool isExists(string usr)
        {
            int tmp = 0;

            try
            {
                connect.Open();

                query = "select COUNT(*) from users where usr = '" + usr + "';";
                command = new SqlCommand(query, connect);

                tmp = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            if (tmp == 1)
                return true;

            else
                return false;
        }


        //return the full name of a specific user 
        public String getFullName(String usr)
        {
            string Name = "";
            query = "select fullName from users where usr = '" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                Name = command.ExecuteScalar().ToString();
                connect.Close();
            }

            catch (Exception e) { }

            return Name;
        }


        /*
         *check if the password matches to the correct user
        */
        public bool loginCheck(String usr, String pass)
        {
            string password = "";
            query = "select password from users where usr = '" + usr + "';";

            try
            {
                connect.Open();


                command = new SqlCommand(query, connect);

                password = command.ExecuteScalar().ToString();
                connect.Close();
            }

            catch (Exception e) { }

            if (password.Equals(pass))
                return true;

            else
                return false;
        }
        /*
        //upload image
        public void uploadPic(string usr, byte[] image)
        {
            query = "update items set image = @IMG where usr = '" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@IMG", image);
                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception ex) { }
        }
        */

        //return the E-mail of the correct user
        public string getEmail(string usr)
        {
            string email = "";
            query = "select email from users where usr = '" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                email = Convert.ToString(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            return email;
        }

        public bool isManager(String usr)
        {
            int tmp = 0;

            try
            {
                connect.Open();

                query = "select COUNT(*) from users where usr = '" + usr + "' AND manager = 1;";
                command = new SqlCommand(query, connect);

                tmp = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            if (tmp == 1)
                return true;

            else
                return false;
        }
     


        public DataTable getDataSourceForItemsByChoice(int whichItems, string name, string clas)
        {

            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Name");
            DataColumn dt1 = new DataColumn("Comments");
            DataColumn dt2 = new DataColumn("Description");
            DataColumn dt3 = new DataColumn("Image");
            DataColumn dt4 = new DataColumn("id");
            DataColumn dt5 = new DataColumn("User");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);
            dtable.Columns.Add(dt5);


            if (whichItems==0)
            query = "select * from items;";
            else
               query = "select * from items where name='"+name+"' and "+"class='"+clas+"'";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "", "","" };
                RowValues[0] = rdr[1].ToString();
                RowValues[1] = rdr[3].ToString();
                RowValues[2] = rdr[4].ToString();
                string id = rdr[5].ToString();
                RowValues[3] = id;
                RowValues[4] = id;
                RowValues[5] = rdr[0].ToString();




                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();
            //setting image url
            foreach (DataRow row in dtable.Rows)
            {
                row[3] = setImagePath(row[3].ToString());
            }




            return dtable;

        }

        public DataTable getDataSourceForUsr(String usr)
        {

            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Name");
            DataColumn dt1 = new DataColumn("Comments");
            DataColumn dt2 = new DataColumn("Description");
            DataColumn dt3 = new DataColumn("Image");
            DataColumn dt4 = new DataColumn("id");


            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);



            query = "select * from items where usr = '" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "", "" };
                    RowValues[0] = rdr[1].ToString();
                    RowValues[1] = rdr[3].ToString();
                    RowValues[2] = rdr[4].ToString();
                    string id = rdr[5].ToString();
                    RowValues[3] = id;
                    RowValues[4] = id;
                
            
           
                
                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();
            //setting image url
            foreach (DataRow row in dtable.Rows)
            {
                row[3] = setImagePath(row[3].ToString());
            }




            return dtable;
        }


        public string setImagePath(String id)
        {
            string path = "";
            query = "select path from images where id = '" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                path = Convert.ToString(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            return path;
        }



        public bool addItem(Item item)
        {

            query = "insert into items values('" + item.getUsr() + "','" + item.getName() + "','" + item.getClass() + "','" + item.getComments() + "','" + item.getDescription() + "','" + item.getId() + "');";


            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e)
            {
                return false;
            }
            //uploadPic(item.getUsr(), item.getPic());

            return true;
        }

        public bool addImage(string id, string path)
        {
            query = "insert into images values('" + id + "','" + path + "');";



            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception e) { return false; }
            return true;

        }


        public bool removeItem(String id)
        {
            //removing the picture from the folder
            string completePath = System.Web.HttpContext.Current.Server.MapPath("~/" + setImagePath(id));
            if (System.IO.File.Exists(completePath))
            {

                System.IO.File.Delete(completePath);

            }




            try
            {
                connect.Open();
                query = "DELETE FROM items WHERE id='" + id + "';";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                query = "DELETE FROM images WHERE id='" + id + "';";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { return false; }
            
 
            return true;
        }


        public bool editItem(String name, String comments, String description, String id)
        {
            query = "UPDATE items "
                    + "SET name='" + name + "'," + "comments='" + comments + "'," + "description='" + description + "' "
                    + "WHERE id='" + id + "';";



            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { return false; }
            return true;

        }

        public int numOf(int user_manager)
        {
            int numOf = 0;

            if (user_manager == 1)
            {
                query = "select COUNT(*) from users where manager = 1;";
            }

            else if (user_manager == 0)
            {
                query = "select COUNT(*) from users where manager = 0;";
            }

            try
            {
                connect.Open();


                command = new SqlCommand(query, connect);

                numOf = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            return numOf;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //transaction section
        public bool addTransaction(Transaction transaction)
        {

            try
            {
                connect.Open();
                //insert to transaction table
                query = "insert into transactions values('" + transaction.getTransaction_id() + "','" + transaction.getItem_id() + "','" + transaction.getType()+ "','" +transaction.getUser()+"','"+transaction.getComments()+  "', 0);";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();

                //insert to transactionItems table
                query = "";
                foreach (string item_id in transaction.getOfferdItemsList())
                {
                    query += "insert into transactionItems values('" + transaction.getTransaction_id() + "','" + item_id + "');";

                }
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { return false; }
            return true;

        }


        public DataTable getDataSourceForTransaction(String usr,string transaction_type)
        {

            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Bidded Item");
            


            dtable.Columns.Add(dt);
           



            query = "select * from transactions where usr = '" + usr + "' and transaction_type='"+transaction_type+"';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "" };
                RowValues[0] = rdr[0].ToString();
              




                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();
       

            return dtable;
        }

        public DataTable getDataSourceForSearch(String usr, string search, String catagory)
        {
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Name");
            DataColumn dt1 = new DataColumn("Comments");
            DataColumn dt2 = new DataColumn("Description");
            DataColumn dt3 = new DataColumn("Image");
            DataColumn dt4 = new DataColumn("id");


            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);

            if (catagory.Equals("All Catagories"))
            {
                query = "select * from items where ([name] LIKE '%'+'" + search + "'+'%') AND (usr != '" + usr + "');";
            }

            else
            {
                query = "select * from items where ([name] LIKE '%'+'" + search + "'+'%')  AND (usr != '" + usr + "') AND ([class] = '" + catagory + "');";
            }

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "", "" };
                RowValues[0] = rdr[1].ToString();
                RowValues[1] = rdr[3].ToString();
                RowValues[2] = rdr[4].ToString();
                string id = rdr[5].ToString();
                RowValues[3] = id;
                RowValues[4] = id;




                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();
            //setting image url
            foreach (DataRow row in dtable.Rows)
            {
                row[3] = setImagePath(row[3].ToString());
            }

            return dtable;
        }




        public int numOfResults(String usr, String search, String catagory)
        {
            int numOf = 0;

            if (catagory.Equals("All Catagories"))
            {
                query = "select count(*) from items where ([name] LIKE '%'+'" + search + "'+'%')  AND (usr != '" + usr + "');";
            }

            else
            {
                query = "select count(*) from items where ([name] LIKE '%'+'" + search + "'+'%')  AND (usr != '" + usr + "') AND ([class] = '" + catagory + "');";
            }
            try
            {
                connect.Open();


                command = new SqlCommand(query, connect);

                numOf = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            return numOf;
        }

        public DataTable getDataSourceForBids(string usr)
        {
            string uuu = usr;
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Bid ID");
            DataColumn dt1 = new DataColumn("Item BarCode");
            DataColumn dt2 = new DataColumn("Item Owner");
         


            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);

            //getting only the bid id and the item id
            query = "select t.id,t.item_id from transactions t where t.usr='" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", ""};
                RowValues[0] = rdr[0].ToString();
                RowValues[1] = rdr[1].ToString();
            
                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            //getting the usr field of the utem owner
            foreach (DataRow row in dtable.Rows)
            {
                row[2] = getUsrByItemId(row[1].ToString());
            }

        


            connect.Close();
       
            return dtable;
        }

        public DataTable getDataSourceForOffers(string usr)
        {
            string uuu = usr;
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Bid ID");
            DataColumn dt1 = new DataColumn("Item BarCode");
            DataColumn dt2 = new DataColumn("Item Owner");



            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);

            //getting only the bid id and the item id
            query = "select t.id,t.item_id from transactions t where t.usr='" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "" };
                RowValues[0] = rdr[0].ToString();
                RowValues[1] = rdr[1].ToString();

                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            //getting the usr field of the utem owner
            foreach (DataRow row in dtable.Rows)
            {
                row[2] = getUsrByItemId(row[1].ToString());
            }




            connect.Close();

            return dtable;
        }



        private string getUsrByItemId(string item_id)
        {
            string usr="";
             //now getting the usr field of the item owner.
            query = "select i.usr from items i where i.id='" + item_id + "';";
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }
            if (rdr.Read())
            {
                usr= rdr[0].ToString();
            }

            connect.Close();
       
            return usr;
        
        }
        public Item getItemById(string item_id)
        {
            string usr="";
            string name = "";
            string clas = "";
            string comments = "";
            string description = "";
            query = "select * from items  where id='" + item_id + "';";
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }
            if (rdr.Read())
            {
                usr = rdr[0].ToString();
                name = rdr[1].ToString();
                clas= rdr[2].ToString();
                comments = rdr[3].ToString();
                description = rdr[4].ToString();
            }

            connect.Close();

            Item item = new Item(usr,name,clas,comments,description);
            return item;
        }


        public LinkedList<Item> getAllItems()
        {
            LinkedList<Item> items = new LinkedList<Item>();
           
          

            //getting only the bid id and the item id
            query = "select * from items;";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                Item itm = new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString());
                itm.setId(rdr[5].ToString());
                items.AddLast(itm);

              
            }

           



            connect.Close();

            return items;
        }


        public LinkedList<Imag> getAllImages()
        {
            LinkedList<Imag> images = new LinkedList<Imag>();



            //getting only the bid id and the item id
            query = "select * from images;";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
               Imag img = new Imag(rdr[0].ToString(), rdr[1].ToString());
              images.AddLast(img);


            }





            connect.Close();

            return images;
        }


        public void deleteClass(string className)
        {
            query = "DELETE FROM classes WHERE cls_name = '" + className + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public int notReadBids(string usr)
        {
            int bids = 0;

            query = "select COUNT(*) from items i, transactions t where i.Id = t.item_id AND (i.usr = '" + usr + "') AND (t.readBid = 0);";
            
            try
            {
                connect.Open();


                command = new SqlCommand(query, connect);

                bids = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            return bids;
        }

        public DataTable getAllBids(string usr) {
 
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Image");
            DataColumn dt1 = new DataColumn("Comments");
         

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);

            query = "select img.path, t.usr, t.readBid from images img, transactions t, items i where (img.id = i.Id) AND (i.Id = t.item_id) AND (i.usr = '" + usr + "') order by t.readBid DESC;";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", ""};
                RowValues[0] = rdr[0].ToString();
                RowValues[1] = "New BID from " + rdr[1].ToString(); ;
            
                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();
       
            return dtable;
    }

        public void MarkAsRead(string usr)
        {
            query = "UPDATE transactions SET readBid = 1 WHERE readBid IN (select t.readBid from transactions t, items i where (i.Id = t.item_id) AND (i.usr = 'a') AND (t.readBid = 0));";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public Transaction getTransactionById(string id)
        {
            string type;
            string comments;
            string user;
            string item_id;
            LinkedList<string> offerdItemsList=new LinkedList<string>();

            //getting the item list:
            query = "select item_id from transactionItems where transaction_id='" + id + "';";
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }
           
            catch (Exception e) { }
            while(rdr.Read())
            {          
                offerdItemsList.AddLast(rdr[0].ToString());
            }



            connect.Close();
            query = "select * from transactions where id='" + id + "';";
            Transaction trsct = null;
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }
           
    
            catch (Exception e) {
            }
            if (rdr.Read())
            {
                 
                item_id = rdr[1].ToString();
                type = rdr[2].ToString();
                user = rdr[3].ToString();
                comments = rdr[4].ToString();
                trsct = new Transaction(user, type, item_id,offerdItemsList ,comments);
                trsct.setTransaction_id(rdr[0].ToString());
            }

            connect.Close();

            return trsct;
        }



        public DataTable getDataSourceForBiddedItems(Transaction trns)
        {

            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Name");
            DataColumn dt1 = new DataColumn("Comments");
            DataColumn dt2 = new DataColumn("Description");
            DataColumn dt3 = new DataColumn("Image");
            DataColumn dt4 = new DataColumn("id");


            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);


            LinkedList<string> offeredItems = trns.getOfferdItemsList();
            query = "select * from items where id =";
            for (int i = 0; i < offeredItems.Count; i++)
            {
                query += "'" + offeredItems.ElementAt(i) + "'";
                if (i != offeredItems.Count - 1)
                    query += " or id= ";
            }
            query += ";";
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "", "" };
                RowValues[0] = rdr[1].ToString();
                RowValues[1] = rdr[3].ToString();
                RowValues[2] = rdr[4].ToString();
                string id = rdr[5].ToString();
                RowValues[3] = id;
                RowValues[4] = id;




                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();
            //setting image url
            foreach (DataRow row in dtable.Rows)
            {
                row[3] = setImagePath(row[3].ToString());
            }




            return dtable;
        }

        public User getUserInformation(string user)
        {

            
            query = "select * from users where usr='" + user + "';";
            User tempUser=null;
           
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }
           
            catch (Exception e) { }
            if(rdr.Read())
            {
                tempUser = new User(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), Convert.ToInt16(rdr[4].ToString()));
            }



            connect.Close();
           
            return tempUser;
        }

        public void removeTransaction(string bid_id)
        {
        
            query = "DELETE FROM transactions WHERE id = '" + bid_id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                

            }
            catch (Exception e) { }
            connect.Close();
            query = "DELETE FROM transactionsItems WHERE id = '" + bid_id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                

            }
            catch (Exception e) { }
            connect.Close();
            return;
        }



    }


}