<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/bootstrap.css"  rel="stylesheet" />
    <link href="Content/style.css"  rel="stylesheet" />



    <title>nadav's title!!!!!!</title>
   


</head>
<body>
     <script type="text/javascript" src="Scripts/jquery-1.9.1.js"> </script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"> </script>


  <form id="form1" runat="server">


<div id="dialog" style="display: none">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>



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
                      <li><asp:HyperLink ID="manage" NavigateUrl="Manager.aspx" data-toggle="modal" runat="server">Manager Page</asp:HyperLink></li>
                    <li class="active"> <a href="/Home.aspx">Home<span class="sr-only">(current)</span></a></li>
                    <li> <a href="/Aboutus.aspx">About Us<span class="sr-only">(current)</span></a></li>
                      
                     <li><asp:HyperLink ID="log" NavigateUrl="#login" data-toggle="modal" runat="server">Login</asp:HyperLink></li>
                     <li><asp:HyperLink ID="reg" NavigateUrl="#register" data-toggle="modal" runat="server">Register</asp:HyperLink></li>
                      <li><a href="#">About Us</a></li>
                      <li><asp:HyperLink ID="contactUs" NavigateUrl="#contact" data-toggle="modal" runat="server">Contact Us</asp:HyperLink></li>
     
                       <li class="dropdown">
                        <asp:LinkButton ID="MyAccount" runat="server" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="false">My Account<asp:HyperLink ID="caret" runat="server"><span class="caret"></span></asp:HyperLink></asp:LinkButton>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="/BarterList.aspx">My Barter list</a></li>
                        <li><a href="#">Add an Item </a></li>
                        <li><a href="#">Another action </a></li>
                        <li><a href="#">Another action</a></li>
                          <li><asp:LinkButton ID="LogOut" runat="server" OnClick="LogOut_Click">LogOut</asp:LinkButton></li>
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
         
         
         <!-- ===================================================Login Modal=======================================================  -->
         <div class="modal fade" id="login" role="dialog" >
             <div class="modal-dialog ">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h3>Login</h3>
                     </div>
                     <div class="modal-body">
                         
                         <span><asp:ValidationSummary ID="LoginValidationSummary" runat="server" ForeColor="Red" ValidationGroup="LoginGroup" /></span>
                         <span>UserName</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic_addon1"></span>
                          <input type="text" class="form-control" placeholder="Enter Your UserName" aria-describedby="basic-addon1" id="loginUserNameTxtBox" runat="server"/>
                        </div>
                          
                         <span>Password</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic_addon2"></span>
                          <input type="Password" class="form-control" placeholder="Enter Your Password" aria-describedby="basic-addon1" id="loginPasswordTxtBox" runat="server"/>
                        </div>

                       
                     </div>
                     <div class="modal-footer">
                         <asp:Button class="btn btn-info" ID="Login" runat="server" OnClick="Login_Click" Text="Login" ValidationGroup="LoginGroup"/>
                         <button class="btn btn-info" data-dismiss="modal"> Cancel </button>

                         <!-- ===================================================Login Validations=======================================================  -->
                          <asp:RequiredFieldValidator ID="LoginUsernameRequired" runat="server" ErrorMessage="UserName Required" ForeColor="Red" ControlToValidate="loginUserNameTxtBox" ValidationGroup="LoginGroup" Display="None"></asp:RequiredFieldValidator>
                          <asp:RequiredFieldValidator ID="LoginPasswordRequired" runat="server" ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="loginPasswordTxtBox" ValidationGroup="LoginGroup" Display="None"></asp:RequiredFieldValidator>

                     </div>
                 </div>
             </div>
         </div>
      
         <!-- ===================================================Login Modal=======================================================  -->

         <!-- ===================================================Register Modal=======================================================  -->
         <div class="modal fade" id="register" role="dialog">
             <div class="modal-dialog ">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h3>Register</h3>
                     </div>
                     <div class="modal-body">
                         
                    
                        <span><asp:ValidationSummary ID="SignUpValidationSummary" runat="server" ValidationGroup="SignUpGroup" ForeColor="Red" /></span>
                   
                         <span>UserName</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon3"></span>
                              <asp:TextBox ID="SignUpUsernameTxt" runat="server" class="form-control" placeholder="Enter UserName" aria-describedby="basic-addon1"></asp:TextBox>
                         </div>               
                
                         <span>First Name</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon4"></span>
                          <input type="text" class="form-control" placeholder="Enter Your First Name" aria-describedby="basic-addon1" id="SignUpFirstTxtBox" runat="server"/>
                        </div>
  
                          <span>Last Name</span>                
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon5"></span>
                          <input type="text" class="form-control" placeholder="Enter Your Last Name" aria-describedby="basic-addon1" id="SignUpLastTxtBox" runat="server"/>
                        </div>

                        <span>Password</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon6"></span>
                          <input type="Password" class="form-control" placeholder="Enter Password" aria-describedby="basic-addon1" id="SignUpPasswordTxtBox" runat="server"/>
                        </div>                         
                       
                        <span>Confirm Password</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon7"></span>
                          <input type="Password" class="form-control" placeholder="Confirm Password" aria-describedby="basic-addon1" id="SignUpConfirmTxtBox" runat="server"/>
                        </div>

                          <span>E-mail</span>
                         <div class="input-group">
                          <span class="input-group-addon" id="basic-addon8"></span>
                          <input type="email" class="form-control" placeholder="Enter Your E-mail" aria-describedby="basic-addon1" id="SignUpEmailTxtBox" runat="server"/>
                        </div>
 
                     </div>
                     <div class="modal-footer">
                         <asp:Button class="btn btn-info" ID="SignUp" runat="server" OnClick="SignUp_Click" Text="SignUp" ValidationGroup ="SignUpGroup"/>
                         <button class="btn btn-info" data-dismiss="modal"> Close </button>

                          <!-- ===================================================Register Validations=======================================================  -->
                         <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ErrorMessage="UserName Required" ForeColor="Red" ControlToValidate="SignUpUsernameTxt" ValidationGroup="SignUpGroup" Display="None"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="FirstRequired" runat="server" ErrorMessage="First Name Required" ForeColor="Red" ControlToValidate="SignUpFirstTxtBox" ValidationGroup="SignUpGroup" Display="None"></asp:RequiredFieldValidator>
                          <asp:RequiredFieldValidator ID="LastRequired" runat="server" ErrorMessage="Last Name Required" ForeColor="Red" ControlToValidate="SignUpLastTxtBox" ValidationGroup="SignUpGroup" Display="None"></asp:RequiredFieldValidator>
                          <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="SignUpPasswordTxtBox" ValidationGroup="SignUpGroup" Display="None"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="PasswordExpression" runat="server" ControlToValidate="SignUpPasswordTxtBox" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must be Min 8 characters, atleast 1 Alphabet and 1 Number" ForeColor="Red" Display="None" ValidationGroup="SignUpGroup"/>
                         <asp:RegularExpressionValidator ID="FirstExpression" runat="server" ControlToValidate="SignUpFirstTxtBox" ValidationExpression="^[a-zA-Z ]*$" ErrorMessage="Invalid character in First Name" ForeColor="Red" Display="None" ValidationGroup="SignUpGroup"/>
                         <asp:RegularExpressionValidator ID="LastExpression" runat="server" ControlToValidate="SignUpLastTxtBox" ValidationExpression="^^[a-zA-Z ]*$" ErrorMessage="Invalid character in Last Name" ForeColor="Red" Display="None" ValidationGroup="SignUpGroup"/>
                          <asp:RequiredFieldValidator ID="ConfirmRequired" runat="server" ErrorMessage="Confirm Password Required" ForeColor="Red" ControlToValidate="SignUpConfirmTxtBox" ValidationGroup="SignUpGroup" Display="None"></asp:RequiredFieldValidator>
                          <asp:CompareValidator ID="ComparePasswords" runat="server" ErrorMessage="Password and Confirm are not equals" ForeColor="Red" ControlToValidate="SignUpPasswordTxtBox" ControlToCompare="SignUpConfirmTxtBox" ValidationGroup="SignUpGroup" Display="None"></asp:CompareValidator>
                          <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ErrorMessage="E-mail Required" ForeColor="Red" ControlToValidate="SignUpEmailTxtBox" ValidationGroup="SignUpGroup" Display="None"></asp:RequiredFieldValidator>


                     </div>
                     
                 </div>
             </div>
         </div>
         <!-- ===================================================Register Modal=======================================================  -->

         <!-- ===================================================Contact Modal========================================================  -->
    <div class="modal fade" id="contact" role="dialog" >
             <div class="modal-dialog ">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h3>Send Us a Message</h3>
                     </div>
                     <div class="modal-body">
                       
                         <span><asp:ValidationSummary ID="SendValidationSummary" runat="server" ValidationGroup="SendGroup" ForeColor="Red"/></span>
                    
                          <div class="input-group">
                          <span class="input-group-addon" id="basic_addon2"></span>
                             <asp:TextBox ID="firsTxt" class="form-control" runat="server" placeholder="First Name" aria-describedby="basic-addon1"></asp:TextBox>
                              <asp:TextBox ID="lastTxt" class="form-control" runat="server" placeholder="Last Name" aria-describedby="basic-addon1"></asp:TextBox>
                        </div>
                        
                        <br />

                         <div class="input-group">
                          <span class="input-group-addon" id="basic_addon1"></span>
                          <input type="text" class="form-control" placeholder="Subject" aria-describedby="basic-addon1" id="SubTxt" runat="server" style="border-width: medium; border-style: solid;" />
                        </div>
                             
                        
                         <div class="input-group">
                          <span class="input-group-addon" id="basic_addon2"></span>
                             <asp:TextBox ID="messageTxt" class="form-control" runat="server" placeholder="Enter your message here" aria-describedby="basic-addon1" TextMode="MultiLine" Height="100"></asp:TextBox>
                        </div>
      
                     </div>
                     <div class="modal-footer">
                         <asp:Button class="btn btn-info" ID="Send" runat="server" OnClick="Send_Click" Text="Send" ValidationGroup="SendGroup"/>
                         <button class="btn btn-info" data-dismiss="modal"> Cancel </button>

                         <!--=================================================Contact validations=========================================================== -->
                        <asp:RequiredFieldValidator ID="SendFirstRequired" runat="server" ErrorMessage="Please enter your firs name" ForeColor="Red" ControlToValidate="firsTxt" ValidationGroup="SendGroup" Display="None"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="SendLastRequired" runat="server" ErrorMessage="Please enter your last name" ForeColor="Red" ControlToValidate="lastTxt" ValidationGroup="SendGroup" Display="None"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="SendSubjectRequired" runat="server" ErrorMessage="Please enter Subject" ForeColor="Red" ControlToValidate="SubTxt" ValidationGroup="SendGroup" Display="None"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="SendMessageRequired" runat="server" ErrorMessage="Please enter Message" ForeColor="Red" ControlToValidate="messageTxt" ValidationGroup="SendGroup" Display="None"></asp:RequiredFieldValidator>
                     </div>
                 </div>
             </div>
         </div>
         <!-- ===================================================Contact Modal========================================================  -->

          <div class="navbar navbar-default navbar-fixed-bottom "> 
                 <div class="container">
                    <p class="navbar-text"> About Us </p>
                     <p class="navbar-text"> Copyrights </p>
                     <p class="navbar-text"> Site is Powered by BarteRoom team </p>
                  </div>
          </div>

     <script type="text/javascript">
            function userExists() {

                alert("This User Name Already Exists!");
          }
    </script>

        <script type="text/javascript">
            function loginUserNotExist() {

                alert("Incorrect User Name!");
            }
    </script>

          <script type="text/javascript">
              function loginFail() {

                  window.alert("Incorrect Password!");
              }
    </script>

    </form>
</body>
</html>
