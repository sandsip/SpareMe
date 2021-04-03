using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchProcess
/// </summary>
public class SearchProcess : DBrunprocedure
{

    public int ProductId { get; set; }
    public string SearchKey { get; set; }

    public string SearchPartNumber_SSi { get; set; }
    public string VendorName { get; set; }

    public DataSet GetSparesMESearchResult()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@SKey", this.SearchKey);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            DataSet DSAdmin_GetVendorList = DBrunprocedure.GetRecords(ConnectionString, "[Customer].[GetSparesMESearchResult]", p);
            if (DSAdmin_GetVendorList.Tables.Count > 0 && DSAdmin_GetVendorList.Tables[0].Rows.Count > 0)
                return DSAdmin_GetVendorList;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList GetPartDetailsOnSSI()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@SearchPartNumber_SSi", this.SearchPartNumber_SSi);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            ArrayList ARRGetPartDetailsOnSSI = GetRecord(ConnectionString, "[Customer].[GetPartDetailsOnSSI]", p);
            if (ARRGetPartDetailsOnSSI != null)
                return ARRGetPartDetailsOnSSI;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetPartDetailsOnSSI_SellerList()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@SearchPartNumber_SSi", this.SearchPartNumber_SSi);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            DataSet DSAdmin_GetVendorList = DBrunprocedure.GetRecords(ConnectionString, "[Customer].[GetPartDetailsOnSSI_SellerList]", p);
            if (DSAdmin_GetVendorList.Tables.Count > 0 && DSAdmin_GetVendorList.Tables[0].Rows.Count > 0)
                return DSAdmin_GetVendorList;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList GetPartDetails_SellerID_PartNo()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@SearchPartNumber_SSi", this.SearchPartNumber_SSi);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@VendorName", this.VendorName);
            p[1].SqlDbType = SqlDbType.NVarChar;
            p[1].Direction = ParameterDirection.Input;

            ArrayList ARRGetPartDetailsOnSSI = GetRecord(ConnectionString, "[Customer].[GetPartDetails_SellerID_PartNo]", p);
            if (ARRGetPartDetailsOnSSI != null)
                return ARRGetPartDetailsOnSSI;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetListProductPictureMappingPID()
    {
        try
        {
            SqlParameter[] sqlParameterArray = new SqlParameter[1];

            sqlParameterArray[0] = new SqlParameter("@ProductId", (object)this.ProductId);
            sqlParameterArray[0].SqlDbType = SqlDbType.Int;
            sqlParameterArray[0].Direction = ParameterDirection.Input;

            DataSet DSGetADSList = DBrunprocedure.GetRecords(ConnectionString, "[Catalog].[GetListProductPictureMappingPID]", sqlParameterArray);
            if (DSGetADSList.Tables[0].Rows.Count > 0)
                return DSGetADSList;
            else
                return (DataSet)null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}