using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;


namespace lv_B2C.Web.Adminlvcn.ChannelItemManage.SiteMenu.ajax
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.ChannelItemExt bllChannelItem = new BLL.ChannelItemExt();

        protected void Page_Load(object sender, EventArgs e)
        {
            string methodName = Request["method"];
            if (String.IsNullOrEmpty(methodName)) return;

            //invoke method
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(this, null);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        public void SearchEmployees()
        {
            try
            {
                //查询条件
                string key = Request["key"];
                string strWhere = "";
                if (key != null)
                {
                    strWhere += " Title like '%" + key + "%'";
                }

                //分页
                int pageIndex = Convert.ToInt32(Request["pageIndex"]) + 1;
                int pageSize = Convert.ToInt32(Request["pageSize"]);
                //字段排序
                string sortField = Request["sortField"];
                string sortOrder = Request["sortOrder"];

                Hashtable result = bllChannelItem.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
                string json = PluSoft.Utils.JSON.Encode(result);
                Response.Write(json);
            }
            catch (Exception e)
            {
                Response.Write(null);
            }
        }

        public void SaveEmployees()
        {
            try
            {
                String employeesStr = Request["employees"];
                ArrayList arrayList = (ArrayList)PluSoft.Utils.JSON.Decode(employeesStr);
                Hashtable hasTab = (Hashtable)arrayList[0];
                Model.ChannelItem modelProduct = bllChannelItem.GetModel(Convert.ToInt32(hasTab["ChannelItemID"]));
                modelProduct.Title = hasTab["Title"].ToString();
                bllChannelItem.Update(modelProduct);
            }
            catch 
            { 
                    
            }
        }
    }
}