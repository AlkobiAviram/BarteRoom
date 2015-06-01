<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<div class="container">
     <h2>Add Item</h2>
    
     <div class="row">
        


        <div class="col-md-4">
            <div class="form-group">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="classes_list" ErrorMessage="please choose class" InitialValue="choose class"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBox_name" ErrorMessage="please insert name"></asp:RequiredFieldValidator>
                  <span>name</span>
                         <div class="input-group">
                         <input type="text" class="form-control" placeholder="Enter Name" aria-describedby="basic-addon1" id="textBox_name" runat="server"/>&nbsp;</div>
                <span>description</span>
                         <div class="input-group">
                          <input type="text" class="form-control" placeholder="Enter Description" aria-describedby="basic-addon1" id="textBox_description" runat="server"/>
                        </div>
                <span>comments</span>
                         <div class="input-group">
                          <input type="text" class="form-control" placeholder="Enter Comments" aria-describedby="basic-addon1" id="textBox_comments" runat="server"/>
                        </div>
                <asp:Button ID="commit_cmd" class="btn btn-info" runat="server" Text="OK" Width="42px" OnClick="commit_cmd_Click" CssClass="nav-pills" />
            </div>
            <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT * FROM [classes]"></asp:SqlDataSource>
            <asp:Button ID="image_upload_cmd" class="btn btn-info" runat="server" Text="upload" Width="70px" OnClick="image_upload_cmd_Click" CssClass="nav-pills" />
            <asp:FileUpload CssClass="input-group" ID="image_upload" runat="server" OnLoad="image_upload_Load" />


        </div>
 
            
    </div>
</div>
   

  


   

    

   
  

</asp:Content>