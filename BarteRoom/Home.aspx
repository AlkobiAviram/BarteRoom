            <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>       
     <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <link href="css/imageSlider.css" rel="stylesheet" type="text/css" runat="server"/>
      <style>
       .customTd {
           width:200px;
           height:200px;

           
       }
       .customTd1{
          background-color:white;
          border:1px solid #4682B4;
       }
   </style>
         
  <div  runat="server" id="welcomeHome">
<table class="table-hover">
    <tr>
        <td class="customTd">
         <h2><asp:Label ID="Label1" runat="server" Text="Check out our latest Items"></asp:Label></h2><br />
<!-----------------------------Image Silder------------------------------------------------------>
        <section class='galeria' id="imgSlider" runat="server">
        <input type="radio" id="uno" value="1" name="tractor" checked='checked' />    
        <input type="radio" id="dole" value="2" name="tractor" />      
        <input type="radio" id="tele" value="3" name="tractor" />
      


             <article class='card una'>
        <label for='dole' class='entypo-left-bold otra'></label>
        <label for='tele' class='entypo-right-bold otra'></label>
        <label for='uno' class='entypo-arrows-ccw afin'></label>
           <asp:ImageButton ID="image1" runat="server" OnClick="image1_Click" />
           <h2 ><asp:HyperLink ID="image1Link" Text="ccccc" runat="server" /></h2>
           
      </article>
  
   
             
                <article class='card dos'>
        <label for='tele' class='entypo-left-bold otra'></label>
        <label for='uno' class='entypo-right-bold otra'></label>
        <label for='dole' class='entypo-arrows-ccw afin'></label>
         <asp:ImageButton ID="image2"  runat="server" OnClick="image2_Click" />
           <h2 ><asp:HyperLink ID="image2Link"  Text="ccccc" runat="server" /></h2>
      </article>
  
     
             
              <article class='card tres'>
        <label for='uno' class='entypo-left-bold otra'></label>
        <label for='dole' class='entypo-right-bold otra'></label>
        <label for='tele' class='entypo-arrows-ccw afin'></label> 
         <asp:ImageButton ID="image3" runat="server" OnClick="image3_Click" /> 
           <h2 ><asp:HyperLink ID="image3Link" Text="ccccc" runat="server" /></h2>
      </article>


    </section>
<!----------------------------------------------------------------------------------------->
        </td>
        </tr>
        <tr>
            <td class="customTd">
<!-----------------------------MostViewedItems------------------------------------------------------>
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

