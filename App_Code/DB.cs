using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class DB
{
    private SqlConnection db_Connection,cnn;
    private SqlCommand db_Command,cmd;
    private SqlDataAdapter db_Adapter;
    private DataSet ds;
    private SqlDataReader reader,readd;
    string order_codecart = "";
	public DB()
	{
        
        try
        {
            db_Connection = new SqlConnection();
            db_Connection.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;            
            db_Command = new SqlCommand();
            db_Command.Connection = db_Connection;
        }
        catch(Exception ex)
        {
            throw ex;
        }


	}

    public Boolean validatelogin(string user,string password)
    {
        db_Connection.Open();
        db_Command.CommandText = "select * from admin_login where (username='"+user+"' AND password='"+password+"')";
        //int i=db_Command.ExecuteNonQuery();
        
        reader=db_Command.ExecuteReader();
        

        if (reader.HasRows==true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }



    public String addData(string productname, string catagory, string productcode ,string productprice)
    {
        int i;
        string s="";
        int id=-1;
        db_Command.CommandText = "insert into  product(product_name,product_type,product_image,product_code,product_price) values ('" + productname + "','" + catagory + "','','" + productcode + "','"+productprice+"');";
        try
        {
            s = db_Command.CommandText;
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            //db_Connection.Close();
            if (i != 0)
            {
                db_Command.CommandText = "select product_id from product where product_name='"+productname+"'";
                id = (int)db_Command.ExecuteScalar();
                return id.ToString();             

                //Response.Redirect("accessbean.aspx");
                //Label1.Text = "No. rows Affected="+i;
                // Response.Redirect("accessbean.aspx");
            }
            else
            {
                return i.ToString();
            }
        }
        catch (Exception ex)
        {
            return "string query="+s+"===="+ex.ToString();
        }
    }


    public string insertcategory(string category)
    {
        int i=0;
        string s = "";
        int id;

        try
        {
            db_Command.CommandText = "insert into  category(category_name,category_image) values ('" + category + "','');";           
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            if (i != null)
            {
                s=db_Command.CommandText = "select category_id from category where category_name='" + category+"'";                
                id = (int)db_Command.ExecuteScalar();                
                return id.ToString();
            }
            else
            {
                return "failed";
            }
        }
        catch (Exception ex)
        {
            return "Exception==="+ex+"asdasdads===="+category+s;
        }
    }

    public String insert_imagename(string thumbimage,int  category_id)
    {
        int i = 0;
        string cat_img;        
        db_Command.CommandText="Update  category set category_image='"+thumbimage+"' where category_id="+category_id;
        cat_img = db_Command.CommandText;
        i = db_Command.ExecuteNonQuery();
        if (i > 0)
        {
            return i.ToString();
        }
        return cat_img;

    }
    public String insert_proimagename(string thumbimage, int product_id)
    {
        int i = 0;
        string cat_img;
        db_Command.CommandText = "Update  product set product_image='" + thumbimage + "' where product_id=" + product_id;
        cat_img = db_Command.CommandText;
        i = db_Command.ExecuteNonQuery();
        if (i != 0)
        {
            return i.ToString();
        }
        return cat_img;

    }

    public SqlDataReader reteivecategory()
    {
        db_Command.CommandText = "select * from category";
        SqlDataReader  j=db_Command.ExecuteReader();
        return j;

    }

    

    public string delcategory(string category_id)
    {
        db_Connection.Open();
        int rowno=0;
        db_Command.CommandText = "delete from category where category_id=" + category_id;
        rowno=db_Command.ExecuteNonQuery();
        db_Connection.Close();
        return rowno.ToString();
    }

    //public string getcategorydetails(string category_id)
    //{
    //    db_Connection.Open();
    //    db_Command.CommandText = "select * from category where category_id=" + category_id;
    //    SqlDataReader reader = db_Command.ExecuteReader();
    //    if (reader.HasRows)
    //    {
    //        int id = -1;
    //        string s = "";
    //        Dbean db = new Dbean();
    //        id = (int)reader.GetValue(0);
    //        db.categoryid = id;
    //        db.categoryname = (string)reader[1];
    //        //MessageBox.Show("Value=" + reader.GetValue(0));           
    //        return "success";
    //    }
    //    else
    //    {
    //        return "failed";
    //    }
    //}

    public string updatecategory(string category, int keyID)
    {
        db_Connection.Open();
        db_Command.CommandText = "update category set category_name='" + category + "' where category_id=" + keyID;
        int i=db_Command.ExecuteNonQuery();
        
        if (i > 0)
        {
            return "success";
        }
        else
        {
            return "failed";
        }
    }

    public string delproduct(string product_id)
    {
        db_Connection.Open();
        int rowno = 0;
        db_Command.CommandText = "delete from product where product_id="+product_id;
        rowno = db_Command.ExecuteNonQuery();
        db_Connection.Close();
        return rowno.ToString();
    }

    public string EditProductData(string productname, string catagory, string productcode, int productid, string productprice)
    {
        db_Connection.Open();
        db_Command.CommandText = "update product set product_name='" + productname + "',product_type='" + catagory + "',product_code='" + productcode + "',product_price='"+productprice+"' where product_id="+productid;
        int i = db_Command.ExecuteNonQuery();

        if (i > 0)
        {
            return "success";
        }
        else
        {
            return "failed";
        }
    }

    public string delabtcategory(string product_id)
    {
        db_Connection.Open();
        int rowno = 0;
        db_Command.CommandText = "delete from about_us where about_id=" + product_id;
        rowno = db_Command.ExecuteNonQuery();
        db_Connection.Close();
        return rowno.ToString();
    }

    public string addaboutdata(string abouthead, string desc,string querystringid)
    {
        int i = 0;
        string s = "";
        int id;
        if (querystringid == null)
        {
            db_Command.CommandText = "insert into  about_us(Abouthead,About) values ('" + abouthead + "','" + desc + "');";
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            if (i != null)
            {
                s = db_Command.CommandText = "select about_id from about_us where Abouthead='" + abouthead + "'";
                id = (int)db_Command.ExecuteScalar();
                return "success";
            }
            else
            {
                return "failed";
            }
        }
        else
        {
            string query=db_Command.CommandText = "update about_us set Abouthead='" + abouthead + "', About='" + desc + "' where about_id=" + querystringid;
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            return query + querystringid;
            //if (i > 0)
            //{
            //    return "success";
            //}
            //else
            //{
            //    return query;
            //}
        }
    }

    public string logo()
    {
        db_Command.CommandText = "select logo from sitelogo";
        return "";
   
    }

    public string insert_logoname(string thumbimage)
    {
        int i;
        db_Command.CommandText = "update sitelogo set Logo='" + thumbimage + "'";
        db_Connection.Open();
        i = db_Command.ExecuteNonQuery();
        if (i != null)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    public string changepass(string newpass,string oldpass)
    {
        int i;
        db_Command.CommandText = "update admin_login set password='" + newpass + "' where password='" + oldpass + "'";
        db_Connection.Open();
        i = db_Command.ExecuteNonQuery();
        if (i >0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    public string insertslide(string thumbimage,string title,string details)
    {
        try
        {
            db_Command.CommandText = "insert into  sliderimages(slideimage,slide_head,slide_details) values ('" + thumbimage + "','" + title + "','" + details + "')";
            db_Connection.Open();
            int i = db_Command.ExecuteNonQuery();
            if (i != null)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public string delslide(string slide_id)
    {
        db_Connection.Open();
        int rowno = 0;
        db_Command.CommandText = "delete from sliderimages where slide_id=" + slide_id;
        rowno = db_Command.ExecuteNonQuery();
        db_Connection.Close();
        return rowno.ToString();
    }

    public string insert_catalog(string thumbimage)
    {
        try
        {
            int i;
            string s = db_Command.CommandText = "update catalogdetails set catalog_name='" + thumbimage + "' where catalog_id=1";
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            if (i > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public string updatethumb(string thumbname, string thumbdesc, string thumb_id, string thumb_category)
    {
        try
        {
            int i;
            string s = db_Command.CommandText = "update thumbIcon set thumb_name='" + thumbname + "',thumb_desc='" + thumbdesc + "',thumb_category='"+thumb_category+"' where id=" + thumb_id;
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            if (i > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public string update_thumbimage(string thumbimage, string thumb_id)
    {
        try
        {
            int i;
            string s = db_Command.CommandText = "update thumbIcon set thum_image='" + thumbimage + "' where id=" + thumb_id;            
            i = db_Command.ExecuteNonQuery();
            if (i > 0)
            {
                return "success";
            }
            else
            {
                return s;
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public string Updateslide(string thumbimage, string title, string details, string slide)
    {
        try
        {
            int i;
            string s = db_Command.CommandText = "update sliderimages set slide_head='" + title + "', slide_details='" + details + "',slideimage='" + thumbimage + "'  where slide_id=" + slide;
            db_Connection.Open();
            i = db_Command.ExecuteNonQuery();
            if (i > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public bool validatecust_login(string username, string password)
    {
        db_Connection.Open();
        db_Command.CommandText = "select * from customer_login where (customer_id='" + username + "' AND password='" + password + "')";        
        reader = db_Command.ExecuteReader();
      
        if (reader.HasRows == true)
        {
            return true;
           
        }
        else
        {
            return false;
        }
    }

    public string insertorder(string cid, string sessionid, string proprice)
    {
        
        int price=Convert.ToInt32(proprice);        
        int money=0;
        try
        {
            db_Command.CommandText = "select * from [order] where customer_id='" + cid + "'AND cust_session_id='" + sessionid + "' AND payment_status='Pending'";
            db_Connection.Open();
            reader = db_Command.ExecuteReader();
            if (reader.HasRows)
            {
                cnn = new SqlConnection();
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cnn.Open();
                reader.Read();
                money = reader.GetInt32(4);
                string cartordercode = reader.GetString(1);
                money = money + price;
                cmd.CommandText = "UPDATE [order] set total_price=" + money + " where customer_id='" + cid + "' AND cust_session_id='" + sessionid + "'AND payment_status='Pending'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return cartordercode;
                }
                reader.Close();
                cnn.Close();
                 
            }
            else
            {
                string order_code = bindorder();
                order_codecart = order_code;
                cnn = new SqlConnection();
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cnn.Open();
                cmd.CommandText = "INSERT INTO [order](orderID,customer_id,cust_session_id,total_price,payment_status)VALUES('" + order_codecart + "','" + cid + "','" + sessionid + "'," + proprice + ",'Pending')";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return order_codecart;
                }
                else
                {
                    return "fail";
                }
            }           
            return "0";
        }
        catch (Exception ex)
        {
            return ex.ToString() +"erroerere=="+ money + price;
        }

        
    }

    private string bindorder()
    {      
        string[] strArray = new string[36];
        strArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random Random = new Random();
        string Code = "O_";
        for (int i = 0; i < 10; i++)
        {
            int j = Convert.ToInt32(Random.Next(0, 36));
            Code += strArray[j].ToString();
        }

        //HtmlInputHidden customhide = new HtmlInputHidden();
        //customhide.Value = Code;
        //customhide.Name = "custom";
        //ordercode=Code;
        //Response.Write("hi===" + ordercode + "code=" + Code);
        return Code;
        //cartkey.Value = Code;          
        //HiddenField cartkey = (HiddenField)Page.FindControl("cartkey");  
    }

    public string insertcart(string cid, string sessionid, string p_code, string p_name, string proprice, string cartorderstate)
    {
        int price = Convert.ToInt32(proprice);
        int data = 0;
        string s = "",o_id="",o_sessid="";
        try
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
            cmd = new SqlCommand();
            cmd.Connection = cnn;
            cnn.Open();
            s=cmd.CommandText = "select customer_id, cust_session_id from [order] where customer_id='" + cid + "'AND cust_session_id='" + sessionid + "'";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                o_id = reader.GetString(0);
                o_sessid = reader.GetString(1);
            }
            reader.Close();
            cmd.CommandText = "select cart_id,qty from cart where client_user_id='" + cid + "'AND client_session_id='" + sessionid + "' AND item_name='"+p_name+"' AND payment_status='Pending'";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                //return data.ToString();
                int cartid = reader.GetInt32(0);
                int cartqty = reader.GetInt32(1);
                cartqty = cartqty + 1;
                reader.Close();
                cmd.CommandText = "Update cart set qty=" + cartqty + "where client_user_id='" + cid + "'AND client_session_id='" + sessionid + "' AND item_name='" + p_name + "' AND cart_id="+cartid;
                int update = cmd.ExecuteNonQuery();
                                           
                //return cartid.ToString();


                return "out=" + update.ToString();
            }
            else
            {
                reader.Close();
                cmd.CommandText = "INSERT INTO cart(order_id, client_user_id,client_session_id,item_name,item_id,item_price,payment_status)VALUES('" + cartorderstate + "','" + cid + "','" + o_sessid + "','" + p_name + "','" + p_code + "','" + price + "','Pending')";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }            

            }
            
        }
        catch (Exception ex)
        {
            return ex.ToString() + s + o_id + o_sessid;
        }
        
    }
}