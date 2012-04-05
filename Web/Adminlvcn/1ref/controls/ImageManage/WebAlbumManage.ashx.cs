using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lv_B2C.Web
{
    /// <summary>
    /// WebAlbumManage 的摘要说明
    /// </summary>
    public class WebAlbumManage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string outStr = "";
            string type = context.Request.QueryString["type"];
            string id = context.Request.QueryString["id"];
            string title = context.Request.QueryString["title"];

            #region  目录管理

            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "load"://目录加载
                        outStr = Manage.WebAlbumDirectory() == string.Empty ? "暂无目录" : Manage.WebAlbumDirectory();
                        break;
                    case "child":
                        if (id != string.Empty)
                        {
                            outStr = Manage.ViewImage(Convert.ToInt32(id));
                        }
                        break;
                    case "edit":
                        if (id == "0")
                        {
                            outStr = Manage.RootAdd(title) > 0 ? "添加根目录成功" : "添加根目录失败";
                        }
                        if (id == "1")
                        {
                            int adbumID = Convert.ToInt32(context.Request.QueryString["adbumID"]);
                            outStr = Manage.DirAdd(adbumID, title) > 0 ? "添加目录成功" : "添加目录失败";
                        }
                        if (id == "2")
                        {
                            int adbumID = Convert.ToInt32(context.Request.QueryString["adbumID"]);
                            outStr = Manage.DirEdit(adbumID, title) > 0 ? "修改目录成功" : "修改目录失败";
                        }
                        break;
                    case "view":
                        if (id != string.Empty)
                        {
                            outStr = Manage.ViewAlbum(Convert.ToInt32(id));
                        }
                        break;
                    case "delete":
                        if (id != string.Empty)
                        {
                            outStr = Manage.DirDelete(Convert.ToInt32(id)) > 0 ? "删除目录成功" : "删除目录失败";
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion

            string imageType = context.Request.QueryString["imagetype"];
            #region 相片管理
            switch (imageType)
            {
                case "delete":
                    if (id != string.Empty)
                    {
                        outStr = Manage.ImageDelete(Convert.ToInt32(id)) > 0 ? "ok" : "false";
                    }
                    break;
                case "edit":
                    if (id != string.Empty)
                    {
                        outStr = Manage.ImageEdit(Convert.ToInt32(id), title) > 0 ? "ok" : "false";
                    }
                    break;
                case "move":
                    string AlbumID = context.Request.QueryString["album"];
                    if (id != string.Empty)
                    {
                        outStr = Manage.ImageMove(Convert.ToInt32(id), Convert.ToInt32(AlbumID)) > 0 ? "ok" : "false";
                    }
                    break;
                default:
                    break;
            }
            #endregion

            context.Response.Write(outStr);
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