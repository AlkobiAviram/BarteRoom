    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BarteRoom.Home1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <style type="text/css">
            .auto-style2 {
                width: 15%;
            }
            .auto-style3 {
                width: 80px;

            }
              .auto-style4 {
                width: 25px;
            }
                 .auto-style5 {
                width: 70px;
            }


        </style>

         <!-- ==============================================Main container===========================================  -->
               <div class="container" id="popupmenu">
                    <div class="row">
                     <div class="container">
                           <table class="nav-justified">
                                <tr>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style3">

                                        <asp:TextBox ID="SearchTextBox" class="form-control" placeholder="Search..." Width="100%" runat="server"></asp:TextBox>
       
                                    </td>

                                    <td class="auto-style4">
                                        <asp:DropDownList ID="catagories" class="form-control" Width="97%" runat="server" DataSourceID="SqlDataSource1" DataTextField="cls_name" DataValueField="cls_name">
                                            </asp:DropDownList>
                                    </td>

                                    <td class="auto-style4">
                                        <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="Search" OnClick="searcCmd_Click"/>
                                        <asp:LinkButton ID="AdvancedSearch" runat="server" ForeColor="Blue">Advanced</asp:LinkButton>
                                    </td>

                                </tr>
                             </table>
                            <br />
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectToDb %>" SelectCommand="SELECT cls_name FROM classes WHERE (cls_name &lt;&gt; 'Choose Class')"></asp:SqlDataSource>
                           <br />

                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style4"></td>
                                    <td class="auto-style5">
                                        <asp:Label ID="searchField" runat="server" Visible =" false" Text="Label" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="results" runat="server" Visible =" false" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>

                     <div class="row">
                          <div class="col-md-10">
                            <asp:GridView ID="homeGridView" CssClass="table table-responsive table-striped" HorizontalAlign="Center" AllowSorting="True"  AllowPaging="True" GridLines="None" AutoGenerateColumns="False" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="homeGridView_SelectedIndexChanged">
                                <Columns>
                        
                                    <asp:ImageField DataImageUrlField ="Image" NullDisplayText="no image" >
                                        <ControlStyle Height="250px" Width="250px" />
                                        <ItemStyle Height="20px" Width="20px" />
                                    </asp:ImageField>
                        
                                    <asp:TemplateField HeaderText="Name" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="change" CausesValidation="False" CommandName="Select" Text='<%# Bind("name") %>' ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
               
                                    <asp:BoundField DataField="comments" HeaderText="Comments" SortExpression="comments" />
                                    <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                                    <asp:BoundField DataField="Id" HeaderText="Item BarCode" ReadOnly="True" SortExpression="Id" />
                                </Columns>
                             </asp:GridView>
                         </div>
                     </div>
                 </div>
               </div>
            

        
           
            
             <div class="container">

         
                 <!-- ==============================================buttom row===========================================  -->
                 <link href="imageSlider.css" rel="stylesheet" type="text/css" />
       <!--
    We will make a slider with stylized thumbnails using CSS3
    The markup is very simple:
    Radio Inputs
    Labels with thumbnails to detect click event
    Main Image
    -->
    <div class="slider">
	    <input type="radio" name="slide_switch" id="id1"/>
	    <label for="id1">
		    <img src="http://thecodeplayer.com/uploads/media/3yiC6Yq.jpg" width="100"/>
	    </label>
	    <img src="http://thecodeplayer.com/uploads/media/3yiC6Yq.jpg"/>
	
	    <!--Lets show the second image by default on page load-->
	    <input type="radio" name="slide_switch" id="id2" checked="checked"/>
	    <label for="id2">
		    <img src="http://thecodeplayer.com/uploads/media/40Ly3VB.jpg" width="100"/>
	    </label>
	    <img src="http://thecodeplayer.com/uploads/media/40Ly3VB.jpg"/>
	
	    <input type="radio" name="slide_switch" id="id3"/>
	    <label for="id3">
		    <img src="http://thecodeplayer.com/uploads/media/00kih8g.jpg" width="100"/>
	    </label>
	    <img src="http://thecodeplayer.com/uploads/media/00kih8g.jpg"/>
	
	    <input type="radio" name="slide_switch" id="id4"/>
	    <label for="id4">
		    <img src="http://thecodeplayer.com/uploads/media/2rT2vdx.jpg" width="100"/>
	    </label>
	    <img src="http://thecodeplayer.com/uploads/media/2rT2vdx.jpg"/>
	
	    <input type="radio" name="slide_switch" id="id5"/>
	    <label for="id5">
		    <img src="http://thecodeplayer.com/uploads/media/8k3N3EL.jpg" width="100"/>
	    </label>
	    <img src="http://thecodeplayer.com/uploads/media/8k3N3EL.jpg"/>
    </div>

    <!-- We will use PrefixFree - a script that takes care of CSS3 vendor prefixes
    You can download it from http://leaverou.github.com/prefixfree/ -->
    <script src="http://thecodeplayer.com/uploads/js/prefixfree.js" type="text/javascript"></script>


               <!-- ==============================================buttom row===========================================  -->
             
             


            </div>
             <!-- ===================================================Main container=======================================================  -->

    </asp:Content>
