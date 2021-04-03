<%@ Page Title="" Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product" style="padding-top: 0px">
        <div class="WellPageHeader">
            <div class=" container">
                <a href="Index.aspx" target="_blank">Home</a> >>
                           My Account
            </div>
        </div>
        <div class="">
            <div class="container">

                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12 text-justify">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="page-title" style="color: #e84c3e;">
                                    <h3 class="legend">Profile Pic</h3>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="upload-box">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="image-box">
                                                <asp:Image ID="Image2" Width="150px" runat="server" CssClass="img-circle" /><br>
                                            </div>
                                            <div class="upload-form">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                                <asp:RegularExpressionValidator
                                                    ID="regexValidateImageFil" runat="server" ControlToValidate="FileUpload1"
                                                    ErrorMessage="file type not allow."
                                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                                <br>
                                                <asp:Button ID="btnProfileUploadImage" runat="server" CssClass="btn btn-primary btn-block" Text="Upload Image" OnClick="btnProfileUploadImage_Click"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="page-title" style="color: #e84c3e;">
                                    <h3 class="legend">Account Information</h3>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <div id="form-validate">
                                    <div class="fieldset">

                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="fieldset" style="display: block;">
                                                    <div class="customer-name">
                                                        <div class="field name-firstname">
                                                            <label for="firstname" class="required"><em>*</em>Full Name</label>
                                                            <div class="input-box">
                                                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" CssClass="form-control required-entry" placeholder="Full Name" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="customer-name">
                                                        <div class="field name-firstname">
                                                            <label for="firstname" class="required"><em>*</em>Email Address</label>
                                                            <div class="input-box">
                                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control required-entry" placeholder="Email Address" />
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="field name-lastname">
                                                            <label for="lastname" class="required"><em>*</em> Contact Number</label>
                                                            <div class="input-box">
                                                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="12" CssClass="form-control required-entry" placeholder="Contact Number" />
                                                            </div>
                                                        </div>
                                                        <br />
                                                    </div>
                                                </div>
                                                <label for="firstname" class="required"><em>*</em>Street Address</label>
                                                <div class="input-box">
                                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="500" CssClass="form-control required-entry" placeholder="Street Address" TextMode="MultiLine" Height="60px" />
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="input-box">
                                                    <div class="customer-name">
                                                        <div class="field name-lastname">
                                                            <label for="lastname" class="required"><em>*</em>Country</label>
                                                            <div class="input-box">
                                                                <asp:DropDownList ID="ddlCustomerCountry" runat="server" CssClass="form-control required-entry" placeholder="Country">
                                                                    <asp:ListItem Value="India">India</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="field name-firstname">
                                                            <label for="firstname" class="required"><em>*</em>State</label>
                                                            <div class="input-box">
                                                                <asp:DropDownList ID="ddlCustomerState" Enabled="false" runat="server" CssClass="form-control required-entry" placeholder="Municipalities" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomerState_SelectedIndexChanged" />

                                                            </div>
                                                        </div>
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="customer-name">
                                                    <div class="field name-firstname">
                                                        <label for="firstname" class="required"><em>*</em>City</label>
                                                        <div class="input-box">
                                                            <asp:DropDownList ID="ddlCustomerCity" Enabled="false" runat="server" CssClass="form-control required-entry" AutoPostBack="true" placeholder="City" OnSelectedIndexChanged="ddlCustomerCity_SelectedIndexChanged" />
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="field name-lastname">
                                                        <label for="lastname" class="required"><em>*</em>Pin Code</label>
                                                        <div class="input-box">
                                                            <asp:TextBox ID="txtPincode" onkeypress="return isNumberKey(event)" runat="server" MaxLength="6" CssClass="form-control required-entry" />
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="input-box">
                                        </div>
                                    </div>
                                    <div class="buttons-set">
                                        <p class="required">* Required Fields</p>

                                        <asp:Button ID="btnAccountEdit" runat="server" CssClass="btn btn-3 left" Text="save" OnClick="btnAccountEdit_Click" OnClientClick="return Reg_ValidEditControl()"></asp:Button>

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
</asp:Content>

