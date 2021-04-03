<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en-US">
<head runat="server">
    <%-- on only in live <script lang="JavaScript">
        function redirectHttpToHttps() {
            if (window.location.protocol == "http:") {
                var httpURL = window.location.hostname + window.location.pathname + window.location.search;
                if (window.location.host == "demo.sparesme.in") {
                    var httpsURL = "https://" + httpURL;
                }
                else {
                    var httpsURL = "https://" + httpURL;
                }
                window.location = httpsURL;
            }
        }
        redirectHttpToHttps();
    </script>--%>
    <meta name="theme-color" content="#ec1d27" />
    <link rel="icon" href="images/favicon.png" type="image/x-icon" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>SparesMe Search for spare parts, brands and more</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/media.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!--fonts-->
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" />
    <!--AutoComplete CSS Begin -->
    <link href="css/autocomlete.css" rel="stylesheet" />
    <!--AutoComplete CSS END-->
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <style type="text/css">
        .ui-dialog {
            overflow: hidden;
        }

        .ui-menu {
            overflow: auto;
            min-height: 30px;
            max-height: 200px;
        }

        .ui-widget-content {
            border: 1px solid #ccc;
            background: #fcfdfd url(images/ui-bg_inset-hard_100_fcfdfd_1x100.png) 50% bottom repeat-x;
            color: #222222;
        }

            .ui-state-hover, .ui-widget-content .ui-state-hover, .ui-widget-header .ui-state-hover, .ui-state-focus, .ui-widget-content .ui-state-focus, .ui-widget-header .ui-state-focus {
                border: 1px solid #ccc;
                background-color: #f8f8f8;
                color: black;
            }

        a {
            color: #171714;
            text-decoration: none;
        }

            a:hover,
            a:focus {
                color: #423f3f;
                text-decoration: underline;
            }

            a:focus {
                outline: 5px auto -webkit-focus-ring-color;
                outline-offset: -2px;
            }
    </style>
    <script type="text/javascript">
        $.noConflict();
        jQuery(document).ready(function ($) {
            $("#txtautocomplete").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $('#txtautocomplete').val() };
                    $.ajax({
                        url: "Service.asmx/GetEmpNames",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message + " : " + textStatus);
                            // console.log("Ajax Error!");  
                        }
                    });
                },
                search: function (e, u) {
                    $(this).addClass('loader');
                },
                response: function (e, u) {
                    $(this).removeClass('loader');
                },
                select: function (event, ui) {
                    if (ui.item) {
                        RedirectURL(ui.item.value);
                    }
                },
                minLength: 3 //This is the Char length of inputTextBox  
            });
        });

        function RedirectURL(SparesME) {
            //$("#outputcontent").remove();
            //var rows = country;
            //$('#outputcontent').append(SparesME);
            if (SparesME == "") {
                $('#<%= txtautocomplete.ClientID %>').focus();
                //alert("emty");
            }
            else {
                window.location.replace("ProductSearch.aspx?Search=" + encodeURIComponent(SparesME.replace(/ /g, ' '))
                //window.location.replace("ProductSearch.aspx?Search=" + encodeURIComponent(SparesME));
                );
            }
        }

        function OnBtnSearchedClick(txtsearched) {
            var sam = $.trim($("[id*=" + txtsearched + "]").val());
            RedirectURL(sam);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <nav class="navbar navbar-default" role="navigation" style="background-color: transparent; border-color: transparent;">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <!--<a class="navbar-brand" href="#">Brand</a>-->
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <SparesME:Login_SignIn_Process ID="UserControlLS1" runat="server" />
            </div>
            <!-- /.navbar-collapse -->
        </nav>

        <!--==========================================================-->
        <div class="img-responsive" style="background-image: url(images/homepage_header_background.svg); background-position: 50% 100%; background-repeat: no-repeat;  height: 100%; ">
            <section class="search-section">

                <div class="container">
                    <div class="row">
                        <div class="center-box">
                            <div class="col-md-6 col-md-offset-3">
                                <div id="logo" class="text-center logo-2">
                                    <img src="images/logo.png" class="img-responsive">
                                    <%--<img src="images/SparesMeLogo.png" class="img-responsive" width="140">--%>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtautocomplete" MaxLength="199" runat="server" class="form-control" placeholder="Search for spare parts, brands and more" />
                                    <span class="input-group-btn">
                                        <button type="button" class="btn btn-default" onclick="OnBtnSearchedClick('<%= txtautocomplete.ClientID%>')"><i class="fa fa-search"></i></button>
                                        <button type="button" class="btn btn-default" title="process"><i class="fa fa-question"></i></button>
                                    </span>
                                </div>
                                <div id="outputbox">
                                    <p id="outputcontent"></p>
                                </div>
                            </div>
                            <!--end of center box-->
                        </div>
                        <!--end of col-md-6-->
                    </div>
                    <!--end of row-->
                </div>
                <!--end of container-->

            </section>

            <section class="accesories">
                <div class="container-fluid">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                <h5 class="heading-1">Spare Parts And Accessories For:</h5>
                                <ul class="sub-link">
                                    <li><a href="#">Industrial</a></li>
                                    <li>/</li>
                                    <li><a href="#">Agriculture</a></li>
                                    <li>/</li>
                                    <li><a href="#">Home Appliances</a></li>
                                    <li>/</li>
                                    <li><a href="#">Automobiles</a></li>
                                    <li>/</li>
                                    <li><a href="#">Marine</a></li>
                                    <li>/</li>
                                    <li><a href="#">Aviation</a></li>
                                </ul>
                            </div>
                            <!--end of col-md-12-->
                        </div>
                        <!--end of row-->
                    </div>
                    <!--end of container-->
                </div>
                <!--end of container fluid-->

            </section>
        </div>
        <!--==========================================================-->

        <section class="main-footer">
            <div class="container-fluid">
                <div class="container">
                    <SparesME:Footer_Process ID="Footer" runat="server" />
                    <!--end of row-->
                </div>
                <!--end of container-->
            </div>
            <!--end of container fluid-->

        </section>


        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="js/bootstrap.min.js"></script>

        <!--AutoComplete CSS Begin -->
        <%--<script type="text/javascript" src="js/jquery.autocomplete.min.js"></script>--%>
        <%--<script type="text/javascript" src="js/currency-autocomplete.js"></script>--%>
        <!--AutoComplete CSS END -->


    </form>
</body>
</html>
