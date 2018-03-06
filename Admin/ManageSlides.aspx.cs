using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_ManageSlides : System.Web.UI.Page
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
        cmd.CommandText = "select * from sliderimages";
        cmd.Connection = cnn;
        da.SelectCommand = cmd;
        ds.Clear();
        da.Fill(ds);
        Slidergrid.DataSource = ds;
        Slidergrid.DataBind();
        string status = Request.QueryString["status"];
        if (status == "deleted")
        {
            statuslabel.Text = "Slide Deleted Succesfully";
        }
        else if (status == "success")
        {
            statuslabel.Text = "Slide Added Succesfully";
        }
    }
    protected string Imagebind(string slide_id, string slide_image)
    {
        string strhtml = "";
        try
        {
            if (!string.IsNullOrEmpty(slide_image))
            {
                string ImageName = slide_image;
                string DirPath = Path.Combine("Upload_images", "SliderImages");
                DirPath = DirPath.Replace("\\", "/");

                if (File.Exists(Path.Combine(Server.MapPath(DirPath), ImageName)))
                {
                    // strhtml = "<td align='left' valign='top' style='width:12%;'>";
                    strhtml += "<td><div style='padding: 8px;'><img src='" + DirPath + "/" + ImageName + "' alt='' class='grid_slide_image'   /></td>";
                    strhtml += "<td><div class='productretrive'>" + slide_image + "</a> </td></div></div>";
                    //strhtml += "<div class='clear h20'></div>";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }

        return strhtml;
    }
    protected void slidedelete(object sender, GridViewCommandEventArgs e)
    {
        string slide_id, prodel;
        if (e.CommandName == "Del")
        {
            slide_id = e.CommandArgument.ToString();
            DB db = new DB();
            prodel = db.delslide(slide_id);
            int delete_id = Convert.ToInt32(prodel);
            if (delete_id > 0)
            {
                //statuslabel.Text = "Deltetion Successful";
                Response.Redirect("ManageSlides.aspx?status=deleted");
            }
            else
            {

            }
        }
    }
}