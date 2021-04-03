<%@ Page Title="" Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="WebPage.aspx.cs" Inherits="WebPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="canonical" href="<%=CompleteURL %>" />
    <meta property="og:locale" content="en_US" />
    <meta property="og:type" content="website" />
    <meta property="og:url" content="<%=ItemCustomerURl %>" />
    <meta property="fb:app_id" content="140317460017846" />
    <meta property="og:site_name" content="BidURDream" />
    <meta property="article:publisher" content="https://www.facebook.com/SparesME/" />
    <meta property="og:title" content=" <%= FBKeywords  %>  " />
    <meta property="og:description" content="<%= FBDescription  %> " />
    <meta property="article:published_time" content="<%=DateTime.Now %>" />
    <meta property="article:modified_time" content="<%=DateTime.Now %>" />
    <meta property="og:updated_time" content="<%=DateTime.Now %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product" style="padding-top: 0px">
        <div class="WellPageHeader">
            <div class=" container">
                <a href="Index.aspx" target="_blank">Home</a> >>
                            <%= WebPageTitle  %>
            </div>
        </div>
        <div class="">
            <div class="container">

                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12 text-justify">
                        <div class="contentpage" id="WebPage1" runat="server">
                            <%= WebPageDesc %>
                        </div>
                    </div>
                    <!--end of col-md-9main-->
                    <!--================================-->
                    <div class="col-md-3 col-sm-3 col-xs-12">
                        Ads
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
            //alert(sam);
            //RedirectURL(sam);
        }
    </script>
</asp:Content>

