using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class UserAccount
	{
		public UserAccount()
		{}
		#region Model
		private int _accountid;
		private string _username="";
		private decimal _fundsmoney=0.00M;
		private decimal _frozenmoney=0.00M;
		private int _levelintegral=0;
		private int _consintegral=0;
		private DateTime _modifydate= DateTime.Now;
		private string _detail="";
		private string _types="";
		/// <summary>
		/// 用户账户表ID
		/// </summary>
		public int AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
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
		/// 可用资金
		/// </summary>
		public decimal FundsMoney
		{
			set{ _fundsmoney=value;}
			get{return _fundsmoney;}
		}
		/// <summary>
		/// 冻结资金
		/// </summary>
		public decimal FrozenMoney
		{
			set{ _frozenmoney=value;}
			get{return _frozenmoney;}
		}
		/// <summary>
		/// 等级积分
		/// </summary>
		public int LevelIntegral
		{
			set{ _levelintegral=value;}
			get{return _levelintegral;}
		}
		/// <summary>
		/// 消费积分
		/// </summary>
		public int ConsIntegral
		{
			set{ _consintegral=value;}
			get{return _consintegral;}
		}
		/// <summary>
		/// 修改时间（账户变动时间）
		/// </summary>
		public DateTime ModifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 详细（账户变动原因）
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		#endregion Model

	}
}

