using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;
using System.Text;

namespace lv_B2C.Web.Adminlvcn.ArticleManage.ProductClass.ajax
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.ArticleClassExt bllArticleClass = new BLL.ArticleClassExt();
        protected void Page_Load(object sender, EventArgs e)
        {
            string methodName = Request["method"];
            if (string.IsNullOrEmpty(methodName)) return;

            //invoke method
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(this, null);
        }

        public void UpdateField()
        {
            int articleClassID = Convert.ToInt32(Request["id"]);
            string articleFName = Request["FName"];
            string articleFval = Request["FVal"];
            bllArticleClass.Update(articleClassID, articleFName, articleFval);
        }

        public void RemoveClass()
        {
            int pid = Convert.ToInt32(Request["Pcd"]);
            int rs = bllArticleClass.Delete(pid);
            Response.Write(rs.ToString());
        }


        StringBuilder sb = new StringBuilder();

        /// <summary>
        /// 获取Json格式的Tree
        /// </summary>
        /// <returns></returns>
        public void GetInputSelectClass()
        {
            sb.Append("[");
            RecursionNav(0);
            sb.Append("]");
            Response.Write(sb.ToString());
        }

        public void UpdateShowOrder()
        { 
            
        }

        #region 递归类
        /// <summary>
        /// 递归类
        /// </summary>
        public void RecursionNav(int topClassID)
        {
            IList<lv_B2C.Model.ArticleClass> listArticleClass = bllArticleClass.GetList("ParentID=" + topClassID);
            for (int i = 0; i < listArticleClass.Count; i++)
            {
                sb.Append("{id: \"" + listArticleClass[i].ArticleClassID
                    + "\", text: \"" + listArticleClass[i].Title  + "\"");

                if (bllArticleClass.HasProductClassSon(listArticleClass[i].ArticleClassID))
                {
                    sb.Append(",children:[");
                    RecursionNav(listArticleClass[i].ArticleClassID);
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