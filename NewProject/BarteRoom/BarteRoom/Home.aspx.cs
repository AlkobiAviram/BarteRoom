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
        protected void Page_Load(object sender, EventArgs e)
        {
            String user_name = loginUserNameTxtBox.Value;
            String password = loginPasswordTxtBox.Value;
            Logic lg = new Logic();
            if (lg.Login(user_name, password))
            {

            }
            else
            {

            }
        }


    }
}
