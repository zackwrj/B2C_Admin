using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Configuration;

namespace lv_DBUtility
{
    public class DBManager
    {
        /// <summary>
        /// Ĭ�ϵ����ݿ�����
        /// </summary>
        public static readonly string connectionString = PubConstant.ConnectionString; 
        /// <summary>
        /// ���ݿ����� Ĭ��֧��sqlserver���ݿ�
        /// </summary>
        public static readonly string dbProviderName = string.IsNullOrEmpty(ConfigurationManager.AppSettings["dbProviderName"])
                                                    ? "System.Data.SqlClient" : ConfigurationManager.AppSettings["dbProviderName"];
        [ThreadStatic]
        static DBHelper helper;

        /// <summary>
        /// ����Ĭ�ϵ����ݿ������
        /// </summary>
        /// <returns></returns>
        public static DBHelper Instance()
        {
            if (helper == null)
            {
                helper = new DBHelper(connectionString, dbProviderName);
                return helper;
            }
            return helper;
        }
    }
}
