using System;
namespace lv_B2C.Model
{
    /// <summary>
    /// OrderView:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrderView
    {
        public OrderView()
        { }
        #region Model
        private int _orderviewid;
        private string _ordernum;
        private string _orderlogisticsnum;
        private string _username;
        private decimal _ordertotalprice;
        private int _orderproductquantity;
        private decimal _orderpostagederate;
        private decimal _orderpostage;
        private decimal _orderdiscount;
        private string _orderdiscountdetail;
        private decimal _orderusedbalance;
        private int _orderusedintegral;
        private decimal _orderactualpaymoney;
        private decimal _ordermerchantsmodifyprice;
        private int _orderstatus;
        private DateTime _ordercreatedate;
        private decimal _totalprice;
        private decimal _price;
        private int _quantity;
        private string _productfieldsidlist;
        private string _productname;
        private string _productpics;
        private decimal _finallyprice;
        private decimal _postage;
        private decimal _modifiedpostage;
        private decimal _totalpostage;
        /// <summary>
        /// 
        /// </summary>
        public int OrderViewID
        {
            set { _orderviewid = value; }
            get { return _orderviewid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderLogisticsNum
        {
            set { _orderlogisticsnum = value; }
            get { return _orderlogisticsnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderTotalPrice
        {
            set { _ordertotalprice = value; }
            get { return _ordertotalprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderProductQuantity
        {
            set { _orderproductquantity = value; }
            get { return _orderproductquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderPostageDerate
        {
            set { _orderpostagederate = value; }
            get { return _orderpostagederate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderPostage
        {
            set { _orderpostage = value; }
            get { return _orderpostage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderDiscount
        {
            set { _orderdiscount = value; }
            get { return _orderdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDiscountDetail
        {
            set { _orderdiscountdetail = value; }
            get { return _orderdiscountdetail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderUsedBalance
        {
            set { _orderusedbalance = value; }
            get { return _orderusedbalance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderUsedIntegral
        {
            set { _orderusedintegral = value; }
            get { return _orderusedintegral; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderActualPayMoney
        {
            set { _orderactualpaymoney = value; }
            get { return _orderactualpaymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderMerchantsModifyPrice
        {
            set { _ordermerchantsmodifyprice = value; }
            get { return _ordermerchantsmodifyprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderCreateDate
        {
            set { _ordercreatedate = value; }
            get { return _ordercreatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrice
        {
            set { _totalprice = value; }
            get { return _totalprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductFieldsIDList
        {
            set { _productfieldsidlist = value; }
            get { return _productfieldsidlist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductPics
        {
            set { _productpics = value; }
            get { return _productpics; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FinallyPrice
        {
            set { _finallyprice = value; }
            get { return _finallyprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal postage
        {
            set { _postage = value; }
            get { return _postage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ModifiedPostage
        {
            set { _modifiedpostage = value; }
            get { return _modifiedpostage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPostage
        {
            set { _totalpostage = value; }
            get { return _totalpostage; }
        }
        #endregion Model

    }
}

