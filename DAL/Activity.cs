using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL
{
    //Activity
    public partial class Activity
    {
        #region  Method
        private const string _defaultOrder = "ActivityID desc ";

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ActivityID", "Activity");
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lv_B2C.Model.Activity model)
        {
            return Merger(model, "Activity_ADD");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(lv_B2C.Model.Activity model)
        {
            return Merger(model, "Activity_Update");
        }

        /// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
        private int Merger(lv_B2C.Model.Activity model, string strStoredProcedure)
        {
            try
            {
                SqlParameter[] parameters = {
					            new SqlParameter("@ActivityID", model.ActivityID) ,            
	            	            new SqlParameter("@Title", model.Title) ,            
	            	            new SqlParameter("@Title_en", model.Title_en) ,            
	            	            new SqlParameter("@Alt", model.Alt) ,            
	            	            new SqlParameter("@Images", model.Images) ,            
	            	            new SqlParameter("@StartTime", model.StartTime) ,            
	            	            new SqlParameter("@EndTime", model.EndTime) ,            
	            	            new SqlParameter("@UserRoles", model.UserRoles) ,            
	            	            new SqlParameter("@ActRangeList", model.ActRangeList) ,            
	            	            new SqlParameter("@RangeType", model.RangeType) ,            
	            	            new SqlParameter("@MinAmount", model.MinAmount) ,            
	            	            new SqlParameter("@IsWithDiscount", model.IsWithDiscount) ,            
	            	            new SqlParameter("@AlbumID", model.AlbumID) ,            
	            	            new SqlParameter("@Way", model.Way) ,            
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
        public int Update(int ActivityID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@ActivityID", ActivityID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Activity_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ActivityID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Activity_Delete", new SqlParameter("@ActivityID", ActivityID));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string ActivityIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Activity_DeleteIDList", new SqlParameter("@ActivityIDList", ActivityIDList));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.Activity GetModel(int ActivityID)
        {
            try
            {
                IList<lv_B2C.Model.Activity> iListActivity = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Activity>(CommandType.StoredProcedure, "Activity_GetModel", new SqlParameter("@ActivityID", ActivityID));
                if (iListActivity.Count > 0)
                {
                    return iListActivity[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "Activity_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.Activity> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Activity>(CommandType.StoredProcedure, "Activity_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Activity>(CommandType.StoredProcedure, "Activity_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.Activity> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Activity>(CommandType.StoredProcedure, "Activity_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.Activity> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }

        private IList<lv_B2C.Model.Activity> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Activity>(CommandType.StoredProcedure, "Activity_GetListByPage", parameters);
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

