using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// Activity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Activity
	{
		public Activity()
		{}
		#region Model
		private int _activityid=0;
		private string _title="";
		private string _title_en="";
		private string _alt="";
		private string _images="";
		private DateTime _starttime= DateTime.Now;
		private DateTime _endtime= DateTime.Now;
		private string _userroles="";
		private string _actrangelist="";
		private int _rangetype=0;
		private decimal _minamount=0.00M;
		private int _iswithdiscount=0;
		private int _albumid=0;
		private int _way=0;
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
		/// 活动表ID
		/// </summary>
		public int ActivityID
		{
			set{ _activityid=value;}
			get{return _activityid;}
		}
		/// <summary>
		/// 商品标题
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
		/// 图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 用户角色（活动范围）
		/// </summary>
		public string UserRoles
		{
			set{ _userroles=value;}
			get{return _userroles;}
		}
		/// <summary>
		/// 活动范围（品牌ID、分类ID、商品ID）
		/// </summary>
		public string ActRangeList
		{
			set{ _actrangelist=value;}
			get{return _actrangelist;}
		}
		/// <summary>
		/// 活动范围（品牌ID、分类ID、商品ID）
		/// </summary>
		public int RangeType
		{
			set{ _rangetype=value;}
			get{return _rangetype;}
		}
		/// <summary>
		/// 金额下限
		/// </summary>
		public decimal MinAmount
		{
			set{ _minamount=value;}
			get{return _minamount;}
		}
		/// <summary>
		/// 打折商品是否参与
		/// </summary>
		public int IsWithDiscount
		{
			set{ _iswithdiscount=value;}
			get{return _iswithdiscount;}
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
		/// 活动方式（享受折扣、现金减免、赠品）
		/// </summary>
		public int Way
		{
			set{ _way=value;}
			get{return _way;}
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

