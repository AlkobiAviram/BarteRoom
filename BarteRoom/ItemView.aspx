<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="BarteRoom.viewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
    <div class="row">
        <div class="col-md-3 border-css">
            
            <asp:Image ID="item_pic" CssClass="img-responsive" runat="server" />
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
                       
                </p>
                    <p>
                        <asp:Button ID="BackToList" runat="server" Text="<< Back to list" CssClass=" btn btn-primary" OnClick="BackToList_Click"/>
                    </p>
            </div>
        </div>
        <div class="jumbotron">
              <h2>Side news</h2>
               <ul>
                   
                   <h4><li><a class="label label-info" href="#">Incoming Offers</a></li></h4>
                   <h4><li><a class="label label-primary" href="Home.aspx">Home</a></li></h4>
                   <h4><li><a class="label label-info" href="Gallery.aspx">Gallery</a></li></h4>
                   <h4><li><asp:HyperLink class="label label-primary" ID="contactUs" NavigateUrl="#contact" data-toggle="modal" runat="server">Contact Us</asp:HyperLink></li></h4>
                   <h4><li><a class="label label-info" href="index.html">Terms of Use</a></li></h4>
               </ul>
            <p> <br> <br> </p> <!--- /n/n --->
            
          </div>
        </div>

</div>


</asp:Content>
