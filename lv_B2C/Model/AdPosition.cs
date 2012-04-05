using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告位置表
	/// </summary>
	[Serializable]
	public partial class AdPosition
	{
		public AdPosition()
		{}
		#region Model
		private int _adpositionid;
		private int _adpageid=0;
		private int _showtype=0;
		private string _title="";
		private string _title_en="";
		private string _detail="";
		private int _width=0;
		private int _height=0;
		private int _adpositiontype=0;
		private string _adpositionproperty="";
		private string _defaultimg="";
		private int _albumid=0;
		private int _siteid=0;
		private int _isshow=1;
		private int _isdel=0;
		private string _types="";
		private int _sort=0;
		private int _tag=0;
		private string _stringvalue="";
		private int _extendid=0;
		/// <summary>
		/// 广告位置ID
		/// </summary>
		public int AdPositionID
		{
			set{ _adpositionid=value;}
			get{return _adpositionid;}
		}
		/// <summary>
		/// 广告页面ID
		/// </summary>
		public int AdPageID
		{
			set{ _adpageid=value;}
			get{return _adpageid;}
		}
		/// <summary>
		/// 展现形式（图片|动画|文本|代码|页面）
		/// </summary>
		public int ShowType
		{
			set{ _showtype=value;}
			get{return _showtype;}
		}
		/// <summary>
		/// 广告位置标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 广告位置英文标题
		/// </summary>
		public string Title_en
		{
			set{ _title_en=value;}
			get{return _title_en;}
		}
		/// <summary>
		/// 广告位置详细信息
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 广告位置宽度
		/// </summary>
		public int Width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 广告位置高度
		/// </summary>
		public int Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 广告位置类型
		/// </summary>
		public int AdPositionType
		{
			set{ _adpositiontype=value;}
			get{return _adpositiontype;}
		}
		/// <summary>
		/// 广告位置属性
		/// </summary>
		public string AdPositionProperty
		{
			set{ _adpositionproperty=value;}
			get{return _adpositionproperty;}
		}
		/// <summary>
		/// 默认图片
		/// </summary>
		public string DefaultImg
		{
			set{ _defaultimg=value;}
			get{return _defaultimg;}
		}
		/// <summary>
		/// 相册ID
		/// </summary>
		public int AlbumID
		{
			set{ _albumid=value;}
			get{return _albumid;}
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

