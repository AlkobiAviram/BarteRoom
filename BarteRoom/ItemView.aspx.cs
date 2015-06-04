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
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic lg = new Logic();
            item_pic.ImageUrl = lg.setImagePath(Session["item_id"].ToString());
            Item item = lg.getItemById(Session["item_id"].ToString());
            itemName.Text = item.getName();
            itemDescription.Text=item.getDescription();
            itemComments.Text=item.getComments();
            itemBarCode.Text = item.getId();
        }

        protected void offer_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MakeBid.aspx");
        }

        protected void BackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BarterList.aspx");
        }
    }
}