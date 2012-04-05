using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;


namespace lv_Common
{
    /// <summary>
    /// 其他公共功能类
    /// </summary>
    public static class Common
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

        /// <summary>
        /// 动态调用一个方法
        /// </summary>
        /// <param name="ClassName">类名称</param>
        /// <param name="MethodName">要调用的方法</param>
        /// <param name="Parameter_value">参数值</param>
        /// <returns>调用方法</returns>
        public static object CallMethod(object className, string methodName, string parameter_value)
        {
            MethodInfo info = null;
            Type mytype = className.GetType();
            info = mytype.GetMethod(methodName);
            return info.Invoke(className, new object[] { parameter_value });
        }

        /// <summary>
        /// 绑定一个DropDownList
        /// </summary>
        /// <param name="ddl">DropDownList实例</param>
        /// <param name="ddlText">DropDownList显示文本</param>
        /// <param name="ddlValue">DropDownList值</param>
        /// <param name="className">类名称</param>
        /// <param name="methodName">要调用的方法</param>
        /// <param name="parameterValue">参数值</param>
        public static void BindDropDownList(DropDownList ddl, string ddlText, string ddlValue, object className, string methodName, string parameterValue)
        {
            ddl.DataSource = CallMethod(className, methodName, parameterValue);
            ddl.DataTextField = ddlText;
            ddl.DataValueField = ddlValue;
            ddl.DataBind();
        }

        /// <summary>
        /// 获取服务器图片上传路径
        /// </summary>
        /// <param name="imageName">图片名称</param>
        /// <returns></returns>
        public static string GetUploadImagePath(string imageName)
        {
            string serverPath = System.Configuration.ConfigurationSettings.AppSettings["ImageUploadPath"];
            if (imageName == "")
            {
                imageName = "noimage.gif";
            }
            return serverPath + imageName;
        }

        
        /// <summary>
        /// 得到页面HTML源码
        /// </summary>
        /// <param name="webAddress">网址</param>
        /// <returns></returns>
        public static string GetHtmlSource(string webAddress)
        {
            //获取这个页面的请求信息     
            HttpWebRequest myHttpWebRequest = WebRequest.Create(webAddress) as HttpWebRequest;
            //得到这些请求信息
            HttpWebResponse myHttpWebResponse = myHttpWebRequest.GetResponse() as HttpWebResponse;
            //将页面信息转换成流
            Stream stream = myHttpWebResponse.GetResponseStream();
            //读取流，转换成gb2312编码
            StreamReader streamreader = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8"));
            //读取流转换成字符串形式
            string strHtml = streamreader.ReadToEnd();
            //关闭流
            stream.Close();
            streamreader.Close();
            //返回字符串，也就是页面html代码
            return strHtml;
        }

        public static string GetAdImagePath(string imageName)
        {
            string serverPath = System.Configuration.ConfigurationSettings.AppSettings["AdImagePath"];
            if (imageName == "")
            {
                imageName = "default_image.gif";
            }
            return serverPath + imageName;
        }

        public static string GetAdFlashPath(string flashName)
        {
            string serverPath = System.Configuration.ConfigurationSettings.AppSettings["AdFlashPath"];
            if (flashName == "")
            {
                flashName = "default_flash.swf";
            }
            return serverPath + flashName;
        }


    }
}
