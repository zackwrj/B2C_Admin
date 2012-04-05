using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.IO;

namespace lv_Common
{
    /// <summary>
    /// 缩放图片
    /// </summary>
    public class DisposeImg
    {
        /// <summary>
        /// 缩放图片
        /// </summary>
        /// <param name="img">原图片</param>
        /// <param name="xWith">处理后宽度</param>
        /// <param name="xHeig">处理后高度</param>
        /// <param name="strName">原图片名称</param>
        /// <param name="strPath">处理后存放路径(站点下任何文件夹)</param>
        /// <returns>返回处理后图片路径</returns>
        public static string scaleImg(System.Web.UI.Page page, System.Drawing.Image img, int xWith,int xHeig, string strName,string afterPath)
        {
            //图片名称
            string newImgName = strName;
            //图片路径
            string newPath = "/" + afterPath;

            //图片宽
            int i = xWith;
            //图片高
            int j = xHeig;
           
            //格式化图片
            System.Drawing.Image imgScale = new System.Drawing.Bitmap(i, j, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(imgScale);
            System.Drawing.Rectangle srcRect = new System.Drawing.Rectangle(0, 0, img.Width, img.Height);
            System.Drawing.Rectangle desRect = new System.Drawing.Rectangle(0, 0, imgScale.Width, imgScale.Height);
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(img, desRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
            //处理后的图片另存
            string strPa = page.Server.MapPath(newPath);
            //检查是否有该路径  没有就创建
            if (!Directory.Exists(strPa))
            {
                Directory.CreateDirectory(strPa);
            }
            string strImg = strPa + newImgName;
            imgScale.Save(strImg);
            g.Dispose();
            return newPath + newImgName;
        }

        public static string scaleImg(System.Web.UI.Page page,System.Drawing.Image img, int xWith, string strName, string afterPath)
        {
            double a = img.Width / img.Height;
            int xHeig = Convert.ToInt32((xWith / a).ToString());
            return scaleImg(page,img, xWith, xHeig, strName, afterPath);
        }

        public static string scaleImg(System.Web.UI.Page page, string imgPath, int xWith, string strName, string afterPath)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(imgPath);
            float a = float.Parse(img.Width.ToString()) / float.Parse(img.Height.ToString());
            float xHeig1 = float.Parse(xWith.ToString()) / a;
            int xHeig = Convert.ToInt32(xHeig1);
            return scaleImg(page,img, xWith, xHeig, strName, afterPath);
        }

        public static string scaleImg(System.Web.UI.Page page, string imgPath, int xWith, int xHeig, string strName, string afterPath)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(imgPath);
            return scaleImg(page,img, xWith, xHeig, strName, afterPath);
        }
    }
}
