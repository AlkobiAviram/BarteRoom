using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class Home : System.Web.UI.Page
    {

        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usr"] == null)
            {
                MyAccount.Visible = false;
            }

            else if (MyAccount != null)
            {
                MyAccount.Visible = true;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            String usrName;
            String password;

            usrName = loginUserNameTxtBox.Value;
            password = loginPasswordTxtBox.Value;

            logic = new Logic();
  
            if (logic.Login(usrName, password))
            {
                Session["usr"] = usrName;
                Response.Redirect("Home.aspx");
                //Response.Redirect("BarterList.aspx");
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            int state;

            String usr = SignUpUsernameTxtBox.Value;
            String first = SignUpFirstTxtBox.Value;
            String last = SignUpLastTxtBox.Value;
            String password = SignUpPasswordTxtBox.Value;
            String confirm = SignUpConfirmTxtBox.Value;
            String email = SignUpEmailTxtBox.Value;

            logic = new Logic();

            state = logic.SignUp(usr, first, last, password, confirm, email);

            if (state == 1)
            {
                comments.Text = "Username already exists";
                comments.Visible = true;
            }

            else if (state == 2)
            {
                comments.Text = "SignUp is fail please try again";
                comments.Visible = true;
            }

            else
                comments.Visible = false;
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["usr"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}
