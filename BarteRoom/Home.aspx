            <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>       
     <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <link href="css/imageSlider.css" rel="stylesheet"/>
            <style>
            .img_slider{
                box-shadow: 0 0 6rem rgba(0,0,0,1);
                border-radius: 3px;
          -webkit-transition: all 1s ease;
          -moz-transition: all 1s ease;
           -o-transition: all 1s ease;
           -ms-transition: all 1s ease;
             transition: all 1s ease;
             }
 
         .img_slider:hover {
          -webkit-filter: blur(5px);
          }
            </style>
         
  <div  runat="server" id="welcomeHome">
<table>
    <tr>
        <td >
         <h2><asp:Label ID="Label1" runat="server" Text="Check out our latest Items"></asp:Label></h2><br />
        </td>
    </tr>
<!-----------------------------Image Silder------------------------------------------------------>
        
    
            <tr>
            
            <td style="text-align:center" >
            
         <asp:ImageButton  CssClass="img_slider" ID="slider" ImageUrl="~/img/ipad.jpg" runat="server"  OnClick="slider_Click"/>
          </td> 
                <td>
                    <h2><asp:Label ID="Label3" runat="server" Text="Browse with Categories"></asp:Label></h2><br />
                    <asp:Button ID="cat1" runat="server" Text="Button" Width="100%"/><p />
                    <asp:Button ID="cat2" runat="server" Text="Button" Width="100%" /><p />
                    <asp:Button ID="cat3" runat="server" Text="Button" Width="100%"/><p />
                    <asp:Button ID="cat4" runat="server" Text="Button" Width="100%"/><p />
                    <asp:Button ID="cat5" runat="server" Text="Button" Width="100%"/><p />
                    <asp:Button ID="cat6" runat="server" Text="Button" Width="100%"/><p />
                    <asp:Button ID="cat7" runat="server" Text="Button" Width="100%"/>
                 
                </td>
            </tr>
            <tr>
            <td style="text-align:center">
         <asp:ImageButton ID="ImageButton1"  runat="server"  OnClick="ImageButton1_Click" />
           
         <asp:ImageButton ID="ImageButton2"  runat="server"  OnClick="ImageButton2_Click"/>
             
         <asp:ImageButton ID="ImageButton3"  runat="server"  OnClick="ImageButton3_Click"/>

          <asp:ImageButton ID="ImageButton4" runat="server"  OnClick="ImageButton4_Click"/>
           </td>
         </tr>
      
<!-----------------------------MostViewedItems------------------------------------------------------>
           <tr>
            
            <td style="text-align:center">
            <h2><asp:Label ID="Label2" runat="server" Text="Most Viewed Items"></asp:Label></h2><br />
         <asp:GridView ID="GridView1" BackColor="White" CssClass="table table-responsive table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
             <Columns>
                 <asp:ImageField DataImageUrlField="image">
                 </asp:ImageField>
                 <asp:BoundField DataField="comments" />
                 <asp:BoundField DataField="id" Visible="false" />
             </Columns>
         </asp:GridView>


<!----------------------------------------------------------------------------------->
          </td>
        </tr>
 
</table>


</div>
            </asp:Content>

