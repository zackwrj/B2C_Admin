using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告表
	/// </summary>
	[Serializable]
	public partial class AdPage
	{
		public AdPage()
		{}
		#region Model
		private int _adpageid;
		private string _title="";
		private string _pagepath="";
		private string _previewimage="";
		private string _detail="";
		private int _siteid=0;
		private int _isshow=0;
		private int _isdel=0;
		private string _types= "0";
		private int _sort=0;
		private int _tag=0;
		private string _stringvalue="";
		private int _extendid=0;
		/// <summary>
		/// 广告页面ID
		/// </summary>
		public int ADPageID
		{
			set{ _adpageid=value;}
			get{return _adpageid;}
		}
		/// <summary>
		/// 页面标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 页面路径
		/// </summary>
		public string PagePath
		{
			set{ _pagepath=value;}
			get{return _pagepath;}
		}
		/// <summary>
		/// 预览图片
		/// </summary>
		public string PreviewImage
		{
			set{ _previewimage=value;}
			get{return _previewimage;}
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
		/// 分站ID
		/// </summary>
		public int SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 是否显示
		/// </summary>
		public int IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 是否逻辑删除
		/// </summary>
		public int IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
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
		/// 排序
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
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
		/// 内容扩展表ID
		/// </summary>
		public int ExtendID
		{
			set{ _extendid=value;}
			get{return _extendid;}
		}
		#endregion Model

	}
}

