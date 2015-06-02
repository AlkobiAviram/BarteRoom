<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BarteRoom.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-responsive table-striped" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"  OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:ImageField DataImageUrlField="Image">
                <ControlStyle Height="250px" Width="250px" />
                <ItemStyle Height="20px" Width="20px" />
            </asp:ImageField>
            <asp:BoundField DataField="User" />
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="Comments" />
            <asp:BoundField DataField="Description" />
            <asp:BoundField DataField="id" />
        </Columns>

    </asp:GridView>
</asp:Content>
