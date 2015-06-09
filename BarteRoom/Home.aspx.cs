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
        private Logic lg=new Logic();
        private LinkedList<Imag> images;
        protected void Page_Load(object sender, EventArgs e)
        {
            //setting the image slider images
                images = lg.getAllImages();
                string URL = "~/" + images.ElementAt(0).getPath();
           
                img0.Src = URL;
               img000.Src = URL;
                URL = "~/" + images.ElementAt(1).getPath(); 
                img1.Src = URL;
                img11.Src = URL;
                URL = "~/" + images.ElementAt(2).getPath(); 
                img2.Src = URL;
                img22.Src = URL;
                URL = "~/" + images.ElementAt(3).getPath(); 
                img3.Src = URL;
                img33.Src = URL;
                URL = "~/" + images.ElementAt(4).getPath(); 
                img4.Src = URL;
                img44.Src = URL;

            
            
        }
        protected void ImgButton0_ServerClick(Object sender, ImageClickEventArgs e)
        {
             images = lg.getAllImages();
             Session["item_id"] = images.ElementAt(0).getId();
             Response.Redirect("/ItemView.aspx");
        }
 

    }
}