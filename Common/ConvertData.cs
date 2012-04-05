using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lv_Common
{
    public static class ConvertData
    {
        #region ConverToStringUTF8
        public static string ConvertToStringUtf8(string str)
        {
            //byte[] buffer = UTF8Encoding.GetBytes(str);
            byte[] buffer = Encoding.ASCII.GetBytes(str);
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(buffer);
        }
        #endregion

        #region ConvertToString
        /// <summary>
        /// 转换成字符串,如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static string ConvertToString(Object obj, string strDefault)
        {
            try
            {
                if (obj == null)
                {
                    return strDefault;
                }

                return obj.ToString();
            }
            catch
            {
            }
            return strDefault;
        }
        /// <summary>
        /// 转换成整形数,如果不能转换,出现异常同则返回0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static string ConvertToString(Object obj)
        {
            return ConvertToString(obj, "");
        }
        #endregion

        #region ConvertToLong
        /// <summary>
        /// 转换成长整形数,如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static long ConvertToLong(Object obj, long lDefault)
        {
            try
            {
                if (obj == null)
                {
                    return lDefault;
                }

                long lRet = long.Parse(obj.ToString().Trim());
                return lRet;
            }
            catch
            {
            }
            return lDefault;
        }
        /// <summary>
        /// 转换成长整形数,如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static long ConvertToLong(Object obj)
        {
            return ConvertToLong(obj, 0);
        }

        #endregion

        #region ConvertToInt
        /// <summary>
        /// 转换成整形数,如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static int ConvertToInt(Object obj, int iDefault)
        {
            try
            {
                if (obj == null)
                {
                    return iDefault;
                }
                //int.Parse(obj.ToString().Trim())
                int iRet = Convert.ToInt32(Convert.ToDouble(obj.ToString().Trim()));
                return iRet;
            }
            catch
            {
            }
            return iDefault;
        }
        /// <summary>
        /// 转换成整形数,如果不能转换,出现异常同则返回0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static int ConvertToInt(Object obj)
        {
            return ConvertToInt(obj, 0);
        }
        #endregion

        #region ConvertToDouble
        /// <summary>
        /// 转换成double,如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static double ConvertToDouble(Object obj, double dDefault)
        {
            try
            {
                if (obj == null)
                {
                    return dDefault;
                }

                double dRet = double.Parse(obj.ToString().Trim());
                return dRet;
            }
            catch
            {
            }
            return dDefault;
        }
        /// <summary>
        /// 转换成double,如果不能转换,出现异常同则返回0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static double ConvertToDouble(Object obj)
        {
            return ConvertToDouble(obj, 0);
        }
        #endregion

        #region ConvertToDecimal
        /// <summary>
        /// 转换成decimal, 如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static decimal ConvertToDecimal(Object obj, decimal dDefault)
        {
            try
            {
                if (obj == null)
                {
                    return dDefault;
                }
                decimal dRet = decimal.Parse(obj.ToString().Trim());
                return dRet;
            }
            catch
            {
            }
            return dDefault;
        }
        /// <summary>
        /// 转换成float,如果不能转换,出现异常同则返回0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static decimal ConvertToDecimal(Object obj)
        {
            return ConvertToDecimal(obj, 0);
        }
        #endregion

        #region ConvertToFloat
        /// <summary>
        /// 转换成float, 如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static float ConvertToFloat(Object obj, float fDefault)
        {
            try
            {
                if (obj == null)
                {
                    return fDefault;
                }
                float fRet = float.Parse(obj.ToString().Trim());
                return fRet;
            }
            catch
            {
            }
            return fDefault;
        }
        /// <summary>
        /// 转换成float,如果不能转换,出现异常同则返回0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static float ConvertToFloat(Object obj)
        {
            return ConvertToFloat(obj, 0);
        }

        #endregion

        #region ConvertToDateTime
        /// <summary>
        /// 转换成DateTime, 如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static DateTime ConvertToDateTime(Object obj, DateTime dateDefault)
        {
            try
            {
                if (obj != null && obj is DateTime)
                    return (DateTime)obj;

                DateTime dateRet = DateTime.Parse(obj.ToString().Trim());
                if ((dateRet > DateTime.Parse("0001-01-01 12:00:00"))
                    && (dateRet < DateTime.Parse("9999-01-01 23:59:59")))
                {
                    return dateRet;
                }
            }
            catch
            {
            }
            return dateDefault;
        }


        /// <summary>
        /// 转换成float,如果不能转换,出现异常同则返回0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static DateTime ConvertToDateTime(Object obj)
        {
            return ConvertToDateTime(obj, ConstantDefine.DefaultDate);
        }
        #endregion

        #region ConvertToDateTimeOfShort
        /// <summary>
        /// 转换成DateTime, 如果不能转换,出现异常同则返回缺省值
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="iDefault">缺省值</param>
        /// <returns>转换结果值</returns>
        public static DateTime ConvertToDateTimeOfShort(Object obj, DateTime dateDefault)
        {
            try
            {
                DateTime dateRet = DateTime.Parse(DateTime.Parse(obj.ToString().Trim()).ToShortDateString());
                if ((dateRet > DateTime.Parse("1753-01-01 12:00:00"))
                    && (dateRet < DateTime.Parse("9999-01-01 23:59:59")))
                {
                    return dateRet;
                }
            }
            catch
            {
            }
            return dateDefault;
        }
        #endregion

        #region ConvertToBool
        /// <summary>
        /// 转换成BOOL,如果不能转换,出现异常同则返回false
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static bool ConvertToBool(Object obj)
        {
            try
            {
                return bool.Parse(obj.ToString());
            }
            catch
            {
            }
            return false;
        }

        public static bool ConvertStringToBool(string obj)
        {
            try
            {
                if (obj != null)
                {
                    obj = obj.ToLower();
                    if (obj.Equals("y") || obj.Equals("1") || obj.Equals("true"))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region ConvertToByteArray
        /// <summary>
        /// 转换成Byte[],如果不能转换,出现异常同则返回null
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static Byte[] ConvertToByteArray(Object obj)
        {
            try
            {
                if (obj == System.DBNull.Value)
                {
                    return null;
                }
                Byte[] byaRet = new byte[((Byte[])obj).Length];
                ((Byte[])obj).CopyTo(byaRet, 0);
                return byaRet;
            }
            catch
            {
            }
            return null;
        }
        #endregion

        #region MoneyConvertToString
        /// <summary>
        /// 金额变换字符串, 是否显示金额为0
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="bShowZero">是否显示0</param>
        /// <returns>转换结果值</returns>
        public static string MoneyConvertToString(Object obj, bool bShowZero)
        {
            try
            {
                decimal dMoney = ConvertToDecimal(obj);
                if (dMoney == 0 && bShowZero == false)
                {
                    return "";
                }
                return dMoney.ToString("0.00");
            }
            catch
            {
                return "0.00";
            }
        }
        /// <summary>
        /// 金额变换字符串, 金额为0时不显示
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static string MoneyConvertToString(Object obj)
        {
            return MoneyConvertToString(obj, false);
        }
        #endregion

        #region DateConvertToString
        /// <summary>
        /// 日期变换字符串, 是否显示日期为1900-01-01
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="bShowZero">日期为1900-01-01是否</param>
        /// <returns>转换结果值</returns>
        public static string DateConvertToString(Object obj, bool bShow)
        {
            try
            {
                DateTime dtDate = ConvertToDateTime(obj);
                if (dtDate == ConstantDefine.DefaultDate && bShow == false)
                {
                    return "";
                }
                return dtDate.ToString("yyyy-MM-dd");
            }
            catch
            {
                return "1900-01-01";
            }
        }
        #endregion

        #region DateConvertToString
        /// <summary>
        /// 日期时间变换字符串, 日期为1900-01-01时不显示
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static string DateConvertToString(Object obj)
        {
            return DateConvertToString(obj, false);
        }
        /// <summary>
        /// 日期时间变换字符串, 日期为1900-01-01时不显示
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns>转换结果值</returns>
        public static string DateTimeConvertToString(Object obj)
        {
            return DateTimeConvertToString(obj, false);
        }
        #endregion

        #region DateTimeConvertToString
        /// <summary>
        /// 日期时间变换字符串, 日期为1900-01-01时不显示 bShowZero为是否显示时间
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="bShowZero">是否显示时间</param>
        /// <returns>转换结果值</returns>
        public static string DateTimeConvertToString(Object obj, bool bShowTime)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj);
                if (dtDateTime == ConstantDefine.DefaultDate)
                {
                    return "";
                }
                if (!bShowTime || (dtDateTime.Hour == 0 && dtDateTime.Minute == 0 && dtDateTime.Second == 0))
                {
                    return dtDateTime.ToString("yyyy-MM-dd");
                }
                return dtDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return "2007-07-30 12:00:00";
            }
        }
        /// <summary>
        /// 日期时间变换字符串
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="format">转换的格式，如"yyyy-MM-dd"</param>
        /// <returns>转换结果值</returns>
        public static string DateTimeConvertToString(Object obj, string format)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj);
                if (dtDateTime == ConstantDefine.DefaultDate)
                {
                    return "";
                }
                return dtDateTime.ToString(format);
            }
            catch
            {
                return "2007-07-30 12:00:00";
            }
        }
        #endregion

        #region DateTimeConvertToStringShort
        /// <summary>
        /// 日期时间变换字符串, 日期为1900-01-01时不显示 bShowZero为是否显示时间
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="bShowZero">是否显示时间</param>
        /// <returns>转换结果值</returns>
        public static string DateTimeConvertToStringShort(Object obj)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj);
                if (dtDateTime == ConstantDefine.DefaultDate)
                {
                    return "";
                }
                return dtDateTime.ToString("MM.dd");
            }
            catch
            {
                return "07.30";
            }
        }
        public static string DateTimeConvertToStringShort(Object obj, bool bShowTime)
        {
            return DateTimeConvertToStringShort(obj);
        }
        #endregion

        #region DateTimeConvertToStringNoSpace
        /// <summary>
        /// 没有空格，以-替换空格和:号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DateTimeConvertToStringNoSpace(Object obj)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj);
                if (dtDateTime.Hour == 0 && dtDateTime.Minute == 0 && dtDateTime.Second == 0)
                {
                    return dtDateTime.ToString("yyyy-MM-dd-HH-mm");
                }
                return dtDateTime.ToString("yyyy-MM-dd-HH-mm");
            }
            catch
            {
                return DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            }
        }
        #endregion

        #region DateTimeConvertToStringNoSpaceAll
        /// <summary>
        /// 没有空格
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DateTimeConvertToStringNoSpaceAll(Object obj)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj);
                if (dtDateTime.Hour == 0 && dtDateTime.Minute == 0 && dtDateTime.Second == 0)
                {
                    return dtDateTime.ToString("yyyyMMddHHmmss");
                }
                return dtDateTime.ToString("yyyyMMddHHmmss");
            }
            catch
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }

        #endregion

        #region DateTimeConvertToStringCN 1900年01月01日
        /// <summary>
        /// 日期时间变换字符串, 是否显示日期为1900-01-01
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="bShowZero">日期为1900-01-01是否</param>
        /// <returns>转换结果值</returns>
        public static string DateTimeConvertToStringCN(Object obj)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj);
                return dtDateTime.ToString("yyyy年MM月dd日");
            }
            catch
            {
                return DateTime.Now.ToString("yyyy年MM月dd日");
            }
        }
        #endregion

        #region DateTimeConvertToStringCNAndWeek 1900年01月01日 星期一
        /// <summary>
        /// 日期时间变换字符串, 是否显示日期为1900-01-01
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="bShowZero">日期为1900-01-01是否</param>
        /// <returns>转换结果值</returns>
        public static string DateTimeConvertToStringCNAndWeek(Object obj)
        {
            try
            {
                DateTime dtDateTime = ConvertToDateTime(obj, DateTime.Now);
                return dtDateTime.ToString("yyyy年MM月dd日 ") + dtDateTime.DayOfWeek.ToString();
            }
            catch
            {
                DateTime dt = DateTime.Now;
                return dt.ToString("yyyy年MM月dd日 ") + dt.DayOfWeek.ToString();
            }
        }
        #endregion

        #region DateTimeSub
        /// <summary>
        /// 得到两个时间的分钟差
        /// </summary>
        /// <param name="dtnew"></param>
        /// <param name="dtold"></param>
        /// <returns></returns>
        public static long DateTimeSub(DateTime dtnew, DateTime dtold)
        {
            try
            {
                //DateTime dtold = FastSpring.Common.ConvertData.ConvertToDateTime("2007-07-29 03:20:00");
                //DateTime dtnew = FastSpring.Common.ConvertData.ConvertToDateTime("2007-07-29 03:40:00");
                return (dtnew.ToFileTime() - dtold.ToFileTime()) / 600000000;
                //Response.Write(s);
            }
            catch
            {
                return 0;
            }
        }

        public static long DateTimeSub(long dtnew, long dtold)
        {
            //DateTime dtold = FastSpring.Common.ConvertData.ConvertToDateTime("2007-07-29 03:20:00");
            //DateTime dtnew = FastSpring.Common.ConvertData.ConvertToDateTime("2007-07-29 03:40:00");
            return (dtnew - dtold) / 600000000;
            //Response.Write(s);
        }
        #endregion
    }
}
