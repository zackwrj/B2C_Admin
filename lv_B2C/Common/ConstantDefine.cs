using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lv_Common
{
    class ConstantDefine
    {
        /// <summary>
        /// 默认NULL
        /// </summary>
        public static object Null
        {
            get { return null; }
        }

        /// <summary>
        /// 默认整数值
        /// </summary>
        public static int DefaultInt
        {
            get { return 0; }
        }

        /// <summary>
        /// 默认整数值
        /// </summary>
        public static long DefaultLong
        {
            get { return 0; }
        }

        /// <summary>
        /// 默认Float值
        /// </summary>
        public static float DefaultFloat
        {
            get { return 0; }
        }


        /// <summary>
        /// 默认Float值
        /// </summary>
        public static double DefaultDouble
        {
            get { return 0; }
        }

        /// <summary>
        /// 默认字符串值
        /// </summary>
        public static string DefaultString
        {
            get { return ""; }
        }

        /// <summary>
        /// 默认日期值
        /// </summary>
        public static DateTime DefaultDate
        {
            get { return DateTime.Parse("1900-01-01 01:01:01"); }
        }

        /// <summary>
        /// 默认日期值
        /// </summary>
        public static DateTime DefaultDateShort
        {
            get { return DateTime.Parse("1900-01-01"); }
        }      
    }
}
