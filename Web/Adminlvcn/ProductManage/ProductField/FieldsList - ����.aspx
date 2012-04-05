<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FieldsList.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.ProductManage.ProductField.FieldsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品属性</title>
    <!--#include file="/Adminlvcn/1ref/Inc/libs.htm"-->
</head>
<body>
    <form id="form1" runat="server">
   <div>
        <h1>
            属性列表</h1>
        <div class="mini-toolbar">
            <a class="mini-button" iconCls="icon-add" href="Modify.aspx" target="main">新增</a>
            <a class="mini-button" iconCls="icon-edit" onclick="editRowList()" target="main">编辑</a>
            <a class="mini-button" iconCls="icon-remove" onclick="onRemove()">删除</a>
            <a class="mini-button" iconCls="icon-reload" href="javascript:history.go(0)">刷新</a>
            <span class="separator"></span>
            属性名称：<input class="mini-textbox" id="seachText" />      
            <a class="mini-button" plain="true" onclick="search()">查询</a>
        </div>
        <div id="datagrid1" class="mini-datagrid" style="width: 100%; height:473px" url="ajax/FieldAjax.aspx?method=SearchEmployees&cid=<%=cid %>"
            valuefield="ProductFieldsID" multiselect="true" pageSize="7" pageIndex="0" sizeList="[8,16,32,64]" contextMenu="#gridMenu" allowResize="true">
            <div property="columns">
                <div type="checkcolumn">
                </div>
                <div field="ProductFieldsID" width="35" headeralign="center" allowsort="true" align="center">
                    <b>ID</b>
                </div>
                <div field="Title" width="120" headeralign="center" allowsort="false" cellclick="editRow()">
                    <b>类型名称</b>
                    <input property="editor" class="mini-textbox" style="width:100%;"/>
                </div>
                <div field="IsPostage" width="50" allowsort="true" renderer="onGetYesNo" align="center" headeralign="center" >
                    <b>是否默认</b>
                    <input property="editor" class="mini-combobox" style="width:100%;" data="Genders"/>      
                </div>
                <div name="action" width="50" headerAlign="center" align="center" renderer="onActionRenderer" cellStyle="padding:0;"><b>操作</b></div>
            </div>
        </div>
        <div id="employeeWindow" class="mini-window" style="width: 650px; height: 400px;" bodystyle="padding:2px;" showfooter="true" showmodal="true" allowresize="true">
            <iframe id="employeeframe" frameborder="0" style="width: 100%; height: 100%;" border="0">
            </iframe>
            <div property="footer" style="padding: 8px; text-align: center;">
                <input class="mini-button" onclick="onSaveClick" text="保存" style="width: 60px; margin-right: 25px;" />
                <input class="mini-button" onclick="onCancelClick" text="取消" style="width: 60px;" />
            </div>
        </div>
        <!--右键菜单-->
        <ul id="gridMenu" class="mini-menu" style="display:none;" onbeforeopen="onBeforeOpen">  
            <li name="edit" iconCls="icon-addnew" onclick="onActionFE()">快速编辑商品</li>
	        <li name="edit" iconCls="icon-edit" onclick="editRowList()">编辑商品</li>
	        <li name="remove" iconCls="icon-remove" onclick="onRemove">删除商品</li>        
        </ul>
        <!--右键菜单 end-->
        <script src="js/FieldsList.js" type="text/javascript"></script>
    </div>
    </form>
</body>
</html>
