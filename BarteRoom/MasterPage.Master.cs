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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private HttpCookie cookie;
        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                manage.Visible = false;

                if (Session["usr"] == null)
                {
                    cookie = Request.Cookies["userLogin"];
                    if (cookie != null)
                    {
                        if (!(cookie["userPassword"].Equals("")))
                        {
                            logic = new Logic();

                            if (logic.Login(cookie["username"], cookie["userPassword"]))
                            {
                                Session["usr"] = cookie["username"];
                                Session["name"] = logic.getName(cookie["username"]);
                                Response.Redirect("Home.aspx");
                            }
                        }
                        loginUserNameTxt.Text = cookie["username"];
                    }


                    MyAccount.Visible = false;
                    log.Visible = true;
                    reg.Visible = true;
                    firsTxt.Visible = true;
                    lastTxt.Visible = true;
                    ReadMarkCmd.Visible = false;
                    msgReadMarkCmd.Visible = false;
                    SignInLabel1.Visible = true;
                    SignInLabel2.Visible = true;
                    noteSignInButton.Visible = true;
                    signInMsg1.Visible = true;
                    signInMsg1.Visible = true;
                    msgLinkButton.Visible = true;
                    seeAllNoteCmd.Visible = false;

                    SendFirstRequired.Visible = true;
                    SendLastRequired.Visible = true;
                }
            }
                if (Session["usr"] != null)
                {
                    int notRead_Msg = 0;
                    int notRead_bids = 0;
                    logic = new Logic();
                    notRead_Msg = logic.notReadMsg(Session["usr"].ToString());
                    notRead_bids = logic.notReadBids(Session["usr"].ToString());

                    message.Text = notRead_Msg.ToString();
                    note.Text = notRead_bids.ToString();
                    recentBids.DataSource = logic.getAllBids(Session["usr"].ToString());
                    recentBids.DataBind();

                    recentmsg.DataSource = logic.getAllMessages(Session["usr"].ToString(), 0);
                    recentmsg.DataBind();

                    for (int i = 0; i < notRead_Msg; i++)
                    {
                        recentmsg.Rows[i].BackColor = Color.Gainsboro;
                    }

                    for (int i = 0; i < notRead_bids; i++)
                    {
                        recentBids.Rows[i].BackColor = Color.Gainsboro;
                    }

                    MyAccount.Visible = true;
                    log.Visible = false;
                    reg.Visible = false;
                    firsTxt.Visible = false;
                    lastTxt.Visible = false;
                    ReadMarkCmd.Visible = true;
                    msgReadMarkCmd.Visible = true;
                    SignInLabel1.Visible = false;
                    SignInLabel2.Visible = false;
                    noteSignInButton.Visible = false;
                    signInMsg1.Visible = false;
                    signInMsg2.Visible = false;
                    msgLinkButton.Visible = false;
                    seeAllNoteCmd.Visible = true;

                    MyAccount.Text = Session["name"].ToString() + caret.Text;

                    SendFirstRequired.Visible = false;
                    SendLastRequired.Visible = false;



                    if (logic.isManager(Session["usr"].ToString()))
                    {
                        manage.Visible = true;
                    }

                }
            //}
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            String usrName;
            String password;

            usrName = loginUserNameTxt.Text;
            password = loginPasswordTxtBox.Value;

            logic = new Logic();

            if (!logic.isExist(usrName))
            {
                passError.Visible = false;
                userError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openerrorModal();", true);

                return;
            }

            if (logic.Login(usrName, password))
            {
                cookie = Request.Cookies["userLogin"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("userLogin");
                    cookie["username"] = usrName;
                    cookie["userPassword"] = "";

                    if (loginCheckBox.Checked)
                    {
                        cookie["userPassword"] = password;
                    }

                    cookie.Expires = DateTime.Now.AddDays(365);
                    Response.Cookies.Add(cookie);
                }

                else
                {
                    if (loginCheckBox.Checked)
                    {
                        cookie["userPassword"] = password;
                    }

                    else
                    {
                        cookie["userPassword"] = "";
                    }

                    cookie["username"] = usrName;
                    Response.Cookies.Set(cookie);
                }

                Session["usr"] = usrName;
                Session["name"] = logic.getName(usrName);

                Response.Redirect(Page.Request.Url.ToString(), true);
            }

            else
            {
                passError.Visible = true;
                userError.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openerrorModal();", true);
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            int state;

            String usr = SignUpUsernameTxt.Text;
            String first = SignUpFirstTxtBox.Value;
            String password = SignUpPasswordTxtBox.Value;
            String confirm = SignUpConfirmTxtBox.Value;
            String email = SignUpEmailTxtBox.Value;

            logic = new Logic();

            state = logic.SignUp(usr, first, password, confirm, email);

            if (state == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openRegerrorModal();", true);
            }

            else if (state == 2)
            {

            }

            else
            {
                Session["usr"] = usr;
                Session["name"] = logic.getName(usr);
                Response.Redirect("Home.aspx");
            }
        }
        protected void MyMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Mail.aspx");
        }
        protected void LogOut_Click(object sender, EventArgs e)
        {
            cookie = Request.Cookies["userLogin"];
            if (cookie != null)
            {
                cookie["userPassword"] = null;
                Response.Cookies.Set(cookie);
            }
            Session["usr"] = null;
            Session["name"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            String usr;
            String first;
            String last;
            String subject;
            String message;

            if (Session["usr"] == null)
            {
                first = firsTxt.Text;
                last = lastTxt.Text;
                subject = SubTxt.Value;
                message = messageTxt.Text;

                logic = new Logic();

                logic.sendEmail("", "", first, subject, message, 0);
            }

            else
            {
                usr = Session["usr"].ToString();
                first = "";
                last = "";
                subject = SubTxt.Value;
                message = messageTxt.Text;

                logic = new Logic();

                logic.sendEmail("", usr, first, subject, message, 1);
            }
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openInfoModal();", true);
        }

        protected void searchCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            String search = SearchTextBox.Text;
            String catagory = catagories.Text;
            int res = 0;
            ctagoriyLabel.Text = catagory;

            if (Session["usr"] != null)
            {
                res = logic.numOfResults(Session["usr"].ToString(), search, catagory);
            }
            else
            {
                res = logic.numOfResults("", search, catagory);
            }

            if (!(search == null))
            {
                searchField.Text = SearchTextBox.Text;

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
                if (Session["usr"] != null)
                {
                    homeGridView.DataSource = logic.getDataSourceForSearch(Session["usr"].ToString(), search, catagory);
                }
                else
                {
                    homeGridView.DataSource = logic.getDataSourceForSearch("", search, catagory);
                }
                homeGridView.DataBind();
            }
        }

        protected void homeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(homeGridView.SelectedIndex);
            GridViewRow row = homeGridView.Rows[index];
            string id= row.Cells[3].Text;
            Response.Redirect("/ItemView.aspx?" + "id=" + Server.UrlEncode(id));
        }

        protected void MyBarter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BarterList.aspx");
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddItem.aspx");
        }

        protected void MyBids_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Bids.aspx");
        }

        protected void MyOffers_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Offers.aspx");
        }


        protected void forgotPassword_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openForgotModal();", true);
        }

        protected void ReadMarkCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            logic.MarkAsRead(Session["usr"].ToString());
            Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void SelectBid_Click(object sender, EventArgs e)
        {

        }

        protected void homeGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            logic = new Logic();
            String search = searchField.Text;
            String catagory = ctagoriyLabel.Text;


            if (Session["usr"] != null)
            {
                homeGridView.DataSource = logic.getDataSourceForSearch(Session["usr"].ToString(), search, catagory);
            }
            else
            {
                homeGridView.DataSource = logic.getDataSourceForSearch("", search, catagory);
            }
            homeGridView.PageIndex = e.NewPageIndex;
            homeGridView.DataBind();
        }

        protected void recentBids_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.ToolTip = "Click to select";
        }

        protected void recentBids_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:

                        break;
                    case DataControlRowType.DataRow:
                        e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer';this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#F5F5DC'");
                        if (e.Row.RowState == DataControlRowState.Alternate)
                        {
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                        }
                        else
                        {
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                        }
                        e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(recentBids, "Select$" + e.Row.RowIndex));
                        break;
                }
            }
            catch { }
        }

        protected void recentBids_SelectedIndexChanged(object sender, EventArgs e)
        {

            logic = new Logic();
            recentBids.DataSource = logic.getAllBids(Session["usr"].ToString());
            recentBids.DataBind();

            int index = Convert.ToInt32(recentBids.SelectedIndex);
            GridViewRow row = recentBids.Rows[index];
            logic.readIndex(row.Cells[2].Text);
            Session["transaction_type"] = "offer";
            Session["bid_id"] = row.Cells[2].Text;

            Response.Redirect("/TransactionView.aspx");
        }

        protected void AboutCmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/About.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void recentmsg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:

                        break;
                    case DataControlRowType.DataRow:
                        e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer';this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#F5F5DC'");
                        if (e.Row.RowState == DataControlRowState.Alternate)
                        {
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                        }
                        else
                        {
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                        }
                        e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(recentmsg, "Select$" + e.Row.RowIndex));
                        break;
                }
            }
            catch { }
        }

        protected void forgotSend_Click(object sender, EventArgs e)
        {
            string text = forgotTxt.Text;
            string user, email, pass, name;
            logic = new Logic();

            if (text.Contains("@"))
            {
                if (logic.isEmailExists(text))
                {
                    user = logic.getUserByEmail(text);
                    pass = logic.getPass(user);
                    name = logic.getName(user);
                    logic.sendEmail(text, user, name, "Your Password at BarteRoom", pass, 2);

                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = true;
                    Label6.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openInfoModal();", true);
                }

                else
                {
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;
                    Label6.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openInfoModal();", true);
                }
            }

            else
            {
                if (logic.isExist(text))
                {
                    email = logic.getEmail(text);
                    pass = logic.getPass(text);
                    name = logic.getName(text);
                    logic.sendEmail(email, text, name, "Your Password at BarteRoom", pass, 2);

                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = true;
                    Label6.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openInfoModal();", true);
                }

                else
                {
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = true;
                    Label5.Visible = false;
                    Label6.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openInfoModal();", true);
                }
            }
        }

        protected void forgotCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openloginModal();", true);
        }

        protected void errorOk_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openloginModal();", true);
        }

        protected void RegerrorOk_Click(object sender, EventArgs e)
        {
            SignUpUsernameTxt.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openregisterModal();", true);
        }

        protected void noteSignInButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openloginModal();", true);
        }

        protected void msgReadMarkCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            logic.msgMarkAsRead(Session["usr"].ToString());
            Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void seeAllNoteCmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Offers.aspx");
        }

    }
}