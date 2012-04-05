using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using lv_Common;
using System.Data;

namespace lv_B2C.BLL
{
    public class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 当前登录用户名
        /// </summary>
        public readonly string bp_curUser = System.Web.HttpContext.Current.User.Identity.Name;

        #region BLL引用

        public readonly BLL.ProductClassExt bllProductClass = new BLL.ProductClassExt();
        public readonly BLL.ProductExt bllProduct = new BLL.ProductExt();

        #endregion BLL引用

        public BasePage()
        {

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(PageBase_Load);
        }
        private void PageBase_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// DropDownList默认项
        /// </summary>
        protected ListItem bp_GetDefaultListItem(string text, string value)
        {
            ListItem item = new ListItem(text, value);
            return item;
        }
        protected ListItem bp_GetDefaultListItem(string value)
        {
            ListItem item = new ListItem("==请选择==", value);
            return item;
        }
        protected ListItem bp_GetDefaultListItem()
        {
            ListItem item = new ListItem("==请选择==", "0");
            return item;
        }

        /// <summary>
        /// 绑定枚举列表
        /// </summary>
        protected void bp_BindTypeEnum(DropDownList dropDownList, List<ListItem> dataSource)
        {
            dropDownList.DataSource = dataSource;
            dropDownList.DataTextField = "text";
            dropDownList.DataValueField = "value";
            dropDownList.DataBind();
        }

        /// <summary>
        /// 绑定枚举列表 (用于模板页或用户控件)
        /// </summary>
        public void BindTypeEnum(DropDownList dropDownList, List<ListItem> dataSource)
        {
            bp_BindTypeEnum(dropDownList, dataSource);
        }
        /// <summary>
        /// 获取服务器图片上传路径
        /// </summary>
        /// <param name="imageName">图片名称</param>
        /// <returns></returns>
        public string bp_GetUploadImagePath(string imageName)
        {
            return lv_Common.Common.GetUploadImagePath(imageName);
        }
        public string bp_GetUploadImagePath(object imageName)
        {
            return lv_Common.Common.GetUploadImagePath(imageName.ToString());
        }
        public string GIP(object imageName)
        {
            return bp_GetUploadImagePath(imageName);
        }
        /// <summary>
        /// 字符串截取(纯文本)
        /// </summary>
        public string bp_CutString(object inputStr, int length)
        {
            return lv_Common.StringPlus.CutString(inputStr, length);
        }

        /// <summary>
        /// 从一段HTML文本中提取出一定字数的纯文本
        /// </summary>
        protected static string bp_GetFirstNchar(object instr, int firstN)
        {
            return lv_Common.HtmlHelper.GetFirstNchar(instr, firstN, false);
        }

        /// <summary>
        /// 返回处理后的时间，通过type设置返回的样式。1：day,2：moon,3：year,4：moon - day,5：year - moon - day,9:year - moon - day HH:mm
        /// </summary>
        public static string bp_CutTime(object time, int style)
        {
            return lv_Common.CutInfo.CutTime(time.ToString(), style);
        }

        /// <summary>
        /// 转换日期格式
        /// </summary>
        /// <param name="dateTime">转换对象</param>
        /// <param name="format">转换的格式，如"yyyy-MM-dd"</param>
        /// <returns></returns>
        public static string bp_ConvDT(object dateTime, string format)
        {
            return lv_Common.ConvertData.DateTimeConvertToString(dateTime, format);
        }
        /// <summary>
        /// 转换日期格式
        /// </summary>
        /// <param name="dataTime">转换对象</param>
        /// <param name="isShowTime">是否显示时间</param>
        /// <returns></returns>
        public static string bp_ConvDT(object dataTime, bool isShowTime)
        {
            return lv_Common.ConvertData.DateTimeConvertToString(dataTime, isShowTime);
        }

        /// <summary>
        /// URL传值，异常时 string 返回 "" ，int 返回 -1
        /// </summary>
        public static T GetUrlParaValue<T>(string urlPara)
        {
            return lv_Common.UrlParaValue.Get<T>(urlPara);
        }
        /// <summary>
        /// URL传值，异常时 string 返回 strDefault ，int 返回 intDefault
        /// </summary>
        public static T GetUrlParaValue<T>(string urlPara, string strDefault, int intDefault)
        {
            return lv_Common.UrlParaValue.Get<T>(urlPara, strDefault, intDefault);
        }
        #region GridView
        /// <summary>
        /// 获取GridView选中行
        /// </summary>
        protected string bp_GetSelIDlist(GridView gridView, string chkControlID)
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl(chkControlID);
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    if (gridView.DataKeys[i].Value != null)
                    {
                        idlist += gridView.DataKeys[i].Value.ToString() + "','";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf("','"));
            }
            return idlist;
        }

        /// <summary>
        /// 获取GridView指定列索引
        /// </summary>
        protected int bp_GetColumnIndex(GridView gridView, string columnHeadText)
        {
            foreach (DataControlField field in gridView.Columns)
            {
                if (field.HeaderText == columnHeadText.Trim())
                    return gridView.Columns.IndexOf(field);
            }
            return -1;
        }

        /// <summary>
        /// GridView排序
        /// </summary>
        protected void bp_SortGridView(string sortColumn, GridView objGridView, DataSet dataSource)
        {
            bp_SortGridView(sortColumn, objGridView, dataSource, false);
        }
        protected void bp_SortGridView(string sortColumn, GridView objGridView, DataSet dataSource, bool isNew)
        {
            if (dataSource == null || dataSource.Tables[0].Rows.Count == 0)
            {
                objGridView.DataSource = null;
                objGridView.DataBind();
                return;
            }
            if (isNew)//重新排序时为true，保留之前排序时为false
            {
                if (null != ViewState["sortColumn"] && ViewState["sortColumn"].ToString() == sortColumn)
                {
                    if ("ASC" == ViewState["sortDirection"].ToString())
                    {
                        ViewState["sortDirection"] = "DESC";
                    }
                    else
                    {
                        ViewState["sortDirection"] = "ASC";
                    }
                }
                else
                {
                    ViewState["sortColumn"] = sortColumn;
                    ViewState["sortDirection"] = "ASC";
                }
            }
            // 获取GridView排序数据列及排序方向  
            string sortExpression = sortColumn;
            string sortDirection = ViewState["sortDirection"].ToString();

            DataTable dt = dataSource.Tables[0];
            // 根据GridView排序数据列及排序方向设置显示的默认数据视图  
            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
            {
                dt.DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
            }
            // GridView绑定并显示数据  
            objGridView.DataSource = dt;
            objGridView.DataBind();
        }

        /// <summary>
        /// 获取GridView排序列索引
        /// </summary>
        protected int bp_GetSortColumnIndex(GridView gridView)
        {
            foreach (DataControlField field in gridView.Columns)
            {
                if (field.SortExpression == ViewState["sortColumn"].ToString().Trim())
                    return gridView.Columns.IndexOf(field);
            }
            return -1;
        }

        /// <summary>
        /// 添加GridView排序标识
        /// </summary>
        protected void bp_AddSortTag(int columnIndex, GridViewRow headerRow)
        {
            Label sortLabel = new Label();
            if (ViewState["sortDirection"].ToString() == "ASC")
            {
                sortLabel.Text = " ↑";
            }
            else
            {
                sortLabel.Text = " ↓";
            }
            headerRow.Cells[columnIndex].Controls.Add(sortLabel);
        }
        #endregion
    }
}
