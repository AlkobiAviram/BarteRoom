<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="BarteRoom.viewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<link rel="stylesheet" type="text/css" href="mystyle.css">


    <div class="container">
    <div class="row">
        <div class="col-md-4">
            <h2>Image</h2>
            <asp:Image ID="item_pic" runat="server" />
        </div>
        <div class="col-md-4">
            <div class="row">
               <h3>name</h3>
                 <p>
                     <asp:Label ID="ItemName" runat="server" Text="Label"></asp:Label>
                </p>
            </div>
             <div class="row">
                <h3>Description</h3>
                   <p>
                      <asp:Label ID="ItemDscription" runat="server" Text="Label"></asp:Label>
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <h3>Side Bar</h3>
            <p>
                sideBar                
            </p>
        
    </div>

</div>


</asp:Content>
