<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="BarteRoom.Manager" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
                    <li> <a href="/Home.aspx"> Home <span class="sr-only">(current)</span></a></li>
                      <li class="active"><a href="/manager.aspx">Manager</a></li>
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
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT usr, password, fullName, email FROM users WHERE (manager = 0)"></asp:SqlDataSource>
    
    </div>
                <table class="nav-justified">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
    </form>
</body>
</html>
