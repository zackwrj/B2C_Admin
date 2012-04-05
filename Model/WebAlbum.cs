using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 相册表
	/// </summary>
	[Serializable]
	public partial class WebAlbum
	{
		public WebAlbum()
		{}
		#region Model
		private int _albumid;
		private int _parentid=0;
		private int _rootid=0;
		private string _albumtypes="";
		private int _albumproperty=0;
		private string _title="";
		private string _title_en="";
		private string _images="";
		private string _detail="";
		private string _link="";
		private int _openmode=0;
		private int _reviewtype=0;
		private int _righttype=0;
		private DateTime _createdate= DateTime.Now;
		private string _createby="";
		private int _hits=0;
		private int _siteid=0;
		private int _isshow=1;
		private int _isdel=0;
		private string _types="";
		private int _sort=0;
		private int _tag=0;
		private string _jasonvlaue="";
		private string _stringarrayvalue="";
		private int _extendid=0;
		/// <summary>
		/// 相册ID
		/// </summary>
		public int AlbumID
		{
			set{ _albumid=value;}
			get{return _albumid;}
		}
		/// <summary>
		/// 父ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 根ID（自身是根级时为0）
		/// </summary>
		public int RootID
		{
			set{ _rootid=value;}
			get{return _rootid;}
		}
		/// <summary>
		/// 相册类型
		/// </summary>
		public string AlbumTypes
		{
			set{ _albumtypes=value;}
			get{return _albumtypes;}
		}
		/// <summary>
		/// 相册属性
		/// </summary>
		public int AlbumProperty
		{
			set{ _albumproperty=value;}
			get{return _albumproperty;}
		}
		/// <summary>
		/// 相册标题
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
		/// 相册图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 相册详细信息
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 相册外部链接
		/// </summary>
		public string Link
		{
			set{ _link=value;}
			get{return _link;}
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
		/// 相册内信息审核类型
		/// </summary>
		public int ReviewType
		{
			set{ _reviewtype=value;}
			get{return _reviewtype;}
		}
		/// <summary>
		/// 相册权限类型（阅读权限控制，积分管理）
		/// </summary>
		public int RightType
		{
			set{ _righttype=value;}
			get{return _righttype;}
		}
		/// <summary>
		/// 发布日期
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 发布者
		/// </summary>
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
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
		/// 预留字段（JASON格式）
		/// </summary>
		public string JasonVlaue
		{
			set{ _jasonvlaue=value;}
			get{return _jasonvlaue;}
		}
		/// <summary>
		/// 预留字段（字符串数组格式）
		/// </summary>
		public string StringArrayValue
		{
			set{ _stringarrayvalue=value;}
			get{return _stringarrayvalue;}
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

