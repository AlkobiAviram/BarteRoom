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
            <h1>About Apps</h1>
            <p>this is our home! BarteRoom is an app for everyone! </p>
            <p> if you have somthing you need and dont want is first hand for an intial price , you can just open an account with barteroom amd look for what you need.</p>
            <p> if you find a partner to switch with you are good to go </p>
	    </div> 

    </section>			                                                                         
    
    <div id="pic2" class="bg-holder" data-width="1024" data-height="768">
    </div>
    
    <section>
        <div class="container">
        <h1>How to use</h1>
             <p>-Surf to the website and login to your account. 
                now you will be at the home page.</p>
             <p>-Now you be able to go to your private account page.-</p>
             <p>-Look for any requests from other users who wish to trade one of your items.</p>
             <p>the request is made of a request for one of your item and an offer from the sender's items list for your item. </p>
             <p>If there is a request,you have two posibilites: </p>
            <p>1.Ignore: if you press that button ,the user who sent the request will get an declain message. </p>
            <p>2.Accept: if you press that button ,you and the other user will get each other's contact information.</p>
            <p>-Also you can make your own requests to other users for any item you wish to own. </p>
            <p>To do this :</p>
            <p>1.search for an item you wish to have. 
                2.choose one or more of your items to offer for that item,by check them. 
                3.press the make a reuest buttom. 
                Now wait for the other side to respond.</p>
            <p>-If you wish to to do non of the above ,you can allways manage your items and your wishlist.</p>
        </div>
    </section>


    <section>
        <div class="container">
        <h1>About BART(BarteRoom Team)</h1>
            <p>Gili Mizrahi-    info:...</p> 
            <p>Nadav Mor-       info:...</p>
            <p>Aviram Alkobi-   info:...</p>
            <p>Netanel Gabay-   info:...</p>
        </div>
    </section>

    <section>
        <div class="container">
        <h1>Contact Us</h1>
             <asp:HyperLink ID="contactUs" CssClass="change" NavigateUrl="#contact" data-toggle="modal" runat="server">Contact Us</asp:HyperLink>
        </div>
    </section>


  <section>
        <div class="container">
        <h1>Terms of Use</h1>
               <ul> 
                 <li class="list-group-item"><a  href="TermsOfUse.aspx"><label>Terms of Use</label></a></li>
                </ul>
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