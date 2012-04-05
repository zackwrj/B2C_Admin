mini.parse();

function page_reload() {
    mini.confirm("刷新页面将丢失数据，确定刷新页面吗？", "确定？",
        function (action) {
            if (action == "ok") {
                history.go(0);
            }
            else {
                return false;
            }
        });
}

function getForm() {
    var form = new mini.Form("#form1");
    var data = form.getData(true);
    var s = mini.encode(data);
    alert(s);
}
function setForm() {
    var obj = {
        String: "abc",
        Date: "2020-11-12",
        Boolean: 'Y',
        TreeSelect: "ajax",
        countrys: "cn",
        countrys2: "de",
        countrys3: "usa"
    };
    var form = new mini.Form("#form1");
    form.setData(obj);
}

function resetForm() {
    var form = new mini.Form("#form1");
    form.reset();
}
function clearForm() {
    var form = new mini.Form("#form1");
    form.clear();
}
