using System;
namespace lv_B2C.Model
{
	/// <summary>
	/// 广告位置表
	/// </summary>
	[Serializable]
	public partial class ArticleConn
	{
		public ArticleConn()
		{}
		#region Model
		private int _articleid=0;
		private int _articleclassid=0;
		/// <summary>
		/// 文章ID
		/// </summary>
		public int ArticleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 文章类别ID
		/// </summary>
		public int ArticleClassID
		{
			set{ _articleclassid=value;}
			get{return _articleclassid;}
		}
		#endregion Model

	}
}

