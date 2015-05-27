<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT usr, name, class, comments, description FROM items WHERE (usr = @currentUser)">
        <SelectParameters>
            <asp:SessionParameter Name="currentUser" SessionField="usr" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
  

    <asp:DataList ID="DataList1" runat="server" DataKeyField="usr" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            usr:
            <asp:Label ID="usrLabel" runat="server" Text='<%# Eval("usr") %>' />
            <br />
            name:
            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <br />
            class:
            <asp:Label ID="classLabel" runat="server" Text='<%# Eval("class") %>' />
            <br />
            comments:
            <asp:Label ID="commentsLabel" runat="server" Text='<%# Eval("comments") %>' />
            <br />
            description:
            <asp:Label ID="descriptionLabel" runat="server" Text='<%# Eval("description") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    
  

</asp:Content>
