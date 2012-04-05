using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	 	//OrderLog
		public partial class OrderLog
	{
		#region  Method
        private const string _defaultOrder = "LogID desc ";
          			
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("LogID", "OrderLog");
        }
     		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lv_B2C.Model.OrderLog model)
		{
			return Merger(model, "OrderLog_ADD");	
		}		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(lv_B2C.Model.OrderLog model)
		{
			 return Merger(model, "OrderLog_Update");
		}
		
		/// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
		private int Merger(lv_B2C.Model.OrderLog model, string strStoredProcedure)
        {
        	try
            {
	            SqlParameter[] parameters = {
					            new SqlParameter("@LogID", model.LogID) ,            
	            	            new SqlParameter("@OrderID", model.OrderID) ,            
	            	            new SqlParameter("@OperateBy", model.OperateBy) ,            
	            	            new SqlParameter("@OperateDate", model.OperateDate) ,            
	            	            new SqlParameter("@OperateDetail", model.OperateDetail)             
	              
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
        public int Update(int LogID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@LogID", LogID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "OrderLog_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }
				
		/// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int LogID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "OrderLog_Delete", new SqlParameter("@LogID", LogID));
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string LogIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "OrderLog_DeleteIDList", new SqlParameter("@LogIDList", LogIDList));
            }
            catch
            {
                return -1;
            }
        }
		
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.OrderLog GetModel(int LogID)
        {
	        try
	        {
	            IList<lv_B2C.Model.OrderLog> iListOrderLog = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderLog>(CommandType.StoredProcedure, "OrderLog_GetModel", new SqlParameter("@LogID", LogID));
	            if (iListOrderLog.Count > 0)
	            {
	                return iListOrderLog[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "OrderLog_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.OrderLog> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderLog>(CommandType.StoredProcedure, "OrderLog_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderLog>(CommandType.StoredProcedure, "OrderLog_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.OrderLog> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderLog>(CommandType.StoredProcedure, "OrderLog_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.OrderLog> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }
        
        private IList<lv_B2C.Model.OrderLog> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.OrderLog>(CommandType.StoredProcedure, "OrderLog_GetListByPage", parameters);
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