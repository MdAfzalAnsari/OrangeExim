using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using beans;
public partial class Admin_manageaboutpage : System.Web.UI.Page
{
    string id;
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
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        id = Request.QueryString["id"];
        int about_id = Convert.ToInt32(id);
        if (id != null)
        {            
            cmd.CommandText = "select  * from about_us where about_id="+about_id;
            cmd.Connection = cnn;
            reader=cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string abouthead = reader.GetString(1);
                string aboutdesc = reader.GetString(2);
                if (!IsPostBack) 
                {
                    About_Heading.Text = abouthead;
                    Description.InnerText = aboutdesc;
                }
                
            }
        }
    }
    protected void  updatedata(object sender, EventArgs e)
    {
       Addnewdata(sender,e);
    }
    protected void  Addnewdata(object sender, EventArgs e)
    {
        //Dbean dbn = new Dbean();
        //dbn.abouthead = About_Heading.Text;
        //dbn.about = Description.InnerText;
        string val;
        string abouthead = About_Heading.Text;
        string desc = Description.InnerText;
        DB db = new DB();
        val=db.addaboutdata(abouthead,desc,id);
        Response.Redirect("AboutPageSetting.aspx?success=true");                    
    }    
}