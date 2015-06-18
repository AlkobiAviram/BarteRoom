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
                //setting the image slider images.
                //note: first i save a copy of a item's imagein 620x320 dimension and then displaies it in the image slider 
                string[] split = images.ElementAt(0).getPath().Split('/');
                Bitmap target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                string path = Server.MapPath("~/img/resizeImage0.jpg");
                target.Save(path);
                image1.ImageUrl = "img/resizeImage0.jpg";
                image1Link.Text = lg.getItemById(lg.getIdByImagePath(images.ElementAt(0).getPath())).getComments();
                string id = lg.getIdByImagePath(images.ElementAt(0).getPath());
                image1Link.NavigateUrl = "/ItemView.aspx?id=" + id;



                split = images.ElementAt(1).getPath().Split('/');
                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                path = Server.MapPath("~/img/resizeImage1.jpg");
                target.Save(path);
                image2.ImageUrl = "img/resizeImage1.jpg";
                image2Link.Text = lg.getItemById(lg.getIdByImagePath(images.ElementAt(1).getPath())).getComments();
                id = lg.getIdByImagePath(images.ElementAt(1).getPath());
                image2Link.NavigateUrl = "/ItemView.aspx?id=" + id;




                split = images.ElementAt(2).getPath().Split('/');
                target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap;
                path = Server.MapPath("~/img/resizeImage2.jpg");
                target.Save(path);
                image3.ImageUrl = "img/resizeImage2.jpg";
                image3Link.Text = lg.getItemById(lg.getIdByImagePath(images.ElementAt(2).getPath())).getComments();
                id = lg.getIdByImagePath(images.ElementAt(2).getPath());
                image3Link.NavigateUrl = "/ItemView.aspx?id=" + id;
           



              //  split = images.ElementAt(3).getPath().Split('/');
              //  target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap; path = Server.MapPath("~/img/resizeImage3.jpg");
               // target.Save(path);
               // img3333.ImageUrl = "~/img/resizeImage3.jpg";
               // img333.ImageUrl = "~/img/resizeImage3.jpg";



               // split = images.ElementAt(4).getPath().Split('/');
               // target = FixedSize(System.Drawing.Image.FromFile(Server.MapPath("img/OriginalSize_" + split[1])), 640, 320) as Bitmap; path = Server.MapPath("~/img/resizeImage4.jpg");
               // target.Save(path);
               // img44444.ImageUrl = "~/img/resizeImage4.jpg";
              //  img444.ImageUrl = "~/img/resizeImage4.jpg";

            }
            catch (Exception exp)
            {

            }
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
            //welcomeHome.Visible = false;
           // homePhotos.Visible = false;
        }

        protected void image3_Click(object sender, ImageClickEventArgs e)
        {
            string id = lg.getIdByImagePath(images.ElementAt(2).getPath());
            Response.Redirect("/ItemView.aspx?id=" + id);

        }

        protected void image2_Click(object sender, ImageClickEventArgs e)
        {
            string id = lg.getIdByImagePath(images.ElementAt(1).getPath());
            Response.Redirect("/ItemView.aspx?id=" + id);

        }

        protected void image1_Click(object sender, ImageClickEventArgs e)
        {
            string id = lg.getIdByImagePath(images.ElementAt(0).getPath());
            Response.Redirect("/ItemView.aspx?id=" + id);

        }
    }
}