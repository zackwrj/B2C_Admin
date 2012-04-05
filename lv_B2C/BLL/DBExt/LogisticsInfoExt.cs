using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lv_Common;
using lv_B2C.Model;
using System.Collections;
namespace lv_B2C.BLL {
	 	//LogisticsInfo
	public partial class LogisticsInfoExt : LogisticsInfo
	{
        public Hashtable GetHashList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            Hashtable result = new Hashtable();
            IList<Model.LogisticsInfo> ilist = GetPageList(strWhere, fieldOrder, pageIndex, pageSize);
            result["data"] = ilist;
            result["total"] = BLL.Pager.PageExtend.GetPageCount(strWhere, "LogisticsInfo");
            return result;
        }
	}
}