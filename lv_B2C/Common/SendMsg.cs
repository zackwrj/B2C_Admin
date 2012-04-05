using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace lv_Common
{
    /// <summary>
    /// 发送手机短信
    /// </summary>
    public class SendMsg
    {
        public static void sends(string strSendMsg, string strPhone)
        {           
            string Tel = strPhone;
            string sendMessage = strSendMsg;
            try
            {
                HttpWebRequest request = WebRequest.Create("http://211.155.25.158:8080/LSBsms/smsInterface.do?method=sendsms&name=10010012&password=21218cca77804d2ba1922c33e0151105&mobile=" + Tel + "&content=" + GB2Unicode(sendMessage) + "&splitsuffix=1") as HttpWebRequest;
                request.Method = "post";
                Stream uploadStream = request.GetRequestStream();
                uploadStream.Close();
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
                string html = sr.ReadToEnd().Trim();
                sr.Close();
                response.Close();               
            }
            catch { }
        }

        /// <summary>
        /// 解决url中含有中文的问题||(HttpWebRequest)WebRequest.Create(strURL)
        /// </summary>
        /// <param name="strSearch"></param>
        /// <returns></returns>
        public static string GB2Unicode(string strSearch)
        {
            string Hexs = "";
            string HH;
            Encoding GB = Encoding.GetEncoding("GB2312");
            Encoding unicode = Encoding.Unicode;
            byte[] GBBytes = GB.GetBytes(strSearch);
            for (int i = 0; i < GBBytes.Length; i++)
            {
                HH = "%" + GBBytes[i].ToString("x");
                Hexs += HH;
            }
            return Hexs;
        }
    }
}
