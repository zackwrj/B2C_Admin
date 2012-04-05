using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ProductClass
	{
		public ProductClass()
		{}
		#region Model
		private int _productclassid=0;
		private int _lftid=0;
		private int _rgtid=0;
		private int _parentid=0;
		private int _rootid=0;
		private int _productfieldclassid=0;
		private string _title="";
		private string _alt="";
		private string _images="";
		private string _firstletter="";
		private string _readme="";
		private string _classkeyword="";
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
		/// 商品类别ID
		/// </summary>
		public int ProductClassID
		{
			set{ _productclassid=value;}
			get{return _productclassid;}
		}
		/// <summary>
		/// 类别左值（用于无限级分类）
		/// </summary>
		public int LftID
		{
			set{ _lftid=value;}
			get{return _lftid;}
		}
		/// <summary>
		/// 类别右值（用于无限级分类）
		/// </summary>
		public int RgtID
		{
			set{ _rgtid=value;}
			get{return _rgtid;}
		}
		/// <summary>
		/// 父级ID

		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 根级ID
		/// </summary>
		public int RootID
		{
			set{ _rootid=value;}
			get{return _rootid;}
		}
		/// <summary>
		/// 商品属性类别ID（在创建类别时选择此类别属于什么类型）
		/// </summary>
		public int ProductFieldClassID
		{
			set{ _productfieldclassid=value;}
			get{return _productfieldclassid;}
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
		/// 图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
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
		/// 类别自述（用于内部查看）
		/// </summary>
		public string Readme
		{
			set{ _readme=value;}
			get{return _readme;}
		}
		/// <summary>
		/// 类别关键字
		/// </summary>
		public string ClassKeyWord
		{
			set{ _classkeyword=value;}
			get{return _classkeyword;}
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

