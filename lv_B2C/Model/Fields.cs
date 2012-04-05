using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// Fields:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Fields
	{
		public Fields()
		{}
		#region Model
		private int _fieldsid=0;
		private int _fieldsclassid=0;
		private int _parentid=0;
		private string _title="";
		private string _alt="";
		private string _firstletter="";
		private string _detail="";
		private string _images="";
		private int _isuseimg=0;
		private int _isselected=0;
		private int _ischoice=0;
		private int _iswhere=0;
		private int _showorder=0;
		/// <summary>
		/// 商品属性ID
		/// </summary>
		public int FieldsID
		{
			set{ _fieldsid=value;}
			get{return _fieldsid;}
		}
		/// <summary>
		/// 属性类别ID
		/// </summary>
		public int FieldsClassID
		{
			set{ _fieldsclassid=value;}
			get{return _fieldsclassid;}
		}
		/// <summary>
		/// 
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
		/// 描述（用于a标签或图片的Alt）
		/// </summary>
		public string Alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		/// 拼音（或英文、数字）首字母
		/// </summary>
		public string FirstLetter
		{
			set{ _firstletter=value;}
			get{return _firstletter;}
		}
		/// <summary>
		/// 详细
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 属性图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 是否使用图片（如：颜色可使用图片或文字）
		/// </summary>
		public int IsUseImg
		{
			set{ _isuseimg=value;}
			get{return _isuseimg;}
		}
		/// <summary>
		/// 是否默认选中（可用于推荐某个属性的商品）
		/// </summary>
		public int IsSelected
		{
			set{ _isselected=value;}
			get{return _isselected;}
		}
		/// <summary>
		/// 是否供用户选择
		/// </summary>
		public int IsChoice
		{
			set{ _ischoice=value;}
			get{return _ischoice;}
		}
		/// <summary>
		/// 是否做为筛选条件
		/// </summary>
		public int IsWhere
		{
			set{ _iswhere=value;}
			get{return _iswhere;}
		}
		/// <summary>
		/// 显示排序
		/// </summary>
		public int ShowOrder
		{
			set{ _showorder=value;}
			get{return _showorder;}
		}
		#endregion Model

	}
}

