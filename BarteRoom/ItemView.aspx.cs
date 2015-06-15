﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// To resize an image and store it to destination folder
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Drawing.Imaging;
namespace BarteRoom
{
    public partial class viewItem : System.Web.UI.Page
    {
        Logic lg = new Logic();
        protected void Page_Load(object sender, EventArgs e)
        {

            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);

            //setting image 
            string[] split = lg.setImagePath(Session["item_id"].ToString()).Split('/');
            item_pic3.ImageUrl = "img/OriginalSize_" + split[1];        

            //setting labels
            Item item = lg.getItemById(Session["item_id"].ToString());
            
      
            nameLabel.Text = item.getName();   
            comLabel.Text = item.getComments();
            idLabel1.Text = item.getId();  
            desLabel.Text=item.getDescription();

            if (!IsPostBack)
            {
                comments_textBox.Visible = false;
                name_textBox.Visible = false;
                description_textBox.Visible = false;
                edit_cmd.Visible = false;
                newImage.Visible = false;
                uploadNewImageLabel.Visible = false;

            }
            //checking if the user logged in
            if (Session["usr"] == null)
            {
                Label1.Visible = true;
                logInHyperLink.Visible = true;
                Label2.Visible = true;
                offer_cmd.Visible = false;

            }
            else//a user has logged in
            {
                Label1.Visible = false;
                logInHyperLink.Visible = false;
                Label2.Visible = false;
                offer_cmd.Visible = true;

                if (Session["usr"].ToString() == item.getUsr())//this means that the item is owned by the user who logged in
                {
                    edit_cmd.Visible = true;
                    offer_cmd.Visible = false;
                    makeBidHeader.Visible = false;
                }
                else//this means that the item is not owned by the user who logged in
                {
                    edit_cmd.Visible = false;
                    offer_cmd.Visible = true;
                    makeBidHeader.Visible = true;
                }
            }

         
        }

        protected void offer_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MakeBid.aspx");
        }
        private int numOfRows(string str)
        {
      
            return str.Split('.').Length;
        }
        
        private int maxLineLength(string str)
        {
            int max=0;
            string[] split=str.Split('\n');
            if (split.Length == 0)
                return str.Length;
           for(int i = 0;i<split.Length;i++){
               if(split[i].Length>max)
                   max=split[i].Length;
           }
            return max;
        }
        protected void BackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }

        protected void edit_cmd_Click(object sender, EventArgs e)
        {
            Logic lg_temp = new Logic();
            Item item = lg.getItemById(Session["item_id"].ToString());
            name_textBox.Text = item.getName();
            name_textBox.Visible = true;


            comments_textBox.Text = item.getComments();
            comments_textBox.Visible = true;

            description_textBox.Text = item.getDescription();
            description_textBox.Height = 400;
            description_textBox.Width = 400;
            description_textBox.Visible = true;

         
          
            
            desLabel.Visible = false;
            nameLabel.Visible = false;
            comLabel.Visible=false;


            commit_cmd.Visible = true;
            cancel_cmd.Visible = true;
            edit_cmd.Visible = false;


            newImage.Visible = true;
            uploadNewImageLabel.Visible = true;
            
        }

        protected void commit_cmd_Click(object sender, EventArgs e)
        {
            
           
            lg.editItem(name_textBox.Text, comments_textBox.Text, description_textBox.Text, Session["item_id"].ToString());
            comments_textBox.Visible = false;
            name_textBox.Visible = false;
            description_textBox.Visible = false;
            newImage.Visible = false;
            uploadNewImageLabel.Visible = false;

            desLabel.Visible = true;
            nameLabel.Visible = true;
            comLabel.Visible = true;

            commit_cmd.Visible = false;
            cancel_cmd.Visible = false;
            edit_cmd.Visible = true;



            //upload new image:
            Boolean fileOK = false;
            if (newImage.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(newImage.FileName).ToLower();
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
                    string file_name = newImage.FileName;

                    //saving original  size image
                    string path = Server.MapPath("~/img/OriginalSize_" + file_name);
                    newImage.PostedFile.SaveAs(path);



                    //saving display size copy
                    Bitmap target = FixedSize(System.Drawing.Image.FromFile(path), 225, 225) as Bitmap;
                    path = Server.MapPath("~/img/" + file_name);
                    target.Save(path);

                    lg.uploadNewImage(Session["item_id"].ToString(), "img/" + file_name);
                    
                    Response.Redirect("/BarterList.aspx");

                }
                catch (Exception ex)
                {
                }
            }















            Response.Redirect("/ItemView.aspx");
        }

        protected void cancel_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ItemView.aspx");
            comments_textBox.Visible = false;
            name_textBox.Visible = false;
            description_textBox.Visible = false;
            newImage.Visible = false;
            uploadNewImageLabel.Visible = false;

            desLabel.Visible = true;
            nameLabel.Visible = true;
            comLabel.Visible = true;


            commit_cmd.Visible = false;
            cancel_cmd.Visible = false;
            edit_cmd.Visible = true;
        }

        protected void description_textBox_TextChanged(object sender, EventArgs e)
        {
         
        }
        protected void comments_textBox_TextChanged(object sender, EventArgs e)
        {
     
        }
        protected void name_textBox_TextChanged(object sender, EventArgs e)
        {

      
        }

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            itemViewPage.Visible = false;
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



    }
}