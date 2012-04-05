mini.parse();
//var _ajaxPath = "/Adminlvcn/1ref/ajax/product/";

var grid = mini.get("datagrid1");
var Genders = [{ id: 1, text: '是' }, { id: 0, text: '否'}]; //快速编辑时的数据

grid.load();
grid.sortBy("ChannelItemID", "desc");
//pager(grid);

setCheckRecursive(true);
function setCheckRecursive(checked) {
    var tree = mini.get("mini-7");
    tree.setCheckRecursive(checked);
}

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


/********右键**********/
function onBeforeOpen(e) {
    var grid = mini.get("datagrid1");
    var menu = e.sender;
}

/********右键 END**********/

/********点击单元格直接编辑*********/
function onActionRenderer(e) {
    var grid = e.sender;
    var record = e.record;
    var uid = record._uid;//行索引
    var rowIndex = e.rowIndex;

    var s = '<a class="Edit_Button" href="javascript:fEditRow(\'' + uid + '\')" target="_blank"><img title="编辑栏目" src="/base_js/miniui/themes/icons/edit.gif"></a>'; 

    if (grid.isEditingRow(record)) {
        s = '<a class="Update_Button" href="javascript:updateRow(\'' + uid + '\')">保存</a>'
                    + '<a class="Cancel_Button" href="javascript:cancelRow(\'' + uid + '\')">取消</a>'
    }
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

function cancelRow(row_uid) {
    grid.reload();
}
