using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_PageSetting : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    string product_id, aboutdel;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val == "" || val == null)
        {
            Response.Redirect("Default.aspx");
        }
        string query = Request.QueryString["success"];
        if (query != null)
        {
            statuslabel.Text = "Updated Successfully";
        }
    }
    protected void deleteabout(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            product_id = e.CommandArgument.ToString();
            DB db = new DB();
            aboutdel = db.delabtcategory(product_id);
            int delete_id = Convert.ToInt32(aboutdel);
            if (delete_id > 0)
            {
                Response.Redirect("AboutPageSetting.aspx");
            }
            else
            {

            }
        }
    }
}