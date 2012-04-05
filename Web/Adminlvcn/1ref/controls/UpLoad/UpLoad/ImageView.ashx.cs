using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lv_B2C.Web
{
    /// <summary>
    /// ImageView 的摘要说明
    /// </summary>
    public class ImageView : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string type = context.Request["type"];
            string id=context.Request["id"];
            string title = context.Request["title"];
            string outStr = "";
            switch(type)
            {
                case "view":
                    if(id!=string.Empty)
                    {
                        outStr = Manage.ImageView(Convert.ToInt32(id));
                    }
                    break;
                case "delete":
                    if (id != string.Empty)
                    {
                        outStr = Manage.ImageDelete(Convert.ToInt32(id)) > 0 ? "删除成功" : "删除失败";
                    }
                    break;
                case "edit":
                    if (id != string.Empty)
                    {
                        outStr = Manage.ImageEdit(Convert.ToInt32(id),title) > 0 ? "修改成功" : "修改失败";
                    }
                    break;
                default: break;
            }
            context.Response.Write(outStr);
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