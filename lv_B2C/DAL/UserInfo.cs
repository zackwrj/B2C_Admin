using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL
{
    //UserInfo
    public partial class UserInfo
    {
        #region  Method
        private const string _defaultOrder = "UserID desc ";
      
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "UserInfo");
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lv_B2C.Model.UserInfo model)
        {
            return Merger(model, "UserInfo_ADD");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(lv_B2C.Model.UserInfo model)
        {
            return Merger(model, "UserInfo_Update");
        }

        /// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
        private int Merger(lv_B2C.Model.UserInfo model, string strStoredProcedure)
        {
            try
            {
                SqlParameter[] parameters = {
					            new SqlParameter("@UserID", model.UserID) ,            
	            	            new SqlParameter("@RolesID", model.RolesID) ,            
	            	            new SqlParameter("@UserName", model.UserName) ,            
	            	            new SqlParameter("@Password", model.Password) ,            
	            	            new SqlParameter("@Email", model.Email) ,            
	            	            new SqlParameter("@ApprovedState", model.ApprovedState) ,            
	            	            new SqlParameter("@PasswordQuestion", model.PasswordQuestion) ,            
	            	            new SqlParameter("@PasswordAnswer", model.PasswordAnswer) ,            
	            	            new SqlParameter("@Nick", model.Nick) ,            
	            	            new SqlParameter("@RealName", model.RealName) ,            
	            	            new SqlParameter("@CnName", model.CnName) ,            
	            	            new SqlParameter("@EnName", model.EnName) ,            
	            	            new SqlParameter("@Number", model.Number) ,            
	            	            new SqlParameter("@Images", model.Images) ,            
	            	            new SqlParameter("@AlbumID", model.AlbumID) ,            
	            	            new SqlParameter("@Sex", model.Sex) ,            
	            	            new SqlParameter("@MobilePhone", model.MobilePhone) ,            
	            	            new SqlParameter("@TelPhone", model.TelPhone) ,            
	            	            new SqlParameter("@Detail", model.Detail) ,            
	            	            new SqlParameter("@Country", model.Country) ,            
	            	            new SqlParameter("@Province", model.Province) ,            
	            	            new SqlParameter("@City", model.City) ,            
	            	            new SqlParameter("@Town", model.Town) ,            
	            	            new SqlParameter("@Post", model.Post) ,            
	            	            new SqlParameter("@Address", model.Address) ,            
	            	            new SqlParameter("@SiteID", model.SiteID) ,            
	            	            new SqlParameter("@Birthday", model.Birthday) ,            
	            	            new SqlParameter("@RegTime", model.RegTime) ,            
	            	            new SqlParameter("@LastLoginIP", model.LastLoginIP) ,            
	            	            new SqlParameter("@VisitCount", model.VisitCount) ,            
	            	            new SqlParameter("@IsFirst", model.IsFirst) ,            
	            	            new SqlParameter("@LastLoginDate", model.LastLoginDate) ,            
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
        public int Update(int UserID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserID", UserID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "UserInfo_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(Guid UserID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "UserInfo_Delete", new SqlParameter("@UserID", UserID));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string UserIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "UserInfo_DeleteIDList", new SqlParameter("@UserIDList", UserIDList));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.UserInfo GetModel(Guid UserID)
        {
            try
            {
                IList<lv_B2C.Model.UserInfo> iListUserInfo = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.UserInfo>(CommandType.StoredProcedure, "UserInfo_GetModel", new SqlParameter("@UserID", UserID));
                if (iListUserInfo.Count > 0)
                {
                    return iListUserInfo[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "UserInfo_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.UserInfo> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.UserInfo>(CommandType.StoredProcedure, "UserInfo_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.UserInfo>(CommandType.StoredProcedure, "UserInfo_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.UserInfo> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.UserInfo>(CommandType.StoredProcedure, "UserInfo_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.UserInfo> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }

        private IList<lv_B2C.Model.UserInfo> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.UserInfo>(CommandType.StoredProcedure, "UserInfo_GetListByPage", parameters);
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
