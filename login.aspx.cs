using System;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;


public partial class login : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand comm = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader1;    
    string username,password;
    Boolean valid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["cust_user"];
        if (val!= null)
        {
            Response.Redirect("Default.aspx");
        }
        currentstate.Visible = false;
        string status=Request.QueryString["status"];
        if (status != null && status =="failed")
        {
            currentstate.Visible = true;
            currentstate.Text = "Wrong Password OR UserName";
        }
    }
    protected void sub_btn_Click(object sender, EventArgs e)
    {        
        DB db = new DB();
        username = cust_username.Text.ToString();
        password = cust_password.Text.ToString();
        
        valid=db.validatecust_login(username, password);
        //Response.Write("Not working=="+valid);
        if (valid)
        {
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
            comm.Connection = cnn;
            cnn.Open();
            comm.CommandText = "select cid from customer_login where customer_id='" + username + "'";
            int cid=(int)comm.ExecuteScalar();
            Session["cust_user"] = cust_username.Text.ToString();
            Session["cust_id"] = cid.ToString();            
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("login.aspx?status=failed");
        }
    }
}
