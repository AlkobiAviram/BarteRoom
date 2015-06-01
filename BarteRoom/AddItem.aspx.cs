using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
namespace BarteRoom
{
    public partial class BarterList2 : System.Web.UI.Page
    {

        private Logic lg;
        protected void Page_Load(object sender, EventArgs e)
        {


        }



        protected void commit_cmd_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            if (image_upload.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(image_upload.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {


                    byte[] pic = image_upload.FileBytes;
                    lg = new Logic();
                    lg.addItem(new Item(Session["usr"].ToString(), textBox_name.Value.ToString(), classes_list.SelectedValue.ToString(), textBox_comments.Value.ToString(), textBox_description.Value.ToString(), pic));
                    Response.Redirect("BarterList.aspx");

                }
                catch (Exception ex)
                {
                }
            }



        }
        private DataTable buildDT(byte[] pic)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("pic");
            dc.DataType = System.Type.GetType("System.Byte[]"); //Type byte[] to store image bytes.
            dc.AllowDBNull = true;

            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["pic"] = pic;
            dt.Rows.Add(dr);

            return dt;
        }



        protected void image_upload_cmd_Click(object sender, EventArgs e)
        {


        }
        protected void image_upload_Load(object sender, EventArgs e)
        {



        }

    }
}