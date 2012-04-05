using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;
using System.Text;


namespace lv_B2C.Web.Adminlvcn.ProductManage.ProductField.ajax
{
    public partial class ajax : BLL.Base.BasePageAdmin
    {
        BLL.FieldsClassExt bllFieldClass = new BLL.FieldsClassExt();
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
                string strClass = "", strBrand = "", strTitle = "", strWhere = "";
                if (key != null)
                {   
                    if (strTitle != "")
                    {
                        if (strWhere != "")
                        {
                            strWhere += " and ";
                        }
                        strWhere += " Title like '%" + key + "%'";
                    }
                }

                //分页
                int pageIndex = Convert.ToInt32(Request["pageIndex"]) + 1;
                int pageSize = Convert.ToInt32(Request["pageSize"]);
                //字段排序
                string sortField = Request["sortField"];
                string sortOrder = Request["sortOrder"];

                Hashtable result = bllFieldClass.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
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
        public void RemoveEmployees()
        {
            int id = 0;
            if (Request["id"] != null)
            {
                id = Convert.ToInt32(Request["id"]);
                int rs = bllFieldClass.Delete(id);
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
                int rs = bllFieldClass.DeleteList(Request["id"]);
                if (rs == 1)
                {
                    Response.Write(rs.ToString());
                }
            }
        }

        public void SaveEmployees()
        {
            //String employeesStr = Request["employees"];
            //ArrayList arrayList = (ArrayList)PluSoft.Utils.JSON.Decode(employeesStr);
            //Hashtable hasTab = (Hashtable)arrayList[0];
            //Model.Product modelProduct = bllFieldClass.GetModel(Convert.ToInt32(hasTab["ProductID"]));
            //modelProduct.Title = hasTab["Title"].ToString();
            //modelProduct.ProductMarketPrice = decimal.Parse(hasTab["ProductMarketPrice"].ToString());
            //modelProduct.ProductPrice = decimal.Parse(hasTab["ProductPrice"].ToString());
            //modelProduct.ProductCount = Convert.ToInt32(hasTab["ProductCount"]);
            //modelProduct.IsPostage = Convert.ToInt32(hasTab["IsPostage"]);
            //modelProduct.TimeToMarket = Convert.ToDateTime(hasTab["TimeToMarket"]);
            //bllFieldClass.Update(modelProduct);
        }

        /// <summary>
        /// 获取类别
        /// </summary>
        public void GetFieldClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            IList<Model.FieldsClass> ilist = bllFieldClass.GetList();
            for (int i = 0; i < ilist.Count; i++)
            {
                sb.Append("{id:\"" + ilist[i].FieldsClassID + "\",text:\"" + ilist[i].Title + "\"}");
                if (i < ilist.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            Response.Write(sb.ToString());
        }
    }
}