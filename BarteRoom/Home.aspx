        <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>       
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


             


             <!-- ==============================================Main container===========================================  -->
               
           

         
                     <!-- ==============================================buttom row:image slider===========================================  -->
         <div class="row" runat="server" id="welcomeHome">
             <div class="jumbotron">
                 <h1>Welcome to BarteRoom</h1>
                 <h3><span> your home for second hand barters </span></h3>
             </div>
         </div>              
            
        <div class="slider" runat="server" id="homePhotos" >



             <!--Lets show the first image by default on page load-->
            	      <!--  picture number 0 --> 
	        <input type="radio" name="slide_switch" id="id1" checked="checked"  />
            <label for="id1" runat="server">
		        <img src="fff" id="img0"  width="100" runat="server" />
	        </label>
	        <img src="fff" id="img000" width="640" height="320" runat="server" />
      


	                       <!--  picture number 1 -->

	        <input type="radio" name="slide_switch" id="id2"  />
	        <label for="id2">
		        <img src="fff" id="img1"  width="100" runat="server" />
	        </label>
	        <img src="fff" id="img11"  runat="server" style="width:640px;height:320px;"  />
	


	                       <!--  picture number 2 -->
	        <input type="radio" name="slide_switch" id="id3"  />
            <label for="id3">
		        <img src="fff" id="img2"  width="100" runat="server" />
	        </label>
	        <img src="fff" id="img22"  width="640" height="320" runat="server"/>
	


	                       <!--  picture number 3 -->
	        <input type="radio" name="slide_switch" id="id4"  />
            <label for="id4">
		        <img src="fff" id="img3"  width="100" runat="server" />
	        </label>
	        <img src="fff" id="img33"  runat="server" width="640" height="320" />
	

	                       <!--  picture number 4 -->
	        <input type="radio" name="slide_switch" id="id5"  />
            <label for="id5">
		        <img src="fff" id="img4"  width="100" runat="server" />
	        </label>
	        <img id="img44" src="dd" runat="server" width="640" height="320" />
            <br /><br />

            


        </div>

    <script type="text/javascript" >

         function test(id) {
             //   if (id == "id0")

          window.location.href = "/ItemView.aspx";

        }

    </script>

                   <!-- ==============================================buttom row===========================================  -->
             
             


            
                 <!-- ===================================================Main container=======================================================  -->

        </asp:Content>

