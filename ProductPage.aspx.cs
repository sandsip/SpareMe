using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductPage : System.Web.UI.Page
{
    SearchProcess objGetPartNumberDeatils = new SearchProcess();

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
            Response.Redirect("ProductSearch.aspx?Search=" + txtautocomplete.Text);
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
            if (Request.QueryString.AllKeys.Any(k => k == "PartNumber"))
            {
                string PartNumber = Request.QueryString.Get("PartNumber");
                ltrlSparesMESearchResult.Text = PartNumber.ToString();
                DisplayPartInfo(PartNumber);
                BindParts_SellerDisplayList(PartNumber);
            }
            else
            {
                Response.Redirect("Index.aspx", true);
            }
        }
    }

    public void DisplayPartInfo(string PartInfo)
    {
        objGetPartNumberDeatils.SearchPartNumber_SSi = PartInfo.ToString();
        ArrayList ARRGetPartDetailsOnSSI = objGetPartNumberDeatils.GetPartDetailsOnSSI();
        if (ARRGetPartDetailsOnSSI.Count > 0)
        {
            ltrlSSI_PartNumber.Text = ARRGetPartDetailsOnSSI[0].ToString();
            ltrlSDesc.Text = ARRGetPartDetailsOnSSI[1].ToString();
            ltrlLDesc.Text = ARRGetPartDetailsOnSSI[2].ToString();
        }
        else
        {
            //if info not thr ...
        }
    }

    public void BindParts_SellerDisplayList(string SearchKey)
    {
        objGetPartNumberDeatils.SearchPartNumber_SSi = SearchKey.ToString();
        //Repetor Bind Begin
        DataSet DSGetSellerList = objGetPartNumberDeatils.GetPartDetailsOnSSI_SellerList();
        if (DSGetSellerList != null)
        {
            RPTSellerDisplayList.DataSource = DSGetSellerList;
            RPTSellerDisplayList.DataBind();
        }
        else
        {
            RPTSellerDisplayList.DataSource = null;
            RPTSellerDisplayList.DataBind();
        }

        //Repetor Bind End

        //showMessageBox(SearchKey.ToString()); // TestCase after search btn hit
    }
}