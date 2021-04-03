using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerControls
/// </summary>
public class CustomerControls : DBrunprocedure
{
    public string FaceBookControlID { get; set; }
    public string First_Name { get; set; }
    public string User_Email { get; set; }
    public string User_Password { get; set; }
    public string Mobile { get; set; }
    public string ReferredCode { get; set; }
    public string CustomerAddress { get; set; }
    public int PostNumberID { get; set; }

    public string CustomerUID { get; set; }
    public string CustomerPImage { get; set; }
    public string CustomerCountry { get; set; }
    public string CustomerState { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerStateID { get; set; }
    public string CustomerPincode { get; set; }

    public ArrayList updateCustomerPImage()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@CustomerUID", this.CustomerUID);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@CustomerPImage", this.CustomerPImage);
            p[1].SqlDbType = SqlDbType.NVarChar;
            p[1].Direction = ParameterDirection.Input;

            ArrayList AupdateCustomerPImage = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[updateCustomerPImage]", p);
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

    public ArrayList SelectCustomerPImage()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@CustomerUID", this.CustomerUID);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            ArrayList ASelectCustomerPImage = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[SelectCustomerPImage]", p);
            if (ASelectCustomerPImage != null)
                return ASelectCustomerPImage;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetStateFromCountry()
    {
        try
        {
            DataSet DGetStateFromCountry = DBrunprocedure.GetAllRecords(ConnectionString, "[Customer].[GetStateFromCountry]");
            if (DGetStateFromCountry.Tables[0].Rows.Count > 0)
                return DGetStateFromCountry;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetCityFromState()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[1] = new SqlParameter("@CustomerStateID", this.CustomerStateID);
            p[1].SqlDbType = SqlDbType.NVarChar;
            p[1].Direction = ParameterDirection.Input;


            DataSet DSGetCityFromState = DBrunprocedure.GetRecords(ConnectionString, "[Customer].[GetCityFromState]", p);
            if (DSGetCityFromState.Tables.Count > 0 && DSGetCityFromState.Tables[0].Rows.Count > 0)
                return DSGetCityFromState;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList EditCustomerProfile()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[10];

            p[0] = new SqlParameter("@CustomerUID", this.CustomerUID);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@CustomerFN", this.First_Name);
            p[1].SqlDbType = SqlDbType.NVarChar;
            p[1].Direction = ParameterDirection.Input;

            p[3] = new SqlParameter("@CustomerMobile", this.Mobile);
            p[3].SqlDbType = SqlDbType.NVarChar;
            p[3].Direction = ParameterDirection.Input;

            p[4] = new SqlParameter("@CustomerAddress", this.CustomerAddress);
            p[4].SqlDbType = SqlDbType.NVarChar;
            p[4].Direction = ParameterDirection.Input;

            p[5] = new SqlParameter("@PostNumberID", this.PostNumberID);
            p[5].SqlDbType = SqlDbType.Int;
            p[5].Direction = ParameterDirection.Input;

            p[6] = new SqlParameter("@CustomerCountry", this.CustomerCountry);
            p[6].SqlDbType = SqlDbType.NVarChar;
            p[6].Direction = ParameterDirection.Input;

            p[7] = new SqlParameter("@CustomerState", this.CustomerState);
            p[7].SqlDbType = SqlDbType.NVarChar;
            p[7].Direction = ParameterDirection.Input;

            p[8] = new SqlParameter("@CustomerCity", this.CustomerCity);
            p[8].SqlDbType = SqlDbType.NVarChar;
            p[8].Direction = ParameterDirection.Input;

            p[9] = new SqlParameter("@CustomerPincode", this.CustomerPincode);
            p[9].SqlDbType = SqlDbType.NVarChar;
            p[9].Direction = ParameterDirection.Input;


            ArrayList ArrEditCustomerProfile = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[EditCustomerProfile]", p);
            if (ArrEditCustomerProfile != null)
                return ArrEditCustomerProfile;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}