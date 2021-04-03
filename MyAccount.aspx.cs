using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class MyAccount : System.Web.UI.Page
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
                txtEmail.Text = Session["CustomerEA"].ToString();
                txtFirstName.Text = Session["CustomerFN"].ToString();
                txtMobile.Text = Session["CustomerMobile"].ToString();

                //  txtPincode.Text = Session["CustomerPincode"].ToString();
                ddlCustomerCountry.ClearSelection();
                ListItem Country = ddlCustomerCountry.Items.FindByText(Session["CustomerCountry"].ToString());

                if (Country != null)
                {
                    Country.Selected = true;
                }

                BindPostalcode();//state binding

                ddlCustomerState.ClearSelection();
                ListItem State = ddlCustomerState.Items.FindByText(Session["CustomerState"].ToString());

                if (State != null)
                {
                    State.Selected = true;
                }

                BindCity();
                ddlCustomerCity.ClearSelection();
                ListItem City = ddlCustomerCity.Items.FindByText(Session["CustomerCity"].ToString());

                if (City != null)
                {
                    City.Selected = true;
                }


                txtAddress.Text = Session["CustomerAddress"].ToString();
                txtPincode.Text = Session["CustomerPincode"].ToString();
                //image control Begin
                objCcontrol.CustomerUID = Session["User_Area_UID"].ToString();
                ArrayList ARASelectCustomerPImage = objCcontrol.SelectCustomerPImage();

                if (ARASelectCustomerPImage[0].ToString() != string.Empty)
                {
                    Image2.ImageUrl = GenerateThumbnail(ARASelectCustomerPImage[0].ToString());
                }
                else
                {
                    Image2.ImageUrl = GenerateThumbnail("img/profile-avatar.png");
                }
                //image control Start
            }
        }
    }

    public string GenerateThumbnail(string Imgpath)
    {
        string path;
        if (File.Exists(Server.MapPath("~/" + Imgpath.ToString())))
        {
            path = Server.MapPath("~/" + Imgpath.ToString());
        }
        else
        {
            Imgpath = "/ProfileImages/profile-avatar.png";
            path = Server.MapPath("~/" + Imgpath.ToString());
        }
        //string path = Server.MapPath("~/" + Imgpath.ToString());
        System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        using (System.Drawing.Image thumbnail = image.GetThumbnailImage(150, 150, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                thumbnail.Save(memoryStream, ImageFormat.Png);
                Byte[] bytes = new Byte[memoryStream.Length];
                memoryStream.Position = 0;
                memoryStream.Read(bytes, 0, (int)bytes.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                return "data:image/png;base64," + base64String;
                //Image2.Visible = true;
            }
        }
    }

    public bool ThumbnailCallback()
    {
        return false;
    }

    CustomerControls objCcontrol = new CustomerControls();

    protected void btnProfileUploadImage_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile != null)
            {
                string Fileextenstion = Path.GetExtension(FileUpload1.PostedFile.FileName);


                objCcontrol.CustomerPImage = "ProfileImages/" + Session["User_Area_UID"].ToString() + Fileextenstion;
                objCcontrol.CustomerUID = Session["User_Area_UID"].ToString();
                ArrayList ARRupdateCustomerPImage = objCcontrol.updateCustomerPImage();
                if (ARRupdateCustomerPImage.Count > 0 && !string.IsNullOrEmpty(Fileextenstion))
                {

                    //Image2.ImageUrl = ARRupdateCustomerPImage[0].ToString();
                    //Save files to disk
                    FileUpload1.SaveAs(Server.MapPath("~/ProfileImages/" + Session["User_Area_UID"].ToString() + Fileextenstion));

                    if (ARRupdateCustomerPImage[0].ToString() != string.Empty)
                    {
                        Image2.ImageUrl = GenerateThumbnail(ARRupdateCustomerPImage[0].ToString());
                    }
                    else
                    {
                        Image2.ImageUrl = GenerateThumbnail("img/profile-avatar.png");
                    }

                    //HttpResponse.RemoveOutputCacheItem("/MyAddress.aspx");

                    jsCall("Saved");
                }
                else
                {
                    jsCall("Please try agian");

                }
            }
        }
        catch (Exception ex)
        {
            jsCall("Please add image");
        }
    }

    protected void jsCall(string alert)
    {
        string script = @"alert('" + alert + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "jsCall", script, true);
    }

    protected void ddlCustomerState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCustomerState.SelectedIndex > 0)
        {
            BindCity();
        }
        else
        { }
    }

    protected void BindPostalcode()
    {
        DataSet DSGetStateFromCountry = objCcontrol.GetStateFromCountry();
        if (DSGetStateFromCountry != null)
        {
            ddlCustomerState.Enabled = true;
            ddlCustomerState.DataTextField = "name";
            ddlCustomerState.DataValueField = "id";
            ddlCustomerState.DataSource = DSGetStateFromCountry;
            ddlCustomerState.DataBind();
            //ddlCustomerState.Items.Insert(0, "--Select--");
            //ddlCustomerState.SelectedIndex = 0;
        }
        else
        {
            // lblstsmsgserv.Text = "There is no data";
        }
    }

    protected void BindCity()
    {
        objCcontrol.CustomerStateID = ddlCustomerState.SelectedValue.ToString();
        DataSet DSGetCityFromState = objCcontrol.GetCityFromState();
        if (DSGetCityFromState != null)
        {
            ddlCustomerCity.Enabled = true;
            ddlCustomerCity.DataTextField = "name";
            ddlCustomerCity.DataValueField = "id";
            ddlCustomerCity.DataSource = DSGetCityFromState;
            ddlCustomerCity.DataBind();
            //ddlCustomerCity.Items.Insert(0, "--Select--");
            ddlCustomerCity.SelectedIndex = 0;
        }
        else
        {
            // lblstsmsgserv.Text = "There is no data";
        }
    }
    protected void ddlCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAccountEdit_Click(object sender, EventArgs e)
    {
        if (txtMobile.Text.Count() <= 12 && txtMobile.Text.Count() >= 10)
        {
            objCcontrol.CustomerUID = Session["User_Area_UID"].ToString();
            objCcontrol.First_Name = txtFirstName.Text;
            objCcontrol.Mobile = txtMobile.Text;
            objCcontrol.CustomerAddress = txtAddress.Text;

            objCcontrol.CustomerCountry = ddlCustomerCountry.SelectedItem.ToString();

            objCcontrol.CustomerState = ddlCustomerState.SelectedItem.ToString();

            objCcontrol.CustomerCity = ddlCustomerCity.SelectedItem.ToString();

            objCcontrol.PostNumberID = Convert.ToInt32(ddlCustomerCity.SelectedValue.ToString());

            objCcontrol.CustomerPincode = txtPincode.Text.Trim().ToString();

            ArrayList ArrCustomer = objCcontrol.EditCustomerProfile();
            if (ArrCustomer[0].ToString() != "Your session has expired please login once again")
            {
                if (ArrCustomer != null)
                {
                    Session["User_Area_UID"] = ArrCustomer[0].ToString();
                    Session["CustomerFN"] = ArrCustomer[1].ToString();

                    Session["CustomerMobile"] = ArrCustomer[2].ToString();
                    Session["CustomerEA"] = ArrCustomer[3].ToString();
                    Session["CustomerAddress"] = ArrCustomer[4].ToString();
                    Session["CustomerCity"] = ArrCustomer[5].ToString();
                    Session["CustomerPincode"] = ArrCustomer[6].ToString();
                    Session["CustomerState"] = ArrCustomer[7].ToString();
                    Session["CustomerCountry"] = ArrCustomer[8].ToString();
                    Session["PincodeID"] = ArrCustomer[9].ToString();

                    if ((!String.IsNullOrEmpty(Request.QueryString.Get("RedirectToAction")) && Request.QueryString.Get("RedirectToAction").Length > 2))
                    {
                        // string urlName = Request.UrlReferrer.ToString();
                        Response.Redirect("/" + Request.QueryString.Get("RedirectToAction"), true);
                    }
                    else
                    {
                        jsCall("Modified");
                        //Response.Redirect("/Accountedit.aspx", true);
                    }

                }
            }
            else
            {
            }
        }
        else
        {
            jsCall("Please enter valid mobile number");
            txtMobile.Focus();
        }
    }
}