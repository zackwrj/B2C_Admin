using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告表
	/// </summary>
	[Serializable]
	public partial class Ad
	{
		public Ad()
		{}
		#region Model
		private int _adid;
		private int _adpositionid=0;
		private int _adtype=0;
		private string _adproperty="";
		private string _title="";
		private string _title_en="";
		private string _detail="";
		private int _approvedstate=0;
		private string _approvedtimelist="";
		private decimal _price=0M;
		private DateTime _begindate= DateTime.Now;
		private DateTime _enddate= DateTime.Now;
		private DateTime _begintime= DateTime.Now;
		private DateTime _endtime= DateTime.Now;
		private string _imgurl="";
		private string _flashurl="";
		private string _txtcontent="";
		private string _codecontent="";
		private string _link="";
		private int _openmode=0;
		private int _albumid=0;
		private int _reviewtype=0;
		private string _username="";
		private string _createby="";
		private DateTime _createdate= DateTime.Now;
		private int _hits=0;
		private int _siteid=0;
		private int _isshow=1;
		private int _isdel=0;
		private string _types="";
		private int _sort=0;
		private int _tag=0;
		private string _stringvalue="";
		private decimal _extendid=0M;
		/// <summary>
		/// 广告ID
		/// </summary>
		public int AdID
		{
			set{ _adid=value;}
			get{return _adid;}
		}
		/// <summary>
		/// 广告位置ID
		/// </summary>
		public int AdPositionID
		{
			set{ _adpositionid=value;}
			get{return _adpositionid;}
		}
		/// <summary>
		/// 广告类型
		/// </summary>
		public int AdType
		{
			set{ _adtype=value;}
			get{return _adtype;}
		}
		/// <summary>
		/// 广告属性
		/// </summary>
		public string AdProperty
		{
			set{ _adproperty=value;}
			get{return _adproperty;}
		}
		/// <summary>
		/// 广告标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 广告英文标题
		/// </summary>
		public string Title_en
		{
			set{ _title_en=value;}
			get{return _title_en;}
		}
		/// <summary>
		/// 广告详细信息
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 审核状态
		/// </summary>
		public int ApprovedState
		{
			set{ _approvedstate=value;}
			get{return _approvedstate;}
		}
		/// <summary>
		/// 审核时间列表
		/// </summary>
		public string ApprovedTimeList
		{
			set{ _approvedtimelist=value;}
			get{return _approvedtimelist;}
		}
		/// <summary>
		/// 广告费用
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 广告投放开始日期
		/// </summary>
		public DateTime BeginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 广告投放结束日期
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 广告投放开始时间
		/// </summary>
		public DateTime BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 广告投放结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 图片广告地址
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// falsh广告地址
		/// </summary>
		public string flashUrl
		{
			set{ _flashurl=value;}
			get{return _flashurl;}
		}
		/// <summary>
		/// 文字广告内容
		/// </summary>
		public string TxtContent
		{
			set{ _txtcontent=value;}
			get{return _txtcontent;}
		}
		/// <summary>
		/// 代码广告内容
		/// </summary>
		public string CodeContent
		{
			set{ _codecontent=value;}
			get{return _codecontent;}
		}
		/// <summary>
		/// 广告外部链接
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
		/// 相册ID
		/// </summary>
		public int AlbumID
		{
			set{ _albumid=value;}
			get{return _albumid;}
		}
		/// <summary>
		/// 广告审核类型
		/// </summary>
		public int ReviewType
		{
			set{ _reviewtype=value;}
			get{return _reviewtype;}
		}
		/// <summary>
		/// 广告投放人
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
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
		/// 广告创建时间
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
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
		public decimal ExtendID
		{
			set{ _extendid=value;}
			get{return _extendid;}
		}
		#endregion Model

	}
}

