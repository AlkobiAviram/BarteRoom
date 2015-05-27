/*
 *BarterRoom - DataBase handler class  
 * Date: 17/05/2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                Item item = new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), (byte[])rdr[5]);
                all_Items.AddLast(item);
            }

            connect.Close();

            return all_Items;
        }



        public bool addItem(Item item)
        {
            query = "insert into items values('" + item.getUsr() + "','" + item.getName() + "','" + item.getClass() + "','" + item.getComments() + "'," + item.getDescription()+ ");";


            try
            {
                connect.Open();

                command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                connect.Close();
            }

            catch (Exception e) { return false; }
            uploadPic(item.getUsr(), item.getPic());
            return true;
        }




        public bool removeItem(Item item)
        {
            query = "delete from items where " + "usr="+"'"+item.getUsr()+"'"
                                                +" and name="+"'"+item.getName()+"'"
                                                +" and class="+"'"+item.getClass()+"'"
                                                +" and comments="+"'"+item.getComments()+"'"
                                                +" and description="+"'"+item.getDescription()+"'"
                                                +" and pic="+item.getUsr()+";";


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
        


    }
}