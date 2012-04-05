using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class ProductStock
	{
		public ProductStock()
		{}
		#region Model
		private int _id=0;
		private int _cityid=0;
		private int _productid=0;
		private int _quantity=0;
		private DateTime _createdate= DateTime.Now;
		private DateTime _emptydate= DateTime.Now;
		private string _types="";
		/// <summary>
		/// 商品库存表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 城市ID
		/// </summary>
		public int CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 商品ID
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 库存量
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
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
		/// 最后修改时间
		/// </summary>
		public DateTime EmptyDate
		{
			set{ _emptydate=value;}
			get{return _emptydate;}
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

