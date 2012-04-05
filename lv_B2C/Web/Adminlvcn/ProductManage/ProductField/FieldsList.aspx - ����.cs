using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lv_B2C.Web.Adminlvcn.ProductManage.ProductField
{
    public partial class FieldsList : System.Web.UI.Page
    {
        public string cid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cid = Request["cid"];
        }
    }
}