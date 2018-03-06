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

public partial class Admin_HomeAboutCompany : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    
    string data;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        Updatehead.Visible = false;
        loadcontent();
             
    }

    private void loadcontent()
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        com.CommandText = "select homeabout from com_info";
        con.Open();
        com.Connection = con;
        data = (string)com.ExecuteScalar();
        if (!IsPostBack)
        {
            about_content.InnerText = data;
        }
    }
    protected void EditContent(object sender, EventArgs e)
    {
        string detail = about_content.InnerText;
        com.CommandText = "update com_info set homeabout='" + detail + "' where id=1";        
        com.Connection = con;
        int i=com.ExecuteNonQuery();
        if (i > 0)
        {
            Updatehead.Visible = true;
            statuslabel.Text = "Content Updated";
        }
    }
}