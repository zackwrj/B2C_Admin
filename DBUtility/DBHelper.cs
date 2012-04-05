

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Data.Common;

namespace lv_DBUtility
{
    public class DBHelper
    {
        private string connectionString = string.Empty;
        private DbProviderFactory factory;
        private DbConnection _connection;
        public DbConnection connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        private DbTransaction _transaction;
        public DbTransaction transaction
        {
            get { return _transaction; }
            set { _transaction = value; ;}
        }

        public DBHelper(string connectionString, string dbProviderName)
        {
            this.connectionString = connectionString;
            factory = DbProviderFactories.GetFactory(dbProviderName);
        }

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        public void OpenConnection()
        {
            if (connection == null)
            {
                connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;
            }
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void BeginTransaction()
        {
            OpenConnection();
            if (transaction == null)
                transaction = connection.BeginTransaction();
        }

        /// <summary>
        /// �ύ���� ���� �ͷŲ��ر���Դ
        /// </summary>
        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
                Dispose();
            }
        }

        /// <summary>
        /// �ع����� ���� �ͷŲ��ر���Դ
        /// </summary>
        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
                Dispose();
            }
        }

        /// <summary>
        /// ���û�п���������Զ��ͷ���Դ���ر����ӣ��������ύ��ع������ʱ���ͷ�
        /// </summary>
        public void Dispose()
        {
            if (transaction == null)
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection.Close();
                    connection = null;
                }
            }
        }

        private DbCommand CreateCommand(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            DbCommand mand = connection.CreateCommand();
            mand.CommandText = cmdText;
            mand.CommandType = cmdType;
            mand.Parameters.AddRange(cmdParas);
            if (transaction != null) mand.Transaction = transaction;
            return mand;
        }

        /// <summary>
        /// ����һ�����ݼ�
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                DbDataAdapter data = factory.CreateDataAdapter();
                data.SelectCommand = mand;
                DataSet ds = new DataSet();
                data.Fill(ds);
                return ds;
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// ������Ӱ�������
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                return mand.ExecuteNonQuery();
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// ���ؽ�����е�һ�е�һ��
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                return mand.ExecuteScalar();
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="KeyWordsID"></param>
        /// <returns></returns>
        public int Exists(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            object obj = ExecuteScalar(cmdType, cmdText, cmdParas);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// ���ط��ͼ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public IList<T> ExecuteReaderList<T>(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                DbDataReader reader = mand.ExecuteReader();
                IList<T> list = ToList<T>(reader);
                return list;
            }
            catch (Exception e){
                return null;
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// ����һ������ �����ݿ��޽�����ؽ��׳��쳣
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public T ExecuteReaderObject<T>(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            return ExecuteReaderList<T>(cmdType, cmdText, cmdParas)[0];
        }

        /// <summary>
        /// ���䴴�����ͼ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private IList<T> ToList<T>(DbDataReader reader)
        {
            Type type = typeof(T);
            IList<T> list = null;
            if (type.IsValueType || type == typeof(string))
                list = CreateValue<T>(reader, type);
            else
                list = CreateObject<T>(reader, type);
            reader.Dispose();
            reader.Close();
            return list;
        }

        private IList<T> CreateObject<T>(DbDataReader reader, Type type)
        {
            IList<T> list = new List<T>();
            PropertyInfo[] properties = type.GetProperties();
            string name = string.Empty;
            while (reader.Read())
            {
                T local = Activator.CreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    name = reader.GetName(i);
                    foreach (PropertyInfo info in properties)
                    {
                        if (name.Equals(info.Name)) { info.SetValue(local, Convert.ChangeType(reader[info.Name], info.PropertyType), null); break; }
                    }
                }
                list.Add(local);
            }
            return list;
        }

        private IList<T> CreateValue<T>(DbDataReader reader, Type type)
        {
            IList<T> list = new List<T>();
            while (reader.Read())
            {
                T local = (T)Convert.ChangeType(reader[0], type, null);
                list.Add(local);
            }
            return list;
        }
    }
}
