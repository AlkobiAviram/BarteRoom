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
 
        <ul class='footer'>
          <li class='entypo-bell'></li>
          <li class='entypo-mic'></li>
          <li class='entypo-megaphone'></li>
        </ul>
        <label for='dole' class='entypo-left-bold otra'></label>
        <label for='tele' class='entypo-right-bold otra'></label>
        <label for='uno' class='entypo-arrows-ccw afin'></label>  
      </article>
  
      <article class='card dos'>
     
        <ul class='footer'>
          <li class='entypo-network'></li>
          <li class='entypo-qq'></li>
          <li class='entypo-picasa'></li>
        </ul>
        <label for='tele' class='entypo-left-bold otra'></label>
        <label for='uno' class='entypo-right-bold otra'></label>
        <label for='dole' class='entypo-arrows-ccw afin'></label>  
      </article>
  
      <article class='card tres'>
       
        <ul class='footer'>
          <li class='entypo-ccw'></li>
          <li class='entypo-arrows-ccw'></li>
          <li class='entypo-cw'></li>
        </ul>
        <label for='uno' class='entypo-left-bold otra'></label>
        <label for='dole' class='entypo-right-bold otra'></label>
        <label for='tele' class='entypo-arrows-ccw afin'></label>  
      </article>

            <article class='card otra'>
        <ul class='footer'>
          <li class='entypo-ccw'></li>
          <li class='entypo-arrows-ccw'></li>
          <li class='entypo-cw'></li>
        </ul>
        <label for='uno' class='entypo-left-bold otra'></label>
        <label for='dole' class='entypo-right-bold otra'></label>
        <label for='tele' class='entypo-arrows-ccw afin'></label>  
      </article>

    </section>
    <div>
    </div>
            </asp:Content>

