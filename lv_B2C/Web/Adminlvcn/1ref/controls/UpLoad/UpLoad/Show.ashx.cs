using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace lv_B2C.Web
{
    /// <summary>
    /// 上传后显示图片进行操作
    /// </summary>
    public class Show : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            string id = context.Request.QueryString["id"] as string;
            if (id == null)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Not Found");
                context.Response.End();
                return;
            }
            string sessionStr = context.Session["UpLoad"].ToString();
            //string sessionStr = "file_info";//Session["UpLoad"]
            //if (context.Request["sessionStr"] != null && !string.IsNullOrEmpty(context.Request["sessionStr"].ToString()))
            //{
            //    sessionStr = context.Request["sessionStr"].ToString();
            //}
            List<Images> thumbnails = context.Session[sessionStr] as List<Images>;

            if (thumbnails == null)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Not Found");
                context.Response.End();
                return;
            }

            foreach (Images thumb in thumbnails)
            {
                if (thumb.ImagesID == id)
                {
                    context.Response.ContentType = "image/jpeg";
                    context.Response.BinaryWrite(thumb.ImagesData);
                    context.Response.End();
                    return;
                }
            }

            // If we reach here then we didn't find the file id so return 404
            context.Response.StatusCode = 404;
            context.Response.Write("Not Found");
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}