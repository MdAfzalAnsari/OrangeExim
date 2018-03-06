using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class IPNListener : System.Web.UI.Page
{
    string cid;
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        con.Open();
        ProcessPayPalIPN();
        con.Close();
    }

    private void ProcessPayPalIPN()
    {
                // receive PayPal ipn data

          // extract ipn data into a string
          byte[] param = Request.BinaryRead(Request.ContentLength);
          string strRequest = Encoding.ASCII.GetString(param);

          // append PayPal verification code to end of string
          strRequest += "&cmd=_notify-validate";
    
          // create an HttpRequest channel to perform handshake with PayPal
          //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"https://www.paypal.com/cgi-bin/webscr");
          HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"https://www.sandbox.paypal.com/cgi-bin/webscr");
          req.Method = "POST";
          req.ContentType = "application/x-www-form-urlencoded";
          req.ContentLength = strRequest.Length;

          // send data back to PayPal to request verification
          StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
          streamOut.Write(strRequest);
          streamOut.Close();

          // receive response from PayPal
          StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
          string strResponse = streamIn.ReadToEnd();
          streamIn.Close();

          // if PayPal response is successful / verified
          if (strResponse.Equals("VERIFIED"))
          {
            // paypal has verified the data, it is safe for us to perform processing now

            // extract the form fields expected: buyer and seller email, payment status, amount
            string payerEmail = Request.Form["payer_email"];
            string paymentStatus = Request.Form["payment_status"];
            string receiverEmail = Request.Form["receiver_email"];
            string amount = Request.Form["mc_gross"];
            string orderid = Request.Form["custom"];

            // if the payment status is complete
            if (paymentStatus.Equals("Completed"))
            {
              // if the seller email is us (we don't want anyone else getting our payment!)
              //if (receiverEmail.ToLower().Equals("my.paypal.seller.account@mycompany.com"))
              //{
              //  // if the amount received is as expected
              //  if (WriteYourOwnLogic_IsOrderAmountCorrect(amount))
              //  {
              //    // complete order processing
              //    //E.g. arrange for despatch of products, mark order as complete, send emails out,
              //  }
              //  // else
              //  else
              //  {
              //    // don't process the order, invalid amount
              //  }
              //}
              // else
              //else
              //{
              //  // don't process the order, invalid seller
              //}
                com.CommandText = "update [order] set payment_status='Paid' Where orderId='" + orderid +"'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();

                com.CommandText = "update [cart] set payment_status='Paid' Where order_id='" + orderid + "'";
                con.Open();
                com.Connection = con;                
                com.ExecuteNonQuery();
                //con.Close();

                //Response.Redirect("DEfault.aspx");
                //Response.Write(orderid);
            }
            // else
            else
            {
                com.CommandText = "update [order] set payment_status='Waiting' Where orderId='" + orderid + "'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();

                com.CommandText = "update [cart] set payment_status='Waiting' Where order_id='" + orderid + "'";
                con.Open();
                com.Connection = con;
                com.ExecuteNonQuery();
                //con.Close();
              // payment not complete yet, may be undergoing additional verification or processing

              // do nothing - wait for paypal to send another IPN when payment is complete
            }
          }       
    }
}