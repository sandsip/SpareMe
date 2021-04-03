<%@ Page Title="" Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="AccountCreate.aspx.cs" Inherits="AccountCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product" style="padding-top: 0px">
        <div class="WellPageHeader">
            <div class=" container">
                <a href="Index.aspx" target="_blank">Home</a> >>
                            Account Create
            </div>
        </div>
        <div class="">
            <div class="container">
                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12 text-justify">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <h2>New Customers</h2>
                                <p>By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more.</p>
                                <br />
                                <div id="BeforeOTP" runat="server">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control" placeholder="Email Address" />
                                       
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers, LowercaseLetters, Custom"
                                            ValidChars=".@." TargetControlID="txtEmail" />
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" CssClass="form-control" placeholder="Contact Number" />
                                        <asp:RequiredFieldValidator ValidationGroup="AccountCreat" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile"
                                            SetFocusOnError="true" ForeColor="Red" CssClass="style7"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers"
                                            TargetControlID="txtMobile" />
                                    </div>

                                    <div class="buttons-set">
                                        <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" ValidationGroup="AccountCreat" runat="server" CssClass="btn btn-danger" Text="Submit"></asp:Button>
                                    </div>
                                </div>
                                <div id="AfterOTP" runat="server">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtOTPVerification" runat="server" MaxLength="10" CssClass="form-control" placeholder="OTP Verification Code" />
                                        <asp:RequiredFieldValidator ValidationGroup="OTPVerify" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOTPVerification"
                                            SetFocusOnError="true" ForeColor="Red" CssClass="style7"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                            TargetControlID="txtOTPVerification" />
                                    </div>
                                    <div class="buttons-set">
                                        <asp:Button ID="btnOTPVerify" OnClick="btnOTPVerify_Click" ValidationGroup="OTPVerify" runat="server" CssClass="btn btn-danger" Text="Submit"></asp:Button>
                                    </div>
                                </div>

                                <div id="PasswordSetup" runat="server" style="display:none">
                                     <div class="form-group">
                                        <asp:TextBox ID="txtFullName" runat="server" MaxLength="50" CssClass="form-control" placeholder="Your Full Name" />
                                        <asp:RequiredFieldValidator ValidationGroup="PasswordGroup" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                                            SetFocusOnError="true" ForeColor="Red" CssClass="style7"></asp:RequiredFieldValidator>                                        
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="10" CssClass="form-control" placeholder="Password" />
                                        <asp:RequiredFieldValidator ValidationGroup="PasswordGroup" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword"
                                            SetFocusOnError="true" ForeColor="Red" CssClass="style7"></asp:RequiredFieldValidator>
                                        
                                    </div>
                                    <div class="buttons-set">
                                        <asp:Button ID="btnPassword" OnClick="btnPassword_Click" ValidationGroup="PasswordGroup" runat="server" CssClass="btn btn-danger" Text="Submit"></asp:Button>
                                    </div>
                                </div>
                            </div>
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



