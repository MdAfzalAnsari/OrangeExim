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
using System.Drawing.Imaging;
using captcha;

public partial class JpegImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CaptchaImageText"] == null)
            return;
        CaptchaImageMgr ci = null;

        if (Request.QueryString["reloadCaptcha"] == "true")
        {
            Session["CaptchaImageText"] = CaptchaImageMgr.GenerateRandomCode();
            ci = new CaptchaImageMgr(this.Session["CaptchaImageText"].ToString(), 250, 50, "Tahoma");
        }
        else
        {
            // Create a CAPTCHA image using the text stored in the Session object.
            ci = new CaptchaImageMgr(this.Session["CaptchaImageText"].ToString(), 250, 50, "Tahoma");
        }

        // Change the response headers to output a JPEG image.
        this.Response.Clear();
        this.Response.ContentType = "image/jpeg";

        // Write the image to the response stream in JPEG format.
        ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

        // Dispose of the CAPTCHA image object.
        ci.Dispose();
    }
}
