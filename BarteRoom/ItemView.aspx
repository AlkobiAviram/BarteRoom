<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="BarteRoom.viewItem" %>

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
   </style>

           <link href="css/navbar.css" rel="stylesheet"/>

               <link href="~/css/ImageHover.css" rel="stylesheet" type="text/css" runat="server"/>
   <div class="container" runat="server" id="itemViewPage">
        
       <table >
            <tr>
             <td class="customTd">
             <span class="img-responsive zoom_img .customSpan"  >
             <asp:Image id="item_pic3"   runat="server"/>
             </span>
             <asp:GridView ID="GridView1" CssClass="table table-responsive table-hover" HorizontalAlign="Center" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting"  OnSelectedIndexChanging="GridView1_SelectedIndexChanging">       
             </asp:GridView>
            <asp:FileUpload ID="newImage" runat="server" />
            <asp:Label ID="uploadNewImageLabel" Text="Upload new image" runat="server" />
            <asp:Button ID="edit_cmd" runat="server" CssClass="btn hvr-wobble-to-bottom-right" Text="Edit" OnClick="edit_cmd_Click" Height="26px" Width="158px"></asp:Button>
            <asp:Button ID="commit_cmd" runat="server" CssClass="btn-default" Visible="false" Text="Commit changes" OnClick="commit_cmd_Click"></asp:Button>
             <asp:Button ID="cancel_cmd" runat="server" CssClass="btn-default" Visible="false" Text="cancel" OnClick="cancel_cmd_Click" Width="114px"></asp:Button>
           </td>
        <td>
                    
                    
                    <h3> <asp:Label ID="makeBidHeader" Text="Make A Bid" runat="server" OnDataBinding="Page_Load"></asp:Label></h3>
                   
                       <asp:Button ID="offer_cmd" Visible="true" runat="server" Text="Make a Bid" CssClass=" btn hvr-icon-wobble-horizontal" OnClick="offer_cmd_Click"/>
                       <asp:Button ID="viewTransaction_cmd" Visible="false" runat="server" Text="View Bid" CssClass=" btn hvr-icon-wobble-horizontal" OnClick="viewTransaction_cmd_Click" />
                       <asp:Label ID="Label2" Visible="true" runat="server" Text="Please"></asp:Label>
                       <asp:HyperLink ID="logInHyperLink" Visible="true" runat="server" OnDataBinding="Page_Load" NavigateUrl="#login" data-toggle="modal" CssClass="change"> log in </asp:HyperLink>
                       <asp:Label ID="Label1" Visible="true" runat="server" Text="to make a bid"></asp:Label>

               
                 
           
                
        </td>
          <td>
               <asp:Label ID="Label3" Visible="false" runat="server" Text="to make a bid"></asp:Label>
          </td>  
                </tr>
             
               <tr class="customTd1">
      <td colspan="3">
             <ul role="tablist" class="nav nav-tabs bs-adaptive-tabs">
              <li id="desc_li" class="active" onclick="onclick2()" >
               <asp:LinkButton ID="description_tab"   runat="server"  OnClick="description_tab_Click">Description</asp:LinkButton>
               </li>
              <li id="owner_li" onclick="onclick1()" ><asp:LinkButton ID="OwnerInformation_tab"   runat="server" OnClick="OwnerInformation_tab_Click">Owner Information</asp:LinkButton></li>
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
            

        

             <h3><asp:Label ID="itemId_header" runat="server" /></h3>
                   <p>
                      
                        <asp:Label  id="idLabel1" runat="server"/>
                </p>
           
        </td>
          </tr>
 

       </table>
      
       

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
