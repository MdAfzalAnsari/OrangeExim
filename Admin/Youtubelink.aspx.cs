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

public partial class Admin_Youtubelink : System.Web.UI.Page
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
        Updatehead.Visible = false;
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "select link from youlink where id=1";
        cmd.Connection = cnn;
        string postlink = (string)cmd.ExecuteScalar();
        if (!IsPostBack)
        {
            youlink.Text = postlink;
        }
    }
    protected void update_link(object sender, EventArgs e)
    {
        string addedlink = youlink.Text;
        //cnn.ConnectionString = "Data Source=GLOBELERA-PC;Initial Catalog=Orange;Integrated Security=True";
        //cnn.Open();
        cmd.CommandText = "update youlink set link='" + addedlink + "' where id=1";
        cmd.Connection = cnn;
        int i=cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Updatehead.Visible = true;
            statuslabel.Text = "Link Updated Succesfully";
        }        
    }
}