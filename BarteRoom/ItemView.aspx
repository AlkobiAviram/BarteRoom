<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="BarteRoom.viewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               <link href="imageHover.css" rel="stylesheet" type="text/css" runat="server"/>
                 <link href="imageHover.css" rel="stylesheet" type="text/css" runat="server"/>
   <div class="container" runat="server" id="itemViewPage">
    <div class="row">
        <div class="col-md-3 border-css">
            
             <div class="zoom_img" >
            <asp:Image  id="item_pic3" CssClass="img-responsive"  runat="server"/>
            <asp:FileUpload ID="newImage" runat="server" />
            <asp:Label ID="uploadNewImageLabel" Text="Upload new image" runat="server" />
            <asp:Button ID="edit_cmd" runat="server" CssClass="btn hvr-wobble-to-bottom-right" Text="Edit" OnClick="edit_cmd_Click" Height="26px" Width="158px"></asp:Button>
            <asp:Button ID="commit_cmd" runat="server" CssClass="btn-default" Visible="false" Text="Commit changes" OnClick="commit_cmd_Click"></asp:Button>
             <asp:Button ID="cancel_cmd" runat="server" CssClass="btn-default" Visible="false" Text="cancel" OnClick="cancel_cmd_Click" Width="114px"></asp:Button>
             </div>
        </div>
        <div class="col-md-6">
            <div class="row">
               <h3>name</h3>
                 <p>
                        <asp:TextBox  id="name_textBox" AutoPostBack="true" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" OnTextChanged="name_textBox_TextChanged"/>
                        <asp:Label ID="nameLabel" runat="server" />
                 </p>
            </div>
                <div class="row">
               <h3>Comments</h3>
                 <p>
                       <asp:TextBox id="comments_textBox" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" OnTextChanged="comments_textBox_TextChanged"/>
                       <asp:Label ID="comLabel" runat="server" />

                 </p>
            </div>
             <div class="row">
                <h3>Description</h3>
                   <p>
                        <asp:TextBox  id="description_textBox" TextMode="multiline" BorderStyle="Dashed" runat="server" OnTextChanged="description_textBox_TextChanged" />
                        <asp:Label ID="desLabel" runat="server" />
                     </p>
             </div>
             <div class="row">
                <h3>Item BarCode</h3>
                   <p>
                      
                        <asp:Label  id="idLabel1" runat="server"/>
                </p>
            </div>
                <div class="row">
                <h3> <asp:Label ID="makeBidHeader" Text="Make A Bid" runat="server" OnDataBinding="Page_Load"></asp:Label></h3>
                   <p>
                       <asp:Button ID="offer_cmd" runat="server" Text="Make a Bid" CssClass=" fa icon-next" OnClick="offer_cmd_Click"/>
                       <asp:Label ID="Label2" runat="server" Text="Please"></asp:Label>
                       <asp:HyperLink ID="logInHyperLink" runat="server" OnDataBinding="Page_Load" NavigateUrl="#login" data-toggle="modal" CssClass="change"> log in </asp:HyperLink>
                       <asp:Label ID="Label1" runat="server" Text="to make a bid"></asp:Label>

                </p>
                    <p>
                        <asp:Button ID="BackToList" runat="server" Text="<< Back to list" CssClass=" btn btn-primary" OnClick="BackToList_Click"/>
                    </p>
            </div>
        </div>
        <div class="col-md-2">
             
              <h2>Side news</h2>
               <ul class="list-group"> 
                  <li class="list-group-item"><a  href="#"><label>Incoming Offers</label></a></li>
                   <li class="list-group-item"><a  href="Home.aspx"><label>Home</label></a></li>
                   <li class="list-group-item"><asp:HyperLink  ID="contactUs" NavigateUrl="#contact" data-toggle="modal" runat="server"><label>Contact Us</label></asp:HyperLink></li>
                   <li class="list-group-item"><a  href="TermsOfUse.aspx"><label>Terms of Use</label></a></li>
               </ul>
           <br/> 
           <br/> <!--- /n/n --->
            
          </div>
        
      </div>
       

</div>


</asp:Content>
