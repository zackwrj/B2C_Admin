using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace lv_B2C.Web
{
    [Serializable]
    public class Images
    {
        public Images()
        { }
        public Images(string id, byte[] data)
        {
            imagesID = id;
            imagesData = data;
        }

        private string imageName;
        private string imagesID;
        private byte[] imagesData;
        private byte[] imagesDataBefore;
        private string imagetype;
        private string url;
        private DateTime createDate;
        private string title;

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        /// <summary>
        /// 图片ID
        /// </summary>
        public string ImagesID
        {
            get { return imagesID; }
            set { imagesID = value; }
        }
        /// <summary>
        /// 压缩后图片
        /// </summary>
        public byte[] ImagesData
        {
            get { return imagesData; }
            set { imagesData = value; }
        }
        /// <summary>
        /// 压缩前图片
        /// </summary>
        public byte[] ImagesDataBefore
        {
            get { return imagesDataBefore; }
            set { imagesDataBefore = value; }
        }
        /// <summary>
        /// 图片URL
        /// </summary>
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 图片类型
        /// </summary>
        public string ImageType
        {
            get
            {
                return GetImageExt(imageName);
            }
        }
        private string GetImageExt(string _ImageExt)
        {
            string[] allowExt = new string[] { ".gif", ".jpg", ".jpeg", ".bmp", ".png" };//*.gif;*.jpg;*.jpeg;*.png;*.bmp
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i] == _ImageExt)
                {
                    return allowExt[i];
                }
            }
            return ".jpg";
            //return false;
        }
    }
}