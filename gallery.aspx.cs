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

public partial class gallery : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand comm = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader1;    
    string html="", spanhtml,productcategory;   
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {        
        //string value = (string)Session["admin_user"];
        //if (value == "" || value == null)
        //{
        //    Response.Redirect("login.aspx");
        //}
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        productcategory = Request.QueryString["cat"];
        if (productcategory == null)
        {

            cnn.Open();
            comm.CommandText = "select category_name from category";
            comm.Connection = cnn;
            string val = (string)comm.ExecuteScalar();
            productcategory = val;

        }
        else
        {
            cnn.Open();
            comm.CommandText = "select category_name from category where category_name='"+productcategory+"'";
            comm.Connection = cnn;
            string val = (string)comm.ExecuteScalar();
            if (val == null)
            {
                Response.Redirect("gallery.aspx");
            }
            Page.Title = productcategory;
        }
        Bindgrid();
        //GenerateRandomCode();
        cartadd.Visible = false;
        string note = (string)Session["notice"];
        if (note != null && note == "getnote")
        {
            //DateTime s=System.DateTime.Now;
            //int i1=s.Second;
            //DateTime newtime = s.AddSeconds(5);
            //for (int i = 0; i < 5; i++)
            //{
            //    //System.Threading.Thread.Sleep(4000);
            //    cartadd.InnerHtml += s;
                cartadd.Visible = true;
            //}
            //cartadd.Visible = false;          
            Session.Remove("notice");
        }
    }

    private void Bindgrid()
    {                
        comm.CommandText = "select  product_name,product_image,product_code,product_price from product where product_type='"+productcategory+"'";
        comm.Connection = cnn;
        da.SelectCommand = comm;
        ds.Clear();
        da.Fill(ds);
        GridViewgallery.DataSource = ds;
        GridViewgallery.DataBind();
        string head = "<h2 class='abh'><span style='margin-left:25px;' >" + productcategory + "<span>";
        product_type.InnerHtml = head;

    }
    protected string binddata(string pro_name,string pro_img)
    {
        int i = 0;
        string product2="";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        comm.CommandText = "select  product_name,product_image,product_price from product where product_type='" + productcategory + "' AND product_name='" + pro_name + "'";        
        comm.Connection = con;
        reader1 = comm.ExecuteReader();
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {                
                html = loadproduct();
                product2 += html;                                
            }
        }
        return product2;
    }

    protected void GridViewgallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewgallery.PageIndex = e.NewPageIndex;        
            Bindgrid();
        
    }

    protected string loadproduct()
    {
        try
        {            
            string src = "Admin/Upload_images/product_images/" + reader1.GetString(1);
            string productname = reader1.GetString(0);
            string price = reader1.GetString(2);
            html = "<div class='img_frame img_frame_15 img_nom' id='productimage' runat='server'><span></span>";
            html += "<a id='imagelink' runat='server' href='" + src + "' rel='lightbox[new_gallery]'><img src='" + src + "' alt='Gallery Item 1' id='imagesrc' runat='server'/></a>";            
            html += "<div ><span><h3 class='app'>" + productname + "</h3></span><span class='pricetag'>"+price+"Rs</span>"+
                    "</div></div>";
            return html;
        }
        catch (Exception ex)
        {
            return "Error ===" + ex.ToString();
        }
    }
    public string bindcart()
    {
        string[] strArray = new string[36];
        strArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random Random = new Random();
        string Code = "";
        for (int i = 0; i < 15; i++)
        {
            int j = Convert.ToInt32(Random.Next(0, 62));
            Code += strArray[j].ToString();
        }
        return Code;
        //cartkey.Value = Code;          
        //HiddenField cartkey = (HiddenField)Page.FindControl("cartkey");
                
    }
    public string bindurl()
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        return url;
    }
}
