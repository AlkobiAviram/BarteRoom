<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="BarteRoom.Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style20 {
            width: 574px;
        }
        .auto-style21 {
            width: 268px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="style2.css" rel="stylesheet" />
    <link href="mailStyle.css" rel="stylesheet" />


        <table class="nav-justified">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">

                    <div class="msgView" visible="false" runat="server" id="msgViewID">
                        <table class="nav-justified">
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style5">

                                    <asp:Label ID="msgSubView" Font-Bold="true" Font-Size="22px" runat="server" Text="Label"></asp:Label>

                                </td>
                                
                            </tr>
                        </table>
                        <asp:Panel ID="msgViewPanel" runat="server" Width="956px">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style19">&nbsp;</td>
                                    <td class="auto-style8">     
                                        <asp:Label ID="msgViewFrom" Font-Bold="true" Font-Size="18px" runat="server" Text="from"></asp:Label>
                                    </td>
                                    <td class="auto-style10">
                                        <asp:Label ID="msgViewDate" Font-Bold="true" Font-Size="18px" runat="server" Text="date"></asp:Label>
                                    </td>
                                    </tr>
                                </table>
                        </asp:Panel>

                        <table class="nav-justified">
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td>

                                    <asp:TextBox ID="msgViewTxt" TextMode="MultiLine" Font-Size="18px" ReadOnly="true" Height="400px" runat="server" Width="832px"></asp:TextBox>

                                </td>
                         
                            </tr>
                            <tr>
                               
                                <td class="auto-style11">&nbsp;</td>
                                <td><br />
                                    <asp:Panel ID="line" Width="832px" Height="1px" BackColor="DarkGray" runat="server"></asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td><br /><br />
                                    <asp:TextBox ID="replayTxt" TextMode="MultiLine" Font-Size="18px" Height="100px" Width="832px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td>
                                    <asp:Panel ID="replayPanel" Width="832px" CssClass="replayStyle" BackColor="#D3D3D3" runat="server" BorderStyle="None">
                                        <asp:LinkButton ID="replayButton" CssClass="btn btn-success" OnClick="replayButton_Click" runat="server">Reply <span class="glyphicon glyphicon-send"></asp:LinkButton>
                                        <asp:LinkButton ID="saveDraft" CssClass="btn btn-primary" OnClick="saveDraft_Click" runat="server">Draft <span class="glyphicon glyphicon-file"></span></asp:LinkButton>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <br /><br /><br /><br />
                    </div>


    <div class="inboxView" runat="server" id="inboxViewID">
        <table class="nav-justified">
                      <tr>
                            <td class="auto-style22">
                                <asp:LinkButton ID="deleteCmd" CssClass="btn btn-danger" OnClick="deleteCmd_Click" runat="server">Delete <span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                            <td class="auto-style21">
                                <asp:LinkButton ID="StarCmd" CssClass="btn btn-warning" OnClick="StarCmd_Click" runat="server">Mark Message <span class="glyphicon glyphicon-star"></span></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Button ID="markMsgAsRead" CssClass="btn btn-success" runat="server" Text="Mark all as read" OnClick="markMsgAsRead_Click" />
                            </td>
                          
                        </tr>
                       </table>
                        
                       <table class="nav-justified">
                        <tr>
                            <td class="auto-style20">
                                <br />
                                <h1>Inbox</h1>
                            </td>
                        </tr>
                    

                    </table>
                    <asp:GridView ID="inboxView" ShowHeader="false" Width="97%" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="inboxView_RowDataBound" OnSelectedIndexChanged="inboxView_SelectedIndexChanged" runat="server">
                        <Columns>

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckMsg" CssClass="checkboxStyle" runat="server" />
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 
                          

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="fromLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("From") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Subject" ShowHeader="False" ItemStyle-CssClass="leftPad" ItemStyle-HorizontalAlign="Left" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="subjectLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("Subject") %>'></asp:Label>
                                        <asp:Label ID="msgLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Msg") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Datetime" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="datetimeLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Datetime") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="idLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="IsRead" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="isReadLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("IsRead") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="IsRead" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="isStarLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("IsStar") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>
                          
                        </Columns>
                      
                    </asp:GridView>
    
        </div>

                    <div class="SentView" runat="server" id="SentViewID">

                        <table class="nav-justified">
                      <tr>
                            <td class="auto-style22">
                                <asp:LinkButton ID="deleteOut" CssClass="btn btn-danger" OnClick="deleteOut_Click" runat="server">Delete <span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                        </tr>
                       </table>
                        
                       <table class="nav-justified">
                        <tr>
                            <td class="auto-style20">
                                <br />
                                <h1><asp:Label ID="OutBoxLabel" runat="server" Text="OutBox"></asp:Label></h1>
                            </td>
                        </tr>
                    

                    </table>


                    <asp:GridView ID="SentGridView" ShowHeader="false" Width="97%" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="SentGridView_RowDataBound" OnSelectedIndexChanged="SentGridView_SelectedIndexChanged" runat="server">
                        <Columns>

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckOutMsg" CssClass="checkboxStyle" runat="server" />
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="toLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("To") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Subject" ShowHeader="False" ItemStyle-CssClass="leftPad" ItemStyle-HorizontalAlign="Left" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="sentsubjectLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("Subject") %>'></asp:Label>
                                        <asp:Label ID="sentmsgLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Msg") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Datetime" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="sentdatetimeLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Datetime") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="sentidLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                        </Columns>
                      
                    </asp:GridView>
    
        </div>

                    <div class="FavouritesView" runat="server" id="FavouritesID">

                         <table class="nav-justified">
                      <tr>
                            <td class="auto-style22">
                                <asp:LinkButton ID="FavourDelete" CssClass="btn btn-danger" OnClick="FavourDelete_Click" runat="server">Delete <span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                            <td class="auto-style21">
                                <asp:LinkButton ID="FavourStarCmd" CssClass="btn btn-warning" OnClick="FavourStarCmd_Click" runat="server">Cancel Mark <span class="glyphicon glyphicon-star"></span></asp:LinkButton>
                            </td>
                          
                        </tr>
                       </table>
                        
                       <table class="nav-justified">
                        <tr>
                            <td class="auto-style20">
                                <br />
                                <h1>Favourites</h1>
                            </td>
                        </tr>
                    

                    </table>


                        <asp:GridView ID="FavourView" ShowHeader="false" Width="97%" GridLines="Horizontal" AutoGenerateColumns="False" runat="server">
                        <Columns>

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="FavourCheckMsg" CssClass="checkboxStyle" runat="server" />
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 
                          

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="FavourfromLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("From") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Subject" ShowHeader="False" ItemStyle-CssClass="leftPad" ItemStyle-HorizontalAlign="Left" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="FavoursubjectLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("Subject") %>'></asp:Label>
                                        <asp:Label ID="FavourmsgLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Msg") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Datetime" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="FavourdatetimeLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Datetime") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="FavouridLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="IsRead" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="FavourisReadLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("IsRead") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="IsRead" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="FavourisStarLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("IsStar") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>
                          
                        </Columns>
                      
                    </asp:GridView>

                    </div>

                    <div class="DraftView" runat="server" id="DraftViewID">

                          <table class="nav-justified">
                      <tr>
                            <td class="auto-style22">
                                <asp:LinkButton ID="draftDelete" CssClass="btn btn-danger" OnClick="draftDelete_Click" runat="server">Delete <span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                        </tr>
                       </table>
                        
                       <table class="nav-justified">
                        <tr>
                            <td class="auto-style20">
                                <br />
                                <h1><asp:Label ID="DraftsLabel" runat="server" Text="Drafts"></asp:Label></h1>
                            </td>
                        </tr>
                    

                    </table>

                        <asp:GridView ID="drafView" ShowHeader="false" Width="97%" GridLines="Horizontal" AutoGenerateColumns="False" runat="server">
                        <Columns>

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="drafCheckMsg" CssClass="checkboxStyle" runat="server" />
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 
                          

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="drafromLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("To") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Subject" ShowHeader="False" ItemStyle-CssClass="leftPad" ItemStyle-HorizontalAlign="Left" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="drafsubjectLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("Subject") %>'></asp:Label>
                                        <asp:Label ID="drafmsgLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Msg") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Datetime" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="drafdatetimeLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Datetime") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="drafidLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>
                          
                        </Columns>
                      
                    </asp:GridView>

                    </div>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

  
    <nav class="main-menu">
            <ul>
               <li class="has-subnav">
                    <a href="#">
                       <i class="fa fa-pencil fa-2x"></i>
                        <span class="nav-text">
                            New message
                        </span>
                    </a>
                </li>

                <li class="has-subnav">
                    <asp:LinkButton ID="InboxCmd" runat="server" OnClick="InboxCmd_Click">
                        <i class="fa fa-inbox fa-2x"></i>
                        <span class="nav-text">
                            <asp:Label ID="InboxLabel" runat="server" ForeColor="Red" Font-Bold="true" Text="Inbox"></asp:Label>
                            <asp:Label ID="numOfLabel" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                        </span>
                    </asp:LinkButton>
                    
                </li>

                <li class="has-subnav">
                    <asp:LinkButton ID="sentCmd" runat="server" OnClick="sentCmd_Click">
                       <i class="fa fa-share fa-2x""></i>
                        <span class="nav-text">
                            Sent mail
                        </span>
                    </asp:LinkButton>
                   
                </li>

                 <li>
                    <a href="#">
                        <i class="fa fa-user fa-2x"></i>
                        <span class="nav-text">
                            Connections
                        </span>
                    </a>
                </li>

                 <li>
                     <asp:LinkButton ID="FavouritesCmd" runat="server" OnClick="FavouritesCmd_Click">
                        <i class="fa fa-star fa-2x"></i>
                        <span class="nav-text">
                            Favourites
                        </span>
                    </asp:LinkButton>
                </li>

                <li>
                   <asp:LinkButton ID="DraftsCmd" runat="server" OnClick="DraftsCmd_Click">
                       <i class="fa fa-file fa-2x"></i>
                        <span class="nav-text">
                            Drafts
                        </span>
                    </asp:LinkButton>
                </li>

                <li class="has-subnav">
                    <a href="#">
                       <i class="fa fa-wrench fa-2x"></i>
                        <span class="nav-text">
                            Settings
                        </span>
                    </a>
                   
                </li>

                <li>
                    <a href="#">
                       <i class="fa fa-info fa-2x"></i>
                        <span class="nav-text">
                            Help
                        </span>
                    </a>
                </li>
            </ul>

        </nav>

</asp:Content>
