using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace lv_Common
{
    /// <summary>
    /// 处理URL参数值
    /// </summary>
    public static class UrlParaValue
    {
        /// <summary>
        /// URL传值，异常时 string 返回 "" ，int 返回 -1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlPara"></param>
        /// <returns></returns>
        public static T Get<T>(string urlPara)
        {
            return Get<T>(urlPara, "", -1);
        }
        /// <summary>
        /// URL传值，异常时 string 返回 strDefault ，int 返回 intDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlPara"></param>
        /// <param name="strDefault"></param>
        /// <param name="intDefault"></param>
        /// <returns></returns>
        public static T Get<T>(string urlPara, string strDefault, int intDefault)
        {
            object obj = new object();
            if (typeof(T) == typeof(string))
            {
                if (HttpContext.Current.Request[urlPara] == null)
                {
                    obj = (object)strDefault;
                    return (T)obj;
                }
            }
            if (typeof(T) == typeof(int))
            {
                if (HttpContext.Current.Request[urlPara] == null)
                {
                    obj = (object)intDefault;
                    return (T)obj;
                }
                if (HttpContext.Current.Request[urlPara].ToString() == "0")
                {
                    return default(T);
                }
                else
                {
                    if (Get<T, string>(HttpContext.Current.Request[urlPara]).ToString() == "0")
                    {
                        obj = (object)intDefault;
                        return (T)obj;
                    }
                    return Get<T, string>(HttpContext.Current.Request[urlPara]);
                }
            }
            return Get<T, string>(HttpContext.Current.Request[urlPara]);
        }
        /// <summary>
        /// URL传值异常获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tinput"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        private static T Get<T, Tinput>(Tinput text)
        {
            try
            {
                return (T)Convert.ChangeType(text, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}