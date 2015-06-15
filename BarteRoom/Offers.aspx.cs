using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BarteRoom
{
    public partial class Offers : System.Web.UI.Page
    {

        Logic lg = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);

            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Gainsboro;
            ((LinkButton)Master.FindControl("MyOffers")).BackColor = Color.Gainsboro;

            if (!IsPostBack)
            {

                bind();
            }
        }
        private void bind()
        {

            GridView1.DataSource = lg.getDataSourceForBidsOrOffers(Session["usr"].ToString(), "offer");
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
            int index = Convert.ToInt32(e.NewSelectedIndex);
            GridViewRow row = GridView1.Rows[index];
            Session["transaction_type"] = "offer";
            Session["bid_id"] = row.Cells[1].Text;
            Response.Redirect("/TransactionView.aspx");
            GridView1.EditIndex = -1;
            bind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            offerPage.Visible = false;

            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Transparent;
            ((LinkButton)Master.FindControl("MyOffers")).BackColor = Color.Transparent;
        }

    }
}