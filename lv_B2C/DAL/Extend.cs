using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	 	//内容扩展表
		public partial class Extend
	{
		#region  Method
        private const string _defaultOrder = "ExtendID desc ";
          			
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ExtendID", "Extend");
        }
     		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lv_B2C.Model.Extend model)
		{
			return Merger(model, "Extend_ADD");	
		}		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(lv_B2C.Model.Extend model)
		{
			 return Merger(model, "Extend_Update");
		}
		
		/// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
		private int Merger(lv_B2C.Model.Extend model, string strStoredProcedure)
        {
        	try
            {
	            SqlParameter[] parameters = {
					            new SqlParameter("@ExtendID", model.ExtendID) ,            
	            	            new SqlParameter("@ExtendTypeID", model.ExtendTypeID) ,            
	            	            new SqlParameter("@F1", model.F1) ,            
	            	            new SqlParameter("@F2", model.F2) ,            
	            	            new SqlParameter("@F3", model.F3) ,            
	            	            new SqlParameter("@F4", model.F4) ,            
	            	            new SqlParameter("@F5", model.F5) ,            
	            	            new SqlParameter("@F6", model.F6) ,            
	            	            new SqlParameter("@F7", model.F7) ,            
	            	            new SqlParameter("@F8", model.F8) ,            
	            	            new SqlParameter("@F9", model.F9) ,            
	            	            new SqlParameter("@FA", model.FA) ,            
	            	            new SqlParameter("@FB", model.FB) ,            
	            	            new SqlParameter("@FC", model.FC) ,            
	            	            new SqlParameter("@FD", model.FD) ,            
	            	            new SqlParameter("@FE", model.FE) ,            
	            	            new SqlParameter("@FF", model.FF) ,            
	            	            new SqlParameter("@FG", model.FG) ,            
	            	            new SqlParameter("@FH", model.FH) ,            
	            	            new SqlParameter("@FI", model.FI) ,            
	            	            new SqlParameter("@FJ", model.FJ) ,            
	            	            new SqlParameter("@FK", model.FK) ,            
	            	            new SqlParameter("@FL", model.FL) ,            
	            	            new SqlParameter("@FM", model.FM) ,            
	            	            new SqlParameter("@FN", model.FN) ,            
	            	            new SqlParameter("@FO", model.FO) ,            
	            	            new SqlParameter("@FP", model.FP) ,            
	            	            new SqlParameter("@FQ", model.FQ) ,            
	            	            new SqlParameter("@FR", model.FR) ,            
	            	            new SqlParameter("@FS", model.FS) ,            
	            	            new SqlParameter("@FT", model.FT) ,            
	            	            new SqlParameter("@FU", model.FU) ,            
	            	            new SqlParameter("@FV", model.FV) ,            
	            	            new SqlParameter("@FW", model.FW) ,            
	            	            new SqlParameter("@FX", model.FX) ,            
	            	            new SqlParameter("@FY", model.FY) ,            
	            	            new SqlParameter("@FZ", model.FZ)             
	              
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
        public int Update(int ExtendID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@ExtendID", ExtendID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Extend_UpdateField", parameters);
            }
            catch
            {
                return -1;
            }
        }
				
		/// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ExtendID)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Extend_Delete", new SqlParameter("@ExtendID", ExtendID));
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string ExtendIDList)
        {
            try
            {
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Extend_DeleteIDList", new SqlParameter("@ExtendIDList", ExtendIDList));
            }
            catch
            {
                return -1;
            }
        }
		
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.Extend GetModel(int ExtendID)
        {
	        try
	        {
	            IList<lv_B2C.Model.Extend> iListExtend = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Extend>(CommandType.StoredProcedure, "Extend_GetModel", new SqlParameter("@ExtendID", ExtendID));
	            if (iListExtend.Count > 0)
	            {
	                return iListExtend[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "Extend_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.Extend> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Extend>(CommandType.StoredProcedure, "Extend_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Extend>(CommandType.StoredProcedure, "Extend_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.Extend> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Extend>(CommandType.StoredProcedure, "Extend_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.Extend> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }
        
        private IList<lv_B2C.Model.Extend> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Extend>(CommandType.StoredProcedure, "Extend_GetListByPage", parameters);
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