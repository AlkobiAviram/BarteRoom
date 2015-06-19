using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BarteRoom
{
    public partial class Mail : System.Web.UI.Page
    {
        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            logic = new Logic();

            ((LinkButton)Master.FindControl("MyMail")).BackColor = Color.Gainsboro;
            ((TextBox)Master.FindControl("SearchTextBox")).Visible = false;
            ((DropDownList)Master.FindControl("catagories")).Visible = false;
            ((Button)Master.FindControl("Button1")).Visible = false;
            ((LinkButton)Master.FindControl("AdvancedSearch")).Visible = false;
            ((GridView)Master.FindControl("homeGridView")).Visible = false;

            int notRead = logic.notReadMsg(Session["usr"].ToString());
            numOfLabel.Text = "(" + notRead.ToString() + ")";
        }

        protected void InboxCmd_Click(object sender, EventArgs e)
        {
            inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
            inboxView.DataBind();
        }
    }
}