using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Logic;
using captcha;
using System.Net.Mail;
using System.Net;
using System.Configuration;

public partial class Admin_ForgotPasswors : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader reader;
    string quest;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            Session["CaptchaImageText"] = CaptchaImageMgr.GenerateRandomCode();

        }
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["OrangeConnectionString"].ConnectionString;
        cnn.Open();
        cmd.CommandText = "select question from admin_login";
        cmd.Connection = cnn;
        quest = (string)cmd.ExecuteScalar();
        if (!IsPostBack)
        {
            question.Text = quest;
        }
        
    }
    protected void getpassword(object sender, EventArgs e)
    {
        bool success = false;
        if (this.Session["CaptchaImageText"] != null)
        {
            //Match captcha text entered by user and the one stored in session
            if (Convert.ToString(this.Session["CaptchaImageText"]) == txtCaptchaText.Text.Trim())
            {
                success = true;
            }
        }
        if (success)
        {
            string useranswer;
            string email = Enter_Email.Text;
            useranswer = answer.Text;
            cmd.CommandText = "select password from customer_login where customer_id='"+email+"'";
            cmd.Connection = cnn;
            string pass = (string)cmd.ExecuteScalar();
            //cmd.CommandText = "select question,answer from admin_login";
            //cmd.Connection = cnn;
            //reader = cmd.ExecuteReader();
            //if (reader.HasRows)
            //{

            //    reader.Read();
            //    quest = reader.GetString(0);
            //    dataanswer = reader.GetString(1);
            //    reader.Close();
            //}
            if (!pass.Equals(null)||pass!="")
            {
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("afzal@globalerainc.com");
                msg.To.Add(email);
                msg.Subject = "Password Recovery";
                msg.IsBodyHtml = true;
                msg.Body = "<p>Dear User,<p/>Please use the following password to login.<p />Password : " + pass +
                           "<p/>";
                //msg.Priority = MailPriority.High;


                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("afzal@globalerainc.com", "afzal261013");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                }
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["CaptchaImageText"] = CaptchaImageMgr.GenerateRandomCode();
                statuslabel.Text = "Please Enter Correct Data";
            }

        }
        else
        {

            //Response.Redirect("contact.aspx");
            Session["CaptchaImageText"] = CaptchaImageMgr.GenerateRandomCode();
            //lblStatus.Visible = true;
            statuslabel.Text = "Incorrect Captcha Try Again";
            statuslabel.ForeColor = System.Drawing.Color.Red;
            //loadgrid();

        }
        
    }
    
}