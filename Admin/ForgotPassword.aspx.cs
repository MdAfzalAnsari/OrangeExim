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
        string dataanswer="", useranswer;
        string email=Enter_Email.Text;
        useranswer = answer.Text;  
        cmd.CommandText = "select password from admin_login";
        cmd.Connection = cnn;
        string pass = (string)cmd.ExecuteScalar();
        cmd.CommandText = "select question,answer from admin_login";
        cmd.Connection = cnn;
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
           
                reader.Read();
                quest = reader.GetString(0);
                dataanswer = reader.GetString(1);                                                                             
                reader.Close();
        }
        
        
        
        //MailMessage m = new MailMessage();
        //        m.To.Add(new MailAddress(email));
        //        m.From = new MailAddress("afzal.live@gmail.com");
        //        m.Subject = "Password Recovery";
        //        m.IsBodyHtml = true;
        //        m.Body = "Dear User,<p />Please use the following password to login.<p />Password : " + pass +
        //              "<p />WebMaster,<br />PhoneBook.Com";
        //        SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Send(m);
        //        statuslabel.Text = "Your password was mailed to you. Please use that password and <a href='login.aspx'>login</a>";

        if (dataanswer.Equals(useranswer))
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
            statuslabel.Text = "Please Enter Correct Data";
        }
    }
    
}