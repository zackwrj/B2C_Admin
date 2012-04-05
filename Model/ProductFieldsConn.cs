using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// ProductFieldsConn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductFieldsConn
	{
		public ProductFieldsConn()
		{}
		#region Model
		private int _productfieldsconnid=0;
		private int _productid=0;
		private int _fieldsid=0;
		private int _fieldsquantity=0;
		private decimal _fieldsmarketprice=0.00M;
		private decimal _fieldsprice=0.00M;
		private string _detail="";
		/// <summary>
		/// 
		/// </summary>
		public int ProductFieldsConnID
		{
			set{ _productfieldsconnid=value;}
			get{return _productfieldsconnid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FieldsID
		{
			set{ _fieldsid=value;}
			get{return _fieldsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FieldsQuantity
		{
			set{ _fieldsquantity=value;}
			get{return _fieldsquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal FieldsMarketPrice
		{
			set{ _fieldsmarketprice=value;}
			get{return _fieldsmarketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal FieldsPrice
		{
			set{ _fieldsprice=value;}
			get{return _fieldsprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		#endregion Model

	}
}

