using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SellerBasicInfo
/// </summary>
public class SellerBasicInfo : DBrunprocedure
{
    public string VendorBusiness_Name { get; set; }
    public string VendorBusiness_Email { get; set; }

    public string VendorAddress_Line1 { get; set; }
    public string VendorAddress_Line2 { get; set; }

    public string VendorAddress_Pincode { get; set; }
    public string VendorAddress_LandMark { get; set; }
    public string VendorAddress_City { get; set; }
    public string VendorAddress_State { get; set; }
    public string VendorAddress_Country { get; set; }
    public string MetaKeywords { get; set; }
    public string MetaDescription { get; set; }
    public string MetaTitle { get; set; }

    public ArrayList GetSellerInformationID()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@VendorName", this.VendorBusiness_Name);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            ArrayList AupdateCustomerPImage = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[GetSellerInformationID]", p);
            if (AupdateCustomerPImage != null)
                return AupdateCustomerPImage;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}