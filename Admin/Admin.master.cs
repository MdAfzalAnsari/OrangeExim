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

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader, reader1, reader2, reader4, readercatalog;
    string html, product = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        bindphone();
        bindmobile();
        bindemail();
        BindLogo();
    }
    private void bindphone()
    {
        com.CommandText = "select phone from admin_contact_us_detail";
        com.Connection = con;
        reader1 = com.ExecuteReader();
        if (reader1.HasRows)
        {
            reader1.Read();
            string mob = reader1.GetString(0);
            phone.Text = mob;
        }
        reader1.Close();
    }
    private void bindemail()
    {
        com.CommandText = "select email from admin_contact_us_detail";
        com.Connection = con;
        reader2 = com.ExecuteReader();
        if (reader2.HasRows)
        {
            reader2.Read();
            string mob = reader2.GetString(0);
            adminemail.HRef = "mailto:" + mob;
            email.Text = mob;


        }
        reader2.Close();
    }

    private void bindmobile()
    {
        com.CommandText = "select Mobile from admin_contact_us_detail";
        com.Connection = con;
        reader = com.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            string mob = reader.GetString(0);
            mobile.Text = mob;
        }
        reader.Close();
    }
    private void BindLogo()
    {
        string s = "";
        //cnn.ConnectionString = "Data Source=GLOBELERA-PC;Initial Catalog=Orange;Integrated Security=True";
        //cnn.Open();
        //cmd.CommandText = "select  slideimage from sliderimages ";
        //cmd.Connection = cnn;
        com.CommandText = "select logo from sitelogo";
        com.Connection = con;
        string name = (string)com.ExecuteScalar();
        s = "<img style='width:228px;height:98px;' src='Upload_images/Logo/" + name + "' alt='' title='' />";
        Logo.InnerHtml = s;

    }
}
