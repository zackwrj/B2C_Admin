using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class Related
	{
		public Related()
		{}
		#region Model
		private int _relatedid=0;
		private string _title="";
		private int? _relatedtype;
		private int _firstid=0;
		private int _secondid=0;
		private int? _tag;
		private string _types="";
		/// <summary>
		/// 相关表ID
		/// </summary>
		public int RelatedID
		{
			set{ _relatedid=value;}
			get{return _relatedid;}
		}
		/// <summary>
		/// 标题（关联说明）
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 相关类型（如：相关新闻、相关商品等）
		/// </summary>
		public int? RelatedType
		{
			set{ _relatedtype=value;}
			get{return _relatedtype;}
		}
		/// <summary>
		/// 第一个ID
		/// </summary>
		public int FirstID
		{
			set{ _firstid=value;}
			get{return _firstid;}
		}
		/// <summary>
		/// 第二个ID
		/// </summary>
		public int SecondID
		{
			set{ _secondid=value;}
			get{return _secondid;}
		}
		/// <summary>
		/// 标识
		/// </summary>
		public int? Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		#endregion Model

	}
}

