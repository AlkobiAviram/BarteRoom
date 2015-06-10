using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BarteRoom
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private HttpCookie cookie;
        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            manage.Visible = false;

            if (Session["usr"] == null)
            {
                if (!IsPostBack)
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
                }

                MyAccount.Visible = false;
                log.Visible = true;
                reg.Visible = true;
                firsTxt.Visible = true;
                lastTxt.Visible = true;

                SendFirstRequired.Visible = true;
                SendLastRequired.Visible = true;
            }

            else
            {
                int notRead = 0;
                logic = new Logic();
                notRead = logic.notReadBids(Session["usr"].ToString());

                note.Text = notRead.ToString();
                recentBids.DataSource = logic.getAllBids(Session["usr"].ToString());
                recentBids.DataBind();

                for (int i = 0; i < notRead; i++)
                {
                    recentBids.Rows[i].BackColor = Color.Gainsboro;
                }

                MyAccount.Visible = true;
                log.Visible = false;
                reg.Visible = false;
                firsTxt.Visible = false;
                lastTxt.Visible = false;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "loginUserNotExist", "loginUserNotExist();", true);
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
                Response.Redirect("Home.aspx");
            }

            else
                ScriptManager.RegisterStartupScript(this, GetType(), "loginFail", "loginFail();", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "userExists", "userExists();", true);
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

                logic.sendEmail("", first, subject, message, 0);
            }

            else
            {
                usr = Session["usr"].ToString();
                first = "";
                last = "";
                subject = SubTxt.Value;
                message = messageTxt.Text;

                logic = new Logic();

                logic.sendEmail(usr, first, subject, message, 1);
            }
        }

        protected void searchCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();
            String search = SearchTextBox.Text;
            String catagory = catagories.Text;
            int res = 0;

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
            Session["item_id"] = row.Cells[4].Text;
            Response.Redirect("/ItemView.aspx");
        }

        protected void MyBarter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BarterList.aspx");
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddItem.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SearchPage.aspx");
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

        }

        protected void ReadMarkCmd_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            logic.MarkAsRead(Session["usr"].ToString());
            Response.Redirect("Home.aspx");
        }

        protected void SelectBid_Click(object sender, EventArgs e)
        {

        }
    }
}