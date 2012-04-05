﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	 	//广告表
		public partial class Ad
	{
		#region  Method
        private const string _defaultOrder = "AdID desc ";
          			
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("AdID", "Ad");
        }
     		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lv_B2C.Model.Ad model)
		{
			return Merger(model, "Ad_ADD");	
		}		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(lv_B2C.Model.Ad model)
		{
			 return Merger(model, "Ad_Update");
		}
		
		/// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
		private int Merger(lv_B2C.Model.Ad model, string strStoredProcedure)
        {
        	try
            {
	            SqlParameter[] parameters = {
					            new SqlParameter("@AdID", model.AdID) ,            
	            	            new SqlParameter("@AdPositionID", model.AdPositionID) ,            
	            	            new SqlParameter("@AdType", model.AdType) ,            
	            	            new SqlParameter("@AdProperty", model.AdProperty) ,            
	            	            new SqlParameter("@Title", model.Title) ,            
	            	            new SqlParameter("@Title_en", model.Title_en) ,            
	            	            new SqlParameter("@Detail", model.Detail) ,            
	            	            new SqlParameter("@ApprovedState", model.ApprovedState) ,            
	            	            new SqlParameter("@ApprovedTimeList", model.ApprovedTimeList) ,            
	            	            new SqlParameter("@Price", model.Price) ,            
	            	            new SqlParameter("@BeginDate", model.BeginDate) ,            
	            	            new SqlParameter("@EndDate", model.EndDate) ,            
	            	            new SqlParameter("@BeginTime", model.BeginTime) ,            
	            	            new SqlParameter("@EndTime", model.EndTime) ,            
	            	            new SqlParameter("@ImgUrl", model.ImgUrl) ,            
	            	            new SqlParameter("@flashUrl", model.flashUrl) ,            
	            	            new SqlParameter("@TxtContent", model.TxtContent) ,            
	            	            new SqlParameter("@CodeContent", model.CodeContent) ,            
	            	            new SqlParameter("@Link", model.Link) ,            
	            	            new SqlParameter("@OpenMode", model.OpenMode) ,            
	            	            new SqlParameter("@AlbumID", model.AlbumID) ,            
	            	            new SqlParameter("@ReviewType", model.ReviewType) ,            
	            	            new SqlParameter("@UserName", model.UserName) ,            
	            	            new SqlParameter("@CreateBy", model.CreateBy) ,            
	            	            new SqlParameter("@CreateDate", model.CreateDate) ,            
	            	            new SqlParameter("@Hits", model.Hits) ,            
	            	            new SqlParameter("@SiteID", model.SiteID) ,            
	            	            new SqlParameter("@IsShow", model.IsShow) ,            
	            	            new SqlParameter("@IsDel", model.IsDel) ,            
	            	            new SqlParameter("@Types", model.Types) ,            
	            	            new SqlParameter("@Sort", model.Sort) ,            
	            	            new SqlParameter("@Tag", model.Tag) ,            
	            	            new SqlParameter("@StringValue", model.StringValue) ,            
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
        public int Update(int AdID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@AdID", AdID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Ad_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }
				
		/// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int AdID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Ad_Delete", new SqlParameter("@AdID", AdID));
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string AdIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Ad_DeleteIDList", new SqlParameter("@AdIDList", AdIDList));
            }
            catch
            {
                return -1;
            }
        }
		
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.Ad GetModel(int AdID)
        {
	        try
	        {
	            IList<lv_B2C.Model.Ad> iListAd = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Ad>(CommandType.StoredProcedure, "Ad_GetModel", new SqlParameter("@AdID", AdID));
	            if (iListAd.Count > 0)
	            {
	                return iListAd[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "Ad_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.Ad> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Ad>(CommandType.StoredProcedure, "Ad_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Ad>(CommandType.StoredProcedure, "Ad_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.Ad> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Ad>(CommandType.StoredProcedure, "Ad_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.Ad> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }
        
        private IList<lv_B2C.Model.Ad> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Ad>(CommandType.StoredProcedure, "Ad_GetListByPage", parameters);
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