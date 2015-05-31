using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class BarterList2 : System.Web.UI.Page
    {
        private String name="";
        private String clas="";
        private String comments="";
        private String description="";
        private Logic lg;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void class_check_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void commit_cmd_Click(object sender, EventArgs e)
        {
            if (true)
            {
                lg = new Logic();
                lg.addItem(new Item(Session["usr"].ToString(), name, clas, comments, description, null));
                Response.Redirect("BarterList.aspx");

            }
            else
            {

            }

        }

        protected void name_textBox_TextChanged(object sender, EventArgs e)
        {
            name = name_textBox.Text;
        }

        protected void comments_textBox_TextChanged(object sender, EventArgs e)
        {
           

        }

        protected void description_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}