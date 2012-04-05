using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;
using System.Text;
namespace lv_B2C.Web.Adminlvcn._1ref.base_ajax
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.ProductClassExt bllProductClass = new BLL.ProductClassExt();
        BLL.ProductBrandExt bllProductBrand = new BLL.ProductBrandExt();
        BLL.ArticleClassExt bllArticleClass = new BLL.ArticleClassExt();

        protected void Page_Load(object sender, EventArgs e)
        {
            string methodName = Request["method"];
            if (String.IsNullOrEmpty(methodName)) return;

            //invoke method
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(this, null);
        }

        StringBuilder sb = new StringBuilder();

        /// <summary>
        /// 获取产品分类
        /// </summary>
        /// <returns></returns>
        public void GetInputSelectClass()
        {
            sb.Append("[");
            RecursionNav(0);
            sb.Append("]");
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 获取文章分类
        /// </summary>
        /// <returns></returns>
        public void GetArticleInputSelectClass()
        {
            sb.Append("[");
            RecursionArticleNav(0);
            sb.Append("]");
            Response.Write(sb.ToString());
        }

        /// <summary>
        /// 获取品牌
        /// </summary>
        public void GetSelectBrand()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            IList<Model.ProductBrand> ilist = bllProductBrand.GetList();
            for (int i = 0; i < ilist.Count; i++)
            {
                sb.Append("{id:\"" + ilist[i].ProductBrandID + "\",text:\"" + ilist[i].Title + "\"}");
                if (i < ilist.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            Response.Write(sb.ToString());
        }

        #region 递归产品分类
        /// <summary>
        /// 递归产品类
        /// </summary>
        /// <summary>
        public void RecursionNav(int topClassID)
        {
            IList<lv_B2C.Model.ProductClass> listProductClass = bllProductClass.GetList("ParentID=" + topClassID);
            for (int i = 0; i < listProductClass.Count; i++)
            {
                sb.Append("{id: \"" + listProductClass[i].ProductClassID
                    + "\", text: \"" + listProductClass[i].Title + "\"");

                if (bllProductClass.HasProductClassSon(listProductClass[i].ProductClassID))
                {
                    sb.Append(",children:[");
                    RecursionNav(listProductClass[i].ProductClassID);
                    sb.Append("]");
                }
                if (i < listProductClass.Count - 1)
                {
                    sb.Append("},");
                }
                else
                {
                    sb.Append("}");
                }
            }
        }
        #endregion
        #region 递归文章分类
        /// <summary>
        /// 递归文章类
        /// </summary>
        /// <summary>
        public void RecursionArticleNav(int topClassID)
        {
            IList<lv_B2C.Model.ArticleClass> listArticleClass = bllArticleClass.GetList("ParentID=" + topClassID);
            for (int i = 0; i < listArticleClass.Count; i++)
            {
                sb.Append("{id: \"" + listArticleClass[i].ArticleClassID
                    + "\", text: \"" + listArticleClass[i].Title + "\"");

                if (bllArticleClass.HasArticleClassSon(listArticleClass[i].ArticleClassID))
                {
                    sb.Append(",children:[");
                    RecursionArticleNav(listArticleClass[i].ArticleClassID);
                    sb.Append("]");
                }
                if (i < listArticleClass.Count - 1)
                {
                    sb.Append("},");
                }
                else
                {
                    sb.Append("}");
                }
            }
        }
        #endregion
    }
}