<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<div class="container">
     <h2>Add Item</h2>
    
     <div class="row">
        


        <div class="col-md-4">
            <div class="form-group form-group-md">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="classes_list" ErrorMessage="please choose class" InitialValue="choose class"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBox_name" ErrorMessage="please insert name"></asp:RequiredFieldValidator>
                 
                         <div class="input-group">
                            <label>Name</label>
                            <input type="text" class="form-control " placeholder="Enter Name" aria-describedby="basic-addon1" id="textBox_name" runat="server"/>&nbsp;
                         </div>
               
                         <div class="input-group">
                              <label>Description</label>
                          <input type="text" class="form-control" placeholder="Enter Description" aria-describedby="basic-addon1" id="textBox_description" runat="server"/>
                        </div>
     
                         <div class="input-group">
                              <label>Comments</label>
                          <input type="text" class="form-control" placeholder="Enter Comments" aria-describedby="basic-addon1" id="textBox_comments" runat="server"/>
                        </div>
                <hr />
            </div>
        </div>
         <div class="col-md-4">
             <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT cls_name FROM classes WHERE (cls_name &lt;&gt; 'All Catagories')"></asp:SqlDataSource>
            <asp:FileUpload CssClass="input-group" ID="image_upload" runat="server" OnLoad="image_upload_Load" />
            <hr />

              <asp:Button ID="commit_cmd" class="btn btn-info" runat="server" Text="OK"  OnClick="commit_cmd_Click" />
             <a class="btn btn-primary" href="/Home.aspx"> go back </a>
               
         </div>

         <div class="col-md-4">
             <div class="jumbotron">
                 <h2>Add your new item today! </h2>
                 <p> share your second hand product with the world</p>
                 <a class="btn btn-info" href="About.aspx"> more info  </a>
             </div>
         </div>

         

        
        
            
    </div>
</div>
   

  


   

    

   
  

</asp:Content>