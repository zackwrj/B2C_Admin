﻿using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using lv_Common;
using lv_B2C.Model;
namespace lv_B2C.BLL {
	 	//ProductBrand
		public partial class ProductBrand
	{
   		     
		private readonly lv_B2C.DAL.ProductBrand dal=new lv_B2C.DAL.ProductBrand();
		
		protected ProductBrand()
		{}
		#region  Method
		
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lv_B2C.Model.ProductBrand model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(lv_B2C.Model.ProductBrand model)
		{
			return dal.Update(model);
		}
		
		/// <summary>
        /// 更新单个字段的值
        /// </summary>
        public int Update(int ProductBrandID, object fieldName, object fieldValue)
        {
            return dal.Update(ProductBrandID, fieldName, fieldValue);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ProductBrandID)
		{
			return dal.Delete(ProductBrandID);
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public int DeleteList(string ProductBrandIDList )
		{
			return dal.DeleteList(ProductBrandIDList );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lv_B2C.Model.ProductBrand GetModel(int ProductBrandID)
		{			
			return dal.GetModel(ProductBrandID);
		}

		/// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
		
		#region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetList(int top, string strWhere, string fieldOrder)
        {
            return dal.GetList(top, strWhere, fieldOrder);
        }

        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListLikeTitle(string strTitle)
        {
            return dal.GetListLikeTitle(strTitle);
        }
        /// <summary>
        /// 获得数据列表-模糊搜索Title
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListLikeTitle(int top, string strTitle, string fieldOrder)
        {
            return dal.GetListLikeTitle(top, strTitle, fieldOrder);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListNotIDList(string strIDList)
        {
            return dal.GetListNotIDList(strIDList);
        }

        /// <summary>
        /// 获得数据列表-id not in (1,2,3)
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListNotIDList(int top, string strIDList, string fieldOrder)
        {
            return dal.GetListNotIDList(top, strIDList, fieldOrder);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListByIDList(string strIDList)
        {
            return dal.GetListByIDList(strIDList);
        }

        /// <summary>
        /// 获得数据列表-根据ID集合（id in (1,2,3)）
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListByIDList(int top, string strIDList, string fieldOrder)
        {
            return dal.GetListByIDList(top, strIDList, fieldOrder);
        }

		 /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetListByPage(string strWhere, string fieldOrder, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, fieldOrder, startIndex, endIndex);
        }
        
        /// <summary>
        /// 数据分页
        /// </summary>
        public IList<lv_B2C.Model.ProductBrand> GetPageList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            return dal.GetPageList(strWhere, fieldOrder, pageIndex, pageSize);
        }
        
        #endregion
		
		
#endregion
   
	}
}