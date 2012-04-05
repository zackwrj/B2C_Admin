using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 内容扩展类型表
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private int _productid=0;
		private string _title="";
		private string _title_en="";
		private string _alt="";
		private string _images="";
		private int _productbrandid=0;
		private string _productcode="";
		private string _productunit="";
		private int _productweight=0;
		private decimal _productmarketprice=0.00M;
		private decimal _productprice=0.00M;
		private decimal _promoteprice=0.00M;
		private DateTime _promotestartdate= DateTime.Now;
		private DateTime _promoteenddate= DateTime.Now;
		private string _productkeywords="";
		private string _summary="";
		private string _detail="";
		private int _productcount=0;
		private int _approvedstate=0;
		private int _ispromote=0;
		private int _isdiscount=0;
		private int _isrecommend=0;
		private int _ishot=0;
		private int _isnew=0;
		private int _isspecialoffer=0;
		private int _ispostage=0;
		private DateTime _timetomarket= DateTime.Now;
		private int _isactive=0;
		private string _link="";
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
		/// 商品ID
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 英文标题（可用于二级域名、目录名）
		/// </summary>
		public string Title_en
		{
			set{ _title_en=value;}
			get{return _title_en;}
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
		/// 商品图片 
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 商品品牌ID
		/// </summary>
		public int ProductBrandID
		{
			set{ _productbrandid=value;}
			get{return _productbrandid;}
		}
		/// <summary>
		/// 商品代码 

		/// </summary>
		public string ProductCode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 商品单位
		/// </summary>
		public string ProductUnit
		{
			set{ _productunit=value;}
			get{return _productunit;}
		}
		/// <summary>
		/// 商品重量

		/// </summary>
		public int ProductWeight
		{
			set{ _productweight=value;}
			get{return _productweight;}
		}
		/// <summary>
		/// 商品市场价
		/// </summary>
		public decimal ProductMarketPrice
		{
			set{ _productmarketprice=value;}
			get{return _productmarketprice;}
		}
		/// <summary>
		/// 商品价格
		/// </summary>
		public decimal ProductPrice
		{
			set{ _productprice=value;}
			get{return _productprice;}
		}
		/// <summary>
		/// 促销价
		/// </summary>
		public decimal PromotePrice
		{
			set{ _promoteprice=value;}
			get{return _promoteprice;}
		}
		/// <summary>
		/// 促销开始时间 
		/// </summary>
		public DateTime PromoteStartDate
		{
			set{ _promotestartdate=value;}
			get{return _promotestartdate;}
		}
		/// <summary>
		/// 促销结束时间
		/// </summary>
		public DateTime PromoteEndDate
		{
			set{ _promoteenddate=value;}
			get{return _promoteenddate;}
		}
		/// <summary>
		/// 关键词
		/// </summary>
		public string ProductKeyWords
		{
			set{ _productkeywords=value;}
			get{return _productkeywords;}
		}
		/// <summary>
		/// 商品简介
		/// </summary>
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 商品详细内容

		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 商品库存（数量）
		/// </summary>
		public int ProductCount
		{
			set{ _productcount=value;}
			get{return _productcount;}
		}
		/// <summary>
		/// 审核状态
		/// </summary>
		public int ApprovedState
		{
			set{ _approvedstate=value;}
			get{return _approvedstate;}
		}
		/// <summary>
		/// 是否促销
		/// </summary>
		public int IsPromote
		{
			set{ _ispromote=value;}
			get{return _ispromote;}
		}
		/// <summary>
		/// 是否打折
		/// </summary>
		public int IsDiscount
		{
			set{ _isdiscount=value;}
			get{return _isdiscount;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int IsRecommend
		{
			set{ _isrecommend=value;}
			get{return _isrecommend;}
		}
		/// <summary>
		/// 是否热门
		/// </summary>
		public int IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否新品

		/// </summary>
		public int IsNew
		{
			set{ _isnew=value;}
			get{return _isnew;}
		}
		/// <summary>
		/// 是否特价
		/// </summary>
		public int IsSpecialOffer
		{
			set{ _isspecialoffer=value;}
			get{return _isspecialoffer;}
		}
		/// <summary>
		/// 是否免邮
		/// </summary>
		public int IsPostage
		{
			set{ _ispostage=value;}
			get{return _ispostage;}
		}
		/// <summary>
		/// 上市时间 
		/// </summary>
		public DateTime TimeToMarket
		{
			set{ _timetomarket=value;}
			get{return _timetomarket;}
		}
		/// <summary>
		/// 是否活动
		/// </summary>
		public int IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		/// <summary>
		/// 外链接
		/// </summary>
		public string Link
		{
			set{ _link=value;}
			get{return _link;}
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

