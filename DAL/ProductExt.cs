using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	//Product
	public partial class ProductExt : Product
	{
        /// <summary>
        /// 获得分页总条数
        /// </summary>
        public int GetPageCount(string strWhere, string tableName)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@strWhere", strWhere),
                    new SqlParameter("@Table",tableName)
                };
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "Table_GetPageCount", parameters));
            }
            catch
            {
                return -1;
            }
        }
	}
}

