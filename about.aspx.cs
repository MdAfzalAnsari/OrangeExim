using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Logic;
using System.Data.SqlClient;

public partial class about : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    string html, spanhtml;
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
                cnn.Open();
                cmd.CommandText = "select homeabout from com_info";
                cmd.Connection = cnn;
                string data = (string)cmd.ExecuteScalar();
                html = "<div class='leftone'><h4 class='lefthead'><span class='text_head'>" + "About Us" + "</span></h4><p class='p_left'>" + data + "</p><div class='clearer'></div></div>";
                templatemo_main.InnerHtml += html;
            }
            else
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
                cnn.Open();
                cmd.CommandText = "select  Abouthead,About from about_us";
                cmd.Connection = cnn;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        html = loadproduct();
                        templatemo_main.InnerHtml += html;
                    }
                }
            }
        }
    }
    protected string loadproduct()
    {
        try
        {
            //imagelink.HRef = "Admin/Upload_images/"+reader.GetString(1);
            string abhead = reader.GetString(0);
            string aboutdetail = reader.GetString(1);
            // Response.Write("Here"+src);
        //    <h4 class="lefthead"><span class="text_head">THE COMPANY</span></h4>
        //<p class="p_left">
        //</p>
        //<div class="clearer"></div>
            html = "<div class='leftone'><h4 class='lefthead'><span class='text_head'>" + abhead + "</span></h4><p class='p_left'>" + aboutdetail + "</p><div class='clearer'></div></div>";
            
            //imagesrc.Src = "Admin/Upload_images/" + reader.GetString(1);
            //html += "";
            return html;

        }
        catch (Exception ex)
        {
            return "Error ===" + ex.ToString();
        }
    }
}
