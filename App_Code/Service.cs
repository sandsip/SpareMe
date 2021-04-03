using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using System.Data;
using System.Web.Services.Protocols;
using System.ComponentModel;

/// <summary>
/// Summary description for Service_CS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{

    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetCustomers(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection(DBrunprocedure.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select ContactName, CustomerId from Customers where " +
                "ContactName like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["ContactName"], sdr["CustomerId"]));
                    }
                }
                conn.Close();
            }
            return customers.ToArray();
        }
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<string> GetEmpNames(string prefix)
    {
        List<string> Emp = new List<string>();
        string query = string.Format("select distinct  Name from [Catalog].[Product] WHERE Name LIKE   \'%{0}%\' or SearchKey LIKE \'%{0}%\' or  FREETEXT(*,'%{0}%')", prefix);

        //DBrunprocedure.cn = new SqlConnection(DBrunprocedure.m_connectionString);
        using (SqlConnection con = new SqlConnection(DBrunprocedure.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Emp.Add(reader.GetString(0));
                }
            }
        }
        return Emp;
    }

    //Search1
    public class UserDetails
    {
        public string Username;

        public string UserID;

        public string ImageURL;

        public string AdditionalInfo;
    }

    [WebMethod()]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<UserDetails> GetUsers(string input)
    {
        DataTable dt = this.CreateDatatable();
        DataRow[] rows;
        rows = dt.Select(string.Format("Username like \'%{0}%\'", input));
        List<UserDetails> result = new List<UserDetails>();
        foreach (DataRow row in rows)
        {
            UserDetails r = new UserDetails();
            r.Username = row["Username"].ToString();
            r.UserID = row["UserID"].ToString();
            r.ImageURL = row["ImageURL"].ToString();
            r.AdditionalInfo = row["AdditionalInfo"].ToString();
            result.Add(r);
        }

        return result;
    }

    private DataTable CreateDatatable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("UserID");
        dt.Columns.Add("Username");
        dt.Columns.Add("ImageURL");
        dt.Columns.Add("AdditionalInfo");
        DataRow row;
        row = dt.NewRow();
        row["UserID"] = "ZuckerbergM";
        row["Username"] = "Mark Zuckerberg";
        row["ImageURL"] = "https://upload.wikimedia.org/wikipedia/commons/3/31/Mark_Zuckerberg_at_the_37th_G8_Summit_in_Deauvill" +
        "e_018_v1.jpg";
        row["AdditionalInfo"] = "Co-Founder of Facebook";
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["UserID"] = "MuskE";
        row["Username"] = "Elon Musk";
        row["ImageURL"] = "https://upload.wikimedia.org/wikipedia/commons/0/04/Elon_Musk_-_The_Summit_2013.jpg";
        row["AdditionalInfo"] = "CEO of SpaceX and Tesla Motors";
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["UserID"] = "GatesB";
        row["Username"] = "Bill Gates mark";
        row["ImageURL"] = "https://upload.wikimedia.org/wikipedia/commons/0/01/Bill_Gates_July_2014.jpg";
        row["AdditionalInfo"] = "Co-Founder of Microsoft";
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["UserID"] = "DorseyJ";
        row["Username"] = "Jack Dorsay";
        row["ImageURL"] = "https://upload.wikimedia.org/wikipedia/commons/6/68/Jack_Dorsey_2012_Shankbone.JPG";
        row["AdditionalInfo"] = "Co-Founder of Twitter";
        dt.Rows.Add(row);
        return dt;

    }
}
