using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class LogisticsCompany
	{
		public LogisticsCompany()
		{}
		#region Model
		private int _id=0;
		private int _logisticsid=0;
		private string _title="";
		private string _title_en="";
		private string _alt="";
		private string _detail="";
		/// <summary>
		/// 物流公司ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 物流类型ID
		/// </summary>
		public int LogisticsID
		{
			set{ _logisticsid=value;}
			get{return _logisticsid;}
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
		/// 英文标题（可用于二级域名、目录名）
		/// </summary>
		public string Title_en
		{
			set{ _title_en=value;}
			get{return _title_en;}
		}
		/// <summary>
		/// 描述（用于a标签或图片的Alt）
		/// </summary>
		public string Alt
		{
			set{ _alt=value;}
			get{return _alt;}
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

