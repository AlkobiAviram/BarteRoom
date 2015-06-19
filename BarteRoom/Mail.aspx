<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="BarteRoom.Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 69px;
        }
        .auto-style5 {
            width: 170px;
        }
        .auto-style6 {
            width: 1137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="mailStyle.css" rel="stylesheet" />


        <table class="nav-justified">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">


    
                    <asp:GridView ID="inboxView" ShowHeader="false" Width="97%" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="inboxView_RowDataBound" runat="server">
                        <Columns>

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="fromLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("From") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Subject" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="subjectLabel" runat="server" Font-Size="Medium" ForeColor="Black" Text='<%# Bind("Subject") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Msg" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="msgLabel" runat="server" Font-Size="Medium" ForeColor="#A9A9A9" Text='<%# Bind("Msg") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="Datetime" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="datetimeLabel" runat="server" Font-Size="Medium" ForeColor="#A9A9A9" Text='<%# Bind("Datetime") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" ShowHeader="False" ConvertEmptyStringToNull="true">
                                    <ItemTemplate>
                                        <asp:Label ID="idLabel" runat="server" Font-Size="0px" ForeColor="Black" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
    

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
                    <a href="#">
                       <i class="fa fa-share fa-2x""></i>
                        <span class="nav-text">
                            Sent mail
                        </span>
                    </a>
                   
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
                    <a href="#">
                        <i class="fa fa-star fa-2x"></i>
                        <span class="nav-text">
                            Favourites
                        </span>
                    </a>
                </li>

                <li>
                   <a href="#">
                       <i class="fa fa-file fa-2x"></i>
                        <span class="nav-text">
                            Drafts
                        </span>
                    </a>
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
