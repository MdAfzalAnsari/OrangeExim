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
using System.Configuration;

public partial class Admin_home : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    string catagory="", pro_img, productid;
    int cat_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == ""||val==null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            //catagory = (string)Request.QueryString["catagory"];
            productid = (string)Request.QueryString["productid"];
            bindproductdata();
        }
        statuslabel.Visible = false;
    }

    private void bindproductdata()
    {
        string name, code, db_p_price;
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText ="select product_name,product_type,product_code,product_price From product where product_id='"+productid+"';";
        cmd.Connection = cnn;
        reader=cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                name = reader.GetString(0);
                catagory = reader.GetString(1);
                code = reader.GetString(2);
                db_p_price = reader.GetString(3);
                if (!IsPostBack)
                {
                     product_name.Text = name;
                     product_code.Text = code;
                     DropDownList1.SelectedValue = catagory;
                     propricee.Text = db_p_price;
                }
            }
            //Response.Write("categ==" + catagory);
            //DropDownList1.SelectedValue = "'"+catagory+"'";
        }
        //
        ////DropDownList1.Text = catagory;
        //
        //DropDownList1.Text = catagory.ToString();
    }
    protected void SaveData(object sender, EventArgs e)
    {
        string productname = product_name.Text.ToString();
        string productcode = product_code.Text.ToString();
        string productprice = propricee.Text.ToString();
        DB db = new DB();
        
            catagory = DropDownList1.SelectedValue;
        
        if (productid == null)
        {

            string value = db.addData(productname, catagory, productcode, productprice);
            cat_id = Convert.ToInt32(value);           
            if (cat_id > 0)
            {
                if (UploadProImage.HasFile)
                {
                    string thumbimage = UploadImage(UploadProImage, true);
                    pro_img = db.insert_proimagename(thumbimage, cat_id);
                }
                statuslabel.Visible = true;
                statuslabel.Text = "Inserted Succesfully";
            }
            else
            {
                //Response.Write("Error=="+value);
            }
        }
        else
        {
            int keyID = Convert.ToInt32(productid);
            string value = db.EditProductData(productname, catagory, productcode, keyID, productprice);
            if (value == "success")
            {
                if (UploadProImage.HasFile)
                {                    
                    string thumbimage = UploadImage(UploadProImage, true, keyID);
                    pro_img = db.insert_proimagename(thumbimage, keyID);
                }
                statuslabel.Visible = true;
                statuslabel.Text = "Product Updated Succesfully" + catagory;
            }
            else
            {

            }
        }
    }

    private string UploadImage(FileUpload imageUpload1, bool p)
    {
        try
        {
            string DirPath = Path.Combine("Upload_images", "product_images");
            string FileName = imageUpload1.FileName.Substring(imageUpload1.FileName.LastIndexOf("."));
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
            return "";
        }
    }
    private string UploadImage(FileUpload imageUpload1, bool p, int keyID)
    {
        try
        {
            string DirPath = Path.Combine("Upload_images", "product_images");
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
}