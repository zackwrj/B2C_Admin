using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Reflection;

namespace lv_B2C.Web
{
    public class Manage
    {
        private static BLL.WebAlbumExt bllWebAlbum = new BLL.WebAlbumExt();
        private static BLL.WebImageExt bllWebImage = new BLL.WebImageExt();

        #region  显示目录与图片

        /// <summary>
        /// 递归子类
        /// </summary>
        /// <param name="webAlbum"></param>
        /// <returns></returns>
        private static string Children(lv_B2C.Model.WebAlbum webAlbum)
        {
            StringBuilder sb = new StringBuilder();
            if (webAlbum.AlbumID > 0)
            {
                IList<Model.WebAlbum> list = bllWebAlbum.GetList(0, "IsDel=0 and ParentID=" + webAlbum.AlbumID.ToString(), "");
                if (list == null)
                {
                    return "";
                }
                if (list.Count > 0)
                {
                    sb.Append("<ul>");
                    foreach (Model.WebAlbum w in list)
                    {
                        sb.Append("<li album='" + w.AlbumID + "' check='0'>");
                        sb.Append(w.Title);

                        sb.Append("</li>");
                        sb.Append(Children(w));
                        //sb.Append("<li>"+Children(w)+"</li>");
                    }
                    sb.Append("</ul>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 显示图片目录
        /// </summary>
        /// <returns></returns>
        public static string WebAlbumDirectory()
        {
            StringBuilder sb = new StringBuilder();
            IList<Model.WebAlbum> rootList = bllWebAlbum.GetList(0, "IsDel=0 and RootID=0 and ParentID=0", "");
            if (rootList != null)
            {
                foreach (Model.WebAlbum webAlbum in rootList)
                {
                    sb.Append("<li album='" + webAlbum.AlbumID + "' check='0'>");
                    sb.Append(webAlbum.Title);

                    sb.Append("</li>");
                    sb.Append(Children(webAlbum));
                    //sb.Append("<li>" + Children(webAlbum) + "</li>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 显示相册所有图片
        /// </summary>
        public static string ViewImage(int webAlbumID)
        {
            IList<Model.WebImage> webImageList = bllWebImage.GetList(0, "IsDel=0 and AlbumID=" + webAlbumID.ToString(), "");
            return ObjectToJson("View", webImageList);
        }

        #endregion

        #region 目录管理

        #region 添加根目录
        public static int RootAdd(string title)
        {
            Model.WebAlbum model = new lv_B2C.Model.WebAlbum();
            model.AlbumID = bllWebAlbum.GetMaxId();
            model.Title = title;
            return bllWebAlbum.Add(model);
        }
        #endregion

        #region 添加子目录
        public static int DirAdd(int albumID, string title)
        {
            Model.WebAlbum dir = bllWebAlbum.GetModel(albumID);

            if (dir.AlbumID < 1)
                return -1;

            lv_B2C.Model.WebAlbum model = new lv_B2C.Model.WebAlbum();
            model.AlbumID = bllWebAlbum.GetMaxId();
            model.ParentID = dir.AlbumID;
            model.RootID = dir.ParentID;
            model.Title = title;
            return bllWebAlbum.Add(model);
        }
        #endregion

        #region 显示目录名称、编辑目录
        /// <summary>
        /// 显示目录名称
        /// </summary>
        /// <param name="webAlbumID"></param>
        /// <returns></returns>
        public static string ViewAlbum(int webAlbumID)
        {
            IList<Model.WebAlbum> webAblum = bllWebAlbum.GetList(1, "AlbumID=" + webAlbumID.ToString(), "");
            return ObjectToJson("View", webAblum);
        }
        /// <summary>
        /// 编辑目录
        /// </summary>
        /// <param name="albumID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static int DirEdit(int albumID, string title)
        {
            Model.WebAlbum dir = bllWebAlbum.GetModel(albumID);

            if (dir.AlbumID < 1)
                return -1;
            return bllWebAlbum.Update(albumID, "Title", title);
        }
        #endregion

        #region  删除目录
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public static int DirDelete(int albumID)
        {
            Model.WebAlbum dir = bllWebAlbum.GetModel(albumID);
            if (dir.AlbumID < 1)
                return -1;
            return bllWebAlbum.Update(albumID, "IsDel", "1");
        }
        #endregion

        #endregion

        #region 相片管理
        /// <summary>
        /// 编辑相片信息
        /// </summary>
        /// <param name="imageID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static int ImageEdit(int imageID, string title)
        {
            Model.WebImage image = bllWebImage.GetModel(imageID);
            if (image.ImageID < 1)
                return -1;
            return bllWebImage.Update(imageID, "Title", title);
        }
        /// <summary>
        /// 显示相片信息
        /// </summary>
        /// <param name="imageID"></param>
        /// <returns></returns>
        public static string ImageView(int imageID)
        {
            IList<Model.WebImage> image = bllWebImage.GetList(1, "IsDel=0 and ImageID=" + imageID.ToString(), "");
            if (image != null)
            {
                image[0].URL = "/Adminlvcn/1ref/controls/UpLoad/Content/Upload/Images/"+ image[0].URL;
            }
            return ObjectToJson("View", image);
        }
        public static string ImageView(string url)
        {
            IList<Model.WebImage> image = bllWebImage.GetList(1, "IsDel=0 and URL='"+url+"'", "");
            return ObjectToJson("View", image);
        }
        /// <summary>
        /// 删除相片
        /// </summary>
        /// <param name="imageID"></param>
        /// <returns></returns>
        public static int ImageDelete(int imageID)
        {
            Model.WebImage image = bllWebImage.GetModel(imageID);
            if (image.ImageID < 1)
                return -1;
            return bllWebImage.Update(imageID, "IsDel", "1");
        }
        /// <summary>
        /// 移到文件夹
        /// </summary>
        /// <param name="imageID"></param>
        /// <returns></returns>
        public static int ImageMove(int imageID, int AlbumID)
        {
            Model.WebImage image = bllWebImage.GetModel(imageID);
            if (image.ImageID < 1)
                return -1;
            return bllWebImage.Update(imageID, "AlbumID", AlbumID);
        }
        #endregion

        private static string ObjectToJson<T>(string jsonName, IList<T> IL)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (IL.Count > 0)
            {
                for (int i = 0; i < IL.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    Type type = obj.GetType();
                    PropertyInfo[] pis = type.GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pis.Length; j++)
                    {
                        Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\"");
                        if (j < pis.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < IL.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
    }
}