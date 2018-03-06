using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Logic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Addcategory : System.Web.UI.Page
{
   private string thumbimage=null;
   private int  cat_id;
   int i;
   string category_id,cat_img,catdel;
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
        cmd.CommandText = "select  * from category";
        cmd.Connection = cnn;
        da.SelectCommand = cmd;
        ds.Clear();
        da.Fill(ds);
        if (!IsPostBack)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
    protected void Deletecategory(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            category_id = e.CommandArgument.ToString();
            DB db = new DB();
            catdel=db.delcategory(category_id);
            int delete_id=Convert.ToInt32(catdel);
            if (delete_id > 0)
            {
                Response.Redirect("ManageCategory.aspx");
            }
            else
            {

            }
        }
        //if (e.CommandName == "Edit")
        //{
        //    category_id = e.CommandArgument.ToString();
        //    DB db = new DB();
        //    string catdetail = db.getcategorydetails(category_id);
            
        //    if (catdel=="success")
        //    {
        //        Dbean dbn = new Dbean();
        //        string catname = dbn.categoryname;
        //        //string catname = db.categoryname;
        //        Response.Redirect("Addcategory.aspx?catname=" + catname);

        //    }
        //    else
        //    {

        //    }
        //}
    }
    protected string Imagebind(string category_id, string category_image, string category_name)
    {
        string strhtml = "";
        try
        {
            if (!string.IsNullOrEmpty(category_image))
            {
                string ImageName = category_image;
                string DirPath = Path.Combine("Upload_images", "category_images");
                DirPath = DirPath.Replace("\\", "/");

                if (File.Exists(Path.Combine(Server.MapPath(DirPath), ImageName)))
                {
                    // strhtml = "<td align='left' valign='top' style='width:12%;'>";AddProductDetails.aspx?category=" + category_name + "
                    strhtml += "<td><div style='padding: 8px;'><img src='" + DirPath + "/" + ImageName + "' alt='' class='grid_pro_image'  /></td>";
                    strhtml += "<td><div style='margin-left:10px;' class='productretrive'>" + category_name + "</td></div></div>";
                   // strhtml += "<div class='clear h20'></div>";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }

        return strhtml;
    }  
    
}