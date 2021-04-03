using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {            
            txtautocomplete.Focus();
        }
    }

    [WebMethod]
    public static Cinemadetails[] GetSearcher(string SearchElement)
    {
        CallerTune objsearcher = new CallerTune();

        objsearcher._BrowseMusicCategory = SearchElement.ToString().Trim();
        DataTable Dt = objsearcher.GetSearchElement().Tables[0];

        List<Cinemadetails> Lst = new List<Cinemadetails>();

        if (Dt != null)
        {
            foreach (DataRow dtrow in Dt.Rows)
            {
                Cinemadetails CinemList = new Cinemadetails();
                CinemList.imgpath = dtrow["imgpath"].ToString().Replace(" ", "%20");
                CinemList.URLLink = dtrow["URLLink"].ToString().Replace(" ", "-") + ".aspx";
                CinemList.MovieTitle = dtrow["MovieTitle"].ToString();
                Lst.Add(CinemList);
            }
        }
        else
        {
            Lst = null;
        }

        return Lst.ToArray();
    }

    public class Cinemadetails
    {
        public string imgpath { get; set; }
        public string URLLink { get; set; }
        public string MovieTitle { get; set; }
    }

   
}