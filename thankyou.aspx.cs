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


public partial class thankyou : System.Web.UI.Page
{
    string cid;
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {

        cid = (string)Session["cust_id"];
        if (cid == "" || cid == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (Session["cashmethod"] == null && Session["Paypalmethod"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        //if (Session["Paypalmethod"] != null)
        //{
        //    //updatepayment();
        //}
        bindorderdetails();
        con.Close();
    }

    private void bindorderdetails()
    {   
        string orderprcode="";
        if (Session["cashmethod"] != null)
        {
            totaldiv.Visible = true;
            orderprcode = (string)Session["cashmethod"];
            //Session.Remove("cashmethod");
        }
        if (Session["Paypalmethod"] != null)
        {
            totaldiv.Visible = false;
            orderprcode = (string)Session["Paypalmethod"];
            //Session.Remove("Paypalmethod");
        }
          
        orderno.Text = orderprcode;
        string s = com.CommandText = "select orderID,payment_type,payment_status,cdatetime,billing_name,billing_add,billing_countryid,billing_stateid,billing_cityid,billing_mobile,billing_zip,order_name,order_email,order_add,countryid,stateid,cityid,order_mobile,order_zip from [order] where customer_id='" + cid + "' AND cust_session_id='" + Session.SessionID.ToString() + "' AND orderID='"+orderprcode+"'";
        com.Connection = con;
        reader=com.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            
            Payment_Type.Text = reader.GetString(1);
            //if (Session["cashmethod"] != null)
            {
                Payment_Status.Text = reader.GetString(2);
            }
            //else
            {
                
               // Payment_Status.Text = "Paid";
            }
            Order_Date.Text = reader.GetDateTime(3).ToString();
            string bilinfo = reader.GetString(4);
            string billadd=reader.GetString(5);
            string billcountry = reader.GetString(6);
            string billstate = reader.GetString(7);
            string billcity = reader.GetString(8);
            string mob=reader.GetString(9);
            string pin = reader.GetString(10);
            string shipinfo = reader.GetString(11);
            string shipadd = reader.GetString(13);
            string shipcountry = reader.GetString(14);
            string shipstate = reader.GetString(15);
            string shipcity = reader.GetString(16);
            string s_mob = reader.GetString(17);
            string s_pin = reader.GetString(18);
            string orderemail = reader.GetString(12);
            
            Billing_Information.Text = "<b>"+bilinfo+"</b>" + "<br/>" + billadd + "<br/>" + billcity +"-"+pin+"," + billstate + "," + billcountry+".<br/><b>Mobile:</b>"+mob+"<br/>";
            Shipping_Information.Text = "<b>" + shipinfo + "</b>" + "<br/>" + shipadd + "<br/>" + shipcity + "-" + s_pin + "," + shipstate + "," + shipcountry + ".<br/><b>Mobile:</b>" + s_mob + "<br/><b>Email ID:</b>"+orderemail;
            con.Close();
        }
        reader.Close();
        //Response.Write("query==" + s);
        
    }

    private void updatepayment()
    {
        string orderid = (string)Session["Paypalmethod"];
        com.CommandText = "Update [order] set payment_status='Paid' where customer_id='" + cid + "' AND cust_session_id='" + Session.SessionID.ToString() + "' AND orderID='"+orderid+"'";
        com.Connection = con;
        com.ExecuteNonQuery();
        con.Close();
        com.CommandText = "Update [cart] set payment_status='Paid' where client_user_id='" + cid + "' AND client_session_id='" + Session.SessionID.ToString() + "' AND order_id='" + orderid + "'";
        com.Connection = con;
        con.Open();
        com.ExecuteNonQuery();
        con.Close();
    }

    public string orderbox()
    {
        string orderprcode="";
        if (Session["cashmethod"] != null)
        {
             orderprcode = (string)Session["cashmethod"];
             
        }
        if (Session["Paypalmethod"] != null)
        {
             orderprcode = (string)Session["Paypalmethod"];
             
        }
        string s = com.CommandText = "select * from [cart] where client_user_id='" + cid + "' AND client_session_id='" + Session.SessionID.ToString() + "' AND order_id='" + orderprcode+"'";
        com.Connection = con;
        con.Open();
        reader=com.ExecuteReader();
        string data = "";
        int orderprice = 0;
        if(reader.HasRows)
        {
            int i=1;
            while (reader.Read())
            {
                string itemname=reader.GetString(4);
                int itemqty=reader.GetInt32(8);
                int itemprice = reader.GetInt32(6);                
                int totalprice=(itemqty)*(itemprice);
                orderprice += totalprice;
                data += "<div class='thanksdetails'><div class='details'>" + i + ".</div> <div class='details'>" + itemname + "</div> <div class='details'>" + itemqty + "</div> <div class='details'>" + itemprice + "</div> <div class='details'>" + totalprice + "</div></div>";
                i++;
            }
            totalorderprice.Text =" Rs."+orderprice.ToString();
            if (Session["cashmethod"] != null)
            {
                finalamt.Text = "Rs." + (orderprice + 100).ToString();
                Session.Remove("cashmethod");
                Session.Remove("Paypalmethod");
            }
            else
            {
                finalamt.Text = "Rs." + (orderprice).ToString();
                Session.Remove("cashmethod");
                Session.Remove("Paypalmethod");
            }
            return data;
        }
        return orderprcode;
    }
}