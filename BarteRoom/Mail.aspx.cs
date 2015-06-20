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
            string id;
            if (Session["usr"] == null)
            {
                Response.Redirect("/Home.aspx");
            }
            
            else
            {
                ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Gainsboro;
                ((LinkButton)Master.FindControl("MyMail")).BackColor = Color.Gainsboro;
                ((TextBox)Master.FindControl("SearchTextBox")).Visible = false;
                ((DropDownList)Master.FindControl("catagories")).Visible = false;
                ((Button)Master.FindControl("Button1")).Visible = false;
                ((LinkButton)Master.FindControl("AdvancedSearch")).Visible = false;
                ((GridView)Master.FindControl("homeGridView")).Visible = false;

                int notRead = logic.notReadMsg(Session["usr"].ToString());
                numOfLabel.Text = "(" + notRead.ToString() + ")";

                if (Request.QueryString["id"] != null)
                {
                    id = Request.QueryString["id"].ToString();
                    inboxView.DataSource = logic.getAllMessages(id, 2);
                }

                else
                {
                    inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
                }
                
                inboxView.DataBind();
            }
        }

        protected void InboxCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
            inboxView.DataBind();

            inboxViewID.Visible = true;
            msgViewID.Visible = false;
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

                        if ((((Label)e.Row.FindControl("msgLabel")).Text).Length > 125)
                        {
                            ((Label)e.Row.FindControl("msgLabel")).Text = ((Label)e.Row.FindControl("msgLabel")).Text.Substring(0, 125) + "....";
                        }

                        if ((((Label)e.Row.FindControl("isReadLabel")).Text).Equals("0"))
                        {
                            ((Label)e.Row.FindControl("fromLabel")).CssClass = "notReadStyle";
                            ((Label)e.Row.FindControl("subjectLabel")).CssClass = "notReadStyle";
                            ((Label)e.Row.FindControl("datetimeLabel")).CssClass = "notReadStyle";
                        }

                        else if ((((Label)e.Row.FindControl("isReadLabel")).Text).Equals("1"))
                        {
                            ((Label)e.Row.FindControl("fromLabel")).CssClass = "readStyle";
                            ((Label)e.Row.FindControl("subjectLabel")).CssClass = "readStyle";
                            ((Label)e.Row.FindControl("datetimeLabel")).CssClass = "readStyle";
                        }
                        
                        break;
                }
            }
            catch { }
        }

        protected void inboxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(inboxView.SelectedIndex);
            logic = new Logic();
            string msgId;
            string email;
            string[] sub;
            string from = ((Label)inboxView.Rows[index].FindControl("fromLabel")).Text;

            email = logic.getEmail(from);
            msgId = ((Label)inboxView.Rows[index].FindControl("idLabel")).Text;
            msgViewFrom.Text = from + " - " + email;
            msgViewDate.Text = ((Label)inboxView.Rows[index].FindControl("datetimeLabel")).Text;
            msgViewTxt.Text = logic.getMsgById(msgId);
            sub = (((Label)inboxView.Rows[index].FindControl("subjectLabel")).Text).Split('-');
            msgSubView.Text = sub[0];

            inboxViewID.Visible = false;
            msgViewID.Visible = true;
        }

        protected void replayButton_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            string from, subject, body;
            string[] to;

            from = Session["usr"].ToString();
            to = (msgViewFrom.Text).Split(' ');
            subject = msgSubView.Text;
            body = replayTxt.Text;
            Response.Write(to[0]);

            Message repMessage = new Message(from, to[0], subject, body);

            logic.addMessage(repMessage);
        }

        
    }
}