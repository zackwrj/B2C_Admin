mini.parse();
//var _ajaxPath = "/Adminlvcn/1ref/ajax/product/";

var grid = mini.get("datagrid1");
var Genders = [{ id: 1, text: '是' }, { id: 0, text: '否'}]; //快速编辑时的数据

grid.load();
grid.sortBy("ProductId", "desc");
//pager(grid);

setCheckRecursive(true);
function setCheckRecursive(checked) {
    var tree = mini.get("mini-7");
    tree.setCheckRecursive(checked);
}

function search() {
    var selClass = mini.get('selectClass');
    var brand = mini.get('selectBrand');
    var key = $("#seachText input[type='text']").val();
    grid.load({ key: '' + selClass.getValue() + '[-($)-]' + brand.getValue() + '[-($)-]' + key + '' });
}
$("#seachText").bind("keydown", function (e) {
    if (e.keyCode == 13) {
        search();
    }
});

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


/********右键**********/
function onBeforeOpen(e) {
    var grid = mini.get("datagrid1");
    var menu = e.sender;
}
function onAdd(e) {
    mini.alert("新增");
}
function onEdit(e) {
    var row = grid.getSelected();
    if (row) {
        mini.alert("编辑：" + row.Title);
    }
}

//批删除
function onRemove(e) {
    var row = grid.getSelecteds();
    if (row.length > 1) {
        var idlist;
        for (var i = 0; i < row.length; i++) {
            idlist += row[i].ProductID;
            if (i < row.length - 1) {
                idlist += ",";
            }
        }
        idlist = idlist.replace('NaN', row[0].ProductID);
        if (idlist != "") {
            confirmDel(idlist, 'RemoveList');
        }
    }
    else if (row.length == 1) {
        confirmDel(row[0].ProductID, 'RemoveEmployees');
    }
    else {
        mini.alert('请选择商品');
    }
}
//删除一行
function delRow(row_uid) {
    var row = grid.getRowByUID(row_uid);
    if (row) {
        confirmDel(row.ProductID, 'RemoveEmployees');
    }
}

/********右键 END**********/

/********点击单元格直接编辑*********/
function onActionRenderer(e) {
    var grid = e.sender;
    var record = e.record;
    var uid = record._uid;//行索引
    var rowIndex = e.rowIndex;

    var s = '<a class="Edit_Button" href="javascript:fEditRow(\'' + uid + '\')" target="_blank"><img title="快速编辑商品" src="/base_js/miniui/themes/icons/node.png"></a>'
            + '<a class="Edit_Button" href="###" target="_blank"><img title="查看商品" src="/base_js/miniui/themes/icons/goto.gif"></a>'
            + '<a class="Edit_Button" href="'+editRow(uid)+'" target="main"><img title="编辑商品" src="/base_js/miniui/themes/icons/edit.gif"></a>'
            + '<a class="Delete_Button" href="javascript:delRow(\'' + uid + '\')"><img title="删除商品" src="/base_js/miniui/themes/icons/remove.gif"></a>';

    if (grid.isEditingRow(record)) {
        s = '<a class="Update_Button" href="javascript:updateRow(\'' + uid + '\')">保存</a>'
                    + '<a class="Cancel_Button" href="javascript:cancelRow(\'' + uid + '\')">取消</a>'
    }
    return s;
}

function editCell(e) {
    getCellEl(e.record, e.column);
    grid.cancelEdit();

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
        return "Modify.aspx?id=" + row.ProductID;
    }
    return "";
}

function editRowList(val) {
    var row = grid.getSelecteds();
    var _href;
    if (row.length == 1) {
        _href = "Modify.aspx?id=" + row[0].ProductID;
    }
    else if (row.length > 1) {
        var idlist;
        for (var i = 0; i < row.length; i++) {
            idlist += row[i].ProductID;
            if (i < row.length - 1) {
                idlist += ",";
            }
        }
        idlist = idlist.replace('NaN', row[0].ProductID);
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




