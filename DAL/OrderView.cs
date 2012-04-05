using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL
{
    //OrderView
    public partial class OrderView
    {
        #region  Method
        private const string _defaultOrder = "OrderViewID desc ";

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("OrderViewID", "OrderView");
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lv_B2C.Model.OrderView model)
        {
            return Merger(model, "OrderView_ADD");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(lv_B2C.Model.OrderView model)
        {
            return Merger(model, "OrderView_Update");
        }

        /// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
        private int Merger(lv_B2C.Model.OrderView model, string strStoredProcedure)
        {
            try
            {
                SqlParameter[] parameters = {
					            new SqlParameter("@OrderViewID", model.OrderViewID) ,            
	            	            new SqlParameter("@OrderDiscountDetail", model.OrderDiscountDetail) ,            
	            	            new SqlParameter("@OrderUsedBalance", model.OrderUsedBalance) ,            
	            	            new SqlParameter("@OrderUsedIntegral", model.OrderUsedIntegral) ,            
	            	            new SqlParameter("@OrderActualPayMoney", model.OrderActualPayMoney) ,            
	            	            new SqlParameter("@OrderMerchantsModifyPrice", model.OrderMerchantsModifyPrice) ,            
	            	            new SqlParameter("@OrderStatus", model.OrderStatus) ,            
	            	            new SqlParameter("@OrderCreateDate", model.OrderCreateDate) ,            
	            	            new SqlParameter("@TotalPrice", model.TotalPrice) ,            
	            	            new SqlParameter("@Price", model.Price) ,            
	            	            new SqlParameter("@Quantity", model.Quantity) ,            
	            	            new SqlParameter("@OrderNum", model.OrderNum) ,            
	            	            new SqlParameter("@ProductFieldsIDList", model.ProductFieldsIDList) ,            
	            	            new SqlParameter("@ProductName", model.ProductName) ,            
	            	            new SqlParameter("@ProductPics", model.ProductPics) ,            
	            	            new SqlParameter("@FinallyPrice", model.FinallyPrice) ,            
	            	            new SqlParameter("@postage", model.postage) ,            
	            	            new SqlParameter("@ModifiedPostage", model.ModifiedPostage) ,            
	            	            new SqlParameter("@TotalPostage", model.TotalPostage) ,            
	            	            new SqlParameter("@OrderLogisticsNum", model.OrderLogisticsNum) ,            
	            	            new SqlParameter("@UserName", model.UserName) ,            
	            	            new SqlParameter("@OrderTotalPrice", model.OrderTotalPrice) ,            
	            	            new SqlParameter("@OrderProductQuantity", model.OrderProductQuantity) ,            
	            	            new SqlParameter("@OrderPostageDerate", model.OrderPostageDerate) ,            
	            	            new SqlParameter("@OrderPostage", model.OrderPostage) ,            
	            	            new SqlParameter("@OrderDiscount", model.OrderDiscount)             
	              
	            };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcedure, parameters);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.OrderView GetModel(int OrderViewID)
        {
            try
            {
                IList<lv_B2C.Model.OrderView> iListOrderView = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderView>(CommandType.StoredProcedure, "OrderView_GetModel", new SqlParameter("@OrderViewID", OrderViewID));
                if (iListOrderView.Count > 0)
                {
                    return iListOrderView[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@strWhere", strWhere)
                };
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "OrderView_GetRecordCount", parameters));
            }
            catch
            {
                return -1;
            }
        }

        #region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderView>(CommandType.StoredProcedure, "OrderView_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderView>(CommandType.StoredProcedure, "OrderView_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.OrderView> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderView>(CommandType.StoredProcedure, "OrderView_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.OrderView> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }

        private IList<lv_B2C.Model.OrderView> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@orderby", fieldOrder),
                    new SqlParameter("@pageIndex", pageIndex),
                    new SqlParameter("@pageSize", pageSize),
                    new SqlParameter("@pageType", pageType)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderView>(CommandType.StoredProcedure, "OrderView_GetListByPage", parameters);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #endregion Method

    }
}
