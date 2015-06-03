using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class Home1 : System.Web.UI.Page
    {
        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searcCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            String search = SearchTextBox.Text;
            int res = logic.numOfResults(search);
            
            if (!(search == null))
            {
                searchField.Text = SearchTextBox.Text + "   ";

                if (res == 1)
                {
                    results.Text = res.ToString() + " listing";
                }

                else
                {
                    results.Text = res.ToString() + " listings";
                }
                results.Visible = true;
                searchField.Visible = true;
                homeGridView.DataSource = logic.getDataSourceForSearch(search);
                homeGridView.DataBind();
            }
        }

        protected void homeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(homeGridView.SelectedIndex);
            GridViewRow row = homeGridView.Rows[index];
            Session["item_id"] = row.Cells[4].Text;
            Response.Redirect("/ItemView.aspx");
        }

    }
}