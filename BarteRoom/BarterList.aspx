<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <asp:GridView ID="GridView1" CssClass="table table-bordered table-responsive table-striped"  runat="server" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" DataSourceID="ItemsDataSource" DataKeyNames="id" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="Comments" />
            <asp:BoundField DataField="Description" />
            <asp:ImageField DataImageUrlField ="Image" NullDisplayText="no image" >
                <ItemStyle Height="20px" Width="20px" />
            </asp:ImageField>
            <asp:BoundField DataField="id" /> 
        </Columns>
        
      
      
    </asp:GridView>
    
  

 
    
  

    <asp:ObjectDataSource ID="ItemsDataSource" runat="server" DeleteMethod="removeItem" SelectMethod="getDataSource" TypeName="BarteRoom.Logic" UpdateMethod="editItem">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="usr" SessionField="usr" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="comments" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="pic" Type="Object" />
            <asp:Parameter Name="id" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    
  

 
    
  

</asp:Content>
