<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/bootstrap.css"  rel="stylesheet" />
   
    <title></title>
</head>
<body>
     <script type="text/javascript" src="Scripts/jquery-1.9.1.js"> </script>
    <script type="text/javascript" src="Scripts/bootstrap.js"> </script>
  

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
                        <li><a href="#">Something else here</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Separated link</a></li>
                        <li class="divider"></li>
                        <li><a href="#">One more separated link</a></li>
                      </ul>
                    </li>
                  </ul>
                  <form class="navbar-form navbar-left" role="search">
                    <div class="form-group">
                      <input type="text" class="form-control" placeholder="Search">
                    </div>
                    <button type="submit" class="btn btn-default">Submit</button>
                  </form>
                 
                </div><!-- /.navbar-collapse -->
              </div><!-- /.container-fluid -->
            </nav>
    </header>
    
     
    
     </div>
     <form id="form1" runat="server">
        
         <div class="container">
            <div class="row">

                <div class="col-md-3" >
                   
                </div>
                 <div class="col-md-6">
                     
                     <div id="Home_Carousel" class="carousel">
                         <ol class="carousel-indicators">
                             <li data-target="#Home_Carousel" data-slide-to="0" class="active"></li>
                             <li data-target="#Home_Carousel" data-slide-to="1"></li>
                             <li data-target="#Home_Carousel" data-slide-to="2"></li>
                         </ol>

                         <div class="carousel-inner">
                             <div class="item active">
                                 <img src="#" alt="picture1" class="img-responsive" />
                             </div>
                         </div>
                     </div>   

                </div>
                 <div class="col-md-3">
                     
                </div>


            </div>
        </div>
    </form>
</body>
</html>
