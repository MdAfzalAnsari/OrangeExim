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
public partial class Parts : System.Web.UI.Page
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
        cnn.ConnectionString = "Data Source=GLOBELERA-PC;Initial Catalog=Orange;Integrated Security=True";
        cnn.Open();
        cmd.CommandText = "select  product_name,product_image,product_code from product where product_type='Parts'";
        cmd.Connection = cnn;
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                html = loadproduct();
                product.InnerHtml += html;
            }
        }


    }

    protected string loadproduct()
    {
        try
        {
            //imagelink.HRef = "Admin/Upload_images/"+reader.GetString(1);
            string src = "Admin/Upload_images/product_images/" + reader.GetString(1);
            string productname = reader.GetString(0);
            // Response.Write("Here"+src);
            html = "<div class='img_frame img_frame_15 img_nom' id='productimage' runat='server'><span></span>";
            html += "<a id='imagelink' runat='server' href='" + src + "' rel='lightbox[new_gallery]'><img src='" + src + "' alt='Gallery Item 1' id='imagesrc' runat='server'/></a>";
            //imagesrc.Src = "Admin/Upload_images/" + reader.GetString(1);
            html += "<div ><span><a href='#'><h3 class='app'>" + productname + "</h3></a></span></div></div>";
            return html;

        }
        catch (Exception ex)
        {
            return "Error ===" + ex.ToString();
        }
    }
}
