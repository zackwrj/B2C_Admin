<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpLoad.ascx.cs" Inherits="lv_B2C.Web.UpLoad" %>
<script>
    function GetControlName() {
        return "<%=ControlName%>";
    }
</script>
<script src="/Adminlvcn/1ref/controls/UpLoad/js/photo.js" type="text/javascript"></script>
<script type="text/javascript" src="/Adminlvcn/1ref/controls/UpLoad/UpLoad/swfupload/swfupload.js"></script>
<script type="text/javascript" src="/Adminlvcn/1ref/controls/UpLoad/js/handlers.js" charset="gb2312"></script>
<script src="/Adminlvcn/1ref/controls/UpLoad/UpLoad/swfupload/jquery-1.4.1.js" type="text/javascript"></script>
<link href="/Adminlvcn/1ref/controls/UpLoad/css/WebUpLoad.css" rel="stylesheet" type="text/css" />
<style>
.photo
{float:left; width:auto
    }
</style>
<script type="text/javascript">
    var swfu;
    window.onload = function () {
        swfu = new SWFUpload({
            // Backend Settings
            upload_url: "/Adminlvcn/1ref/controls/UpLoad/UpLoad/UpLoadFile.aspx?width=<%=ImageWidth%>&height=<%=ImageHeight%>&sessionStr=" + GetControlName(),   //ImageWidth  ImageHeight
            post_params: {
                "ASPSESSID": "<%=Session.SessionID %>"
            },

            // File Upload Settings
            file_size_limit: "<%=File_Size_Limit %>",   //"2 MB",
            file_types: "<%=File_Types %>", //"*.gif;*.jpg;*.jpeg;*.png;*.bmp;",
            file_types_description: "JPG Images",
            file_upload_limit: "<%=File_Upload_Limit%>", //"0",    // Zero means unlimited

            // Event Handler Settings - these functions as defined in Handlers.js
            //  The handlers are not part of SWFUpload but are part of my website and control how
            //  my website reacts to the SWFUpload events.
            file_queue_error_handler: fileQueueError,
            file_dialog_complete_handler: fileDialogComplete,
            upload_progress_handler: uploadProgress,
            upload_error_handler: uploadError,
            upload_success_handler: uploadSuccess,
            //upload_success_handler: alert("ggg"),
            upload_complete_handler: uploadComplete,

            // Button settings
            //	            button_image_url: "images/XPButtonNoText_160x22.png",
            //	            button_placeholder_id: "spanButtonPlaceholder",
            //	            button_width: 160,
            //	            button_height: 22,
            //	            button_text: '<span class="button">选择图片 <span class="buttonSmall">(最大2M)</span></span>',
            //	            button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
            //	            button_text_top_padding: 1,
            //              button_text_left_padding: 5,

            button_image_url: "/Adminlvcn/1ref/controls/UpLoad/Images/upload-button.png", // Relative to the Flash file
            button_width: "140",
            button_height: "40",
            button_placeholder_id: "spanButtonPlaceholder",
            button_text: '<span class="theFont">浏览</span>',
            button_text_style: ".theFont { font-size: 14px; font-weight: bold; text-align: center; color:#333333; }",
            button_text_left_padding: 1,
            button_text_top_padding: 5,

            // Flash Settings
            flash_url: "/Adminlvcn/1ref/controls/UpLoad/UpLoad/swfupload/swfupload.swf", // Relative to this file

            custom_settings: {
                upload_target: "divFileProgressContainer"
            },

            // Debug Settings
            debug: false
        });
    }

    $(function () {
        $("#cancle").click(function () {
            $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/Edit.ashx?sessionStr=" + GetControlName() + "&edit=alldelete", function (d) {
                if (d == "ok") {
                    $("#thumbnails").children().remove();
                }
                else {
                    alert(d);
                }
            })
        })
        $("#addImages").click(function () {
            //            if ($("#thumbnails .UploadDiv[check='1']").length < 1) {
            //                alert("请选择要上传的图片");
            //            }
            //            else {
            var $tempTry = true;
            $("#thumbnails .UploadDiv").each(function () {
                var id = $(this).attr("id");
                $.post("/Adminlvcn/1ref/controls/UpLoad/UpLoad/Edit.ashx?sessionStr=" + GetControlName() + "&edit=add&id=" + id, function (d) {
                    if (d > 0) {
                        $("#" + id).remove();
                        //alert(d);
                        //alert("上传成功");
                        //alert(ssss)
                        //swfu.cancelUpload();
                        $.getJSON("/Adminlvcn/1ref/controls/UpLoad/UpLoad/ImageView.ashx?type=view&id=" + d, function (d) {
                            //$("#afterUpload").append(GetLoadList(d.View[0].Title, d.View[0].URL, d.View[0].ImageID));
                            $("#afterUpload").append(CreateImageDiv(d.View[0].Title, d.View[0].URL, d.View[0].ImageID));
                        })

                    }
                    else {
                        $tempTry = false;
                        return false;
                        alert("上传失败！");
                        //alert(d)
                    }
                })
            })
            if ($tempTry == false) {
                $("#addImages").trigger("click");
            }
            //alert("1")
            //$("#swfu_container div:eq(0)").hide();
            //}
        })
        //全选/反选
        $("#checkAll").change(function () {
//            var thDivCount = $("#thumbnails .UploadDiv").length;
//            var thDivCountCheck = $("#thumbnails .UploadDiv[check='1']").length + 1;

            if (!$(this).hasClass("checked")) {
                $(this).addClass("checked");
                $("#thumbnails .UploadDiv").attr("check", "1");
                $("#thumbnails .UploadTop").each(function () {
                    $(this).find("span:eq(0)").find("img").css("visibility", "visible");
                })
                return;
            }
            $(this).removeClass('checked');
            $("#thumbnails .UploadDiv").attr("check", "0");
            $("#thumbnails .UploadTop").each(function () {
                $(this).find("span:eq(0)").find("img").css("visibility", "hidden");
            })

            //alert(thDivCountCheck)
//            if (!$(this).hasClass("checked")) {
//                $(this).addClass("checked");
//                $("#thumbnails .UploadDiv").attr("check", "1");
//                $("#thumbnails .UploadTop").each(function () {
//                    $(this).find("span:eq(0)").find("img").css("visibility", "visible");
//                })
//                return;
//            }
//            $(this).removeClass('checked');
//            $("#thumbnails .UploadDiv").attr("check", "0");
//            $("#thumbnails .UploadTop").each(function () {
//                $(this).find("span:eq(0)").find("img").css("visibility", "hidden");
//            })
        })
        //批量删除
        $("#deleteAll").click(function () {
            if ($("#thumbnails .UploadDiv[check='1']").length < 1) {
                alert("请选择要删除的图片！");
            }
            else {
                $("#thumbnails .UploadDiv").each(function () {
                    if ($(this).attr("check") == "1") {
                        $("#editCannelButton_" + $(this).attr("id")).trigger("click");
                    }
                })
            }
        })
        //批量编辑
        $("#editAll").click(function () {
            if ($("#thumbnails .UploadDiv[check='1']").length < 1) {
                alert("请选择要编辑的图片！");
            }
            else {
                $("#editAllTitle").css("visibility", "visible");
                $("#editAllTitle").focus();
            }
        })
        $("#editAllTitle").blur(function () {
            $("#thumbnails .UploadTitle").each(function () {
                if ($(this).parent().attr("check") == "1") {
                    $(this).trigger("click");
                    $(this).find("input").val($("#editAllTitle").val());
                    $(this).find("input").trigger("blur");
                }
            })
            $("#editAllTitle").val("");
            $("#editAllTitle").css("visibility", "hidden");
        })
    })

</script>
<div id="content">
    已上传
    <div id="afterUpload">
    </div>
    <br />
    <div id="swfu_container" style="margin: 0px 10px;">
        <div>
            <span id="spanButtonPlaceholder" style="float:left"></span>
            <span>
              <input type="button"  value="清空列表" id="cancle"
              style="font-size: 14px; font-weight: bold; text-align: center; color:#333333;
                   background-image:url('/Adminlvcn/1ref/controls/UpLoad/Images/upload-button.png'); width:140px; height:40px; padding-top:-50px"  />
            </span>
        </div>
        <div>
           <input type="checkbox" id="checkAll" />
           <label for="checkAll">全选</label>
           <span></span>
           <input type="button"  id="deleteAll" value="批量删除"/>
           <input type="button"  id="editAll" value="批量编辑"/>
          <%-- <a href="javascript:;" id="editAll">批量编辑</a>--%>
           <input type="text" id="editAllTitle"  style=" visibility:hidden"/>
        </div>
        <div>
            <input type="button"  value="确认上传" id="addImages"
              style="font-size: 14px; font-weight: bold; text-align: center; color:#333333;
                   background-image:url('/Adminlvcn/1ref/controls/UpLoad/Images/upload-button.png'); width:140px; height:40px;"  />
        </div>
       <%-- <div id="divFileProgressContainer" style="height: 75px;">
        </div>--%>
        <div id="thumbnails">
        </div>
        <br />
        

    </div>
</div>
