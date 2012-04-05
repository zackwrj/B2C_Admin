<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>B2C管理后台</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <script src="/base_js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/base_js/miniui/miniui.js" type="text/javascript"></script>
    <link href="/base_js/miniui/themes/default/miniui.css" rel="stylesheet" type="text/css" />
    <link href="/base_js/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    html, html body
    {
        padding:0;border:0;margin:0;
        width:100%;height:100%;overflow:hidden;
        font-family:Verdana;
        font-size:12px;    
        line-height:22px;
    }
    .header
    {
        background:url(1ref/images/header.gif) repeat-x 0 -1px;
    }
   
    </style>
</head>
<body>
<div id="layout1" class="mini-layout" style="width:100%;height:100%;" >
    <div class="header" region="north" height="70" showSplit="false" showHeader="false">
        <h1 style="margin:0;padding:15px;cursor:default;">B2C管理后台</h1>
    </div>
    <div title="south" region="south" showSplit="false" showHeader="false" height="30" >
        <div style="line-height:28px;text-align:center;cursor:default">Copyright © 广州市龙睿网络科技有限公司版权所有 </div>
    </div>
    <div showHeader="true" showCollapseButton="true" showSplit="true" region="west" width="180" maxWidth="250" minWidth="100">
        <!--左导航 begin-->
        <div id="navbar1" class="mini-navbar" activeIndex="0" style="width:100%;height:100%;" autoCollapse="true" borderStyle="border:0;">
            <div title="商品管理">
                <ul id="tree1" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" > 
                    <li><a href="ProductManage/Product/List.aspx" target="main" onclick='waitClick()'>商品列表</a></li>
                    <li><a href="ProductManage/Product/Modify.aspx" target="main" onclick='waitClick()'>新增商品</a></li>
                    <li><a href="ProductManage/ProductClass/List.aspx" target="main" onclick='waitClick()'>商品分类</a></li>
                    <li><a href="ProductManage/ProductField/List.aspx" target="main" onclick='waitClick()'>商品属性</a></li>
                    <li><a href="ProductManage/ProductBrand/List.aspx" target="main" onclick='waitClick()'>商品品牌</a></li>
                    <li><a href="Product/ProductRecycleBin.aspx" target="main" onclick='waitClick()'>商品回收站</a></li>
                    <li><a href="Product/ProductKeyWords.aspx" target="main" onclick='waitClick()'>商品关键字</a></li>
                </ul>
            </div>
            <div title="栏目管理">            
                <ul id="tree2" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><a href="ChannelItemManage/SiteMenu/List.aspx" target="main" onclick='waitClick()'>网站主导航栏目</a></li>
                </ul>
            </div>
            <div title="订单管理">            
                <ul id="tree3" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><a href="OrderManage/Order/List.aspx" target="main" onclick='waitClick()'>订单列表</a></li>
                     <li><span>订单高级搜索</span></li>
                     <li><span>订单打印</span></li>
                     <li><span>订单操作日志</span></li>
                </ul>
            </div>
            <div title="物流管理">            
                <ul id="tree4" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>邮费模板</span></li>
                     <li><span>物流公司</span></li>
                </ul>
            </div>
            <div title="文章管理">
                <ul id="tree5" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><a href="ArticleManage/Article/List.aspx" target="main" onclick='waitClick()'>文章列表</a></li>
                     <li><a href="ArticleManage/ArticleClass/List.aspx" target="main" onclick='waitClick()'>文章分类</a></li>
                     <li><span>文章关键字</span></li>
                </ul>
            </div>
            <div title="消息（评论）管理">            
                <ul id="tree6" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>消息管理</span></li>
                     <li><span>评论管理</span></li>
                </ul>
            </div>
            <div title="用户管理">            
                <ul id="tree7" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>用户列表</span></li>
                     <li><span>用户等级</span></li>
                     <li><span>用户账户</span>
                        <ul>
                            <li><span>积分</span></li>
                            <li><span>钱包</span></li>
                        </ul>
                     </li>
                </ul>
            </div>
            <div title="广告管理">            
                <ul id="tree8" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>广告管理</span></li>
                </ul>
            </div>
            <div title="商家（加盟）管理">            
                <ul id="tree9" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>商家（加盟）</span></li>
                </ul>
            </div>
            <div title="活动管理">            
                <ul id="tree10" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>优惠活动</span></li>
                     <li><span>超值礼包</span></li>
                </ul>
            </div>
            <div title="帮助中心">            
                <ul id="tree11" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>帮助中心</span></li>
                </ul>
            </div>
            <div title="系统设置">            
                <ul id="tree12" onselectnode="onNodeSelect" class="mini-tree" style="width:100%;height:100%;" showTreeIcon="true" textField="text" valueField="id" >       
                     <li><span>系统设置</span></li>
                </ul>
            </div>
        </div>        
        <!--左导航 end-->
    </div>
    <div id="iframe_parent" title="center" region="center" bodyStyle="overflow:hidden;">
        <iframe id="main" onload="iframeLoad()" frameborder="0" name="main" src="OrderManage/Order/List.aspx" style="width:100%;height:100%;" border="0"></iframe>
    </div>
</div>
<script src="1ref/js/js.js" type="text/javascript"></script>
</body>
</html>
