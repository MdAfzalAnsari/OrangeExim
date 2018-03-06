using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Index : System.Web.UI.Page
{
    string username,password;
    Boolean valid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = (string)Session["admin_user"];
        if (val!= null)
        {
            Response.Redirect("Products.aspx");
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
        username = adminusername.Text.ToString();
        password = adminpassword.Text.ToString();
        
        valid=db.validatelogin(username, password);
        Response.Write("Not working=="+valid);
        if (valid)
        {
            Session["admin_user"] = adminusername.Text.ToString();
            Response.Redirect("Products.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx?status=failed");

        }
    }
}