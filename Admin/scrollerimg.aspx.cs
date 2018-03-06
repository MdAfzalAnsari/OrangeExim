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

public partial class Admin_scrollerimg : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();        
    }
    protected void update_scroller(object sender, EventArgs e)
    {
        if (ScrollerUpload.HasFile)
        {
            string thumbimage = UploadImage(ScrollerUpload);
            if (thumbimage != null)
            {
                
                
                cmd.CommandText = "insert into scroller values ('" + thumbimage + "')";
                cmd.Connection = cnn;
                int s = cmd.ExecuteNonQuery();
                if (s > 0)
                {
                    Response.Redirect("HomeFooterscroller.aspx");
                }
                else
                {

                }
            }
        }
    }
    private string UploadImage(FileUpload SlideUpload)
    {
        try
        {
            string logoname = SlideUpload.FileName;
            string DirPath = Path.Combine("../", "scrollerimage");
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