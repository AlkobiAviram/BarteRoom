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
            User usr = lg.getUserInformation(trns.getBidder());
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
            }
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = Convert.ToInt32(e.NewSelectedIndex);
            GridViewRow row = GridView1.Rows[index];
            Session["item_id"] = row.Cells[5].Text;
            Response.Redirect("/ItemView.aspx");
            GridView1.EditIndex = -1;
            bind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}