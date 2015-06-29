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
    public partial class Mail : System.Web.UI.Page
    {
        private Logic logic;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            logic = new Logic();
            string id;
            DataTable dt;
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
                (Master.FindControl("navigation_bar")).Visible = false;
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        id = Request.QueryString["id"].ToString();
                        if (logic.isMsgExists(id))
                        {
                            dt = logic.getAllMessages(id, 2);
                        }
                        else
                        {
                            dt = logic.getSentMessage(id);
                        }
                        logic.setMsgAsRead(id);

                        string from = dt.Rows[0][0].ToString();
                        string email = logic.getEmail(from);
                        msgViewFrom.Text = from + " - " + email;
                        dt.Rows[0][0].ToString();
                        msgViewDate.Text = dt.Rows[0][3].ToString();
                        msgViewTxt.Text = logic.getMsgById(dt.Rows[0][4].ToString());
                        string[] sub = (dt.Rows[0][1].ToString()).Split('-');
                        msgSubView.Text = sub[0];
                        favourEmptyID.Visible = false;
                        inboxViewID.Visible = false;
                        inboxEmptyID.Visible = false;
                        SentViewID.Visible = false;
                        sentEmptyID.Visible = false;
                        msgViewID.Visible = true;
                        FavouritesID.Visible = false;
                        DraftViewID.Visible = false;
                        draftEmptyID.Visible = false;
                        newMessageID.Visible = false;
                        connectionsViewID.Visible = false;
                        connEmptyID.Visible = false;
                    }

                    else
                    {
                        if (!Page.IsPostBack)
                        {
                            inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
                            inboxView.DataBind();
                        }

                        if (inboxView.Rows.Count == 0)
                        {
                            draftEmptyID.Visible = false;
                            sentEmptyID.Visible = false;
                            favourEmptyID.Visible = false;
                            inboxViewID.Visible = false;
                            inboxEmptyID.Visible = true;
                            SentViewID.Visible = false;
                            msgViewID.Visible = false;
                            FavouritesID.Visible = false;
                            DraftViewID.Visible = false;
                            newMessageID.Visible = false;
                            connectionsViewID.Visible = false;
                            connEmptyID.Visible = false;
                        }

                        else
                        {
                            draftEmptyID.Visible = false;
                            sentEmptyID.Visible = false;
                            favourEmptyID.Visible = false;
                            inboxViewID.Visible = true;
                            inboxEmptyID.Visible = false;
                            SentViewID.Visible = false;
                            msgViewID.Visible = false;
                            FavouritesID.Visible = false;
                            DraftViewID.Visible = false;
                            newMessageID.Visible = false;
                            connectionsViewID.Visible = false;
                            connEmptyID.Visible = false;
                        }
                    }
                }
                    int notRead = logic.notReadMsg(Session["usr"].ToString());
                numOfLabel.Text = "(" + notRead.ToString() + ")";
                
            }
        }

        protected void InboxCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            inboxView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 1);
            inboxView.DataBind();

            if (inboxView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = true;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = true;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
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
                        
                        e.Row.Cells[1].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[1].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(inboxView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[2].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(inboxView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[3].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[3].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(inboxView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[4].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[4].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(inboxView, "Select$" + e.Row.RowIndex));
                        
                        if ((((Label)e.Row.FindControl("msgLabel")).Text).Length > 80)
                        {
                            ((Label)e.Row.FindControl("msgLabel")).Text = ((Label)e.Row.FindControl("msgLabel")).Text.Substring(0, 80) + "....";
                        }

                        if ((((Label)e.Row.FindControl("isStarLabel")).Text).Equals("1"))
                        {
                            e.Row.CssClass = "starStyle";
                        }

                        else if ((((Label)e.Row.FindControl("isStarLabel")).Text).Equals("0"))
                        {
                            e.Row.CssClass = "notstarStyle";
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
            string id;
            int index = Convert.ToInt32(inboxView.SelectedIndex);

            id = ((Label)inboxView.Rows[index].FindControl("idLabel")).Text;
            Response.Redirect("/Mail.aspx?id=" + Server.UrlEncode(id));
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

            Message repMessage = new Message(from, to[0], subject, body);

            bool isSend = logic.addMessage(repMessage, 0);
            replayTxt.Text = "";

            if (isSend)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Message Sent!');", true);
            }

            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Message not Sent! please try again');", true);
            }
        }

        protected void sentCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            SentGridView.DataSource = logic.getAllSentMessages(Session["usr"].ToString());
            SentGridView.DataBind();

            if (SentGridView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = true;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = true;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void SentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:

                        break;
                    case DataControlRowType.DataRow:
                        e.Row.Cells[1].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[1].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SentGridView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[2].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SentGridView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[3].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[3].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SentGridView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[4].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[4].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SentGridView, "Select$" + e.Row.RowIndex));

                        if ((((Label)e.Row.FindControl("sentmsgLabel")).Text).Length > 80)
                        {
                            ((Label)e.Row.FindControl("sentmsgLabel")).Text = ((Label)e.Row.FindControl("sentmsgLabel")).Text.Substring(0, 80) + "....";
                        }

                        break;
                }
            }
            catch { }
        }

        protected void SentGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            int index = Convert.ToInt32(SentGridView.SelectedIndex);

            id = ((Label)SentGridView.Rows[index].FindControl("sentidLabel")).Text;
            Response.Redirect("/Mail.aspx?id=" + Server.UrlEncode(id));
        }

        protected void markMsgAsRead_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            logic.msgMarkAsRead(Session["usr"].ToString());

            Response.Redirect("/Mail.aspx");
        }

        protected void deleteCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            foreach (GridViewRow row in inboxView.Rows)
            {
                if(((CheckBox)row.FindControl("CheckMsg")).Checked)
                {
                    string id = ((Label)row.FindControl("idLabel")).Text;
                    logic.deleteMsg(id);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Deleteed!');", true);
                }                
            }

            Response.Redirect("/Mail.aspx"); 
        }

        protected void StarCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            foreach (GridViewRow row in inboxView.Rows)
            {
                if (((CheckBox)row.FindControl("CheckMsg")).Checked)
                {
                    string id = ((Label)row.FindControl("idLabel")).Text;
                    if ((((Label)row.FindControl("isStarLabel")).Text).Equals("0"))
                    {
                        logic.markAsStar(id);
                    }
                    else if ((((Label)row.FindControl("isStarLabel")).Text).Equals("1"))
                    {
                        logic.markAsnotStar(id);
                    }
                }
            }

            Response.Redirect("/Mail.aspx");
        }

        protected void saveDraft_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            string from, subject, body;
            string[] to;

            from = Session["usr"].ToString();
            to = (msgViewFrom.Text).Split(' ');
            subject = msgSubView.Text;
            body = replayTxt.Text;

            Message repMessage = new Message(from, to[0], subject, body);

            logic.addMessage(repMessage, 1);
        }

        protected void FavouritesCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            FavourView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 3);
            FavourView.DataBind();

            if (FavourView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = true;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = true;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void DraftsCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            drafView.DataSource = logic.getAllDrafts(Session["usr"].ToString());
            drafView.DataBind();

            if (drafView.Rows.Count == 0)
            {
                draftEmptyID.Visible = true;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = true;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void deleteOut_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            foreach (GridViewRow row in SentGridView.Rows)
            {
                if (((CheckBox)row.FindControl("CheckOutMsg")).Checked)
                {
                    string id = ((Label)row.FindControl("sentidLabel")).Text;
                    logic.deleteSentMsg(id);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Deleteed!');", true);
                }
            }

            SentGridView.DataSource = logic.getAllSentMessages(Session["usr"].ToString());
            SentGridView.DataBind();

            if (SentGridView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = true;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = true;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void FavourDelete_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            foreach (GridViewRow row in FavourView.Rows)
            {
                if (((CheckBox)row.FindControl("FavourCheckMsg")).Checked)
                {
                    string id = ((Label)row.FindControl("FavouridLabel")).Text;
                    logic.deleteMsg(id);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Deleteed!');", true);
                }
            }

            FavourView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 3);
            FavourView.DataBind();

            if (FavourView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = true;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = true;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void FavourStarCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            foreach (GridViewRow row in FavourView.Rows)
            {
                if (((CheckBox)row.FindControl("FavourCheckMsg")).Checked)
                {
                    string id = ((Label)row.FindControl("FavouridLabel")).Text;
                    logic.markAsnotStar(id);
                }
            }
            FavourView.DataSource = logic.getAllMessages(Session["usr"].ToString(), 3);
            FavourView.DataBind();

            if (FavourView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = true;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = true;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void draftDelete_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            foreach (GridViewRow row in drafView.Rows)
            {
                if (((CheckBox)row.FindControl("drafCheckMsg")).Checked)
                {
                    string id = ((Label)row.FindControl("drafidLabel")).Text;
                    logic.deleteMsg(id);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Deleteed!');", true);
                }
            }

            drafView.DataSource = logic.getAllDrafts(Session["usr"].ToString());
            drafView.DataBind();

            if (drafView.Rows.Count == 0)
            {
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                draftEmptyID.Visible = true;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = true;
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void FavourView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:

                        break;
                    case DataControlRowType.DataRow:
                        e.Row.Cells[1].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[1].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(FavourView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[2].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(FavourView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[3].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[3].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(FavourView, "Select$" + e.Row.RowIndex));
                        e.Row.Cells[4].Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        e.Row.Cells[4].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(FavourView, "Select$" + e.Row.RowIndex));

                        if ((((Label)e.Row.FindControl("FavourmsgLabel")).Text).Length > 80)
                        {
                            ((Label)e.Row.FindControl("FavourmsgLabel")).Text = ((Label)e.Row.FindControl("FavourmsgLabel")).Text.Substring(0, 80) + "....";
                        }

                        break;
                }
            }
            catch { }
        }

        protected void FavourView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            int index = Convert.ToInt32(FavourView.SelectedIndex);

            id = ((Label)FavourView.Rows[index].FindControl("FavouridLabel")).Text;
            Response.Redirect("/Mail.aspx?id=" + Server.UrlEncode(id));
        }

        protected void deleteMsgView_Click(object sender, EventArgs e)
        {
            string id;
            logic = new Logic();

            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
                bool isDelete = logic.deleteMsg(id);

                Response.Redirect("/Mail.aspx");

                if (isDelete)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Message Deleteed!');", true);
                }
            }
        }

        protected void newMsgCmd_Click(object sender, EventArgs e)
        {
            favourEmptyID.Visible = false;
            inboxViewID.Visible = false;
            inboxEmptyID.Visible = false;
            SentViewID.Visible = false;
            msgViewID.Visible = false;
            FavouritesID.Visible = false;
            DraftViewID.Visible = false;
            draftEmptyID.Visible = false;
            sentEmptyID.Visible = false;
            newMessageID.Visible = true;
            connectionsViewID.Visible = false;
            connEmptyID.Visible = false;
        }

        protected void sendMsg_Click(object sender, EventArgs e)
        {
            string to;
            string sub;
            string msg_body;

            to = connectionsList.SelectedValue;
            msg_body = newMsgTxt.Text;

            if (newSubTxt.Text == null)
            {
                sub = "null";
            }

            else
            {
                sub = newSubTxt.Text;
            }

            Message newMsg = new Message(Session["usr"].ToString(), to, sub, msg_body);

            logic = new Logic();

            bool isSend = logic.addMessage(newMsg, 0);

            if (isSend)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Message Sent!');", true);
            }

            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Message not Sent! please try again');", true);
            }
        }

        protected void newDraft_Click(object sender, EventArgs e)
        {
            string to;
            string sub;
            string msg_body;

            to = connectionsList.SelectedValue;
            msg_body = newMsgTxt.Text;

            if (newSubTxt.Text == null)
            {
                sub = "null";
            }

            else
            {
                sub = newSubTxt.Text;
            }

            Message newMsg = new Message(Session["usr"].ToString(), to, sub, msg_body);

            logic = new Logic();

            bool isSaved = logic.addMessage(newMsg, 1);

            if (isSaved)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('Save as draft!');", true);
            }

            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('not Save! please try again');", true);
            }
        }


        protected void drafView_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic = new Logic();
            string to;
            string sub;
            string msg_body;
            string id;
            int index = Convert.ToInt32(drafView.SelectedIndex);

            to = ((Label)drafView.Rows[index].FindControl("drafromLabel")).Text;
            sub = ((Label)drafView.Rows[index].FindControl("drafsubjectLabel")).Text;
            msg_body = ((TextBox)drafView.Rows[index].FindControl("drafmsgLabel")).Text;

            id = ((Label)drafView.Rows[index].FindControl("drafidLabel")).Text;

            Message newMsg = new Message(Session["usr"].ToString(), to, sub, msg_body);

            logic.sendDraft(id, newMsg);
            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('draft Sent!');", true);


            drafView.DataSource = logic.getAllDrafts(Session["usr"].ToString());
            drafView.DataBind();

            if (drafView.Rows.Count == 0)
            {
                draftEmptyID.Visible = true;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = true;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = false;
            }
        }

        protected void connectionsCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            connectionView.DataSource = logic.getAllConnections(Session["usr"].ToString());
            connectionView.DataBind();

            if (connectionView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = true;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = true;
                connEmptyID.Visible = false;
            }
        }

        protected void connectionView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string usr;
            logic = new Logic();

            int index = Convert.ToInt32(connectionView.SelectedIndex);

            usr = ((Label)connectionView.Rows[index].FindControl("connUserLabel")).Text;

            logic.deleteConn(Session["usr"].ToString(), usr);

            connectionView.DataSource = logic.getAllConnections(Session["usr"].ToString());
            connectionView.DataBind();

            if (connectionView.Rows.Count == 0)
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = false;
                connEmptyID.Visible = true;
            }

            else
            {
                draftEmptyID.Visible = false;
                sentEmptyID.Visible = false;
                favourEmptyID.Visible = false;
                inboxViewID.Visible = false;
                inboxEmptyID.Visible = false;
                SentViewID.Visible = false;
                msgViewID.Visible = false;
                FavouritesID.Visible = false;
                DraftViewID.Visible = false;
                newMessageID.Visible = false;
                connectionsViewID.Visible = true;
                connEmptyID.Visible = false;
            }
        }

    }
}