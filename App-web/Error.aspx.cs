using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public string error = "Error";
        protected void Page_Load(object sender, EventArgs e)
        {
            error = (string)Session["Error"];
        }
    }
}