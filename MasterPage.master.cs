using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;



public partial class MasterPage : System.Web.UI.MasterPage
{
    static int tval;
    static int cartid1, oldval;
    string text_qty_val = "";
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    LinkButton lbtnDelete, changeqty, save;
    HtmlAnchor qtylink1;
    HyperLink qtylink;
    HiddenField hide, tvalue;
    //HtmlInputText textbox;
    TextBox textbox1;
    //UpdatePanel Mycart;
    AsyncPostBackTrigger at;
    SqlDataReader reader, reader1, reader2, reader4, readercatalog;
    string html, product = "", cid, sessionid;
    int qty = 0;
    int price = 0;
    int cartid = 0;
    ScriptManager currentScriptManager;
    protected void Page_Init(object sender, EventArgs e)
    {

        //Mycart3.Update();
        Mycart3.ContentTemplateContainer.EnableViewState = true;
        currentScriptManager = System.Web.UI.ScriptManager.GetCurrent(this.Page);
        //Mycart2.Controls.Clear();
        // Mycart = new UpdatePanel();
        // Mycart.ID = "updatee";
        // Mycart.Attributes.Add("runat", "server");
        // Mycart.UpdateMode = UpdatePanelUpdateMode.Conditional;
        cid = (string)Session["cust_id"];
        sessionid = Session.SessionID;
        SqlCommand co1 = new SqlCommand();
        SqlConnection con1 = new SqlConnection();
        con1.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        //con1.ConnectionString = "Data Source=GLOBELERA-PC;Initial Catalog=Orange;Integrated Security=True";
        con1.Open();
        co1.CommandText = "select item_name,qty,item_price,cart_id from [cart] where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND payment_status='Pending'";
        co1.Connection = con1;
        int i = 0, j = 0;
        string data = "";
        HtmlGenericControl ul ;
        reader = co1.ExecuteReader();
        //if (!IsPostBack)
        {
            if (reader.HasRows)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.ID = "dynamiccart";
                while (reader.Read())
                {
                    cartid = reader.GetInt32(3);
                    quantitycontrol();
                    string name = reader.GetString(0);
                    price = reader.GetInt32(2);
                    i = i + 1;

                    lbtnDelete = new LinkButton();
                    lbtnDelete.Text = "Remove";
                    lbtnDelete.CssClass = "linkdeletecart";
                    lbtnDelete.Attributes.Add("runat", "server");
                    lbtnDelete.Attributes.Add("AutoPost", "true");
                    lbtnDelete.Click += new EventHandler(this.lbtnDelete_Command);
                    lbtnDelete.ID = "lkbtDelete" + cartid.ToString();
                    lbtnDelete.CommandArgument = cartid.ToString();
                    lbtnDelete.CommandName = "Delete";

                    ul = new HtmlGenericControl("ul");
                    ul.ID = "dyanmicul" + cartid;
                    ul.Attributes.Add("class", "carttablehead");
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.ID = "dynamicli" + cartid;
                    li.InnerHtml = name;
                    ul.Controls.Add(li);
                    HtmlGenericControl li2 = new HtmlGenericControl("li");
                    li2.ID = "dynamicli2" + cartid;
                    //li.InnerHtml = name;
                    //data = "<ul class='carttablehead'><li class=''>" + name + "</li><li class=''>";
                    //Mycart.Controls.Add(new LiteralControl(data));
                    Mycart3.ContentTemplateContainer.Controls.Add(ul);
                    //Mycart2.Controls.Add(new LiteralControl(data));
                    HtmlGenericControl cartdiv = new HtmlGenericControl("div");
                    cartdiv.ID = "innercartdiv" + cartid;
                    cartdiv.Attributes.Add("class", "cart-qty-panel-read fk-text-center");
                    cartdiv.Controls.Add(qtylink);
                    // Mycart3.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='cart-qty-panel-read fk-text-center'>"));
                    // Mycart2.Controls.Add(new LiteralControl("<div class='cart-qty-panel-read fk-text-center'>"));
                    Mycart3.ContentTemplateContainer.Controls.Add(cartdiv);
                    //Mycart2.Controls.Add(qtylink);

                    textbox1 = new TextBox();

                    textbox1.Attributes.Add("name", "qty" + i);
                    textbox1.Attributes.Add("runat", "server");
                    //textbox.Attributes.Add("AutoPost", "true");
                    textbox1.Attributes.Add("class", "cart-qty-textbox");
                    textbox1.ID = (cartid).ToString() + i;
                    textbox1.Text = (qty).ToString();
                    //textbox1.AutoPostBack = true;
                    text_qty_val = qty.ToString();
                    textbox1.TextChanged += new EventHandler(this.textbox1_TextChanged);
                    hide = new HiddenField();
                    hide.ID = "hide_" + cartid;
                    hide.Value = price.ToString();
                    tvalue = new HiddenField();
                    tvalue.ID = "text_" + cartid;
                    tvalue.Value = qty.ToString();
                    HtmlGenericControl cartdivtext = new HtmlGenericControl("div");
                    cartdivtext.Attributes.Add("class", "cart-qty-panel-write fk-hidden");
                    cartdivtext.Controls.Add(textbox1);
                    cartdivtext.Controls.Add(hide);
                    cartdivtext.Controls.Add(tvalue);
                    //Mycart3.ContentTemplateContainer.Controls.Add(new LiteralControl("</div><div class='cart-qty-panel-write fk-hidden'>"));
                    //Mycart2.Controls.Add(new LiteralControl("</div><div class='cart-qty-panel-write fk-hidden'>"));
                    //Mycart3.ContentTemplateContainer.Controls.Add(textbox1);
                    //Mycart2.Controls.Add(textbox1);
                    save = new LinkButton();
                    save.Text = "Save";
                    save.Attributes.Add("AutoPostBack ", "true");
                    save.Attributes.Add("class", "fk-smallfont fk-font-small fksd-smalltext");
                    save.ID = cartid.ToString();
                    //save.Attributes.Add("onclick", "save_ServerClick");// += new EventHandler(this.save_ServerClick);
                    save.Click += new EventHandler(this.save_ServerClick);
                    save.ClientIDMode = ClientIDMode.Static;
                    save.Attributes.Add("runat", "server");
                    cartdivtext.Controls.Add(save);
                    li2.Controls.Add(cartdiv);
                    li2.Controls.Add(cartdivtext);
                    ul.Controls.Add(li2);
                    HtmlGenericControl liprice = new HtmlGenericControl("li");
                    liprice.ID = "pricel" + cartid;
                    liprice.InnerHtml = (price * qty).ToString();
                    ul.Controls.Add(liprice);
                    //Mycart3.ContentTemplateContainer.Controls.Add(save);
                    //Mycart2.Controls.Add(save);
                    //Mycart3.ContentTemplateContainer.Controls.Add(new LiteralControl("</div></li><li class=''>" + price * qty + "</li>"));
                    // Mycart2.Controls.Add(new LiteralControl("</div></li><li class=''>" + price * qty + "</li>"));
                    ul.Controls.Add(lbtnDelete);
                    //Mycart3.ContentTemplateContainer.Controls.Add(lbtnDelete);
                    //Mycart2.Controls.Add(lbtnDelete);
                    System.Web.UI.AsyncPostBackTrigger trig = new System.Web.UI.AsyncPostBackTrigger();
                    trig.ControlID = save.ID;
                    trig.EventName = "Click";
                    Mycart3.Triggers.Add(trig);
                    System.Web.UI.AsyncPostBackTrigger trigdelete = new System.Web.UI.AsyncPostBackTrigger();
                    trigdelete.ControlID = lbtnDelete.ID;
                    trigdelete.EventName = "Click";
                    Mycart3.Triggers.Add(trig);
                    currentScriptManager.RegisterAsyncPostBackControl(save);
                    currentScriptManager.RegisterAsyncPostBackControl(lbtnDelete);
                    //Mycart3.ContentTemplateContainer.Controls.Add(new LiteralControl("</ul>"));
                    //Mycart2.Controls.Add(new LiteralControl("</ul>"));

                    //Mycart.ChildrenAsTriggers = true;
                    //ScriptManager1.RegisterAsyncPostBackControl(save);
                    //ScriptManager1.RegisterAsyncPostBackControl(lbtnDelete);
                    //Page.Form.FindControl("cartlayer").Controls.Add(Mycart);
                    //cartlayer.Controls.Add(Mycart);

                    //updatecartpanel.ContentTemplateContainer.Controls.Add(save);
                    //ScriptManager currPageScriptManager = ScriptManager.GetCurrent(Page) as ScriptManager;
                    //if (currPageScriptManager != null)
                    //{
                    //    //Response.Write("<script>alert(' text=" + save.ClientID + "')</script>");
                    //    // write your code
                    //    currPageScriptManager.RegisterAsyncPostBackControl(save);
                    //    // Now call the UpdatePanel.Update() when myControlName posts back.
                    //    Mycart.Update();
                    //}


                    //updatecartpanel.Triggers.Add(trig);
                    //updatecartpanel.Update();
                    //Response.Write("<script>alert(' text=" + save.ClientID + "')</script>");
                    //at = new AsyncPostBackTrigger();
                    //at.ControlID = save.ID;
                    //at.EventName = "ServerClick";
                    //updatecartpanel.Triggers.Add(at);
                    //div.Controls.Add(ul);
                    div.Controls.Add(ul);
                    Mycart3.ContentTemplateContainer.Controls.Add(div);
                }

                //Page.Form.FindControl("Mycart2").Controls.Add(Mycart3);

            }
            else
            {
                Mycart3.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='nodata'>No Products added in Cart</div>"));
                //Mycart3.Update();
            }
            
        }
        reader.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string note = (string)Session["notice"];
        
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();

        //Mycart3.Update();


        bindtotal();
        //if (!IsPostBack)
        {
            bindphone();
            bindmobile();
            bindemail();
            BindLogo();
            bindcategory();
            Bindcatalog();
            cartbutton();

        }
        

    }

    private void quantitycontrol()
    {
        qty = reader.GetInt32(1);
        qtylink = new HyperLink();
        qtylink.Text = qty.ToString();
        qtylink.ID = "qty_" + cartid.ToString();
        //qtylink.Attributes.Add("value","'"+qty+"'");
        qtylink.Attributes.Add("class", "cart-qty");
        qtylink.Attributes.Add("runat", "server");
        qtylink.Attributes.Add("AutoPostBack ", "true");
        qtylink.Attributes.Add("onclick", "$(this).closest('li').addClass('change').find('.cart-qty-textbox').val($(this).html()).select().end().find('.cart-qty-panel-write').removeAttr('style');");
    }

    private void cartbutton()
    {
        com.CommandText = "select * from cart where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "'";
        com.Connection = con;
        reader = com.ExecuteReader();
        if (reader.HasRows)
        {
            c_button.Visible = true;
        }
        else
        {
            c_button.Visible = false;
        }
        reader.Close();
    }
    protected void savebtn(object sender, System.EventArgs e)
    {
        //Label1.Text = "Panel refreshed at " +
        //DateTime.Now.ToString();      
    }
    protected void textbox1_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        string s = t.Text;
        string t_id = t.ID;
        int n = t_id.Length;
        string st_id = t_id.Substring(0, n - 1);
        HiddenField ts = (HiddenField)Page.Form.FindControl("text_" + st_id);
        st_id = ts.Value;
        text_qty_val = t.Text.ToString();
        if (text_qty_val == null || text_qty_val == "")
        {
            text_qty_val = st_id.ToString();
        }
        // Response.Write("<script>alert(' text=" + text_qty_val + "')</script>");
    }

    protected void save_ServerClick(object sender, System.EventArgs e)
    {

        int k = 0;        
        //System.Threading.Thread.Sleep(3000);
        //Response.Write("<script>alert(' text=" + text_qty_val + "')</script>");
        int changeqty = 0;
        LinkButton hl = sender as LinkButton;
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string id = hl.ID;

        tval = Convert.ToInt32(text_qty_val);
        cartid1 = Convert.ToInt32(id);
        //strOriginal.Remove(20, 5);
        com.CommandText = "update cart set qty=" + tval + " where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND cart_id=" + cartid1;
        com.Connection = con;
        //Response.Write("update cart set qty=" + tval + " where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND cart_id=" + cartid);
        changeqty = com.ExecuteNonQuery();
        //Label1.Text = "Panel refreshed at " +
        //DateTime.Now.ToString();      
        //if (hl.HasAttributes)
        //{
        //    username.InnerText = hl.Attributes.Keys.ToString();
        //}
        if (changeqty > 0)
        {
            HyperLink qt = (HyperLink)Page.Form.FindControl("qty_" + id);
            qt.Text = text_qty_val;
            HiddenField hd = (HiddenField)Page.Form.FindControl("hide_" + id);
            string p_price = hd.Value;
            HtmlGenericControl chli = (HtmlGenericControl)Page.Form.FindControl("pricel" + id);
            chli.InnerText = (Convert.ToInt32(text_qty_val) * Convert.ToInt32(p_price)).ToString();



            bindtotal();


            Mycart3.Update();
            //Control c = (UpdatePanel)Page.Form.Controls(Mycart);            
            UpdatePanel1.Update();

        }
        else
        {
            //Mycart.Update();
            //Response.Write("<script>alert('fail ')</script>");
        }


    }



    protected void lbtnDelete_Command(object sender, System.EventArgs e)
    {
        //System.Threading.Thread.Sleep(2000);
        LinkButton lnk = sender as LinkButton;
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string co = lnk.CommandName;
        string ca = lnk.CommandArgument.ToString();
        if (co == "Delete")
        {
            int cartid = Convert.ToInt32(lnk.CommandArgument.ToString());
            com.CommandText = "delete from cart where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND cart_id=" + cartid;
            com.Connection = con;
            int i = com.ExecuteNonQuery();
            bindtotal();
            if (i > 0)
            {
                bindtotal();
                string linkid = lnk.ID.ToString();
                //linkid.Remove("lkbtDelete");
                string divid = linkid.Remove(0, 10);
                HtmlGenericControl remdiv = (HtmlGenericControl)Page.Form.FindControl("dyanmicul" + divid);
                
                
                UpdatePanel1.Update();
                
                remdiv.Visible = false;
                //Response.Write("asdasd" + co);
                //Response.Redirect(url);
            }

        }
    }


    //public string bindc()
    //{
    //    int i = 0, j = 0;
    //    com.CommandText = "select item_name,qty,item_price,cart_id from cart where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "'";
    //    com.Connection = con;
    //    reader = com.ExecuteReader();
    //    if (reader.HasRows)
    //    {
    //        while (reader.Read())
    //        {

    //        }
    //    }
    //    string data = "";
    //    int total=0;
    //    reader.Close();
    //    reader = com.ExecuteReader();
    //    if (reader.HasRows)
    //    {
    //        while (reader.Read())
    //        {
    //            string name = reader.GetString(0);
    //            int qty = reader.GetInt32(1);
    //            int price = reader.GetInt32(2);
    //            total = total + price;
    //            data += "<ul class='carttablehead'><li class=''>" + name + "</li><li class=''>" + qty + "</li><li class=''>" + price + "</li><li class=''>" + "</li></ul>";
    //        }
    //        reader.Close();
    //    }
    //    else
    //    {
    //        data += "<ul class='carttablehead'><li class=''>NO DATA</li></ul>";
    //    }
    //    //reader.Close();
    //    return data;
    //}
    public void bindtotal()
    {
        UpdatePanel1.Update();
        Mycart3.Update();
        reader.Close();
        string data = "";
        int total = 0;
        com.CommandText = "select item_price,qty from cart where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND payment_status='Pending'";
        com.Connection = con;
        reader = com.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int pro_price = reader.GetInt32(0);
                int qty = reader.GetInt32(1);
                total = total + pro_price * qty;
                data = "Rs. " + total;
            }
            reader.Close();
            totalprice.InnerText = data;
        }
        else
        {
            //UpdatePanel1.Visible = false;
            //totalprice.Visible = false;
            checkoutlink.Visible = false;
            //Response.Redirect("gallery.aspx");
            data = "Rs. 0";
            reader.Close();
            totalprice.InnerText = data + "";

        }


    }


    private void bindcategory()
    {
        string s = "";
        com.CommandText = "select category_name from category";
        com.Connection = con;
        reader4 = com.ExecuteReader();
        if (reader4.HasRows)
        {
            while (reader4.Read())
            {
                string html = loadcategory();
                s += html;
                product = s;
            }
        }
        category.InnerHtml = product;
        reader4.Close();

    }

    private string loadcategory()
    {
        string cat = reader4.GetString(0);
        html = "<li><a href='gallery.aspx?cat=" + cat + "' class='res'>" + cat + "</a></li>";
        return html;
    }
    private void BindLogo()
    {
        string s = "";
        com.CommandText = "select logo from sitelogo";
        com.Connection = con;
        string name = (string)com.ExecuteScalar();
        s = "<img style='width:228px;height:98px;' src='Admin/Upload_images/Logo/" + name + "' alt='' title='' />";
        Logo.InnerHtml = s;

    }

    private void bindemail()
    {
        com.CommandText = "select email from admin_contact_us_detail";
        com.Connection = con;
        reader2 = com.ExecuteReader();
        if (reader2.HasRows)
        {
            reader2.Read();
            string mob = reader2.GetString(0);
            adminemail.HRef = "mailto:" + mob;
            email.Text = mob;


        }
        reader2.Close();
    }

    private void bindmobile()
    {
        com.CommandText = "select Mobile from admin_contact_us_detail";
        com.Connection = con;
        reader = com.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            string mob = reader.GetString(0);
            mobile.Text = mob;
        }
        reader.Close();
    }

    private void bindphone()
    {
        com.CommandText = "select phone from admin_contact_us_detail";
        com.Connection = con;
        reader1 = com.ExecuteReader();
        if (reader1.HasRows)
        {
            reader1.Read();
            string mob = reader1.GetString(0);
            phone.Text = mob;
        }
        reader1.Close();
    }
    private void Bindcatalog()
    {

        com.CommandText = "select catalog_name from catalogdetails ";
        com.Connection = con;
        readercatalog = com.ExecuteReader();
        if (readercatalog.HasRows)
        {
            readercatalog.Read();
            string file = readercatalog.GetString(0);
            string html = "<h4>Orange Exim Catalogue</h4>" +
                        "<p>Download Catalogue & More info.</p><a href='files/catalog/" + file + "' target='_blank' class='post-link'>Download</a>";
            string image = " <a href='files/catalog/" + file + "' target='_blank'>" +
                          "<img class='catalogimage' alt='catalog image' src='images/catalog.jpg'/></a>";
            cataloglayer.InnerHtml = html;
            imagelink.InnerHtml = image;
        }
        readercatalog.Close();

    }
    protected void subscribe_Click(object sender, EventArgs e)
    {

        int i = 0;
        string sub_email = emailidsub.Text.ToUpper();
        com.CommandText = "select  * from  NewsLetter_subscription where subscribe_email='" + sub_email + "'";
        com.Connection = con;
        reader = com.ExecuteReader();
        if (!reader.HasRows)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into NewsLetter_subscription values('" + sub_email + "')";
            cmd.Connection = con;
            reader.Close();
            int no = cmd.ExecuteNonQuery();
            if (no > 0)
            {
                //Response.Write("success");
                Response.Write("<script>alert('Email Id Successfully Registered')</script>");
                //Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('Email Id Already Registered')</script>");
            //Response.Redirect("Default.aspx");
        }
    }
}
