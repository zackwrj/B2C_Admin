﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	 	//OrderInfo
		public partial class OrderInfo
	{
		#region  Method
        private const string _defaultOrder = "OrderID desc ";
          			
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("OrderID", "OrderInfo");
        }
     		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lv_B2C.Model.OrderInfo model)
		{
			return Merger(model, "OrderInfo_ADD");	
		}		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(lv_B2C.Model.OrderInfo model)
		{
			 return Merger(model, "OrderInfo_Update");
		}
		
		/// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
		private int Merger(lv_B2C.Model.OrderInfo model, string strStoredProcedure)
        {
        	try
            {
	            SqlParameter[] parameters = {
					            new SqlParameter("@OrderID", model.OrderID) ,            
	            	            new SqlParameter("@UserName", model.UserName) ,            
	            	            new SqlParameter("@OrderNum", model.OrderNum) ,            
	            	            new SqlParameter("@LogisticsNum", model.LogisticsNum) ,            
	            	            new SqlParameter("@Consignee", model.Consignee) ,            
	            	            new SqlParameter("@Province", model.Province) ,            
	            	            new SqlParameter("@City", model.City) ,            
	            	            new SqlParameter("@Town", model.Town) ,            
	            	            new SqlParameter("@Post", model.Post) ,            
	            	            new SqlParameter("@Address", model.Address) ,            
	            	            new SqlParameter("@MobilePhone", model.MobilePhone) ,            
	            	            new SqlParameter("@TelPhone", model.TelPhone) ,            
	            	            new SqlParameter("@Email", model.Email) ,            
	            	            new SqlParameter("@Landmark", model.Landmark) ,            
	            	            new SqlParameter("@BestTime", model.BestTime) ,            
	            	            new SqlParameter("@Logistics", model.Logistics) ,            
	            	            new SqlParameter("@LogisticsDetail", model.LogisticsDetail) ,            
	            	            new SqlParameter("@IsInsure", model.IsInsure) ,            
	            	            new SqlParameter("@Payment", model.Payment) ,            
	            	            new SqlParameter("@PaymentDetail", model.PaymentDetail) ,            
	            	            new SqlParameter("@PayPoundage", model.PayPoundage) ,            
	            	            new SqlParameter("@InvoiceType", model.InvoiceType) ,            
	            	            new SqlParameter("@InvoiceTitle", model.InvoiceTitle) ,            
	            	            new SqlParameter("@InvoiceDetail", model.InvoiceDetail) ,            
	            	            new SqlParameter("@InvoiceCustomersMsg", model.InvoiceCustomersMsg) ,            
	            	            new SqlParameter("@InvoiceMerchantsMsg", model.InvoiceMerchantsMsg) ,            
	            	            new SqlParameter("@InvoiceMoney", model.InvoiceMoney) ,            
	            	            new SqlParameter("@ProductTotalPrice", model.ProductTotalPrice) ,            
	            	            new SqlParameter("@Postage", model.Postage) ,            
	            	            new SqlParameter("@Insurance", model.Insurance) ,            
	            	            new SqlParameter("@PackingMoney", model.PackingMoney) ,            
	            	            new SqlParameter("@CARDSMoney", model.CARDSMoney) ,            
	            	            new SqlParameter("@Discount", model.Discount) ,            
	            	            new SqlParameter("@DiscountDetail", model.DiscountDetail) ,            
	            	            new SqlParameter("@PostageDerate", model.PostageDerate) ,            
	            	            new SqlParameter("@UsedBalance", model.UsedBalance) ,            
	            	            new SqlParameter("@UsedIntegral", model.UsedIntegral) ,            
	            	            new SqlParameter("@ProductQuantity", model.ProductQuantity) ,            
	            	            new SqlParameter("@ProductWeight", model.ProductWeight) ,            
	            	            new SqlParameter("@ActualPayMoney", model.ActualPayMoney) ,            
	            	            new SqlParameter("@MerchantsModifyPrice", model.MerchantsModifyPrice) ,            
	            	            new SqlParameter("@OrderStatus", model.OrderStatus) ,            
	            	            new SqlParameter("@CreateDate", model.CreateDate) ,            
	            	            new SqlParameter("@LastModifyDate", model.LastModifyDate) ,            
	            	            new SqlParameter("@Hits", model.Hits) ,            
	            	            new SqlParameter("@IsShow", model.IsShow) ,            
	            	            new SqlParameter("@Types", model.Types) ,            
	            	            new SqlParameter("@Tag", model.Tag) ,            
	            	            new SqlParameter("@StringValue", model.StringValue) ,            
	            	            new SqlParameter("@IsDel", model.IsDel) ,            
	            	            new SqlParameter("@Sort", model.Sort) ,            
	            	            new SqlParameter("@ExtendID", model.ExtendID)             
	              
	            };			
	            return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcedure, parameters);
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 更新单个字段的值
        /// </summary>
        public int Update(int OrderID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", OrderID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "OrderInfo_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }
				
		/// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int OrderID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "OrderInfo_Delete", new SqlParameter("@OrderID", OrderID));
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string OrderIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "OrderInfo_DeleteIDList", new SqlParameter("@OrderIDList", OrderIDList));
            }
            catch
            {
                return -1;
            }
        }
		
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.OrderInfo GetModel(int OrderID)
        {
	        try
	        {
	            IList<lv_B2C.Model.OrderInfo> iListOrderInfo = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderInfo>(CommandType.StoredProcedure, "OrderInfo_GetModel", new SqlParameter("@OrderID", OrderID));
	            if (iListOrderInfo.Count > 0)
	            {
	                return iListOrderInfo[0];
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
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@strWhere", strWhere)
                };
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "OrderInfo_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.OrderInfo> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderInfo>(CommandType.StoredProcedure, "OrderInfo_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderInfo>(CommandType.StoredProcedure, "OrderInfo_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.OrderInfo> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderInfo>(CommandType.StoredProcedure, "OrderInfo_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.OrderInfo> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }
        
        private IList<lv_B2C.Model.OrderInfo> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderInfo>(CommandType.StoredProcedure, "OrderInfo_GetListByPage", parameters);
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


/*------ 代码生成时出现错误: ------
f:\已安装\动软\Template\TemplateFile\简单三层模板\DAL.cmt(27,43) : warning CS0162: 正在编译转换: 检测到无法访问的代码
f:\已安装\动软\Template\TemplateFile\简单三层模板\DAL.cmt(346,5) : warning CS0414: 正在编译转换: 私有字段“Microsoft.VisualStudio.TextTemplating83DB1929C768C75D65FC119BB59F94AD.GeneratedTextTransformation.n”已被赋值，但从未使用过它的值
*/