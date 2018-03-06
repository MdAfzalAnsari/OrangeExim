using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_AddCategory : System.Web.UI.Page
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
        //LoadGrid();
    }
    private void LoadGrid()
    {
        //DB db = new DB();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "select  * from category";
        cmd.Connection = cnn;
        da.SelectCommand = cmd;
        ds.Clear();
        da.Fill(ds);
        //categorygrid.DataSource = ds;
       // categorygrid.DataBind();          

    }
    protected void DeleteRow(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            cmd.CommandText = "delete from category where category_id='" + e.CommandArgument.ToString() + "'";
            cmd.Connection = cnn;
            da.DeleteCommand = cmd;

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    Response.Redirect("");
                    //Label1.Text = "No. rows Affected="+i;
                    //Response.Write("Deleted Successfully");
                }
            }
            catch (Exception e1)
            {
                Response.Write(e1.Message);
            }

        }

        if (e.CommandName == "Edit")
        {
            Response.Redirect("EditCategory.aspx?id=" + e.CommandArgument.ToString());
            //cmd.CommandText = "delete from category where category_id='" + e.CommandArgument.ToString() + "'";
            //cmd.Connection = cnn;
            //da.DeleteCommand = cmd;

            //try
            //{
            //    int i = cmd.ExecuteNonQuery();
            //    if (i != 0)
            //    {
            //        Response.Redirect("");
            //        //Label1.Text = "No. rows Affected="+i;
            //        //Response.Write("Deleted Successfully");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    Response.Write(e1.Message);
            //}

        }
    }
    

}