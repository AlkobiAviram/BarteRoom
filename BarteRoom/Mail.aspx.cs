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
            if (Session["usr"] == null)
            {
                Response.Redirect("/Home.aspx");
            }
            
            else{
            logic = new Logic();

            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Gainsboro;
            ((LinkButton)Master.FindControl("MyMail")).BackColor = Color.Gainsboro;
            ((TextBox)Master.FindControl("SearchTextBox")).Visible = false;
            ((DropDownList)Master.FindControl("catagories")).Visible = false;
            ((Button)Master.FindControl("Button1")).Visible = false;
            ((LinkButton)Master.FindControl("AdvancedSearch")).Visible = false;
            ((GridView)Master.FindControl("homeGridView")).Visible = false;

            int notRead = logic.notReadMsg(Session["usr"].ToString());
            numOfLabel.Text = "(" + notRead.ToString() + ")";

            inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
            inboxView.DataBind();
            }
        }

        protected void InboxCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
            inboxView.DataBind();
        }

        protected void inboxView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:

                        break;
                    case DataControlRowType.DataRow:
                        e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(inboxView, "Select$" + e.Row.RowIndex));
                        break;
                }
            }
            catch { }
        }
    }
}