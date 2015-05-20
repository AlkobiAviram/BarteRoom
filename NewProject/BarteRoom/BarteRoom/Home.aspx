<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/bootstrap.css"  rel="stylesheet" />
    <link href="Content/style.css"  rel="stylesheet" />
   
    <title>BarteRoom</title>
</head>
<body>
     <script type="text/javascript" src="Scripts/jquery-1.9.1.js"> </script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"> </script>
  
  <form id="form1" runat="server">
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
                    <!--img src="img/img4.jpg" class="img-responsive" /-->
               
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                  <ul class="nav navbar-nav">
                    <li class="active"> <a href="/Home.aspx"> Home <span class="sr-only">(current)</span></a></li>
                    <li><a href="#">About Us</a></li>
                     <li><a href="#login" data-toggle="modal">Login</a></li>
                     <li><a href="#register" data-toggle="modal">Register</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">My Account <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="/BarterList.aspx">Edit your Barter list</a></li>
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
                       <h3>Some content</h3>
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
         
         
         <!-- ===================================================Login Modal=======================================================  -->
         <div class="modal fade" id="login" role="dialog" >
             <div class="modal-dialog ">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h3>Login</h3>
                     </div>
                     <div class="modal-body">
                          <asp:RequiredFieldValidator ID="LoginUsernameRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="loginUserNameTxtBox" ValidationGroup="LoginGroup"></asp:RequiredFieldValidator>
                         <span>Username</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic_addon1"></span>
                          <input type="text" class="form-control" placeholder="Enter your username" aria-describedby="basic-addon1" id="loginUserNameTxtBox" runat="server"/>
                        </div>
                         <asp:RequiredFieldValidator ID="LoginPasswordRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="loginPasswordTxtBox" ValidationGroup="LoginGroup"></asp:RequiredFieldValidator>
                          <span>Password</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic_addon2"></span>
                          <input type="Password" class="form-control" placeholder="Enter your Password" aria-describedby="basic-addon1" id="loginPasswordTxtBox" runat="server"/>
                        </div>

                       
                     </div>
                     <div class="modal-footer">
                         <asp:Button class="btn btn-info" ID="Login" runat="server" OnClick="Login_Click" Text="Login" ValidationGroup="LoginGroup"/>
                         <button class="btn btn-info" data-dismiss="modal"> Cancel </button>
                     </div>
                 </div>
             </div>
         </div>
      loginBu
         <!-- ===================================================Login Modal=======================================================  -->

         <!-- ===================================================Register Modal=======================================================  -->
         <div class="modal fade" id="register" role="dialog">
             <div class="modal-dialog ">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h3>Register</h3>
                     </div>
                     <div class="modal-body">
                         
                     <asp:RequiredFieldValidator ID="UsernameRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpUsernameTxtBox" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                         <span>Username</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon3"></span>
                          <input type="text" class="form-control" placeholder="Enter your username" aria-describedby="basic-addon1" id="SignUpUsernameTxtBox" runat="server"/>
                        </div>               

                         <asp:RequiredFieldValidator ID="FirstRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpFirstTxtBox" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                          <span>First name</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon4"></span>
                          <input type="text" class="form-control" placeholder="Enter your first name" aria-describedby="basic-addon1" id="SignUpFirstTxtBox" runat="server"/>
                        </div>

                         <asp:RequiredFieldValidator ID="LastRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpLastTxtBox" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                           <span>Last name</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon5"></span>
                          <input type="text" class="form-control" placeholder="Enter your last name" aria-describedby="basic-addon1" id="SignUpLastTxtBox" runat="server"/>
                        </div>

                         <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpPasswordTxtBox" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                         <span>Password</span>
                         <asp:RegularExpressionValidator ID="PasswordExpression" runat="server" ControlToValidate="SignUpPasswordTxtBox" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="*" ForeColor="Red" />
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon6"></span>
                          <input type="Password" class="form-control" placeholder="Min 8 characters atleast 1 Alphabet and 1 Number" aria-describedby="basic-addon1" id="SignUpPasswordTxtBox" runat="server"/>
                        </div>                         
                        <asp:RequiredFieldValidator ID="ConfirmRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpConfirmTxtBox" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                         <span>Confirm Password</span>
                         <asp:CompareValidator ID="ComparePasswords" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpPasswordTxtBox" ControlToCompare="SignUpConfirmTxtBox" ValidationGroup="SignUpGroup"></asp:CompareValidator>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon7"></span>
                          <input type="Password" class="form-control" placeholder="Confirm Password" aria-describedby="basic-addon1" id="SignUpConfirmTxtBox" runat="server"/>
                        </div>

                         <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SignUpEmailTxtBox" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                           <span>E-mail</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon8"></span>
                          <input type="email" class="form-control" placeholder="Enter your email" aria-describedby="basic-addon1" id="SignUpEmailTxtBox" runat="server"/>
                        </div>
 
                     </div>
                     <div class="modal-footer">
                         <asp:Button class="btn btn-info" ID="SignUp" runat="server" OnClick="SignUp_Click" Text="SignUp" ValidationGroup ="SignUpGroup"/>
                         <button class="btn btn-info" data-dismiss="modal"> Close </button>
                     </div>
                     <asp:Label ID="comments" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                 </div>
             </div>
         </div>
         <!-- ===================================================Register Modal=======================================================  -->


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
