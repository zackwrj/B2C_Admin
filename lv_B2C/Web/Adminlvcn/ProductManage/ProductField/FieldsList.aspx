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
            <a class="mini-button" iconcls="icon-add" href="FieldsModify.aspx" target="main">新增</a>
            <a class="mini-button" iconcls="icon-edit" onclick="editRowList()" target="main">编辑</a>
            <a class="mini-button" iconcls="icon-remove" onclick="onRemove()">删除</a> <a class="mini-button"
                iconcls="icon-zoomin" onclick="onExpandAllClick">展开全部</a> <a class="mini-button"
                    iconcls="icon-zoomout" onclick="onCollapseAllClick">折叠全部</a> 
                <a class="mini-button" iconcls="icon-reload" href="javascript:history.go(-1)">返回</a>
                    <a class="mini-button" iconcls="icon-reload" href="javascript:history.go(0)">刷新</a> <span class="separator">
                        </span>属性名称：<input class="mini-textbox" id="seachText" />
            <a class="mini-button" plain="true" onclick="search()">查询</a>
        </div>
        <!--右键菜单-->
        <ul id="gridMenu" class="mini-menu" style="display: none;" onbeforeopen="onBeforeOpen">
            <li name="edit" iconcls="icon-addnew" onclick="onActionFE()">快速编辑属性</li>
            <li name="edit" iconcls="icon-edit" onclick="editRowList()">编辑属性</li>
            <li name="remove" iconcls="icon-remove" onclick="onRemove">删除属性</li>
        </ul>
        <!--右键菜单 end-->
        <div id="treegrid1" treecolumn="Title" valuefield="FieldsID" pagesize="18"
            sizelist="[18,36,54,108,9999]" showfooter="true" class="mini-treegrid" style="width: 100%;
            height: 474px;" showtreelines="true" contextmenu="#gridMenu" multiselect="true"
            url="ajax/FieldsTree.aspx?cid=<%=cid %>" allowresize="true" headeralign="center"
            align="center">
            <div property="columns">
                <div type="checkcolumn" width="10">
                </div>
                <div name="FieldsID" field="FieldsID" width="10">
                    <b>ID</b></div>
                <div name="Title" field="Title" width="120">
                    <b>属性名称</b>
                    <input property="editor" class="mini-textbox" style="width: 100px;" />
                </div>
                <div field="Images" width="20">
                    <b>图片</b></div>
                <div name="action" width="20" headeralign="center" align="center" renderer="onActionRenderer"
                    cellstyle="padding:0;">
                    <b>操作</b></div>
            </div>
        </div>
        <script src="js/FieldTree.js" type="text/javascript"></script>
        <%--<script src="js/FieldsList.js" type="text/javascript"></script>--%>
    </div>
    </form>
</body>
</html>
