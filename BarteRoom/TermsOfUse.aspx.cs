﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class TermsOfUse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("navigation_bar")).Visible = false;
        }
    }
}