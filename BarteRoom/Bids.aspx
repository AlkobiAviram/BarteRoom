﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bids.aspx.cs" Inherits="BarteRoom.BidsOffersInbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div class="container" runat="server" id="BidsPage">
            <table>
            <tr>
                <td>
                  <h2><asp:Label ID="bid_header" Text="Bids List" Font-Bold="true" runat="server" /></h2> <br />
                   <asp:GridView ID="GridView1" BackColor="White" CssClass="table table-responsive table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
                       <Columns>
                           <asp:CommandField ButtonType="Button" SelectText="View" HeaderText="View Bid" ShowSelectButton="True">
                              <ControlStyle CssClass="btn hvr hvr-wobble-to-bottom-right"></ControlStyle>
                           </asp:CommandField>
                           <asp:BoundField DataField="Bid ID" HeaderText="Bid ID" />
                           <asp:BoundField DataField="Item BarCode" HeaderText="Bidded Item BarCode" />
                           <asp:ImageField DataImageUrlField="Item Image" HeaderText="Bidded Item Image" />                      
                           <asp:BoundField DataField="Item Owner" HeaderText="Item Owner" />
                           <asp:BoundField DataField="Comments" HeaderText="Comments" />
                           <asp:BoundField DataField="Seen" HeaderText="Seen" />                       
                           <asp:BoundField DataField="Date Created" HeaderText="Date Submitted" />
                       </Columns>
                   </asp:GridView>
                   </td>
              </tr>                     
         </table> 
            </div>
        </div>

      </div>


 


</asp:Content>
