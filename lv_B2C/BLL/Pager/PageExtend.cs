using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lv_B2C.BLL.Pager
{
    public class PageExtend
    {
        static lv_B2C.DAL.ProductExt dal = new lv_B2C.DAL.ProductExt();
        /// <summary>
        /// 获得分页总条数
        /// </summary>
        public static int GetPageCount(string strWhere, string tableName)
        {
            return dal.GetPageCount(strWhere, tableName);
        }
    }
}
