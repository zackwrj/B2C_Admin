using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告位置表
	/// </summary>
	[Serializable]
	public partial class Citys
	{
		public Citys()
		{}
		#region Model
		private int _cityid=0;
		private int _parentid=0;
		private string _title="";
		private int _citylevel=0;
		/// <summary>
		/// 城市ID
		/// </summary>
		public int CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 父级ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 等级
		/// </summary>
		public int CityLevel
		{
			set{ _citylevel=value;}
			get{return _citylevel;}
		}
		#endregion Model

	}
}

