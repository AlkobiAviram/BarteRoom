<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- ==============================================Main container===========================================  -->
         <div class="container">

            <div class="row row-css-custom">

                <div class="col-md-6" >
                  <div class="list-group links-css-custom" >
                      <a href="#" class="list-group-item active ">
                        Barter Info Center
                      </a>
                      <a href="#" class="list-group-item">dummy</a>
                      <a href="#" class="list-group-item">dummy</a>
                      <a href="#" class="list-group-item">dummy</a>
                      <a href="#" class="list-group-item">dummy</a>
                    </div>
                </div>
                
                 <div class="col-md-6">
                     <div class="jumbotron jumbo-css-custom">
                       <h3>Some content</h3>
                  </div>
                </div>    
            </div>

             <div class="row row-css-custom">
                 <div class="col-md-10 col-md-offset-1">
                     
                     <div id="Home_Carousel" class="carousel slide">
                         <ol class="carousel-indicators">
                             <li data-target="#Home_Carousel" data-slide-to="0" class="active"></li>
                             <li data-target="#Home_Carousel" data-slide-to="1"></li>
                             <li data-target="#Home_Carousel" data-slide-to="2"></li>
                         </ol>

                         <div class="carousel-inner">
                             <div class="item active">
                                 <img src="img/img1.jpg" alt="picture1" class="img-responsive" />
                                 <div class="carousel-caption">
                                     <h3>Gerrard is the best scorer!</h3>
                                 </div>
                             </div>
                             <div class="item">
                                 <img src="img/img2.jpg" alt="picture2" class="img-responsive" />
                                 <div class="carousel-caption">
                                     <h3>Gerrard is the best passer!</h3>
                                 </div>
                             </div>
                              <div class="item">
                                 <img src="img/img3.jpg" alt="picture3" class="img-responsive" />
                                  <div class="carousel-caption">
                                     <h3>Gerrard is the best player!</h3>
                                 </div>
                             </div>
                         </div>
                         <a class="carousel-control left" href="#Home_Carousel" data-slide="prev">
                             <span class="prev"></span>
                         </a>
                          <a class="carousel-control right" href="#Home_Carousel" data-slide="next">
                             <span class="next"></span>
                         </a>
                     </div>   
                </div>
             </div>

             <!-- ==============================================buttom row===========================================  -->
             <div class="row row-css-custom">
                 <div class="col-md-4">
                     <div class="jumbotron">
                         <h3>
                             something!!
                         </h3>
                     </div>
                 </div>
                  <div class="col-md-4">
                       <div class="jumbotron">
                         <h3>
                             something differnt!!
                          
                         </h3>
                     </div>
                 </div>
                  <div class="col-md-4">
                       <div class="jumbotron">
                         <h3>
                             somtehing else!!
                         </h3>
                     </div>
                 </div>
             </div>
           <!-- ==============================================buttom row===========================================  -->
             
             


        </div>
         <!-- ===================================================Main container=======================================================  -->

</asp:Content>
