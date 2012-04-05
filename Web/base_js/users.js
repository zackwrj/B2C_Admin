$(function () {

    $("[vclass='page-1']").marsPage({
        pageTabs: "[vclass='rep-1']",
        hoverClass: "page-hover-class",
        clickClass: "page_click_class",
        hasBackTop: true,
        pageNum: 10
    });
    $("[vclass='page-2']").marsPage({
        pageTabs: "[vclass='rep-2']",
        hoverClass: "page-hover-class",
        clickClass: "page_click_class",
        hasBackTop: true,
        pageNum: 10
    });
    $("[vclass='page-3']").marsPage({
        pageTabs: "[vclass='rep-3']",
        hoverClass: "page-hover-class",
        clickClass: "page_click_class",
        hasBackTop: true,
        pageNum: 10
    });

    var $btnPhoto = $("div.x_user_right div.middle a,div.x_user_right div.middle img");
    var $showPhoto = $("div.show_update_photo");
    var $file = $("div.show_update_photo input[type='file']");
    var $updatephoto = $("div.show_update_photo samp .btn");
    var $closephoto = $("div.show_update_photo span a");
    var $falsephoto = $("div.show_update_photo samp .btnfalse");
    var $movephoto = $("div.show_update_photo");
    var $mask = $("#body-mask");
    $btnPhoto.click(function () {
        $mask.show();
        $showPhoto.css({ top: $(window).height() / 2 - $showPhoto.height() / 2, left: $(window).width() / 2 - $showPhoto.width() / 2 }).fadeIn(300);
    })

    $updatephoto.click(function () {
        $mask.show();
        $updatephoto.hide();
        $falsephoto.show();
    });

    $closephoto.click(function () {
        $mask.hide();
        $showPhoto.fadeOut(300);
    })
    $mask.width($(window).width()).height($(window).height());
    $(window).resize(function () {
        $mask.width($(window).width()).height($(window).height());
    })

    $movephoto.mousedown(function (evt) {
        var evt = evt || window.event;
        moveable = true;
        posy = evt.clientY - parseInt($(this).offset().top);
        posx = evt.clientX - parseInt($(this).offset().left);
        var _this = $(this);
        $("body").mousemove(function (evt) {
            if (moveable) {
                var evt = evt || window.event;
                _this.css({ left: evt.clientX - posx, top: evt.clientY - posy });
            }
        })
    });
    $movephoto.mouseup(function () {
        moveable = false;
    });

    var $edit = $("#UserInfoTable td a.edit");
    var $etext = $("#UserInfoTable td input");

    $edit.click(function () {
        $(this).parent().siblings().find("samp").hide();
        $(this).parent().siblings().find("input").show().focus();
    })

    //    $etext.blur(function () {
    //        $(this).siblings('samp').text($(this).val())
    //        $(this).hide().siblings('samp').show();
    //    })

    $("#u_left_nav dd").navMenu({
        className: "nav_dd_click",
        otherExecu: "$(this).eq(i).siblings('dt').addClass('nav_dt_click'); $(this).eq(i).show();$(this).eq(i).parent().find('dd').show();$(this).eq(i).parent().siblings().find('dd').hide();$(this).eq(i).parent().siblings().find('dt').removeClass('nav_dt_click')"
    });

    $("#u_left_nav dt").click(function () {
        $(this).addClass("nav_dt_click").siblings('dd').slideToggle(300);
        $(this).parent().siblings('dl').find('dd').slideUp(300);
        $(this).parent().siblings('dl').find('dt').removeClass('nav_dt_click');
    });

    $("#x_user_right_son_title li").navHover({
        becomeCase: "#u_bussiness_father",
        hoverClass: "li_click"
    })

    $("#wqvfi .save").inputMsg({
        msgWay: "right",
        msgAnimate: "show",
        succeedText: ""
    })
})