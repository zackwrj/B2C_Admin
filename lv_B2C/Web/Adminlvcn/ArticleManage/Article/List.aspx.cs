using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace lv_B2C.Web.Adminlvcn.ArticleManage.Article
{
    public partial class List : BLL.Base.BasePageAdmin
    {
        BLL.ArticleExt bllArticle = new BLL.ArticleExt();
        BLL.ArticleConnExt bllArticleConn = new BLL.ArticleConnExt();
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(List));
            string methodName = Request["method"];
            if (string.IsNullOrEmpty(methodName)) return;

            //invoke method
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(this, null);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        //[AjaxPro.AjaxMethod()]
        //public void SearchArticleList()
        //{
        //    try
        //    {
        //        //查询条件
        //        string key = Request["key"];
        //        string strClass = "", strBrand = "", strTitle = "", strWhere = "";
        //        if (key != null)
        //        {
        //            string[] obj = key.Split(new string[] { "[-($)-]" }, StringSplitOptions.None);
        //            strClass = obj[0];
        //            strTitle = obj[1];

        //            if (strClass != "")
        //            {
        //                IList<Model.ProductConn> ilistProductConn = bllArticleConn("ProductClassID in (" + strClass + ")");
        //                for (int i = 0; i < ilistProductConn.Count; i++)
        //                {
        //                    strWhere += " productID=" + ilistProductConn[i].ProductID;
        //                    if (i < ilistProductConn.Count - 1)
        //                    {
        //                        strWhere += " or ";
        //                    }
        //                }
        //            }
        //            if (strBrand != "")
        //            {
        //                if (strWhere != "")
        //                {
        //                    strWhere += " and ";
        //                }
        //                strWhere += " ProductBrandID in (" + strBrand + ")";
        //            }
        //            if (strTitle != "")
        //            {
        //                if (strWhere != "")
        //                {
        //                    strWhere += " and ";
        //                }
        //                strWhere += " Title like '%" + strTitle + "%'";
        //            }
        //        }

        //        //分页
        //        int pageIndex = Convert.ToInt32(Request["pageIndex"]) + 1;
        //        int pageSize = Convert.ToInt32(Request["pageSize"]);
        //        //字段排序
        //        string sortField = Request["sortField"];
        //        string sortOrder = Request["sortOrder"];

        //        Hashtable result = bllProduct.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
        //        string json = PluSoft.Utils.JSON.Encode(result);
        //        Response.Write(json);
        //    }
        //    catch (Exception e)
        //    {
        //        Response.Write(null);
        //    }
        //}
        }
}