using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 图片表
	/// </summary>
	[Serializable]
	public partial class WebImage
	{
		public WebImage()
		{}
		#region Model
		private int _imageid;
		private int _albumid=0;
		private string _url="";
		private string _link="";
		private string _title="";
		private string _title_en="";
		private string _tips="";
		private string _detail="";
		private string _author="";
		private string _imgtypes="";
		private int _approvedstate=0;
		private string _approvedtimelist="";
		private string _imgfrom="";
		private DateTime _createdate= DateTime.Now;
		private string _createby="";
		private DateTime _modifydate= DateTime.Now;
		private string _modifyby="";
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
		/// 图片ID
		/// </summary>
		public int ImageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
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
		/// 图片地址
		/// </summary>
		public string URL
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 图片外部链接
		/// </summary>
		public string Link
		{
			set{ _link=value;}
			get{return _link;}
		}
		/// <summary>
		/// 图片标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 图片英文标题
		/// </summary>
		public string Title_en
		{
			set{ _title_en=value;}
			get{return _title_en;}
		}
		/// <summary>
		/// 图片小标题(alt)
		/// </summary>
		public string Tips
		{
			set{ _tips=value;}
			get{return _tips;}
		}
		/// <summary>
		/// 图片详细信息
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 作者
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 图片类型
		/// </summary>
		public string ImgTypes
		{
			set{ _imgtypes=value;}
			get{return _imgtypes;}
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
		/// 图片来源
		/// </summary>
		public string ImgFrom
		{
			set{ _imgfrom=value;}
			get{return _imgfrom;}
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
		/// 修改日期
		/// </summary>
		public DateTime ModifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 修改者
		/// </summary>
		public string ModifyBy
		{
			set{ _modifyby=value;}
			get{return _modifyby;}
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

