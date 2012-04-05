using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ExtendType
	{
		public ExtendType()
		{}
		#region Model
		private int _extendtypeid;
		private string _typename="";
		private string _typename_en="";
		private string _tablename="";
		private string _detail="";
		private DateTime _createdate= DateTime.Now;
		private string _f1_define="";
		private string _f2_define="";
		private string _f3_define="";
		private string _f4_define="";
		private string _f5_define="";
		private string _f6_define="";
		private string _f7_define="";
		private string _f8_define="";
		private string _f9_define="";
		private string _fa_define="";
		private string _fb_define="";
		private string _fc_define="";
		private string _fd_define="";
		private string _fe_define="";
		private string _ff_define="";
		private string _fg_define="";
		private string _fh_define="";
		private string _fi_define="";
		private string _fj_define="";
		private string _fk_define="";
		private string _fl_define="";
		private string _fm_define="";
		private string _fn_define="";
		private string _fo_define="";
		private string _fp_define="";
		private string _fq_define="";
		private string _fr_define="";
		private string _fs_define="";
		private string _ft_define="";
		private string _fu_define="";
		private string _fv_define="";
		private string _fw_define="";
		private string _fx_define="";
		private string _fy_define="";
		private string _fz_define="";
		/// <summary>
		/// 内容扩展类型ID
		/// </summary>
		public int ExtendTypeID
		{
			set{ _extendtypeid=value;}
			get{return _extendtypeid;}
		}
		/// <summary>
		/// 内容扩展类型名称
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 扩展类型英文名称
		/// </summary>
		public string TypeName_en
		{
			set{ _typename_en=value;}
			get{return _typename_en;}
		}
		/// <summary>
		/// 相关表的名称
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 详细说明
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
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
		/// 扩展字段定义说明
		/// </summary>
		public string F1_define
		{
			set{ _f1_define=value;}
			get{return _f1_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F2_define
		{
			set{ _f2_define=value;}
			get{return _f2_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F3_define
		{
			set{ _f3_define=value;}
			get{return _f3_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F4_define
		{
			set{ _f4_define=value;}
			get{return _f4_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F5_define
		{
			set{ _f5_define=value;}
			get{return _f5_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F6_define
		{
			set{ _f6_define=value;}
			get{return _f6_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F7_define
		{
			set{ _f7_define=value;}
			get{return _f7_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F8_define
		{
			set{ _f8_define=value;}
			get{return _f8_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string F9_define
		{
			set{ _f9_define=value;}
			get{return _f9_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FA_define
		{
			set{ _fa_define=value;}
			get{return _fa_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FB_define
		{
			set{ _fb_define=value;}
			get{return _fb_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FC_define
		{
			set{ _fc_define=value;}
			get{return _fc_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FD_define
		{
			set{ _fd_define=value;}
			get{return _fd_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FE_define
		{
			set{ _fe_define=value;}
			get{return _fe_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FF_define
		{
			set{ _ff_define=value;}
			get{return _ff_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FG_define
		{
			set{ _fg_define=value;}
			get{return _fg_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FH_define
		{
			set{ _fh_define=value;}
			get{return _fh_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FI_define
		{
			set{ _fi_define=value;}
			get{return _fi_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FJ_define
		{
			set{ _fj_define=value;}
			get{return _fj_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FK_define
		{
			set{ _fk_define=value;}
			get{return _fk_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FL_define
		{
			set{ _fl_define=value;}
			get{return _fl_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FM_define
		{
			set{ _fm_define=value;}
			get{return _fm_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FN_define
		{
			set{ _fn_define=value;}
			get{return _fn_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FO_define
		{
			set{ _fo_define=value;}
			get{return _fo_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FP_define
		{
			set{ _fp_define=value;}
			get{return _fp_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FQ_define
		{
			set{ _fq_define=value;}
			get{return _fq_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FR_define
		{
			set{ _fr_define=value;}
			get{return _fr_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FS_define
		{
			set{ _fs_define=value;}
			get{return _fs_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FT_define
		{
			set{ _ft_define=value;}
			get{return _ft_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FU_define
		{
			set{ _fu_define=value;}
			get{return _fu_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FV_define
		{
			set{ _fv_define=value;}
			get{return _fv_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FW_define
		{
			set{ _fw_define=value;}
			get{return _fw_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FX_define
		{
			set{ _fx_define=value;}
			get{return _fx_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FY_define
		{
			set{ _fy_define=value;}
			get{return _fy_define;}
		}
		/// <summary>
		/// 扩展字段定义说明
		/// </summary>
		public string FZ_define
		{
			set{ _fz_define=value;}
			get{return _fz_define;}
		}
		#endregion Model

	}
}

