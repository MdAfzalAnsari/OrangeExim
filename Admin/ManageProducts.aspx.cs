using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_AddProducts : System.Web.UI.Page
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
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        if (!Page.IsPostBack)
        {
            Bindgrid();
        }
    }
    protected void GridViewgallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bindgrid();

    }

    private void Bindgrid()
    {        
        cmd.CommandText = "select * from product";
        cmd.Connection = cnn;
        da.SelectCommand = cmd;
        ds.Clear();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }
    //protected string bindcheck(string featured)
    //{
    //    //GridView1.ColumnsGenerator = "<asp:CheckBoxList ID='ProductSelector' runat='server' autopostback='true'><asp:ListItem Value='" + featured + "' ></asp:ListItem></asp:CheckBoxList>";
    //    string strhtml = "";
    //    strhtml = "<asp:CheckBox ID='ProductSelector' runat='server' ><asp:ListItem Value='" + featured + "' ></asp:ListItem></asp:CheckBox>";        
    //    return strhtml;
    //}
    protected string Imagebind(string product_id, string product_image, string product_name)
    {
        string strhtml = "";
        try
        {
            if (!string.IsNullOrEmpty(product_image))
            {
                string ImageName = product_image;
                string DirPath = Path.Combine("Upload_images", "product_images");
                DirPath = DirPath.Replace("\\", "/");

                if (File.Exists(Path.Combine(Server.MapPath(DirPath), ImageName)))
                {
                   
                    strhtml += "<td><div style='padding: 8px;'><img  src='" + DirPath + "/" + ImageName + "' alt='' class='grid_pro_image' /></td>";
                    strhtml += "<td><div class='productretrive'>" + product_name + "</a> </td></div></div>";
                    
                }
            }
        }
        catch(Exception ex)
        {
            return ex.ToString();
        }

        return strhtml;
    }
    protected void productdelete(object sender, GridViewCommandEventArgs e)
    {
        string product_id,prodel;
        if (e.CommandName == "Del")
        {
            product_id = e.CommandArgument.ToString();
            DB db = new DB();
            prodel = db.delproduct(product_id);
            int delete_id = Convert.ToInt32(prodel);
            if (delete_id > 0)
            {
                Response.Redirect("ManageProducts.aspx");
                statuslabel.Text = "Deletion Successful";
            }
            else
            {
                statuslabel.Text = "Deletion Failed";
            }
        }        
    }
    
    protected void setfeatured(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
           
            
                var chkStat = row.FindControl("chkview") as CheckBox;
                //Response.Write(chkStat.Text);
                //int index = row.RowIndex;  
                bool s = chkStat.Checked;
                //Response.Write(s);
                if (chkStat.Checked)
                {
                    var hide = row.FindControl("hide") as HiddenField;
                    string id = hide.Value;
                    //var link = row.FindControl("DeleteProduct") as LinkButton;
                    //Response.Write("TEXTT==" + hide.Value);
                    //DB db = new DB();
                    //db.updatefeature(id);
                    cmd.CommandText = "update product set featured=" + 1 + " where product_id=" + id;
                    cmd.Connection = cnn;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write("<br/>update product set featured=" + 1 + " where product_id=" + id);
                        Response.Write("no="+i);
                    }
                }
                if (!chkStat.Checked)
                {
                    var hide = row.FindControl("hide") as HiddenField;
                    string id = hide.Value;
                    cmd.CommandText = "update product set featured=" + 0 + " where product_id=" + id;
                    cmd.Connection = cnn;
                    int i = cmd.ExecuteNonQuery();
                    Response.Write("<br/>update product set featured=" + 0 + " where product_id=" + id);
                }

                
        }
        Response.Write("dout");
    }

    protected void chkview_CheckedChanged(object sender, EventArgs e)
    {
 
            CheckBox ch = (CheckBox)sender as CheckBox;
            if (ch.Checked)
            {
                GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
                int index = row.RowIndex;                
                HiddenField hidea = (HiddenField)GridView1.Rows[index].FindControl("hide");
                string id = hidea.Value;
                cmd.CommandText = "update product set featured=" + 1 + " where product_id=" + id;
                cmd.Connection = cnn;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("ManageProducts.aspx");
                }
                
            }
            if (!ch.Checked)
            {
                GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
                int index = row.RowIndex;                
                HiddenField hidea = (HiddenField)GridView1.Rows[index].FindControl("hide");
                string id = hidea.Value;
                cmd.CommandText = "update product set featured=" + 0 + " where product_id=" + id;
                cmd.Connection = cnn;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("ManageProducts.aspx");
                }
            }
      }
    
}