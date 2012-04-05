using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ProductFieldClass
	{
		public ProductFieldClass()
		{}
		#region Model
		private int _fieldclassid=0;
		private string _title="";
		private string _images="";
		private string _alt="";
		private string _firstletter="";
		private string _detail="";
        private int _isdefault = 0;
		private int _extendid=0;
		private int _extendtypeid=0;
		/// <summary>
		/// 属性类别ID
		/// </summary>
		public int FieldClassID
		{
			set{ _fieldclassid=value;}
			get{return _fieldclassid;}
		}
        /// <summary>
        /// 是否默认
        /// </summary>
        public int IsDefault
        {
            set { _isdefault = value; }
            get { return _isdefault; }
        }
		
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 描述（用于a标签或图片的Alt）
		/// </summary>
		public string Alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		/// 拼音（或英文、数字）首字母

		/// </summary>
		public string FirstLetter
		{
			set{ _firstletter=value;}
			get{return _firstletter;}
		}
		/// <summary>
		/// 详细
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 扩展ID
		/// </summary>
		public int ExtendID
		{
			set{ _extendid=value;}
			get{return _extendid;}
		}
		/// <summary>
		/// 扩展类型ID

		/// </summary>
		public int ExtendTypeID
		{
			set{ _extendtypeid=value;}
			get{return _extendtypeid;}
		}
		#endregion Model

	}
}

