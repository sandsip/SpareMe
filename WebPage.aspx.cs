using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebPage : System.Web.UI.Page
{
    public string WebPageTitle = "";
    public string WebPageHeadLine = "";
    public string WebPageDesc = "";
    public string ItemCustomerURl = "";
    public string CompleteURL = "";
    public string FBDescription { get; set; }
    public string FBKeywords { get; set; }

    WebPageControls objWebPost = new WebPageControls();

    protected void Page_Load(object sender, EventArgs e)
    {
        Button BTNSearchME = (Button)this.Master.FindControl("BTNSearchME");
        BTNSearchME.Click += new EventHandler(BTNSearchME_Click);

        try
        {
            CompleteURL += Request.Url.AbsoluteUri;
            if (!String.IsNullOrEmpty(Request.QueryString["Page"]))
            {
                ItemCustomerURl += Request.Url.AbsoluteUri;

                string WebPageName = Request.QueryString.Get("Page").ToString().Replace("-", " ");  //Item Name
                objWebPost.WebPagePost = WebPageName;
                ArrayList ArrGetWebPages = objWebPost.GetWebPages();

                WebPageDesc += ArrGetWebPages[1].ToString();
                WebPageTitle += ArrGetWebPages[0].ToString();
                WebPageHeadLine += ArrGetWebPages[4].ToString();

                Page.Title = ArrGetWebPages[0].ToString() + ", " + ArrGetWebPages[3].ToString() + " SparesMe  " + DateTime.Now;
                FBDescription += ArrGetWebPages[0].ToString() + ", " + ArrGetWebPages[4].ToString() + " | " + " SparesMe  " + DateTime.Now;
                FBKeywords += ArrGetWebPages[3].ToString() + ", " + ArrGetWebPages[4].ToString();



                //Page description
                HtmlMeta pagedesc = new HtmlMeta();
                pagedesc.Name = "Description";
                pagedesc.Content = ArrGetWebPages[0].ToString() + ", " + ArrGetWebPages[4].ToString() + " | " + "SparesMe  " + DateTime.Now;
                Header.Controls.Add(pagedesc);

                //page keywords
                HtmlMeta pagekeywords = new HtmlMeta();
                pagekeywords.Name = "keywords";
                pagekeywords.Content = ArrGetWebPages[0].ToString() + ", " + ArrGetWebPages[3].ToString() + " | " + "SparesMe  " + DateTime.Now;

            }

        }
        catch (Exception ex)
        {
            Response.Redirect("/Index.aspx", true);
        }
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
            Response.Redirect("ProductSearch.aspx?Search=" + txtautocomplete.Text);
        //else
        // showMessageBox("Search for spare parts, brands and more");

        txtautocomplete.Focus();
    }
}