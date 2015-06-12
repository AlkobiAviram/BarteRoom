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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //setting image 
            string[] split = lg.setImagePath(Session["item_id"].ToString()).Split('/');
            item_pic3.ImageUrl = "img/OriginalSize_" + split[1];        

            //setting labels
            Item item = lg.getItemById(Session["item_id"].ToString());
            itemName.Text = item.getName();
            itemDescription.Text=item.getDescription();
            itemBarCode.Text = item.getId();


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

        protected void BackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }

      

    }
}