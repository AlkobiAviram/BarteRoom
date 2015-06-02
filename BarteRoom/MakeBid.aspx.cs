using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class MakeBid : System.Web.UI.Page
    {
        Logic lg = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                bind();
            }
        }

        private void bind()
        {

            GridView1.DataSource = lg.getDataSourceForUsr(Session["usr"].ToString());
            GridView1.DataBind();

        }
    }
}