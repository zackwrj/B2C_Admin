using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace lv_B2C.Web.Controls
{
    public partial class Editor : System.Web.UI.UserControl
    {
        public string Value
        {
            set { mckeditor.Text = value; }
            get { return mckeditor.Text; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}