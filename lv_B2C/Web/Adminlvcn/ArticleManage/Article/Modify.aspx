<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.ArticleManage.Article.Modify" %>

<%@ Register Src="~/Adminlvcn/1ref/controls/Editor.ascx" TagName="Editor" TagPrefix="uc1" %>
<%@ Register Src="../../1ref/controls/UpLoad/UpLoad/UpLoad.ascx" TagName="UpLoad"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑文章</title>
    <!--#include file="/Adminlvcn/1ref/Inc/libs.htm"-->
    <link href="css/modify.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" onsubmit="return onBeforeSubmit()">
    <div>
        <h1>
            <%=PageTitle%></h1>
        <div class="mini-toolbar">
            <a class="mini-button" iconcls="icon-goto" href="List.aspx" target="main">商品列表</a>
            <a class="mini-button" iconcls="icon-reload" href="javascript:history.go(0)">刷新</a><!--onclick="page_reload()"-->
            <a class="mini-button" iconcls="icon-reload" href="javascript:history.go(-1)">返回</a>
        </div>
        <div class="content">
            <ul id="validGroup1" class="validGroup">
            </ul>
            <ul class="product_list">
                <li>
                    <label>
                        商品名称：</label>
                    <input id="txtTitle" name="productname" errormode="none" onvalidation="onProductNameVali"
                        requirederrortext="商品名称不能为空" class="mini-textbox" required="true" /></li>
                <li>
                    <label>
                        商品货号：</label>
                    <input id="txtProductCode" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="商品货号不能为空" class="mini-textbox" required="false" />
                    <b>如果为空,系统将自动生成一个唯一的货号</b></li>
                <li>
                    <label>
                        所属分类：</label>
                    <input id="Text3" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="请选择所属分类" multiselect="true" class="mini-treeselect" required="true"
                        url="/Adminlvcn/1ref/base_ajax/ajax.aspx?method=GetInputSelectClass" /></li>
                <li>
                    <label>
                        商品品牌：</label>
                    <input id="Text4" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="请选择商品品牌" class="mini-ComboBox" required="true" url="/Adminlvcn/1ref/base_ajax/ajax.aspx?method=GetSelectBrand" /></li>
                <li>
                    <label>
                        本站售价：</label>
                    <input id="Text5" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="本站售价不能为0" class="mini-spinner" required="true" /></li>
                <li>
                    <label>
                        市场售价：</label>
                    <input id="Text6" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="本站售价不能为0" class="mini-spinner" required="true" /></li>
                <li>
                    <label>
                        赠送积分数：</label>
                    <input id="Text7" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="赠送积分数" class="mini-spinner" required="false" /></li>
                <li>
                    <label>
                        积分购买金额：</label>
                    <input id="Text8" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="积分购买金额" class="mini-spinner" required="false" />
                    <b>购买该商品最多可以使用积分的金额</b></li>
                <li>
                    <asp:CheckBox ID="CheckBox1" Text="" runat="server" CssClass="in_cb" />
                    <label>
                        促销价：</label>
                    <input id="Text9" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="促销价不能为空" class="mini-spinner" required="true" /></li>
                <li>
                    <label>
                        促销日期：</label>
                    <input id="Text10" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="促销开始日期不能为空" class="mini-datepicker" showtime="true" required="true" />
                    -
                    <input id="Text12" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="促销结束日期不能为空" class="mini-datepicker" showtime="true" required="true" /></li>
                <li>
                    <label>
                        商品主图：</label>
                    <input id="Text11" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="商品主图不能为空" class="mini-htmlfile" limittype="*.png" required="true" /></li>
                 <li>
                    <label for="company$text">
                        物流公司：</label>
                    <input id="Text1" name="company" errormode="none" onvalidation="onProductNameVali"
                        requirederrortext="物流公司不能为空" class="mini-textbox" required="true" /></li>
            </ul>
            <%--<uc2:UpLoad ID="UpLoad1" runat="server" />--%>
        </div>
    </div>
    <div style="width: 100%; height: 30px; text-align: center; margin-top: 10px;">
        <asp:Button ID="btnSave" runat="server" Text="保存"></asp:Button>
        <asp:Button ID="btnAdd" runat="server" Text="新增"></asp:Button>
        <input id="btnReset" runat="server" type="button" value="重置" onclick="resetForm()" />
        <asp:Button ID="btnBack" runat="server" OnClientClick="javascript:history.go(-1)"
            Text="返回"></asp:Button>
    </div>
    <%-- <script src="../../1ref/js/pages/product_edit.js" type="text/javascript"></script>--%>
    <script src="/Adminlvcn/1ref/js/validation.js" type="text/javascript"></script>
    </form>
</body>
</html>
