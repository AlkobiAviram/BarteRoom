<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BarteRoom.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
       <div class="col-md-3">
           <asp:TextBox ID="SearchTextBox" runat="server"  OnTextChanged="SearchTextBox_TextChanged" margin="20px;" padding="20px;" width="250px" Height="40px" cssClass="">search...</asp:TextBox>
       </div>
        <div class="col-md-3">
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT * FROM [classes]"></asp:SqlDataSource>
             <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name">
             </asp:DropDownList>
        </div>
          <div class="col-md-3">
              <asp:Button ID="search_cmd" runat="server" OnClick="search_cmd_Click" Text="Search" />
        </div>
    </div>
    </div>
    

    <div class="row">
        <div class="col-md-10">
              <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-responsive table-striped" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"  OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:ImageField DataImageUrlField="Image" ControlStyle-CssClass="img-responsive" >
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
        </div>
    </div>


</asp:Content>
