﻿using System;
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
        
        private Logic lg = new Logic();
       
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);
            ((LinkButton)Master.FindControl("AdvancedSearch")).Click += new EventHandler(this.searchBtn_Click);
            (Master.FindControl("navigation_bar")).Visible = false;


            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Gainsboro;
            ((LinkButton)Master.FindControl("AddItem")).BackColor = Color.Gainsboro;

            


            if (!IsPostBack)
            {
              
                bind();
                //updating the subclasses droplist
                
               
            }

            
        }

        private void bind()
        {
            DataTable table = new DataTable();
            DataTable dt = lg.getImagesOfItem(Session["add_item"].ToString());

            //rotating the table:
    
                //Get all the rows and change into columns
                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    table.Columns.Add(Convert.ToString(i));
                    if (GridView1.Columns.Count <= i)
                    {
                        ImageField img_fld = new ImageField();
                        img_fld.DataImageUrlField = Convert.ToString(i);
                        
                        GridView1.Columns.Add(img_fld);
                    }
                }
                DataRow dr;
                //get all the columns and make it as rows
                dr = table.NewRow();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                   
                    dr[j] = dt.Rows[j][0];
                  
                   
                }
                table.Rows.Add(dr);
                GridView1.DataSource = table;
                GridView1.DataBind();

               
           
        }



        private void BindDropDownListToDataTable()
        {

            sub_classes_list.DataTextField = "sub_category";
            sub_classes_list.DataValueField = "sub_category";
            
            sub_classes_list.DataSource = lg.getAllSubCategory(classes_list.SelectedValue.ToString());
            sub_classes_list.DataBind();
             
        }

        protected void commit_cmd_Click(object sender, EventArgs e)
        {
                Item newItem = new Item();
                newItem.Usr=Session["usr"].ToString();
                newItem.Name=name_textBox.Text; 
                newItem.Clss=classes_list.SelectedValue.ToString();
                newItem.Sub_clss =sub_classes_list.SelectedValue.ToString();
                newItem.Comments=comnts_textBox.Text;
                newItem.Description=desc_textBox.Text;
                newItem.Id = Session["add_item"].ToString();
                
                lg.addItem(newItem);
                Response.Redirect("/BarterList.aspx");

         
        }








        protected void image_upload_cmd_Click(object sender, EventArgs e)
        {


        }
        protected void image_upload_Load(object sender, EventArgs e)
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

        //search button event handler
        void searchBtn_Click(Object sender, EventArgs e)
        {
            AddItem.Visible = false;

            ((LinkButton)Master.FindControl("MyAccount")).BackColor = Color.Transparent;
            ((LinkButton)Master.FindControl("AddItem")).BackColor = Color.Transparent;
        }

        protected void cancel_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BarterList.aspx");
        }

        protected void upload_cmd_Click(object sender, EventArgs e)
        {

            Boolean fileOK = false;
            if (image_upload.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(image_upload.FileName).ToLower();
                String[] allowedExtensions = {".jpg",".gif", ".png", ".jpeg"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
            }


            try
            {

              if (fileOK)
                {
                    string file_name = image_upload.FileName;

                    //saving original size image
                    string path = Server.MapPath("~/img/OriginalSize_" + file_name);
                    image_upload.PostedFile.SaveAs(path);



                    //saving display size copy
                    Bitmap target = FixedSize(System.Drawing.Image.FromFile(path), 225, 225) as Bitmap;
                    path = Server.MapPath("~/img/" + file_name);
                    target.Save(path);
                    int numOfPictures = lg.numOfImages(Session["add_item"].ToString());
                    int isProfile;
                    if (numOfPictures == 0)
                    {
                        isProfile = 1;
                    }
                    else
                        isProfile=0;
                    Imag img = new Imag(Session["add_item"].ToString(), "img/" + file_name, isProfile);
                    lg.addImage(img);
                }
               }
            catch (Exception ex)
            {
            }

            bind();
          
            
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
      

            if (e.CommandName == "Delete")
            {
             



            }




        
        }

      
        
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            bind();
        }

        protected void sub_classes_list_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        protected void classes_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownListToDataTable();
            
        }

        protected void classes_list_TextChanged(object sender, EventArgs e)
        {
            BindDropDownListToDataTable();
        }
    }
}