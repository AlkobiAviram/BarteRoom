<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT usr, name, class, comments, description FROM items WHERE (usr = @currentUser)">
        <SelectParameters>
            <asp:SessionParameter Name="currentUser" SessionField="usr" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
  

    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="usr" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="usr" HeaderText="usr" ReadOnly="True" SortExpression="usr" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="class" HeaderText="class" SortExpression="class" />
            <asp:BoundField DataField="comments" HeaderText="comments" SortExpression="comments" />
            <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
            <asp:ButtonField CommandName="Delete" Text="delete" />
            <asp:ButtonField CommandName="Edit" Text="Edit" />
            <asp:ButtonField CommandName="Update" Text="update" />
        </Columns>
        <RowStyle BorderStyle="Solid" />
    </asp:GridView>
    
  

</asp:Content>
