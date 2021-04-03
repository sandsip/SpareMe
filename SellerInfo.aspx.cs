using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SellerInfo : System.Web.UI.Page
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

    SellerBasicInfo objSBasicInfo = new SellerBasicInfo();
    SearchProcess objGetPartNumberDeatils = new SearchProcess();

    protected void Page_Load(object sender, EventArgs e)
    {
        Button BTNSearchME = (Button)this.Master.FindControl("BTNSearchME");
        BTNSearchME.Click += new EventHandler(BTNSearchME_Click);

        if (!IsPostBack)
        {
            if (Request.QueryString.AllKeys.Any(k => k == "Seller") && !string.IsNullOrEmpty(Request.QueryString["Seller"].ToString()))
            {
                objSBasicInfo.VendorBusiness_Name = Request.QueryString["Seller"].ToString();
                ArrayList ARGetSellerInformationID = objSBasicInfo.GetSellerInformationID();

                if (ARGetSellerInformationID != null)
                {
                    ltrlSellerDisplayName.Text = SellerDisplayName.Text = ARGetSellerInformationID[8].ToString();

                    linkseller.HRef = "ProductSearch.aspx?Search=" + ARGetSellerInformationID[8].ToString();

                    ltrlSellerinfo.Text = "Based in " + ARGetSellerInformationID[16].ToString() + ", " + ARGetSellerInformationID[8].ToString() + " has been an SparesMe member since " + ARGetSellerInformationID[17].ToString();
                    Page.Title = ARGetSellerInformationID[7].ToString() + " | SparesMe";

                    ltrlSellerAddress.Text = ARGetSellerInformationID[10].ToString() + "" + ARGetSellerInformationID[11].ToString();

                    //Page description
                    HtmlMeta pagedesc = new HtmlMeta();
                    pagedesc.Name = "Description";
                    pagedesc.Content = ARGetSellerInformationID[6].ToString() + " | " + DateTime.Now;
                    Header.Controls.Add(pagedesc);

                    //page keywords
                    HtmlMeta pagekeywords = new HtmlMeta();
                    pagekeywords.Name = "keywords";
                    pagekeywords.Content = ARGetSellerInformationID[5].ToString();
                    Header.Controls.Add(pagekeywords);
                }
                else
                {

                }
            }

            //when partnumber display --URL Display PartNumber
            if (Request.QueryString.AllKeys.Any(k => k == "PartNumber") && !string.IsNullOrEmpty(Request.QueryString["PartNumber"].ToString()))
            {
                PartNumber.Visible = true;
                DisplayPartInfo(Request.QueryString["Seller"].ToString(), Request.QueryString["PartNumber"].ToString());
            }
            else
            {
                PartNumber.Visible = false;
            }

            //when SSN is present
            if (Request.QueryString.AllKeys.Any(k => k == "SSNID") && !string.IsNullOrEmpty(Request.QueryString["SSNID"].ToString()))
                GetExclusiveList(Request.QueryString["SSNID"].ToString());

        }
    }

    public void DisplayPartInfo(string VName, string PartInfo)
    {
        try
        {
            objGetPartNumberDeatils.VendorName = VName.ToString();
            objGetPartNumberDeatils.SearchPartNumber_SSi = PartInfo.ToString();
            ArrayList ARRGetPartDetails_SellerID_PartNo = objGetPartNumberDeatils.GetPartDetails_SellerID_PartNo();
            if (ARRGetPartDetails_SellerID_PartNo.Count > 0)
            {
                ltrlSSI_PartNumber.Text = ARRGetPartDetails_SellerID_PartNo[2].ToString();
                ltrlTitle.Text = ARRGetPartDetails_SellerID_PartNo[3].ToString();
                ltrlSDesc.Text = ARRGetPartDetails_SellerID_PartNo[4].ToString();
                ltrlLDesc.Text = ARRGetPartDetails_SellerID_PartNo[5].ToString();


                Page.Title = ARRGetPartDetails_SellerID_PartNo[8].ToString() + " | Buy genuine spare parts for cars and bikes from SparesME.in";
                //Page description
                HtmlMeta pagedesc = new HtmlMeta();
                pagedesc.Name = "Description";
                pagedesc.Content = ARRGetPartDetails_SellerID_PartNo[7].ToString() + " | " + DateTime.Now;
                Header.Controls.Add(pagedesc);

                //page keywords
                HtmlMeta pagekeywords = new HtmlMeta();
                pagekeywords.Name = "keywords";
                pagekeywords.Content = ARRGetPartDetails_SellerID_PartNo[6].ToString();
                Header.Controls.Add(pagekeywords);
            }
            else
            {
                //if info not thr ...
            }
        }
        catch
        {
            string message = "You will now be redirected to Meet Seller Search Page.(This seller not verified with us)";
            string url = "/ProductPage.aspx?PartNumber=" + PartInfo.ToString(); ;
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
    }

    #region Product Image Slide
    public class SparesMEImage
    {
        public string PicturePath { get; set; }
        public string PictureName { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
    }
    private void GetExclusiveList(string SSN)
    {
        objGetPartNumberDeatils.ProductId = int.Parse(SSN.ToString());
        DataSet DSGetListProductPictureMappingPID = objGetPartNumberDeatils.GetListProductPictureMappingPID();
        if (DSGetListProductPictureMappingPID != null)
        {
            RPTProductImgSlide.DataSource = DSGetListProductPictureMappingPID;
            RPTProductImgSlide.DataBind();
        }
        else
        {
            List<SparesMEImage> sparesMEImage = new List<SparesMEImage>();
            sparesMEImage.Add(new SparesMEImage() { PicturePath = "/images/no-image-product.png", PictureName = "", AltAttribute = " Buy genuine spare parts for cars and bikes from SparesME.in", TitleAttribute = " Buy genuine spare parts for cars and bikes from SparesME.in" });

            RPTProductImgSlide.DataSource = sparesMEImage;
            RPTProductImgSlide.DataBind();
        }
    }

    private int index = 1;
    protected string GetDivClass()
    {
        if (index == 1)
        {
            index++;
            return "active";
        }
        else
        {
            return "";
        }
    }
    #endregion
}