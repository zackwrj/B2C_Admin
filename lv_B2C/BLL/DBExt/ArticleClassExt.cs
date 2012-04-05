using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using lv_Common;
using lv_B2C.Model;
namespace lv_B2C.BLL {
	 	//ArticleClass
	public partial class ArticleClassExt : ArticleClass
	{
        private lv_B2C.DAL.ArticleClassExt dal = null;
        public bool HasArticleClassSon(int articleClassID)
        {
            dal = new DAL.ArticleClassExt();
            int rs = dal.HasArticleClassSon(articleClassID);
            if (rs != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}