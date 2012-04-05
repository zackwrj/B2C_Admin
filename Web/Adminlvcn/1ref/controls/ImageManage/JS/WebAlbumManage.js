/// <reference path="../Scripts/jquery-1.4.1-vsdoc.js" />


function DireLoad() {
    $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=load", function (d) {
        $("#webImageDir").empty();
        $("#webImageDir").append(d);
    })
    
}
function ViewImage(JsonList) {
    //所有元素
    var $UploadDiv = $("<div class='UploadDiv'></div>"); //总体
    var $UploadImage = $("<div class='UploadImage'></div>"); //图片内容
    var $UploadTop = $("<div class='UploadTop'></div>");  //操作
    var $UploadTopSpanLeft = $("<span class='l'></span>");
    var $UploadTopImageCheck = $("<img src='/Adminlvcn/1ref/controls/ImageManage/Images/check.png' alt='选中' />");
    var $UploadTopSpanRight = $("<span class='r'></span>"); ;
    var $UploadTopImageClose = $("<img src='/Adminlvcn/1ref/controls/ImageManage/Images/close.png' alt='删除' />");
    var $Upload = $("<div class='Upload'></div>") //图片
    var $UploadImg = $("<img src='" + JsonList.URL + "' alt='" + JsonList.Title + "'>");
    var $UploadTitle = $("<div class='UploadTitle'></div>"); //标题
    var $UploadTitleSpan = $("<span>" + JsonList.Title + "</span>");
    //属性
    $UploadDiv.attr("id", JsonList.ImageID); //cannel
    $UploadDiv.attr("check", "0");
    $UploadTopImageClose.attr("id", "editCannelButton_" + JsonList.ImageID);
    $UploadTopImageCheck.css("visibility", "hidden");
    $UploadTopImageClose.css("visibility", "hidden");
    $UploadTitle.attr("id", "editTitle_" + JsonList.ImageID);
    $UploadTopSpanLeft.append($UploadTopImageCheck);
    $UploadTopSpanRight.append($UploadTopImageClose);
    $UploadTop.append($UploadTopSpanLeft);
    $UploadTop.append($UploadTopSpanRight);
    $Upload.append($UploadImg);
    $UploadImage.append($UploadTop);
    $UploadImage.append($Upload);
    $UploadTitle.append($UploadTitleSpan);
    $UploadDiv.append($UploadImage);
    $UploadDiv.append($UploadTitle);

    //事件
    $UploadImage.hover(function () {
        $UploadTopImageClose.css("visibility", "visible");
        $UploadImage.addClass("UploadImageHover");
    }, function () {
        $UploadTopImageClose.css("visibility", "hidden");
        $UploadImage.removeClass("UploadImageHover");
    }).click(function () {
        if ($UploadDiv.attr("check") == "0") {
            $UploadTopImageCheck.css("visibility", "visible");
            $UploadDiv.attr("check", "1");
        }
        else {
            $UploadTopImageCheck.css("visibility", "hidden");
            $UploadDiv.attr("check", "0");
        }
    })
    //删除
    $UploadTopImageClose.click(function () {
        $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?imagetype=delete&id=" + $UploadDiv.attr("id"), function (d) {
            if (d == "ok") {
                $UploadDiv.empty().remove();
            }
            else {
                alert("删除失败");
            }
        })
    })
    //编辑标题
    $UploadTitle.click(function () {
        var $temp = $("<span><input type='text'></span>");
        if ($UploadTitle.find("span input").length < 1) {
            $temp.find("input").bind("blur", function () {
                var $temps = $UploadTitle.find("span").find("input[type='text']").val();
                $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?imagetype=edit&id=" + $UploadDiv.attr("id") + "&title=" + $temps, function (d) {
                    if (d == "ok") {
                        if ($temps == "") {
                            $temps = "标题";
                        }
                        $UploadTitle.find("span").remove();
                        $UploadTitle.append("<span>" + $temps + "</span>");
                    }
                    else {
                        alert("修改标题失败");
                    }
                })
            })
            var ss = $UploadTitle.find("span").text();
            $temp.find("input").val(ss);
            $UploadTitle.find("span").remove();
            $UploadTitle.append($temp);
            $temp.find("input").select().focus();
        }
    })
    $UploadDiv.bind("moveDir", function () {
        $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?imagetype=move&id=" + $UploadDiv.attr("id") + "&album=" + $("#moveSelect").attr("ablum"), function (d) {
            if (d == "ok") {
                $UploadDiv.remove();
            }
            else {
                alert("移动失败！");
            }
        })
        //alert($("#moveSelect").attr("ablum"))
    })
    return $UploadDiv;
}
$(function () {
    DireLoad();


    //无目录相片
    $("#ImageDir").click(function () {
        $.getJSON("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=child&id=0",
        function (data) {
            $("#viewImage").empty();
            for (var i = 0; i < data.View.length; i++) {
                $("#viewImage").append(ViewImage(data.View[i]));
            }
        })
    })
    $("#ImageDir").trigger("click");
    //目录相片
    $("#webImageDir li").live("click", function () {
        $("#webImageDir li").removeClass("red").attr("check", "0");
        $(this).addClass("red").attr("check", "1");
        var tempID = $(this).attr("album");
        $.getJSON("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=child&id=" + tempID,
        function (data) {
            $("#viewImage").empty();
            for (var i = 0; i < data.View.length; i++) {
                $("#viewImage").append(ViewImage(data.View[i]));
            }
        })
        event.stopPropagation();
    })
    Right_Key();
    MoveDiv("editManage");
    //全选/反选
    $("#checkAll").change(function () {
        if (!$(this).hasClass("checked")) {
            $(this).addClass("checked");
            $("#viewImage .UploadDiv").attr("check", "1");
            $("#viewImage .UploadTop").each(function () {
                $(this).find("span:eq(0)").find("img").css("visibility", "visible");
            })
            return;
        }
        $(this).removeClass('checked');
        $("#viewImage .UploadDiv").attr("check", "0");
        $("#viewImage .UploadTop").each(function () {
            $(this).find("span:eq(0)").find("img").css("visibility", "hidden");
        })
    })
    //批量删除
    $("#deleteAll").click(function () {
        if ($("#viewImage .UploadDiv[check='1']").length < 1) {
            alert("请选择要删除的图片！");
        }
        else {
            $("#viewImage .UploadDiv").each(function () {
                if ($(this).attr("check") == "1") {
                    $("#editCannelButton_" + $(this).attr("id")).trigger("click");
                }
            })
        }
    })
    //批量编辑
    $("#editAll").click(function () {
        if ($("#viewImage .UploadDiv[check='1']").length < 1) {
            alert("请选择要编辑的图片！");
        }
        else {
            $("#editAllTitle").css("visibility", "visible");
            $("#editAllTitle").focus();
        }
    })
    $("#editAllTitle").blur(function () {
        $("#viewImage .UploadTitle").each(function () {
            if ($(this).parent().attr("check") == "1") {
                $(this).trigger("click");
                $(this).find("input").val($("#editAllTitle").val());
                $(this).find("input").trigger("blur");
            }
        })
        $("#editAllTitle").val("");
        $("#editAllTitle").css("visibility", "hidden");
    })
    //移动文件夹
    $("#moveView").click(function () {
        $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=load", function (d) {
            $("#moveSelect").css("visibility", "visible").empty();
            $("#moveSelect").append(d);
        })
    })
    //选择移动的文件夹
    $("#moveSelect li").live("click", (function () {
        $("#moveSelect").attr("ablum", $(this).attr("album"));
        $("#moveSelect li").removeClass("red");
        $(this).addClass("red");
    })
    )
    //批量移动
    $("#moveAll").click(function () {
        if ($("#viewImage .UploadDiv[check='1']").length < 1) {
            alert("请选择要移动的图片！"); return false;
        }
        if ($("#moveSelect").attr("ablum") == 0) {
            alert("请选择移动的文件夹！"); return false;
        }
        $("#viewImage .UploadDiv").each(function () {
            if ($(this).attr("check") == "1") {
                $(this).trigger("moveDir");
            }
        })
    })

})

function Right_Key() {
    var $MenuRoot = $("#MenuRoot"), $ManageDir = $("#ManageDir"), 
    $editManage = $("#editManage"), $imageManage = $("#imageManage");
     //根目录右键
    $("#ImageDir").mousedown(function (e) {
        if (e.which == 3) {
            $ManageDir.hide();
            $imageManage.hide();
            $MenuRoot.show().css({ top: e.pageY, left: e.pageX });
        }
    })
    //管理目录右键
    var $adbumID = 0;
    $("#webImageDir  li").live("mousedown", function (e) {
        if (e.which == 3) {
            $MenuRoot.hide();
            $imageManage.hide();
            $ManageDir.show().css({ top: e.pageY, left: e.pageX });
            //alert("ffg")
            $adbumID = $(this).attr("album");
            $("#editManage").attr("album", $adbumID);
            event.stopPropagation();
        }
    })
    $("body").bind("contextmenu", function (e) {
        return false;
    }).click(function () {
        $MenuRoot.hide();
        $ManageDir.hide();
        $imageManage.hide()
    })
    //添加根目录
    var $addRoot = $("#addRoot");
    $addRoot.click(function () {
        $editManage.css("visibility", "visible");
        Manage_show(0);
    })
    //添加子目录
    $("#addDir").click(function () {
        Manage_show(1);
        $editManage.css("visibility", "visible");
    })
    //编辑子目录
    $("#editDir").click(function () {
        Manage_show(2);
        $editManage.css("visibility", "visible");
        if ($("#editManage").attr("edit") == 2) {
            $.getJSON("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=view&id=" + $("#editManage").attr("album"), function (d) {
                $("#editManageText").val(d.View[0].Title);
            })
        }
    })
    //编辑目录
    Edit_Manage();
    //删除目录
    $("#deleteDir").click(function () {
        if (confirm("你确定要删除目录： " + $("#webImageDir li[album='" + $adbumID + "']").text() + " 吗？")) {
            $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=delete&id=" + $adbumID, function (d) {
                alert(d);DireLoad();
            })
        }
    })
    //图片右键
    $("#viewImage .UploadDiv").live("mousedown", function (e) {
        if (e.which == 3) {
            $MenuRoot.hide();
            $ManageDir.hide();
            $imageManage.show().css({ top: e.pageY, left: e.pageX });
            $imageManage.attr("image",$(this).attr("id"))
            event.stopPropagation();
        }
    })
    $("#imageManage_Select").click(function () {
        $("#viewImage .UploadDiv[id='" + $imageManage.attr("image") + "']").find(".UploadImage").trigger("click");
    })
    $("#imageManage_Delete").click(function () {
        $("#viewImage .UploadDiv[id='" + $imageManage.attr("image") + "']").find("img[alt='删除']").trigger("click");
    })
    $("#imageManage_Edit").click(function () {
        $("#viewImage .UploadDiv[id='" + $imageManage.attr("image") + "']").find(".UploadTitle").trigger("click");
    })
}
//移动编辑、添加子类Div
function MoveDiv(id) {
    $("#" + id + "").find("div:eq(0)").mousedown(function (event) {
        $("#" + id + "").css("cursor", "move");
        var _offset = $("#" + id + "").offset();
        x1 = event.clientX - _offset.left;
        y1 = event.clientY - _offset.top;
        var witchButton = false;
        if (document.all && event.button == 1) { witchButton = true; }
        else { if (event.button == 0) witchButton = true; }
        if (witchButton)//按左键,FF是0，IE是1
        {
            $(document).mousemove(function (event) {
                $("#" + id + "").css("left", (event.clientX - x1) + "px");
                $("#" + id + "").css("top", (event.clientY - y1) + "px");
            })
        }
    })
    $("#" + id + "").find("div:eq(0)").mouseup(function () {
        $("#" + id + "").css("cursor", "");
        $(document).unbind("mousemove");
    })
}
//退出编辑
function Manage_hide() {
    $("#editManage").find("input[type='text']").val("");
    $("#editManage").css("visibility", "hidden").attr("edit","-1");
}
//进入编辑  0为添加根目录 1添加目录 2 修改目录
function Manage_show(index) { 
    var tempTitle = $("#editManage").find("div:eq(0)").children("h5 span:eq(0)");
    switch (index) {
        case 0:
            tempTitle.text("添加根目录");
            break;
        case 1:
            tempTitle.text("添加目录");
            break;
        case 2:
            tempTitle.text("修改目录");
            break;
    }
    $("#editManage").css("visibility", "visible").attr("edit", index);
}
//编辑目录
function Edit_Manage() {
    var $editManageRes = $("#editManageRes");
    var $editManageBut = $("#editManageBut");
    var $editManageText = $("#editManageText");
    var $editManage=$("#editManage");
    //重置
    $editManageRes.click(function () {
        $("#editManage").find("input[type='text']").val("");
    })
    //添加 0为添加根目录 1添加目录 2 修改目录
    $("#editManageBut").click(function () {
        if ($editManageText.val() == "") {
            alert("请填写目录名称！");
            return false;
        }
        if ($editManage.attr("edit") == 0) {
            $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=edit&id=0&title=" + $editManageText.val(),
            function (d) {
                $("#editManage").find("input[type='text']").val("");
                $("#editManage").css("visibility", "hidden");
                
                alert(d);DireLoad();
            })
            return false;
        }
        $.get("/Adminlvcn/1ref/controls/ImageManage/WebAlbumManage.ashx?type=edit&adbumID=" + $editManage.attr("album") + "&id=" + $editManage.attr("edit") + "&title=" + $editManageText.val(),
            function (d) {
                $("#editManage").find("input[type='text']").val("");
                $("#editManage").css("visibility", "hidden");
                
                alert(d);DireLoad();
        })
    })
}