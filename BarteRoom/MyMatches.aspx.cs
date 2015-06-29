using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace BarteRoom
{
    public partial class MyMatches : System.Web.UI.Page
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

            GridView1.DataSource = lg.getDataSourceForMyMatches(Session["usr"].ToString());
            GridView1.DataBind();

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // if (e.CommandName == "Update")
            // {
            //Convert.ToInt16(e.CommandArgument);

            //}

            if (e.CommandName == "Delete")
            {

                string delete_id = e.CommandArgument.ToString();
                lg.deleteMatch(delete_id);


            }
         
       
            if (e.CommandName == "Select")
            {
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            bind();
        }

  

   
   

     

     

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DataTable dt = lg.getDataSourceForUsr(Session["usr"].ToString());
            int index = Convert.ToInt32(e.NewSelectedIndex);
            string id = dt.Rows[index]["id"].ToString();
            lg.AddView(id);
            Response.Redirect("/ItemView.aspx?" + "id=" + Server.UrlEncode(id));
            GridView1.EditIndex = -1;
            bind();

        }

    }
}