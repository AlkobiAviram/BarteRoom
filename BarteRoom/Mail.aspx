<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="BarteRoom.Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 69px;
        }
        .auto-style6 {
            width: 1137px;
        }
        .auto-style7 {
            width: 150px;
        }
        .notReadStyle{
            font-weight: bold;
        }
        .readStyle{
            font-weight: normal;
        }
        .msgViweStyle1{
            width: 300px;
        }
        .auto-style8 {
            width: 838px;
            padding-left: 50px;
            border-bottom-color: darkgrey;
            border-top-color: darkgrey;
            border-top-style: solid;
            border-top-width: medium;
            border-bottom-style: solid;
            border-bottom-width: medium;
        }
        .auto-style10 {
            border-bottom: solid;
            border-top: solid;
            border-bottom-color: darkgrey;
            border-top-color: darkgrey; 
            width: 371px;
        }
        .auto-style11 {
            padding-left: 50px;
            width: 120px;
        }
        .replayStyle{
            padding-bottom: 8px;
            padding-top: 8px;
            padding-left: 8px;
        }
        .auto-style14 {
            width: 172px;
        }
        .auto-style15 {
            width: 275px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="mailStyle.css" rel="stylesheet" />


        <table class="nav-justified">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">

                    <div class="msgView" visible="false" runat="server" id="msgViewID">
                        <table class="nav-justified">
                            <tr>
                                <td class="auto-style14">&nbsp;</td>
                                <td class="auto-style5">

                                    <asp:Label ID="msgSubView" Font-Bold="true" Font-Size="22px" runat="server" Text="Label"></asp:Label>

                                </td>
                                
                            </tr>
                        </table>
                        <asp:Panel ID="msgViewPanel" runat="server" Width="988px">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
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
                                    <asp:Panel ID="replayPanel" Width="832px" CssClass="replayStyle" BackColor="#fbfbfb" runat="server">
                                        <asp:Button ID="replayButton" CssClass="btn btn-info" runat="server" Text="Replay" OnClick="replayButton_Click" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <br /><br /><br /><br />
                    </div>


    <div class="inboxView" runat="server" id="inboxViewID">
                    <asp:GridView ID="inboxView" ShowHeader="false" Width="97%" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="inboxView_RowDataBound" OnSelectedIndexChanged="inboxView_SelectedIndexChanged" runat="server">
                        <Columns>

                            <asp:TemplateField HeaderText="From" ShowHeader="False" ConvertEmptyStringToNull="true" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="fromLabel" runat="server" Font-Size="18px" ForeColor="Black" Text='<%# Bind("From") %>'></asp:Label>
                                    </ItemTemplate>                                          
                                </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Subject" ShowHeader="False" ItemStyle-HorizontalAlign="Left" ConvertEmptyStringToNull="true">
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
