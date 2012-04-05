using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lv_B2C.BLL.Base
{
    public class BasePageAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// 当前登录用户名
        /// </summary>
        public readonly string bp_curUser = System.Web.HttpContext.Current.User.Identity.Name;

        #region BLL引用

        public readonly BLL.ProductClassExt bllProductClass = new BLL.ProductClassExt();
        public readonly BLL.ProductExt bllProduct = new BLL.ProductExt();

        public readonly BLL.ArticleClassExt bllArticleClass = new BLL.ArticleClassExt();
        public readonly BLL.ArticleExt bllArticle = new BLL.ArticleExt();

        #endregion BLL引用
    }
}
