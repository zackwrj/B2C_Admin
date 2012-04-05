using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// FieldsClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FieldsClass
	{
		public FieldsClass()
		{}
		#region Model
		private int _fieldsclassid=0;
		private string _title="";
		private string _images="";
		private string _alt="";
		private string _firstletter="";
		private int _isdefault=0;
		private string _detail="";
		/// <summary>
		/// 属性类别ID
		/// </summary>
		public int FieldsClassID
		{
			set{ _fieldsclassid=value;}
			get{return _fieldsclassid;}
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
		/// 图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
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
		/// 
		/// </summary>
		public int IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
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

