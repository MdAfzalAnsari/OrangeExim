using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using System.Net.Mail;
using System.ComponentModel;
using System.Collections.Generic;

namespace Logic
{
    public class CommonLogic
    {
        public CommonLogic()
        {

        }
        public static void CreateDirectory(string strFolder)
        {
            try
            {
                if (!Directory.Exists(strFolder))
                    Directory.CreateDirectory(strFolder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   }
}