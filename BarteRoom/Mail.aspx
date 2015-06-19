<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="BarteRoom.Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="mailStyle.css" rel="stylesheet" />

    <style>
        .tb{
            width:50px;
        }
    </style>
    <div class="mailBox" runat="server" id="mailBoxID">
        <table>
            <tr>
                <td class="td"></td>
                <td>
                    <asp:GridView ID="inboxView" ShowHeader="false" Width="80%" runat="server"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>

    <div class="area">

    </div>
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
