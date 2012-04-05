using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 用户组表
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private Guid _userid;
		private Guid _rolesid;
		private string _username="";
		private string _password="";
		private string _email="";
		private int _approvedstate=0;
		private string _passwordquestion="";
		private string _passwordanswer="";
		private string _nick="";
		private string _realname="";
		private string _cnname="";
		private string _enname="";
		private string _number="";
		private string _images="";
		private int _albumid=0;
		private string _sex="";
		private string _mobilephone="";
		private string _telphone="";
		private string _detail="";
		private string _country="";
		private string _province="";
		private string _city="";
		private string _town="";
		private string _post="";
		private string _address="";
		private int _siteid=0;
        private DateTime _birthday = DateTime.Now;
		private DateTime _regtime= DateTime.Now;
		private string _lastloginip="";
		private int _visitcount=0;
		private int _isfirst=0;
		private DateTime _lastlogindate= DateTime.Now;
		private int _hits=0;
		private int _isshow=0;
		private string _types="";
		private int _tag=0;
		private string _stringvalue="";
		private int _isdel=0;
		private int _sort=0;
		private int _extendid=0;
		/// <summary>
		/// 用户ID
		/// </summary>
		public Guid UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public Guid RolesID
		{
			set{ _rolesid=value;}
			get{return _rolesid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
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
		/// 密码问题
		/// </summary>
		public string PasswordQuestion
		{
			set{ _passwordquestion=value;}
			get{return _passwordquestion;}
		}
		/// <summary>
		/// 密码问题
		/// </summary>
		public string PasswordAnswer
		{
			set{ _passwordanswer=value;}
			get{return _passwordanswer;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string Nick
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 中文名
		/// </summary>
		public string CnName
		{
			set{ _cnname=value;}
			get{return _cnname;}
		}
		/// <summary>
		/// 英文名
		/// </summary>
		public string EnName
		{
			set{ _enname=value;}
			get{return _enname;}
		}
		/// <summary>
		/// 用户编号
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 用户头像
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 用户相册ID
		/// </summary>
		public int AlbumID
		{
			set{ _albumid=value;}
			get{return _albumid;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string MobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string TelPhone
		{
			set{ _telphone=value;}
			get{return _telphone;}
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
		/// 国籍
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 区
		/// </summary>
		public string Town
		{
			set{ _town=value;}
			get{return _town;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string Post
		{
			set{ _post=value;}
			get{return _post;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
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
		/// 用户生日
		/// </summary>
		public DateTime Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 最后登录IP
		/// </summary>
		public string LastLoginIP
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
		}
		/// <summary>
		/// 访问次数
		/// </summary>
		public int VisitCount
		{
			set{ _visitcount=value;}
			get{return _visitcount;}
		}
		/// <summary>
		/// 是否首次
		/// </summary>
		public int IsFirst
		{
			set{ _isfirst=value;}
			get{return _isfirst;}
		}
		/// <summary>
		/// 最后登录时间
		/// </summary>
		public DateTime LastLoginDate
		{
			set{ _lastlogindate=value;}
			get{return _lastlogindate;}
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

