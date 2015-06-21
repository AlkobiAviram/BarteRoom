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
            //connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectToDb"].ConnectionString);
            connect = new SqlConnection("Data Source=dorejhld9m.database.windows.net;Initial Catalog=barteroomdb;Integrated Security=False;User ID=gabaynati;Password=NatiGabay1;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }


        /*
         * adding new user to the Database
         * if the adding fails from some resion return false
         * if the adding success return true
        */
        public bool addNewUser(String usr, String password, String fullName, String email, int manager)
        {
            query = "insert into dbo.Users values('" + usr + "','" + password + "','" + fullName + "','" + email + "'," + manager + ");";

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

                query = "select COUNT(*) from dbo.users where usr = '" + usr + "';";
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
            query = "select fullName from dbo.users where usr = '" + usr + "';";

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
            query = "select password from dbo.users where usr = '" + usr + "';";

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

     


        //return the E-mail of the correct user
        public string getEmail(string usr)
        {
            string email = "";
            query = "select email from dbo.users where usr = '" + usr + "';";

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

                query = "select COUNT(*) from dbo.users where usr = '" + usr + "' AND manager = 1;";
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


            if (whichItems == 0)
                query = "select * from dbo.items;";
            else
                query = "select * from dbo.items where name='" + name + "' and " + "class='" + clas + "'";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "", "", "" };
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



            query = "select * from dbo.items where usr = '" + usr + "';";

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
        public DataTable getImagesOfItem(string item_id)
        {
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Images");
         
       

          
                query = "select i.path from dbo.images i where i.item_id='"+item_id+"';";
           

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }
            int i = 1;
            while (rdr.Read())
            {
                if (i == 1)
                {
                    dtable.Columns.Add(dt);
                    i--;
                }
                object[] RowValues = {""};
                RowValues[0] = rdr[0].ToString();
              
                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();

            }

            connect.Close();
            return dtable;
        }

        public int numOfImages(string item_id)
        {
            int images = 0;

            query = "select COUNT(*) from dbo.images where item_id ='" + item_id+ "';";

            try
            {
                connect.Open();


                command = new SqlCommand(query, connect);

               images = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            return images;
        }

        public string setImagePath(String id)
        {
            string path = "";
            query = "select path from dbo.images where item_id = '" + id + "' and isProfile=1;";

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

            query = "insert into dbo.items values('" + item.Usr + "','" + item.Name + "','" + item.Clss + "','" + item.Comments + "','" + item.Description + "','" + item.Id + "');";


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

        public void addImage(Imag img)
        {
            query = "insert into dbo.images values('" + img.Item_id + "','" + img.Path + "','" + img.Image_id + "'," + img.IsProfile + ");";
            /*
             //removing the picture from the folder
             string completePath = System.Web.HttpContext.Current.Server.MapPath("~/" + setImagePath(item_id));
             if (System.IO.File.Exists(completePath))
             {

                 System.IO.File.Delete(completePath);

             }
             string[] split = setImagePath(item_id).Split('/');
           
             completePath = System.Web.HttpContext.Current.Server.MapPath("~/img/OriginalSize_" + split[1]);
             if (System.IO.File.Exists(completePath))
             {

                 System.IO.File.Delete(completePath);

             }


             */
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception ex) { }
        }


        public bool removeItem(String id)
        {
            //removing the picture from the folder
            string completePath = System.Web.HttpContext.Current.Server.MapPath("~/" + setImagePath(id));
            if (System.IO.File.Exists(completePath))
            {

                System.IO.File.Delete(completePath);

            }
            string[] split = setImagePath(id).Split('/');
            completePath = System.Web.HttpContext.Current.Server.MapPath("~/img/OriginalSize_" + split[1]);
            if (System.IO.File.Exists(completePath))
            {

                System.IO.File.Delete(completePath);

            }




            try
            {
                if(connect.State==ConnectionState.Closed)
                connect.Open();
                query = "DELETE FROM dbo.items WHERE id='" + id + "';";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                query = "DELETE FROM dbo.images WHERE item_id='" + id + "';";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                connect.Close();
            }

            catch (Exception e) { return false; }


            return true;
        }


        public bool editItem(String name, String comments, String description, String id)
        {
            query = "UPDATE dbo.items "
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
                query = "select COUNT(*) from dbo.users where manager = 1;";
            }

            else if (user_manager == 0)
            {
                query = "select COUNT(*) from dbo.users where manager = 0;";
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
                query = "insert into dbo.transactions values('" + transaction.Transaction_id + "','" + transaction.Item_id + "','" + transaction.Owner + "','" + transaction.Bidder + "','" + transaction.Comments + "', 0,'" + transaction.Date + "');";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();

                //insert to transactionItems table
                query = "";
                foreach (string item_id in transaction.OfferdItemsList)
                {
                    Guid newGuid = Guid.NewGuid();

                    query += "insert into dbo.transactionItems values('" + transaction.Transaction_id + "','" + item_id + "','" + newGuid.ToString() + "');";

                }
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { return false; }
            return true;

        }

        /*
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
        <<<<<<< HEAD
                */
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
                query = "select * from dbo.items where ([name] LIKE '%'+'" + search + "'+'%') AND (usr != '" + usr + "') order by Id;";
            }

            else
            {
                query = "select * from dbo.items where ([name] LIKE '%'+'" + search + "'+'%')  AND (usr != '" + usr + "') AND ([class] = '" + catagory + "') order by Id;";
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
                query = "select count(*) from dbo.items where ([name] LIKE '%'+'" + search + "'+'%')  AND (usr != '" + usr + "');";
            }

            else
            {
                query = "select count(*) from dbo.items where ([name] LIKE '%'+'" + search + "'+'%')  AND (usr != '" + usr + "') AND ([class] = '" + catagory + "');";
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

        public DataTable getDataSourceForBidsOrOffers(string usr, string BidOrOffer)
        {

            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Bid ID");
            DataColumn dt1 = new DataColumn("Item BarCode");
            DataColumn dt2 = new DataColumn("Item Image");
            DataColumn dt3;
            if (BidOrOffer.Equals("bid"))
                dt3 = new DataColumn("Item Owner");
            else
                dt3 = new DataColumn("Bidder");
            DataColumn dt4 = new DataColumn("Comments");
            DataColumn dt5 = new DataColumn("Seen");
            DataColumn dt6 = new DataColumn("Date Created");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);
            dtable.Columns.Add(dt5);
            dtable.Columns.Add(dt6);
            //getting only the bid id and the item id
            if (BidOrOffer == "bid")
                query = "select t.id,t.item_id,t.owner,t.comments,t.readBid ,t.datetime from dbo.transactions t where t.bidder='" + usr + "';";
            else
                query = "select t.id,t.item_id,t.bidder,t.comments,t.readBid,t.datetime from dbo.transactions t where t.owner='" + usr + "';";
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "", "" ,"",""};
                RowValues[0] = rdr[0].ToString();
                RowValues[1] = rdr[1].ToString();
                RowValues[2] = rdr[1].ToString();
                RowValues[3] = rdr[2].ToString();
                RowValues[4] = rdr[3].ToString();
                if (Convert.ToInt32(rdr[4].ToString()) == 1)
                    RowValues[5] = "yes";
                else
                    RowValues[5] = "no";
                RowValues[6] = rdr[5].ToString();
                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }


            connect.Close();
            //setting image url
            foreach (DataRow row in dtable.Rows)
            {
                row[2] = setImagePath(row[2].ToString());
            }
            return dtable;
        }


        private string getUsrByItemId(string item_id)
        {
            string usr = "";
            //now getting the usr field of the item owner.
            query = "select i.usr from dbo.items i where i.id='" + item_id + "';";
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
            }

            connect.Close();

            return usr;

        }
        public Item getItemById(string item_id)
        {
            string usr = "";
            string name = "";
            string clas = "";
            string comments = "";
            string description = "";
            query = "select * from dbo.items  where id='" + item_id + "';";
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
                clas = rdr[2].ToString();
                comments = rdr[3].ToString();
                description = rdr[4].ToString();
            }

            connect.Close();

            Item item = new Item(usr, name, clas, comments, description);
            return item;
        }


        public LinkedList<Item> getAllItems()
        {
            LinkedList<Item> items = new LinkedList<Item>();



            //getting only the bid id and the item id
            query = "select * from dbo.items;";

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
                itm.Id=rdr[5].ToString();
                items.AddLast(itm);


            }





            connect.Close();

            return items;
        }


        public LinkedList<Imag> getAllImages()
        {
            LinkedList<Imag> images = new LinkedList<Imag>();



            query = "select * from dbo.images;";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();
            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                Imag img = new Imag(rdr[0].ToString(), rdr[1].ToString(), Convert.ToInt32(rdr[3].ToString()));
                img.Image_id=rdr[2].ToString();
                images.AddLast(img);
            }





            connect.Close();

            return images;
        }
        public string getIdByImagePath(string path)
        {

            string item_id="";
            //getting only the bid id and the item id
            query = "select item_id from dbo.images where path='"+path+"';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();
            }

            catch (Exception e) { }

            while (rdr.Read())
            {
             item_id=rdr[0].ToString();
            }





            connect.Close();

            return item_id;
        
        }

        public void deleteClass(string className)
        {
            query = "DELETE FROM dbo.classes WHERE cls_name = '" + className + "';";

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

            query = "select COUNT(*) from dbo.items i, dbo.transactions t where i.Id = t.item_id AND (i.usr = '" + usr + "') AND (t.readBid = 0);";

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

        public DataTable getAllBids(string usr)
        {

            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("Image");
            DataColumn dt1 = new DataColumn("Comments");
            DataColumn dt2 = new DataColumn("id");
            DataColumn dt3 = new DataColumn("Datetime");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);

            query = "select img.path, t.bidder, t.id, t.datetime, t.readBid from dbo.images img, dbo.transactions t, dbo.items i where (img.item_id = i.Id) AND (i.Id = t.item_id) AND (i.usr = '" + usr + "') order by t.readBid,datetime DESC;";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }

            while (rdr.Read())
            {
                object[] RowValues = { "", "", "", "" };
                RowValues[0] = rdr[0].ToString();

                if(Convert.ToInt32(rdr[4].ToString()) == 0)
                {
                RowValues[1] = "You have a new BID from " + rdr[1].ToString();
                }
                else
                {
                    RowValues[1] = "Already read BID from user " + rdr[1].ToString();
                }
                RowValues[2] = rdr[2].ToString();

                string[] tmp = rdr[3].ToString().Split(' ');
                RowValues[3] = tmp[0] + " at " + tmp[1];

                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();

            return dtable;
        }

        public void MarkAsRead(string usr)
        {
            query = "UPDATE dbo.transactions SET readBid = 1 WHERE readBid IN (select t.readBid from dbo.transactions t where (t.owner = '" + usr + "') AND (t.readBid = 0));";

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
            string item_id;
            string owner;
            string bidder;
            string comments;
            int readBid;

            LinkedList<string> offerdItemsList = new LinkedList<string>();

            //getting the item list:
            query = "select item_id from dbo.transactionItems where transaction_id='" + id + "';";
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }
            while (rdr.Read())
            {
                offerdItemsList.AddLast(rdr[0].ToString());
            }



            connect.Close();
            query = "select * from dbo.transactions where id='" + id + "';";
            Transaction trsct = null;
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }


            catch (Exception e)
            {
            }
            if (rdr.Read())
            {

                item_id = rdr[1].ToString();
                owner = rdr[2].ToString();
                bidder = rdr[3].ToString();
                comments = rdr[4].ToString();
                readBid = Convert.ToInt32(rdr[5].ToString());
                trsct = new Transaction(item_id, owner, bidder, offerdItemsList, comments);
                trsct.Transaction_id=rdr[0].ToString();
                trsct.ReadBid=readBid;
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


            LinkedList<string> offeredItems = trns.OfferdItemsList;
            query = "select * from dbo.items where id =";
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


            query = "select * from dbo.users where usr='" + user + "';";
            User tempUser = null;

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) { }
            if (rdr.Read())
            {
                tempUser = new User(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), Convert.ToInt16(rdr[4].ToString()));
            }



            connect.Close();

            return tempUser;
        }

        public void removeTransaction(string bid_id)
        {

            query = "DELETE FROM dbo.transactions WHERE id = '" + bid_id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();


            }
            catch (Exception e) { }
            connect.Close();
            query = "DELETE FROM dbo.transactionsItems WHERE id = '" + bid_id + "';";

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

        public void readIndex(string id)
        {
            query = "UPDATE dbo.transactions SET readBid = 1 WHERE id = '" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();


            }
            catch (Exception e) { }
        }






        ////////////////////////////////////////////////////////////////////////////
        //this section is related to messages


        public void addMessage(Message msg, string dt, int flag)
        {
            if (flag == 0)
            {
                query = "insert into dbo.msg values('" + msg.Id + "','" + msg.From + "','" + msg.To + "','" + msg.Subject + "','" + msg.Msg_body + "', 0, '" + dt + "', 0, 0);";
            }

            else if(flag == 1)
            {
                query = "insert into dbo.msg values('" + msg.Id + "','" + msg.From + "','" + msg.To + "','" + msg.Subject + "','" + msg.Msg_body + "', 0, '" + dt + "', 1, 0);";
            }

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }

            if (flag == 0)
            {
                query = "insert into dbo.sentmsg values('" + msg.Id + "','" + msg.From + "','" + msg.To + "','" + msg.Subject + "','" + msg.Msg_body + "','" + dt + "');";

                try
                {
                    connect.Open();

                    command = new SqlCommand(query, connect);

                    command.ExecuteNonQuery();
                    connect.Close();
                }

                catch (Exception e) { }
            }
        }


        public DataTable getAllMessages(string usr, int flag)
        {
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("From");
            DataColumn dt1 = new DataColumn("Subject");
            DataColumn dt2 = new DataColumn("Msg");
            DataColumn dt3 = new DataColumn("Datetime");
            DataColumn dt4 = new DataColumn("Id");
            DataColumn dt5 = new DataColumn("IsRead");
            DataColumn dt6 = new DataColumn("IsStar");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);
            dtable.Columns.Add(dt5);
            dtable.Columns.Add(dt6);

            if (flag == 0)
            {
                query = "select DISTINCT fromUsr, subject, msg_body, datetime, Id, isRead from dbo.msg where toUsr = '" + usr + "' order by  isRead, datetime DESC;";
            }

            else if (flag == 1)
            {
                query = "select fromUsr, subject, msg_body, datetime, Id, isRead, star from dbo.msg where toUsr = '" + usr + "' order by  isRead, datetime DESC;";
            }
            else if (flag == 2)
            {
                query = "select fromUsr, subject, msg_body, datetime, Id, isRead, star from dbo.msg where Id = '" + usr + "' order by  isRead, datetime DESC;";
            }
            else if (flag == 3)
            {
                query = "select fromUsr, subject, msg_body, datetime, Id, isRead, star from dbo.msg where toUsr = '" + usr + "' AND(star = 1) order by  isRead, datetime DESC;";
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
                object[] RowValues = { "", "", "", "", "", "", "" };


                RowValues[0] = rdr[0].ToString();

                String tmpSub = rdr[1].ToString();

                if (tmpSub.Length > 7)
                {
                    tmpSub = tmpSub.Substring(0, 7) + "...";
                }

                if (flag == 1)
                {
                    tmpSub += "-";
                }
                RowValues[1] = tmpSub;
                
                String tmpMsg = rdr[2].ToString();

                if (tmpMsg.Length > 60 && flag == 0)
                {
                    tmpMsg = tmpMsg.Substring(0, 60) + "...";
                }

                RowValues[2] = tmpMsg;

                string[] tmp = rdr[3].ToString().Split(' ');
                RowValues[3] = tmp[0] + " at " + tmp[1];
                RowValues[4] = rdr[4].ToString();
                RowValues[5] = rdr[5].ToString();

                if (flag == 3 || flag == 1)
                {
                    RowValues[6] = rdr[6].ToString();
                }

                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();

            }

            connect.Close();

            return dtable;
        }

        public DataTable getAllDrafts(string usr)
        {
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("To");
            DataColumn dt1 = new DataColumn("Subject");
            DataColumn dt2 = new DataColumn("Msg");
            DataColumn dt3 = new DataColumn("Datetime");
            DataColumn dt4 = new DataColumn("Id");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);


            query = "select toUsr, subject, msg_body, datetime, Id from dbo.msg where fromUsr = '" + usr + "' AND (draft = 1) order by  isRead, datetime DESC;";
            
            
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

                RowValues[0] = rdr[0].ToString();

                String tmpSub = rdr[1].ToString();

                if (tmpSub.Length > 7)
                {
                    tmpSub = tmpSub.Substring(0, 7) + "...";
                }

                RowValues[1] = tmpSub;

                String tmpMsg = rdr[2].ToString();

                RowValues[2] = tmpMsg;

                string[] tmp = rdr[3].ToString().Split(' ');
                RowValues[3] = tmp[0] + " at " + tmp[1];
                RowValues[4] = rdr[4].ToString();

                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();

            }

            connect.Close();

            return dtable;
        }

        public DataTable getAllSentMessages(string usr)
        {
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("To");
            DataColumn dt1 = new DataColumn("Subject");
            DataColumn dt2 = new DataColumn("Msg");
            DataColumn dt3 = new DataColumn("Datetime");
            DataColumn dt4 = new DataColumn("Id");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);

            query = "select toUsr, subject, msg_body, datetime, Id from dbo.sentmsg where fromUsr = '" + usr + "' order by datetime DESC;";
            
            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);
                rdr = command.ExecuteReader();


            }

            catch (Exception e) {  }

            
            while (rdr.Read())
            {

                object[] RowValues = { "", "", "", "", "" };

                RowValues[0] = rdr[0].ToString();

                String tmpSub = rdr[1].ToString();

                if (tmpSub.Length > 7)
                {
                    tmpSub = tmpSub.Substring(0, 7) + "...";
                }

                tmpSub += "-";
                
                RowValues[1] = tmpSub;

                RowValues[2] = rdr[2].ToString();

                string[] tmp = rdr[3].ToString().Split(' ');
                RowValues[3] = tmp[0] + " at " + tmp[1];
                RowValues[4] = rdr[4].ToString();

                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();

            return dtable;
        }

        public int notReadMsg(string usr)
        {
            int bids = 0;

            query = "select COUNT(*) from dbo.msg where toUsr = '" + usr + "' AND (isRead = 0);";

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

        public string getPass(string usr)
        {
            string pass = "";
            query = "select password from dbo.users where usr = '" + usr + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                pass = command.ExecuteScalar().ToString();
                connect.Close();
            }

            catch (Exception e) { }

            return pass;
        }

        public bool isEmailExists(string email)
        {
            int tmp = 0;

            try
            {
                connect.Open();

                query = "select COUNT(*) from dbo.users where email = '" + email + "';";
                command = new SqlCommand(query, connect);

                tmp = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();
            }

            catch (Exception e) { }

            if (tmp >= 1)
                return true;

            else
                return false;
        }

        public string getUserByEmail(string email)
        {
            string user = "";
            query = "select usr from dbo.users where email = '" + email + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                user = command.ExecuteScalar().ToString();
                connect.Close();
            }

            catch (Exception e) { }

            return user;
        }

        public void msgMarkAsRead(string usr)
        {
            query = "UPDATE dbo.msg SET isRead = 1 WHERE isRead = 0;";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public string getMsgById(string id)
        {
            string msgID = "";
            query = "select msg_body from dbo.msg where Id = '" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                msgID = command.ExecuteScalar().ToString();
                connect.Close();
            }

            catch (Exception e) { }

            return msgID;
        }

        public void deleteMsg(string id)
        {
            query = "DELETE FROM dbo.msg WHERE Id='" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public void deleteSentMsg(string id)
        {
            query = "DELETE FROM dbo.sentmsg WHERE Id='" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public void markAsStar(string id)
        {
            query = "UPDATE dbo.msg SET star = 1 WHERE Id='" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public void markAsnotStar(string id)
        {
            query = "UPDATE dbo.msg SET star = 0 WHERE Id='" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public void setMsgAsRead(string id)
        {
            query = "UPDATE dbo.msg SET isRead = 1 WHERE Id='" + id + "';";

            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { }
        }

        public bool isMsgExists(string id)
        {
            int tmp = 0;

            try
            {
                connect.Open();

                query = "select COUNT(*) from dbo.msg where Id = '" + id + "';";
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

        public DataTable getSentMessage(string id)
        {
            DataTable dtable = new DataTable();
            DataColumn dt = new DataColumn("To");
            DataColumn dt1 = new DataColumn("Subject");
            DataColumn dt2 = new DataColumn("Msg");
            DataColumn dt3 = new DataColumn("Datetime");
            DataColumn dt4 = new DataColumn("Id");

            dtable.Columns.Add(dt);
            dtable.Columns.Add(dt1);
            dtable.Columns.Add(dt2);
            dtable.Columns.Add(dt3);
            dtable.Columns.Add(dt4);

            query = "select toUsr, subject, msg_body, datetime, Id from dbo.sentmsg where Id = '" + id + "' order by datetime DESC;";

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

                RowValues[0] = rdr[0].ToString();

                String tmpSub = rdr[1].ToString();

                RowValues[1] = tmpSub;

                RowValues[2] = rdr[2].ToString();

                string[] tmp = rdr[3].ToString().Split(' ');
                RowValues[3] = tmp[0] + " at " + tmp[1];
                RowValues[4] = rdr[4].ToString();

                DataRow dRow;
                dRow = dtable.Rows.Add(RowValues);
                dtable.AcceptChanges();
            }

            connect.Close();

            return dtable;
        }

    }


}