﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="BarteRoom.viewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style>
       .customTd {
           width:400px;
           height:400px;
           
       }
       .customTd1{
          background-color:white;
          border:1px solid #4682B4;
       }
       .natiColumn{
           width:100%;
       }
       .natiImage{
            
          border:1px solid #4682B4;
       }
   </style>

           <link href="css/navbar.css" rel="stylesheet"/>

               <link href="~/css/ImageHover.css" rel="stylesheet" type="text/css" runat="server"/>
   <div class="container" runat="server" id="itemViewPage">
         <asp:ScriptManager ID="script2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel id="panel" runat="server">
    <ContentTemplate>
       <table class="table">
            <tr>
             <td class="natiColumn">
                   
             <span class=" zoom_img .customSpan"  >
             <asp:Image id="item_pic3"   runat="server"/>
             </span >
                 <!--
             <asp:FileUpload ID="newImage" runat="server" />
            <asp:Label ID="uploadNewImageLabel" Text="Upload new image" runat="server" />
                 -->

           <asp:LinkButton ID="edit_cmd"  CssClass="btn change"  runat="server" Width="100%" Text="Edit"  OnClick="edit_cmd_Click"  ValidationGroup="addGroup">
          <span aria-hidden="true" class="glyphicon glyphicon-edit"></span>
           <asp:Label ID="Lbl1" runat="server" Text="Edit Item"></asp:Label></asp:LinkButton>
          
           <asp:LinkButton ID="cancel_cmd"  Visible="false" CssClass="btn change"  runat="server" Width="100%" Text="Cancel" OnClick="cancel_cmd_Click"  ValidationGroup="addGroup">
          <span aria-hidden="true" class="glyphicon glyphicon-remove-circle"></span>
           <asp:Label ID="Lbl2" runat="server" Text="Cancel"></asp:Label></asp:LinkButton>                 

           <asp:LinkButton ID="commit_cmd" Visible="false"  CssClass="btn change"  runat="server" Width="100%" Text="Commit changes" OnClick="commit_cmd_Click"  ValidationGroup="addGroup">
          <span aria-hidden="true" class="glyphicon glyphicon-ok-circle"></span>
           <asp:Label ID="Lbl3" runat="server" Text="Commit Changes"></asp:Label></asp:LinkButton>                   
            
                 

              

                
        </td>
             </tr>
             <tr >
              <td  class="natiColumn">
             <div id="images" runat="server">
             </div>
           
           </td>

          <td>
               <asp:Label ID="Label3" Visible="false" runat="server" Text="to make a bid"></asp:Label>
          </td>  
                </tr>
             
               <tr class="customTd1">
            <td colspan="3">
             <ul role="tablist" class="nav nav-tabs bs-adaptive-tabs">
              <li id="desc_li" class="active" onclick="onclick2()" >
               <asp:LinkButton ID="description_tab"  Text="Description" runat="server"  OnClick="description_tab_Click"></asp:LinkButton>
               </li>
              <li id="owner_li" onclick="onclick1()" ><asp:LinkButton ID="OwnerInformation_tab" Text="Owner Information"   runat="server" OnClick="OwnerInformation_tab_Click"></asp:LinkButton></li>
                </ul>



               <h3><asp:Label ID="name_header" runat="server" /></h3>
                 <p>
                        <asp:TextBox  id="name_textBox" AutoPostBack="true" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" OnTextChanged="name_textBox_TextChanged"/>
                        <asp:Label ID="nameLabel" runat="server" />
                 </p>
 
              <h3><asp:Label ID="comments_header" runat="server" /></h3>
                 <p>
                       <asp:TextBox id="comments_textBox" TextMode="multiline" BorderStyle="Dashed"  runat="server" Width="100%" OnTextChanged="comments_textBox_TextChanged"/>
                       <asp:Label ID="comLabel" runat="server" />

                 </p>
            
    
              <h3><asp:Label ID="description_header" runat="server" /></h3>
                   <p>
                        <asp:TextBox  id="description_textBox" TextMode="multiline" BorderStyle="Dashed" runat="server" OnTextChanged="description_textBox_TextChanged" />
                        <asp:Label ID="desLabel" runat="server" />
                     </p>
            

           <h3><asp:Label ID="main_category_header" runat="server" /></h3>
                   <p>
                        <asp:Label ID="main_category_label" runat="server" />
                     </p>
        


           <h3><asp:Label ID="sub_category_header" runat="server" /></h3>
                   <p>
                        <asp:Label ID="sub_category_label" runat="server" />
                     </p>


             <h3><asp:Label ID="itemId_header" runat="server" /></h3>
                   <p>
                      
                        <asp:Label  id="idLabel1" runat="server"/>
                </p>
           
        </td>
          </tr>
             
          <tr>
            <td style="position:center">
            <h3> <asp:Label ID="makeBidHeader" Text="Make A Bid" runat="server" OnDataBinding="Page_Load"></asp:Label></h3>
                   
          <asp:Button ID="offer_cmd" Visible="true" runat="server" Text="Make a Bid" CssClass=" btn hvr-icon-wobble-horizontal" OnClick="offer_cmd_Click"/>
           <asp:Button ID="viewTransaction_cmd" Visible="false" runat="server" Text="View Bid" CssClass=" btn hvr-icon-wobble-horizontal" OnClick="viewTransaction_cmd_Click" />
          <asp:Label ID="Label2" Visible="true" runat="server" Text="Please"></asp:Label>
           <asp:HyperLink ID="logInHyperLink" Visible="true" runat="server" OnDataBinding="Page_Load" NavigateUrl="#login" data-toggle="modal" CssClass="change"> log in </asp:HyperLink>
           <asp:Label ID="Label1" Visible="true" runat="server" Text="to make a bid"></asp:Label>           
            </td>
          </tr>
       </table>
      </ContentTemplate>
  </asp:UpdatePanel>
       

</div>
<script>
    function onclick1() {
        document.getElementById("desc_li").className = "affix";
        document.getElementById("owner_li").className = "active";
        return false;
    }
    function onclick2() {
        document.getElementById("desc_li").className = "active";
        document.getElementById("owner_li").className = "affix";
        return false;
    }
</script>

</asp:Content>
