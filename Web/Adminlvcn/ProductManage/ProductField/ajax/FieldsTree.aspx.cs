using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

namespace lv_B2C.Web.Adminlvcn.ProductManage.ProductField.ajax
{
    public partial class FieldsTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据
            ArrayList treeData = FromDataBase();

            //使用TreeGrid服务端功能
            CreateTreeGrid(treeData);
        }

        public void CreateTreeGrid(ArrayList treeData)
        {
            string key = Convert.ToString(Request["name"]);
            int pageIndex = Convert.ToInt32(Request["pageIndex"]);
            int pageSize = Convert.ToInt32(Request["pageSize"]);

            PluSoft.Data.DataTree tree = new PluSoft.Data.DataTree();
            tree.IdField = "FieldsID";
            tree.NodesField = "children";
            tree.ParentField = "ParentID";

            //传递折叠信息
            tree.LoadExpandCollapseConfig(Request);

            tree.LoadTree(treeData);

            //if (!string.IsNullOrEmpty(key))
            //{
            //    ArrayList filters = SearchNodes(key, tree.GetList());
            //    tree.CreateDataView(filters);
            //}
            //GetPagedNodes(pageIndex, pageSize)
            ArrayList data = tree.GetPagedNodes(pageIndex, pageSize);//从数据视图，获取分页数据
            int total = tree.GetCollapsedCount();  //获取折叠、过滤、排序后的总记录数
            Hashtable resulte = new Hashtable();
            resulte["total"] = total;
            resulte["data"] = data;

            string json = PluSoft.Utils.JSON.Encode(resulte);
            Response.Write(json);
        }

        public ArrayList SearchNodes(string key, ArrayList nodeList)
        {
            ArrayList filters = new ArrayList();

            for (int i = 0, l = nodeList.Count; i < l; i++)
            {
                Hashtable node = (Hashtable)nodeList[i];
                string taskName = Convert.ToString(node["Name"]);
                if (taskName != null && taskName.IndexOf(key) != -1)
                {
                    filters.Add(node);
                }
            }

            return filters;
        }
        public ArrayList FromDataBase()
        {
            string json = GetJsonTree();
            ArrayList tree = (ArrayList)PluSoft.Utils.JSON.Decode(json);
            return tree;
        }


        BLL.FieldsExt bllFields = new BLL.FieldsExt();
        StringBuilder sb = new StringBuilder();

        /// <summary>
        /// 获取Json格式的Tree
        /// </summary>
        /// <returns></returns>
        public string GetJsonTree()
        {
            sb.Append("[");
            RecursionNav(0);
            sb.Append("]");
            return sb.ToString();
        }

        #region 递归类
        /// <summary>
        /// 递归类
        /// </summary>
        /// <summary>
        public void RecursionNav(int topClassID)
        {
            IList<lv_B2C.Model.Fields> listProductClass = bllFields.GetList("ParentID=" + topClassID + CidWhere);
            if (listProductClass != null)
            {
                for (int i = 0; i < listProductClass.Count; i++)
                {
                    sb.Append("{\"FieldsID\": \"" + listProductClass[i].FieldsID
                        + "\", \"Title\": \"" + listProductClass[i].Title
                        + "\", \"Images\": \"" + listProductClass[i].Images
                        + "\", \"ParentID\": \"" + listProductClass[i].ParentID
                        + "\"");

                    if (bllFields.HasProductClassSon(listProductClass[i].FieldsID))
                    {
                        sb.Append(",\"children\":[");
                        RecursionNav(listProductClass[i].FieldsID);
                        sb.Append("]");
                    }
                    if (i < listProductClass.Count - 1)
                    {
                        sb.Append("},");
                    }
                    else
                    {
                        sb.Append("}");
                    }
                }
            }
        }
        #endregion

        private string CidWhere
        {
            get
            {
                if (Session["cid"] != null)
                {
                    return " and FieldsClassID=" + Session["cid"];
                }
                else if (Request["cid"] != null)
                {
                    Session["cid"] = Request["cid"];
                    return " and FieldsClassID=" + Session["cid"];
                }
                else
                {
                    return "";
                }
            }
        }
    }
}