using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BarteRoom
{
    public partial class BarterList1 : System.Web.UI.Page
    {
        Logic lg = new Logic();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Gainsboro;
            ((LinkButton)Master.FindControl("MyBarter")).BackColor = Color.Gainsboro;
            GridView1.RowStyle.Height = 50;
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
        /*
        protected void GridView1_SelectedIndexChanged(object sender,EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Logic lg = new Logic();
               // row.Cells[4].Text
            
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.sele];


        }
        */
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           // if (e.CommandName == "Update")
           // {
                      //Convert.ToInt16(e.CommandArgument);
             
            //}
            
            if (e.CommandName == "Delete")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
              

                // TextBox delete_id = new TextBox();
                string delete_id = row.Cells[7].Text;
                lg.removeItem(delete_id);

                
            }
            if (e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                //you must get the new values with textboxes..
                TextBox nm = new TextBox();
                TextBox cmt = new TextBox();
                TextBox dsct = new TextBox();
                TextBox ID = new TextBox();
                nm = (TextBox)GridView1.Rows[index].Cells[4].Controls[0];
                cmt = (TextBox)GridView1.Rows[index].Cells[5].Controls[0];
                dsct = (TextBox)GridView1.Rows[index].Cells[6].Controls[0];
                ID = (TextBox)GridView1.Rows[index].Cells[7].Controls[0];

                lg.editItem(nm.Text, cmt.Text, dsct.Text, ID.Text);
                GridView1.EditIndex = -1;    

            }
            if (e.CommandName == "Edit")
            {

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
        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = Convert.ToInt16(e.NewEditIndex);

            bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
           
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

       
            bind();
          //  Response.Redirect("/BarterList.aspx");
        }

        protected void index_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = Convert.ToInt32(e.NewSelectedIndex);
            GridViewRow row = GridView1.Rows[index];
            Session["item_id"] = row.Cells[7].Text;
            Response.Redirect("/ItemView.aspx");
            GridView1.EditIndex = -1;
            bind();

        }
      




    }
}