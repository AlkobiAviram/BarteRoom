    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
            <div class="row" runat="server" id="sideBar">
               
              
                    
                        <asp:GridView ID="GridView1" BackColor="White"  CssClass="table table-responsive table-hover"  runat="server" AllowSorting="True"  AllowPaging="True"  AutoGenerateColumns="False" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowUpdated="GridView1_RowUpdated" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
                            <Columns>
                     

                                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                    <ItemTemplate>
                                 <asp:LinkButton ID="btnRandom8"  CssClass="change"  runat="server" CommandName="Delete" CommandArgument='<%# Bind("id") %>'  Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                                 </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                  <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                                  <asp:Label ID="Lbl1" runat="server" Text="Delete Item"></asp:Label></asp:LinkButton>
                                 </HeaderTemplate>
                                </asp:TemplateField> 



                                 <asp:TemplateField HeaderText="Image" ShowHeader="False">
                               <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton3"  CssClass="change"  CommandName="Select" runat="server"><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' /> </asp:LinkButton>
                               </ItemTemplate>
                                  <HeaderTemplate>
                                  <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-picture"></span>
                                  <asp:Label ID="Lbl1" runat="server" Text="Item image"></asp:Label></asp:LinkButton>
                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            

                           <asp:TemplateField HeaderText="Name" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4"  CssClass="change"  CommandName="Select" runat="server"><asp:Label ID="Label3" runat="server" Text='<%# Bind("Name") %>'></asp:Label></asp:LinkButton>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                  <asp:LinkButton ID="btnRandom3" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-font"></span>
                                  <asp:Label ID="Lbl1" runat="server" Text="Name"></asp:Label></asp:LinkButton>
                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            
                           <asp:TemplateField HeaderText="Comments" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" CssClass="change"  CommandName="Select" runat="server"><asp:Label ID="Label4" runat="server" Text='<%# Bind("Comments") %>'></asp:Label></asp:LinkButton>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom5" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-comment"></span>
                                  <asp:Label ID="Lbl3" runat="server" Text="Comments"></asp:Label></asp:LinkButton>

                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            




                           <asp:TemplateField HeaderText="Seen" ShowHeader="False">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton6" CssClass="change"  CommandName="Select" runat="server"><asp:Label ID="Label5" runat="server" Text='<%# Bind("id" ) %>'></asp:Label></asp:LinkButton>

                               </ItemTemplate>
                                  <HeaderTemplate>
                                 <asp:LinkButton ID="btnRandom6" runat="server" CssClass="btn btn-primary"  Width="100%"     >
                                <span aria-hidden="true" class="glyphicon glyphicon-barcode"></span>
                                  <asp:Label ID="Lbl4" runat="server" Text="Item BarCode"></asp:Label></asp:LinkButton>

                                 </HeaderTemplate>
                                 <ItemStyle Font-Bold="True" Font-Size="Large" ForeColor="#3366CC" />
                           </asp:TemplateField> 
                            
                            </Columns>
                    </asp:GridView>
                
          

            </div>
   
        </asp:Content>
