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
                     <asp:Label ID="ItemName" runat="server" Text="Label"></asp:Label>
                </p>
            </div>
             <div class="row">
                <h3>Description</h3>
                   <p>
                      <asp:Label ID="ItemDscription" runat="server" Text="Label"></asp:Label>
                </p>
            </div>
                <div class="row">
                <h3>Make a Bid</h3>
                   <p>
                       <asp:Button ID="offer_cmd" runat="server" Text="Make a Bid" CssClass=" btn btn-primary" OnClick="offer_cmd_Click"/>
                </p>
            </div>
        </div>
        <div class="col-md-2">
          <div class="jumbotron">
              <h2>Side news</h2>
              <p> 
                  laurem ipsum laurem ipsum laurem ipsum <br />
                  laurem ipsum laurem ipsum laurem ipsum <br />
                  
<              </p>
          </div>
        
        </div>

</div>


</asp:Content>
