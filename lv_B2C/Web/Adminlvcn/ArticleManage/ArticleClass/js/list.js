/// <reference path="../../../../base_js/jquery-1.6.2.min.js" />

mini.parse();

var tree = mini.get("tree1");


function onAddBefore(e) {
    var tree = mini.get("tree1");
    var node = tree.getSelectedNode();

    var newNode = {};
    tree.addNode(newNode, "before", node);
}
function onAddAfter(e) {
    var tree = mini.get("tree1");
    var node = tree.getSelectedNode();

    var newNode = {};
    tree.addNode(newNode, "after", node);
}
function onAddNode(e) {
    var tree = mini.get("tree1");
    var node = tree.getSelectedNode();

    var newNode = {};
    tree.addNode(newNode, "add", node);
}

//编辑
function onEditNode() {
    var node = $('#tree1 .mini-tree-selectedNode'); //获取选中节点
    if (node.length > 0) {
        mini.get('treeMenu').hide();
        var edit_b = node.find('b');
        var pcd = edit_b.attr('pcd');

        edit_b.after('<input class="b_to_edit" type="text" value="' + edit_b.text() + '" />');
        edit_b.hide();
        edit_b.siblings('input.b_to_edit').focus().select().blur(function () {
            var thisval = $(this).val()
            edit_b.show().text(thisval);
            $.post('ajax/ajax.aspx?method=UpdateField', { Action: "post", id: pcd, FName: 'Title', FVal: thisval }, function () { });
            $(this).remove();
        });
    }
    else {
        mini.alert('请选中需要编辑的分类');
    }
}
function onRemoveNode(e) {
    var tree = mini.get("tree1");
    var node = tree.getSelectedNode();

    if (node) {
        if (confirmClick()) {
            tree.removeNode(node);
        }
    }
}
function onMoveNode(e) {
    var tree = mini.get("tree1");
    var node = tree.getSelectedNode();

    alert("moveNode");
}
function onBeforeOpen(e) {
    var menu = e.sender;
    var tree = mini.get("tree1");

    var node = tree.getSelectedNode();
    if (node && node.text == "Base") {
        e.cancel = true;
        //阻止浏览器默认右键菜单
        e.htmlEvent.preventDefault();
        return;
    }

    ////////////////////////////////
    var editItem = mini.getbyName("edit", menu);
    var removeItem = mini.getbyName("remove", menu);
    editItem.show();
    removeItem.enable();

}

//展开所有
function expandAll() {
    var tree = mini.get("tree1");
    tree.expandAll();
}
//折叠所有
function collapseAll() {
    var tree = mini.get("tree1");
    tree.collapseAll();
}



/******移动节点*******/

var moveWindow = mini.get("moveWindow");
var moveTree = mini.get("moveTree");

function fillMoveTree(treeData) {
    treeData = mini.clone(treeData);
    moveTree.loadData(treeData);
    moveTree.collapseAll();
    document.getElementById("moveAction").value = "add";
}


/******移动节点 End*******/


/****添加图片*********/
var addImgWindow = mini.get('addImgWindow');

function onAddImg() {
    var proname = document.getElementById("productclassname");
    var _selectName = $('#tree1 .mini-tree-selectedNode b').text(); //获取选中节点
    proname.innerText = _selectName;
    addImgWindow.show();
}
function hideWindow() {
    addImgWindow.hide();
}



function submitForm() {
    var form = new mini.Form("#form1");
    form.validate();
    if (form.isValid() == false) return;

    form.ajaxSubmit({
        url: "FormService.aspx",
        success: function (text) {
            alert("提交成功，返回结果:" + text);
        }
    });
}

function isEmail(s) {
    if (s.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
        return true;
    else
        return false;
}
function onUserNameValidation(e) {
    if (e.isValid) {
        if (isEmail(e.value) == false) {
            e.errorText = "必须输入邮件地址";
            e.isValid = false;
        }
    }
}
function onPwdValidation(e) {
    if (e.isValid) {
        if (e.value.length < 5) {
            e.errorText = "密码不能少于5个字符";
            e.isValid = false;
        }
    }
}

/****添加图片 End*********/


//删除分类
function del(val) {
    mini.confirm("确定删除分类？", "确定？",
        function (action) {
            if (action == "ok") {
                var pcd = val.getAttribute('pcd');
                $.post("ajax/ajax.aspx?method=RemoveClass", { Action: "post", Pcd: pcd }, function (data) {
                    if (data > 0) {
                        mini.alert("删除成功！", "提醒", function () {
                            history.go(0);
                        });
                    } else {
                        mini.alert("删除失败！");
                    }
                });
            } else {
                return false;
            }
        }
    );
}



$(function () {
    $('.mini-tree-nodetitle').hover(function () {
        $(this).addClass('jq_mini_add');
    }, function () {
        $(this).removeClass('jq_mini_add');
    });

    $('#eidt').click(function () {


    })
    //上下移动
    var $tree = $('#tree1');

    var $up = $tree.find('div.up');
    var $down = $tree.find('div.down');

    //上移
    $up.click(function () {
        var $this = $(this);
        var _thisOrder = $this.attr('showorder');
        var _thisPcd = $this.attr('pcd');
        var _prevOrder = $this.parent().parent().parent().parent().parent().parent().prev().find('div.up').attr('showorder');
        var _prevPcd = $this.parent().parent().parent().parent().parent().parent().prev().find('div.up').attr('pcd');
        if (_prevOrder == undefined) {
            _prevOrder = $this.parent().parent().parent().parent().parent().parent().prev().find('div.dis-up').attr('showorder');
        }
        if (_prevPcd == undefined) {
            _prevPcd = $this.parent().parent().parent().parent().parent().parent().prev().find('div.dis-up').attr('pcd');
        }

        $.post('ajax/ajax.aspx?method=UpdateField', { Action: "post", id: _thisPcd, FName: 'ShowOrder', FVal: _prevOrder }, function () {
            $.post('ajax/ajax.aspx?method=UpdateField', { Action: "post", id: _prevPcd, FName: 'ShowOrder', FVal: _thisOrder }, function () {
                history.go(0);
            });
        });
    });
    //下移
    $down.click(function () {
        var $this = $(this);
        var _thisOrder = $this.attr('showorder');
        var _thisPcd = $this.attr('pcd');
        var _nextOrder = $this.parent().parent().parent().parent().parent().parent().next().find('div.up').attr('showorder');
        var _nextPcd = $this.parent().parent().parent().parent().parent().parent().next().find('div.up').attr('pcd');
        if (_nextOrder == undefined) {
            _nextOrder = $this.parent().parent().parent().parent().parent().parent().next().find('div.dis-up').attr('showorder');
        }
        if (_nextPcd == undefined) {
            _nextPcd = $this.parent().parent().parent().parent().parent().parent().next().find('div.dis-up').attr('pcd');
        }

        $.post('ajax/ajax.aspx?method=UpdateField', { Action: "post", id: _thisPcd, FName: 'ShowOrder', FVal: _nextOrder }, function () {
            $.post('ajax/ajax.aspx?method=UpdateField', { Action: "post", id: _nextPcd, FName: 'ShowOrder', FVal: _thisOrder }, function () {
                history.go(0);
            });
        });
    });
});