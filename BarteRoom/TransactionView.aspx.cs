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

            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);
            ((LinkButton)Master.FindControl("AdvancedSearch")).Click += new EventHandler(this.searchBtn_Click);
            (Master.FindControl("navigation_bar")).Visible = false;

            Logic lg = new Logic();
            trns=lg.getTransactionById(Session["bid_id"].ToString());
            lg.markBidAsRead(Session["bid_id"].ToString());
            
            //////////////////////regarding the item
            item_pic.ImageUrl = lg.setImagePath(trns.Item_id);
            Item item = lg.getItemById(trns.Item_id);
            itemName.Text = item.Name;
            itemDescription.Text = item.Description;
            itemBarCode.Text = item.Id;
            itemOwner.Text = item.Usr;
            /////////////////////////////////


            User usr;
            //////////////////////regarding the bid or offer 
            if (Session["transaction_type"].ToString() == "bid")
            {
                usr = lg.getUserInformation(trns.Owner);
                BidOrOfferHeader.Text = "Bid Information";
                OfferdItemsHeader.Text = "The Items That You Offered To The Owner:";
                OwnerOrBidderInformationHeader.Text = "Owner Information";
                Confirm_cmd.Visible = false;
                confirm_label.Visible = false;
                Lbl1.Text = "Withdraw bid";
            }
            else
            {
                usr = lg.getUserInformation(trns.Bidder);
                BidOrOfferHeader.Text = "Offer Information";
                OfferdItemsHeader.Text = "The Items That The Bidder Offered To You:";
                OwnerOrBidderInformationHeader.Text = "Bidder Information";
                Confirm_cmd.Visible = true;
                confirm_label.Visible = true;
                Lbl1.Text = "Decline offer";

            }


            //////////////////////



            ///////////////////////////////regarding the contact information
            contact_usr.Text = usr.Usr;
            contact_fullName.Text = usr.FullName;
            contact_email.Text = usr.Email;
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
            lg.removeTransaction(trns.Transaction_id);
            bidRemoved_alert.Visible = true;
            if (Session["transaction_type"].ToString() == "bid")
            {
                    Response.Redirect("/Bids.aspx");

            }
            else
            Response.Redirect("/Offers.aspx");
        }

        protected void BackToList_Click(object sender, EventArgs e)
        {
            if (Session["transaction_type"].ToString() == "bid")
            {
                Response.Redirect("/Bids.aspx");

            }
            else
                Response.Redirect("/Offers.aspx");
        }

        protected void Confirm_cmd_Click(object sender, EventArgs e)
        {
            chooseOneItem.Visible = false;
            alreadyOffered.Visible = false;
            string checked_itemId="";
            //checking which cell selected
            foreach (GridViewRow i in GridView1.Rows)
            {
                if (((RadioButton)i.FindControl("rdio_items")).Checked)
                    checked_itemId = i.Cells[4].Text;
            }
            if (checked_itemId == "")
            {
                chooseOneItem.Visible = true;
                return;

            }
            Boolean isItemAlreadyOffered=lg.isItemAlreadyOfferedByUser(checked_itemId,Session["usr"].ToString());
            if (isItemAlreadyOffered)
            {
                chooseOneItem.Visible = true;
                return;

            }
            //adding a new match
            Match mtch = new Match(Session["usr"].ToString(), trns.Item_id, checked_itemId);
            lg.addAMatch(mtch);
            //removing the transction
            lg.removeTransaction(trns.Transaction_id);

            lg.addAConnection(trns.Owner, trns.Bidder);
            lg.addAConnection(trns.Bidder, trns.Owner);

            lg.addNote(trns.Bidder, 2, trns.Item_id, "You got a new Match!", trns.Owner);
            Response.Redirect("/MyMatches.aspx");

        }

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            transactionsPage.Visible = false;
        }
    }
}