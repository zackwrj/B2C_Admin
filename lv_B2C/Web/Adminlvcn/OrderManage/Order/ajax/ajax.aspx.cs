using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;


namespace lv_B2C.Web.Adminlvcn.OrderManage.Order.ajax
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.OrderInfoExt bllOrderInfo = new BLL.OrderInfoExt();
        BLL.OrderProductExt bllOrderProduct = new BLL.OrderProductExt();

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
                   strWhere += " Title like '%" + strTitle + "%'";                  
                }

                //分页
                int pageIndex = Convert.ToInt32(Request["pageIndex"]) + 1;
                int pageSize = Convert.ToInt32(Request["pageSize"]);
                //字段排序
                string sortField = Request["sortField"];
                string sortOrder = Request["sortOrder"];

                Hashtable result = bllOrderInfo.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
                string json = PluSoft.Utils.JSON.Encode(result);
                Response.Write(json);
            }
            catch (Exception e)
            {
                Response.Write(null);
            }
        }

        /// <summary>
        /// 查出此订单中的商品
        /// </summary>
        public void GetOrderProduct()
        {
            //查询条件
            string key = Request["key1"],strWhere="";
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

            Hashtable result = bllOrderProduct.GetHashList(strWhere, sortField + " " + sortOrder, pageIndex, pageSize);
            string json = PluSoft.Utils.JSON.Encode(result);
            Response.Write(json);
        }

        
        /// <summary>
        /// 得到订单信息
        /// </summary>
        public void GetModel()
        {
            string strId = Request["id"];

            Model.OrderInfo modelOrder = bllOrderInfo.GetModel(Convert.ToInt32(strId));
            //modelOrder.CreateDate = Convert.ToDateTime(modelOrder.CreateDate.ToString("yyyy-MM-dd HH:mm")); //格式化时间
            IList<Model.OrderProduct> listOrderProduct = bllOrderProduct.GetList("OrderNum='" + modelOrder.OrderNum + "'");
            Hashtable ht = new Hashtable();
            ht["Order"] = modelOrder;
            ht["Product"] = listOrderProduct;
            string json = PluSoft.Utils.JSON.Encode(ht);
            Response.Write(json);
        }

        //public void GetPositionsByDepartmenId()
        //{
        //    string id = Request["id"];
        //    ArrayList data = new TestDB().GetPositionsByDepartmenId(id);
        //    String json = PluSoft.Utils.JSON.Encode(data);
        //    Response.Write(json);
        //}


        /// <summary>
        /// 删除
        /// </summary>
        public void RemoveEmployees()
        {
            int id = 0;//商品ID
            if (Request["id"] != null)
            {
                id = Convert.ToInt32(Request["id"]);
                int rs = bllOrderInfo.Delete(id);
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
                int rs = bllOrderInfo.DeleteList(Request["id"]);
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
                //String employeesStr = Request["employees"];
                //ArrayList arrayList = (ArrayList)PluSoft.Utils.JSON.Decode(employeesStr);
                //Hashtable hasTab = (Hashtable)arrayList[0];
                //Model.Product modelProduct = bllProduct.GetModel(Convert.ToInt32(hasTab["ProductID"]));
                //modelProduct.Title = hasTab["Title"].ToString();
                //modelProduct.ProductMarketPrice = decimal.Parse(hasTab["ProductMarketPrice"].ToString());
                //modelProduct.ProductPrice = decimal.Parse(hasTab["ProductPrice"].ToString());
                //modelProduct.ProductCount = Convert.ToInt32(hasTab["ProductCount"]);
                //modelProduct.IsPostage = Convert.ToInt32(hasTab["IsPostage"]);
                //modelProduct.TimeToMarket = Convert.ToDateTime(hasTab["TimeToMarket"]);
                //bllProduct.Update(modelProduct);
            }
            catch 
            { 
                    
            }
        }
    }
}