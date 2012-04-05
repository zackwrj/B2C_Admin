using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	 	//内容扩展类型表
		public partial class ExtendType
	{
		#region  Method
        private const string _defaultOrder = "ExtendTypeID desc ";
          			
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ExtendTypeID", "ExtendType");
        }
     		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lv_B2C.Model.ExtendType model)
		{
			return Merger(model, "ExtendType_ADD");	
		}		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(lv_B2C.Model.ExtendType model)
		{
			 return Merger(model, "ExtendType_Update");
		}
		
		/// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
		private int Merger(lv_B2C.Model.ExtendType model, string strStoredProcedure)
        {
        	try
            {
	            SqlParameter[] parameters = {
					            new SqlParameter("@ExtendTypeID", model.ExtendTypeID) ,            
	            	            new SqlParameter("@TypeName", model.TypeName) ,            
	            	            new SqlParameter("@TypeName_en", model.TypeName_en) ,            
	            	            new SqlParameter("@TableName", model.TableName) ,            
	            	            new SqlParameter("@Detail", model.Detail) ,            
	            	            new SqlParameter("@CreateDate", model.CreateDate) ,            
	            	            new SqlParameter("@F1_define", model.F1_define) ,            
	            	            new SqlParameter("@F2_define", model.F2_define) ,            
	            	            new SqlParameter("@F3_define", model.F3_define) ,            
	            	            new SqlParameter("@F4_define", model.F4_define) ,            
	            	            new SqlParameter("@F5_define", model.F5_define) ,            
	            	            new SqlParameter("@F6_define", model.F6_define) ,            
	            	            new SqlParameter("@F7_define", model.F7_define) ,            
	            	            new SqlParameter("@F8_define", model.F8_define) ,            
	            	            new SqlParameter("@F9_define", model.F9_define) ,            
	            	            new SqlParameter("@FA_define", model.FA_define) ,            
	            	            new SqlParameter("@FB_define", model.FB_define) ,            
	            	            new SqlParameter("@FC_define", model.FC_define) ,            
	            	            new SqlParameter("@FD_define", model.FD_define) ,            
	            	            new SqlParameter("@FE_define", model.FE_define) ,            
	            	            new SqlParameter("@FF_define", model.FF_define) ,            
	            	            new SqlParameter("@FG_define", model.FG_define) ,            
	            	            new SqlParameter("@FH_define", model.FH_define) ,            
	            	            new SqlParameter("@FI_define", model.FI_define) ,            
	            	            new SqlParameter("@FJ_define", model.FJ_define) ,            
	            	            new SqlParameter("@FK_define", model.FK_define) ,            
	            	            new SqlParameter("@FL_define", model.FL_define) ,            
	            	            new SqlParameter("@FM_define", model.FM_define) ,            
	            	            new SqlParameter("@FN_define", model.FN_define) ,            
	            	            new SqlParameter("@FO_define", model.FO_define) ,            
	            	            new SqlParameter("@FP_define", model.FP_define) ,            
	            	            new SqlParameter("@FQ_define", model.FQ_define) ,            
	            	            new SqlParameter("@FR_define", model.FR_define) ,            
	            	            new SqlParameter("@FS_define", model.FS_define) ,            
	            	            new SqlParameter("@FT_define", model.FT_define) ,            
	            	            new SqlParameter("@FU_define", model.FU_define) ,            
	            	            new SqlParameter("@FV_define", model.FV_define) ,            
	            	            new SqlParameter("@FW_define", model.FW_define) ,            
	            	            new SqlParameter("@FX_define", model.FX_define) ,            
	            	            new SqlParameter("@FY_define", model.FY_define) ,            
	            	            new SqlParameter("@FZ_define", model.FZ_define)             
	              
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
        public int Update(int ExtendTypeID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@ExtendTypeID", ExtendTypeID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ExtendType_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }
				
		/// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ExtendTypeID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ExtendType_Delete", new SqlParameter("@ExtendTypeID", ExtendTypeID));
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string ExtendTypeIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ExtendType_DeleteIDList", new SqlParameter("@ExtendTypeIDList", ExtendTypeIDList));
            }
            catch
            {
                return -1;
            }
        }
		
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.ExtendType GetModel(int ExtendTypeID)
        {
	        try
	        {
	            IList<lv_B2C.Model.ExtendType> iListExtendType = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ExtendType>(CommandType.StoredProcedure, "ExtendType_GetModel", new SqlParameter("@ExtendTypeID", ExtendTypeID));
	            if (iListExtendType.Count > 0)
	            {
	                return iListExtendType[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "ExtendType_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.ExtendType> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ExtendType>(CommandType.StoredProcedure, "ExtendType_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ExtendType>(CommandType.StoredProcedure, "ExtendType_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.ExtendType> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ExtendType>(CommandType.StoredProcedure, "ExtendType_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.ExtendType> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }
        
        private IList<lv_B2C.Model.ExtendType> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ExtendType>(CommandType.StoredProcedure, "ExtendType_GetListByPage", parameters);
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