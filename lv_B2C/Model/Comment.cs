using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告位置表
	/// </summary>
	[Serializable]
	public partial class Comment
	{
		public Comment()
		{}
		#region Model
		private int _commentid=0;
		private int _commenttype=0;
		private int _typeid=0;
		private int _parentid=0;
		private string _title="";
		private string _title_en="";
		private string _alt="";
		private string _images="";
		private int _approvedstate=0;
		private string _detail="";
		private decimal _score=0.0M;
		private int _pos=0;
		private int _neg=0;
		private int _quotedid=0;
		private DateTime _freezetime= DateTime.Now;
		private string _createby="";
		private string _publishername="";
		private string _publishersex="";
		private string _publisheremail="";
		private string _publisherip="";
		private string _publishertel="";
		private string _publisherqq="";
		private string _publishercontact="";
		private int? _albumid;
		private DateTime _createdate= DateTime.Now;
		private DateTime? _lastmodifydate;
		private int _hits=0;
		private int _isshow=0;
		private string _types="";
		private int _tag=0;
		private string _stringvalue="";
		private int _isdel=0;
		private int _sort=0;
		private int _extendid=0;
		/// <summary>
		/// 评论表ID
		/// </summary>
		public int CommentID
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 评论类型（如：对商品评论、对文章评论、对留言评论等）
		/// </summary>
		public int CommentType
		{
			set{ _commenttype=value;}
			get{return _commenttype;}
		}
		/// <summary>
		/// 被评论的文章ID、被评论的商品ID
		/// </summary>
		public int TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 父级ID
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
		/// 图片
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
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
		/// 评论内容
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 评分（如：1颗星，2个颗星，等等）
		/// </summary>
		public decimal Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 顶
		/// </summary>
		public int Pos
		{
			set{ _pos=value;}
			get{return _pos;}
		}
		/// <summary>
		/// 踩
		/// </summary>
		public int Neg
		{
			set{ _neg=value;}
			get{return _neg;}
		}
		/// <summary>
		/// 引用评论ID
		/// </summary>
		public int QuotedID
		{
			set{ _quotedid=value;}
			get{return _quotedid;}
		}
		/// <summary>
		/// 评论冻结时间（单位：秒）（评论完后相隔多久才能再次评论）
		/// </summary>
		public DateTime FreezeTime
		{
			set{ _freezetime=value;}
			get{return _freezetime;}
		}
		/// <summary>
		/// 评论者（已登录时记录）
		/// </summary>
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 评论人姓名
		/// </summary>
		public string PublisherName
		{
			set{ _publishername=value;}
			get{return _publishername;}
		}
		/// <summary>
		/// 评论人性别
		/// </summary>
		public string PublisherSex
		{
			set{ _publishersex=value;}
			get{return _publishersex;}
		}
		/// <summary>
		/// 评论人Email
		/// </summary>
		public string PublisherEmail
		{
			set{ _publisheremail=value;}
			get{return _publisheremail;}
		}
		/// <summary>
		/// 评论人IP
		/// </summary>
		public string PublisherIP
		{
			set{ _publisherip=value;}
			get{return _publisherip;}
		}
		/// <summary>
		/// 评论人联系电话
		/// </summary>
		public string PublisherTel
		{
			set{ _publishertel=value;}
			get{return _publishertel;}
		}
		/// <summary>
		/// 评论人QQ
		/// </summary>
		public string PublisherQQ
		{
			set{ _publisherqq=value;}
			get{return _publisherqq;}
		}
		/// <summary>
		/// 评论人其他联系方式
		/// </summary>
		public string PublisherContact
		{
			set{ _publishercontact=value;}
			get{return _publishercontact;}
		}
		/// <summary>
		/// 相册ID
		/// </summary>
		public int? AlbumID
		{
			set{ _albumid=value;}
			get{return _albumid;}
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
		public DateTime? LastModifyDate
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

