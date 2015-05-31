<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    








    <asp:SqlDataSource ID="SQL_for_classes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT * FROM [classes]"></asp:SqlDataSource>
    <asp:CheckBoxList ID="class_check_box" runat="server" DataSourceID="SQL_for_classes" DataTextField="cls_name" DataValueField="cls_name" OnSelectedIndexChanged="class_check_box_SelectedIndexChanged">
    </asp:CheckBoxList>


    <asp:Button ID="commit_cmd" class="btn btn-info" runat="server" Text="OK" Width="42px" OnClick="commit_cmd_Click" CssClass="nav-pills" />
    <asp:TextBox ID="name_textBox" runat="server" OnTextChanged="name_textBox_TextChanged">name</asp:TextBox>
    <asp:TextBox ID="comments_textBox" runat="server" OnTextChanged="comments_textBox_TextChanged">comments</asp:TextBox>
    <asp:TextBox ID="description_textBox" runat="server" OnTextChanged="description_textBox_TextChanged">description</asp:TextBox>
    








</asp:Content>