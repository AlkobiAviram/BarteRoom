using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
// To open image files from directory
using System.IO;
// To store image file names to ArrayList
using System.Collections;
// To resize an image and store it to destination folder
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BarteRoom
{
    public partial class Home1 : System.Web.UI.Page
    {
        public static Logic lg = new Logic();
        public static LinkedList<Imag> images = lg.getAllImages();

        protected void Page_Load(object sender, EventArgs e)
        {
            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);
            
            try
            {
               //////////setting image slider////////////////////////////////////////////////////////////////
                //setting the image slider images.
                //note: first i save a copy of a item's imagein 640x320 dimension and then displaies it in the image slider 
                string[] split = images.ElementAt(0).Path.Split('/');
                Bitmap target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                string path = Server.MapPath("~/img/resizeImage0.jpg");
                target.Save(path);

                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 100, 100) as Bitmap;
                path = Server.MapPath("~/img/resizeImage_tab0.jpg");
                target.Save(path);

                ImageButton1.ImageUrl = "img/resizeImage_tab0.jpg";
                slider.ImageUrl = "img/resizeImage0.jpg";

            



                split = images.ElementAt(1).Path.Split('/');
                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                path = Server.MapPath("~/img/resizeImage1.jpg");
                target.Save(path);

                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 100, 100) as Bitmap;
                path = Server.MapPath("~/img/resizeImage_tab1.jpg");
                target.Save(path);

                ImageButton2.ImageUrl = "img/resizeImage_tab1.jpg";


         



                split = images.ElementAt(2).Path.Split('/');
                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                path = Server.MapPath("~/img/resizeImage2.jpg");
                target.Save(path);

                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 100, 100) as Bitmap;
                path = Server.MapPath("~/img/resizeImage_tab2.jpg");
                target.Save(path);

                ImageButton3.ImageUrl = "img/resizeImage_tab2.jpg";





                split = images.ElementAt(3).Path.Split('/');
                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                path = Server.MapPath("~/img/resizeImage3.jpg");
                target.Save(path);

                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 100, 100) as Bitmap;
                path = Server.MapPath("~/img/resizeImage_tab3.jpg");
                target.Save(path);

                ImageButton4.ImageUrl = "img/resizeImage_tab3.jpg";

                
///////////////////////////////////////////////////////////////////////////////////////////
/////////////////////setting categories
                LinkedList<string> categories = lg.getAllMainCategories();
                cat1.Text = categories.ElementAt(0).ToString();
                cat2.Text = categories.ElementAt(1).ToString();
                cat3.Text = categories.ElementAt(2).ToString();
                cat4.Text = categories.ElementAt(3).ToString();
                cat5.Text = categories.ElementAt(4).ToString();
                cat6.Text = categories.ElementAt(5).ToString();
                cat7.Text = categories.ElementAt(6).ToString();
            }
            catch (Exception exp)
            { }

       
            if (!IsPostBack)
            {

                bind();
            }
                 
        }
        private void bind()
        {

            GridView1.DataSource = lg.getDataSourceForMostViewedItems();
            GridView1.DataBind();
      

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
            }
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = Convert.ToInt32(e.NewSelectedIndex);
            GridViewRow row = GridView1.Rows[index];

            Response.Redirect("/ItemView.aspx?id=" + row.Cells[2].Text);
            GridView1.EditIndex = -1;
            bind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        static System.Drawing.Image FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
           
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
      //  protected void img0_
            
        protected void viewItem_cmd_Click(object sender, EventArgs e)
        {
    
            /*
            if (label0.TagName )
            {
                  Session["item_id"] = getImageId(0);
            }
            else if(id2.Checked)
            {
                Session["item_id"] = getImageId(1);
            }
            else if (id3.Checked)
            {
                Session["item_id"] = getImageId(2);
            }
            else if (id4.Checked)
            {
                Session["item_id"] = getImageId(3);
            }
            else if (id5.Checked)
            {
                Session["item_id"] = getImageId(4);
            }
            Response.Redirect("/ItemView.aspx");
             */
        }

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            welcomeHome.Visible = false;
        }

        protected void slider_Click(object sender, ImageClickEventArgs e)
        {
            int slider_img_num;
            if (Session["slider_img_num"] == null)
                slider_img_num = 0;
            else
                slider_img_num = Convert.ToInt32(Session["slider_img_num"].ToString());
            Response.Redirect("/ItemView.aspx?id=" + lg.getIdByImagePath(images.ElementAt(slider_img_num).Path));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["slider_img_num"] = 0;
            slider.ImageUrl = "img/resizeImage0.jpg";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["slider_img_num"] = 1;
            slider.ImageUrl = "img/resizeImage1.jpg";
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["slider_img_num"] = 2;
            slider.ImageUrl = "img/resizeImage2.jpg";
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Session["slider_img_num"] = 3;
            slider.ImageUrl = "img/resizeImage3.jpg";
        }

        protected void cat1_Click(object sender, EventArgs e)
        {
           // ((Button)Master.FindControl("Button1")).Click(this, EventArgs.Empty);
            //cat1_Click(null, EventArgs.Empty);
           // Master.Server.
        }

    }
}