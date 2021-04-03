using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccountCreate : System.Web.UI.Page
{
    Gateway_Control objGControl = new Gateway_Control();

    public string CodeSenderOTP()
    {
        int value = (new Random()).Next(1000, 10000);
        return value.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BeforeOTP.Style.Add("display", "block");
            AfterOTP.Style.Add("display", "none");

            if (Session["User_Area_UID"] == null)
            {

            }
            else
            {
                Response.Redirect("/MyAccount.aspx", true);
            }
        }

        Button BTNSearchME = (Button)this.Master.FindControl("BTNSearchME");
        BTNSearchME.Click += new EventHandler(BTNSearchME_Click);
    }

    protected void showMessageBox(string message)
    {
        string sScript;
        message = message.Replace("'", "\'");
        sScript = String.Format("alert('{0}');", message);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
    }

    protected void BTNSearchME_Click(object sender, EventArgs e)
    {
        TextBox txtautocomplete = (TextBox)this.Master.FindControl("txtautocomplete");
        if (!string.IsNullOrEmpty(txtautocomplete.Text))
            Response.Redirect("ProductSearch.aspx?Search=" + txtautocomplete.Text.Replace(" ", "-"));
        //else
           // showMessageBox("Search for spare parts, brands and more");

        txtautocomplete.Focus();
    }

    protected void jsCall(string alert)
    {
        string script = @"alert('" + alert + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "jsCall", script, true);
    }

    private string ValidateEmail(string em)
    {
        string email = em;
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success)
            return "Valid";
        else
            return "Invalid";
    }

    EmailServices objem = new EmailServices();
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtMobile.Text.Trim().ToString()))
        {
            //Verify Begin
            objGControl.CustomerEA = txtEmail.Text.Trim();
            objGControl.CustomerMobile = txtMobile.Text.Trim();
            ArrayList arrcheck = objGControl.VerifyCustomer();
            if (arrcheck[0].ToString() == "Done")
            {
                string mobileOTPService = txtMobile.Text.Trim().ToString();
                Session["MobileOTPVerifiy"] = CodeSenderOTP();
                SMSControls.SMSSendFuction(mobileOTPService.ToString(), Session["MobileOTPVerifiy"].ToString() + " is your SparesMe verification code. Please do not share OTP with anyone to ensure account's security");

                if (!string.IsNullOrEmpty(txtEmail.Text) && ValidateEmail(txtEmail.Text) == "Valid")
                {
                    string Type = "OTP process";
                    string FullName = "Sparesme";

                    string To = txtEmail.Text.Trim();
                    string Subject = "OTP for verification process";
                    string Content = "<strong>" + Session["MobileOTPVerifiy"].ToString() + "</strong> is your SparesMe verification code. Please do not share OTP with anyone to ensure account's security";
                    string post = "OTP Process";

                    objem.EmailPoint_Customized(Type, FullName, To, Subject, Content, post);
                }

                BeforeOTP.Style.Add("display", "none");
                AfterOTP.Style.Add("display", "block");
                txtOTPVerification.Focus();
            }
            else
            {
                jsCall(arrcheck[0].ToString());
            }
            //Verify END

        }
        else
        {
            jsCall("ALL Fields Required");

        }
    }
    protected void btnOTPVerify_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Session["MobileOTPVerifiy"].Equals(txtOTPVerification.Text.ToString())) && !string.IsNullOrEmpty(Session["MobileOTPVerifiy"].ToString()))
            {
                //Insert Begin
                BeforeOTP.Style.Add("display", "none");
                AfterOTP.Style.Add("display", "none");
                PasswordSetup.Style.Add("display", "block");

                Session.Remove("MobileOTPVerifiy");




                //Insert END
            }
            else
            {
                jsCall("OTP not valid");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("AccountCreate.aspx?Msg=Session-is-closed", true);
        }

    }
    protected void btnPassword_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtFullName.Text.Trim()))
        {
            objGControl.CustomerEA = txtEmail.Text.Trim();
            objGControl.CustomerMobile = txtMobile.Text.Trim();
            objGControl.CustomerFN = txtFullName.Text.Trim();
            objGControl.Current_pwd = GenericFunctions.Encrypt(txtPassword.Text.Trim());

            ArrayList ARRCreateCustomer = objGControl.CreateCustomer();
            if (ARRCreateCustomer.Count.ToString() == "10")              //customer details
            {
                if (ARRCreateCustomer != null)
                {
                    Session["User_Area_UID"] = ARRCreateCustomer[0].ToString();
                    Session["CustomerFN"] = ARRCreateCustomer[1].ToString();
                    Session["CustomerMobile"] = ARRCreateCustomer[2].ToString();
                    Session["CustomerEA"] = ARRCreateCustomer[3].ToString();
                    Session["CustomerAddress"] = ARRCreateCustomer[4].ToString();
                    Session["CustomerCity"] = ARRCreateCustomer[5].ToString();
                    Session["CustomerPincode"] = ARRCreateCustomer[6].ToString();
                    Session["CustomerState"] = ARRCreateCustomer[7].ToString();
                    Session["CustomerCountry"] = ARRCreateCustomer[8].ToString();
                    Session["PincodeID"] = ARRCreateCustomer[9].ToString();

                    if ((!String.IsNullOrEmpty(Request.QueryString.Get("RedirectToAction")) && Request.QueryString.Get("RedirectToAction").Length > 2))
                    {
                        // string urlName = Request.UrlReferrer.ToString();
                        Response.Redirect("/" + Request.QueryString.Get("RedirectToAction"), true);
                    }
                    else
                    {
                        //SMSControls.SMSSendFuction(ARRCreateCustomer[2].ToString(), "Dear Customer, Welcome to SparesMe ");
                        Response.Redirect("/MyAccount.aspx", true);
                    }

                }

            }
            else
            {
                jsCall(ARRCreateCustomer[0].ToString());
            }
        }
        else
        {
            jsCall("ALL Fields Required");
        }
    }
}