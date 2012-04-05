using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告位置表
	/// </summary>
	[Serializable]
	public partial class ChannelItem
	{
		public ChannelItem()
		{}
		#region Model
		private int _channelitemid;
		private int _channelid=0;
		private int _channelitemtype=0;
		private string _channelitemproperty="";
		private string _title="";
		private string _title_en="";
		private string _images="";
		private int _albumid=0;
		private string _detail="";
		private int _openmode=0;
		private int _reviewtype=0;
		private int _righttype=0;
		private string _link="";
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
		/// 
		/// </summary>
		public int ChannelItemID
		{
			set{ _channelitemid=value;}
			get{return _channelitemid;}
		}
		/// <summary>
		/// 频道ID
		/// </summary>
		public int ChannelID
		{
			set{ _channelid=value;}
			get{return _channelid;}
		}
		/// <summary>
		/// 栏目类型
		/// </summary>
		public int ChannelItemType
		{
			set{ _channelitemtype=value;}
			get{return _channelitemtype;}
		}
		/// <summary>
		/// 栏目属性
		/// </summary>
		public string ChannelItemProperty
		{
			set{ _channelitemproperty=value;}
			get{return _channelitemproperty;}
		}
		/// <summary>
		/// 栏目标题
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
		/// 栏目图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
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
		/// 栏目详细信息
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 页面打开方式
		/// </summary>
		public int OpenMode
		{
			set{ _openmode=value;}
			get{return _openmode;}
		}
		/// <summary>
		/// 栏目内信息审核类型
		/// </summary>
		public int ReviewType
		{
			set{ _reviewtype=value;}
			get{return _reviewtype;}
		}
		/// <summary>
		/// 栏目内信息权限类型（阅读权限控制，积分管理）
		/// </summary>
		public int RightType
		{
			set{ _righttype=value;}
			get{return _righttype;}
		}
		/// <summary>
		/// 外链地址
		/// </summary>
		public string Link
		{
			set{ _link=value;}
			get{return _link;}
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

