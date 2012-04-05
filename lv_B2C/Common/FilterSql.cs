using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lv_Common
{
    public class FilterSql
    {
        /// <summary>
        ///SQL注入过滤
        /// </summary>
        /// <param name="InText">要过滤的字符串</param>
        /// <returns>如果参数存在不安全字符，则返回true</returns>
        public static bool SqlFilter(string InText)
        {
            string word = "and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join|'";
            if (InText == null)
                return false;
            foreach (string str_t in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(str_t + " ") > -1) || (InText.ToLower().IndexOf(" " + str_t) > -1) || (InText.ToLower().IndexOf(str_t) > -1))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
