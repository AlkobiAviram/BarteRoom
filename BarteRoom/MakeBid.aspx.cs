﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class MakeBid : System.Web.UI.Page
    {
        Logic lg = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("navigation_bar")).Visible = false;
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
        private LinkedList<string> getSelectedItems()
        {
            LinkedList<string> items = new LinkedList<string>();
            foreach(GridViewRow i in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)i.FindControl("checkBox");
                if (chk.Checked)
                {
                    if (!lg.isItemAlreadyBiddedByUsrOrOfferedToUsr(i.Cells[5].Text, Session["usr"].ToString(),"bid"))
                        items.AddLast(i.Cells[5].Text);
                    else
                        Response.Write("Item: " + i.Cells[5].Text + " already bidded before,therefore it will not be added");
                }
            }
            return items;
        }

        protected void commitBid_cmd_Click(object sender, EventArgs e)
        {
            LinkedList<string> items = getSelectedItems();
            string owner = lg.getItemById(Request.QueryString["id"].ToString()).Usr;
            Transaction trns = new Transaction(Request.QueryString["id"].ToString(), owner, Session["usr"].ToString(), items, comments_TextBox.Text);
            lg.addTransaction(trns);
            Response.Redirect("/Bids.aspx");
        }

        protected void comments_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}