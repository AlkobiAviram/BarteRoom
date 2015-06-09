<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BarteRoom.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
   

    
    <link type="text/css" rel="stylesheet" href="Content/style.css" />
    <br />
    <div class="row">
        <div class="col-md-10">
              <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-responsive table-striped" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"  OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:ImageField DataImageUrlField="Image" ControlStyle-CssClass="img-responsive img-css">
                       
                        
                    </asp:ImageField>
                    <asp:BoundField DataField="User" />
                    <asp:BoundField DataField="Name" />
                    <asp:BoundField DataField="Comments" />
                    <asp:BoundField DataField="Description" />
                    <asp:BoundField DataField="id" />
                </Columns>

            </asp:GridView>
        </div>

        <div class="col-md-2">
            <ul class="list-group">
              <li class="list-group-item">dummy</li>
              <li class="list-group-item">dummy</li>
              <li class="list-group-item">dummy</li>
              <li class="list-group-item">dummy</li>
              <li class="list-group-item">dummy</li>
            </ul>
        </div>
    </div>

  </div>
</asp:Content>
