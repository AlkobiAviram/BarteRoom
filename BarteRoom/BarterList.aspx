<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <asp:GridView ID="GridView1" CssClass="table table-bordered table-responsive table-striped"  runat="server" AllowSorting="True"  AllowPaging="True"  AutoGenerateColumns="False" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowUpdated="GridView1_RowUpdated" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
          
            <asp:ImageField DataImageUrlField ="Image" NullDisplayText="no image" >
                <ControlStyle Height="250px" Width="250px" />
                <ItemStyle Height="20px" Width="20px" />
            </asp:ImageField>
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="Comments" />
            <asp:BoundField DataField="Description" />
            <asp:BoundField DataField="id" /> 
        </Columns>
        
      
      
    </asp:GridView>
    
  

 
    
  

    </asp:Content>
