using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ProductPics
	{
		public ProductPics()
		{}
		#region Model
		private int _picsid=0;
		private int _productid=0;
		private string _title="";
		private string _title_en="";
		private string _alt="";
		private string _products="";
		private string _productm="";
		private string _productl="";
		private int _productfieldid=0;
		private string _detail="";
		private int _extendid=0;
		/// <summary>
		/// 商品多图ID
		/// </summary>
		public int PicsID
		{
			set{ _picsid=value;}
			get{return _picsid;}
		}
		/// <summary>
		/// 商品ID
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
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
		/// 英文标题（可用于二级域名、目录名）
		/// </summary>
		public string Title_en
		{
			set{ _title_en=value;}
			get{return _title_en;}
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
		/// 小图
		/// </summary>
		public string ProductS
		{
			set{ _products=value;}
			get{return _products;}
		}
		/// <summary>
		/// 中图
		/// </summary>
		public string ProductM
		{
			set{ _productm=value;}
			get{return _productm;}
		}
		/// <summary>
		/// 大图

		/// </summary>
		public string ProductL
		{
			set{ _productl=value;}
			get{return _productl;}
		}
		/// <summary>
		/// 商品属性ID
		/// </summary>
		public int ProductFieldID
		{
			set{ _productfieldid=value;}
			get{return _productfieldid;}
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
		#endregion Model

	}
}

