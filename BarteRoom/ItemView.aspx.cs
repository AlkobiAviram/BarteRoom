using System;
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
using System.Data;
namespace BarteRoom
{
    public partial class viewItem : System.Web.UI.Page
    {
        Logic lg = new Logic();
        string id = "";
        string bid_id = "";
        string bid_type = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //searech button event catch
            ((Button)Master.FindControl("Button1")).Click += new EventHandler(this.searchBtn_Click);
            ((LinkButton)Master.FindControl("AdvancedSearch")).Click += new EventHandler(this.searchBtn_Click);
            (Master.FindControl("navigation_bar")).Visible = false;
          
            //setting image
              if (Request.QueryString["id"] != null){
                  id = Request.QueryString["id"].ToString();
                  Session["item_id"] = Request.QueryString["id"].ToString();
               }  
              else
              {
                  id = Session["item_id"].ToString(); 
              }
            string[] split;
            if (lg.setImagePath(id) != "" && lg.setImagePath(id)!=null)
            { 
            split = lg.setImagePath(id).Split('/');
            item_pic3.ImageUrl = "img/OriginalSize_" + split[1];        
            }
            //setting labels
            Item item = lg.getItemById(id);
            item.Id=id;
      
            nameLabel.Text = item.Name;   
            comLabel.Text = item.Comments;
            idLabel1.Text = item.Id;  
            desLabel.Text=item.Description;
            main_category_label.Text = item.Clss;
            sub_category_header.Text = item.Sub_clss;
            name_header.Text = "Item Name";
            comments_header.Text = "Comments";
            description_header.Text = "Description";
            itemId_header.Text = "Item Bar-Code";
            sub_category_header.Text = "Sub Category";
            main_category_header.Text = "main Category";


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

                if (Session["usr"].ToString() == item.Usr)//this means that the item is owned by the user who logged in
                {
                    edit_cmd.Visible = true;
                    offer_cmd.Visible = false;
                    makeBidHeader.Visible = false;
                    //checking for offers
                      if (lg.isItemAlreadyBiddedByUsrOrOfferedToUsr(id, Session["usr"].ToString(), "offer")) //this means that the user who logged in has an offer on that item
                         {
                             edit_cmd.Visible = false;
                             offer_cmd.Visible = false;
                             viewTransaction_cmd.Visible = true;
                             makeBidHeader.Visible = true;
                             makeBidHeader.Text = "You Have An Offer On That Item!";
                             bid_id = lg.getBidIdByBidderOrOwner(id, Session["usr"].ToString(), "offer");
                             bid_type = "offer";
                        }




                }
                else if (lg.isItemAlreadyBiddedByUsrOrOfferedToUsr(id, Session["usr"].ToString(), "bid")) //this means that the user who logged in bidded before on that item
                {
                    edit_cmd.Visible = false;
                    offer_cmd.Visible = false;
                    viewTransaction_cmd.Visible = true;
                    makeBidHeader.Visible = true;
                    makeBidHeader.Text = "You Bidded on The Item!";
                    bid_id = lg.getBidIdByBidderOrOwner(id, Session["usr"].ToString(), "bid");
                    bid_type = "bid";
                }
              
                else//this means that the item is not owned by the user who logged in
                {
                    edit_cmd.Visible = false;
                    offer_cmd.Visible = true;
                    makeBidHeader.Visible = true;
                }
            }

           
                bind();
            
        }
        private void bind()
        {
  
            DataTable dt = lg.getImagesOfItem(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ImageButton bt=new ImageButton();
                bt.ImageUrl = dt.Rows[i][0].ToString();
                bt.ID=""+i;
                bt.CssClass="natiImage";
                bt.Click+=new ImageClickEventHandler(pic_Click);
                images.Controls.Add(bt);
                images.Controls.Add(new LiteralControl("&nbsp"));
                images.Controls.Add(new LiteralControl("&nbsp"));
            }

        }
        protected void pic_Click(object sender, EventArgs e)
        {
            DataTable dt = lg.getImagesOfItem(id);
            string imgPath=dt.Rows[Convert.ToInt32(((ImageButton)sender).ID)][0].ToString();
            item_pic3.ImageUrl = imgPath;



        }
        protected void offer_cmd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MakeBid.aspx?" + "id=" + Request.QueryString["id"].ToString());
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
            Item item = lg.getItemById(id);
            item.Id=id;
            name_textBox.Text = item.Name;
            name_textBox.Visible = true;


            comments_textBox.Text = item.Comments;
            comments_textBox.Visible = true;

            description_textBox.Text = item.Description;
            description_textBox.Height = 400;
            description_textBox.Width = 400;
            description_textBox.Visible = true;

         
          
            
            desLabel.Visible = false;
            nameLabel.Visible = false;
            comLabel.Visible=false;
            main_category_label.Visible = false;
            sub_category_label.Visible = false;

            commit_cmd.Visible = true;
            cancel_cmd.Visible = true;
            edit_cmd.Visible = false;


            newImage.Visible = true;
            uploadNewImageLabel.Visible = true;

            item_pic3.Visible=false;
        }

        protected void commit_cmd_Click(object sender, EventArgs e)
        {
           


            lg.editItem(name_textBox.Text, comments_textBox.Text, description_textBox.Text, id);
            comments_textBox.Visible = false;
            name_textBox.Visible = false;
            description_textBox.Visible = false;
            newImage.Visible = false;
            uploadNewImageLabel.Visible = false;

            desLabel.Visible = true;
            nameLabel.Visible = true;
            comLabel.Visible = true;
            main_category_label.Visible = true;
            sub_category_label.Visible = true;

            commit_cmd.Visible = false;
            cancel_cmd.Visible = false;
            edit_cmd.Visible = true;


            Response.Redirect("/ItemView.aspx?id="+id);
       
        }

        protected void cancel_cmd_Click(object sender, EventArgs e)
        {
            comments_textBox.Visible = false;
            name_textBox.Visible = false;
            description_textBox.Visible = false;
            newImage.Visible = false;
            uploadNewImageLabel.Visible = false;

            desLabel.Visible = true;
            nameLabel.Visible = true;
            comLabel.Visible = true;
            main_category_label.Visible = true;
            sub_category_label.Visible = true;

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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // if (e.CommandName == "Update")
            // {
            //Convert.ToInt16(e.CommandArgument);

            //}

            if (e.CommandName == "Delete")
            {
                /*
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];


                // TextBox delete_id = new TextBox();
                string delete_id = row.Cells[6].Text;
                lg.removeItem(delete_id);

                */
            }
            

            
          
            if (e.CommandName == "Select")
            {
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            /*
            int index = Convert.ToInt32(e.NewSelectedIndex);
            GridViewRow row = GridView1.Rows[index];
            string id = row.Cells[6].Text;
            Response.Redirect("/ItemView.aspx?" + "id=" + Server.UrlEncode(id));
            GridView1.EditIndex = -1;
            bind();
            */
        }
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            bind();
        }

        protected void description_tab_Click(object sender, EventArgs e)
        {
            main_category_label.Visible = true;
            main_category_header.Visible = true;
            sub_category_label.Visible = true;
            sub_category_header.Visible = true;
            

            Item item = lg.getItemById(id);
            item.Id = id;
            nameLabel.Text = item.Name;
            comLabel.Text = item.Comments;
            idLabel1.Text = item.Id;
            desLabel.Text = item.Description;
            main_category_label.Text = item.Clss;
            sub_category_header.Text = item.Sub_clss;
            name_header.Text = "Item Name";
            comments_header.Text = "Comments";
            description_header.Text = "Description";
            itemId_header.Text = "Item Bar-Code";
            sub_category_header.Text = "Sub Category";
            main_category_header.Text = "main Category";



        }

        protected void OwnerInformation_tab_Click(object sender, EventArgs e)
        {

           
            string owner = lg.getItemById(id).Usr;
            User usr = lg.getUserInformation(owner);
            nameLabel.Text=usr.Usr;
            comLabel.Text =usr.FullName;
            desLabel.Text =  usr.Email;


            name_header.Text = "Owner User Name";
            comments_header.Text = "Owner Full Name";
            description_header.Text = "Owner Email Address";

            main_category_label.Visible = false;
            main_category_header.Visible = false;
            sub_category_label.Visible = false;
            sub_category_header.Visible = false;

          
        }

        protected void viewTransaction_cmd_Click(object sender, EventArgs e)
        {
            Session["transaction_type"] = bid_type;
            Session["bid_id"] = bid_id;
            Response.Redirect("/TransactionView.aspx");
        }

        protected void Upload_cmd_Click(object sender, EventArgs e)
        {
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


                    lg.addImage(new Imag(Request.QueryString["id"].ToString(), "img/" + file_name, 0));


                }
                catch (Exception ex)
                {
                }
                bind();
            }
        }

    }
}