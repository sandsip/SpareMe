<%@ Page Title="Seller | SparesMe " Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="SellerInfo.aspx.cs" Inherits="SellerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/Seller.css" rel="stylesheet" />
    <style type="text/css">
        .carousel-control i {
            position: absolute;
            top: 50%;
            left: 50%;
            z-index: 5;
            display: inline-block;
            width: 20px;
            height: 20px;
            margin-top: -10px;
            margin-left: -10px;
        }

        .mag {
            width: 200px;
            margin: 0 auto;
            float: none;
        }

            .mag img {
                max-width: 100%;
            }



        .magnify {
            position: relative;
            cursor: none
        }

        .magnify-large {
            position: absolute;
            display: none;
            width: 175px;
            height: 175px;
            -webkit-box-shadow: 0 0 0 7px rgba(255, 255, 255, 0.85), 0 0 7px 7px rgba(0, 0, 0, 0.25), inset 0 0 40px 2px rgba(0, 0, 0, 0.25);
            -moz-box-shadow: 0 0 0 7px rgba(255, 255, 255, 0.85), 0 0 7px 7px rgba(0, 0, 0, 0.25), inset 0 0 40px 2px rgba(0, 0, 0, 0.25);
            box-shadow: 0 0 0 7px rgba(255, 255, 255, 0.85), 0 0 7px 7px rgba(0, 0, 0, 0.25), inset 0 0 40px 2px rgba(0, 0, 0, 0.25);
            -webkit-border-radius: 100%;
            -moz-border-radius: 100%;
            border-radius: 100%
        }
    </style>
    <script>
        !function ($) {

            "use strict"; // jshint ;_;


            /* MAGNIFY PUBLIC CLASS DEFINITION
             * =============================== */

            var Magnify = function (element, options) {
                this.init('magnify', element, options)
            }

            Magnify.prototype = {

                constructor: Magnify

                , init: function (type, element, options) {
                    var event = 'mousemove'
                        , eventOut = 'mouseleave';

                    this.type = type
                    this.$element = $(element)
                    this.options = this.getOptions(options)
                    this.nativeWidth = 0
                    this.nativeHeight = 0

                    this.$element.wrap('<div class="magnify" \>');
                    this.$element.parent('.magnify').append('<div class="magnify-large" \>');
                    this.$element.siblings(".magnify-large").css("background", "url('" + this.$element.attr("src") + "') no-repeat");

                    this.$element.parent('.magnify').on(event + '.' + this.type, $.proxy(this.check, this));
                    this.$element.parent('.magnify').on(eventOut + '.' + this.type, $.proxy(this.check, this));
                }

                , getOptions: function (options) {
                    options = $.extend({}, $.fn[this.type].defaults, options, this.$element.data())

                    if (options.delay && typeof options.delay == 'number') {
                        options.delay = {
                            show: options.delay
                            , hide: options.delay
                        }
                    }

                    return options
                }

                , check: function (e) {
                    var container = $(e.currentTarget);
                    var self = container.children('img');
                    var mag = container.children(".magnify-large");

                    // Get the native dimensions of the image
                    if (!this.nativeWidth && !this.nativeHeight) {
                        var image = new Image();
                        image.src = self.attr("src");

                        this.nativeWidth = image.width;
                        this.nativeHeight = image.height;

                    } else {

                        var magnifyOffset = container.offset();
                        var mx = e.pageX - magnifyOffset.left;
                        var my = e.pageY - magnifyOffset.top;

                        if (mx < container.width() && my < container.height() && mx > 0 && my > 0) {
                            mag.fadeIn(100);
                        } else {
                            mag.fadeOut(100);
                        }

                        if (mag.is(":visible")) {
                            var rx = Math.round(mx / container.width() * this.nativeWidth - mag.width() / 2) * -1;
                            var ry = Math.round(my / container.height() * this.nativeHeight - mag.height() / 2) * -1;
                            var bgp = rx + "px " + ry + "px";

                            var px = mx - mag.width() / 2;
                            var py = my - mag.height() / 2;

                            mag.css({ left: px, top: py, backgroundPosition: bgp });
                        }
                    }

                }
            }


            /* MAGNIFY PLUGIN DEFINITION
             * ========================= */

            $.fn.magnify = function (option) {
                return this.each(function () {
                    var $this = $(this)
                        , data = $this.data('magnify')
                        , options = typeof option == 'object' && option
                    if (!data) $this.data('tooltip', (data = new Magnify(this, options)))
                    if (typeof option == 'string') data[option]()
                })
            }

            $.fn.magnify.Constructor = Magnify

            $.fn.magnify.defaults = {
                delay: 0
            }


            /* MAGNIFY DATA-API
             * ================ */

            $(window).on('load', function () {
                $('[data-toggle="magnify"]').each(function () {
                    var $mag = $(this);
                    $mag.magnify()
                })
            })

        }(window.jQuery);</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product" style="padding-top: 0px">
        <div class="WellPageHeader">
            <div class="container">
                <a href="Index.aspx" target="_blank">Home</a> >>                           
                <asp:Literal ID="SellerDisplayName" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="row idx_crd">
                            <div class="col-md-2 col-sm-2 col-xs-12" style="padding: 0;">
                                <center>  
                                <div class=""> <%--image-box--%>
                                    <asp:Image ID="Image2" Width="150px" runat="server" CssClass="img-responsive" ImageUrl="https://ir.ebaystatic.com/pictures/aw/social/avatar.png" />
                                </div>
                                </center>
                            </div>
                            <div class="col-md-10 col-sm-10 col-xs-12">
                                <div class="row">
                                    <div class="col-md-7 col-sm-7 col-xs-12">
                                        <div style="padding-top: 0px;">
                                            <a class="mbg-id" href=""><span class="g-hdn">User ID&nbsp;</span> <span class="heighlight">
                                                <asp:Literal ID="ltrlSellerDisplayName" runat="server"></asp:Literal></span> </a>(<a href="#" title="lingoimpex's feedback score is 5516"><span class="g-hdn">Feedback score&nbsp;</span>5516</a><i class="gspr greenStar star" role="img" aria-label="lingoimpex's feedback score is 5516"></i>)</span><span class="mbg-l" role="presentation"></span>
                                        </div>
                                        99.8% positive feedback                  
                                    </div>

                                    <div class="col-md-5 col-sm-5 col-xs-12">
                                        <div>
                                            <ul class="list-inline" style="float: right;">
                                                <li class="list-inline-item"><i class="fa fa-tags" aria-hidden="true"></i>&nbsp;<a id="linkseller" runat="server" class="heighlight" style="font-size: 13px;">Items for sale</a>
                                                </li>
                                                <li class="list-inline-item"><i class="fas fa-store" aria-hidden="true"></i>&nbsp;<a class="heighlight" style="font-size: 13px;">Visit store</a>
                                                </li>
                                                <li class="list-inline-item"><i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;<a class="heighlight" style="font-size: 13px;">Contact</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12" style="float: right;">
                                        <asp:Literal ID="ltrlSellerinfo" runat="server"></asp:Literal>
                                        <br />
                                        <asp:Literal ID="ltrlSellerAddress" runat="server"></asp:Literal>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>


                </div>
                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12">

                        <div class="row" id="PartNumber" runat="server">
                            <div class="col-md-5 col-sm-5 col-xs-12">
                                <div style="-webkit-box-shadow: 0 0 5px rgba(0,0,0,0.3); box-shadow: 0 0 5px rgba(0,0,0,0.3);">
                                    <div>
                                        <%--<asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl="https://images-eu.ssl-images-amazon.com/images/I/51amt0HH8pL._AC_US218_.jpg" />--%>
                                        <div class="bg-primary r" style="text-align: center; background-color: transparent">
                                            <div class="carousel slide carousel-fade" data-ride="carousel" id="c-fade">
                                                <div class="carousel-inner">
                                                    <asp:Repeater ID="RPTProductImgSlide" runat="server">
                                                        <ItemTemplate>
                                                            <div class="item <%# GetDivClass() %> ">
                                                                <a target="_blank" href="<%# Eval("PicturePath") %><%# Eval("PictureName") %>">
                                                                    <img src="<%# Eval("PicturePath") %><%# Eval("PictureName") %>" class="img-responsive" data-toggle="magnify" alt="<%# Eval("AltAttribute") %>" title="<%# Eval("TitleAttribute") %>" width="100%" draggable="true" data-bukket-ext-bukket-draggable="true">
                                                                </a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <a class="left carousel-control" href="#c-fade" data-slide="prev">
                                                    <i class="fa fa-angle-left" style="color: #050304;"></i>
                                                </a>
                                                <a class="right carousel-control" href="#c-fade" data-slide="next">
                                                    <i class="fa fa-angle-right" style="color: #050304;"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--end of product image-->
                            </div>
                            <!--end of col-md-3-->

                            <div class="col-md-7 col-sm-7 col-xs-12">
                                <div class="main-box" style="-webkit-box-shadow: 0 0 5px rgba(0,0,0,0.3); box-shadow: 0 0 3px 0px rgba(37, 36, 37, 0.64);">
                                    <div class="row">
                                        <div class="col-md-8 col-sm-8 col-xs-12" style="margin: 0px;">
                                            <asp:Literal ID="ltrlTitle" runat="server" />
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
                                        <asp:Literal ID="ltrlSDesc" runat="server" />
                                        <br />
                                        <asp:Literal ID="ltrlLDesc" runat="server" />
                                    </div>
                                    <!--end of col-md-6-->
                                </div>
                                <!--end of row-->


                            </div>
                            <!--end of col-md-9-->
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="main-box" style="-webkit-box-shadow: 0 0 5px rgba(0,0,0,0.3); box-shadow: 0 0 3px 0px rgba(37, 36, 37, 0.64);">
                                    <div class="row">
                                        <div class="col-md-4 col-sm-4 col-xs-12" style="margin: 0px;">
                                        </div>

                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <asp:Literal ID="Literal2" runat="server" />
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-12">
                        Ads
                    </div>
                    <!--end of col-md-4main-->


                </div>
            </div>
            <!--end of row-->
        </div>
        <!--end of container-->
        <!--end of container fluid-->
    </section>
</asp:Content>


