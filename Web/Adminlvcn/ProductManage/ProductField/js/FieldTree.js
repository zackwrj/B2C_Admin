mini.parse();

var treegrid1 = mini.get("treegrid1");

treegrid1.load();

function onTextEnter(e) {
    onClick();
}
function onClick(e) {

    var key = mini.get("key");
    var text = key.getValue();

    treegrid1.load({
        name: text
    });
}
onCollapseAllClick();
function onExpandAllClick(e) {
    treegrid1.expandAll();
}
function onCollapseAllClick(e) {
    treegrid1.collapseAll();
}


/********右键**********/
function onBeforeOpen(e) {
    var treegrid1 = mini.get("datagrid1");
    var menu = e.sender;
}
function onAdd(e) {
    mini.alert("新增");
}
function onEdit(e) {
    var row = treegrid1.getSelected();
    if (row) {
        mini.alert("编辑：" + row.Title);
    }
}

//右键快速编辑
function onActionFE(e) {
    var record = e.record;
    var uid = record._uid; //行索引
    fEditRow(uid);
    var menu = mini.get('gridMenu');
    menu.hide();
}
//快速编辑
function fEditRow(row_uid) {
    var row = treegrid1.getRowByUID(row_uid);
    if (row) {
        treegrid1.cancelEdit();
        treegrid1.beginEditRow(row);
    }
}
/********右键 End**********/


//批删除
function onRemove(e) {
    var row = treegrid1.getSelecteds();
    if (row.length > 1) {
        var idlist;
        for (var i = 0; i < row.length; i++) {
            idlist += row[i].ProductFieldsID;
            if (i < row.length - 1) {
                idlist += ",";
            }
        }
        idlist = idlist.replace('undefined', '');
        if (idlist != "") {
            confirmDel(idlist, 'RemoveList');
        }
    }
    else if (row.length == 1) {
        confirmDel(row[0].ProductFieldsID, 'RemoveEmployees');
    }
    else {
        mini.alert('请选择商品');
    }
}
//删除一行
function delRow(row_uid) {
    var row = treegrid1.getRowByUID(row_uid);
    if (row) {
        confirmDel(row.ProductFieldsID, 'RemoveEmployees');
    }
}



//function onActionRenderer(e) {
////    var record = e.record;
////    var uid = record._uid; //行索引
////    var rowIndex = e.rowIndex;
////    var _id = record.ProductFieldsID;

//    var s =  '<a class="Edit_Button" href="" target="_blank"><img title="快速编辑商品" src="/base_js/miniui/themes/icons/node.png"></a>'
//            + '<a class="Edit_Button" href="###" target="_blank"><img title="查看商品" src="/base_js/miniui/themes/icons/goto.gif"></a>'
//            + '<a class="Edit_Button" href="" target="main"><img title="编辑商品" src="/base_js/miniui/themes/icons/edit.gif"></a>'
//            + '<a class="Delete_Button" href=""><img title="删除商品" src="/base_js/miniui/themes/icons/remove.gif"></a>';

////    if (treegrid1.isEditingRow(record)) {
////        s = '<a class="Update_Button" href="">保存</a>'
////                    + '<a class="Cancel_Button" href="">取消</a>'
////    }
//    return s;
//}

/********点击单元格直接编辑*********/
function onActionRenderer(e) {
    var row = treegrid1.getSelected();
    var record = e.record;
    var uid = record._uid; //行索引
    var s = '<a class="Edit_Button" href="javascript:fEditRow(\'' + uid + '\')" target="_blank"><img title="快速编辑属性" src="/base_js/miniui/themes/icons/node.png"></a>'
            + '<a class="Edit_Button" href="' + editRow(uid) + '" target="main"><img title="编辑属性" src="/base_js/miniui/themes/icons/edit.gif"></a>'
            + '<a class="Delete_Button" href="javascript:delRow(\'' + uid + '\')"><img title="删除属性" src="/base_js/miniui/themes/icons/remove.gif"></a>';

    if (treegrid1.isEditingRow(row)) {
        s = '<a class="Update_Button" href="javascript:updateRow(\'' + uid + '\')">保存</a>'
                    + '<a class="Cancel_Button" href="javascript:cancelRow(\'' + uid + '\')">取消</a>'
    }
    return s;
}

function editCell(e) {
    getCellEl(e.record, e.column);
    treegrid1.cancelEdit();

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
    var row = treegrid1.getRowByUID(row_uid);
    if (row) {
        treegrid1.cancelEdit();
        treegrid1.beginEditRow(row);
    }
}
//快速保存
function updateRow(row_uid) {
    var row = treegrid1.getRowByUID(row_uid);
    var rowData = treegrid1.getEditRowData(row);
    treegrid1.loading("保存中，请稍后......");
    var json = mini.encode([rowData]);
    $.ajax({
        url: "ajax/FieldAjax.aspx?method=SaveEmployees",
        data: { employees: json },
        success: function (text) {
            treegrid1.reload();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        }
    });
}
/********点击单元格直接编辑 ENd*********/

function editRow(row_uid) {
    var row = treegrid1.getRowByUID(row_uid);
    if (row) {
        return "FieldsModify.aspx?id=" + row.ProductFieldsID;
    }
    return "";
}

function editRowList() {
    var row = treegrid1.getSelecteds();
    var _href;
    if (row.length > 0) {
        _href = "FieldsModify.aspx?id=" + row[0].ProductFieldsID;
    }
    else {
        mini.alert('请选择商品');
        return false;
    }
    window.location = _href;
}

function cancelRow(row_uid) {
    treegrid1.reload();
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
    //    treegrid1.loading("删除中，请稍后...");
    $.ajax({
        url: "ajax/FieldAjax.aspx?method=" + toMothod + "&id=" + _id,
        success: function (text) {
            mini.alert("删除成功", "提醒", function () {
                treegrid1.reload();
            });
        },
        error: function () {
            mini.alert("删除失败", "提醒", function () {
                treegrid1.reload();
            });
        }
    });
}
