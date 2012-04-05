using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class OrderInfo
	{
		public OrderInfo()
		{}
		#region Model
		private int _orderid=0;
		private string _username="";
		private string _ordernum="";
		private string _logisticsnum="";
		private string _consignee="";
		private string _province="";
		private string _city="";
		private string _town="";
		private string _post="";
		private string _address="";
		private string _mobilephone="";
		private string _telphone="";
		private string _email="";
		private string _landmark="";
		private DateTime _besttime= DateTime.Now;
		private string _logistics="";
		private string _logisticsdetail="";
		private int _isinsure=0;
		private string _payment="";
		private string _paymentdetail="";
		private decimal _paypoundage=0.00M;
		private string _invoicetype="";
		private string _invoicetitle="";
		private string _invoicedetail="";
		private string _invoicecustomersmsg="";
		private string _invoicemerchantsmsg="";
		private decimal _invoicemoney=0.00M;
		private decimal _producttotalprice=0.00M;
		private decimal _postage=0.00M;
		private decimal _insurance=0.00M;
		private decimal _packingmoney=0.00M;
		private decimal _cardsmoney=0.00M;
		private decimal _discount=0.00M;
		private string _discountdetail="";
		private decimal _postagederate=0.00M;
		private decimal _usedbalance=0.00M;
		private int _usedintegral=0;
		private int _productquantity=0;
		private int _productweight=0;
		private decimal _actualpaymoney=0.00M;
		private decimal _merchantsmodifyprice=0.00M;
		private int _orderstatus=0;
		private DateTime _createdate= DateTime.Now;
		private DateTime _lastmodifydate= DateTime.Now;
		private int _hits=0;
		private int _isshow=0;
		private string _types="";
		private int _tag=0;
		private string _stringvalue="";
		private int _isdel=0;
		private int _sort=0;
		private int _extendid=0;
		/// <summary>
		/// 订单信息表ID
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		/// 订单号
		/// </summary>
		public string OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 物流单号
		/// </summary>
		public string LogisticsNum
		{
			set{ _logisticsnum=value;}
			get{return _logisticsnum;}
		}
		/// <summary>
		/// 收货人
		/// </summary>
		public string Consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 区
		/// </summary>
		public string Town
		{
			set{ _town=value;}
			get{return _town;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string Post
		{
			set{ _post=value;}
			get{return _post;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string MobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 座机号码
		/// </summary>
		public string TelPhone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 标志性建筑
		/// </summary>
		public string Landmark
		{
			set{ _landmark=value;}
			get{return _landmark;}
		}
		/// <summary>
		/// 最佳送货时间
		/// </summary>
		public DateTime BestTime
		{
			set{ _besttime=value;}
			get{return _besttime;}
		}
		/// <summary>
		/// 物流公司
		/// </summary>
		public string Logistics
		{
			set{ _logistics=value;}
			get{return _logistics;}
		}
		/// <summary>
		/// 物流描述
		/// </summary>
		public string LogisticsDetail
		{
			set{ _logisticsdetail=value;}
			get{return _logisticsdetail;}
		}
		/// <summary>
		/// 是否需要保险
		/// </summary>
		public int IsInsure
		{
			set{ _isinsure=value;}
			get{return _isinsure;}
		}
		/// <summary>
		/// 支付方式
		/// </summary>
		public string Payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 支付方式描述
		/// </summary>
		public string PaymentDetail
		{
			set{ _paymentdetail=value;}
			get{return _paymentdetail;}
		}
		/// <summary>
		/// 支付手续费（单位：百分比）
		/// </summary>
		public decimal PayPoundage
		{
			set{ _paypoundage=value;}
			get{return _paypoundage;}
		}
		/// <summary>
		/// 发票类型
		/// </summary>
		public string InvoiceType
		{
			set{ _invoicetype=value;}
			get{return _invoicetype;}
		}
		/// <summary>
		/// 发票抬头
		/// </summary>
		public string InvoiceTitle
		{
			set{ _invoicetitle=value;}
			get{return _invoicetitle;}
		}
		/// <summary>
		/// 发票内容
		/// </summary>
		public string InvoiceDetail
		{
			set{ _invoicedetail=value;}
			get{return _invoicedetail;}
		}
		/// <summary>
		/// 发票之客户留言内容
		/// </summary>
		public string InvoiceCustomersMsg
		{
			set{ _invoicecustomersmsg=value;}
			get{return _invoicecustomersmsg;}
		}
		/// <summary>
		/// 发票之商家留言内容
		/// </summary>
		public string InvoiceMerchantsMsg
		{
			set{ _invoicemerchantsmsg=value;}
			get{return _invoicemerchantsmsg;}
		}
		/// <summary>
		/// 发票费用（税）
		/// </summary>
		public decimal InvoiceMoney
		{
			set{ _invoicemoney=value;}
			get{return _invoicemoney;}
		}
		/// <summary>
		/// 商品总金额
		/// </summary>
		public decimal ProductTotalPrice
		{
			set{ _producttotalprice=value;}
			get{return _producttotalprice;}
		}
		/// <summary>
		/// 邮费
		/// </summary>
		public decimal Postage
		{
			set{ _postage=value;}
			get{return _postage;}
		}
		/// <summary>
		/// 保险费
		/// </summary>
		public decimal Insurance
		{
			set{ _insurance=value;}
			get{return _insurance;}
		}
		/// <summary>
		/// 包装费用
		/// </summary>
		public decimal PackingMoney
		{
			set{ _packingmoney=value;}
			get{return _packingmoney;}
		}
		/// <summary>
		/// 贺卡费用
		/// </summary>
		public decimal CARDSMoney
		{
			set{ _cardsmoney=value;}
			get{return _cardsmoney;}
		}
		/// <summary>
		/// 折扣
		/// </summary>
		public decimal Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 折扣说明
		/// </summary>
		public string DiscountDetail
		{
			set{ _discountdetail=value;}
			get{return _discountdetail;}
		}
		/// <summary>
		/// 邮费减免
		/// </summary>
		public decimal PostageDerate
		{
			set{ _postagederate=value;}
			get{return _postagederate;}
		}
		/// <summary>
		/// 已使用余额
		/// </summary>
		public decimal UsedBalance
		{
			set{ _usedbalance=value;}
			get{return _usedbalance;}
		}
		/// <summary>
		/// 已使用积分
		/// </summary>
		public int UsedIntegral
		{
			set{ _usedintegral=value;}
			get{return _usedintegral;}
		}
		/// <summary>
		/// 商品数量
		/// </summary>
		public int ProductQuantity
		{
			set{ _productquantity=value;}
			get{return _productquantity;}
		}
		/// <summary>
		/// 商品重量（单位：千克）
		/// </summary>
		public int ProductWeight
		{
			set{ _productweight=value;}
			get{return _productweight;}
		}
		/// <summary>
		/// 实际支付金额
		/// </summary>
		public decimal ActualPayMoney
		{
			set{ _actualpaymoney=value;}
			get{return _actualpaymoney;}
		}
		/// <summary>
		/// 商家修改总价
		/// </summary>
		public decimal MerchantsModifyPrice
		{
			set{ _merchantsmodifyprice=value;}
			get{return _merchantsmodifyprice;}
		}
		/// <summary>
		/// 订单状态（待确认、待付款、侍发货、已完成、取消、无效、退货）
		/// </summary>
		public int OrderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
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
		public DateTime LastModifyDate
		{
			set{ _lastmodifydate=value;}
			get{return _lastmodifydate;}
		}
		/// <summary>
		/// 点击次数

		/// </summary>
		public int Hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 是否显示（例：隐藏换季商品）
		/// </summary>
		public int IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 标识符
		/// </summary>
		public int Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// 预留字段（字符串分割）
		/// </summary>
		public string StringValue
		{
			set{ _stringvalue=value;}
			get{return _stringvalue;}
		}
		/// <summary>
		/// 是否删除

		/// </summary>
		public int IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 排序

		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 扩展ID
		/// </summary>
		public int ExtendID
		{
			set{ _extendid=value;}
			get{return _extendid;}
		}
		#endregion Model

	}
}

