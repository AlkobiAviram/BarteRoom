using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class TransactionView : System.Web.UI.Page
    {
        Logic lg = new Logic();
        Transaction trns;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic lg = new Logic();
            trns=lg.getTransactionById(Session["bid_id"].ToString());
            
            
            //////////////////////regarding the item
            item_pic.ImageUrl = lg.setImagePath(trns.getItem_id());
            Item item = lg.getItemById(trns.getItem_id());
            itemName.Text = item.getName();
            itemDescription.Text = item.getDescription();
            itemBarCode.Text = item.getId();
            itemOwner.Text = item.getUsr();
            /////////////////////////////////


            ///////////////////////////////regarding the contact information
            User usr = lg.getUserInformation(trns.getUser());
            contact_usr.Text = usr.getUser();
            contact_fullName.Text = usr.getFullName();
            contact_email.Text = usr.getEmail();
            ////////////////////////////////
            if (!IsPostBack)
            {

                bind();
            }
        }

        private void bind()
        {

            GridView1.DataSource = lg.getDataSourceForBiddedItems(trns);
            GridView1.DataBind();

        }
        protected void cancel_cmd_Click(object sender, EventArgs e)
        {
            lg.removeTransaction(trns.getTransaction_id());
            Response.Redirect("/Bids.aspx");
        }

        protected void BackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BarterList.aspx");
        }
    }
}