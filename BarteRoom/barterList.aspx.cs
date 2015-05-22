using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class BarterList : System.Web.UI.Page
    {
        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAccount.Text = Session["name"].ToString() + caret.Text;
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["usr"] = null;
            Session["name"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}