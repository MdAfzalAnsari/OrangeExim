using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Logic;
using System.IO;

public partial class Admin_Addcategory : System.Web.UI.Page
{
    private string thumbimage = null;
    private int cat_id;
    int i, keyID=0 ;
    string category_id, cat_img, catdel;
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
        string catname = Request.QueryString["catname"];
        keyID = Convert.ToInt32(Request.QueryString["catid"]);
        if (catname != null)
        {
            if (!IsPostBack)
            {
                 category_name.Text = catname.ToString();
            }
        }
    }
    protected void Save_category(object sender, EventArgs e)
    {
        DB db = new DB();
        string category = category_name.Text;
        if (keyID > 0)
        {
            //write Code to Update
          category_id = db.updatecategory(category,keyID);
          if (category_id == "success")
          {
              if (imageUpload1.HasFile)
              {

                  string thumbimage = UploadImage(imageUpload1, true,keyID);
                  cat_img = db.insert_imagename(thumbimage, keyID);
                  //Response.Write("IMage Updated");

              }
              status.Text = "Category Updated Successfully";
          }
          else
          {
              status.Text = "Updated Failed";
          }
        }
        else
        {
            try
            {
                category_id = db.insertcategory(category);
                cat_id = Convert.ToInt32(category_id);
                //Response.Write("Inserted==" + cat_id);
                if (cat_id > 0)
                {

                    if (imageUpload1.HasFile)
                    {
                        string thumbimage = UploadImage(imageUpload1, true);
                        cat_img = db.insert_imagename(thumbimage, cat_id);
                        Response.Write("Inse==" + thumbimage +"catid="+cat_id);
                        status.Text = "Category Added Succesfully";

                    }
                }
                //else
                {
                    //Response.Redirect("Addcategory.aspx");
                }
            }
            catch (Exception ex)
            {
                //Response.Write("Inserted==" + cat_id + ex.ToString());
            }
        }
        

    }

    private string UploadImage(FileUpload imageUpload1, bool p, int keyID)
    {
        try
        {
            string DirPath = Path.Combine("Upload_images", "category_images");
            string FileName = imageUpload1.FileName.Substring(imageUpload1.FileName.LastIndexOf("."));
            if (p)
                FileName = keyID + "_t" + FileName;
            else
                FileName = keyID + "_z" + FileName;

            CommonLogic.CreateDirectory(Server.MapPath(DirPath));
            imageUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath(DirPath), FileName));

            return FileName;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    private string UploadImage(FileUpload imageUpload1, bool p)
    {
        string DirPath = "", FileName="";
        try
        {
            DirPath = Path.Combine("Upload_images","category_images");
            //DirPath = DirPath.Replace("\\", "/");
            FileName = imageUpload1.FileName.Substring(imageUpload1.FileName.LastIndexOf("."));
            if (p)
                FileName = cat_id + "_t" + FileName;
            else
                FileName = cat_id + "_z" + FileName;

            CommonLogic.CreateDirectory(Server.MapPath(DirPath));
            imageUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath(DirPath), FileName));

            return FileName;
        }
        catch (Exception ex)
        {
            return "path=" + Server.MapPath(DirPath) + "name=" + FileName;
        }
    }
}