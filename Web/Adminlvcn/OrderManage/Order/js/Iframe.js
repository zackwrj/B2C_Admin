//加载商品信息
//        var grid = mini.get("datagrid1");
//        grid.load();
//        grid.sortBy("ProductId", "desc");
//加载商品ssss信息Endkdkdkdkd88e8348384323123123

mini.parse();

var form = new mini.Form("form1");

var formData = { id: 0 };


function SaveData() {
    var o = form.getData();
    o.id = formData.id;

    form.validate();
    if (form.isValid() == false) return;

    var json = mini.encode([o]);
    $.ajax({
        url: "../data/DataService.aspx?method=SaveEmployees",
        data: { employees: json },
        cache: false,
        success: function (text) {

            CloseWindow("save");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
            CloseWindow();
        }
    });
}

//标准方法接口定义
function SetData(data) {
    alert(123);
    if (data.action == "edit") {
        //跨页面传递的数据对象，克隆后才可以安全使用
        data = mini.clone(data);
        formData.id = data.id;
        alert(formData.id);
        $.ajax({
            url: "../ajax/ajax.aspx?method=GetModel&id=" + data.id,
            cache: false,
            success: function (text) {
                alert(123);
                alert(text);
                var o = mini.decode(text);
                form.setData(o);
                //                onDeptChanged();
                //                mini.getbyName("position").setValue(o.position);
            }
        });
    }
}



function GetData() {
    var o = form.getData();
    return o;
}
function CloseWindow(action) {
    if (window.CloseOwnerWindow) window.CloseOwnerWindow(action);
    else window.close();
}
function onOk(e) {
    SaveData();
}
function onCancel(e) {
    CloseWindow("cancel");
}
//////////////////////////////////
//function onDeptChanged(e) {
//    var deptCombo = mini.getbyName("dept_id");
//    var positionCombo = mini.getbyName("position");
//    var dept_id = deptCombo.getValue();

//    positionCombo.load("../data/DataService.aspx?method=GetPositionsByDepartmenId&id=" + dept_id);
//    positionCombo.setValue("");
//}


