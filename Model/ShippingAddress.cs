using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ShippingAddress
	{
		public ShippingAddress()
		{}
		#region Model
		private int _addressid=0;
		private string _username="";
		private string _consignee="";
		private string _province="";
		private string _city="";
		private string _town="";
		private string _post="";
		private string _address="";
		private string _mobilephone="";
		private string _telphone="";
		private int _isdefault=0;
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
		/// 收货地址ID
		/// </summary>
		public int AddressID
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		/// <summary>
		/// 所属用户
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 收货人
		/// </summary>
		public string Consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
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
		/// 手机号码
		/// </summary>
		public string MobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 座机号码
		/// </summary>
		public string TelPhone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public int IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
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
		/// 是否显示
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

