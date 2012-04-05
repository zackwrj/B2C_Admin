<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.ArticleManage.Article.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章列表</title>
    <!--#include file="/Adminlvcn/1ref/Inc/libs.htm"-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            文章列表</h1>
        <div class="mini-toolbar">
            <a class="mini-button" iconCls="icon-add" href="Modify.aspx" target="main">新增</a>
            <a class="mini-button" iconCls="icon-edit" onclick="editRowList()" target="main">编辑</a>
            <a class="mini-button" iconCls="icon-remove" onclick="onRemove()">删除</a>
            <a class="mini-button" iconCls="icon-reload" href="javascript:history.go(0)">刷新</a>
            <span class="separator"></span>
            所属类别：
            <input id='selectClass' multiselect="true" class="mini-treeselect" url="/Adminlvcn/1ref/base_ajax/ajax.aspx?method=GetInputSelectClass" valueField="id" textField="text"/>
            &nbsp;文章标题：<input class="mini-textbox" id="seachText" />      
            <a class="mini-button" plain="true" onclick="search()">查询</a>
        </div>
        <div id="datagrid1" class="mini-datagrid" style="width: 100%; height:473px" url="/Article/List.aspx?method=SearchArticleList"
            valuefield="ProductID" multiselect="true" pageSize="7" pageIndex="0" sizeList="[8,16,32,64]" contextMenu="#gridMenu" allowResize="true">
            <div property="columns">
                <div type="checkcolumn">
                </div>
                <div field="ProductID" width="35" headeralign="center" allowsort="true" align="center">
                    <b>ID</b>
                </div>
                <div field="Title" width="120" headeralign="center" allowsort="false" cellclick="editRow()">
                    <b>文章标题</b>
                    <input property="editor" class="mini-textbox" style="width:100%;"/>
                </div>
                <div field="Author" width="60" renderer="onGetMoney" headeralign="center" align="center" allowsort="true">
                    <b>作者</b>
                    <input property="editor" class="mini-spinner" minValue="0" maxValue="999999" value="25" style="width:100%;"/>    
                </div>
                <div field="CreateBy" width="60" allowsort="true" renderer="onGetMoney" align="center"  headeralign="center">
                    <b>创建者</b>
                    <input property="editor" class="mini-spinner" minValue="0" maxValue="999999" value="25" style="width:100%;"/>    
                </div>
                <div field="CreateDate" width="50" headeralign="center" allowsort="true" align="center"  >
                    <b>创建时间</b>
                    <input property="editor" class="mini-spinner" minValue="0" maxValue="999999" value="25" style="width:100%;"/>
                </div>
                <div field="ModifyBy" width="50" allowsort="true" renderer="onGetYesNo" align="center" headeralign="center" >
                    <b>编辑者</b>
                    <input property="editor" class="mini-combobox" style="width:100%;" value="0" data="Genders"/>      
                </div>
                <div field="LastModifyDate" width="50" allowsort="true" align="center" headeralign="center" >
                    <b>编辑时间</b>
                    <input property="editor" class="mini-spinner" minValue="0" value="25" style="width:100%;"/>
                </div>
                <div field="Hists" width="100" headeralign="center" dateformat="yyyy-MM-dd" allowsort="true" align="center">
                    <b>点击率</b>
                    <input property="editor" class="mini-datepicker" style="width:100%;"/>
                </div>
                <div name="action" width="50" headerAlign="center" align="center" renderer="onActionRenderer" cellStyle="padding:0;"><b>操作</b></div>
            </div>
        </div>
        <!--右键菜单-->
        <ul id="gridMenu" class="mini-menu" style="display:none;" onbeforeopen="onBeforeOpen">  
            <li name="edit" iconCls="icon-addnew" onclick="onActionFE()">快速编辑商品</li>
	        <li name="edit" iconCls="icon-edit" onclick="editRowList()">编辑商品</li>
	        <li name="remove" iconCls="icon-remove" onclick="onRemove">删除商品</li>        
        </ul>
        <!--右键菜单 end-->
        <script src="js/list.js" type="text/javascript"></script>
    </div>
    </form>
</body>
</html>
