using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class savecart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Request.Form["cartkey"].ToString());
       // Response.Write("data=="+s);
        string cid = (string)Session["cust_id"];
        if (cid == "" || cid == null)
        {
            Response.Redirect("login.aspx");
        }
        string cartkey = Request.Form["cartvalues"].ToString();
        string productcode = Request.Form["itemid"].ToString();
        string pro_name = Request.Form["productname"].ToString();
        string pro_price = Request.Form["productprice"].ToString();
        string url = Request.Form["url"].ToString();
        //Response.Write("value====" +s0+ s1 + s2);
        string sessionid = Session.SessionID;
        
        //Response.Write(sessionid);
       
        if (cartkey == null || productcode == null || pro_name == null || Session["cust_id"].ToString() == "" || Session["cust_id"].ToString() == null)
        {
            Response.Redirect("login.aspx");
        }
        
        DB db = new DB();
        string orderstate = db.insertorder(cid, sessionid, pro_price);
        if (orderstate !=null)
        {
            string cartinsert = db.insertcart(cid, sessionid, productcode, pro_name, pro_price, orderstate);
            Session["notice"] = "getnote";
            //
            Response.Redirect(url);
            //Response.Write("==" + cartinsert);
        }
        else
        {
            Response.Write("ordeer=="+orderstate);
        }
        
           
    }
}