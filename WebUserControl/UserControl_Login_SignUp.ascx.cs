using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl_UserControl_Login_SignUp : System.Web.UI.UserControl
{
    Gateway_Control ObjAccountLogin = new Gateway_Control();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_Area_UID"] == null)
            {
                if (Request.QueryString["Popup"] == "Login")
                {
                    mp1.Show();
                }
                logcontrol.HRef = "Default.aspx?Popup=Login";
                MyAccountControl.Visible = false;
                logcontrol.Style.Add("display", "block");
                MyAccountControl.Style.Add("display", "none");
            }
            else
            {
                logcontrol.Style.Add("display", "none");
                MyAccountControl.Style.Add("display", "block");
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string Password = txtPassword.Text;

        if (txtEmail.Text != "")
        {
            if (txtPassword.Text != "")
            {
                email = txtEmail.Text;
                Password = txtPassword.Text;
                logincred(email, Password);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('The Password field is required.')", true);
                mp1.Show();
                txtPassword.Focus();
                //mp1.OnShowing();
            }
        }
        else
        {
            txtEmail.Focus();
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Enter email/mobile number is required')", true);
            mp1.Show();
            //mp1.OnShowing();
        }
    }

    public void logincred(string Email, string Password)
    {
        if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
        {
            ObjAccountLogin.UserName = Email.Trim();
            ObjAccountLogin.UserPassword = Password.Trim();

            ArrayList arrcheck = ObjAccountLogin.Check_Customer_Credentials();
            try
            {
                if (arrcheck[0].ToString() == "not sucfull")
                {

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Please make sure that your Email/Mobile number and the Password is Correct.')", true);
                    Email = "";
                    Password = "";
                    mp1.Show();
                    txtEmail.Focus();
                }
                else if (arrcheck.Count.ToString() == "10")              //customer details
                {
                    if (arrcheck != null)
                    {
                        Session["User_Area_UID"] = arrcheck[0].ToString();
                        Session["CustomerFN"] = arrcheck[1].ToString();
                        Session["CustomerMobile"] = arrcheck[2].ToString();
                        Session["CustomerEA"] = arrcheck[3].ToString();
                        Session["CustomerAddress"] = arrcheck[4].ToString();
                        Session["CustomerCity"] = arrcheck[5].ToString();
                        Session["CustomerPincode"] = arrcheck[6].ToString();
                        Session["CustomerState"] = arrcheck[7].ToString();
                        Session["CustomerCountry"] = arrcheck[8].ToString();
                        Session["PincodeID"] = arrcheck[9].ToString();

                        if ((!String.IsNullOrEmpty(Request.QueryString.Get("RedirectToAction")) && Request.QueryString.Get("RedirectToAction").Length > 2))
                        {
                            // string urlName = Request.UrlReferrer.ToString();
                            Response.Redirect("/" + Request.QueryString.Get("RedirectToAction"), false);
                        }
                        else
                        {
                            //Response.AddHeader("Refresh", "0; url=MyAccount.aspx");
                            Response.Redirect("/MyAccount.aspx", true);

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Email-ID/Mobile Number and password do not match or you do not have an account yet.')", true);
                mp1.Show();
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Email-ID/Mobile Number and password do not match or you do not have an account yet.')", true);
            mp1.Show();
        }
    }

    protected void BtnLIO_Click(object sender, EventArgs e)
    {
        Session.Remove("firstVisit");
        Session.Remove("User_Area_UID");
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("/Index.aspx?Popup=Login", true);

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

    protected void btnForgetPassword_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtforgetpassword.Text.Trim()))
        {
            ObjAccountLogin.UserName = txtforgetpassword.Text.Trim();
            ObjAccountLogin.UserPassword = passsandesh.Generate(5, 8);
            ArrayList arrcheck = ObjAccountLogin.Check_Customer_Email();

            if (arrcheck != null)
            {
                if (arrcheck[0].ToString() != "0")
                {
                    string FullName = arrcheck[0].ToString();
                    string EmailAddress = arrcheck[1].ToString();
                    string Pass = arrcheck[2].ToString().Trim();
                    string password = GenericFunctions.Decrypt(Pass).Trim();
                    string CMobile = arrcheck[3].ToString().Trim();

                    if (!string.IsNullOrEmpty(EmailAddress) && ValidateEmail(EmailAddress) == "Valid")
                    {
                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress(ConfigurationManager.AppSettings["Email_Sender"], "SparesMe");
                        msg.To.Add(new MailAddress(EmailAddress.Trim().ToString(), FullName.Trim()));
                        msg.Subject = "Reset Your SparesMe account Password";
                        msg.BodyEncoding = Encoding.UTF8;
                        msg.IsBodyHtml = true;
                        msg.Body = string.Format("<html><head>    <title>Welcom to SparesMe</title></head><body style='background-color: #f1f1f1; font-family: arial, sans-serif; font-size: 13px; font-variant: normal; width: 700px; font-weight: 500'>    <div align='center' style='width: 650px; height: auto; min-height: 400px; margin: 25px; padding: 10px; height: auto;'>        <div align='left' style='width: 580px; height: auto; min-height: 400px; margin: 25px; padding: 10px; height: auto; border: 10px solid rgba(236, 42, 45, 0.6)'>            <br />            <div style='color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: 13px; line-height: normal; background-color: #fff; padding-top: 14px; padding-right: 14px; padding-bottom: 14px; padding-left: 14px; margin-bottom: 4px; border-top-left-radius: 5px; border-top-right-radius: 5px; border-bottom-right-radius: 5px; border-bottom-left-radius: 5px;'>                <a href='" + ConfigurationManager.AppSettings["WebSiteURL"].ToString() + "' style='color: rgb(255, 255, 255);' target='_blank'>                    <img alt='" + ConfigurationManager.AppSettings["WebSiteTitle"].ToString() + " ' src='" + ConfigurationManager.AppSettings["WebSiteURL"].ToString() + "/images/SparesMeLogo.png' style='display: block; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; border-image: initial; width: 30%;' />                </a>            </div>            <div style='color: rgb(34, 34, 34); font-size: 13px; line-height: normal; font-family: Helvetica Neue, Arial, Helvetica, sans-serif; margin-top: 14px; margin-right: 14px; margin-bottom: 14px; margin-left: 14px;'>                <h2 style='margin-top: 0px; margin-right: 0px; margin-bottom: 16px; margin-left: 0px; font-size: 18px; font-weight: normal;'>Forgot your password, ( <b>" + FullName + " </b>) ?</h2>                <p>                    " + ConfigurationManager.AppSettings["WebSiteTitle"].ToString() + "  received a request to reset the password for your " + ConfigurationManager.AppSettings["WebSiteTitle"].ToString() + "  account.                </p>                Please find your password listed below. If you wish to change the password login                                to your account using the below mentioned password and access your profile for alteration.                <br />                <br />                &quot; Password &quot; : <b>" + password + "</b><br /><br /><p style='line-height: 18px; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(238, 238, 238); padding-bottom: 10px; margin-top: 0px; margin-right: 0px; margin-bottom: 10px; margin-left: 0px;'>                    <span style='font: italic normal normal 13px/normal Georgia, serif; color: rgb(102, 102, 102);'>Team " + ConfigurationManager.AppSettings["WebSiteTitle"].ToString() + "                     </span>                </p>                <br />                <a href='" + ConfigurationManager.AppSettings["WebSiteURL"].ToString() + "/Index.aspx?popup=Login'>Signin                </a>            </div>            <p style='font-family: Arial, Helvetica, sans-serif; line-height: normal; margin-top: 5px; font-size: 10px; color: rgb(136, 136, 136);'>                Please do not reply to this message; it was sent from an unmonitored email address.            </p>            <br />        </div>    </div></body></html>");
                        msg.Priority = MailPriority.High;
                        SmtpClient client = new SmtpClient();

                        client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Email_EnableSsl"]);
                        //AWS email server to activate BEGIN

                        try
                        {
                            client.Send(msg);
                            msg.Dispose();
                            //sms password option Begin
                            //SMSControls.SMSSendFuction(CMobile.ToString(), password.ToString() + " is your Password for the Account " + EmailAddress.ToString() + " on " + ConfigurationManager.AppSettings["WebSiteURL"].ToString());
                            //sms password option END

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "var r = confirm('If there is an account associated with " + EmailAddress + " you will receive an email with a link to reset your password. , please check your Mail Inbox..'); if (r == true) var str= '/Index.aspx?popup=Login' ; location.href = str='/Index.aspx?popup=Login' ;  ", true);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    if (!string.IsNullOrEmpty(CMobile))
                    {
                        //sms password option Begin
                        SMSControls.SMSSendFuction(CMobile.ToString(), password.ToString() + " is your Password for the Account " + CMobile.ToString() + " on " + ConfigurationManager.AppSettings["WebSiteURL"].ToString());
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Please check password has been sent to your mobile number')", true);
                        //sms password option END
                    }

                    txtforgetpassword.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('The Email You Have Entered is Not in Our Records')", true);
                    txtforgetpassword.Text = string.Empty;
                    txtforgetpassword.Focus();
                    frgtPnl.Show();
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('The Email You Have Entered is not in Our Records')", true);
            txtforgetpassword.Text = string.Empty;
            txtforgetpassword.Focus();
            frgtPnl.Show();
        }
    }
}