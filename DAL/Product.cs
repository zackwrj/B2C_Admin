using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL
{
    //Product
    public partial class Product
    {
        #region  Method
        private const string _defaultOrder = "ProductID desc ";

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProductID", "Product");
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lv_B2C.Model.Product model)
        {
            return Merger(model, "Product_ADD");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(lv_B2C.Model.Product model)
        {
            return Merger(model, "Product_Update");
        }

        /// <summary>
        /// 执行更新或新增的存储过程
        /// </summary>
        private int Merger(lv_B2C.Model.Product model, string strStoredProcedure)
        {
            try
            {
                SqlParameter[] parameters = {
					            new SqlParameter("@ProductID", model.ProductID) ,            
	            	            new SqlParameter("@Title", model.Title) ,            
	            	            new SqlParameter("@Title_en", model.Title_en) ,            
	            	            new SqlParameter("@Alt", model.Alt) ,            
	            	            new SqlParameter("@Images", model.Images) ,            
	            	            new SqlParameter("@ProductBrandID", model.ProductBrandID) ,            
	            	            new SqlParameter("@ProductCode", model.ProductCode) ,            
	            	            new SqlParameter("@ProductUnit", model.ProductUnit) ,            
	            	            new SqlParameter("@ProductWeight", model.ProductWeight) ,            
	            	            new SqlParameter("@ProductMarketPrice", model.ProductMarketPrice) ,            
	            	            new SqlParameter("@ProductPrice", model.ProductPrice) ,            
	            	            new SqlParameter("@PromotePrice", model.PromotePrice) ,            
	            	            new SqlParameter("@PromoteStartDate", model.PromoteStartDate) ,            
	            	            new SqlParameter("@PromoteEndDate", model.PromoteEndDate) ,            
	            	            new SqlParameter("@ProductKeyWords", model.ProductKeyWords) ,            
	            	            new SqlParameter("@Summary", model.Summary) ,            
	            	            new SqlParameter("@Detail", model.Detail) ,            
	            	            new SqlParameter("@ProductCount", model.ProductCount) ,            
	            	            new SqlParameter("@ApprovedState", model.ApprovedState) ,            
	            	            new SqlParameter("@IsPromote", model.IsPromote) ,            
	            	            new SqlParameter("@IsDiscount", model.IsDiscount) ,            
	            	            new SqlParameter("@IsRecommend", model.IsRecommend) ,            
	            	            new SqlParameter("@IsHot", model.IsHot) ,            
	            	            new SqlParameter("@IsNew", model.IsNew) ,            
	            	            new SqlParameter("@IsSpecialOffer", model.IsSpecialOffer) ,            
	            	            new SqlParameter("@IsPostage", model.IsPostage) ,            
	            	            new SqlParameter("@TimeToMarket", model.TimeToMarket) ,            
	            	            new SqlParameter("@IsActive", model.IsActive) ,            
	            	            new SqlParameter("@Link", model.Link) ,            
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
        public int Update(int ProductID, object fieldName, object fieldValue)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@ProductID", ProductID),                       
					new SqlParameter("@FieldName", fieldName),
					new SqlParameter("@FieldValue",fieldValue)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Product_UpdateField", parameters);
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
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Product_Delete", new SqlParameter("@ProductID", ProductID));
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
                return lv_DBUtility.DBManager.Instance().ExecuteNonQuery(CommandType.StoredProcedure, "Product_DeleteIDList", new SqlParameter("@ProductIDList", ProductIDList));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lv_B2C.Model.Product GetModel(int ProductID)
        {
            try
            {
                IList<lv_B2C.Model.Product> iListProduct = lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Product>(CommandType.StoredProcedure, "Product_GetModel", new SqlParameter("@ProductID", ProductID));
                if (iListProduct.Count > 0)
                {
                    return iListProduct[0];
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
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "Product_GetRecordCount", parameters));
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
        public IList<lv_B2C.Model.Product> GetList()
        {
            return GetList(0, "", _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Product> GetList(string strWhere)
        {
            return GetList(0, strWhere, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.Product> GetList(int top, string strWhere, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Product>(CommandType.StoredProcedure, "Product_GetList", parameters);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListLikeTitle(string strTitle)
        {
            return GetListLikeTitle(0, strTitle, _defaultOrder);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@Title", strTitle),
                    new SqlParameter("@fieldOrder", fieldOrder)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Product>(CommandType.StoredProcedure, "Product_GetListLikeTitle", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListNotIDList(string strIDList)
        {
            return GetListNotIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 0);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListByIDList(string strIDList)
        {
            return GetListByIDList(0, strIDList, _defaultOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return IDListMerger(top, strIDList, fieldOrder, 1);
        }

        private IList<lv_B2C.Model.Product> IDListMerger(int top, string strIDList, string fieldOrder, int inTypes)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@top", top),
                    new SqlParameter("@strIDList", strIDList),
                    new SqlParameter("@fieldOrder", fieldOrder),
                    new SqlParameter("@inTypes", inTypes)
                };
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Product>(CommandType.StoredProcedure, "Product_GetListByIDList", parameters);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.Product> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return PageMerger(strWhere, fieldOrder, pageIndex, pageSize, 1);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public IList<lv_B2C.Model.Product> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return PageMerger(strWhere, fieldOrder, startIndex, endIndex, 0);
        }

        private IList<lv_B2C.Model.Product> PageMerger(string strWhere, string fieldOrder, int pageIndex, int pageSize, int pageType)
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
                return lv_DBUtility.DBManager.Instance().ExecuteReaderList<lv_B2C.Model.Product>(CommandType.StoredProcedure, "Product_GetListByPage", parameters);
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