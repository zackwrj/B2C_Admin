using System;
using System.Collections.Generic;
using System.Text;

namespace lv_Common
{
    /// <summary>
    /// 字符串分割
    /// </summary>
    public static class StringPlus
    {
        
        public static List<string> ConvertStringToList(string strInput, char speater)
        {
            List<string> list = new List<string>();
            strInput = DelLastChar(strInput, speater);
            string[] array = strInput.Split(speater);
            foreach (string str in array)
            {
                if (!string.IsNullOrEmpty(str) && str != speater.ToString())
                {
                    list.Add(str);
                }
            }
            return list;
        }
        public static List<string> ConvertStringToList(string strInput)
        {
            return ConvertStringToList(strInput, ',');
        }
        public static string ConvertListToString(string[] list, char speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == list.Length - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }
        public static string ConvertListToString(string[] list)
        {
            return ConvertListToString(list, ',');
        }
        public static string ConvertListToString(List<string> list, char speater)
        {
            return ConvertListToString(list.ToArray(), speater);
        }
        public static string ConvertListToString(List<string> list)
        {
            return ConvertListToString(list, ',');
        }   

        /// <summary>
        /// 设置(追加)分割字符串列表
        /// </summary>
        /// <param name="strList">原分割字符串列表(被追加)</param>
        /// <param name="strNew">新追加的字符串</param>
        /// <param name="sepeater">分隔符</param>
        /// <returns></returns>
        public static string AppendToStringList(string strList, string strNew, char sepeater)
        {
            if (string.IsNullOrEmpty(strList))
            {
                return strNew;
            }
            else if (string.IsNullOrEmpty(strNew))
            {
                return strList;
            }
            else
            {
                return strList + sepeater + strNew;
            }
        }
        /// <summary>
        /// 设置(追加)分割字符串列表(使用缺省分隔符',')
        /// </summary>
        /// <param name="strList">原分割字符串列表(被追加)</param>
        /// <param name="strNew">新追加的字符串</param>
        /// <returns></returns>
        public static string AppendToList(string strList, string strNew)
        {
            return AppendToStringList(strList, strNew, ',');
        }

        /// <summary>
        /// 字符串截取(纯文本)
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="length">截取长度</param>
        /// <returns>输出</returns>
        public static string CutString(object inputStr, int length)
        {
            string OutputStr = inputStr.ToString();
            if (!String.IsNullOrEmpty(OutputStr))
            {
                if (OutputStr.Length > length)
                {
                    return OutputStr.Substring(0, length);
                }
                else
                {
                    return OutputStr;
                }
            }
            return "";
        }

        /// <summary>
        /// 如果最后一个字符是逗号，则删除
        /// </summary>
        public static string DelLastComma(string str)
        {
            if (str.Length > 0)
            {
                if (str.LastIndexOf(",") == str.Length - 1)
                {
                    return str.Substring(0, str.LastIndexOf(","));
                }
                else
                {
                    return str;
                }
            }
            else
            {
                return str;
            }
        }



        /// <summary>
        /// 如果最后一个字符不是逗号，则加上一个逗号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AddLastComma(string str)
        {
            if (str.Length > 0)
            {
                if (str.LastIndexOf(",") == str.Length - 1)
                {
                    return str;
                }
                else
                {
                    return str + ",";
                }
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 如果最后一个字符是（某某符号），则删除
        /// </summary>
        public static string DelLastChar(string str, char strchar)
        {
            if (str.Length > 0)
            {
                if (str.LastIndexOf(strchar) == str.Length - 1)
                {
                    return str.Substring(0, str.LastIndexOf(strchar));
                }
                else
                {
                    return str;
                }
            }
            else
            {
                return str;
            }
        }

        
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
    }
}
