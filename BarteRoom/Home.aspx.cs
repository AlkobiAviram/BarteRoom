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
            manage.Visible = false;

            if (Session["usr"] == null)
            {
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
                logic = new Logic();

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

            usrName = loginUserNameTxtBox.Value;
            password = loginPasswordTxtBox.Value;

            logic = new Logic();
  
            if (logic.Login(usrName, password))
            {
                Session["usr"] = usrName;
                Session["name"] = logic.getName(usrName);
                Response.Redirect("Home.aspx");
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            int state;

            String usr = SignUpUsernameTxt.Text;
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

                logic.sendEmail("", first, last, subject, message, 0);
            }

            else
            {
                usr = Session["usr"].ToString();
                first = "";
                last = "";
                subject = SubTxt.Value;
                message = messageTxt.Text;

                logic = new Logic();

                logic.sendEmail(usr, first, last, subject, message, 1);
            }
        }

        protected void SignUpUsernameTxt_TextChanged(object sender, EventArgs e)
        {
            logic = new Logic();

            if (logic.isExist(SignUpUsernameTxt.Text))
            {
                comments.Visible = true;
             
            }

            else
            {
                
            }
        }

    
    }
}
