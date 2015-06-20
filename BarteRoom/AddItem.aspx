    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
       .td {
           width:500px;
       }
   </style>
      <div class="container" runat="server" id="AddItem">

                  
         <h2>Add Item</h2>
    
  
         <table  class="table-hover">


        <tr> 
    <td class="td">      
    <label>Item Name</label>
    <asp:TextBox  id="name_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />                      
    </td>
     <td class="td">
        <label>Choose Category</label>
        <br />
        <asp:DropDownList ID="classes_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name" Height="23px" Width="189px" ></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT cls_name FROM classes WHERE (cls_name &lt;&gt; 'All Catagories')"></asp:SqlDataSource>         
     </td> 
       <td class="td"> 
     <label>What Next</label>
      <br /> 
      <asp:Button ID="commit_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server"   Text="Add" OnClick="commit_cmd_Click"  ValidationGroup="addGroup" />
      <asp:Button ID="cancel_cmd" CssClass="btn hvr hvr-wobble-to-bottom-right" runat="server" Text="Cancel"  OnClick="cancel_cmd_Click"  ValidationGroup="addGroup" />
      </td>
        </tr>
       

   <tr> 
    <td class="td">          
   <label>Comments</label>
   <asp:TextBox  id="comnts_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" />                     
    </td >
       
     </tr>


       <tr> 
    <td class="td">      
      <label>Description</label> 
        <br />
      <asp:TextBox id="desc_textBox" AutoPostBack="false" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="380" Height="400" />        
    </td >
     <td class="td">   
      <label>Upload Photo</label>
      <br />
     <asp:FileUpload  CssClass="btn hvr hvr-wobble-skew" ID="image_upload" runat="server" OnLoad="image_upload_Load" Width="252px" />
     <br />
      <asp:Button CssClass="btn hvr hvr-wobble-skew" ID="previe_button" runat="server" Text="preview" OnClick="previe_button_Click" />
      <br />
         <asp:GridView ID="GridView1" runat="server">

         </asp:GridView>
       </td > 
      </tr>


            </table>


        
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" ValidationGroup="addGroup" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="classes_list" ErrorMessage="please choose class" ForeColor="Red" Display="None" InitialValue="choose class" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name_textBox" ErrorMessage="please insert name" ForeColor="Red" Display="None" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                 
                     
               
                     
                                 
     
                   
        
         
        
                 

              

            

   
         

        
        
            
   
   

  


   

    

   
  
</div> 
    </asp:Content>