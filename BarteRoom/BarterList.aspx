<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BarterList.aspx.cs" Inherits="BarteRoom.BarterList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

</asp:Content>
