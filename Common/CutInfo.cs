using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lv_Common
{
    /// <summary>
    /// 字符串截取帮助类
    /// </summary>
    public class CutInfo
    {
        /// <summary>
        /// 返回处理后的时间，通过type设置返回的样式。1：day,2：moon,3：year,4：moon - day,5：year - moon - day,9:year - moon - day HH:mm
        /// </summary>
        /// <param name="time"></param>
        /// <param name="objObject"></param>
        public static string CutTime(string time, int style)
        {
            DateTime dt = DateTime.Parse(time);
            string day = ("0" + dt.Day).Remove(0, ("0" + dt.Day).Length - 2);
            string month = ("0" + dt.Month).Remove(0, ("0" + dt.Month).Length - 2);
            string hour = ("0" + dt.Hour).Remove(0, ("0" + dt.Hour).Length - 2);
            string minute = ("0" + dt.Minute).Remove(0, ("0" + dt.Minute).Length - 2);

            string Time;
            switch (style)
            {
                case 1: Time = day; break;
                case 2: Time = month; break;
                case 3: Time = dt.Year.ToString(); break;
                case 4: Time = month + "-" + day; break;
                case 5: Time = dt.Year.ToString() + "-" + month + "-" + day; break;
                case 6: Time = dt.GetDateTimeFormats('f')[0].ToString(); break;
                case 7: Time = string.Format("{0:f}", dt); break;
                case 8: Time = dt.GetDateTimeFormats('g')[0].ToString(); break;
                case 9: Time = dt.Year.ToString() + "-" + month + "-" + day + " " + hour + ":" + minute; break;
                case 10: Time = dt.Year.ToString() + "年" + month + "月" + day + "日"; break;
                default: Time = dt.Date.ToString(); break;
            }
            return Time;
        }
    }
}
