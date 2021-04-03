using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CallerTune
/// </summary>
public class CallerTune
{
    public CallerTune()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Constr = DBrunprocedure.ConnectionString;

    public string _BrowseMusicCategory { get; set; }

    public DataSet GetCallerTuneMusicGenre()
    {
        try
        {
            SqlParameter[] sqlParameterArray = new SqlParameter[1];

            sqlParameterArray[0] = new SqlParameter("@BrowseMusicCategory", (object)this._BrowseMusicCategory);
            sqlParameterArray[0].SqlDbType = SqlDbType.NVarChar;
            sqlParameterArray[0].Direction = ParameterDirection.Input;

            DataSet DSGetParticularMusicGenre = DBrunprocedure.GetRecords(this.Constr, "GetCallerTuneMusicGenre", sqlParameterArray);
            if (DSGetParticularMusicGenre.Tables[0].Rows.Count > 0)
                return DSGetParticularMusicGenre;
            else
                return (DataSet)null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }


    public DataSet GetSearchElement()
    {
        try
        {
            SqlParameter[] sqlParameterArray = new SqlParameter[1];

            sqlParameterArray[0] = new SqlParameter("@BrowseMusicCategory", (object)this._BrowseMusicCategory);
            sqlParameterArray[0].SqlDbType = SqlDbType.NVarChar;
            sqlParameterArray[0].Direction = ParameterDirection.Input;

            DataSet DSGetParticularMusicGenre = DBrunprocedure.GetRecords(this.Constr, "GetSearchElement", sqlParameterArray);
            if (DSGetParticularMusicGenre.Tables[0].Rows.Count > 0)
                return DSGetParticularMusicGenre;
            else
                return (DataSet)null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string searchtext { get; set; }

    public DataSet Admin_CallerTuneDetails()
    {
        try
        {
            SqlParameter[] sqlParameterArray = new SqlParameter[1]
        {
          new SqlParameter("@SearchText", (object) this.searchtext)
        };
            sqlParameterArray[0].SqlDbType = SqlDbType.NVarChar;
            sqlParameterArray[0].Direction = ParameterDirection.Input;


            DataSet DAdmin_CallerTuneDetails = DBrunprocedure.GetRecords(this.Constr, "Admin_CallerTuneDetails", sqlParameterArray);
            if (DAdmin_CallerTuneDetails.Tables[0].Rows.Count > 0)
                return DAdmin_CallerTuneDetails;
            else
                return (DataSet)null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string BrowseMusicCallerTunesID { get; set; }

    public ArrayList DeleteCallerTuneTitle()
    {
        try
        {
            SqlParameter[] sqlParameterArray = new SqlParameter[1];

            sqlParameterArray[0] = new SqlParameter("@BrowseMusicCallerTunesID", (object)this.BrowseMusicCallerTunesID);
            sqlParameterArray[0].SqlDbType = SqlDbType.UniqueIdentifier;
            sqlParameterArray[0].Direction = ParameterDirection.Input;

            return DBrunprocedure.GetRecord(this.Constr, "DeleteCallerTuneTitle", sqlParameterArray) ?? (ArrayList)null;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}