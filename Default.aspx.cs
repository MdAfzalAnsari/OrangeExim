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

using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader,reader1;
    string html, spanhtml;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
            cnn.Open();
            cmd.CommandText = "select  slideimage,slide_head,slide_details from sliderimages ";
            cmd.Connection = cnn;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    html = bindslides();
                    ulslide.InnerHtml += html;
                }
            }
            reader.Close();
        
                Bindthumb1();
                Bindthumb2();
                Bindthumb3();
                bindthumblink();
                bindinfo();
                bindlink();
                bindscroller();
                bindphotogallery();

        }

    }

    private void bindthumblink()
    {
        string link;
        int i = 0;
        cmd.CommandText = "select TOP 3 thumb_category from thumbIcon";
        cmd.Connection = cnn;
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                link = reader.GetString(0);
                if (i == 0)
                {
                    gallerylink0.NavigateUrl = "gallery.aspx?cat=" + link;
                }
                if (i == 1)
                {
                    gallerylink1.NavigateUrl = "gallery.aspx?cat=" + link;
                }
                if (i == 2)
                {
                    gallerylink2.NavigateUrl = "gallery.aspx?cat=" + link;
                }
                i++;                
            }
            reader.Close();
        }
    }

    private void bindphotogallery()
    {
        string link, pro_name;
        cmd.CommandText = "select TOP 9 product_image,product_name from product where featured=1 ";
        cmd.Connection = cnn;
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                link = reader.GetString(0);
                pro_name = reader.GetString(1);
                footer_feature.InnerHtml += "<li><a href='Admin/Upload_images/product_images/" + link + "'  rel='lightbox[portfolio]'><img src='Admin/Upload_images/product_images/" + link + "' alt='" + pro_name + "' class='feature'/></a></li>";
            }
        }
        reader.Close();
        
    }

    private void bindscroller()
    {
        string link;
        cmd.CommandText = "select scrollerimage from scroller";
        cmd.Connection = cnn;
        reader=cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                link=reader.GetString(0);
                carousel.InnerHtml += "<li><img class='imgslide' src='scrollerimage/" + link + "' alt=''/></li>";
            }
        }
        reader.Close();
    }

    private void bindlink()
    {
        string link;
        cmd.CommandText = "select link from youlink where id=1";
        cmd.Connection = cnn;
        link = (string)cmd.ExecuteScalar();
        if (link != null)
        {
            youtubelink.InnerHtml += "<iframe class='frame' width='450' height='245' src='" + link + "?wmode=opaque' frameborder='' allowfullscreen='true'></iframe>";
        }

    }

    private void bindinfo()
    {
        string para;
        cmd.CommandText = "select homeabout from com_info where id=1";
        cmd.Connection = cnn;
        para=(string)cmd.ExecuteScalar();        
        int count=para.Length;
        string homepara;
        if (count < 950)
        {
            homepara = para;
        }
        else
        {
            homepara = para.Substring(0, 950);
        }
        
        
        if (count > 950)
        {
            homepara = homepara + "...........";
            com_info.InnerText = homepara;            
            readpara.Visible = true;
            //com_info.InnerHtml += "<a href='' class='more1' style='font-size:10px;float:right' id='read' runat='server' onclick='"+showdata()+"'>Read more</a>";            
            
        }
        else
        {
            readpara.Visible = false;
            com_info.InnerText = homepara;     
            //Response.Write(count);
            
        }
        //reader.Close();
    }

    //private string showdata()
    //{
       
    //    //string winFeatures = "toolbar=no,status=no,menubar=no,location=center,scrollbars=no,resizable=no,height=500,width=657";
    // //   return "";
    //}

    private void Bindthumb1()
    {
        string thumbimage,thumbname,desc;
        cmd.CommandText = "select * from thumbIcon where id=1";
        cmd.Connection = cnn;
        reader1 = cmd.ExecuteReader();
        if (reader1.HasRows)
        {
            reader1.Read();
            thumbimage = reader1.GetString(3);
            thumbname = reader1.GetString(1);
            desc = reader1.GetString(2);
             thumb_para.InnerHtml = desc;
             thumbs.InnerHtml += "<span class='clip' style='background-image: url(images/HomeThumbImages/" + thumbimage + ");'></span>" +
                             "<h4 style='text-align:center;'><strong class='Prodhead'>" + thumbname + "</strong><br/></h4>";

        }
        reader1.Close();
        
    }
    private void Bindthumb2()
    {
        string thumbimage, thumbname, desc;
        cmd.CommandText = "select * from thumbIcon where id=2";
        cmd.Connection = cnn;
        reader1 = cmd.ExecuteReader();
        if (reader1.HasRows)
        {
            reader1.Read();
            thumbimage = reader1.GetString(3);
            thumbname = reader1.GetString(1);
            desc = reader1.GetString(2);
            thumb_para2.InnerHtml = desc;
            thumbs2.InnerHtml += "<span class='clip' style='background-image: url(images/HomeThumbImages/" + thumbimage + ");'></span>" +
                            "<h4 style='text-align:center;'><strong class='Prodhead'>" + thumbname + "</strong><br/></h4>";

        }
        reader1.Close();


    }
    private void Bindthumb3()
    {
        string thumbimage, thumbname, desc;
        cmd.CommandText = "select * from thumbIcon where id=3";
        cmd.Connection = cnn;
        reader1 = cmd.ExecuteReader();
        if (reader1.HasRows)
        {
            reader1.Read();
            thumbimage = reader1.GetString(3);
            thumbname = reader1.GetString(1);
            desc = reader1.GetString(2);
            thumb_para3.InnerHtml = desc;
            thumbs3.InnerHtml += "<span class='clip' style='background-image: url(images/HomeThumbImages/" + thumbimage + ");'></span>" +
                            "<h4 style='text-align:center;'><strong class='Prodhead'>" + thumbname + "</strong><br/></h4>";

        }
        reader1.Close();

    }

    private string bindslides()
    {
        try
        {
            //imagelink.HRef = "Admin/Upload_images/"+reader.GetString(1);
           // string src = "Admin/Upload_images/product_images/" + reader.GetString(1);
            string sliderimage = reader.GetString(0);
            string title = reader.GetString(1);
            string details = reader.GetString(2);
            // Response.Write("Here"+src);

            html = "<li><img class='slideimg' src='Admin/Upload_images/SliderImages/" + sliderimage + "' alt='' title='' />" + "<div class='slide-desc'><h2>" + title + "</h2><p>" + details + "</p></div></li>";
            return html;

        }
        catch (Exception ex)
        {
            return "Error ===" + ex.ToString();
        }
    }
    protected void showdata(object sender, EventArgs e)
    {
        //string winFeatures = "toolbar=no,status=no,menubar=no,location=center,scrollbars=no,resizable=no,height=500,width=657";
        //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "about.aspx?id=1", winFeatures));
        Response.Redirect("about.aspx?id=1");
    }
}
