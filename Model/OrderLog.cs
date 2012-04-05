using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class OrderLog
	{
		public OrderLog()
		{}
		#region Model
		private int _logid=0;
		private int _orderid=0;
		private string _operateby="";
		private DateTime _operatedate= DateTime.Now;
		private string _operatedetail="";
		/// <summary>
		/// 订单日志表ID
		/// </summary>
		public int LogID
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// 订单ID
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 操作者
		/// </summary>
		public string OperateBy
		{
			set{ _operateby=value;}
			get{return _operateby;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperateDate
		{
			set{ _operatedate=value;}
			get{return _operatedate;}
		}
		/// <summary>
		/// 操作说明
		/// </summary>
		public string OperateDetail
		{
			set{ _operatedetail=value;}
			get{return _operatedetail;}
		}
		#endregion Model

	}
}

