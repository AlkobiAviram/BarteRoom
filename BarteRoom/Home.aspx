            <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>       
     <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="css/imageSlider.css" rel="stylesheet" type="text/css" runat="server"/>

         <section class='galeria' runat="server">
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
    <div>
    </div>
            </asp:Content>

