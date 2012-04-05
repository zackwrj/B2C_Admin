using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL  
{
	//ProductFields
	public partial class ProductFieldsExt : ProductFields
	{
        public int HasProductClassSon(int productFieldsID)
        {
            try
            {
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "ProductFields_HasSon", new SqlParameter("@ProductFieldsID", productFieldsID)));
            }
            catch
            {
                return -1;
            }
        }
	}
}

