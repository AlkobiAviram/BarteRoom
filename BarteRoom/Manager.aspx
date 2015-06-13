<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="BarteRoom.Manager1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

    <style type="text/css">
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
        .auto-style10 {
            width: 251px;
        }
    </style>

   

</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <!-- ======================================================Managers table================================================================== -->
    <table class="nav-justified">
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style2"><strong><span class="auto-style4">All Managers - <asp:Label ID="numOfManagers" runat="server" Text="Label" ForeColor="Gray"></asp:Label></span></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">
                <asp:GridView ID="Managers" runat="server" AutoGenerateColumns="False" DataKeyNames="usr" DataSourceID="SqlDataSource1" GridLines="Horizontal" ShowFooter="True" Width="685px" AllowSorting="True" BorderStyle="Inset" HorizontalAlign="Center" CellPadding="5" AllowPaging="True">
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
    <!-- ======================================================Managers table================================================================== -->

    
    <br /><br />

    <!-- ======================================================Users table================================================================== -->
        <table class="nav-justified">
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style2"><strong><span class="auto-style4">All Users - <asp:Label ID="numOfUsers" runat="server" Text="Label" ForeColor="Gray"></asp:Label></span></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">
                <asp:GridView ID="UsersTable" runat="server" AutoGenerateColumns="False" DataKeyNames="usr" DataSourceID="Users" GridLines="Horizontal" ShowFooter="True" Width="685px" AllowSorting="True" BorderStyle="Inset" HorizontalAlign="Center" CellPadding="5" AllowPaging="True">
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
                                <asp:Button ID="insertNewUser" class="btn btn-info" onClick="insertNewUser_Click" runat="server" Text="Insert" ValidationGroup="insertNewUser"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name" SortExpression="usr">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("usr") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:RequiredFieldValidator ID="users_UserRequired" runat="server" ErrorMessage="UserName Required" ControlToValidate="addUserUsr" ForeColor="Red" ValidationGroup="insertNewUser" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="addUserUsr" class="form-control" placeholder="User" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password" SortExpression="password">
                            <EditItemTemplate>
                                  <asp:RegularExpressionValidator ID="users_editPasswordExpression" runat="server" ControlToValidate="users_editPass" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must be Min 8 characters, atleast 1 Alphabet and 1 Number" ForeColor="Red" Display="None" ValidationGroup="users_editGroup"/>
                                  <asp:RequiredFieldValidator ID="users_editPassRequired" runat="server" ErrorMessage="Password Required" ControlToValidate="users_editPass" ForeColor="Red" ValidationGroup="users_editGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="users_editPass" class="form-control" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("password") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                  <asp:RegularExpressionValidator ID="users_PasswordExpression" runat="server" ControlToValidate="addUserPass" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must be Min 8 characters, atleast 1 Alphabet and 1 Number" ForeColor="Red" Display="None" ValidationGroup="insertNewUser"/>
                                  <asp:RequiredFieldValidator ID="users_PassRequired" runat="server" ErrorMessage="Password Required" ControlToValidate="addUserPass" ForeColor="Red" ValidationGroup="insertNewUser" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="addUserPass" class="form-control" placeholder="Password" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="fullName">
                            <EditItemTemplate>
                                 <asp:RequiredFieldValidator ID="users_editNameRequired" runat="server" ErrorMessage="Name Required" ControlToValidate="users_editName" ForeColor="Red" ValidationGroup="users_editGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="users_editName" class="form-control" runat="server" Text='<%# Bind("fullName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("fullName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                  <asp:RequiredFieldValidator ID="users_NameRequired" runat="server" ErrorMessage="Name Required" ControlToValidate="users_addUserName" ForeColor="Red" ValidationGroup="insertNewUser" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="users_addUserName" class="form-control" placeholder="Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                            <EditItemTemplate>
                                <asp:RequiredFieldValidator ID="users_editEmailRequired" runat="server" ErrorMessage="E-mail Required" ControlToValidate="users_editEmail" ForeColor="Red" ValidationGroup="users_editGroup" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="users_editEmail" class="form-control" runat="server" Text='<%# Bind("email") %>' TextMode="Email"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                  <asp:RequiredFieldValidator ID="users_EmailRequired" runat="server" ErrorMessage="E-mail Required" ControlToValidate="users_addUserEmail" ForeColor="Red" ValidationGroup="insertNewUser" Display="None"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="users_addUserEmail" class="form-control" placeholder="E-mail" aria-describedby="basic-addon1" runat="server" TextMode="Email"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" />
                    <EmptyDataRowStyle HorizontalAlign="Center" Wrap="False" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle HorizontalAlign="Center" BackColor="#CCCCCC" Font-Bold="True" />
                    <RowStyle HorizontalAlign="Center" />

                </asp:GridView>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="insertNewUser" ForeColor="red"/>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="users_editGroup" ForeColor="red"/>

                <asp:SqlDataSource ID="Users" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT usr, password, fullName, email FROM users WHERE (manager = 0)" DeleteCommand="DELETE FROM users WHERE (usr = @usr)" InsertCommand="INSERT INTO users(usr, password, fullName, email, manager) VALUES (@usr, @pass, @name, @email, 0)" UpdateCommand="UPDATE users SET password = @password, fullName = @fullName, email = @email 
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

    <!-- ======================================================Users table================================================================== -->
    
    <br /> <br />

    <!--=======================================================classes====================================================================== -->

            <table class="nav-justified">
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style2"><strong><span class="auto-style4">Classes</asp:Label></span></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">
                <asp:GridView ID="ClassesTable" runat="server" AutoGenerateColumns="False" DataKeyNames="cls_name" DataSourceID="classesSource" GridLines="Horizontal" ShowFooter="True" Width="685px" AllowSorting="True" BorderStyle="Inset" HorizontalAlign="Center" CellPadding="5" AllowPaging="True" OnRowCommand="ClassesTable_RowCommand">
                    <Columns>

                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                      &nbsp;<asp:Button ID="deleteClass" class="btn btn-info" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                                  </ItemTemplate>

                              </asp:TemplateField>             

                        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-info" />

                        <asp:TemplateField ShowHeader="False">
                            <FooterTemplate>
                                <asp:Button ID="insertClass" class="btn btn-info" onClick="insertClass_Click" runat="server" Text="Insert" ValidationGroup="insertClass"/>
                            </FooterTemplate>
                        </asp:TemplateField>

                         

                            <asp:TemplateField HeaderText="class Name" SortExpression="cls_name">
                                <EditItemTemplate>
                                    <asp:RequiredFieldValidator ID="classRequired" ControlToValidate="classEditTxt" ForeColor="Red" runat="server" ErrorMessage="Class Name Required" ValidationGroup="classeditGroup"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="classEditTxt" class="form-control" runat="server" Text='<%# Eval("cls_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label" runat="server" Text='<%# Bind("cls_name") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:RequiredFieldValidator ID="class_UserRequired" runat="server" ErrorMessage="class Required" ControlToValidate="classInsert" ForeColor="Red" ValidationGroup="insertClass" Display="None"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="classInsert" class="form-control" placeholder="Class Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <EmptyDataRowStyle HorizontalAlign="Center" Wrap="False" />
                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" BackColor="#CCCCCC" Font-Bold="True" VerticalAlign="Middle" />
                    <RowStyle HorizontalAlign="Center" />

                </asp:GridView>

                <asp:ValidationSummary ID="insertClassValidationSummary" runat="server" ValidationGroup="insertClass" ForeColor="red"/>
                <asp:ValidationSummary ID="editClassValidationSummary" runat="server" ValidationGroup="classeditGroup" ForeColor="red"/>

                <asp:SqlDataSource ID="classesSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT * FROM classes" InsertCommand="INSERT INTO classes(cls_name) VALUES (@class_name)" DeleteCommand="DELETE FROM classes WHERE  cls_name = @cls_name AND cls_name != 'All Catagories' AND cls_name != 'choose class'" UpdateCommand="UPDATE classes SET cls_name = @class_name WHERE (cls_name = @tmp)
">
                    <InsertParameters>
                        <asp:Parameter Name="class_name" Type="String" />
                    </InsertParameters>
                          <DeleteParameters>
                        <asp:Parameter Name="cls_name" type="String"/>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="class_name" Type="String" />
                        <asp:ControlParameter ControlID="tmpLabel" Name="tmp" PropertyName="Text" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    <br /><br />
    <asp:Label ID="tmpLabel" runat="server" Text="Label" Visible="false"></asp:Label>
    <br />
    <!--=======================================================classes====================================================================== -->

     <script type="text/javascript">
            function userExists() {

                alert("This User Name Already Exists!");
          }
    </script>

</asp:Content>


