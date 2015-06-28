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
        <asp:GridView ID="GridView1" BackColor="White" CssClass="table table-responsive table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True">
                       <Columns>

                          
                          
                           <asp:TemplateField HeaderText="Item_Image" ShowHeader="False">
                               <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton3" CommandName="Select" runat="server"><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Item_Image") %>' /> </asp:LinkButton>
                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"    >
                                <span aria-hidden="true" class="glyphicon glyphicon-picture"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl1" runat="server" Text="Item image"></asp:Label>
                                 </HeaderTemplate>
                           </asp:TemplateField> 
                            
                           <asp:TemplateField HeaderText="Bidder" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" CommandName="Select" runat="server"><asp:Label ID="Label3" runat="server" Text='<%# Bind("Bidder") %>'></asp:Label></asp:LinkButton>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom4" runat="server" CssClass="btn btn-primary"    >
                                <span aria-hidden="true" class="glyphicon glyphicon-user"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl2" runat="server" Text="Bidder"></asp:Label>

                                 </HeaderTemplate>
                           </asp:TemplateField> 
                            
                           <asp:TemplateField HeaderText="Comments" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" CommandName="Select" runat="server"><asp:Label ID="Label4" runat="server" Text='<%# Bind("Comments") %>'></asp:Label></asp:LinkButton>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom5" runat="server" CssClass="btn btn-primary"    >
                                <span aria-hidden="true" class="glyphicon glyphicon-comment"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl3" runat="server" Text="Comments"></asp:Label>

                                 </HeaderTemplate>
                           </asp:TemplateField> 
                            




                           <asp:TemplateField HeaderText="Seen" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton6" CommandName="Select" runat="server"><asp:Label ID="Label5" runat="server" Text='<%# Bind("Seen" ) %>'></asp:Label></asp:LinkButton>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom6" runat="server" CssClass="btn btn-primary"    >
                                <span aria-hidden="true" class="glyphicon glyphicon-eye-open"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl4" runat="server" Text="Seen"></asp:Label>

                                 </HeaderTemplate>
                           </asp:TemplateField> 
                            



                           <asp:TemplateField HeaderText="Date_Created" ShowHeader="False"> 
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton7" CommandName="Select" runat="server"><asp:Label ID="Label6" runat="server" Text='<%# Bind("Date_Created") %>' ></asp:Label></asp:LinkButton>
                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom7" runat="server" CssClass="btn btn-primary"    >
                                <span aria-hidden="true" class="glyphicon glyphicon-time"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl5" runat="server" Text="Date"></asp:Label>

                                 </HeaderTemplate>
                           </asp:TemplateField> 
                            
                                
                            <asp:TemplateField HeaderText="Bid_ID" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandName="Select" runat="server"><asp:Label ID="Label1" runat="server" Text='<%# Bind("Bid_ID") %>'></asp:Label></asp:LinkButton>
                                
                                </ItemTemplate>
                                <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom1" runat="server" CssClass="btn btn-primary"    >
                                <span aria-hidden="true" class="glyphicon glyphicon-asterisk"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl6" runat="server" Text="Bid ID"></asp:Label>
                                 
                                </HeaderTemplate>
                           </asp:TemplateField>





                           <asp:TemplateField HeaderText="Item_BarCode" ShowHeader="False"> 
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" CommandName="Select" runat="server"><asp:Label ID="Label2" runat="server" Text='<%# Bind("Item_BarCode") %>' ></asp:Label></asp:LinkButton>
                                                                                                                                                                                        
                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom2" runat="server" CssClass="btn btn-primary">
                                <span aria-hidden="true" class="glyphicon glyphicon-barcode"></span>
                                 </asp:LinkButton><br />
                                  <asp:Label ID="Lbl7" runat="server" Text="Item BarCode"></asp:Label>
                                 </HeaderTemplate>
                           </asp:TemplateField>
                              
                       </Columns>
                   </asp:GridView>
                    </td>
              </tr>                     
         </table>
      </div>

</asp:Content>
