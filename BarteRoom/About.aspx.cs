﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BarteRoom
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("AboutCmd")).BackColor = Color.Gainsboro;
            ((TextBox)Master.FindControl("SearchTextBox")).Visible = false; 
            ((DropDownList)Master.FindControl("catagories")).Visible = false;
            ((Button)Master.FindControl("Button1")).Visible = false; 
            ((LinkButton)Master.FindControl("AdvancedSearch")).Visible = false;
            ((GridView)Master.FindControl("homeGridView")).Visible = false;
            (Master.FindControl("navigation_bar")).Visible = false;

        }
    }
}