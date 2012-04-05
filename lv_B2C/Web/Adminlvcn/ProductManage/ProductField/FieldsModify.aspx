<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FieldsModify.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.ProductManage.ProductField.FieldsModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=PageTitle%></title>
    <!--#include file="/Adminlvcn/1ref/Inc/libs.htm"-->
    <link href="css/Modify.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" onsubmit="return onBeforeSubmit()">
    <div>
        <h1>
            <%=PageTitle%></h1>
        <div class="mini-toolbar">
            <a class="mini-button" iconcls="icon-goto" href="FieldsList.aspx" target="main">属性列表</a>
            <a class="mini-button" iconcls="icon-reload" href="javascript:history.go(0)">刷新</a><!--onclick="page_reload()"-->
            <a class="mini-button" iconcls="icon-reload" href="javascript:history.go(-1)">返回</a>
        </div>
        <ul id="validGroup1" class="validGroup">
        </ul>
        <div class="content">
            <ul class="product_list">
                <li><label>所属类型：</label>
                    <input id="Text1" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                    requirederrortext="请选择所属属性" class="mini-ComboBox" required="true" enabled="false" value="4"
                    url="ajax/ajax.aspx?method=GetFieldClass" /></li>
                <li><label>所属属性：</label>
                    <input id="Text4" name="productname" errormode="none" onvalidation="onOnlyNotNull"
                    requirederrortext="请选择所属属性" class="mini-ComboBox" required="true" value="1"
                    url="ajax/FieldAjax.aspx?method=GetRootFields" /></li>
                <li>
                    <label>
                        属性名称：</label>
                    <input id="txtTitle" name="fieldsname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="属性名称不能为空" class="mini-textbox" required="true" /></li>
                <li>
                    <label>
                        属性图片：</label>
                    <input id="Text2" name="fieldsname" errormode="none" onvalidation="onOnlyNotNull"
                        requirederrortext="属性图片不能为空" class="mini-textbox" required="true" /></li>
            </ul>
        </div>
        <div style="width: 100%; height: 30px; text-align: center; margin-top: 10px;">
            <asp:Button ID="btnSave" runat="server" Text="保存"></asp:Button>
            <asp:Button ID="btnAdd" runat="server" Text="新增"></asp:Button>
            <input id="btnReset" runat="server" type="button" value="重置" onclick="resetForm()" />
            <asp:Button ID="btnBack" runat="server" OnClientClick="javascript:history.go(-1)"
                Text="返回"></asp:Button>
        </div>
    </div>
    <script src="/Adminlvcn/1ref/js/validation.js" type="text/javascript"></script>
    </form>
</body>
</html>
