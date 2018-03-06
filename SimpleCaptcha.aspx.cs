using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class SimpleCaptcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //UpdateCaptchaText();
        }
    }
    
    

    protected void btnReGenerate_Click(object sender, EventArgs e)
    {
        
    }

    //private void UpdateCaptchaText()
    //{
    //    Label1.Text = string.Empty;
    //    Label1.Visible = false;
        
    //    //Store the captcha text in session to validate
    //    Session["Captcha"] = Guid.NewGuid().ToString().Substring(0, 6);

    //}
    protected void Button2_Click(object sender, EventArgs e)
    {
       // Response.Redirect("Default.aspx");
        System.Threading.Thread.Sleep(3000);
        Label1.Text = "Panel refreshed at " +
        DateTime.Now.ToString();      
        //UpdateCaptchaText();
        //UpdatePanel1.Update();

    }
    
}
