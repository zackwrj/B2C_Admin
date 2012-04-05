using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace lv_B2C.Web
{
    public partial class UpLoadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Drawing.Image thumbnail_image = null;
            System.Drawing.Image original_image = null;//输出压缩后图片
            System.Drawing.Image before_image = null;//输出原来图片

            System.Drawing.Bitmap final_image = null;
            System.Drawing.Bitmap before_bit = null;//原来图片

            System.Drawing.Graphics graphic = null;
            MemoryStream ms = null;
            MemoryStream newsMs = null;

            //string sessionStr = "file_info";//
            string sessionStr = Session["UpLoad"].ToString();
            int imageWidth = Convert.ToInt32(Request["width"]);
            int imageHeight = Convert.ToInt32(Request["height"]);

            try
            {
                HttpPostedFile jpeg_image_upload = Request.Files["Filedata"];
                original_image = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);
                #region 旧方法
                //int width = original_image.Width;
                //int height = original_image.Height;

                ////int target_width = original_image.Width;
                ////int target_height = original_image.Height;

                //int target_width = imageWidth;
                //int target_height = imageHeight;
                //int new_width, new_height;

                //float target_ratio = (float)target_width / (float)target_height;
                //float image_ratio = (float)width / (float)height;

                //if (target_ratio > image_ratio)
                //{
                //    new_height = target_height;
                //    new_width = (int)Math.Floor(image_ratio * (float)target_height);
                //}
                //else
                //{
                //    new_height = (int)Math.Floor((float)target_width / image_ratio);
                //    new_width = target_width;
                //}

                //new_width = new_width > target_width ? target_width : new_width;
                //new_height = new_height > target_height ? target_height : new_height;
                //final_image = new System.Drawing.Bitmap(target_width, target_height);
                //graphic = System.Drawing.Graphics.FromImage(final_image);
                //graphic.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Rectangle(0, 0, target_width, target_height));
                //int paste_x = (target_width - new_width) / 2;
                //int paste_y = (target_height - new_height) / 2;
                //graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; /* new way */

                //graphic.DrawImage(original_image, paste_x, paste_y, new_width, new_height);

                //ms = new MemoryStream();
                //final_image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);


                //before_image = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);
                //before_bit = new System.Drawing.Bitmap(before_image.Width, before_image.Height);
                //graphic = System.Drawing.Graphics.FromImage(final_image);
                //graphic.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Rectangle(0, 0, before_image.Width, before_image.Height));
                //graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; /* new way */
                //graphic.DrawImage(before_image, 0, 0, before_image.Width, before_image.Height);

                //newsMs = new MemoryStream();
                //before_bit.Save(newsMs, System.Drawing.Imaging.ImageFormat.Jpeg);

                //before_image = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);
                //System.Drawing.Bitmap before_bit = new System.Drawing.Bitmap(before_image.Width, before_image.Height);
                //graphic = System.Drawing.Graphics.FromImage(before_bit);
                //graphic.DrawImage(before_image, 0, 0, before_image.Width, before_image.Height);
                //MemoryStream newMS = new MemoryStream();
                //before_bit.Save(newMS, System.Drawing.Imaging.ImageFormat.Jpeg);

                #endregion

                //时间+随机数
                string thumbnail_id = DateTime.Now.ToString("yyyyMMddHHmmssfff")+GetRandom();

                ms = GetImage(original_image, imageWidth, imageHeight);

                before_image = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);

                newsMs = GetImage(before_image, before_image.Width, before_image.Height);

                Images thumb = new Images(thumbnail_id, ms.GetBuffer());
                thumb.Title = jpeg_image_upload.FileName.Substring(0, jpeg_image_upload.FileName.Length - 4);
                thumb.ImagesDataBefore = newsMs.GetBuffer();
                thumb.ImageName = jpeg_image_upload.FileName;
                //newMS.Close();
                //thumb.ImageType = jpeg_image_upload.FileName;
                // Put it all in the Session (initialize the session if necessary)	


                //List<Images> thumbnails = Session["file_info"] as List<Images>;
                List<Images> thumbnails = Session[sessionStr] as List<Images>;

                if (thumbnails == null)
                {
                    //thumbnails = new List<Thumbnail>();
                    thumbnails = new List<Images>();
                    //Session["file_info"] = thumbnails;
                    Session[sessionStr] = thumbnails;
                }
                thumbnails.Add(thumb);

                Response.StatusCode = 200;
                Response.Write(thumbnail_id);
            }
            catch
            {
                Response.StatusCode = 500;
                Response.Write("An error occured");
                Response.End();
            }
            finally
            {
                if (final_image != null) final_image.Dispose();
                if (graphic != null) graphic.Dispose();
                if (original_image != null) original_image.Dispose();
                if (thumbnail_image != null) thumbnail_image.Dispose();
                if (ms != null) 
                { 
                    ms.Close(); 
                }

                if (before_image != null) before_image.Dispose();
                if (before_bit != null) before_bit.Dispose();
                if (newsMs != null) newsMs.Close();
                Response.End();
            }

        }

        /// <summary>
        /// 输出图片内存
        /// </summary>
        /// <param name="original_image"></param>
        /// <param name="target_width"></param>
        /// <param name="target_height"></param>
        /// <returns></returns>
        private MemoryStream GetImage(System.Drawing.Image original_image, int target_width, int target_height)
        {
            System.Drawing.Bitmap final_image = null;
            System.Drawing.Graphics graphic = null;
            int width = original_image.Width;
            int height = original_image.Height;
            int new_width, new_height;

            float target_ratio = (float)target_width / (float)target_height;
            float image_ratio = (float)width / (float)height;

            if (target_ratio > image_ratio)
            {
                new_height = target_height;
                new_width = (int)Math.Floor(image_ratio * (float)target_height);
            }
            else
            {
                new_height = (int)Math.Floor((float)target_width / image_ratio);
                new_width = target_width;
            }
            new_width = new_width > target_width ? target_width : new_width;
            new_height = new_height > target_height ? target_height : new_height;
            final_image = new System.Drawing.Bitmap(target_width, target_height);
            graphic = System.Drawing.Graphics.FromImage(final_image);
            graphic.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Rectangle(0, 0, target_width, target_height));
            int paste_x = (target_width - new_width) / 2;
            int paste_y = (target_height - new_height) / 2;
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; /* new way */

            graphic.DrawImage(original_image, paste_x, paste_y, new_width, new_height);
            MemoryStream ms = new MemoryStream();
            final_image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();
            graphic.Dispose();
            return ms;
        }
        /// <summary>
        /// 随机数
        /// </summary>
        /// <returns></returns>
        private string GetRandom()
        {
            Random ra = new Random();
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += ra.Next(0, 9);
            }
            return str;
        }
    
    }
}