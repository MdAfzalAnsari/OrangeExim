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
using Logic;


public partial class Admin_managethumbdetail : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    string thumb_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        Updatehead.Visible = false;
        thumb_id = Request.QueryString["id"];
        //int t_id=Convert.ToInt32(thumb_id);
        if (thumb_id == null)
        {
            Response.Redirect("HomeThumbContent.aspx");
        }        
        else
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
            con.Open();
            com.CommandText = "select * from thumbIcon where id=" + thumb_id;
            com.Connection = con;
            reader=com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (!IsPostBack)
                {
                    string name = reader.GetString(1);
                    string descrip = reader.GetString(2);
                    Thumb_name.Text = name;
                    Description.InnerText = descrip;
                }
            }
            else
            {
                Response.Redirect("HomeThumbContent.aspx");
            }
            reader.Close();
        }
    }
    protected void EditThumb(object sender, EventArgs e)
    {
        string thumbname="", thumbdesc="", thumb_category="";
        //if (!IsPostBack)
        {
             thumbname = Thumb_name.Text;
             thumbdesc = Description.InnerText;
             thumb_category = DropDownList1.SelectedValue;
        }
        DB db = new DB();
        string i = db.updatethumb(thumbname, thumbdesc, thumb_id, thumb_category);
        if (i == "success")
        {
            if (thumbimageupload.HasFile)
            {

                string thumbimage = UploadImage(thumbimageupload, thumb_id);
                string img = db.update_thumbimage(thumbimage,thumb_id);
               // Response.Write("IMage Updated" + img+thumbimage);
                Updatehead.Visible = true;
                statuslabel.Text = "Updated Successfully";
            }
        }
    }

    private string UploadImage(FileUpload thumbimageupload,string thumb_id)
    {
        try
        {
            string logoname = thumbimageupload.FileName;
            string DirPath = Path.Combine("../images", "HomeThumbImages");
            string FileName = thumbimageupload.FileName.Substring(thumbimageupload.FileName.LastIndexOf("."));

            FileName = thumb_id + FileName;


            CommonLogic.CreateDirectory(Server.MapPath(DirPath));
            thumbimageupload.PostedFile.SaveAs(Path.Combine(Server.MapPath(DirPath), FileName));

            return FileName;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
}