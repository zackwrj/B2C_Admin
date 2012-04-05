using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ProductConn
	{
		public ProductConn()
		{}
		#region Model
		private int _productid=0;
		private int _productclassid=0;
		private int _productfieldid=0;
		/// <summary>
		/// 商品ID
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品类别ID
		/// </summary>
		public int ProductClassID
		{
			set{ _productclassid=value;}
			get{return _productclassid;}
		}
		/// <summary>
		/// 商品属性ID
		/// </summary>
		public int ProductFieldID
		{
			set{ _productfieldid=value;}
			get{return _productfieldid;}
		}
		#endregion Model

	}
}

