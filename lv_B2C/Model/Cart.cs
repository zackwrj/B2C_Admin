using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告位置表
	/// </summary>
	[Serializable]
	public partial class Cart
	{
		public Cart()
		{}
		#region Model
		private int _cartid=0;
		private string _username="";
		private int _productid=0;
		private string _productfieldidlist="";
		private int _quantity=0;
		private decimal _productprice=0.00M;
		private decimal _producttotalprice=0.00M;
		private string _detail="";
		/// <summary>
		/// 购物车
		/// </summary>
		public int CartID
		{
			set{ _cartid=value;}
			get{return _cartid;}
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
		/// 商品ID
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品属性ID
		/// </summary>
		public string ProductFieldIDList
		{
			set{ _productfieldidlist=value;}
			get{return _productfieldidlist;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 商品单价
		/// </summary>
		public decimal ProductPrice
		{
			set{ _productprice=value;}
			get{return _productprice;}
		}
		/// <summary>
		/// 商品总价
		/// </summary>
		public decimal ProductTotalPrice
		{
			set{ _producttotalprice=value;}
			get{return _producttotalprice;}
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

