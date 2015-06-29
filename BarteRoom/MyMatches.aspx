<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyMatches.aspx.cs" Inherits="BarteRoom.MyMatches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="advanced" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                
                        <asp:GridView ID="GridView1" BackColor="White"  CssClass="table table-responsive table-hover"  runat="server" AllowSorting="True"  AllowPaging="True"  AutoGenerateColumns="False" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting"  OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
                            <Columns>
                     
                                 <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                    <ItemTemplate>
                                 <asp:LinkButton ID="btnRandom8"  CssClass="change"  runat="server" CommandName="Delete" CommandArgument='<%# Bind("Your_Item" ) %>'  Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                                 </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                  <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                                  <asp:Label ID="Lbl1" runat="server" Text="Delete Item"></asp:Label></asp:LinkButton>
                                 </HeaderTemplate>
                                </asp:TemplateField> 
                     



                                 <asp:TemplateField HeaderText="Your Item" ShowHeader="False">
                               <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Your_item") %>' /> 
                               </ItemTemplate>
                                  <HeaderTemplate>
                                  <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-picture"></span>
                                  <asp:Label ID="Lbl1" runat="server" Text="Your Item"></asp:Label></asp:LinkButton>
                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            

                           <asp:TemplateField HeaderText="Parnter User" ShowHeader="False">
                               <ItemTemplate>
                               <asp:Label ID="Label3" runat="server" Text='<%# Bind("Partner_usr") %>'></asp:Label>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                  <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-user"></span>
                                  <asp:Label ID="Lbl1" runat="server" Text="Parnter User"></asp:Label></asp:LinkButton>
                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            


                           <asp:TemplateField HeaderText="His_Item" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("His_Item") %>' />

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom5" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-picture"></span>
                                  <asp:Label ID="Lbl3" runat="server" Text="His Item"></asp:Label></asp:LinkButton>

                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            




                           <asp:TemplateField HeaderText="Date" ShowHeader="False">
                               <ItemTemplate>
                                   <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date" ) %>'></asp:Label>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom6" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-time"></span>
                                  <asp:Label ID="Lbl4" runat="server" Text="Date"></asp:Label></asp:LinkButton>

                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            




                            </Columns>
                    </asp:GridView>

</asp:Content>
