<%@ Page Title="" Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="ProductSearch.aspx.cs" Inherits="ProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product">
        <div class="">
            <div class="container">
                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12">
                        <div class="heading-box">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <%--Your Search For Automobile Spare Parts / 1243656 Search Results--%>
                                Your Search For
                                <asp:Literal ID="ltrlSparesMESearchResult" runat="server" />
                                    Search Results
                                </div>
                                <!--end of col-md-12-->
                            </div>
                        </div>
                        <!--end of row-->
                        <br>

                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                Filtering
                            </div>
                            <!--end of col-md-2-->
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <select class="form-control">
                                    <option>-Category-</option>
                                    <option>Automobiles </option>
                                </select>
                            </div>
                            <!--end of col-md-2-->
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <select class="form-control">
                                    <option>-ORIGIN-</option>
                                    <option>Aftermarket</option>
                                    <option>OEM</option>
                                </select>
                            </div>
                            <!--end of col-md-2-->
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <select class="form-control">
                                    <option>Choose</option>
                                    <option>BMW</option>
                                    <option>Audi</option>
                                    <option>Ashok Leyland</option>
                                    <option>Tata</option>
                                    <option>Honda</option>

                                </select>
                            </div>
                            <!--end of col-md-2-->
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <select class="form-control">
                                    <option>-Fitting place--</option>
                                    <option>Left</option>
                                    <option>Right</option>
                                    <option>Top</option>
                                    <option>Front</option>
                                    <option>Bonnet</option>
                                    <option>Glass</option>
                                </select>
                            </div>
                            <!--end of col-md-2-->
                        </div>
                        <!--end of row-->
                        <!--====================================================-->
                        <br>
                        <asp:Repeater ID="RPTSearchResult" runat="server">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnSSIKey" runat="server" Value='<%# Eval("SSI_PartNumber") %>' />
                                <div class="heading-box">
                                    <div class="row">
                                        <div class="col-md-7 col-sm-7 col-xs-12">
                                            <div class="SearchKeyHeader">
                                                <%# Eval("SDesc") %>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-12">
                                            <div class="SearchKeyHeader">Part No : <%# Eval("SSI_PartNumber") %></div>
                                        </div>
                                        <div class="col-md-2 col-sm-2 col-xs-12">
                                            <a href="ProductPage.aspx?PartNumber=<%# Eval("SSI_PartNumber") %>" class="btn btn-primary btn-block">Meet Sellers</a>
                                        </div>
                                    </div>
                                </div>
                                <br>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0px 26px; max-height: auto; min-height: 50px; display: block; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">
                                        <%# Eval("LDesc") %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%--<div class="row heading-box">
                            <div class="col-md-6 col-sm-6 col-xs-12">Parts Short Description:</div>
                            <div class="col-md-4 col-sm-4 col-xs-12">Part No:</div>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <button type="button" class="btn btn-3">Buy</button>
                            </div>
                        </div>
                        <br>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                Long Description:
                            </div>
                        </div>--%>
                    </div>
                    <!--end of col-md-9main-->
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
    <script type="text/javascript">
        function OnBtnSearchedClick(txtsearched) {
            var sam = $.trim($("[id*=" + txtsearched + "]").val());
            // alert(sam);

            //RedirectURL(sam);
        }
    </script>
</asp:Content>

