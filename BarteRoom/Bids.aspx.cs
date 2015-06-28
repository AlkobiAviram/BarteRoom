using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
namespace BarteRoom
{
    public partial class BidsOffersInbox : System.Web.UI.Page
    {
        Logic lg = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);
            ((LinkButton)Master.FindControl("AdvancedSearch")).Click += new EventHandler(this.searchBtn_Click);
            (Master.FindControl("navigation_bar")).Visible = false;

            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Gainsboro;
            ((LinkButton)Master.FindControl("MyBids")).BackColor = Color.Gainsboro;

            if (!IsPostBack)
            {

                bind();
            }
        }
        private void bind()
        {

            GridView1.DataSource = lg.getDataSourceForBidsOrOffers(Session["usr"].ToString(), "bid");
            GridView1.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
            }
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
    

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(GridView1.SelectedIndex);
            DataTable dt = lg.getDataSourceForBidsOrOffers(Session["usr"].ToString(), "bid");
            Session["transaction_type"] = "bid";
            string id = dt.Rows[index]["Bid_ID"].ToString();
            Session["bid_id"] = id;

         
            Response.Redirect("/TransactionView.aspx");
            GridView1.EditIndex = -1;
            bind();
        }

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            BidsPage.Visible = false;

            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Transparent;
            ((LinkButton)Master.FindControl("MyBids")).BackColor = Color.Transparent;
        }
    }
}