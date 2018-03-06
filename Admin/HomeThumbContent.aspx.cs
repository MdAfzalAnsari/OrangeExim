using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;

public partial class Admin_HomeThumbContent : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }        
        bindthumbs();
    }

    private void bindthumbs()
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        com.CommandText = "select * from thumbIcon";
        com.Connection = con;
        da.SelectCommand = com;
        ds.Clear();
        da.Fill(ds);
        Thumbdetails.DataSource = ds;
        Thumbdetails.DataBind();   
    }
    protected string Imagebind(string id,string name)
    {
        string strhtml = "";
        try
        {
            if (!string.IsNullOrEmpty(id))
            {
                string ImageName = id;
                string DirPath = Path.Combine("../images", "HomeThumbImages");
                DirPath = DirPath.Replace("\\", "/");

                if (File.Exists(Path.Combine(Server.MapPath(DirPath), ImageName)))
                {
                   // strhtml = "<td align='left' valign='top' style='width:12%;'>";
                    strhtml += "<td><div style='padding: 8px;'><img  src='" + DirPath + "/" + ImageName + "' alt='' class='grid_pro_image'/></td>";
                    strhtml += "<td><div class='productretrive'>" + name + "</a> </td></div></div>";
                   // strhtml += "<div class='clear h20'></div>";
                }
            }
        }
        catch(Exception ex)
        {
            return ex.ToString();
        }

        return strhtml;
    }
}