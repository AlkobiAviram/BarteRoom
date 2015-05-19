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
                Session[usrName] = usrName;
                Response.Redirect("BarterList.aspx");
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            String usr = SignUpUsernameTxtBox.Value;
            String first = SignUpFirstTxtBox.Value;
            String last = SignUpLastTxtBox.Value;
            String password = SignUpPasswordTxtBox.Value;
            String confirm = SignUpConfirmTxtBox.Value;
            String email = SignUpEmailTxtBox.Value;

            logic = new Logic();

            logic.SignUp(usr, first, last, password, confirm, email);
        }
    }
}
