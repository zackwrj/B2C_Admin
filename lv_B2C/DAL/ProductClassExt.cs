using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	//ProductClass
	public partial class ProductClassExt : ProductClass
	{
        public int HasProductClassSon(int productClassID)
        {
            try
            {
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "ProductClass_HasSon", new SqlParameter("@ProductClassID", productClassID)));
            }
            catch
            {
                return -1;
            }
        }
	}
}

