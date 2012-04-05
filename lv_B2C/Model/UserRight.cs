using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 用户权限表
	/// </summary>
	[Serializable]
	public partial class UserRight
	{
		public UserRight()
		{}
		#region Model
		private int _userrightid;
		private int _parentid=0;
		private string _title="";
		private bool _isavailable= false;
		private string _detail="";
		private string _images="";
		private int _albumid=0;
		private int _tag=0;
		private string _types="";
		private int _sort=0;
		private int _siteid=0;
		private string _link="";
		private string _jasonvlaue="";
		private string _stringarrayvalue="";
		private int _extendid=0;
		/// <summary>
		/// 用户权限表ID
		/// </summary>
		public int UserRightID
		{
			set{ _userrightid=value;}
			get{return _userrightid;}
		}
		/// <summary>
		/// 父ID（首级ID为0）
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 用户权限标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 是否生效
		/// </summary>
		public bool IsAvailable
		{
			set{ _isavailable=value;}
			get{return _isavailable;}
		}
		/// <summary>
		/// 详细信息
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 用户权限图片
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
		/// 标识符
		/// </summary>
		public int Tag
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
		/// <summary>
		/// 排序
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
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
		/// 资讯外部链接
		/// </summary>
		public string Link
		{
			set{ _link=value;}
			get{return _link;}
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

