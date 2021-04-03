using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductSearch : System.Web.UI.Page
{
    SearchProcess objSP = new SearchProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.AllKeys.Any(k => k == "Search"))
            {
                ltrlSparesMESearchResult.Text = Request.QueryString.Get("Search");
                BindParts_SparesME(ltrlSparesMESearchResult.Text);
            }
            else
            {
                //dont redirect to home screen -- Response.Redirect("Index.aspx", true);
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
            BindParts_SparesME(txtautocomplete.Text.ToString()); //Call To SearchMethod To Bind Parts --BindParts_SparesME
        //else
        // showMessageBox("Search for spare parts, brands and more");
        txtautocomplete.Focus();
    }

    public void BindParts_SparesME(string SearchKey)
    {
        ltrlSparesMESearchResult.Text = SearchKey.ToString();
        objSP.SearchKey = SearchKey.ToString();
        //Repetor Bind Begin
        DataSet DSsearchresult = objSP.GetSparesMESearchResult();
        if (DSsearchresult != null)
        {
            RPTSearchResult.DataSource = DSsearchresult;
            RPTSearchResult.DataBind();
        }
        else
        {
            RPTSearchResult.DataSource = null;
            RPTSearchResult.DataBind();
        }

        //Repetor Bind End

        //showMessageBox(SearchKey.ToString()); // TestCase after search btn hit
    }
}