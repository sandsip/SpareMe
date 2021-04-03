<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControl_Login_SignUp.ascx.cs" Inherits="WebUserControl_UserControl_Login_SignUp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .modalBackground {
        filter: alpha(opacity=90);
        opacity: 0.8;
        background: rgba(0, 0, 0, .7);
        -webkit-font-smoothing: antialiased;
    }

    a:hover, a:focus {
        color: #423f3f;
        text-decoration: underline;
    }

    .btn-primary:hover {
        color: #fff;
        background-color: #464646;
        border-color: #46464673;
    }

    #login-dp {
        min-width: 250px;
        padding: 14px 14px 0;
        overflow: hidden;
        background-color: rgba(255,255,255,.8);
    }

        #login-dp .bottom {
            background-color: rgb(70, 70, 70);
            border-top: 1px solid #ddd;
            clear: both;
            padding: 14px;
            color: white;
        }

            #login-dp .bottom > a {
                color: #ffffff;
                text-decoration: none;
                cursor: pointer;
            }

                #login-dp .bottom > a:hover {
                    color: #ff3641;
                    text-decoration: none;
                    cursor: pointer;
                }

    .text-center {
        text-align: center;
    }

    .btn-primary {
        color: #fff;
        background-color: #ff3641;
        border-color: #ff3641;
    }

        .btn-primary.active.focus, .btn-primary.active:focus, .btn-primary.active:hover, .btn-primary:active.focus, .btn-primary:active:focus, .btn-primary:active:hover, .open > .dropdown-toggle.btn-primary.focus, .open > .dropdown-toggle.btn-primary:focus, .open > .dropdown-toggle.btn-primary:hover {
            color: #fff;
            background-color: #464646;
            border-color: #e2e2e2;
        }
</style>

<!--IndexPage Begin-->
<ul class="nav navbar-nav navbar-right">
    <li><a href="WebPage.aspx?Page=About-Me">Contact <span class="heighlight">Me</span> : 1800-121-00 <span class="heighlight">Me</span>(63)</a></li>
    <li><a id="logcontrol" runat="server" class="Button_shadow">sign <span class="heighlight">Me</span> In</a></li>
    <li id="MyAccountControl" runat="server" class="dropdown">
        <a href="#" class="dropdown-toggle Button_shadow" data-toggle="dropdown">My <span class="heighlight">Account</span> <b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a href="MyAccount.aspx">My Profile</a></li>
            <li><a href="MyAccount.aspx">Order Details</a></li>
            <li><a href="ChangePassword.aspx">Change Password</a></li>
            <li class="divider"></li>
            <li>
                <asp:LinkButton ID="BtnLIO" runat="server" OnClick="BtnLIO_Click" Text="logout" /></li>
        </ul>
    </li>
</ul>
<!--IndexPage END-->


<%--Something's not right. Please try again.--%>
<%--Please enter valid Email ID/Mobile number--%>

<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="logcontrol"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none" DefaultButton="btnLogin">
    <asp:Button ID="btnClose" runat="server" Text="X" CssClass="button" Style="display: block; width: 30px; height: 30px; background: url(../images/btn-close.png) no-repeat center center; text-indent: -10000px; position: absolute; top: -15px; right: -15px; cursor: pointer; border: 0px;" />
    <div id="login-dp">
        <div class="row">
            <div class="col-md-12">
                <img src="../images/SparesMeLogo.png" width="120" class="img-responsive" />
                Login <%--via
                                        <div class="social-buttons text-center">
                                            Facebook
                                        </div>--%>
                <hr style="margin-top: 0px; border: 1px solid #464646;" />
                <div class="form" id="login-nav">
                    <div class="form-group">
                        <label class="sr-only" for="exampleInputEmail2">
                            <asp:RequiredFieldValidator ValidationGroup="LoginProcess" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="* Please enter valid Email ID/Mobile number" SetFocusOnError="true" ForeColor="Red" CssClass="style7">* Please enter valid Email ID/Mobile number</asp:RequiredFieldValidator></label>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control" placeholder="Enter Email/Mobile number" />
                    </div>
                    <div class="form-group">
                        <label class="sr-only" for="exampleInputPassword2">
                            <asp:RequiredFieldValidator ValidationGroup="LoginProcess" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="* Please enter valid Password" SetFocusOnError="true" ForeColor="Red" CssClass="style7">* Please enter valid Password</asp:RequiredFieldValidator></label>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" CssClass="form-control" placeholder="Password" TextMode="Password" />

                        <div class="help-block text-right">
                            <a id="logcontrolfrgtPnl" style="color: #464646;"
                                onclick="return ShowModalPopupUnlock()" runat="server">Forget the password ?</a>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnLogin" ValidationGroup="LoginProcess" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox">
                            keep me logged-in
                        </label>
                    </div>
                </div>
            </div>
            <div class="bottom text-center">
                New here ? <a href="AccountCreate.aspx"><b>Join Us</b></a>
            </div>
        </div>
    </div>
</asp:Panel>

<!--Forget Password Begins--->
<cc1:ModalPopupExtender ID="frgtPnl" runat="server" PopupControlID="Panel2" TargetControlID="logcontrolfrgtPnl"
    CancelControlID="btnClosefrgtPnl" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" Style="display: none" DefaultButton="btnForgetPassword">
    <asp:Button ID="btnClosefrgtPnl" runat="server" Text="X" CssClass="button" Style="display: block; width: 30px; height: 30px; background: url(../images/btn-close.png) no-repeat center center; text-indent: -10000px; position: absolute; top: -10px; right: -4px; cursor: pointer; border: 0px;" />
    <div id="login-dpfrgtPnl" style="padding: 14px 14px; overflow: hidden; background-color: rgba(255,255,255,.8);">
        <div class="">
            <fieldset class="flfrm reg lgn frgt">
                <h1 class="frgtHdng">FORGOT PASSWORD</h1>
                <p class="frgtPwd">Please enter your Email/Mobile number below. You will receive a new reset your password shortly.</p>
                <div class="fldWrp">
                    <asp:TextBox ID="txtforgetpassword" runat="server" MaxLength="50" CssClass="form-control" placeholder="Email/Mobile number" />
                </div>
                <br />
                <div class="fldWrp">
                    <asp:Button ID="btnForgetPassword" runat="server" CssClass="btn btn-primary btn-2" Text="Submit" OnClick="btnForgetPassword_Click"></asp:Button>
                </div>
            </fieldset>
        </div>
    </div>

</asp:Panel>

<!-- Forget Password End---->


