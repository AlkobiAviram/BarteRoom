﻿using System;
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
        private string global_category="All Categories";
       
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
                    seeAllMsg.Visible = false;

                    SendFirstRequired.Visible = true;
                    SendLastRequired.Visible = true;
                }
            }
              advancedBind();
                navBar();
            
                if (Session["usr"] != null)
                {
                    int notRead_Msg = 0;
                    int notRead_notes = 0;
                    logic = new Logic();
                    notRead_Msg = logic.notReadMsg(Session["usr"].ToString());
                    notRead_notes = logic.notReadNotes(Session["usr"].ToString());

                    message.Text = notRead_Msg.ToString();
                    note.Text = notRead_notes.ToString();
                    recentBids.DataSource = logic.getAllNotes(Session["usr"].ToString());
                    recentBids.DataBind();

                    recentmsg.DataSource = logic.getAllMessages(Session["usr"].ToString(), 0);
                    recentmsg.DataBind();

                    for (int i = 0; i < notRead_Msg; i++)
                    {
                        recentmsg.Rows[i].BackColor = Color.Gainsboro;
                    }

                    for (int i = 0; i < notRead_notes; i++)
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
                    seeAllMsg.Visible = true;

                    MyAccount.Text = Session["name"].ToString() + caret.Text;

                    SendFirstRequired.Visible = false;
                    SendLastRequired.Visible = false;



                    if (logic.isManager(Session["usr"].ToString()))
                    {
                        manage.Visible = true;
                    }
                    
                }
                
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

        protected void MyMatches_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyMatches.aspx");
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

            if(Session["wasAdvancedButtonClicked"]==null ||!(Boolean)Session["wasAdvancedButtonClicked"])
            global_category = catagories.SelectedValue;
            int res = 0;
            ctagoriyLabel.Text = global_category;

            if (Session["usr"] != null)
            {
                res = logic.numOfResults(Session["usr"].ToString(), search, global_category);
            }
            else
            {
                res = logic.numOfResults("", search, global_category);
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
                    homeGridView.DataSource = logic.getDataSourceForSearch(Session["usr"].ToString(), search, global_category);
                }
                else
                {
                    homeGridView.DataSource = logic.getDataSourceForSearch("", search, global_category);
                }
                homeGridView.DataBind();
            }
        }
        private void navBar()
        {

            LinkedList<string> categories = logic.getAllMainCategories();

            
           
                    
                    
                    cat1.Text = categories.ElementAt(7);
                    cat2.Text = categories.ElementAt(8);
                    cat3.Text = categories.ElementAt(11);
                    cat4.Text = categories.ElementAt(17);
                    cat5.Text = categories.ElementAt(19);
                    cat6.Text = categories.ElementAt(25);
                
            
        }
        protected void navBar_Click(object sender, EventArgs e)
        {

        }
        private void advancedBind()
        {
            logic = new Logic();
            LinkedList<string> cats = logic.getAllMainCategories();
            Table tb = new Table();
            foreach (string str in cats)
            {

                DataTable dt = logic.getAllSubCategory(str);

                TableRow tr0 = new TableRow();
                TableCell tCell0 = new TableCell();
                Label main_cat = new Label();
                main_cat.Text = str;
                tCell0.Controls.Add(main_cat);
                tr0.Cells.Add(tCell0);
                tb.Rows.Add(tr0);


                TableRow tr = new TableRow();
                TableCell tCell = new TableCell();
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    LinkButton bt = new LinkButton();
                    bt.Text = dr[0].ToString();
                    bt.ID = str+"cat" + i;
                    bt.Visible = true;
                    bt.Click += new EventHandler(bt_Click);
                    tCell.Controls.Add(new LiteralControl("&nbsp"));
                    tCell.Controls.Add(bt);

                    tCell.CssClass = "toppad naticell";

                }

                tr.Cells.Add(tCell);

                tb.Rows.Add(tr);

            }


            advanced.Controls.Add(tb);
            advanced.Visible = false;
        }
        protected void AdvancedSearch_Click(object sender, EventArgs e)
        {
            Session["wasAdvancedButtonClicked"] = true;
            advanced.Visible = true;
        }
        protected void bt_Click(object sender, EventArgs e)
        {
            global_category = ((Button)sender).Text;
            SearchTextBox.Text = "";
            searchCmd_Click(null, e);
            Session["wasAdvancedButtonClicked"] = false;
        }
        protected void catgry_Click(object sender, EventArgs e)
        {
            Session["wasAdvancedButtonClicked"] = true;
            global_category = ((LinkButton)sender).Text;
            SearchTextBox.Text = "";
            searchCmd_Click(null, e);
            Session["wasAdvancedButtonClicked"] = false;
           
        }
        protected void homeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(homeGridView.SelectedIndex);
            GridViewRow row = homeGridView.Rows[index];
            string id= row.Cells[3].Text;
            logic = new Logic();
            logic.AddView(id);
            Response.Redirect("/ItemView.aspx?" + "id=" + Server.UrlEncode(id));
        }

        protected void MyBarter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BarterList.aspx");
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            Guid newGuid = Guid.NewGuid();
            Session["add_item"] = newGuid.ToString(); 
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
            recentBids.DataSource = logic.getAllNotes(Session["usr"].ToString());
            recentBids.DataBind();

            int index = Convert.ToInt32(recentBids.SelectedIndex);
            GridViewRow row = recentBids.Rows[index];
            string id = row.Cells[2].Text;
            logic.readIndex(id);
            int noteType = logic.getType(id);
            if (noteType == 1)
            {
                Session["transaction_type"] = "offer";
                Session["bid_id"] = logic.getTrans_id(id);
                Response.Redirect("/TransactionView.aspx");
            }

            else if (noteType == 2)
            {
                Response.Redirect("/MyMatches.aspx");
            }
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

        protected void msgReadMarkCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            logic.msgMarkAsRead(Session["usr"].ToString());
            Response.Redirect(Page.Request.Url.ToString(), true);
        }


        protected void recentmsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic = new Logic();
            string id;

            recentmsg.DataSource = logic.getAllMessages(Session["usr"].ToString(), 0);
            recentmsg.DataBind();

            int index = Convert.ToInt32(recentmsg.SelectedIndex);
            GridViewRow row = recentmsg.Rows[index];
            id = ((Label)recentmsg.Rows[index].FindControl("idLabel")).Text;

            Response.Redirect("/Mail.aspx?id=" + Server.UrlEncode(id));
        }


        protected void seeAllMsg_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Mail.aspx");
        }

    }
}