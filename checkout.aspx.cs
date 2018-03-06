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

public partial class checkout : System.Web.UI.Page
{
    string text_qty_val = "",orderID="";
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    LinkButton lbtnDelete, changeqty;
    HtmlAnchor qtylink1, save;
    HyperLink qtylink;
    //HtmlInputText textbox;
    TextBox textbox1;
    UpdatePanel Mycart;
    AsyncPostBackTrigger at;
    SqlDataReader reader, reader1, reader2, reader4, readercatalog;
    string html, product = "", cid, sessionid;
    int qty = 0;
    int cartid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string cusid = (string)Session["cust_id"];
        if (cusid == "" || cusid == null)
        {            
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            string query = "select CountryId, CountryName from Countries ORDER BY CountryName";
            BindDropDownList(ddlCountries, query, "CountryName", "CountryId", "Select Country");
            BindDropDownList(shippingddlCountries, query, "CountryName", "CountryId", "Select Country");
            ddlStates.Enabled = false;
            ddlCities.Enabled = false;
            shippingddlStates.Enabled = false;
            shippingddlCities.Enabled = false;
            ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
            ddlCities.Items.Insert(0, new ListItem("Select City", "0"));
            shippingddlStates.Items.Insert(0, new ListItem("Select State", "0"));
            shippingddlCities.Items.Insert(0, new ListItem("Select City", "0"));
        }
        Mycart = new UpdatePanel();
        Mycart.ID = "updatee2";
        Mycart.Attributes.Add("runat", "server");
        Mycart.UpdateMode = UpdatePanelUpdateMode.Conditional;
        cid = (string)Session["cust_id"];
        sessionid = Session.SessionID;
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        SqlCommand co1 = new SqlCommand();
        SqlConnection con1 = new SqlConnection();
        con1.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con1.Open();
        co1.CommandText = "select item_name,qty,item_price,cart_id,order_id from cart where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND payment_status='Pending'";
        co1.Connection = con1;
        int i = 0, j = 0;
        string data = "";
        reader = co1.ExecuteReader();
        //if (!IsPostBack)
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    orderID = reader.GetString(4);
                    quantitycontrol();                    
                    string name = reader.GetString(0);
                    int price = reader.GetInt32(2);
                    i = i + 1;
                    cartid = reader.GetInt32(3);
                    lbtnDelete = new LinkButton();
                    lbtnDelete.Text = "Delete";
                    lbtnDelete.CssClass = "linkdeletecart";
                    lbtnDelete.Attributes.Add("runat", "server");
                    lbtnDelete.Click += new EventHandler(this.lbtnDelete_Command);
                    lbtnDelete.ID = "lkbtDelete" + i;
                    lbtnDelete.CommandArgument = cartid.ToString();
                    lbtnDelete.CommandName = "Delete";

                    data = "<ul class='checkouttablehead'><li class=''>" + name + "</li><li class=''>";
                    //Mycart.Controls.Add(new LiteralControl(data));
                    Mycart.ContentTemplateContainer.Controls.Add(new LiteralControl(data));
                    //Mycart2.Controls.Add(new LiteralControl(data));

                    Mycart.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='cart-qty-panel-read fk-text-center'>"));
                    // Mycart2.Controls.Add(new LiteralControl("<div class='cart-qty-panel-read fk-text-center'>"));
                    Mycart.ContentTemplateContainer.Controls.Add(qtylink);
                    //Mycart2.Controls.Add(qtylink);

                    textbox1 = new TextBox();

                    textbox1.Attributes.Add("name", "qty" + i);
                    textbox1.Attributes.Add("runat", "server");
                    //textbox.Attributes.Add("AutoPost", "true");
                    textbox1.Attributes.Add("class", "cart-qty-textbox");
                    textbox1.ID ="t_" +i + (cartid).ToString();
                    textbox1.Text = (cartid).ToString();
                    //textbox1.AutoPostBack = true;
                    textbox1.TextChanged += new EventHandler(this.textbox1_TextChanged);

                    Mycart.ContentTemplateContainer.Controls.Add(new LiteralControl("</div><div class='cart-qty-panel-write fk-hidden'>"));
                    // Mycart2.Controls.Add(new LiteralControl("</div><div class='cart-qty-panel-write fk-hidden'>"));
                    Mycart.ContentTemplateContainer.Controls.Add(textbox1);
                    //Mycart2.Controls.Add(textbox1);
                    save = new HtmlAnchor();
                    save.InnerText = "Save";
                    //save.Attributes.Add("AutoPostBack ", "true");
                    save.Attributes.Add("class", "fk-smallfont fk-font-small fksd-smalltext");
                    save.ID = cartid.ToString() + i;
                    save.ServerClick += new EventHandler(this.save_ServerClick);
                    save.Attributes.Add("runat", "server");
                    Mycart.ContentTemplateContainer.Controls.Add(save);
                    //Mycart2.Controls.Add(save);
                    Mycart.ContentTemplateContainer.Controls.Add(new LiteralControl("</div></li><li class=''>" + price * qty + "</li>"));
                    // Mycart2.Controls.Add(new LiteralControl("</div></li><li class=''>" + price * qty + "</li>"));
                    Mycart.ContentTemplateContainer.Controls.Add(lbtnDelete);
                    //Mycart2.Controls.Add(lbtnDelete);
                    Mycart.ContentTemplateContainer.Controls.Add(new LiteralControl("</ul>"));
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
                    //PostBackTrigger trig = new PostBackTrigger();
                    //trig.ControlID = save.ID;
                    //updatecartpanel.Triggers.Add(trig);
                    //updatecartpanel.Update();
                    //Response.Write("<script>alert(' text=" + save.ClientID + "')</script>");
                    //at = new AsyncPostBackTrigger();
                    //at.ControlID = save.ID;
                    //at.EventName = "ServerClick";
                    //updatecartpanel.Triggers.Add(at);
                }
                //Page.FindControl("Mycart2").Controls.Add(Mycart);
                Mycart2.Controls.Add(Mycart);
                reader.Close();
                //Repeater1.DataBind = Mycart;
                da.SelectCommand = co1;
                ds.Clear();
                da.Fill(ds);
                //Repeater1.DataSource = ds;
                //Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
                Mycart.ContentTemplateContainer.Controls.Add(new LiteralControl("<div class='nodata'>No Products added in Cart</div>"));
                reader.Close();
            }
        }
        HtmlGenericControl remdiv = (HtmlGenericControl)Page.Form.FindControl("cartdetails");
        remdiv.Visible = false;
        bindtotal();
    }
    private void BindDropDownList(DropDownList ddl, string query, string text, string value, string defaultText)
    {
        string conString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                ddl.DataSource = cmd.ExecuteReader();
                ddl.DataTextField = text;
                ddl.DataValueField = value;
                ddl.DataBind();
                con.Close();
            }
        }
        ddl.Items.Insert(0, new ListItem(defaultText, "0"));
    }
    public string tprice()
    {
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
                int price = reader.GetInt32(0);
                int qty = reader.GetInt32(1);
                total = total + price * qty;
                data = (total / 60).ToString();
            }
        }
        return data;
    }
    public void bindtotal()
    {
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
                int price = reader.GetInt32(0);
                int qty = reader.GetInt32(1);
                total = total + price * qty;
                data = "Rs. " + total;

            }
            reader.Close();
            totalprice.InnerText = data;
        }
        else
        {
            data = "Rs. 0";
            reader.Close();
            totalprice.InnerText = data;

        }


    }
    private void quantitycontrol()
    {
        qty = reader.GetInt32(1);
        qtylink = new HyperLink();
        qtylink.Text = qty.ToString();
        //qtylink.Attributes.Add("class", "cart-qty");
        qtylink.Attributes.Add("runat", "server");
        //qtylink.Attributes.Add("AutoPostBack ", "true");
        //qtylink.Attributes.Add("onclick", "$(this).closest('li').addClass('change').find('.cart-qty-textbox').val($(this).html()).select().end().find('.cart-qty-panel-write').removeAttr('style');");
    }
    protected void textbox1_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        string s = t.Text;
        text_qty_val = t.Text.ToString();


        // Response.Write("<script>alert(' text=" + text_qty_val + "')</script>");
    }
    protected void lbtnDelete_Command(object sender, System.EventArgs e)
    {
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
            if (i > 0)
            {
                //Response.Write("asdasd" + co);
                Response.Redirect(url);
            }

        }
    }

    protected void save_ServerClick(object sender, System.EventArgs e)
    {

        System.Threading.Thread.Sleep(3000);
        //Response.Write("<script>alert(' text=" + text_qty_val + "')</script>");
        int changeqty = 0;
        HtmlAnchor hl = sender as HtmlAnchor;
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string id = hl.ID;
        int tval = Convert.ToInt32(text_qty_val);
        int cartid = Convert.ToInt32(id);
        //strOriginal.Remove(20, 5);
        com.CommandText = "update cart set qty=" + tval + " where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND cart_id=" + cartid;
        com.Connection = con;
        //Response.Write("update cart set qty=" + tval + " where client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND cart_id=" + cartid);
        changeqty = com.ExecuteNonQuery();
        //Label1.Text = "Panel refreshed at " +
        //DateTime.Now.ToString();      
        if (changeqty > 0)
        {


        }
        else
        {

        }

       

    }
    protected void Country_Changed(object sender, EventArgs e)
    {        
        ddlStates.Enabled = false;
        ddlCities.Enabled = false;
        ddlStates.Items.Clear();
        ddlCities.Items.Clear();
        ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
        ddlCities.Items.Insert(0, new ListItem("Select City", "0"));
        int countryId = int.Parse(ddlCountries.SelectedItem.Value);       
        if (countryId > 0)
        {
            string query = string.Format("select StateId, StateName from States where CountryId = {0}", countryId);
            BindDropDownList(ddlStates, query, "StateName", "StateId", "Select State");
            ddlStates.Enabled = true;           
        }
    }
    protected void State_Changed(object sender, EventArgs e)
    {
        ddlCities.Enabled = false;
        ddlCities.Items.Clear();
        ddlCities.Items.Insert(0, new ListItem("Select City", "0"));
        int stateId = int.Parse(ddlStates.SelectedItem.Value);
        if (stateId > 0)
        {
            string query = string.Format("select CityId, CityName from Cities where StateId = {0}", stateId);
            BindDropDownList(ddlCities, query, "CityName", "CityId", "Select City");
            ddlCities.Enabled = true;           
        }
    }
    protected void shippingCountry_Changed(object sender, EventArgs e)
    {
       
        shippingddlStates.Enabled = false;
        shippingddlCities.Enabled = false;
        shippingddlStates.Items.Clear();
        shippingddlCities.Items.Clear();
        shippingddlStates.Items.Insert(0, new ListItem("Select State", "0"));
        shippingddlCities.Items.Insert(0, new ListItem("Select City", "0"));
        int countryId = int.Parse(shippingddlCountries.SelectedItem.Value);
        if (countryId > 0)
        {
            string query = string.Format("select StateId, StateName from States where CountryId = {0}", countryId);
            BindDropDownList(shippingddlStates, query, "StateName", "StateId", "Select State");
            shippingddlStates.Enabled = true;
        }
    }
    protected void shippingState_Changed(object sender, EventArgs e)
    {
        shippingddlCities.Enabled = false;
        shippingddlCities.Items.Clear();
        shippingddlCities.Items.Insert(0, new ListItem("Select City", "0"));
        int stateId = int.Parse(shippingddlStates.SelectedItem.Value);
        if (stateId > 0)
        {
            string query = string.Format("select CityId, CityName from Cities where StateId = {0}", stateId);
            BindDropDownList(shippingddlCities, query, "CityName", "CityId", "Select City");
            shippingddlCities.Enabled = true;
        }
    }

    protected void setsameaddress(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        {
            //Response.Write("<script>alert(' text=')</script>");
            CheckBox cb = sender as CheckBox;
            bool state = cb.Checked;
            //Response.Write("asdasd");
            //Response.Write("<script>alert(' text=" + state + "')</script>");
            if (state == true)
            {
                shippingname.Text = Billing_name.Text;
                shippingaddress.Text = Billing_address.Text;
                shippingddlCountries.SelectedIndex = ddlCountries.SelectedIndex;
                shipmobile.Text = Billing_mobile.Text;
                //BindDropDownList(shippingddlCities, query, "CityName", "CityId", "Select City");
                shippingddlCountries.Enabled = true;
                //shippingddlStates.SelectedItem.Value = ddlStates.SelectedItem.Value;                
                shippingddlStates.Items.Insert(0, new ListItem(ddlStates.SelectedItem.ToString(), "b_"));
                shippingddlStates.SelectedIndex = 0;
                shippingddlStates.Enabled = true;
                shippingddlCities.Items.Insert(0, new ListItem(ddlCities.SelectedItem.ToString(), "c_"));
                shippingddlCities.SelectedIndex = 0; 
                shippingddlCities.SelectedItem.Value = ddlCities.SelectedItem.Value;
                shippingddlCities.Enabled = true;
                shipping_zipcode.Text = Billing_zipcode.Text;
            }
            else
            {
                shippingname.Text = "";
                shippingaddress.Text = "";
                shippingddlCountries.SelectedIndex = 0;
                shippingddlStates.Items.Remove(shippingddlStates.Items.FindByValue("b_"));
                shippingddlCities.Items.Remove(shippingddlCities.Items.FindByValue("1"));
                shipmobile.Text = "";
                //shippingddlStates.Items.FindByValue("0").Selected = true;
                //shippingddlCities.Items.FindByValue("0").Selected = true;
                //shippingddlStates.Text ="Select State";
                //shippingddlCities.Text ="Select City";
                shippingddlStates.Enabled = true;
                shippingddlCities.Enabled = true;
                shipping_zipcode.Text = "";
                shippingddlCountries.Enabled = true;
            }

        }
    }

    protected void check_availability(object sender, EventArgs e)
    {
        string pin = pincode.Text;
        com.CommandText = "select pincode from pincode where pincode='"+pin +"'";
        com.Connection = con;
        string code=(string)com.ExecuteScalar();
        if (code != null)
        {
            codnotify.Text = "Cash On delivery Available";
        }
        else
        {
            codnotify.Text = "Cash On Delivery not Available";
        }
    }

    protected void checkoutProcess(object sender, EventArgs e)
    {
       // Response.Write("hi");
        //Response.Write("<script>alert(' text=')</script>");
        //com = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString= ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        conn.Open();
        int totalp=Convert.ToInt32(tprice());
        bool p_method = paypalmethod.Checked;
        bool payterms = terms.Checked;
        bool cas_method = codmethod.Checked;
        string orderemail = Billing_email.Text;
        string billname = Billing_name.Text;
        string ship_name = shippingname.Text;
        string zipcode = Billing_zipcode.Text;
        string shipzipcode = shipping_zipcode.Text;
        string billcountry = ddlCountries.SelectedItem.Text;
        string billstate = ddlStates.SelectedItem.Text;
        string billcity = ddlCities.SelectedItem.Text;
        string shipcountry = shippingddlCountries.SelectedItem.Text;
        string shipstate = shippingddlStates.SelectedItem.Text;
        string shipcity = shippingddlCities.SelectedItem.Text;
        string billadd = Billing_address.Text;
        string shipadd = shippingaddress.Text;
        string b_mob = Billing_mobile.Text;
        string s_mob=shipmobile.Text;
        if (p_method)
        {
            if (payterms)
            {
                string pcode = bindordercode();
                //ordercode = "O_"+bindcart();
                //string qu = com.CommandText = "INSERT INTO [order](orderID,customer_id,cust_session_id,total_price,final_price,billing_name,billing_add,billing_countryid,billing_stateid,billing_cityid,billing_mobile,billing_zip,order_name,order_email,order_add,countryid,stateid,cityid,order_mobile,order_zip,payment_type,payment_status,order_status,cdatetime)VALUES('" + ordercode + "','" + cid + "','" + sessionid + "'," + totalp * 60 + "," + totalp * 60 + ",'" + Billing_name.Text.ToString() + "','" + Billing_address.Text.ToString() + "','" + billcountry + "','" + billstate + "','" + billcity + "','" + b_mob + "','" + zipcode + "','" + ship_name + "','" + orderemail + "','" + shipadd + "','" + shipcountry + "','" + shipstate + "','" + shipcity + "','" + s_mob + "','" + shipzipcode + "','Paypal','Paid','Pending','" + System.DateTime.Now.ToString() + "')";            
                com.Connection = conn;
                com.CommandText = "UPDATE [order] set total_price=" + totalp + ",final_price=" + totalp + ",billing_name='" + billname + "',billing_add='" + billadd + "',billing_countryid='" + billcountry + "',billing_stateid='" + billstate + "',billing_cityid='" + billcity + "',billing_mobile='" + b_mob + "',billing_zip='" + zipcode + "',order_name='" + ship_name + "',order_email='" + orderemail + "',order_add='" + shipadd + "',countryid='" + shipcountry + "',stateid='" + shipstate + "',cityid='" + shipcity + "',order_mobile='" + s_mob + "',order_zip='" + shipzipcode + "',payment_type='Paypal',order_status='Pending',cdatetime='" + System.DateTime.Now.ToString() + "' WHERE customer_id='" + cid + "' AND cust_session_id='" + sessionid + "' AND orderID='" + pcode + "'";
                //Response.Write(qu);
                
                int i = com.ExecuteNonQuery();
                if (i > 0)
                {
                    //Response.Write("success");
                    //returnurl.Value = "http://localhost:90/OrangeExim/thankyou.aspx";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "payformsbt();", true);// uncomment this
                }
            }
            else
            {
                Response.Write("<script>alert('Please Agree Terms And Conditions')</script>");
            }


        }
        else if (cas_method)
        {
            if (payterms)
            {
                
                string pcode = bindordercode();
                //ordercode = "O_" + bindcart();
                //string qu = com.CommandText = "INSERT INTO [order](orderID,customer_id,cust_session_id,total_price,final_price,billing_name,billing_add,billing_countryid,billing_stateid,billing_cityid,billing_mobile,billing_zip,order_name,order_email,order_add,countryid,stateid,cityid,order_mobile,order_zip,payment_type,payment_status,order_status,cdatetime)VALUES('" + ordercode + "','" + cid + "','" + sessionid + "'," + totalp * 60 + "," + totalp * 60 + ",'" + Billing_name.Text.ToString() + "','" + Billing_address.Text.ToString() + "','" + billcountry + "','" + billstate + "','" + billcity + "','" + b_mob + "','" + zipcode + "','" + ship_name + "','" + orderemail + "','" + shipadd + "','" + shipcountry + "','" + shipstate + "','" + shipcity + "','" + s_mob + "','" + shipzipcode + "','Paypal','Paid','Pending','" + System.DateTime.Now.ToString() + "')";            
                com.Connection = conn;
                com.CommandText = "UPDATE [order] set total_price=" + totalp + ",final_price=" + totalp + ",billing_name='" + billname + "',billing_add='" + billadd + "',billing_countryid='" + billcountry + "',billing_stateid='" + billstate + "',billing_cityid='" + billcity + "',billing_mobile='" + b_mob + "',billing_zip='" + zipcode + "',order_name='" + ship_name + "',order_email='" + orderemail + "',order_add='" + shipadd + "',countryid='" + shipcountry + "',stateid='" + shipstate + "',cityid='" + shipcity + "',order_mobile='" + s_mob + "',order_zip='" + shipzipcode + "',payment_type='Cash',payment_status='CashOnDelivery',order_status='Pending',cdatetime='" + System.DateTime.Now.ToString() + "' WHERE customer_id='" + cid + "' AND cust_session_id='" + sessionid + "' AND orderID='" + pcode+"'";
                //Response.Write(qu);
                int i = com.ExecuteNonQuery();
                
                
                if (i > 0)
                {
                    con.Close();
                    com.CommandText = "Update [cart] set payment_status='CashOnDelivery' WHERE client_user_id='" + cid + "' AND client_session_id='" + sessionid + "' AND order_id='" + pcode + "'";
                    con.Open();
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    //Response.Write(pcode);
                    Session["cashmethod"] = pcode;
                    Response.Redirect("thankyou.aspx");
                }
                else
                {
                    //Response.Write(pcode);
                }
            }
            else
            {
                Response.Write("<script>alert('Please Agree Terms And Conditions')</script>");
            }
        }

        else
        {
            Response.Write("<script>alert('Please Select Payment Method')</script>");
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "payformsbt();", true);// uncomment this
    }

    public string bindordercode()
    {
       
        reader.Close();
        com.Connection = con;
        com.CommandText = "select orderID from [order] WHERE customer_id='" + cid + "' AND cust_session_id='" + sessionid + "' AND payment_status='Pending'";
        string Code = (string)com.ExecuteScalar();        
        return Code;
        
    }
    
}