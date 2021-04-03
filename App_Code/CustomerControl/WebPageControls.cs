using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebPageControls
/// </summary>
public class WebPageControls : DBrunprocedure
{
    public string WebPagePost { get; set; }

    public ArrayList GetWebPages()
    {
        SqlParameter[] p;
        try
        {
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@Temp", this.WebPagePost);
            p[0].SqlDbType = SqlDbType.NVarChar;
            p[0].Direction = ParameterDirection.Input;

            ArrayList ARGetWebPages = DBrunprocedure.GetRecord(ConnectionString, "GetWebPages", p);
            if (ARGetWebPages != null)
                return ARGetWebPages;
            else
                return null;

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}