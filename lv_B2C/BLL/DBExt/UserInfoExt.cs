using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using lv_Common;
using lv_B2C.Model;
namespace lv_B2C.BLL {
	 	//UserInfo
	public partial class UserInfoExt : UserInfo
	{
        private readonly lv_B2C.DAL.UserInfoExt dal = new lv_B2C.DAL.UserInfoExt();

   		/// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public int IsExistUserName(string userName)
        {
            return dal.IsExistUserName(userName);
        }

        /// <summary>
        /// 判断邮箱是否存在
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public int IsExistEmail(string email)
        {
            return dal.IsExistEmail(email);

        }
	}
}