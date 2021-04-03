using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VDFrontMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.AllKeys.Any(k => k == "Search"))
            {
                txtautocomplete.Text = Request.QueryString.Get("Search");
            }
            else
            {
                //dont redirect to home screen -- Response.Redirect("Index.aspx", true);
            }
        }
    }
}
