using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public class DBrunprocedure
{

    //private static string m_connectionString = "Data Source=182.50.133.111; Initial Catalog=JKonline; User ID=JKonline; Password='Secure123#';Connect Timeout=200; pooling='true'; Max Pool Size=1000";
    //private static string m_connectionString = "Data Source=NS1; Initial Catalog=DFMusicDB;Integrated Security=True; Connect Timeout=200; pooling='true'; Max Pool Size=1000";
    //private static string m_connectionString = "Data Source=SANDESH-PC\\SANDESH;Initial Catalog=DFMusicDB;Integrated Security=True;Max Pool Size=1000";
    //private static string m_connectionString = "Data Source=SANDESH-PC\\SQLEXPRESS; Initial Catalog=DFMusicDB; User ID=sa; Password='Secure123#';Connect Timeout=200; pooling='false'; Max Pool Size=200";
    // private static string m_connectionString = "Data Source=182.50.133.111; Initial Catalog=JKonline; User ID=JKonline; Password='Secure123#';Connect Timeout=2000; pooling='true'; Max Pool Size=2000";
    private static string m_connectionString = "Data Source=DESKTOP-JSENO6G; Initial Catalog=DBNSparesMe; User ID=sa; Password='Secure123#';Connect Timeout=200; pooling='false'; Max Pool Size=200";
    //private static string m_connectionString = "Data Source=SANDESH-PC\\SQLEXPRESS; Initial Catalog=DBNSparesMe; User ID=sa; Password='Secure123#';Connect Timeout=200; pooling='false'; Max Pool Size=200";
    //private static string m_connectionString = "Data Source=dbisparesme.cjtutaupcdlc.ap-south-1.rds.amazonaws.com; Initial Catalog=DBNSparesMe; User ID=DBUSparesMe; Password='Secure123#';Connect Timeout=2000; pooling='true'; Max Pool Size=2000";

    private static SqlConnection cn;
    private static SqlCommand cmd;
    private static SqlDataReader dr;
    private static SqlDataAdapter da;
    private static DataSet ds;

    public static string ConnectionString
    {
        get
        {
            return DBrunprocedure.m_connectionString;
        }
    }

    static DBrunprocedure()
    {
    }

    public DBrunprocedure()
    {
        try
        {
            DBrunprocedure.cn = (SqlConnection)null;
            DBrunprocedure.cmd = (SqlCommand)null;
            DBrunprocedure.dr = (SqlDataReader)null;
            DBrunprocedure.da = (SqlDataAdapter)null;
            DBrunprocedure.ds = (DataSet)null;
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (DBrunprocedure.cn != null && DBrunprocedure.cn.State == ConnectionState.Open)
                DBrunprocedure.cn.Close();
        }
    }

    public static void RunSQLProcedure(string connectionstring, string procname, SqlParameter[] param)
    {
        try
        {
            DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
            DBrunprocedure.cn.Open();
            DBrunprocedure.cmd = new SqlCommand(procname, DBrunprocedure.cn);
            DBrunprocedure.cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParameter in param)
            {
                if (sqlParameter != null)
                    DBrunprocedure.cmd.Parameters.Add(sqlParameter);
            }
            DBrunprocedure.cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (DBrunprocedure.cn != null && DBrunprocedure.cn.State == ConnectionState.Open)
                DBrunprocedure.cn.Close();
        }
    }

    public static void RunAllSQLProcedure(string connectionstring, string procname)
    {
        try
        {
            DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
            DBrunprocedure.cn.Open();
            DBrunprocedure.cmd = new SqlCommand(procname, DBrunprocedure.cn);
            DBrunprocedure.cmd.CommandType = CommandType.StoredProcedure;
            DBrunprocedure.cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (DBrunprocedure.cn != null && DBrunprocedure.cn.State == ConnectionState.Open)
                DBrunprocedure.cn.Close();
        }
    }

    public static DataSet GetRecords(string connectionstring, string procname, SqlParameter[] param)
    {
        try
        {
            DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
            DBrunprocedure.cn.Open();
            DBrunprocedure.cmd = new SqlCommand(procname, DBrunprocedure.cn);
            DBrunprocedure.ds = new DataSet();
            DBrunprocedure.cmd.CommandType = CommandType.StoredProcedure;
            DBrunprocedure.da = new SqlDataAdapter(DBrunprocedure.cmd);
            foreach (SqlParameter sqlParameter in param)
            {
                if (sqlParameter != null)
                    DBrunprocedure.cmd.Parameters.Add(sqlParameter);
            }
            DBrunprocedure.da.Fill(DBrunprocedure.ds, procname);
            return DBrunprocedure.ds;
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (DBrunprocedure.dr != null && !DBrunprocedure.dr.IsClosed)
                DBrunprocedure.dr.Close();
            if (DBrunprocedure.cn != null && DBrunprocedure.cn.State == ConnectionState.Open)
                DBrunprocedure.cn.Close();
        }
    }

    public static ArrayList GetRecord(string connectionstring, string procname, SqlParameter[] param)
    {
        try
        {
            DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
            DBrunprocedure.cn.Open();
            DBrunprocedure.cmd = new SqlCommand(procname, DBrunprocedure.cn);
            DBrunprocedure.cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParameter in param)
            {
                if (sqlParameter != null)
                    DBrunprocedure.cmd.Parameters.Add(sqlParameter);
            }
            DBrunprocedure.dr = DBrunprocedure.cmd.ExecuteReader();
            if (DBrunprocedure.dr == null)
                return (ArrayList)null;
            int num = 0;
            ArrayList arrayList = new ArrayList();
            while (DBrunprocedure.dr.Read())
            {
                for (int index = 0; index < DBrunprocedure.dr.FieldCount; ++index)
                {
                    arrayList.Add((object)DBrunprocedure.dr[index].ToString());
                    ++num;
                }
            }
            if (num > 0)
                return arrayList;
            else
                return (ArrayList)null;
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (DBrunprocedure.dr != null && !DBrunprocedure.dr.IsClosed)
                DBrunprocedure.dr.Close();
            if (DBrunprocedure.cn != null && DBrunprocedure.cn.State == ConnectionState.Open)
                DBrunprocedure.cn.Close();
        }
    }

    public static DataSet GetAllRecords(string connectionstring, string procname)
    {
        try
        {
            DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
            DBrunprocedure.cmd = new SqlCommand(procname, DBrunprocedure.cn);
            DBrunprocedure.ds = new DataSet();
            DBrunprocedure.cmd.CommandType = CommandType.StoredProcedure;
            DBrunprocedure.da = new SqlDataAdapter(DBrunprocedure.cmd);
            DBrunprocedure.da.Fill(DBrunprocedure.ds, procname);
            return DBrunprocedure.ds;
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static ArrayList GetInfo(string connectionstring, string procname)
    {
        try
        {
            DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
            DBrunprocedure.cn.Open();
            DBrunprocedure.cmd = new SqlCommand(procname, DBrunprocedure.cn);
            DBrunprocedure.cmd.CommandType = CommandType.StoredProcedure;
            DBrunprocedure.dr = DBrunprocedure.cmd.ExecuteReader();
            if (DBrunprocedure.dr == null)
                return (ArrayList)null;
            ArrayList arrayList = new ArrayList();
            if (!DBrunprocedure.dr.HasRows)
                return (ArrayList)null;
            DataTable dataTable = new DataTable();
            dataTable.Load((IDataReader)DBrunprocedure.dr);
            foreach (DataRow dataRow in (InternalDataCollectionBase)dataTable.Rows)
            {
                foreach (DataColumn index in (InternalDataCollectionBase)dataTable.Columns)
                    arrayList.Add(dataRow[index]);
            }
            return arrayList;
        }
        catch (SqlException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (DBrunprocedure.dr != null && !DBrunprocedure.dr.IsClosed)
                DBrunprocedure.dr.Close();
            if (DBrunprocedure.cn != null && DBrunprocedure.cn.State == ConnectionState.Open)
                DBrunprocedure.cn.Close();
        }
    }
}
