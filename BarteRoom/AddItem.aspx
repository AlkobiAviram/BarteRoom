        <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <link href="~/css/css_forAddItem.css" rel="stylesheet" type="text/css" runat="server"/>
            
            
            
            
            <div class="container" runat="server" id="AddItem">
             <h2>Add Item</h2>
    
             <table  class="table">


            <tr> 
        <td class="nati-name">      
        <label>Item Name</label>
        <asp:TextBox  id="name_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />                      
        </td>
         <td>
            <label>Choose Category & Sub-Category</label>
            <br />
            <asp:DropDownList ID="classes_list" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="main_category" DataValueField="main_category" Height="23px" Width="189px" OnSelectedIndexChanged="classes_list_SelectedIndexChanged" OnTextChanged="classes_list_TextChanged" ></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT DISTINCT [main_category] FROM [classes]"></asp:SqlDataSource>
             <asp:DropDownList ID="sub_classes_list" CssClass=""  runat="server" AutoPostBack="true"  Height="23px" Width="189px" OnSelectedIndexChanged="sub_classes_list_SelectedIndexChanged"  />
              
               
         </td>
                 
            <td> 
         <label>What Next</label>
          <br /> 
          <asp:LinkButton ID="commit_cmd"  CssClass="btn change"  runat="server" Width="100%" OnClick="commit_cmd_Click"  ValidationGroup="addGroup">
          <span aria-hidden="true" class="glyphicon glyphicon-floppy-save"></span>
           <asp:Label ID="Lbl1" runat="server" Text="Save Item"></asp:Label></asp:LinkButton>
          <asp:LinkButton ID="cancel_cmd"  CssClass="btn change"  runat="server" Width="100%" OnClick="commit_cmd_Click"  ValidationGroup="addGroup">
          <span aria-hidden="true" class="glyphicon glyphicon-remove-sign"></span>
           <asp:Label ID="Lbl2" runat="server" Text="Cancel"></asp:Label></asp:LinkButton>
          </td>
            </tr>


            <tr>
            <td class="nati-comments" colspan="2">          
               <label>Comments</label>
                <asp:TextBox  id="comnts_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />                     
             </td >
            </tr>



     <tr> 
        <td class="nati-description"  colspan="3"  >      
          <label>Description</label> 
            <br />
          <asp:TextBox id="desc_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="700px" Height="400px" />        
        </td>
         
         </tr>   

          
            
            <tr>
            <td>   
                <br /> 
          <label>Upload Photo</label>
          <br />
         <asp:FileUpload  CssClass="btn hvr hvr-wobble-skew" ID="image_upload" runat="server" OnLoad="image_upload_Load" Width="252px" />
         <br />
          <asp:LinkButton ID="upload_cmd"  CssClass="btn change"  runat="server" Width="100%" OnClick="upload_cmd_Click"  ValidationGroup="addGroup">
          <span aria-hidden="true" class="glyphicon glyphicon-remove-sign"></span>
           <asp:Label ID="Label1" runat="server" Text="Upload Image"></asp:Label></asp:LinkButton>
          <br />
             <asp:GridView ID="GridView1" CssClass="table table-responsive table-hover" HorizontalAlign="Center" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"  OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting"  >
  

             </asp:GridView>
           </td > 
            </tr>
             
    

                </table>


        
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" ValidationGroup="addGroup" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="classes_list" ErrorMessage="please choose class" ForeColor="Red" Display="None" InitialValue="choose class" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name_textBox" ErrorMessage="please insert name" ForeColor="Red" Display="None" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                 
                     
               
                     
                                 
     
                   
        
         
        
                 

              

            

   
         

        
        
            
   
   

  


   

    

   
  
    </div> 
        </asp:Content>