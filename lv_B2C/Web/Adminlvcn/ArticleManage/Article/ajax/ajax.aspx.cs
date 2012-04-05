using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;

namespace lv_B2C.Web.Adminlvcn.ArticleManage.Article.ajax
{
    public partial class ajax : BLL.Base.BasePageAdmin
    {
        BLL.ArticleExt bllArticle = new BLL.ArticleExt();
        BLL.ArticleConnExt bllArticleConn = new BLL.ArticleConnExt();

        protected void Page_Load(object sender, EventArgs e)
        {
            //AjaxPro.Utility.RegisterTypeForAjax(typeof(List));
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
        ///[AjaxPro.AjaxMethod()]
        public void SearchArticleList()
        {
            try
            {
                //查询条件
                string key = Request["key"];
                string strClass = "", strTitle = "", strWhere = "";
                if (key != null)
                {
                    string[] obj = key.Split(new string[] { "[-($)-]" }, StringSplitOptions.None);
                    strClass = obj[0];
                    strTitle = obj[1];

                    if (strClass != "")
                    {
                        string temp = "";
                        IList<Model.ArticleConn> ilistArticleConn = bllArticleConn.GetList("ArticleClassID in (" + strClass + ")");
                        for (int i = 0; i < ilistArticleConn.Count; i++)
                        {
                            temp += ilistArticleConn[i].ArticleID;
                            if (i < ilistArticleConn.Count - 1)
                            {
                                temp += ",";
                            }
                        }
                        if (temp != "")
                        {
                            strWhere += " ArticleID in (" + temp + ")";
                        }
                        else {
                            Response.Write(null);
                            Response.End();
                        }
                    }
                    if (strTitle != "")
                    {
                        if (strWhere != "")
                        {
                            strWhere += " and ";
                        }
                        strWhere += " Title like '%" + strTitle + "%'";
                    }
                }

                //分页
                int pageIndex = Convert.ToInt32(Request["pageIndex"]) + 1;
                int pageSize = Convert.ToInt32(Request["pageSize"]);
                //字段排序
                string sortField = Request["sortField"];
                string sortOrder = Request["sortOrder"];

                Hashtable result = bllArticle.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
                string json = PluSoft.Utils.JSON.Encode(result);
                Response.Write(json);
            }
            catch (Exception e)
            {
                Response.Write(null);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void RemoveArticles()
        {
            int id = 0;//商品ID
            if (Request["id"] != null)
            {
                id = Convert.ToInt32(Request["id"]);
                int rs = bllArticle.Delete(id);
                if (rs == 1)
                {
                    Response.Write(rs.ToString());
                }
            }
        }

        /// <summary>
        /// 批删除
        /// </summary>
        public void RemoveList()
        {
            if (Request["id"] != null)
            {
                int rs = bllArticle.DeleteList(Request["id"]);
                if (rs == 1)
                {
                    Response.Write(rs.ToString());
                }
            }
        }
        #region 保存文章
        public void SaveArticle()
        {
            try
            {
                String employeesStr = Request["articles"];
                ArrayList arrayList = (ArrayList)PluSoft.Utils.JSON.Decode(employeesStr);
                Hashtable hasTab = (Hashtable)arrayList[0];
                Model.Article modelProduct = bllArticle.GetModel(Convert.ToInt32(hasTab["ArticleID"]));
                modelProduct.Title = hasTab["Title"].ToString();
                modelProduct.Author = hasTab["Author"].ToString();
                modelProduct.ModifyBy = string.IsNullOrEmpty(bp_curUser)?"administrator":bp_curUser;
                modelProduct.LastModifyDate = DateTime.Now;
                modelProduct.Hits = Convert.ToInt32(hasTab["Hits"]);
                modelProduct.IsShow = Convert.ToInt32(hasTab["IsShow"]);
                bllArticle.Update(modelProduct);
            }
            catch
            {

            }
        }
        #endregion
    }
}