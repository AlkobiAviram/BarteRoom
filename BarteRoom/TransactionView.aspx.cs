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
            item_pic.ImageUrl = lg.setImagePath(trns.getItem_id());
            Item item = lg.getItemById(trns.getItem_id());
            itemName.Text = item.getName();
            itemDescription.Text = item.getDescription();
            //itemComments.Text=item.getComments();
            itemBarCode.Text = item.getId();
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