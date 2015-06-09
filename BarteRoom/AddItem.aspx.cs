using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
// To store image file names to ArrayList
using System.Collections;
// To resize an image and store it to destination folder
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Drawing.Imaging;
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



                    //String path = "BarteRoom/img/" + Path.GetFileName(image_upload.PostedFile.FileName);
                   
                    lg = new Logic();
                    Item newItem = new Item(Session["usr"].ToString(), textBox_name.Value.ToString(), classes_list.SelectedValue.ToString(), textBox_comments.Value.ToString(), textBox_description.Value.ToString());
                    string path = Server.MapPath("~/img/" + image_upload.FileName);
                    image_upload.PostedFile.SaveAs(path);
                    lg.addImage(newItem.getId(), "img/" + image_upload.FileName);
                    lg.addItem(newItem);
                    Response.Redirect("BarterList.aspx");
                   
                }
                catch (Exception ex)
                {
                }
            }



        }
        



        protected void image_upload_cmd_Click(object sender, EventArgs e)
        {


        }
        protected void image_upload_Load(object sender, EventArgs e)
        {



        }
        public void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            if (OnlyResizeIfWider)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }

            int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            if (NewHeight > MaxHeight)
            {
                // Resize with height instead
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                NewHeight = MaxHeight;
            }

            System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();

            // Save resized picture
            NewImage.Save(NewFile);
        }

    }
}