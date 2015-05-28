using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class BarterList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

         


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // If multiple buttons are used in a GridView control, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName.Equals("Delete"))
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                String id=GridView1.Rows[index].Cells[4].Text;
                Logic lg = new Logic();
                lg.removeItem(id);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void SQL_for_items_Deleting(object sender, SqlDataSourceCommandEventArgs e)
        {

        }
        private void BindGridViewData()
        {

           // GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees();
            //GridView1.DataBind();
        }




    }
}