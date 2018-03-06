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
public partial class Admin_ClientRequest : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    string contactid,id,state;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        Updatehead.Visible =false;
        state=Request.QueryString["status"];
        if(state!=null && state=="deleted" && state != "")
        {
            Updatehead.Visible = true;
            statuslabel.Text="Request Deleted Successfully";
        }
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "select  * from contactus";
        cmd.Connection = cnn;
        da.SelectCommand = cmd;
        ds.Clear();
        da.Fill(ds);
        if (!IsPostBack)
        {
            client.DataSource = ds;
            client.DataBind();
            
        }
    }
    protected void Deletecategory(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            contactid = e.CommandArgument.ToString();
            if (contactid != null)
            {
                cmd.CommandText = "delete  from contactus where contact_id="+contactid;
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("ClientRequest.aspx?status=deleted");
                }

            }
            
        }
    }
}