<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<div class="container"  runat="server" id="AddItem">
                  
     <h2>Add Item</h2>
    
     <div class="row">
        


        <div class="col-md-4">
            <div class="form-group form-group-md">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" ValidationGroup="addGroup" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="classes_list" ErrorMessage="please choose class" ForeColor="Red" Display="None" InitialValue="choose class" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name_textBox" ErrorMessage="please insert name" ForeColor="Red" Display="None" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                 
                         <div class="input-group">
                            <label>Item Name</label>
                          <asp:TextBox  id="name_textBox" AutoPostBack="true" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />
                         </div>
               
                         <div class="input-group">
                              <label>Comments</label>
                          <asp:TextBox  id="comnts_textBox" AutoPostBack="true" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />
                        </div>
     
                         <div class="input-group">
                              <label>Description</label>
                          <asp:TextBox  id="desc_textBox" AutoPostBack="true" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="400" Height="400" />
                        </div>
                <hr />
            </div>
        </div>
         <div class="col-md-6">
             <h3>Choose Category</h3>
             <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name" Height="23px" Width="189px" ></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT cls_name FROM classes WHERE (cls_name &lt;&gt; 'All Catagories')"></asp:SqlDataSource>
              <h3>Upload Photo</h3>
             <asp:FileUpload CssClass="input-group" ID="image_upload" runat="server" OnLoad="image_upload_Load" /><asp:Button ID="previe_button" runat="server" Text="preview" OnClick="previe_button_Click" />
             <asp:Image ID="image_preview" runat="server" />
             <hr />

            <asp:Button ID="commit_cmd" CssClass="btn icon-bar fa-arrow-circle-left" runat="server"   OnClick="commit_cmd_Click"  ValidationGroup="addGroup" />
             <asp:Button ID="cancel_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server" Text="Cancel"  OnClick="cancel_cmd_Click"  ValidationGroup="addGroup" />

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