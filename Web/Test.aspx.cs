using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Test : System.Web.UI.Page
    {
        lv_B2C.BLL.ArticleExt bllArticle = new lv_B2C.BLL.ArticleExt();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblGetMaxID.Text = bllArticle.GetMaxId().ToString();//GetMaxID
        }

        //GetListByPage
        protected void btn_Click(object sender, EventArgs e)
        {
            int pageSize = Convert.ToInt32(txt111.Text);
            int pageIndex = Convert.ToInt32(txt.Text);
            rptTest.DataSource = bllArticle.GetPageList(TextBox14.Text, "ArticleID desc", pageIndex, pageSize);
            rptTest.DataBind();
        }
      

        //Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int a = bllArticle.Delete(Convert.ToInt32(txtDelete.Text));
            if (a == 0)
            {
                lblDelete.Text = "删除失败";
            }
            else
            {
                lblDelete.Text = "删除成功";
            }
        }
        //DeleteList
        protected void btnDelIDList_Click(object sender, EventArgs e)
        {
            int a = bllArticle.DeleteList(txtDelIDList.Text);
            if (a == 0)
            {
                lblDelIDList.Text = "删除失败";
            }
            else
            {
                lblDelIDList.Text = "删除成功，共删除" + a + "条记录";
            }
        }
        //GetRecordCount
        protected void btnGetCount_Click(object sender, EventArgs e)
        {
            lblGetCount.Text = bllArticle.GetRecordCount(txtGetCount.Text).ToString();
        }
        //GetModel
        protected void btnGetModel_Click(object sender, EventArgs e)
        {
            lv_B2C.Model.Article model = bllArticle.GetModel(Convert.ToInt32(txtGetModel.Text));
            lblGetModel.Text = model.ArticleID + "----" + model.Title;
        }
        //GetList
        protected void btnGetList_Click(object sender, EventArgs e)
        {
            int top = Convert.ToInt32(txtGetListTop.Text);
            string strWhere = txtGetListStrWhere.Text;
            string fieldOrder = txtGetListFieldOrder.Text;

            rptGetList.DataSource = bllArticle.GetList(top, strWhere, fieldOrder);
            rptGetList.DataBind();
        }
        //GetListLikeTitle
        protected void Button1_Click(object sender, EventArgs e)
        {
            int top = Convert.ToInt32(TextBox1.Text);
            string strWhere = TextBox2.Text;
            string fieldOrder = TextBox3.Text;

            Repeater1.DataSource = bllArticle.GetListLikeTitle(top, strWhere, fieldOrder);
            Repeater1.DataBind();
        }
        //GetListByIDList
        protected void Button2_Click(object sender, EventArgs e)
        {
            int top = Convert.ToInt32(TextBox4.Text);
            string strWhere = TextBox5.Text;
            string fieldOrder = TextBox6.Text;

            Repeater2.DataSource = bllArticle.GetListNotIDList(top, strWhere, fieldOrder);
            Repeater2.DataBind();
        }
        //add
        protected void Button3_Click(object sender, EventArgs e)
        {
            lv_B2C.Model.Article model = new lv_B2C.Model.Article();
            model.ArticleID = Convert.ToInt32(TextBox7.Text);
            model.Title = TextBox8.Text;
            model.CreateDate = DateTime.Now;
            model.LastModifyDate = DateTime.Now;


            int a = bllArticle.Add(model);
            if (a == 1)
            {
                Label1.Text = "新增成功";
            }
            else
            {
                Label1.Text = "新增失败";
            }
        }
        //Update
        protected void Button4_Click(object sender, EventArgs e)
        {
            lv_B2C.Model.Article model = bllArticle.GetModel(Convert.ToInt32(TextBox9.Text));
            model.ArticleID = Convert.ToInt32(TextBox9.Text);
            model.Title = TextBox10.Text;
            model.CreateDate = DateTime.Now;
            model.LastModifyDate = DateTime.Now;
          
            int a = bllArticle.Update(model);
            if (a == 1)
            {
                Label2.Text = "更新成功";
            }
            else
            {
                Label2.Text = "更新失败";
            }
        }
        //更新单个字段的值
        protected void Button5_Click(object sender, EventArgs e)
        {
            int a = bllArticle.Update(Convert.ToInt32(TextBox11.Text), TextBox12.Text.ToString(), TextBox13.Text.ToString());
            if (a == 1)
            {
                Label3.Text = "更新成功";
            }
            else
            {
                Label3.Text = "更新失败";
            }
        }
    }
}