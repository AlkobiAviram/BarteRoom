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

              //  string delete_id = e.CommandArgument.ToString();
                //lg.deleteMatch(delete_id);


            }
         
       
            if (e.CommandName == "Select")
            {
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = lg.getDataSourceForMyMatches(Session["usr"].ToString());
            int index = Convert.ToInt32(GridView1.SelectedIndex);
            string bidded_item_id = dt.Rows[index]["Bidded_item_id"].ToString();
            string offered_item_id = dt.Rows[index]["Offered_item_id"].ToString();
            lg.deleteMatch(bidded_item_id,offered_item_id);
            
            bind();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

           
        }

  

   
   

     

     

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
      
        }

    }
}