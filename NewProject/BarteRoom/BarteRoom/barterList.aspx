<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/bootstrap.css"  rel="stylesheet" />
    <link href="Content/style.css"  rel="stylesheet" />
   
    <title>My Barter List</title>
</head>
<body>
     <script type="text/javascript" src="Scripts/jquery-1.9.1.js"> </script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"> </script>
  
  <form id="form2" runat="server">
        <header>
            <nav class="navbar navbar-default ">
              <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                               
                    <a class="navbar-brand" href="/Home.aspx">BarteRoom</a>
               
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                  <ul class="nav navbar-nav">
                      <li><a href="#login" data-toggle="modal">LogOut</a></li>
                    <li class="active"><a href="/Home.aspx">Home <span class="sr-only">(current)</span></a></li>
                    <li><a href="#">Suport</a></li>
                     
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">My Account <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="#">Edit your Barter list</a></li>
                        <li><a href="#">Add an Item </a></li>
                        <li><a href="#">Another action </a></li>
                        <li><a href="#">Another action</a></li>
                   
                      </ul>
                    </li>
                  </ul>
                  
                </div><!-- /.navbar-collapse -->
              </div><!-- /.container-fluid -->
            </nav>
        </header>

      <!-- ==============================================Main container===========================================  -->
         <div class="container">

            <div class="row row-css-custom">

                <div class="col-md-3" >
                  <div class="list-group links-css-custom" >
                      <a href="#" class="list-group-item active">
                        Add Item To List
                      </a>
                      <a href="#" class="list-group-item">Remove Item</a>
                      <a href="#" class="list-group-item">Edit Item</a>
                      <a href="#" class="list-group-item">dummy</a>
                      <a href="#" class="list-group-item">dummy</a>
                    </div>
                </div>
                 <div class="col-md-6">
              
                        <ul class="list-group">
                          <li class="alert alert-success">
                            <span class="badge" role="alert">14</span>
                            Name1
                          </li>
                             <li class="alert alert-success">
                            <span class="badge" role="alert">14</span>
                            Name1
                          </li>
                             <li class="alert alert-success">
                            <span class="badge" role="alert">14</span>
                            Name1
                          </li>
                             <li class="alert alert-success">
                            <span class="badge" role="alert">14</span>
                            Name1
                          </li>
                        </ul>

                       

                       </div>
                       <div class="col-md-3">
                          <div>
                                <img src="img/img4.jpg" class="img-responsive" />
                          </div>
                       </div>    
                 </div>   
            </div>
   
          <div class="navbar navbar-default navbar-fixed-bottom "> 
                 <div class="container">
                    <p class="navbar-text"> About Us </p>
                     <p class="navbar-text"> Copyrights </p>
                     <p class="navbar-text"> Site is Powered by BarteRoom team </p>
                  </div>
          </div>
    </form>
</body>
</html>
