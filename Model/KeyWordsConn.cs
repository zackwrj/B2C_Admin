using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// KeyWordsConn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KeyWordsConn
	{
		public KeyWordsConn()
		{}
		#region Model
		private int _keywordsid=0;
		private int _productid=0;
		private int _articleid=0;
		/// <summary>
		/// 关键词ID
		/// </summary>
		public int KeyWordsID
		{
			set{ _keywordsid=value;}
			get{return _keywordsid;}
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
		/// 文章ID
		/// </summary>
		public int ArticleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		#endregion Model

	}
}

