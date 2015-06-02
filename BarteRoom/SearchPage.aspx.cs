using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    
    public partial class SearchPage : System.Web.UI.Page
    {
         Logic lg = new Logic();
         int choice = 0;
         string item_name = "";
         string item_class = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
        
            bind();
           }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
            }
        }


        private void bind()
        {

            GridView1.DataSource = lg.getDataSourceForItemsByChoice(choice, item_name,item_class);
            GridView1.DataBind();
        
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = Convert.ToInt32(e.NewSelectedIndex);
            GridViewRow row = GridView1.Rows[index];
            Session["item_id"] = row.Cells[6].Text;
            Response.Redirect("/ItemView.aspx");
            GridView1.EditIndex = -1;
            bind();
        }

        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void search_cmd_Click(object sender, EventArgs e)
        {
            
            choice = 1;
            item_name=SearchTextBox.Text;
            item_class=classes_list.Text;
            bind();
        }
  


        
    }
}