using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class viewItem : System.Web.UI.Page
    {
        Logic lg = new Logic();
        private string new_name="";
        private string new_comments = "";
        private string new_description = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);

            //setting image 
            string[] split = lg.setImagePath(Session["item_id"].ToString()).Split('/');
            item_pic3.ImageUrl = "img/OriginalSize_" + split[1];        

            //setting labels
            Item item = lg.getItemById(Session["item_id"].ToString());
            
      
            nameLabel.Text = item.getName();   
            comLabel.Text = item.getComments();
            idLabel1.Text = item.getId();  
            desLabel.Text=item.getDescription();

            if (IsPostBack)
            {
                comments_textBox.Visible = false;
                name_textBox.Visible = false;
                description_textBox.Visible = false;

            }
            //checking if the user logged in
            if (Session["usr"] == null)
            {
                makeBidLabel.Visible = true;
                makeBidLabel.Text = "Please log in to make a bid";
                offer_cmd.Visible = false;

            }
            else
            {
                makeBidLabel.Visible = false;
                offer_cmd.Visible = true;
            }
        }

        protected void offer_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MakeBid.aspx");
        }
        private int numOfRows(string str)
        {
      
            return str.Split('.').Length;
        }
        
        private int maxLineLength(string str)
        {
            int max=0;
            string[] split=str.Split('\n');
            if (split.Length == 0)
                return str.Length;
           for(int i = 0;i<split.Length;i++){
               if(split[i].Length>max)
                   max=split[i].Length;
           }
            return max;
        }
        protected void BackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }

        protected void edit_cmd_Click(object sender, EventArgs e)
        {
            Logic lg_temp = new Logic();
            Item item = lg.getItemById(Session["item_id"].ToString());
            name_textBox.Text = item.getName();
            name_textBox.Visible = true;


            comments_textBox.Text = item.getComments();
            comments_textBox.Visible = true;

            description_textBox.Text = item.getDescription();
            description_textBox.Rows = numOfRows(item.getDescription());
            description_textBox.Width = maxLineLength(item.getDescription());
            description_textBox.Visible = true;

         
          
            
            desLabel.Visible = false;
            nameLabel.Visible = false;
            comLabel.Visible=false;


            commit_cmd.Visible = true;
            cancel_cmd.Visible = true;
            edit_cmd.Visible = false;
            
        }

        protected void commit_cmd_Click(object sender, EventArgs e)
        {
            
           
            lg.editItem(name_textBox.Text, comments_textBox.Text, description_textBox.Text, Session["item_id"].ToString());
            comments_textBox.Visible = false;
            name_textBox.Visible = false;
            description_textBox.Visible = false;


            desLabel.Visible = true;
            nameLabel.Visible = true;
            comLabel.Visible = true;

            commit_cmd.Visible = false;
            cancel_cmd.Visible = false;
            edit_cmd.Visible = true;
            Response.Redirect("/ItemView.aspx");
        }

        protected void cancel_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ItemView.aspx");
            comments_textBox.Visible = false;
            name_textBox.Visible = false;
            description_textBox.Visible = false;


            desLabel.Visible = true;
            nameLabel.Visible = true;
            comLabel.Visible = true;


            commit_cmd.Visible = false;
            cancel_cmd.Visible = false;
            edit_cmd.Visible = true;
        }

        protected void description_textBox_TextChanged(object sender, EventArgs e)
        {
         
        }
        protected void comments_textBox_TextChanged(object sender, EventArgs e)
        {
     
        }
        protected void name_textBox_TextChanged(object sender, EventArgs e)
        {

      
        }

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            itemViewPage.Visible = false;
        }

    }
}