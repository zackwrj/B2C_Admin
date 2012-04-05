using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using lv_DBUtility;
namespace lv_B2C.DAL
{
    //UserInfo
    public partial class UserInfoExt : UserInfo
    {
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public int IsExistUserName(string userName)
        {
            try
            {
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "UserInfo_IsExistUserName", new SqlParameter("@UserName", userName)));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 判断邮箱是否存在
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public int IsExistEmail(string email)
        {
            try
            {
                return Convert.ToInt32(lv_DBUtility.DBManager.Instance().ExecuteScalar(CommandType.StoredProcedure, "UserInfo_IsExistEmail", new SqlParameter("@Email", email)));
            }
            catch
            {
                return -1;
            }
        }
    }
}

