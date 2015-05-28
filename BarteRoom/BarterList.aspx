<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" DataSourceID="ObjectDataSource1">
        <RowStyle BorderStyle="Solid" />
      
      
    </asp:GridView>
    
  

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getDataSource" TypeName="BarteRoom.Logic">
        <SelectParameters>
            <asp:SessionParameter Name="usr" SessionField="usr" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
  

</asp:Content>
