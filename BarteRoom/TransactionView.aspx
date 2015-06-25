<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionView.aspx.cs" Inherits="BarteRoom.TransactionView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <link href="imageHover.css" rel="stylesheet" type="text/css" runat="server"/>
        <style>
   
       .customTable{
          background-color:white;
          border:1px solid #4682B4;
       }
      
   </style>
     <script language ="javascript" type="text/javascript">
         function SelectRadiobutton(radio) {
             var rdBtn = document.getElementById(radio.id);
             var rdBtnList = document.getElementsByTagName("input");
             for (i = 0; i < rdBtnList.length; i++) {
                 if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                     rdBtnList[i].checked = false;
                 }

             }
         }
         
     </script>
      <div class="container" runat="server" id="transactionsPage">
    

          <table class="customTable table-condensed" >
              <tr>

         <td>
             <span class="zoom_img" >
            <asp:Image ID="item_pic" CssClass="img-responsive" runat="server" />
              </span>
       
       
               <h2>Bidded Item</h2>
                <p></p>
                <h3>Item Name</h3>
                 <p>
                     <asp:Label ID="itemName" runat="server"></asp:Label>
                </p>
       


                <h3><asp:Label ID="descriptionHeader" Text="Description" runat="server"></asp:Label></h3>
                   <p>
                       <asp:Label ID="itemDescription" runat="server"></asp:Label>
                </p>
                <h3><asp:Label ID="itemBarCodeHeader" Text="Item BarCode" runat="server"></asp:Label></h3>
                   <p>
                      <asp:Label ID="itemBarCode" runat="server" OnDataBinding="Page_Load"></asp:Label>
                </p>
                <h3><asp:Label ID="itemOwnerHeader" Text="Item Owner" runat="server"></asp:Label></h3>
                   <p>
                      <asp:Label ID="itemOwner" runat="server" OnDataBinding="Page_Load"></asp:Label>
                </p>

             </td>
                  <td>
                <h2><asp:Label ID="OwnerOrBidderInformationHeader"  runat="server"></asp:Label></h2>
                
               
                        <h3>Contact's User Tag</h3>
                  <p>
                     <asp:Label ID="contact_usr" runat="server"></asp:Label>
                  </p>  <h3>Contact's Full Name</h3><p>
                     <asp:Label ID="contact_fullName" runat="server"></asp:Label>
                   </p>  <h3>Contact's Email</h3><p>
                     <asp:Label ID="contact_email" runat="server"></asp:Label>
                   </p>  


                  </td>
        </tr>
              
                <tr>
                    <td colspan="2">
                <h2><asp:Label ID="OfferdItemsHeader"  runat="server"></asp:Label></h2>
                   <asp:GridView ID="GridView1"  CssClass="table table-responsive table-hover" HorizontalAlign="Center" GridLines="None"  runat="server" AllowSorting="True"  AllowPaging="True"  AutoGenerateColumns="False"  >
                        <Columns>                                 

                            <asp:TemplateField>
                                <ItemTemplate>

                                    <asp:RadioButton ID="rdio_items" runat="server" GroupName="sel" OnClick="javascript:SelectRadiobutton(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:ImageField DataImageUrlField ="Image" NullDisplayText="no image" ControlStyle-CssClass="img-responsive img-css" >
                               
                            <ControlStyle CssClass="img-responsive img-css"></ControlStyle>
                               
                            </asp:ImageField>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Comments" HeaderText="Comments" />
                        
                            <asp:BoundField DataField="id" HeaderText="Item BarCode" /> 

                        </Columns>
                </asp:GridView>
        
                </td>

             
                 </tr>
                   
              
              
              
              <tr>
                  <td>
                <h2><asp:Label ID="BidOrOfferHeader" Text="" runat="server"></asp:Label></h2>
                   <p>
                       <asp:Button ID="cancel_cmd" runat="server" Text="Cancel Bid" CssClass=" btn btn-success" OnClick="cancel_cmd_Click"/>      
                </p>
                    <p>
                        <asp:Button ID="BackToList" runat="server" Text="<< Back to list" CssClass=" btn btn-primary" OnClick="BackToList_Click"/>
                    </p>
                    <p>
                        <asp:Button ID="Confirm_cmd" runat="server" Text="Confirm Offer" CssClass=" btn btn-primary" OnClick="Confirm_cmd_Click"/>
                        <asp:Label ID="confirm_label" Text="Note:By confirming the offer ,You commite to the Transaction" runat="server"></asp:Label>
                    </p>
         
                  </td>
              </tr>    
      <!--
             
              <h2>Side news</h2>
               <ul class="list-group"> 
                  <li class="list-group-item"><a  href="#"><label>Incoming Offers</label></a></li>
                   <li class="list-group-item"><a  href="Home.aspx"><label>Home</label></a></li>
                   <li class="list-group-item"><asp:HyperLink  ID="contactUs" NavigateUrl="#contact" data-toggle="modal" runat="server"><label>Contact Us</label></asp:HyperLink></li>
                   <li class="list-group-item"><a  href="index.html"><label>Terms of Use</label></a></li>
               </ul>
           <br/> 
           <br/>  /n/n --->
  
     </table>  

</div>




       
</asp:Content>
