using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lv_B2C.Web.Adminlvcn.ArticleManage.Article
{
    public partial class Modify : System.Web.UI.Page
    {
        public string PageTitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLoad();
            }
        }

        public void BindLoad()
        {
            if (Request["id"] != null || Request["ids"] != null)
            {
                PageTitle = "编辑商品";
                btnSave.Visible = true;
                btnAdd.Visible = false;
                btnReset.Visible = false;
            }
            else
            {
                PageTitle = "添加商品";
                btnSave.Visible = false;
                btnAdd.Visible = true;
                btnReset.Visible = true;
            }
        }
    }
}