/// <reference path="jquery-1.4.1-vsdoc.js" />

function DireLoad() {
    $.get("/Adminlvcn/1ref/controls/UpLoad/WebUpLoad/WebUp.ashx?type=load", function (d) {
        $("#webImageDir").append(d);
    })
}
function ViewImage(JsonList) {
    //所有元素
    var $UploadDiv = $("<div class='UploadDiv'></div>"); //总体
    var $UploadImage = $("<div class='UploadImage'></div>"); //图片内容
    var $UploadTop = $("<div class='UploadTop'></div>");  //操作
    var $UploadTopSpanLeft = $("<span class='l'></span>");
    var $UploadTopImageCheck = $("<img src='/Adminlvcn/1ref/controls/UpLoad/Images/check.png' alt='选中' />");
    var $UploadTopSpanRight = $("<span class='r'></span>"); ;
    var $UploadTopImageClose = $("<img src='/Adminlvcn/1ref/controls/UpLoad/Images/close.png' alt='删除' />");
    var $Upload = $("<div class='Upload'></div>") //图片
    var $UploadImg = $("<img src='" + JsonList.URL + "' alt='"+JsonList.Title+"'>");
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
    }, function () {
        $UploadTopImageClose.css("visibility", "hidden");
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
    return $UploadDiv;
}
$(function () {
    DireLoad();
    //$("#webImageDir ul:gt(0)").remove();
    $("#webImageDir li").live("click", function () {
        $("#webImageDir li").removeClass("red").attr("check", "0");
        $(this).addClass("red").attr("check", "1");
        var tempID = $(this).attr("album");
        $.getJSON("/Adminlvcn/1ref/controls/UpLoad/WebUpLoad/WebUp.ashx?type=child&id=" + tempID,
        function (data) {
            $("#viewImage").empty();
            for (var i = 0; i < data.View.length; i++) {
                $("#viewImage").append(ViewImage(data.View[i]));
            }
        })
        event.stopPropagation();
    })
    $("#ViewPhoto").contextMenu({
        menuId: "contextMenu",
        onContextMenuItemSelected: function (menuItemId, $triggerElement) {
            //alert('trigger1' + menuItemId + ' ' + $triggerElement.attr('id'))
            //alert(menuItemId)
            switch (menuItemId) {
                case "addDir":
                    //alert($triggerElement.find("li").attr("album"));
                    if ($triggerElement.find("li[check='1']").length < 0) {
                        alert("请选择目录！");
                    }
                    break;
            }
        },
        onContextMenuShow: function ($triggerElement) {
            //alert('trigger1' + $triggerElement.attr('id'))
            alert("120d")
            if ($triggerElement.find("li[check='1']").length < 0) {
                alert("请选择目录！");
            }
        },
        showShadow: false
    });

    $("#delete").click(function () { alert("14") })
//    var ss = "";
//    ss.substr(0, ss.length - 4);
})