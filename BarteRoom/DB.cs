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
/*
        public LinkedList<Item> fillUsrItemList(String usr)
        {
            LinkedList<Item> all_Items = new LinkedList<Item>();

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
                Item item;
                if (rdr[5] == System.DBNull.Value)
                    item = new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), null);
                else
                    item = new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), (byte[])rdr[5]);


                all_Items.AddLast(item);
            }

            connect.Close();

            return all_Items;
        }

*/


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
                query = "insert into transactions values('" + transaction.getTransaction_id() + "','" + transaction.getItem_id() + "','" + transaction.getType()+ "','" +transaction.getUser()+"','"+transaction.getComments()+  "');";
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

        public DataTable getDataSourceForSearch(string search)
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



            query = "select * from items where ([name] LIKE '%'+'" + search + "'+'%');";

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



    }


}