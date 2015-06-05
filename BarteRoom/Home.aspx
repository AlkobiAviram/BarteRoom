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
	    <label for="id1">
		    <img id="img0"  Width="100" runat="server" />
	    </label>
	    <img id="img00" src="" runat="server" width="640" height="320" runat="server"/>
	
	    <!--Lets show the second image by default on page load-->
	    <input type="radio" name="slide_switch" id="id2" />
	    <label for="id2">
		    <img id="img1"  Width="100" runat="server" />
	    </label>
	    <img id="img11" src="" runat="server" width="640" height="320" runat="server"/>
	
	    <input type="radio" name="slide_switch" id="id3"/>
        <label for="id3">
		    <img id="img2"  Width="100" runat="server" />
	    </label>
	    <img id="img22" src="" runat="server" width="640" height="320" runat="server"/>
	
	    <input type="radio" name="slide_switch" id="id4"/>
        <label for="id4">
		    <img id="img3"  Width="100" runat="server" />
	    </label>
	    <img id="img33" src="" runat="server" width="640" height="320" runat="server"/>
	
	    <input type="radio" name="slide_switch" id="id5"/>
        <label for="id5">
		    <img id="img4"  Width="100" runat="server" />
	    </label>
	    <img id="img44" src="" runat="server" width="640" height="320" runat="server"/>
    </div>

    <!-- We will use PrefixFree - a script that takes care of CSS3 vendor prefixes
    You can download it from http://leaverou.github.com/prefixfree/ -->
    <script src="http://thecodeplayer.com/uploads/js/prefixfree.js" type="text/javascript"></script>

        <!-- We will use PrefixFree - a script that takes care of CSS3 vendor prefixes
        You can download it from http://leaverou.github.com/prefixfree/ -->
        <script src="http://thecodeplayer.com/uploads/js/prefixfree.js" type="text/javascript"></script>


                   <!-- ==============================================buttom row===========================================  -->
             
             


            
                 <!-- ===================================================Main container=======================================================  -->

        </asp:Content>
