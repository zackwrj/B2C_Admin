<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.ProductManage.ProductBrand.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <!--#include file="/Adminlvcn/1ref/Inc/libs.htm"-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            商品品牌</h1>
        <div class="mini-toolbar">
            <a class="mini-button" iconcls="icon-add" href="Modify.aspx" target="main">新增</a>
            <a class="mini-button" iconcls="icon-edit" onclick="editRowList()">编辑</a> <a class="mini-button"
                iconcls="icon-remove" onclick="onRemove()">删除</a> <a class="mini-button" iconcls="icon-reload"
                    href="javascript:history.go(0)">刷新</a> <span class="separator"></span>品牌名称：<input
                        class="mini-textbox" id="seachText" />
            <a class="mini-button" plain="true" onclick="search()">查询</a>
        </div>
        <div id="datagrid1" class="mini-datagrid" style="width: 100%; height: 473px" url="ajax/ajax.aspx?method=SearchEmployees"
            valuefield="ProductBrandID" multiselect="true" pagesize="7" pageindex="0" sizelist="[8,16,32,64]"
            contextmenu="#gridMenu" allowresize="true">
            <div property="columns">
                <div type="checkcolumn">
                </div>
                <div field="ProductBrandID" width="35" headeralign="center" allowsort="true" align="center">
                    <b>ID</b>
                </div>
                <div field="Title" width="120" headeralign="center" allowsort="false" cellclick="editRow()">
                    <b>商品名称</b>
                    <input property="editor" class="mini-textbox" style="width: 100%;" />
                </div>
                <div field="Images" width="70" headeralign="center" allowsort="false" renderer="onGetImages"
                    align="center" headeralign="center">
                    <b>品牌图片</b></div>

                <div field="IsHot" width="70" headeralign="center" allowsort="false" renderer="onGetYesNo"
                    align="center" headeralign="center">
                    <b>是否热门</b></div>
                <div field="LastModifyDate" width="100" headeralign="center" dateformat="yyyy-MM-dd"
                    allowsort="true" align="center">
                    <b>最后修改时间</b>
                </div>
                <div name="action" width="50" headeralign="center" align="center" renderer="onActionRenderer"
                    cellstyle="padding:0;">
                    <b>操作</b></div>
            </div>
        </div>
        <div id="employeeWindow" class="mini-window" style="width: 650px; height: 400px;"
            bodystyle="padding:2px;" showfooter="true" showmodal="true" allowresize="true">
            <iframe id="employeeframe" frameborder="0" style="width: 100%; height: 100%;" border="0">
            </iframe>
            <div property="footer" style="padding: 8px; text-align: center;">
                <input class="mini-button" onclick="onSaveClick" text="保存" style="width: 60px; margin-right: 25px;" />
                <input class="mini-button" onclick="onCancelClick" text="取消" style="width: 60px;" />
            </div>
        </div>
        <!--右键菜单-->
        <ul id="gridMenu" class="mini-menu" style="display: none;" onbeforeopen="onBeforeOpen">
            <li name="edit" iconcls="icon-addnew" onclick="onActionFE()">快速编辑商品</li>
            <li name="edit" iconcls="icon-edit" onclick="editRowList()">编辑商品</li>
            <li name="remove" iconcls="icon-remove" onclick="onRemove">删除商品</li>
        </ul>
        <!--右键菜单 end-->
        <!--编辑窗口-->
        <div id="addImgWindow" title="编辑品牌" class="mini-window" style="width: 500px; height: 300px;"
            showmodal="true" showfooter="true" allowresize="true">
            <ul class="window_ul">
                <li>
                    <label>品牌名称：</label>
                    <input type="hidden" id="proBrandID" />
                    <input id="txtBrandName" name="BrandName" onvalidation="onPwdValidation" class="mini-password" requirederrortext="品牌名称不能为空" required="true" />
                </li>
                <li>
                    <label>
                        分类图片：</label>
                    <input id="pwd" name="pwd" onvalidation="onPwdValidation" class="mini-password" requirederrortext="密码不能为空"
                        required="true" />
                </li>
            </ul>
            <div property="footer" style="padding: 5px;">
                <div style="width: 100px; margin: auto;">
                    <input type="button" value="确定" onclick="submitForm()" />
                    <input type="button" value="取消" onclick="hideWindow()" />
                </div>
            </div>
        </div>
        <!--编辑窗口 End-->
        <script src="js/List.js" type="text/javascript"></script>
    </div>
    </form>
</body>
</html>
