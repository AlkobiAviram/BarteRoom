using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace BarteRoom
{
    public partial class Categories : System.Web.UI.Page
    {
        Logic lg = new Logic();
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkedList<string> cats = lg.getAllMainCategories();
            DataTable dt = lg.getAllSubCategory(cats.ElementAt(0).ToString());
            for(int i=0;i<dt.Rows.Count;i++){
                DataRow dr = dt.Rows[i];
                Button bt = new Button();
                bt.Text = dr[0].ToString();
                bt.ID = "cat" + i;
                bt.Visible = true;
                Main.Controls.Add(bt);
            }
        }
    }
}