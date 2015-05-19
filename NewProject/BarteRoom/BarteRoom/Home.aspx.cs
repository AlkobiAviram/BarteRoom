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
            loginButton.Click += new EventHandler(this.GreetingBtn_Click);

        }


        private void run()
        {

        }



        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Write("good");
     
        }


        protected void LoginCloseButton_Click(object sender, EventArgs e)
        {
      
        }
    }
}
