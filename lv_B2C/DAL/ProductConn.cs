using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL
{
    //ProductConn
    public partial class ProductConn
    {
        #region  Method
        private const string _defaultOrder = "ProductID desc ";

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProductID", "ProductConn");
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lv_B2C.Model.ProductConn model)
        {
            return Merger(model, "ProductConn_ADD");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(lv_B2C.Model.ProductConn model)
        {
            return Merger(model, "ProductConn_Update");
        }

        /// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
        private int Merger(lv_B2C.Model.ProductConn model, string strStoredProcedure)
        {
            try
            {
                SqlParameter[] parameters = {
					            new SqlParameter("@ProductID", model.ProductID) ,            
	            	            new SqlParameter("@ProductClassID", model.ProductClassID) ,            
	            	            new SqlParameter("@ProductFieldID", model.ProductFieldID)             
	              
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
        public int Update(int ProductID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@ProductID", ProductID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ProductConn_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ProductID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ProductConn_Delete", new SqlParameter("@ProductID", ProductID));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string ProductIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ProductConn_DeleteIDList", new SqlParameter("@ProductIDList", ProductIDList));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.ProductConn GetModel(int ProductID)
        {
            try
            {
                IList<lv_B2C.Model.ProductConn> iListProductConn = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ProductConn>(CommandType.StoredProcedure, "ProductConn_GetModel", new SqlParameter("@ProductID", ProductID));
                if (iListProductConn.Count > 0)
                {
                    return iListProductConn[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "ProductConn_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.ProductConn> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ProductConn>(CommandType.StoredProcedure, "ProductConn_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ProductConn>(CommandType.StoredProcedure, "ProductConn_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.ProductConn> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ProductConn>(CommandType.StoredProcedure, "ProductConn_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.ProductConn> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }

        private IList<lv_B2C.Model.ProductConn> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ProductConn>(CommandType.StoredProcedure, "ProductConn_GetListByPage", parameters);
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
