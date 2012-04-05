using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lv_B2C.Web
{
    public partial class UpLoad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session["UpLoad"] = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        #region 控件属性
        private string file_size_limit = "2 MB";//上传文件大小 file_types: "*.gif;*.jpg;*.jpeg;*.png;*.bmp;",
        private string file_types = "*.gif;*.jpg;*.jpeg;*.png;*.bmp;";// 文件类型 
        private string file_upload_limit = "30";//上传文件数量
        private string controlName="file_info";


        /// <summary>
        /// 上传文件大小 
        /// <para>默认为2MB</para>
        /// </summary>
        public string File_Size_Limit
        {
            get { return file_size_limit; }
            set { file_size_limit = value; }
        }
        /// <summary>
        /// 文件类型
        /// <para>默认为图片类型</para>
        /// <para>*.gif;*.jpg;*.jpeg;*.png;*.bmp;</para>
        /// </summary>
        public string File_Types
        {
            get { return file_types; }
            set { file_types = value; }
        }
        /// <summary>
        /// 上传文件数量
        ///<para>默认数量为50</para> 
        /// </summary>
        public string File_Upload_Limit
        {
            get { return file_upload_limit; }
            set { file_upload_limit = value; }
        }


        private int width = 100;
        private int height = 100;
        /// <summary>
        /// 上传压缩后图片的宽度
        /// <para>单位像素</para>
        /// <para>默认 100px</para>
        /// </summary>
        public int ImageWidth
        {
            get { return width; }
            set { width = value; }
        }
        /// <summary>
        /// 上传压缩后图片的高度
        /// <para>单位像素</para>
        /// <para>默认 100px</para>
        /// </summary>
        public int ImageHeight
        {
            get { return height; }
            set { height = value; }
        }
        /// <summary>
        /// 控件名称
        /// </summary>
        public string ControlName
        {
            get { return controlName; }
            set { controlName = value; }
        }
        #endregion
    }
}