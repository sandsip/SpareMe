<%@ Page Title="" Language="C#" MasterPageFile="~/VDFrontMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="main-product" style="padding-top: 0px">
        <div class="WellPageHeader">
            <div class="container">
                <a href="Index.aspx" target="_blank">Home</a> >>
                           Change Password                
            </div>
        </div>
        <div class="">
            <div class="container">
                <div class="row">
                    <div class="col-md-9 col-sm-9 col-xs-12 text-justify">
                        
                        <div>
                            <div id="form-validate">
                                <asp:Panel ID="panelpramod" runat="server" DefaultButton="btnChangePassword">
                                    <div class="fieldset" style="display: block;">
                                        <div class="page-title" style="color: #e84c3e;">
                                            <h2 class="legend">Change Password</h2>
                                        </div>
                                        <br />

                                        <div class="form-group">
                                            <div class="input-group input-group">
                                                <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                                <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" MaxLength="50" CssClass="form-control" placeholder="New Password" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="input-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="txtConfirmNewPassword" TextMode="Password" runat="server" MaxLength="50" CssClass="form-control" placeholder="Confirm New Password" />
                                        </div>
                                    </div>
                                    <div class="buttons-set">                                        
                                            <asp:Button ID="btnChangePassword" runat="server" TextMode="Password" CssClass="btn btn-danger" Text="Save" OnClick="btnChangePassword_Click" OnClientClick="return Reg_ValidPasswordChange()"></asp:Button>
                                    </div>
                                </asp:Panel>
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

