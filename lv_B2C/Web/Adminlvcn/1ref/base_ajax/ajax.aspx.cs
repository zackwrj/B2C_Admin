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
        /// 获取分类
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

        #region 递归分类
        /// <summary>
        /// 递归类
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
    }
}