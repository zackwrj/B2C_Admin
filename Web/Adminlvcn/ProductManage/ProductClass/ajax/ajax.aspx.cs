using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;
using System.Text;

namespace lv_B2C.Web.Adminlvcn.ProductManage.ProductClass.ajax
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.ProductClassExt bllProductClass = new BLL.ProductClassExt();
        protected void Page_Load(object sender, EventArgs e)
        {
            string methodName = Request["method"];
            if (String.IsNullOrEmpty(methodName)) return;

            //invoke method
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(this, null);
        }

        public void UpdateField()
        {
            int proClassID = Convert.ToInt32(Request["id"]);
            string proFName = Request["FName"];
            string proFval = Request["FVal"];
            bllProductClass.Update(proClassID, proFName, proFval);
        }

        public void RemoveClass()
        {
            int pid = Convert.ToInt32(Request["Pcd"]);
            int rs = bllProductClass.Delete(pid);
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
        /// <summary>
        public void RecursionNav(int topClassID)
        {
            IList<lv_B2C.Model.ProductClass> listProductClass = bllProductClass.GetList("ParentID=" + topClassID);
            for (int i = 0; i < listProductClass.Count; i++)
            {
                sb.Append("{id: \"" + listProductClass[i].ProductClassID
                    + "\", text: \"" + listProductClass[i].Title  + "\"");

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