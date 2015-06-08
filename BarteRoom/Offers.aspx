<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="BarteRoom.Offers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
        <div class="col-md-4">
            <div class="row">
                   <h1>Offers List</h1>
                <asp:GridView ID="GridViewOffers" CssClass="table table-responsive table-striped" runat="server">
                       <Columns>
                           <!--< need no add function  in GridView>-->
                           <asp:CommandField ButtonType="Button" HeaderText="View Bid" ShowSelectButton="True" />
                           <asp:BoundField DataField="Item BarCode" HeaderText="Item BarCode" />
                           <asp:BoundField DataField="Bid ID" HeaderText="Bid ID" />
                           <asp:BoundField DataField="Item Owner" HeaderText="Item Owner" />
                       </Columns>
                   </asp:GridView>
                                   
            </div>
        </div>

      </div>

</asp:Content>
