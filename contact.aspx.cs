using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using captcha;
using System.Configuration;

public partial class contact : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader,reader1,reader2;
    string name, emailid, phone1, message1;    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {

            Session["CaptchaImageText"] = CaptchaImageMgr.GenerateRandomCode();
            
        }
        loadgrid();

        

    }

    protected void loadgrid()
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        bindaddress();
        bindmobile();
        bindphone();
        bindemail();
        bindgooglelink();
            
    }

    private void bindgooglelink()
    {
        com.CommandText = "select google_link from admin_contact_us_detail";
        com.Connection = con;
        reader2 = com.ExecuteReader();
        if (reader2.HasRows)
        {
            reader2.Read();
            string glink = reader2.GetString(0);
            string link="<iframe class='mapp' width='960' height='240' frameborder='0' scrolling='no' marginheight='0'"+
               "marginwidth='0' src='"+glink+"'></iframe>";
            googlelink.HRef = glink;
            googleframe.InnerHtml = link;
            //emaillink.HRef = "mailto:" + mob;
           // adminemail.Text = mob;


        }
        reader2.Close();
    }

    private void bindemail()
    {
        com.CommandText = "select email from admin_contact_us_detail";
        com.Connection = con;
        reader2 = com.ExecuteReader();
        if (reader2.HasRows)
        {
            reader2.Read();
            string mob = reader2.GetString(0);            
            emaillink.HRef ="mailto:"+mob;
            adminemail.Text = mob;
            
            
        }
        reader2.Close();
    }

    private void bindphone()
    {
        com.CommandText = "select phone from admin_contact_us_detail";
        com.Connection = con;
        reader1 = com.ExecuteReader();
        if (reader1.HasRows)
        {
            reader1.Read();
            string mob = reader1.GetString(0);
            adminphone.Text = mob;
        }
        reader1.Close();
    }

    private void bindmobile()
    {
        com.CommandText = "select Mobile from admin_contact_us_detail";
        com.Connection = con;
        reader=com.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            string mob = reader.GetString(0);
            adminmobile.Text = mob;            
        }
        reader.Close();
    }

    private void bindaddress()
    {
        com.CommandText = "select address from admin_contact_us_detail";
        com.Connection = con;
        da.SelectCommand = com;
        ds.Clear();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();    
    }
    protected void btnSubmitCaptcha_Click(object sender, EventArgs e)
    {
        bool success = false;
        if (this.Session["CaptchaImageText"] != null)
        {
            //Match captcha text entered by user and the one stored in session
            if (Convert.ToString(this.Session["CaptchaImageText"]) == txtCaptchaText.Text.Trim())
            {
                success = true;
            }
        }       
        if (success)
        {
            insert_contact_data();

        }
        else
        {         
                      
                //Response.Redirect("contact.aspx");
                Session["CaptchaImageText"] = CaptchaImageMgr.GenerateRandomCode();
                //lblStatus.Visible = true;
                lblStatus.Text = "Please Try Again";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //loadgrid();
            
        }
    }

    private void insert_contact_data()
    {
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        com = new SqlCommand();
        com.Connection = con;
        name = author.Text.ToString();
        emailid = email_id.Text.ToString();
        message1 = text.InnerText;
        phone1 = mobile_no.Text.ToString();
        name.Trim();
        string sqlcommand="insert into contactus values('"+name+"','"+emailid+"','"+phone1+"','"+message1+"')";
        com.CommandText = sqlcommand;
        //da = new SqlDataAdapter(com);        
        //da.InsertCommand=com;
        com.ExecuteNonQuery();
        con.Close();
        Response.Redirect("contact.aspx");
    }

    
}
