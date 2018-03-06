using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Admin_sliderImage : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    string slide;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();        
        slide = Request.QueryString["slide_id"];
        if (slide != null)
        {
            //SlideUpload.Visible = false;
            //slidefile.Visible = false;
            if (!IsPostBack)
            {
                cmd.CommandText = "select slide_head,slide_details from sliderimages where slide_id=" + slide;
                cmd.Connection = cnn;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string title = reader.GetString(0);
                    string details = reader.GetString(1);
                    s_title.Text = title;
                    sliderarea.InnerText = details;
                }
            }
        }
    }
    protected void update_slide(object sender, EventArgs e)
    {
        string title = s_title.Text;
        string details = sliderarea.InnerText;
        if (slide != null)
        {
            if (SlideUpload.HasFile)
            {
                string thumbimage = UploadImage(SlideUpload);
                if (thumbimage != null)
                {
                    DB db = new DB();
                    string s = db.Updateslide(thumbimage, title, details,slide);
                    if (s == "success")
                    {
                        Response.Redirect("ManageSlides.aspx?status=success");
                    }
                    else
                    {

                    }
                }
            }
        }
        else
        {
            if (SlideUpload.HasFile)
            {                
                string thumbimage = UploadImage(SlideUpload);
                if (thumbimage != null)
                {
                    DB db = new DB();
                    string s = db.insertslide(thumbimage, title, details);
                    if (s == "success")
                    {
                        Response.Redirect("ManageSlides.aspx?status=success");
                    }
                    else
                    {

                    }
                }
            }
        }
       
    }

    private string UploadImage(FileUpload SlideUpload)
    {
        try
        {
            string logoname = SlideUpload.FileName;
            string DirPath = Path.Combine("Upload_images", "SliderImages");
            string FileName = SlideUpload.FileName.Substring(SlideUpload.FileName.LastIndexOf("."));
            FileName = logoname;
            CommonLogic.CreateDirectory(Server.MapPath(DirPath));
            SlideUpload.PostedFile.SaveAs(Path.Combine(Server.MapPath(DirPath), FileName));

            return FileName;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
        
    }
}