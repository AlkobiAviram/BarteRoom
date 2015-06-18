<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<div class="container"  runat="server" id="AddItem">
                  
     <h2>Add Item</h2>
    
  
        


        <div class="col-md-4">
            <div class="form-group form-group-md">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" ValidationGroup="addGroup" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="classes_list" ErrorMessage="please choose class" ForeColor="Red" Display="None" InitialValue="choose class" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name_textBox" ErrorMessage="please insert name" ForeColor="Red" Display="None" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                 
                            <div class="row">
                            <label>Item Name</label>
                          <asp:TextBox  id="name_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />
                         </div>
               
                       <div class="row">
                              <label>Comments</label>
                          <asp:TextBox  id="comnts_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />
                        </div>
     
                         <div class="row">
                              <label>Description</label>
                          <asp:TextBox id="desc_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="380" Height="400" />
                        </div>
                
            </div>
        </div>
         
         <div class="col-lg-5">
              <div class="row">
             <label>Choose Category</label>
             <br />
             <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name" Height="23px" Width="189px" ></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT cls_name FROM classes WHERE (cls_name &lt;&gt; 'All Catagories')"></asp:SqlDataSource>
              </div>

            <div class="row">
             <label>Upload Photo</label>
             <br />
            <asp:FileUpload  CssClass="btn hvr hvr-wobble-skew" ID="image_upload" runat="server" OnLoad="image_upload_Load" />
                 <asp:Button CssClass="btn hvr hvr-wobble-skew" ID="previe_button" runat="server" Text="preview" OnClick="previe_button_Click" />
                <asp:Image ID="image_preview" runat="server" />
                </div>


              <div class="row">
             <label>What Next</label>
                     <br />
            <asp:Button ID="commit_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server"   Text="Add" OnClick="commit_cmd_Click"  ValidationGroup="addGroup" />
             <asp:Button ID="cancel_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server" Text="Cancel"  OnClick="cancel_cmd_Click"  ValidationGroup="addGroup" />
                </div>
         </div>

   
         

        
        
            
    </div>
    
   

  


   

    

   
  

</asp:Content>