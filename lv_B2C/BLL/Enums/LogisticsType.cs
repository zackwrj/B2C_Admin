using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace lv_B2C.BLL.Enums
{
    public enum LogisticsType
    {
        快递 = 0,
        EMS = 1,
        平邮 = 2
    }

    public static class LogisticsTypeAction
    {
        /// <summary>
        /// 获取枚举列表
        /// </summary>
        public static List<ListItem> GetList()
        {
            List<ListItem> typeList = new List<ListItem>();
            foreach (LogisticsType type in Enum.GetValues(typeof(LogisticsType)))
            {
                typeList.Add(new ListItem(type.ToString(), ((int)type).ToString()));
            }
            return typeList;
        }

        /// <summary>
        /// 获取枚举列表Json格式
        /// </summary>
        public static string GetJson()
        {
            string sbJson = "";
            sbJson += "[";
            foreach (LogisticsType type in Enum.GetValues(typeof(LogisticsType)))
            {
                sbJson += "{ id: " + ((int)type).ToString() + ", text: '" + type.ToString() + "' },";
            }
            sbJson = sbJson.Substring(0, sbJson.Length - 1);
            sbJson += "]";
            return sbJson.ToString();
        }

        /// <summary>
        /// 用枚举值获取枚举项名称
        /// </summary>
        public static string GetNameByValue(object typeValue)
        {
            int itype = Convert.ToInt32(typeValue);
            LogisticsType type = (LogisticsType)itype;
            return type.ToString();
        }
    }
}
