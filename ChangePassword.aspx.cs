using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
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

    protected void Page_Load(object sender, EventArgs e)
    {
        Button BTNSearchME = (Button)this.Master.FindControl("BTNSearchME");
        BTNSearchME.Click += new EventHandler(BTNSearchME_Click);

        if (!IsPostBack)
        {
            if (Session["User_Area_UID"] == null)
            {
                Session.Remove("User_Area_UID");
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Please login ')", true);                
                Response.Redirect("/Index.aspx?Popup=Login");
            }
            else
            {

            }
        }
    }
    protected void jsCall(string alert)
    {
        string script = @"alert('" + alert + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "jsCall", script, true);
    }

    Gateway_Control objChangePassword = new Gateway_Control();

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Text == txtConfirmNewPassword.Text)
        {
            if (txtNewPassword.Text.Length >= 6)
            {                
                objChangePassword.CustomerUID = Session["User_Area_UID"].ToString();
                objChangePassword.New_pwd = txtNewPassword.Text.Trim();

               ArrayList  arrChangepwd_status = objChangePassword.Change_userPassword();
                if (arrChangepwd_status != null)
                {
                    if (arrChangepwd_status[0].ToString() == "1")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Password Changed.')", true);
                        txtConfirmNewPassword.Text = "";
                        
                        txtNewPassword.Text = "";
                    }
                    else if (arrChangepwd_status[0].ToString() == "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Invalid Current Password.')", true);
                        
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Please make sure Password length is must be greater then 6 Digit Alpha Numeric Character.')", true);
                txtNewPassword.Focus();
            }
        }
        else
        {

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Message", "alert('Please make sure your passwords match.')", true);
            txtConfirmNewPassword.Focus();
        }
    }
}