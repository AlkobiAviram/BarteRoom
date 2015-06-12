<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="BarteRoom.viewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               <link href="imageHover.css" rel="stylesheet" type="text/css" runat="server"/>
   <div class="container">
    <div class="row">
        <div class="col-md-3 border-css">
            
             <div class="zoom_img" >
            <asp:Image  id="item_pic3" CssClass="img-responsive"  runat="server"/>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
               <h3>name</h3>
                 <p>
                     <asp:Label ID="itemName" runat="server"></asp:Label>
                </p>
            </div>
             <div class="row">
                <h3>Description</h3>
                   <p>
                       <asp:Label ID="itemDescription" runat="server"></asp:Label>
                </p>
                <h3>Item BarCode</h3>
                   <p>
                      <asp:Label ID="itemBarCode" runat="server" OnDataBinding="Page_Load"></asp:Label>
                </p>
            </div>
                <div class="row">
                <h3>Make a Bid</h3>
                   <p>
                       <asp:Button ID="offer_cmd" runat="server" Text="Make a Bid" CssClass=" btn btn-success" OnClick="offer_cmd_Click"/>
                       <asp:Label ID="makeBidLabel" runat="server" OnDataBinding="Page_Load"></asp:Label>

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
                   <li class="list-group-item"><a  href="index.html"><label>Terms of Use</label></a></li>
               </ul>
           <br/> 
           <br/> <!--- /n/n --->
            
          </div>
        
      </div>
       

</div>


</asp:Content>
