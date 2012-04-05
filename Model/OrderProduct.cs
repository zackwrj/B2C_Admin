using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class OrderProduct
	{
		public OrderProduct()
		{}
		#region Model
		private int _id=0;
		private string _ordernum="";
		private int _productid=0;
		private decimal _totalprice=0.00M;
		private decimal _price=0.00M;
		private int _quantity=0;
		private decimal _postage=0.00M;
		private decimal _totalpostage=0.00M;
		private decimal _modifiedpostage=0.00M;
		private string _productname="";
		private string _productfieldsidlist="";
		private string _productpics="";
		private decimal _finallyprice=0.00M;
		/// <summary>
		/// 订单商品表ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
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
		/// 总价
		/// </summary>
		public decimal TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		/// <summary>
		/// 单价
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// 邮费（单件）
		/// </summary>
		public decimal postage
		{
			set{ _postage=value;}
			get{return _postage;}
		}
		/// <summary>
		/// 总邮费
		/// </summary>
		public decimal TotalPostage
		{
			set{ _totalpostage=value;}
			get{return _totalpostage;}
		}
		/// <summary>
		/// 修改后总邮费
		/// </summary>
		public decimal ModifiedPostage
		{
			set{ _modifiedpostage=value;}
			get{return _modifiedpostage;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 商品属性ID
		/// </summary>
		public string ProductFieldsIDList
		{
			set{ _productfieldsidlist=value;}
			get{return _productfieldsidlist;}
		}
		/// <summary>
		/// 商品图片
		/// </summary>
		public string ProductPics
		{
			set{ _productpics=value;}
			get{return _productpics;}
		}
		/// <summary>
		/// 最终成交价
		/// </summary>
		public decimal FinallyPrice
		{
			set{ _finallyprice=value;}
			get{return _finallyprice;}
		}
		#endregion Model

	}
}

