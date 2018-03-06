using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_ManageSubscription : System.Web.UI.Page
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
        string status = Request.QueryString["status"];
        if (status == null || status != "success")
        {
            Updatehead.Visible = false;

        }
        if (status != null && status == "success")
        {
            Updatehead.Visible = true;
            statuslabel.Text = "Succesfully Unsubscribed";
        }

        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        Bindgrid();
    }

    private void Bindgrid()
    {
        cmd.CommandText = "select * from  NewsLetter_subscription";
        cmd.Connection = cnn;
        da.SelectCommand = cmd;
        ds.Clear();
        da.Fill(ds);
        subscription1.DataSource = ds;
        subscription1.DataBind();
    }
    protected void GridViewgallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        subscription1.PageIndex = e.NewPageIndex;
        Bindgrid();

    }
    protected void Unsubscribe(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "Del")
        {
            cmd.CommandText = "delete from  NewsLetter_subscription where subscribe_id="+e.CommandArgument.ToString();
            cmd.Connection = cnn;
            int delete_id = cmd.ExecuteNonQuery();
            if (delete_id > 0)
            {
                statuslabel.Text = "Deletion Successful";
                Response.Redirect("ManageSubscription.aspx?status=success");
            }
            else
            {
                Response.Redirect("ManageSubscription.aspx?status=fail");
            }
        }
    }
}