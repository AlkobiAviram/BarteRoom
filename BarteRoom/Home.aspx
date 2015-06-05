        <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


             <!-- ==============================================Main container===========================================  -->
               
           

         
                     <!-- ==============================================buttom row===========================================  -->
                     <link href="imageSlider.css" rel="stylesheet" type="text/css" />
           <!--
        We will make a slider with stylized thumbnails using CSS3
        The markup is very simple:
        Radio Inputs
        Labels with thumbnails to detect click event
        Main Image
        -->
       <!--
    We will make a slider with stylized thumbnails using CSS3
    The markup is very simple:
    Radio Inputs
    Labels with thumbnails to detect click event
    Main Image
    -->
    <div class="slider">
	    <input type="radio" name="slide_switch" id="id1" checked="checked"/>
	    <label for="id1"   runat="server">
		    <img src="fff" id="img0"  width="100" runat="server" />
	    </label>
	  <!--  <img id="img00" src="" runat="server" style="width:640px;height:320px;" /> -->
	    <img src="fff" id="img000" width="640" height="320" runat="server" onclick="onClick0()" />
      
	    <!--Lets show the second image by default on page load-->
	    <input type="radio" name="slide_switch" id="id2" />
	    <label for="id2">
		    <img src="fff" id="img1"  width="100" runat="server" />
	    </label>
	    <img src="fff" id="img11"  runat="server" style="width:640px;height:320px;"  />
	
	    <input type="radio" name="slide_switch" id="id3"/>
        <label for="id3">
		    <img src="fff" id="img2"  width="100" runat="server" />
	    </label>
	    <img src="fff" id="img22"  width="640" height="320" runat="server"/>
	
	    <input type="radio" name="slide_switch" id="id4"/>
        <label for="id4">
		    <img src="fff" id="img3"  width="100" runat="server" />
	    </label>
	    <img src="fff" id="img33"  runat="server" width="640" height="320" />
	
	    <input type="radio" name="slide_switch" id="id5"/>
        <label for="id5">
		    <img src="fff" id="img4"  width="100" runat="server" />
	    </label>
	    <img id="img44" src="dd" runat="server" width="640" height="320" />
    </div>

    <!-- We will use PrefixFree - a script that takes care of CSS3 vendor prefixes
    You can download it from http://leaverou.github.com/prefixfree/ -->
    <script src="http://thecodeplayer.com/uploads/js/prefixfree.js" type="text/javascript"></script>

        <!-- We will use PrefixFree - a script that takes care of CSS3 vendor prefixes
        You can download it from http://leaverou.github.com/prefixfree/ -->
        <script src="http://thecodeplayer.com/uploads/js/prefixfree.js" type="text/javascript"></script>


                   <!-- ==============================================buttom row===========================================  -->
             
             


            
                 <!-- ===================================================Main container=======================================================  -->
<script>
    function onClick0() {
  
        window.location.href("Default2.aspx");
    }
</script>
        </asp:Content>

