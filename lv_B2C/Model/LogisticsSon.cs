using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class LogisticsSon
	{
		public LogisticsSon()
		{}
		#region Model
		private int _id=0;
		private int _logisticsid=0;
		private string _cityidlist="";
		private decimal _defaultmoney=0.00M;
		private decimal _beyondmoney=0.00M;
		private string _detail="";
		/// <summary>
		/// 物流子表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 物流信息ID
		/// </summary>
		public int LogisticsID
		{
			set{ _logisticsid=value;}
			get{return _logisticsid;}
		}
		/// <summary>
		/// 运送到（偏远城市、特殊城市特殊邮费）
		/// </summary>
		public string CityIDList
		{
			set{ _cityidlist=value;}
			get{return _cityidlist;}
		}
		/// <summary>
		/// 默认邮费
		/// </summary>
		public decimal DefaultMoney
		{
			set{ _defaultmoney=value;}
			get{return _defaultmoney;}
		}
		/// <summary>
		/// 超出邮费
		/// </summary>
		public decimal BeyondMoney
		{
			set{ _beyondmoney=value;}
			get{return _beyondmoney;}
		}
		/// <summary>
		/// 详细
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		#endregion Model

	}
}

