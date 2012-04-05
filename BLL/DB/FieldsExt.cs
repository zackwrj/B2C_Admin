using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lv_Common;
using lv_B2C.Model;
using System.Collections;
namespace lv_B2C.BLL
{
    public class FieldsExt : Fields
    {
        private lv_B2C.DAL.FieldsExt dal = null;

        public Hashtable GetHashList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            Hashtable result = new Hashtable();
            IList<Model.Fields> ilist = GetPageList(strWhere, fieldOrder, pageIndex, pageSize);
            result["data"] = ilist;
            result["total"] = BLL.Pager.PageExtend.GetPageCount(strWhere, "ProductFields");
            return result;
        }

        /// <summary>
        /// 是否存在子类
        /// </summary>
        /// <param name="productClassID"></param>
        /// <returns></returns>
        public bool HasProductClassSon(int productFieldsID)
        {
            dal = new DAL.FieldsExt();
            int rs = dal.HasProductClassSon(productFieldsID);
            if (rs != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
