<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="lv_B2C.Web.Adminlvcn.OrderManage.Order.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品订单</title>
    <link href="/Adminlvcn/1ref/css/miniui/demo.css" rel="stylesheet" type="text/css" />
    <link href="/Adminlvcn/1ref/css/miniui/icons.css" rel="stylesheet" type="text/css" />
    <link href="/Adminlvcn/1ref/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/base_js/miniui/themes/default/miniui.css" rel="stylesheet" type="text/css" />
    <script src="/base_js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/base_js/miniui/miniui.js" type="text/javascript"></script>

    <link href="css/Modify.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button Text="Btn" runat="server" OnClick="Unnamed1_Click" />
    <div>
        <h1>
            订单列表</h1>
        <div class="mini-toolbar">
            <%--<a class="mini-button" iconcls="icon-add" href="Modify.aspx" target="main">新增</a>--%>
            <a class="mini-button" iconcls="icon-edit" onclick="editWindow()">编辑</a> <a class="mini-button"
                iconcls="icon-remove" onclick="onRemove()">删除</a> <a class="mini-button" iconcls="icon-reload"
                    href="javascript:history.go(0)">刷新</a> <span class="separator"></span>订单号：<input
                        class="mini-textbox" id="seachText" onenter="onTextEnter" />
            <a class="mini-button" plain="true" onclick="search()">查询</a>
        </div>
        <div id="datagrid1" class="mini-datagrid" style="width: 100%; height: 473px" url="ajax/ajax.aspx?method=SearchEmployees"
            valuefield="OrderID" multiselect="true" pagesize="7" pageindex="0" sizelist="[8,16,32,64]"
            contextmenu="#gridMenu" allowresize="true">
            <div property="columns">
                <div type="checkcolumn">
                </div>
                <div field="OrderID" width="35" headeralign="center" allowsort="true" align="center">
                    <b>ID</b>
                </div>
                <div field="OrderNum" width="70" headeralign="center" allowsort="false" align="center"
                    headeralign="center">
                    <b>订单号</b></div>
                <div field="LogisticsNum" width="120" headeralign="center" allowsort="false" cellclick="editRow()">
                    <b>物流单号</b>
                    <input property="editor" class="mini-textbox" style="width: 100%;" />
                </div>
                <div field="CreateDate" width="60" headeralign="center" dateformat="yyyy-MM-dd" align="center"
                    allowsort="true">
                    <b>下单时间</b>
                </div>
                <div field="Postage" width="60" allowsort="true" renderer="onGetMoney" align="center"
                    headeralign="center">
                    <b>运费</b>
                    <input property="editor" class="mini-spinner" minvalue="0" maxvalue="999999" value="25"
                        style="width: 100%;" />
                </div>
                <div field="MerchantsModifyPrice" width="50" headeralign="center" allowsort="true"
                    align="center">
                    <b>订单总金额</b>
                    <input property="editor" class="mini-spinner" minvalue="0" maxvalue="999999" value="25"
                        style="width: 100%;" />
                </div>
                <div field="Consignee" width="50" allowsort="true" align="center" headeralign="center">
                    <b>收货人</b>
                </div>
                <div field="MobilePhone" width="100" headeralign="center" allowsort="true" align="center">
                    <b>手机号码</b>
                </div>
                <div name="action" width="50" headeralign="center" align="center" renderer="onActionRenderer"
                    cellstyle="padding:0;">
                    <b>操作</b></div>
            </div>
        </div>
        <div id="editWin" class="mini-window" title="<b>编辑订单</b>" style="width: 740px; height: 410px;"
            showtoolbar="true" showfooter="true" showmodal="true" allowresize="true" allowdrag="true">
            <div property="toolbar">
                <ul class="header_ul">
                    <li>订单号：<span id="order_orderNum"></span></li>
                    <li>订单原价：<span id="order_ActualPayMoney"></span> 元</li>
                </ul>
            </div>
            <div property="footer" style="height: 33px;">
                <div style="width: 180px; height: 33px; margin: auto; line-height: 30px; overflow: hidden;
                    text-align: center;">
                    <a class="mini-button" onclick="onOk" style="width: 60px; margin-right: 20px;">保存</a>
                    <a class="mini-button" onclick="onCancel" style="width: 60px;">取消</a>
                </div>
            </div>
            <div class="win_contents">
                <ul>
                    <li>　物流单号：</li>
                    <li><input id="order_LogisticsNum" class="mini-textbox" /></li>
                </ul>
                <ul>
                    <li>　下单时间：</li>
                    <li><input id="order_createdate" class="mini-datepicker" disabled="disabled" /></li>
                </ul>
               <%-- <ul>
                    <li>　运　　费：</li>
                    <li><input id="order_Postage" class="mini-spinner" required="true" /></li>
                </ul>--%>
               <%-- <ul>
                    <li>订单总金额：</li>
                    <li><input id="order_ProductTotalPrice" class="mini-spinner" required="true" /></li>
                </ul>--%>
                <ul>
                    <li>　　收货人：</li>
                    <li><input id="order_Consignee" class="mini-textbox" disabled="disabled" /></li>
                </ul>
                <ul>
                    <li>　手机号码：</li>
                    <li><input id="order_MobilePhone" class="mini-textbox" disabled="disabled" /></li>
                </ul>
            </div>
            <div style="clear:both;"></div>
            <div class="win_tabs" id="win_tabs">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <thead>
                        <tr>
                            <td style="width:80px;">商品图片</td>
                            <td>商品名称</td>
                            <td>商品属性</td>
                            <td>单价</td>
                            <td>数量</td>
                            <td>商品总价</td>
                            <td>折扣</td>
                            <td>运费</td>
                            <td>小计</td>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div style="clear:both;"></div>
            <div class="win_bottom">
                <ul>
                    <li>收货地址：</li>
                    <li>广东省 广州市 越秀区 </li>
                </ul>
                <ul>
                    <li>买家实付：</li>
                    <li><span id="get_prototalprice">25.00</span> + 
                        <span id="get_postage">10.00</span> + 
                        <span id="get_discount">0.00</span> = 
                        <span id="get_total">35.00</span> 元
                    </li>
                </ul>
                <ul class="light">
                    <li>买家实付 = </li>
                    <li>商品总价 + 运费 + 折扣</li>
                </ul>
            </div>
        </div>
        <!--右键菜单-->
        <ul id="gridMenu" class="mini-menu" style="display: none;" onbeforeopen="onBeforeOpen">
            <li name="edit" iconcls="icon-addnew" onclick="onActionFE()">快速编辑商品</li>
            <li name="edit" iconcls="icon-edit" onclick="editRowList()">编辑商品</li>
            <li name="remove" iconcls="icon-remove" onclick="onRemove">删除商品</li>
        </ul>
        <!--右键菜单 end-->
        <script src="js/List.js" type="text/javascript"></script>
    </div>
    </form>
</body>
</html>
