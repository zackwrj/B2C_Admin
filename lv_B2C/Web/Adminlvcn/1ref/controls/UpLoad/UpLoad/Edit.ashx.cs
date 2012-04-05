using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Threading;
namespace lv_B2C.Web
{
    /// <summary>
    /// 对上传图片进行操作
    /// </summary>
    public class Edit : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string sessionStr = context.Session["UpLoad"].ToString();

            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string edit = context.Request["edit"];
            string title = context.Request["title"];
            
            string temp = "";
            //列表清除
            if (edit == "alldelete")
            {
                try
                {
                    context.Session[sessionStr] = null;
                    temp = "ok";
                }
                catch (Exception e)
                {
                    temp = e.Message;
                }
                context.Response.Write(temp);
                context.Response.End();
                return;
            }
            //添加
            if (edit == "add")
            {
                string id = context.Request["id"];
                List<Images> imagesList = context.Session[sessionStr] as List<Images>;
                try
                {
                    for (int i = 0; i < imagesList.Count; i++)
                    {
                        if (id == imagesList[i].ImagesID)
                        {
                            temp = UpLoadImage(imagesList[i], context,imagesList);
                            if (Convert.ToInt32(temp)<0)
                            {
                                context.Response.Write("error");
                                context.Response.End();
                                return;
                            }
                            context.Session[sessionStr] = imagesList;
                            
                        }
                    }
                }
                catch (Exception e)
                {
                    temp = e.Message;
                }
                context.Response.Write(temp);
                context.Response.End();
                return;
            }
            //删除
            if (edit.Contains("editCannelButton"))
            {
                string deleteID = edit.Substring(edit.IndexOf("_") + 1);
                List<Images> imagesList = context.Session[sessionStr] as List<Images>;
                List<Images> tempList = imagesList;
                for (int i = 0; i < imagesList.Count; i++)
                {
                    if (deleteID == imagesList[i].ImagesID)
                    {
                        imagesList.Remove(imagesList[i]);
                        context.Session[sessionStr] = imagesList;
                        temp = "ok";
                    }
                }
                context.Response.Write(temp);
                context.Response.End();
                return;
            }
            //编辑
            if (edit.Contains("editTitle"))
            {
                string deleteID = edit.Substring(edit.IndexOf("_") + 1);

                List<Images> imagesList = context.Session[sessionStr] as List<Images>;
                for (int i = 0; i < imagesList.Count; i++)
                {
                    if (deleteID == imagesList[i].ImagesID)
                    {
                        imagesList[i].Title = title;
                        context.Session[sessionStr] = imagesList;
                        temp ="ok";
                    }
                }
                context.Response.Write(temp);
                context.Response.End();
                return;
            }
            temp = edit;
            context.Response.Write("图片ID:" + temp + title);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region   检查文件合法性
        /// <summary>
        /// 检查是否为合法的上传图片
        /// </summary>
        /// <param name="_fileExt"></param>
        /// <returns></returns>
        private bool CheckImageExt(string _ImageExt)
        {
            string[] allowExt = new string[] { ".gif", ".jpg", ".jpeg", ".bmp", ".png" };//*.gif;*.jpg;*.jpeg;*.png;*.bmp
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i] == _ImageExt) { return true; }
            }
            return false;
            //return false;
        }

        //private string GetImageName()
        //{
        //    Random rd = new Random();
        //    StringBuilder serial = new StringBuilder();
        //    serial.Append(DateTime.Now.ToString("yyyyMMddHHmmssff"));
        //    serial.Append(rd.Next(0, 999999).ToString());
        //    return serial.ToString();

        //}

        #endregion

        #region 上传文件
        public string UpLoadImage(Images image, HttpContext context, List<Images> imagesList)
        {
            string sessionStr = context.Session["UpLoad"].ToString();
            try
            {
                string serverPath = System.Web.HttpContext.Current.Server.MapPath("~");

                string toFilePath = Path.Combine(serverPath, @"Adminlvcn\1ref\controls\UpLoad\Content\Upload\Images\");

                string toFullName = toFilePath + image.ImagesID + image.ImageType;
                string toBeforeName = toFilePath + "before_"+image.ImagesID + image.ImageType;
                if (File.Exists(toBeforeName))
                {
                    File.Delete(toBeforeName);
                }
                if (File.Exists(toBeforeName) == false)
                {

                    if (File.Exists(toFullName))
                    {
                        File.Delete(toFullName);
                    }
                    if (File.Exists(toFullName) == false)
                    {
                        

                        BLL.WebImageExt bllwebImageExt = new BLL.WebImageExt();
                        Model.WebImage webImage = new Model.WebImage();
                        webImage.ImageID =bllwebImageExt.GetMaxId();

                        webImage.Title =image.Title;
                        webImage.URL = image.ImagesID + image.ImageType;
                        webImage.ImgTypes = image.ImageType;
                        if (bllwebImageExt.Add(webImage) > 0)
                        {
                            FileStream F1 = File.Create(toBeforeName);
                            F1.Write(image.ImagesDataBefore, 0, image.ImagesDataBefore.Length);
                            F1.Close();
                            F1.Dispose();

                            FileStream FS;
                            FS = File.Create(toFullName);
                            FS.Write(image.ImagesData, 0, image.ImagesData.Length);
                            FS.Close();
                            FS.Dispose();

                            //List<Images> imagesList = context.Session[sessionStr] as List<Images>;
                            for (int i = 0; i < imagesList.Count; i++)
                            {
                                if (image.ImagesID == imagesList[i].ImagesID)
                                {
                                    imagesList.Remove(imagesList[i]);
                                    context.Session[sessionStr] = imagesList;
                                    if (imagesList.Count == 0)
                                        context.Session[sessionStr] = null;
                                }
                            }
                            Thread.Sleep(200);
                            return webImage.ImageID.ToString();
                        }
                        else
                        { 
                            return "-1"; 
                        }
                    }
                    return "-1";
                    //return "ok";
                }
                else
                {
                    return "-1";
                    //return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}