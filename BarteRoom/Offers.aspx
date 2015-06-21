<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="BarteRoom.Offers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
       .customTd {
           width:400px;
           height:400px;
    
       }
       .customTable{
          background-color:white;
          border:1px solid #4682B4;
       }
   </style>
<div class="container" runat="server" id="offerPage">
        <table>
            <tr>
                <td>
                  <h2><asp:Label ID="bid_header" Text="Offers List" Font-Bold="true" runat="server" /></h2> <br />
                <asp:GridView ID="GridView1" BackColor="White" CssClass="table table-responsive table-hover" GridLines="None" AutoGenerateColumns="False" runat="server" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
                       <Columns>
                           <asp:CommandField ButtonType="Button" SelectText="View" HeaderText="View Bid" ShowSelectButton="True">
                                 <ControlStyle CssClass="btn hvr hvr-wobble-to-bottom-right"></ControlStyle>
                           </asp:CommandField>
                           <asp:BoundField DataField="Bid ID" HeaderText="Bid ID" />
                           <asp:BoundField DataField="Item BarCode" HeaderText="Offered Item BarCode" />
                           <asp:ImageField DataImageUrlField="Item Image" HeaderText="Offered Item Image"/>
                           <asp:BoundField DataField="Bidder" HeaderText="Bidder" />
                           <asp:BoundField DataField="Comments" HeaderText="Comments" />
                           <asp:BoundField DataField="Seen" HeaderText="Seen" />
                           <asp:BoundField DataField="Date Created" HeaderText="Date Submitted"/>
                       </Columns>
                   </asp:GridView>
                    </td>
              </tr>                     
         </table>
      </div>

</asp:Content>
