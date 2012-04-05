using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ProductFields
	{
		public ProductFields()
		{}
		#region Model
		private int _productfieldsid=0;
		private int _fieldclassid=0;
        private int _parentid = 0;
		private string _title="";
		private string _alt="";
		private int _fieldquantity = 0;
		private decimal _fieldprice=0;
		private string _firstletter="";
		private string _detail="";
		private string _images="";
		private int _isuseimg=0;
		private int _isselected=0;
		private int _ischoice=0;
		private int _iswhere=0;
		private int _showorder=0;
		private DateTime _createdate= DateTime.Now;
		private DateTime _lastmodifydate= DateTime.Now;
		private int _hits=0;
		private int _isshow=0;
		private string _types="";
		private int _tag=0;
		private string _stringvalue="";
		private int _isdel=0;
		private int _sort=0;
		private int _extendid=0;
		/// <summary>
		/// 商品属性ID
		/// </summary>
		public int ProductFieldsID
		{
			set{ _productfieldsid=value;}
			get{return _productfieldsid;}
		}
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
		/// <summary>
		/// 属性类别ID
		/// </summary>
		public int FieldClassID
		{
			set{ _fieldclassid=value;}
			get{return _fieldclassid;}
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
		/// 描述（用于a标签或图片的Alt）
		/// </summary>
		public string Alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		/// 属性数量（不同属性商品库存量可能不同）
		/// </summary>
		public int FieldQuantity
		{
			set{ _fieldquantity=value;}
			get{return _fieldquantity;}
		}
		/// <summary>
		/// 属性价格（不同属性商品可能会有不同的价格）
		/// </summary>
		public decimal FieldPrice
		{
			set{ _fieldprice=value;}
			get{return _fieldprice;}
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
		/// 属性图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 是否使用图片（如：颜色可使用图片或文字）
		/// </summary>
		public int IsUseImg
		{
			set{ _isuseimg=value;}
			get{return _isuseimg;}
		}
		/// <summary>
		/// 是否默认选中（可用于推荐某个属性的商品）
		/// </summary>
		public int IsSelected
		{
			set{ _isselected=value;}
			get{return _isselected;}
		}
		/// <summary>
		/// 是否供用户选择
		/// </summary>
		public int IsChoice
		{
			set{ _ischoice=value;}
			get{return _ischoice;}
		}
		/// <summary>
		/// 是否做为筛选条件
		/// </summary>
		public int IsWhere
		{
			set{ _iswhere=value;}
			get{return _iswhere;}
		}
		/// <summary>
		/// 显示排序
		/// </summary>
		public int ShowOrder
		{
			set{ _showorder=value;}
			get{return _showorder;}
		}
		/// <summary>
		/// 创建时间

		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime LastModifyDate
		{
			set{ _lastmodifydate=value;}
			get{return _lastmodifydate;}
		}
		/// <summary>
		/// 点击次数

		/// </summary>
		public int Hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 是否显示（例：隐藏换季商品）
		/// </summary>
		public int IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 标识符
		/// </summary>
		public int Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// 预留字段（字符串分割）
		/// </summary>
		public string StringValue
		{
			set{ _stringvalue=value;}
			get{return _stringvalue;}
		}
		/// <summary>
		/// 是否删除

		/// </summary>
		public int IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 排序

		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 扩展ID
		/// </summary>
		public int ExtendID
		{
			set{ _extendid=value;}
			get{return _extendid;}
		}
		#endregion Model

	}
}

