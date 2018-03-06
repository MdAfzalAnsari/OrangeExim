using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Logic;
using System.Configuration;

public partial class Admin_Profile : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        Updatehead.Visible = false;
        string status = Request.QueryString["status"];
        string passstatus = Request.QueryString["changestatus"];        
        if (status != null)
        {
            statuslabel.Text = "Profile Updated Successfully";
            Updatehead.Visible = true;            
        }
        if (passstatus != null)
        {
            if (passstatus == "success")
            {
                statuslabel.Text = "Password Updated  Successfully";
                Updatehead.Visible = true;
            }
            else
            {                
                statuslabel.Text = "Password Updated Failed";
                Updatehead.Visible = true;
            }
        }
        if (!IsPostBack)
        {
            binddata();            
        }
    }

    private void binddata()
    {
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "select * from admin_contact_us_detail";
        cmd.Connection = cnn;
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            string address, mobile, phone, emailid, link;
            address=reader.GetString(1);
            mobile = reader.GetString(2);
            phone = reader.GetString(3);
            emailid = reader.GetString(4);
            link = reader.GetString(5);
            Email.Text = emailid;
            Phone.Text = phone;
            contentarea.InnerText = address;
            Mobile_No.Text = mobile;
            googlelink.Text = link;

        }
        reader.Close();
        cmd.CommandText = "select question from admin_login";
        cmd.Connection = cnn;
        string dataquestion = (string)cmd.ExecuteScalar();
        question.Text = dataquestion;
        
    }

    protected void update_Click(object sender, EventArgs e)
    {
        int i = 0;
        try
        {
          
            string email = Email.Text;
           // string contactno = contact.Text;
            string mobile = Mobile_No.Text;
            string phone = Phone.Text;
           // string pincode = Pincode.Text;
            //string city = City.Text;
            string address = contentarea.InnerText;
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
            cnn.Open();
            cmd.CommandText = "update admin_contact_us_detail set address='" + address + "',Mobile='" + mobile + "',phone='" + phone + "',email='" + email + "' where id=1";
            cmd.Connection = cnn;
            i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                //Response.Write("success");
                Response.Redirect("Profile.aspx?status=success");
            }
            else
            {
                Response.Write("fail" + i + address + mobile + phone);
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERRROROROR====" + ex.ToString());
        }
    }
    protected void update_logo(object sender, EventArgs e)
    {
        //Response.Write("IT shree");
        if (LogoUpload.HasFile)
        {
            DB db = new DB();
            string thumbimage = UploadImage(LogoUpload);
            string img = db.insert_logoname(thumbimage);
            Response.Redirect("Profile.aspx?status=success");

        }
    }

    private string UploadImage(FileUpload imageUpload1)
    {
        try
        {
            string logoname=LogoUpload.FileName;
            string DirPath = Path.Combine("Upload_images", "Logo");
            string FileName = imageUpload1.FileName.Substring(imageUpload1.FileName.LastIndexOf("."));

            FileName = logoname;
            

            CommonLogic.CreateDirectory(Server.MapPath(DirPath));
            imageUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath(DirPath), FileName));

            return FileName;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    protected void changepassword(object sender, EventArgs e)
    {
        string oldpass = Old_Password.Text;
        string newpass = New_Password.Text;
        DB db = new DB();
        string status = db.changepass(newpass, oldpass);
        Response.Write(status);
        if (status == "fail")
        {
            Response.Redirect("Profile.aspx?changestatus=" + status);
        }
        else
        {
            Response.Redirect("Profile.aspx?changestatus=" + status);
        }
    }
    protected void update_Catalog(object sender, EventArgs e)
    {
        if (CatalogUpload.HasFile)
        {
            DB db = new DB();
            string thumbimage = Uploadcatalog(CatalogUpload);
           // string img = db.insert_logoname(thumbimage);
           // Response.Write("Catalog Updated" + thumbimage);
            if (thumbimage != null)
            {
                
                string img = db.insert_catalog(thumbimage);
                if (img == "success")
                {
                    statuslabel.Text = "Catalog Updated";
                    Updatehead.Visible = true;
                }
                else
                {
                    statuslabel.Text = "Please Try Again";
                    Updatehead.Visible = true;
                }
            }
        }
    }
    private string Uploadcatalog(FileUpload catalogUpload)
    {
        try
        {
            string logoname = catalogUpload.FileName;
            string DirPath = Path.Combine("../files", "catalog");
            string FileName = catalogUpload.FileName.Substring(catalogUpload.FileName.LastIndexOf("."));            
            FileName = logoname;
            CommonLogic.CreateDirectory(Server.MapPath(DirPath));
            catalogUpload.PostedFile.SaveAs(Path.Combine(Server.MapPath(DirPath), FileName));
            return FileName;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
    protected void update_link(object sender, EventArgs e)
    {
        string link = googlelink.Text;
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "update admin_contact_us_detail set google_link='" + link + "' where id=1";
        cmd.Connection = cnn;
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            //Response.Write("success");
            Response.Redirect("Profile.aspx?status=success");
        }
    }
    protected void update_security(object sender, EventArgs e)
    {
        string que=question.Text;
        string ans=answer.Text;
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "update admin_login set question='" + que + "' , answer='" + ans + "'";
        cmd.Connection = cnn;
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            //Response.Write("success");
            Response.Redirect("Profile.aspx?status=success");
        }
    }
}