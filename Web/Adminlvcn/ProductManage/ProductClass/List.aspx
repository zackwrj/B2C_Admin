<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.ProductManage.ProductClass.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品分类</title>
    <!--#include file="/Adminlvcn/1ref/Inc/libs.htm"-->
    <link href="css/List.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            商品分类</h1>
        <div class="mini-toolbar">
            <a class="mini-button" iconcls="icon-add" href="###" target="main">新增</a> <a class="mini-button"
                iconcls="icon-edit" onclick="onEditNode()" target="main">编辑</a> <a class="mini-button"
                    iconcls="icon-remove" onclick="onRemove()">删除</a> <a class="mini-button" iconcls="icon-zoomin"
                        onclick="expandAll()" target="main">展开全部</a> <a class="mini-button" iconcls="icon-zoomout"
                            onclick="collapseAll()" target="main">折叠全部</a> <a class="mini-button" iconcls="icon-reload"
                                href="javascript:history.go(0)">刷新</a> <span class="separator">
            </span>类别名称：<input class="mini-textbox" id="seachText" />
            <a class="mini-button" plain="true" id="seachSubmit">查询</a>
        </div>
        <div class="product-class-main">
            <div class="top">
                <ul>
                    <li style="float: left; margin-left: 25px;">类别名称</li>
                    <li style="float: right; margin-right: 20px;">操作</li>
                    <li style="float: right; margin-right: 200px;">添加图片</li>
                </ul>
            </div>
            <div class="abs-son">
                <asp:Literal ID="litClass" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div style="width: 100%; height: 30px; text-align: center; margin-top: 10px;">
        <asp:Button ID="btnSave" runat="server" Text="保存"></asp:Button>
        <asp:Button ID="btnBack" runat="server" OnClientClick="javascript:history.go(-1)"
            Text="返回"></asp:Button>
    </div>
    <!--右键菜单-->
    <ul id="treeMenu" class="mini-menu" style="display: none;" onbeforeopen="onBeforeOpen">
        <li iconcls="icon-move" onclick="onMoveNode">移动类别</li>
        <li class="separator"></li>
        <li><span iconcls="icon-add">新增类别</span>
            <ul>
                <li onclick="onAddBefore">在此之前插入</li>
                <li onclick="onAddAfter">在此之后插入</li>
                <li onclick="onAddNode">插入子类别</li>
            </ul>
        </li>
        <li name="edit" iconcls="icon-edit" id="eidt" onclick="onEditNode()">编辑类别</li>
        <li name="remove" iconcls="icon-remove" onclick="onRemoveNode">删除类别</li>
    </ul>
    <!--右键菜单 end-->
    <!--添加图片、编辑图片-->
    <div id="addImgWindow" title="添加图片" class="mini-window" style="width: 500px; height: 300px;" showmodal="true" showfooter="true" allowresize="true">
        <ul class="window_ul">
            <li>
                <label>分类名称：</label>
                <span id="productclassname"></span>
            </li>
            <li>
                <label>分类图片：</label>
                <input id="pwd" name="pwd" onvalidation="onPwdValidation" class="mini-password" requirederrortext="密码不能为空" required="true" />
            </li>
        </ul>
                    
        <div property="footer" style="padding: 5px;">
            <div style="width:100px;margin:auto;">
                <input type="button" value="确定" onclick="submitForm()" />
                <input type="button" value="取消" onclick="hideWindow()" />
            </div>
        </div>
    </div>
    <!--添加图片、编辑图片 End-->
    <script src="js/List.js" type="text/javascript"></script>
    </form>
</body>
</html>
