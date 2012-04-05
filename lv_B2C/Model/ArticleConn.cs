using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lv_B2C.Model{
	 	//ArticleConn
		public class ArticleConn
	{
   		     
      	/// <summary>
		/// 文章ID
        /// </summary>		
		private int _articleid;
        public int ArticleID
        {
            get{ return _articleid; }
            set{ _articleid = value; }
        }        
		/// <summary>
		/// 文章类别ID
        /// </summary>		
		private int _articleclassid;
        public int ArticleClassID
        {
            get{ return _articleclassid; }
            set{ _articleclassid = value; }
        }        
		   
	}
}

