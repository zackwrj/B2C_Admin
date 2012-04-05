
mini.parse();

var grid = mini.get("datagrid1");
var Genders = [{ id: 1, text: '是' }, { id: 0, text: '否'}]; //快速编辑时的数据

grid.load();
grid.sortBy("OrderID", "desc");
//pager(grid);


function search() {
    var key = $("#seachText input[type='text']").val();
    grid.load({ key: key });
}

function onTextEnter(e) {
    search();
}

function getSelecteds() {
    var rows = grid.getSelecteds();

    var s = "";
    for (var i = 0, l = rows.length; i < l; i++) {
        var row = rows[i];
        s += row.loginname;
        if (i != l - 1) s += ",";
    }
    alert(s);
}
function onGetYesNo(e) {
    if (e.value == '1') {
        return '<img src="/base_js/miniui/themes/icons/ok.png">';
    }
    else {
        return '<img src="/base_js/miniui/themes/icons/no.png">';
    }
}
function onGetMoney(e) {
    return "￥" + e.value + ".00";
}
function onGetImages(e) {
    return "<img src='" + e.value + "' width='50px' height='50px'/>";
}
function onGetDate(e) {
    var value = e.value;
    if (value) return mini.formatDate(value, 'yyyy-MM-dd');
    return "";
}


//function editWindow() {
//    var row = grid.getSelected();
//    if (row) {
//        mini.openTop({
//            url: "/Adminlvcn/OrderManage/Order/iframe/EditWindow.htm",
//            title: "编辑订单", width: 600, height: 360,
//            onload: function () {
//                var iframe = this.getIFrameEl();
//                var data = { action: "edit", id: row.OrderID };
//                iframe.contentWindow.SetData(data);
//            },
//            ondestory: function (action) {
//                grid.reload();
//            }
//        });

//    
//}
/****************弹出编辑窗口****************/
var messageBox; //正在加载
function editWindow() {
    var grid = mini.get("datagrid1");
    var row = grid.getSelecteds();
    if (row.length == 1) {
        messageBox = mini.loading("正在加载，请稍候...", "加载中"); //正在加载
        $('#order_orderNum').text(row[0].OrderNum);//订单号
        $('#order_ActualPayMoney').text(toMoney(row[0].ActualPayMoney)); //订单原价
        $.post('ajax/ajax.aspx?method=GetModel&id=' + row[0].OrderID, function (data) {
            /*订单信息*/
            mini.get('order_LogisticsNum').setValue(data.Order.LogisticsNum);
            mini.get('order_createdate').setValue(data.Order.CreateDate);
           // mini.get('order_Postage').setValue(data.Order.Postage);
            mini.get('order_Consignee').setValue(data.Order.Consignee);
            mini.get('order_MobilePhone').setValue(data.Order.MobilePhone);

            $('#get_total').text(toMoney(data.Order.ActualPayMoney));

            var _html;
            for (var i = 0; i < data.Product.length; i++) {
                _html += appendHtml(data.Product[i]);
            }
            $('#win_tabs tbody').html(_html);
            calculation();
            mini.hideMessageBox(messageBox); //隐藏正在加载
            showWin();
        }, 'json');
    } else if (row.length > 1) {
        mini.alert("请选择一个订单");
    }
    else {
        mini.alert("请选择订单");
    }
}
function saveWindow() { 
    
}
function Span(obj) {
    return $("#editWin span[name='" + obj + "']");
}
function closeWin() {
    var win = mini.get("editWin");
    win.hide();
}
function showWin() {
    var win = mini.get("editWin");
    win.show();
}
function onOk(e) {
    
    closeWin();
}
function onCancel(e) {
    closeWin();
}
function toMoney(obj) {
    try{
        var a = obj.split('.').length;
        return parseFloat(obj);
    }
    catch (e) {
        return obj + '.00';
    }
}
function calculation() {
    var $smallprice = $('#win_tabs input[name="FinallyPrice"]');
    $smallprice.each(function () {
        
    });
}
function appendHtml(obj) {
    var _html = '<tr>' +
                '<td>' +
                    '<img src="#" width="50" height="50" alt="Alternate Text" /></td>' +
                '<td>' + obj.ProductName +
                '</td>' +
                '<td>' +
                    '<ul>' + obj.ProductFieldsIDList +
                    '</ul>' +
                '</td>' +
                '<td>' +
                    '<input name="price" value="' + obj.Price + '"/>' +
                '</td>' +
                '<td>' +
                    '<input name="quantity" value="' + obj.Quantity + '"/>' +
                '</td>' +
                '<td>' +
                    '<input name="totalprice" value="' + obj.TotalPrice + '"/>' +
                '</td>' +
                '<td>' +
                    '<input  name="discount" value="0.01" />' +
                '</td>' +
                '<td>' +
                    '<input  name="postage" value="' + obj.postage + '"/>' +
                '</td>' +
                '<td>' +
                    '<input name="FinallyPrice" value="' + obj.FinallyPrice + '"/>' +
                '</td>' +
            '</tr>';
    return _html;
}
/****************弹出编辑窗口End******************/




/********右键**********/
function onBeforeOpen(e) {
    var grid = mini.get("datagrid1");
    var menu = e.sender;
}
function onAdd(e) {
    mini.alert("新增");
}
function onEdit(e) {
    editWindow();
}

//批删除
function onRemove(e) {
    var row = grid.getSelecteds();
    if (row.length > 1) {
        var idlist;
        for (var i = 0; i < row.length; i++) {
            idlist += row[i].OrderID;
            if (i < row.length - 1) {
                idlist += ",";
            }
        }
        idlist = idlist.replace('NaN', row[0].OrderID);
        if (idlist != "") {
            confirmDel(idlist, 'RemoveList');
        }
    }
    else if (row.length == 1) {
        confirmDel(row[0].OrderID, 'RemoveEmployees');
    }
    else {
        mini.alert('请选择商品');
    }
}
//删除一行
function delRow(row_uid) {
    var row = grid.getRowByUID(row_uid);
    if (row) {
        confirmDel(row.OrderID, 'RemoveEmployees');
    }
}

/********右键 END**********/

/********点击单元格直接编辑*********/
function onActionRenderer(e) {
    var grid = e.sender;
    var record = e.record;
    var uid = record._uid; //行索引
    var rowIndex = e.rowIndex;

    var s = '<a class="Edit_Button" onclick="editWindow()" target="_blank"><img title="快速编辑订单" src="/base_js/miniui/themes/icons/node.png"></a>'
            + '<a class="Edit_Button" href="' + editRow(uid) + '" target="main"><img title="编辑订单" src="/base_js/miniui/themes/icons/edit.gif"></a>'
            + '<a class="Delete_Button" href="javascript:delRow(\'' + uid + '\')"><img title="删除订单" src="/base_js/miniui/themes/icons/remove.gif"></a>';
    return s;
}

//右键快速编辑
function onActionFE() {
    var uid = record._uid; //行索引
    fEditRow(uid);
    var menu = mini.get('gridMenu');
    menu.hide();
}
//快速编辑
function fEditRow(row_uid) {
    var row = grid.getRowByUID(row_uid);
    if (row) {
        grid.cancelEdit();
        grid.beginEditRow(row);
    }
}
function updateRow(row_uid) {
    var row = grid.getRowByUID(row_uid);
    var rowData = grid.getEditRowData(row);
    grid.loading("保存中，请稍后......");
    var json = mini.encode([rowData]);
    $.ajax({
        url: "ajax/ajax.aspx?method=SaveEmployees",
        data: { employees: json },
        success: function (text) {
            grid.reload();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        }
    });
}
/********点击单元格直接编辑 ENd*********/

////快速保存
//function updateRow(row_uid) {
//    var row = grid.getRowByUID(row_uid);
//    var rowData = grid.getEditRowData(row);

//    grid.loading("保存中，请稍后......");
//    var json = mini.encode([rowData]);
//    alert(json);
//    $.ajax({
//        url: "../data/dataservice.aspx?method=SaveEmployees",
//        data: { employees: json },
//        success: function (text) {
//            grid.reload();
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//            alert(jqXHR.responseText);
//        }
//    });

//}
function editRow(row_uid) {
    var row = grid.getRowByUID(row_uid);
    if (row) {
        return "Modify.aspx?id=" + row.OrderID;
    }
    return "";
}

function editRowList(val) {
    var row = grid.getSelecteds();
    var _href;
    if (row.length == 1) {
        _href = "Modify.aspx?id=" + row[0].OrderID;
    }
    else if (row.length > 1) {
        var idlist;
        for (var i = 0; i < row.length; i++) {
            idlist += row[i].OrderID;
            if (i < row.length - 1) {
                idlist += ",";
            }
        }
        idlist = idlist.replace('NaN', row[0].OrderID);
        _href = "Modify.aspx?ids=" + idlist;
    }
    else {
        mini.alert('请选择商品');
        return false;
    }
    window.location = _href;
}

function cancelRow(row_uid) {
    grid.reload();
}

function confirmDel(_id, toMothod) {
    mini.confirm("确定删除商品？", "确定？",
            function (action) {
                if (action == "ok") {
                    delData(_id, toMothod);
                }
            }
        );
}

function delData(_id, toMothod) {
    //    grid.loading("删除中，请稍后...");
    $.ajax({
        url: "ajax/ajax.aspx?method=" + toMothod + "&id=" + _id,
        success: function (text) {
            mini.alert("删除成功", "提醒", function () {
                grid.reload();
            });
        },
        error: function () {
            mini.alert("删除失败", "提醒", function () {
                grid.reload();
            });
        }
    });
}




