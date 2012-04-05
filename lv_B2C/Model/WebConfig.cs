using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 网站配置表
	/// </summary>
	[Serializable]
	public partial class WebConfig
	{
		public WebConfig()
		{}
		#region Model
		private int _settingid;
		private string _attribute="";
		private string _setting="";
		private int _isavailable=0;
		private string _detail="";
		private int _tag=0;
		private string _types="";
		private int _sort=0;
		private int _siteid=0;
		private string _link="";
		private string _jasonvlaue="";
		private string _stringarrayvalue="";
		private int _extendid=0;
		/// <summary>
		/// 配置ID
		/// </summary>
		public int SettingID
		{
			set{ _settingid=value;}
			get{return _settingid;}
		}
		/// <summary>
		/// 属性
		/// </summary>
		public string Attribute
		{
			set{ _attribute=value;}
			get{return _attribute;}
		}
		/// <summary>
		/// 值
		/// </summary>
		public string Setting
		{
			set{ _setting=value;}
			get{return _setting;}
		}
		/// <summary>
		/// 是否生效
		/// </summary>
		public int IsAvailable
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

