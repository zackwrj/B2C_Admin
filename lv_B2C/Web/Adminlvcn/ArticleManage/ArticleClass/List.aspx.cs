using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace lv_B2C.Web.Adminlvcn.ArticleManage.ArticleClass
{
    public partial class List : BLL.Base.BasePageAdmin
    {
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RecursionNav(0);
                litClass.Text = sb.ToString();
            }
        }

        #region 递归类
        /// <summary>
        /// 递归类
        /// </summary>
        /// <summary>
        public void RecursionNav(int topClassID)
        {
            IList<lv_B2C.Model.ArticleClass> listArticleClass = bllArticleClass.GetList(0, "ParentID=" + topClassID, "ShowOrder asc");
            if (listArticleClass != null)
            {
                if (topClassID == 0)
                {
                    sb.Append("<ul id='tree1'' class='mini-tree' style='width: 100%;' enablehottrack='false' howTreeIcon='true' textField='text' valueField='id' contextMenu='#treeMenu'>");
                }
                else
                {
                    sb.Append("<ul>");
                }
                for (int i = 0; i < listArticleClass.Count; i++)
                {
                    sb.Append("<li><span isdel='" + listArticleClass[i].IsDel + "'><b pcd='" + listArticleClass[i].ArticleClassID + "'>" + listArticleClass[i].Title + "</b><samp>");
                    sb.Append("<div class='add_image'>");
                    sb.Append("<div class='add' onclick='onAddImg()'>添加图片</div>");
                    sb.Append("<div class='edit hide'>");
                    sb.Append("<div class='view_img'></div>");
                    sb.Append("<div class='edit_img'>编辑</div>");
                    sb.Append("<div class='del_img'>删除</div>");
                    sb.Append("</div></div>");
                    sb.Append("<div class='action'>");
                    if (listArticleClass[i].IsDel == 1)
                    {
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' class='dis-del'></div>");
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' class='del hide' onclick='del(this)'></div>");
                    }
                    else
                    {
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' class='del' onclick='del(this)'></div>");
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' class='dis-del hide'></div>");
                    }
                    if (i == listArticleClass.Count - 1)
                    {
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "'  class='dis-down'></div>");
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "' class='down hide'></div>");
                    }
                    else
                    {
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "' class='down'></div>");
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "'  class='dis-down hide'></div>");
                    }
                    if (i == 0)
                    {
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "'  class='dis-up'></div>");
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "'  class='up hide'></div>");
                    }
                    else
                    {
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "'  class='up'></div>");
                        sb.Append("<div pcd='" + listArticleClass[i].ArticleClassID + "' showorder='" + listArticleClass[i].ShowOrder + "'  class='dis-up hide'></div>");
                    }
                    sb.Append("</div></samp></span>");
                    RecursionNav(listArticleClass[i].ArticleClassID);
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }
        }
        #endregion
    }
}