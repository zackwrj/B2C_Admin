/// <reference path="jquery-1.4.1-vsdoc.js" />

function CreateImageDiv(title,src,id) {

    var $UploadDiv = $("<div class='UploadDiv'></div>"); //总体
    var $UploadImage = $("<div class='UploadImage'></div>"); //图片内容
    var $UploadTop = $("<div class='UploadTop'></div>");  //操作
    var $UploadTopSpanLeft = $("<span class='l'></span>");
    //var $UploadTopImageCheck = $("<img src='/Adminlvcn/1ref/controls/UpLoad/Images/check.png' alt='选中' />");
    var $UploadTopSpanRight = $("<span class='r'></span>"); ;
    var $UploadTopImageClose = $("<img src='/Adminlvcn/1ref/controls/UpLoad/Images/close.png' alt='删除' />");
    var $Upload = $("<div class='Upload'></div>") //图片
    var $UploadImg;
    var $UploadTitle = $("<div class='UploadTitle'></div>"); //标题
    var $UploadTitleSpan = $("<span>" +title + "</span>");

    //属性
    $UploadDiv.attr("id", id); //cannel
    $UploadDiv.attr("check", "0");
    $UploadTopImageClose.attr("id", "editCannelButton_" +id);
    //$UploadTopImageCheck.css("visibility", "hidden");
    $UploadTopImageClose.css("visibility", "hidden");
    $UploadTitle.attr("id", "editTitle_" + id);

    //添加
    //$UploadTopSpanLeft.append($UploadTopImageCheck);
    $UploadTopSpanRight.append($UploadTopImageClose);
    $UploadTop.append($UploadTopSpanLeft);
    $UploadTop.append($UploadTopSpanRight);
    $Upload.append("<img src='"+src+"'>");
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
        if (confirm("你确定要删除吗？")) {
            $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/ImageView.ashx?type=delete&id=" + $UploadDiv.attr("id"), function (d) {
                alert(d);
                if (d == "删除成功")
                    $UploadDiv.empty().remove();
            })
        }
    })
    $UploadTitle.click(function () {
        var $temp = $("<span><input type='text' class='text'></span>");
        if ($UploadTitle.find("span input").length < 1) {
            $temp.find("input").bind("blur", function () {
                var $temps = $UploadTitle.find("span").find("input[type='text']").val();
                $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/ImageView.ashx?type=edit&title=" + $temps + "&id=" + $UploadDiv.attr("id"), function (d) {
                    if ($temps == "") {
                        $temps = "标题";
                    }
                    $UploadTitle.find("span").remove();
                    $UploadTitle.append("<span>" + $temps + "</span>");
                    //alert(d)
                    //$("#aa").append(d+"<br>");
                })
            })
            var ss = $UploadTitle.find("span").text();
            $temp.find("input").val(ss);
            $UploadTitle.find("span").remove();
            $UploadTitle.append($temp);
            $temp.find("input").select().focus();
            //setFocus($temp.find("input")[0]);
        }
    })
    //事件
    return $UploadDiv;
}
function myFocus(sel, start, end) {
    if (sel.setSelectionRange) {
        sel.focus();
        sel.setSelectionRange(start, end);
    }
    else if (sel.createTextRange) {
        var range = sel.createTextRange();
        range.collapse(true);
        range.moveEnd('character', end);
        range.moveStart('character', start);
        range.select();
    }
}
function setFocus(sel) {
    length = sel.value.length;
    myFocus(sel, length, length);
}

function GetLoadList(title,src,id) {
    var $UL = $("<ul after='"+id+"'></ul>");

    var $LiTitle = $("<li></li>");
    var $Li = $("<li></li>");
    var $LiImg = $("<li><img src='" + src + "'><li/>");
    var $ButDele = $("<input type='button' id='after_delete_'" + id + " value='删除'/>");
    var $ButEdit = $("<input type='button' id='after_edit_'" + id + " value='编辑'/>");
    var $ButEditText = $("<input type='text' id='after_editText_'"+id+" style='visibility:hidden'/>");

    $ButDele.click(function () {
        if (confirm("你确定要删除吗？")) {
            $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/ImageView.ashx?type=delete&id=" + id, function (d) {
                alert(d);
                if (d == "删除成功")
                    $UL.remove();
            })
        }
    })
    $ButEdit.click(function () {
        if ($ButEditText.css("visibility") == "hidden") {
            $ButEditText.css("visibility", "visible");
        }
        else {
            $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/ImageView.ashx?type=edit&title=" + $ButEditText.val() + "&id=" + id,
            function (d) {
                if (d == "修改成功") {
                    $LiTitle.text($ButEditText.val());
                    $ButEditText.css("visibility", "hidden").val("");
                }
            })

        }
    })
    $LiTitle.text(title);
    $Li.append($ButDele);
    $Li.append($ButEdit);
    $Li.append($ButEditText);
    $UL.append($LiTitle);
    $UL.append($LiImg);
    $UL.append($Li);
    return $UL;

}
