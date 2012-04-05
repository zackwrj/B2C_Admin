using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class LogDetail
	{
		public LogDetail()
		{}
		#region Model
		private int _detailid;
		private int _logid=0;
		private string _fieldname="";
		private string _fieldalias="";
		private string _fieldoriginalvalue="";
		private string _fieldvalue="";
		private DateTime _modifydate= DateTime.Now;
		private string _modifydetail="";
		/// <summary>
		/// 订单日志详细ID
		/// </summary>
		public int DetailID
		{
			set{ _detailid=value;}
			get{return _detailid;}
		}
		/// <summary>
		/// 所属订单日志
		/// </summary>
		public int LogID
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// 字段名
		/// </summary>
		public string FieldName
		{
			set{ _fieldname=value;}
			get{return _fieldname;}
		}
		/// <summary>
		/// 字段别名
		/// </summary>
		public string FieldAlias
		{
			set{ _fieldalias=value;}
			get{return _fieldalias;}
		}
		/// <summary>
		/// 字段原始值
		/// </summary>
		public string FieldOriginalValue
		{
			set{ _fieldoriginalvalue=value;}
			get{return _fieldoriginalvalue;}
		}
		/// <summary>
		/// 字段当前值
		/// </summary>
		public string FieldValue
		{
			set{ _fieldvalue=value;}
			get{return _fieldvalue;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime ModifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 修改说明
		/// </summary>
		public string ModifyDetail
		{
			set{ _modifydetail=value;}
			get{return _modifydetail;}
		}
		#endregion Model

	}
}

