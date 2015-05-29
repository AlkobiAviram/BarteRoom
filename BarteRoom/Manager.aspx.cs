using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class Manager1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertNewManager_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["usr"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerUsr")).Text;
            SqlDataSource1.InsertParameters["pass"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerPass")).Text;
            SqlDataSource1.InsertParameters["name"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerName")).Text;
            SqlDataSource1.InsertParameters["email"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerEmail")).Text;

            SqlDataSource1.Insert();
        }
    }
}