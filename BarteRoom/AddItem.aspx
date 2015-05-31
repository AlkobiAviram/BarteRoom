<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BarteRoom.BarterList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<div class="container">
     <h2>Add Item</h2>
    
     <div class="row">
        


        <div class="col-md-4">
            <div class="form-group">
                  <span>name</span>
                         <div class="input-group">
                         <input type="text" class="form-control" placeholder="Enter Name" aria-describedby="basic-addon1" id="loginPasswordTxtBox" runat="server"/>
                        </div>
                <span>description</span>
                         <div class="input-group">
                          <input type="text" class="form-control" placeholder="Enter Description" aria-describedby="basic-addon1" id="Password1" runat="server"/>
                        </div>
                <span>comments</span>
                         <div class="input-group">
                          <input type="text" class="form-control" placeholder="Enter Comments" aria-describedby="basic-addon1" id="Password2" runat="server"/>
                        </div>
                <asp:Button ID="commit_cmd" class="btn btn-info" runat="server" Text="OK" Width="42px" OnClick="commit_cmd_Click" CssClass="nav-pills" />
            </div>
        </div>
         <div class="col-md-4">
             <select>
              <option value="volvo">Volvo</option>
              <option value="saab">Saab</option>
              <option value="opel">Opel</option>
              <option value="audi">Audi</option>
            </select>

             <asp:FileUpload CssClass="input-group" ID="FileUpload1" runat="server" />
         </div>
 
            
    </div>
</div>
   

  

  <!--  <asp:TextBox ID="name_textBox" runat="server" OnTextChanged="name_textBox_TextChanged">name</asp:TextBox>
              <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="comments_textBox_TextChanged">comments</asp:TextBox>
              <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="description_textBox_TextChanged">description</asp:TextBox>-->
   

    

   
  

</asp:Content>