using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Gateway_Control
/// </summary>
public class Gateway_Control : DBrunprocedure
{
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string Current_pwd { get; set; }
    public string New_pwd { get; set; }    
    public string CustomerUID { get; set; }
    public string CustomerMobile { get; set; }
    public string CustomerEA { get; set; }
    public string CustomerFN { get; set; }

    public ArrayList Check_Customer_Credentials()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@CustomerEA", this.UserName);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@CustomerPassword", GenericFunctions.Encrypt(this.UserPassword));
            p[1].SqlDbType = SqlDbType.NVarChar;
            p[1].Direction = ParameterDirection.Input;

            ArrayList ARRCheck_Customer_Credentials = GetRecord(ConnectionString, "[Customer].[Check_Customer_Credentials]", p);
            if (ARRCheck_Customer_Credentials != null)
                return ARRCheck_Customer_Credentials;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList Check_Customer_Email()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@Cust_email", this.UserName);
            p[0].SqlDbType = SqlDbType.VarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@CustomerPassword", GenericFunctions.Encrypt(this.UserPassword));
            p[1].SqlDbType = SqlDbType.VarChar;
            p[1].Direction = ParameterDirection.Input;

            ArrayList arr7 = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[Check_Customer_Email]", p);
            if (arr7 != null)
                return arr7;
            else
                return null;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList VerifyCustomer()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[2];

            p[0] = new SqlParameter("@CustomerEA", this.CustomerEA);
            p[0].SqlDbType = SqlDbType.VarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@CustomerMobile", this.CustomerMobile);
            p[1].SqlDbType = SqlDbType.VarChar;
            p[1].Direction = ParameterDirection.Input;

            ArrayList arr7 = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[VerifyCustomer]", p);
            if (arr7 != null)
                return arr7;
            else
                return null;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList CreateCustomer()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[4];

            p[0] = new SqlParameter("@CustomerEA", this.CustomerEA);
            p[0].SqlDbType = SqlDbType.VarChar;
            p[0].Direction = ParameterDirection.Input;

            p[1] = new SqlParameter("@CustomerMobile", this.CustomerMobile);
            p[1].SqlDbType = SqlDbType.VarChar;
            p[1].Direction = ParameterDirection.Input;

            p[2] = new SqlParameter("@CustomerFN", this.CustomerFN);
            p[2].SqlDbType = SqlDbType.VarChar;
            p[2].Direction = ParameterDirection.Input;

            p[3] = new SqlParameter("@CustomerPassword", this.Current_pwd);
            p[3].SqlDbType = SqlDbType.VarChar;
            p[3].Direction = ParameterDirection.Input;

            ArrayList arr7 = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[CreateCustomer]", p);
            if (arr7 != null)
                return arr7;
            else
                return null;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public ArrayList Change_userPassword()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[3];


            p[0] = new SqlParameter("@User_Area_UID", this.CustomerUID);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            p[2] = new SqlParameter("@New_Pwd", GenericFunctions.Encrypt(this.New_pwd));
            p[2].SqlDbType = SqlDbType.NVarChar;
            p[2].Direction = ParameterDirection.Input;

            ArrayList ARRChange_userPassword = DBrunprocedure.GetRecord(ConnectionString, "[Customer].[Change_userPassword]", p);
            if (ARRChange_userPassword != null)
                return ARRChange_userPassword;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }



}