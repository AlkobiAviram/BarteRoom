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
     
                GridView1.DataSource = lg.getDataSource(Session["usr"].ToString());
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
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int x = e.RowIndex;
         
            TextBox delete_id = new TextBox();
            delete_id = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
            lg.removeItem(delete_id.Text);
            GridView1.EditIndex = -1;
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
        
     
            GridViewRow row = GridView1.Rows[e.RowIndex];
            //you must get the new values with textboxes..
            TextBox nm = new TextBox();
            TextBox cmt = new TextBox();
            TextBox dsct = new TextBox();
            TextBox ID = new TextBox();
            nm = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            cmt = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            dsct = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
            ID = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
           
            lg.editItem(nm.Text, cmt.Text, dsct.Text, ID.Text);
            GridView1.EditIndex = -1;
            bind();
           
        }

        protected void index_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();

        }






    }
}