using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	 	//ArticleConn
		public partial class ArticleConn
	{
        //#region  Method
        //private const string _defaultOrder = " desc ";
          			
        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //    return DbHelperSQL.GetMaxID("", "ArticleConn");
        //}
        
        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public int Exists()
        //{
        //    return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ArticleConn_Exists", new SqlParameter("@", ));
        //}		
		
        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(lv_B2C.Model.ArticleConn model)
        //{
        //    return Merger(model, "ArticleConn_ADD");	
        //}		
		
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int Update(lv_B2C.Model.ArticleConn model)
        //{
        //     return Merger(model, "ArticleConn_Update");
        //}
		
        ///// <summary>
        ///// 执行更新或新增的存储过程
        ///// </summary>
        //private int Merger(lv_B2C.Model.ArticleConn model, string strStoredProcedure)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = {
        //                        new SqlParameter("@ArticleID", model.ArticleID) ,            
        //                        new SqlParameter("@ArticleClassID", model.ArticleClassID)             
	              
        //        };			
        //        return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcedure, parameters);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}
        
        ///// <summary>
        ///// 更新单个字段的值
        ///// </summary>
        //public int Update(int , object fieldName, object fieldValue)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = {
        //            new SqlParameter("@", ),                       
        //            new SqlParameter("@FieldName", fieldName),
        //            new SqlParameter("@FieldValue",fieldValue)
        //        };
        //        return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ArticleConn_UpdateField", parameters);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}
				
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public int Delete()
        //{
        //    try
        //    {
        //        return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ArticleConn_Delete", new SqlParameter("@", ));
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}
        
        ///// <summary>
        ///// 批量删除数据
        ///// </summary>
        //public int DeleteList(string List)
        //{
        //    try
        //    {
        //        return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "ArticleConn_DeleteIDList", new SqlParameter("@List", List));
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}
		
        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public lv_B2C.Model.ArticleConn GetModel()
        //{
        //    try
        //    {
        //        IList<lv_B2C.Model.ArticleConn> iListArticleConn = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ArticleConn>(CommandType.StoredProcedure, "ArticleConn_GetModel", new SqlParameter("@", ));
        //        if (iListArticleConn.Count > 0)
        //        {
        //            return iListArticleConn[0];
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }            
        //    catch
        //    {
        //        return null;
        //    }
        //}
        
        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = { 
        //            new SqlParameter("@strWhere", strWhere)
        //        };
        //        return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "ArticleConn_GetRecordCount", parameters));
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}
		
        //#region 获得数据列表
		
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetList()
        //{
        //    return GetList(0, "", _defaultOrder);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetList(string strWhere)
        //{
        //    return GetList(0, strWhere, _defaultOrder);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetList(int top, string strWhere, string fieldOrder)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = { 
        //            new SqlParameter("@top", top),
        //            new SqlParameter("@strWhere", strWhere),
        //            new SqlParameter("@fieldOrder", fieldOrder)
        //        };
        //        return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ArticleConn>(CommandType.StoredProcedure, "ArticleConn_GetList", parameters);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        
        ///// <summary>
        ///// 获得数据列表-模糊搜索Title
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetListLikeTitle(string strTitle)
        //{
        //    return GetListLikeTitle(0, strTitle, _defaultOrder);
        //}
        ///// <summary>
        ///// 获得数据列表-模糊搜索Title
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = { 
        //            new SqlParameter("@top", top),
        //            new SqlParameter("@Title", strTitle),
        //            new SqlParameter("@fieldOrder", fieldOrder)
        //        };
        //        return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ArticleConn>(CommandType.StoredProcedure, "ArticleConn_GetListLikeTitle", parameters);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        
        ///// <summary>
        ///// 获得数据列表-根据ID集合
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetListByIDList(string strIDList)
        //{
        //    return GetListByIDList(0, strIDList, _defaultOrder);
        //}
        ///// <summary>
        ///// 获得数据列表-根据ID集合
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetListByIDList(int top, string strIDList, string fieldOrder)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = { 
        //            new SqlParameter("@top", top),
        //            new SqlParameter("@Title", strIDList),
        //            new SqlParameter("@fieldOrder", fieldOrder)
        //        };
        //        return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ArticleConn>(CommandType.StoredProcedure, "ArticleConn_GetListByIDList", parameters);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        
        ///// <summary>
        ///// 数据分页
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        //{
        //    return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        //}

        ///// <summary>
        ///// 分页获取数据
        ///// </summary>
        //public IList<lv_B2C.Model.ArticleConn> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        //{
        //    return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        //}
        
        //private IList<lv_B2C.Model.KeyWords> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
        //{
        //    try
        //    {
        //        SqlParameter[] parameters = { 
        //            new SqlParameter("@strWhere", strWhere),
        //            new SqlParameter("@orderby", fieldOrder),
        //            new SqlParameter("@pageIndex", pageIndex),
        //            new SqlParameter("@pageSize", pageSize),
        //            new SqlParameter("@pageType", pageType)
        //        };
        //        return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.ArticleConn>(CommandType.StoredProcedure, "ArticleConn_GetListByPage", parameters);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
		
        //#endregion
		
        //#endregion Method
		
	}
}


/*------ 代码生成时出现错误: ------
f:\已安装\动软\Template\TemplateFile\简单三层模板\DAL.cmt(323,5) : warning CS0414: 正在编译转换: 私有字段“Microsoft.VisualStudio.TextTemplating082940C45DCDF73293FBA634ED713B98.GeneratedTextTransformation.n”已被赋值，但从未使用过它的值
*/