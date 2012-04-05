using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;


namespace lv_B2C.Web.Adminlvcn.ProductManage.Product.ajax
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.ProductExt bllProduct = new BLL.ProductExt();
        BLL.ProductConnExt bllProductConn = new BLL.ProductConnExt();

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
                    string[] obj = key.Split(new string[] { "[-($)-]" }, StringSplitOptions.None);
                    strClass = obj[0];
                    strBrand = obj[1];
                    strTitle = obj[2];

                    if (strClass != "")
                    {
                        IList<Model.ProductConn> ilistProductConn = bllProductConn.GetList("ProductClassID in (" + strClass + ")");
                        for (int i = 0; i < ilistProductConn.Count; i++)
                        {
                            strWhere += " productID=" + ilistProductConn[i].ProductID;
                            if (i < ilistProductConn.Count - 1)
                            {
                                strWhere += " or ";
                            }
                        }
                    }
                    if (strBrand != "")
                    {
                        if (strWhere != "")
                        {
                            strWhere += " and ";
                        }
                        strWhere += " ProductBrandID in (" + strBrand + ")";
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

                Hashtable result = bllProduct.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
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
            int id = 0;//商品ID
            if (Request["id"] != null)
            {
                id = Convert.ToInt32(Request["id"]);
                int rs = bllProduct.Delete(id);
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
                int rs = bllProduct.DeleteList(Request["id"]);
                if (rs == 1)
                {
                    Response.Write(rs.ToString());
                }
            }
        }

        public void SaveEmployees()
        {
            try
            {
                String employeesStr = Request["employees"];
                ArrayList arrayList = (ArrayList)PluSoft.Utils.JSON.Decode(employeesStr);
                Hashtable hasTab = (Hashtable)arrayList[0];
                Model.Product modelProduct = bllProduct.GetModel(Convert.ToInt32(hasTab["ProductID"]));
                modelProduct.Title = hasTab["Title"].ToString();
                modelProduct.ProductMarketPrice = decimal.Parse(hasTab["ProductMarketPrice"].ToString());
                modelProduct.ProductPrice = decimal.Parse(hasTab["ProductPrice"].ToString());
                modelProduct.ProductCount = Convert.ToInt32(hasTab["ProductCount"]);
                modelProduct.IsPostage = Convert.ToInt32(hasTab["IsPostage"]);
                modelProduct.TimeToMarket = Convert.ToDateTime(hasTab["TimeToMarket"]);
                bllProduct.Update(modelProduct);
            }
            catch 
            { 
                    
            }
        }
    }
}