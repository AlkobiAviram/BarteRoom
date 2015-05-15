<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/bootstrap.css"  rel="stylesheet" />
    <link href="Content/style.css"  rel="stylesheet" />
   
    <title></title>
</head>
<body>
     <script type="text/javascript" src="Scripts/jquery-1.9.1.js"> </script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"> </script>
  

    <header>
         <nav class="navbar navbar-default">
              <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                               
                    <a class="navbar-brand" href="#">BarteRoom</a>
               
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                  <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Home <span class="sr-only">(current)</span></a></li>
                    <li><a href="#">About Us</a></li>
                     <li><a href="#">Link 1</a></li>
                     <li><a href="#">Link 2</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">My Account <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="#">Action</a></li>
                        <li><a href="#">Another action</a></li>
                   
                      </ul>
                    </li>
                  </ul>
                  
                </div><!-- /.navbar-collapse -->
              </div><!-- /.container-fluid -->
            </nav>
        </header>
    
     
    
     
     <form id="form1" runat="server">
        
         <div class="container">
            <div class="row row-css-custom">

                <div class="col-md-3" >
                   <div class="jumbotron jumbo-css-custom">
                       <h3>find a barter partner now!</h3>
                  </div>
                 
                </div>
                 <div class="col-md-6">
                     
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
                 <div class="col-md-3">
                   <div class="jumbotron jumbo-css-custom">
                       <h3>Best Deal of your life?</h3>
                  </div>
                </div>    

            </div>

              <div class="row row-css-custom">
                 <div class="col-md-4">
                     <div class="jumbotron">
                         <h3>
                             somthing!!
                         </h3>
                     </div>
                 </div>
                  <div class="col-md-4">
                       <div class="jumbotron">
                         <h3>
                             somthing differnt!!
                         </h3>
                     </div>
                 </div>
                  <div class="col-md-4">
                       <div class="jumbotron">
                         <h3>
                             somthing else!!
                         </h3>
                     </div>
                 </div>
             </div>
          
             
            


        </div>

          <div class="navbar navbar-default navbar-fixed-bottom "> 
                 <div class="container">
                    <p class="navbar-text"> About Us </p>
                     <p class="navbar-text"> Copyrights </p>
                     <p class="navbar-text"> Site is Powered by nadav mor </p>
                  </div>
          </div>
    </form>
</body>
</html>
