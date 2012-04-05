using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

using System.Windows.Forms;
using System.IO;

namespace lv_Common
{
    /// <summary>
    /// 网页截图
    /// </summary>
    public class WebSnapshot
    {
        #region 网页快照

        /// <summary>
        /// 保存网页为图片（默认宽度250，保存在网站根目录的SnapPic文件夹下）
        /// </summary>
        /// <param name="strWebAddress"></param>
        public static string CutWeb(System.Web.UI.Page page, string strWebAddress)
        {
            return CutWeb(page, 250, "/SnapPic/", strWebAddress);
        }

        /// <summary>
        /// 保存网页为图片
        /// </summary>
        /// <param name="cutWidht">返回图片的宽度</param>
        /// <param name="returnPath">图片保存路径</param>
        public static string CutWeb(System.Web.UI.Page page, int cutWidht, string returnPath, string strWebAddress)
        {
            Assignment(page, cutWidht, returnPath, strWebAddress);
            Thread NewTh = new Thread(GetScreenImage);
            NewTh.SetApartmentState(ApartmentState.STA);//启动单元线程
            NewTh.Start();
            NewTh.Join();
            return ReturnImgUrl;
        }
        #endregion

        #region 属性赋值
        public static void Assignment(System.Web.UI.Page page, int cutWidht, string returnPath, string strWebAddress)
        {
            if (cutWidht > 0)
            {
                CutWidth = cutWidht;
            }
            if (returnPath.Trim() != "")
            {
                ReturnPath = returnPath;
            }
            if (strWebAddress.Trim() != "")
            {
                WebAddress = strWebAddress;
            }
            ThisPage = page;
        }
        #endregion

        #region 捕获屏幕
        ///// 捕获屏幕 
        protected static void GetScreenImage()
        {
            string imgName;
            try
            {

                string url = WebAddress;
                GetSnap thumb = new GetSnap(url);
                System.Drawing.Bitmap x = thumb.GetBitmap();//获取截图
                System.Drawing.Bitmap y = SHCut(x, 0, 0, 1500, 5000);//使用GDI+剪裁
                string FileName = DateTime.Now.ToString("yyyyMMddhhmmss");

                if (!Directory.Exists(ReturnPath + "Big/"))
                {
                    Directory.CreateDirectory(ReturnPath + "Big/");
                }
                string str = ThisPage.Server.MapPath("~" + ReturnPath + "Big/" + FileName + ".jpg");
                //string str = ThisPage.Server.MapPath("~/UploadFiles/634593668516757891.jpg");
                x.Save(str);//保存截图到SnapPic目录下

                imgName = ThisPage.Server.MapPath("~" + ReturnPath + "Big/" + FileName + ".jpg");
                if (!Directory.Exists(ReturnPath + "Small/"))
                {
                    Directory.CreateDirectory(ReturnPath + "Small/");
                }
                ReturnImgUrl = DisposeImg.scaleImg(ThisPage, imgName, 250, FileName, ReturnPath.Remove(0, 1) + "Small/");
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Resize图片
        /// <summary>
        /// Resize图片
        /// </summary>
        protected static Bitmap SHResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region  剪裁-用GDI+
        /// <summary>
        /// 剪裁 -- 用GDI+
        /// </summary>
        protected static Bitmap SHCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (StartX >= w || StartY >= h)
            {
                return null;
            }

            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }

            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 返回缩略图的宽度
        /// </summary>
        private static int CutWidth;
        /// <summary>
        /// 图片保存路径
        /// </summary>
        private static string ReturnPath;
        /// <summary>
        /// 图片保存路径
        /// </summary>
        private static string WebAddress;
        /// <summary>
        /// 返回图片路径
        /// </summary>
        private static string ReturnImgUrl;
        /// <summary>
        /// 页面
        /// </summary>
        private static System.Web.UI.Page ThisPage;
        #endregion
    }

    #region 内部类

    class GetSnap
    {
        private string MyURL;

        public string WebSite
        {
            get { return MyURL; }
            set { MyURL = value; }
        }

        public GetSnap(string WebSite)
        {
            this.WebSite = WebSite;
        }

        public Bitmap GetBitmap()
        {
            WebPageBitmap Shot = new WebPageBitmap(this.WebSite);
            Shot.GetIt(0, 0);
            Bitmap Pic = Shot.DrawBitmap();
            return Pic;
        }
    }

    class WebPageBitmap
    {
        WebBrowser MyBrowser;
        string URL;
        int Height;
        int Width;

        public WebPageBitmap(string url)
        {
            this.URL = url;
            MyBrowser = new WebBrowser();
            MyBrowser.ScrollBarsEnabled = false;
        }

        public void GetIt(int w, int h)
        {
            MyBrowser.Navigate(this.URL);
            while (MyBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            if (w != 0 && h != 0)
            {
                this.Height = h;
                this.Width = w;
            }
            else
            {
                this.Height = int.Parse(MyBrowser.Document.Body.GetAttribute("scrollHeight"));
                this.Width = int.Parse(MyBrowser.Document.Body.GetAttribute("scrollwidth"));
            }
            MyBrowser.Size = new Size(this.Width, this.Height);
        }

        public Bitmap DrawBitmap()
        {
            int theight = this.Height;
            int twidth = this.Width;
            Bitmap myBitmap = new Bitmap(Width, Height);
            Rectangle DrawRect = new Rectangle(0, 0, Width, Height);
            MyBrowser.DrawToBitmap(myBitmap, DrawRect);
            System.Drawing.Image imgOutput = myBitmap;
            System.Drawing.Image oThumbNail = new Bitmap(twidth, theight, imgOutput.PixelFormat);
            Graphics g = Graphics.FromImage(oThumbNail);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle oRectangle = new Rectangle(0, 0, twidth, theight);
            g.DrawImage(imgOutput, oRectangle);
            try
            {
                return (Bitmap)oThumbNail;
            }
            catch
            {
                return null;
            }
            finally
            {
                imgOutput.Dispose();
                imgOutput = null;
                MyBrowser.Dispose();
                MyBrowser = null;
            }
        }
    }
    #endregion
}
