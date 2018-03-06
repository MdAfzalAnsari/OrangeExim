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


public partial class Registration_detail : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand comm = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    string html = "", spanhtml, productcategory;
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        comm.Connection = cnn;
        cnn.Open();
    }
    protected void register(object sender, EventArgs e)
    {
        string firstname = First.Text;
        string lastname = Last.Text;
        string logid = loginemail.Text;
        string pass = New_Password.Text;
        comm.CommandText = "insert into customer_login(customer_id,password) values('" + logid + "','" + pass + "')";
        
        int loginsert=comm.ExecuteNonQuery();
        if (loginsert > 0)
        {
            comm.CommandText = "select customer_id from customer_login where customer_id='" + logid + "'";
            string logdata = (string)comm.ExecuteScalar();
            comm.CommandText = "insert into customer_details(customer_id,customer_name,customer_last_name) values('"+ logdata+"','" + firstname + "','" + lastname + "')";
            int customerdetails=comm.ExecuteNonQuery();
            if (customerdetails > 0)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}