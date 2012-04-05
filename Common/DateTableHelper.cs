using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace lv_Common
{
    /// <summary>
    /// DataTable相关操作帮助类
    /// </summary>
    public static class DateTableHelper
    {
        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="count">要查询的条数(传入0为查全部)</param>
        /// <param name="select">查询条件</param>
        /// <param name="dt">DataTable数据集</param>
        /// <returns>结果集</returns>
        public static DataTable Select(int count, string select, DataTable dt)
        {
            DataRow[] dr = dt.Select(select);
            DataTable returndt = dt.Clone();
            if (count == 0)
            {
                count = dr.Length;
            }
            else if (count > dr.Length)
            {
                count = dr.Length;
            }

            for (int i = 0; i < count; i++)
            {
                returndt.ImportRow(dr[i]);
            }
            return returndt;
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="startIndex">开始的位置(由0开始)</param>
        /// <param name="count">要查询的条数(传入0为查全部)</param>
        /// <param name="select">查询条件</param>
        /// <param name="dt">DataTable数据集</param>
        /// <returns>结果集</returns>
        public static DataTable Select(int startIndex, int count, string select, DataTable dt)
        {
            DataRow[] dr = dt.Select(select);
            int length = startIndex + count;
            DataTable returndt = dt.Clone();
            if (count == 0)
            {
                count = dr.Length;
            }
            else if (count > dr.Length)
            {
                count = dr.Length;
            }
            else if (dr.Length < length)
            {
                for (int i = startIndex; i < dr.Length; i++)
                {
                    returndt.ImportRow(dr[i]);
                }
            }
            else
            {
                for (int i = startIndex; i < length; i++)
                {
                    returndt.ImportRow(dr[i]);
                }
            }
            return returndt;
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="count">要查询的条数(传入0为查全部)</param>
        /// <param name="select">查询条件</param>
        /// <param name="dt">DataTable数据集</param>
        /// <param name="sort">排序的字段</param>
        /// <returns>结果集</returns>
        public static DataTable Select(int count, string select, DataTable dt, string sort)
        {
            DataRow[] dr = dt.Select(select, sort);
            DataTable returndt = dt.Clone();
            if (count == 0)
            {
                count = dr.Length;
            }
            else if (count > dr.Length)
            {
                count = dr.Length;
            }

            for (int i = 0; i < count; i++)
            {
                returndt.ImportRow(dr[i]);
            }
            return returndt;
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="startIndex">开始的位置(由0开始)</param>
        /// <param name="count">要查询的条数(传入0为查全部)</param>
        /// <param name="select">查询条件</param>
        /// <param name="dt">DataTable数据集</param>
        /// <param name="sort">排序的字段</param>
        /// <returns>结果集</returns>
        public static DataTable Select(int startIndex, int count, string select, DataTable dt, string sort)
        {
            DataRow[] dr = dt.Select(select, sort);
            int length = startIndex + count;
            DataTable returndt = dt.Clone();
            if (count == 0)
            {
                count = dr.Length;
            }
            else if (count > dr.Length)
            {
                count = dr.Length;
            }
            else if (dr.Length < length)
            {
                for (int i = startIndex; i < dr.Length; i++)
                {
                    returndt.ImportRow(dr[i]);
                }
            }
            else
            {
                for (int i = startIndex; i < length; i++)
                {
                    returndt.ImportRow(dr[i]);
                }
            }
            return returndt;
        }
    }
}
