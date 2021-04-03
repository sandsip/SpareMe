<%@ Page Title="" Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="ProductPage.aspx.cs" Inherits="ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product">
        <div class="">
            <div class="container">
                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12">
                        <div class="main-box" style="-webkit-box-shadow: 0 0 5px rgba(0,0,0,0.3); box-shadow: 0 0 5px 0px rgb(124, 123, 124);">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-12 SearchResultHeader">
                                    <small style="color: black">Your Search For Part No / <strong>
                                        <asp:Label ID="ltrlSparesMESearchResult" runat="server" ForeColor="#000000" /></strong> Sellers Found</small>
                                </div>
                                <!--end of col-md-3-->

                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <div>
                                        <label for="">Delivery Area Pin Code :</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                                <!--end of col-md-3-->


                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <div>
                                        <label for="">Sort By : </label>
                                        <select class="form-control">
                                            <option>-Select-</option>
                                            <option>Sort By Price</option>
                                            <option>Sort By Sellers Rating</option>
                                            <option>Sort By Delivery Within</option>
                                            <option>Sort Near to you</option>
                                        </select>

                                    </div>
                                </div>
                                <!--end of col-md-3-->


                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <div>
                                        <label for="">Filter By :</label>
                                        <select class="form-control">
                                            <option>-ORIGIN-</option>
                                            <option>OEM</option>
                                            <option>Reseller</option>
                                            <option>Aftermarket</option>
                                            <option>All Origin</option>
                                        </select>
                                    </div>
                                </div>
                                <!--end of col-md-3-->

                            </div>
                            <!--end of row-->
                        </div>
                        <!--end of main box-->
                        <!--====================================-->
                        <br>
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <div style="-webkit-box-shadow: 0 0 5px rgba(0,0,0,0.3); box-shadow: 0 0 5px rgba(0,0,0,0.3);">
                                    <center> <asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl="https://images-eu.ssl-images-amazon.com/images/I/51amt0HH8pL._AC_US218_.jpg" /></center>
                                </div>
                                <!--end of product image-->
                            </div>
                            <!--end of col-md-3-->

                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <div class="main-box" style="-webkit-box-shadow: 0 0 5px rgba(0,0,0,0.3); box-shadow: 0 0 3px 0px rgba(37, 36, 37, 0.64);">
                                    <div class="row">
                                        <div class="col-md-8 col-sm-8 col-xs-12" style="margin: 0px;">
                                            <asp:Literal ID="ltrlSDesc" runat="server" />
                                        </div>
                                        <!--end of col-md-6-->
                                        <div class="col-md-4 col-sm-4 col-xs-12">
                                            Part No :
                                            <asp:Literal ID="ltrlSSI_PartNumber" runat="server" />
                                        </div>
                                        <!--end of col-md-6-->
                                    </div>
                                    <!--end of row-->
                                </div>
                                <!--end of main-box-->

                                <div class="row">
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-xs-12" style="text-align: justify">
                                        <asp:Literal ID="ltrlLDesc" runat="server" />
                                    </div>
                                    <!--end of col-md-6-->
                                </div>
                                <!--end of row-->


                            </div>
                            <!--end of col-md-9-->
                        </div>
                        <!--end of row-->
                        <!--==========================================================-->
                        <br>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead class="th">
                                            <tr>
                                                <th>Store Name</th>
                                                <th>Rating</th>
                                                <th>Delivery Within</th>
                                                <th>Price <i class="fa fa-inr"></i></th>
                                                <th>Freight <i class="fa fa-inr"></i></th>
                                                <th>Total Price <i class="fa fa-inr"></i></th>
                                                <th>Qty</th>
                                                <th>Purchase</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="RPTSellerDisplayList" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <asp:HiddenField ID="hdnPID" runat="server" Value='<%# Eval("PID") %>' />
                                                        <asp:HiddenField ID="hdnVID" runat="server" Value='<%# Eval("VID") %>' />
                                                        <td><a href='SellerInfo.aspx?Seller=<%# Eval("SellerName") %>&PartNumber=<%# Eval("SSI_PartNumber") %>&SSNID=<%# Eval("PID") %>' target="_blank"><%# Eval("SellerName") %></a></td>
                                                        <td><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star-half-o"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i></td>
                                                        <td><%# Eval("ETA") %></td>
                                                        <td><%# Eval("SellerPrice").ToString() == "0.0" ? Eval("SellerPrice").ToString() : "ON REQUIST"  %></td>

                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>
                                                            <button type="button" class="btn btn-danger btn-2"><%# Eval("SellerPrice").ToString() == "0.0" ? Eval("SellerPrice").ToString() : "ON REQUIST"  %></button>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                            <%--<tr>
                                                <td>Sameer Store</td>
                                                <td><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star-half-o"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <button type="button" class="btn btn-danger btn-2">Buy</button>
                                                </td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                                <!--end of table responsive-->

                            </div>
                            <!--end of col-md-12-->

                        </div>
                        <!--end of row-->




                    </div>
                    <!--end of col-md-8main-->
                    <!--================================-->







                    <div class="col-md-3 col-sm-3 col-xs-12">
                        <%--Ads--%>
                    </div>
                    <!--end of col-md-4main-->


                </div>
                <!--end of row-->
            </div>
            <!--end of container-->
        </div>
        <!--end of container fluid-->
    </section>

    
     
</asp:Content>

