<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="BarteRoom.Manager1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

    <style type="text/css">
        .auto-style1 {
            width: 276px;
        }
        .auto-style2 {
            text-align: center;
            width: 501px;
        }
        .auto-style3 {
            width: 501px;
        }
        .auto-style4 {
            text-decoration: underline;
        }
    </style>

   

</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2"><strong><span class="auto-style4">All Managers</span></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style3">
                <asp:GridView ID="Managers" runat="server" AutoGenerateColumns="False" DataKeyNames="usr" DataSourceID="SqlDataSource1" GridLines="Horizontal" ShowFooter="True" Width="685px" AllowSorting="True" BorderStyle="Inset" HorizontalAlign="Center" CellPadding="5">
                    <Columns>

                   <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                      &nbsp;<asp:Button ID="delete" class="btn btn-info" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                                  </ItemTemplate>

                              </asp:TemplateField>
                  


                         <asp:TemplateField ShowHeader="False">
                                  <EditItemTemplate>
                                      <asp:Button ID="update" class="btn btn-info" runat="server" CausesValidation="True" CommandName="Update" Text="Update" ValidationGroup="editGroup"></asp:Button>
                                      &nbsp;<asp:Button ID="cancel" class="btn btn-info" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:Button>
                                  </EditItemTemplate>
           
                                  <ItemTemplate>
                                      <asp:Button ID="edit" class="btn btn-info" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:Button>
                                      </ItemTemplate>
                                      </asp:TemplateField>

   
                        <asp:TemplateField ShowHeader="False">
                            <FooterTemplate>
                                <asp:Button ID="insertNewManager" class="btn btn-info" OnClick="insertNewManager_Click" runat="server" Text="Insert" ValidationGroup="insertGroup"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name" SortExpression="usr">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("usr") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:RequiredFieldValidator ID="UserRequired" runat="server" ErrorMessage="UserName Required" ControlToValidate="addManagerUsr" ForeColor="Red" ValidationGroup="insertGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="addManagerUsr" class="form-control" placeholder="User" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password" SortExpression="password">
                            <EditItemTemplate>
                                  <asp:RequiredFieldValidator ID="editPassRequired" runat="server" ErrorMessage="Password Required" ControlToValidate="TextBox1" ForeColor="Red" ValidationGroup="editGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBox1" class="form-control" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("password") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                  <asp:RequiredFieldValidator ID="PassRequired" runat="server" ErrorMessage="Password Required" ControlToValidate="addManagerPass" ForeColor="Red" ValidationGroup="insertGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="addManagerPass" class="form-control" placeholder="Password" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="fullName">
                            <EditItemTemplate>
                                 <asp:RequiredFieldValidator ID="editNameRequired" runat="server" ErrorMessage="Name Required" ControlToValidate="TextBox2" ForeColor="Red" ValidationGroup="editGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBox2" class="form-control" runat="server" Text='<%# Bind("fullName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("fullName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                  <asp:RequiredFieldValidator ID="NameRequired" runat="server" ErrorMessage="Name Required" ControlToValidate="addManagerName" ForeColor="Red" ValidationGroup="insertGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="addManagerName" class="form-control" placeholder="Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                            <EditItemTemplate>
                                <asp:RequiredFieldValidator ID="editEmailRequired" runat="server" ErrorMessage="E-mail Required" ControlToValidate="TextBox3" ForeColor="Red" ValidationGroup="editGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBox3" class="form-control" runat="server" Text='<%# Bind("email") %>' TextMode="Email"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                  <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ErrorMessage="E-mail Required" ControlToValidate="addManagerEmail" ForeColor="Red" ValidationGroup="insertGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="addManagerEmail" class="form-control" placeholder="E-mail" aria-describedby="basic-addon1" runat="server" TextMode="Email"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" Wrap="False" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle HorizontalAlign="Center" BackColor="#CCCCCC" Font-Bold="True" />
                    <RowStyle HorizontalAlign="Center" />

                </asp:GridView>

                <asp:ValidationSummary ID="insertValidationSummary" runat="server" ValidationGroup="insertGroup" ForeColor="red"/>
                <asp:ValidationSummary ID="editValidationSummary" runat="server" ValidationGroup="editGroup" ForeColor="red"/>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT usr, password, fullName, email FROM users WHERE (manager = 1)" DeleteCommand="DELETE FROM users WHERE (usr = @usr)" InsertCommand="INSERT INTO users(usr, password, fullName, email, manager) VALUES (@usr, @pass, @name, @email, 1)" UpdateCommand="UPDATE users SET password = @password, fullName = @fullName, email = @email 
where usr=@usr">
                    <InsertParameters>
                        <asp:Parameter Name="usr" Type="String"/>
                        <asp:Parameter Name="pass" Type="String"/>
                        <asp:Parameter Name="name" Type="String"/>
                        <asp:Parameter Name="email" Type="String"/>
                    </InsertParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="usr" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="password" Type="String"/>
                        <asp:Parameter Name="fullName" Type="String"/>
                        <asp:Parameter Name="email" Type="String"/>
                        <asp:Parameter Name="usr" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>


