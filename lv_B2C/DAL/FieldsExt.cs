using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace lv_B2C.DAL
{
    public class FieldsExt : Fields
    {
        public int HasProductClassSon(int fieldsID)
        {
            try
            {
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "Fields_HasSon", new SqlParameter("@ProductFieldsID", fieldsID)));
            }
            catch
            {
                return -1;
            }
        }
    }
}
