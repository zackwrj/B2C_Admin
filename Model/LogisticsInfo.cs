using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class LogisticsInfo
	{
		public LogisticsInfo()
		{}
		#region Model
		private int _logisticsid=0;
		private int _logisticstype=0;
		private decimal _defaultmoney=0.00M;
		private decimal _beyondmoney=0.00M;
		private string _detail="";
		/// <summary>
		/// 物流信息ID
		/// </summary>
		public int LogisticsID
		{
			set{ _logisticsid=value;}
			get{return _logisticsid;}
		}
		/// <summary>
		/// 物流类型（一般为：快递、EMS、平邮）
		/// </summary>
		public int LogisticsType
		{
			set{ _logisticstype=value;}
			get{return _logisticstype;}
		}
		/// <summary>
		/// 默认邮费（每件默认邮费）
		/// </summary>
		public decimal DefaultMoney
		{
			set{ _defaultmoney=value;}
			get{return _defaultmoney;}
		}
		/// <summary>
		/// 超出邮费（每超出一件增加邮费）
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

