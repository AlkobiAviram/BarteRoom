<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BarteRoom.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="Scripts/jquery.parallax-scroll.js"> </script>
     <script type="text/javascript" src="Scripts/jquery.parallax-scroll.min.js"> </script>
 
    <div id="pic1" class="bg-holder" data-width="1024" data-height="768">
	</div>

    <section>
	     <div class="container">
            <h1>Section 1</h1>
            <p>laurem ipsum laurem ipsum laurem ipsum laurem ipsum laurem ipsum laurem ipsum </p>
	    </div> 

    </section>			                                                                         
    
    <div id="pic2" class="bg-holder" data-width="1024" data-height="768">
    </div>
    
    <section>
        <div class="container">
        <h1>Section 2</h1>
        <p>laurem ipsum laurem ipsum laurem ipsum laurem ipsum laurem ipsum laurem ipsum </p>
        </div>
    </section>

    <div id="pic3" class="bg-holder" data-width="1024" data-height="768">
    </div>
		
        

    <style>

            html,
            body {
              width: 100%;
              height: 100%;
            }

            .bg-holder {
              width: 100%;
              height: 100%;
            }

            .bg-holder#pic1 {
              background-image: url('/img/pic1.jpg');

              
            }

            .bg-holder#pic2 {
              background-image: url('/img/pic2.jpg');
            }
            .bg-holder#pic3 {
              background-image: url('/img/pic3.jpg');
            }

            

            @media (min-width: 768px) {
              .bg-holder#pic1 {
                background-image: url('img/pic1_bigger.jpg');
               
              }
              .bg-holder#pic2 {
                background-image: url('img/pic2_bigger.jpg');
              }
              .bg-holder#pic3 {
                background-image: url('img/pic3_bigger.jpg');
              }
            }

    </style>
    		
    <script type="text/javascript">
        $(document).ready(function () {

            console.log('in parallax scroll');
            $('.bg-holder').parallaxScroll({
                friction: 0.5
            });

        });
    </script>
    
<div class="modal-footer">
    <button class="btn btn-info" data-dismiss="modal"> Share </button>
</div>
             
</asp:Content>