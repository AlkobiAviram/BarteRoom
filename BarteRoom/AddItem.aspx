        <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <link href="~/css/css_forAddItem.css" rel="stylesheet" type="text/css" runat="server"/>
            <div class="container" runat="server" id="AddItem">

                  
             <h2>Add Item</h2>
    
  
             <table  class="table-bordered">


            <tr> 
        <td class="nati-name">      
        <label>Item Name</label>
        <asp:TextBox  id="name_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />                      
        </td>
         <td>
            <label>Choose Category</label>
            <br />
            <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="main_category" DataValueField="main_category" Height="23px" Width="189px" OnSelectedIndexChanged="classes_list_SelectedIndexChanged" OnTextChanged="classes_list_TextChanged" ></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT DISTINCT [main_category] FROM [classes]"></asp:SqlDataSource>
             <asp:DropDownList ID="sub_classes_list" runat="server"  DataTextField="sub_category" DataValueField="sub_category" Height="23px" Width="189px" AutoPostBack="True" DataMember="sub_category" OnSelectedIndexChanged="sub_classes_list_SelectedIndexChanged" >
                 <asp:ListItem>sub_catgeory</asp:ListItem>
             </asp:DropDownList>
               
         </td>
                 
            <td> 
         <label>What Next</label>
          <br /> 
          <asp:Button ID="commit_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server"   Text="Add" OnClick="commit_cmd_Click"  ValidationGroup="addGroup" />
          <asp:Button ID="cancel_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server" Text="Cancel"  OnClick="cancel_cmd_Click"  ValidationGroup="addGroup" />
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
          <asp:Button CssClass="btn hvr hvr-wobble-skew" ID="upload_cmd" runat="server" Text="Upload Image" OnClick="upload_cmd_Click" />
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