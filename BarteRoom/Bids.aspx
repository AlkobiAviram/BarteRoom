<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bids.aspx.cs" Inherits="BarteRoom.BidsOffersInbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div class="container">
        <div class="col-md-4">
            <div class="row">
               <h1>
                   <asp:GridView ID="GridView1" CssClass="table table-responsive table-striped" runat="server" AutoGenerateColumns="False" >
                       <Columns>
                           <asp:BoundField DataField="Item BarCode" HeaderText="Item BarCode" />
                           <asp:BoundField DataField="Bid ID" HeaderText="Bid ID" />
                           <asp:BoundField DataField="Item Owner" HeaderText="Item Owner" />
                       </Columns>
                   </asp:GridView>
                   Bids List</h1>
            </div>
        </div>

      </div>


 


</asp:Content>
