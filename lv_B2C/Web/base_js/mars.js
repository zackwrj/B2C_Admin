
$(function () {

    $.fn.navHover = function (options) {
        var opts = $.extend({}, $.fn.navHover.defaults, options); //通用
        //默认第一个添加样式
        $(this).parent().find("li:first").addClass(opts.hoverClass);

        //默认第一项目显示，其它隐藏
        $(opts.becomeCase).children().hide();
        $(opts.becomeCase).children().first().show();

        //给this一个索引
        $(this).parent().find("li").each(function (i) {
            $(this).data("data", { index: i });
        })
        if (opts.eventType == "click") {
            $(this).click(function () {
                $(this).parent().find("li").removeClass(opts.hoverClass);
                $(this).addClass(opts.hoverClass);
                $(opts.becomeCase).children().hide();
                $(opts.becomeCase).children().eq($(this).data("data").index).show();
            })
        } else {
            $(this).hover(function () {
                $(this).parent().find("li").removeClass(opts.hoverClass);
                $(this).addClass(opts.hoverClass);
                $(opts.becomeCase).children().hide();
                $(opts.becomeCase).children().eq($(this).data("data").index).show();
            })
        }
    };
    //格式通用
    $.fn.navHover.defaults = {
        becomeCase: "",   //被操作项的父级容器
        hoverClass: "",   //this添加的样式
        eventType: ""     //事件类型
    };
    //通用
    $.fn.navHover.setDefaults = function (settings) {
        $.extend($.fn.navHover.defaults, settings);
    };
});

//首先，导入下面这
//调用方法：$("[vclass='menu'] li").navMenu({ className: "nav_click" });
//$("[vclass='menu'] li")为需要添加样式的对像,className为需要添加的样式
$(function () {
    $.fn.navMenu = function (options) {
        var opts = $.extend({}, $.fn.navMenu.defaults, options); //通用
        var _location = location.toString();
        var _pagename = _location.substr(_location.lastIndexOf('/') + 1, _location.length);
        var _name = _pagename.substr(0, _pagename.indexOf('.'));
        for (var i = 0; i < $(this).length; i++) {
            var _href = $(this).eq(i).find('a').attr('href');
            var _aname = _href.substr(_href.lastIndexOf('/') + 1, _href.length);
            var _link = _aname.substr(0, _aname.indexOf('.'));
            if (_link == _name) {
                $(this).eq(i).addClass(opts.className);
                if (opts.otherExecu != "") {
                    eval(opts.otherExecu);
                }
                break;
            }
            else if (_name == "") {
                $(this).eq(0).addClass(opts.className);
                break;
            }
        }
        $(this).click(function () { $(this).addClass(opts.className); });
    };
    //格式通用
    $.fn.navMenu.defaults = {
        className: "",   //this添加的样式
        otherExecu: ""    //执行其它语句
    };
    //通用
    $.fn.navMenu.setDefaults = function (settings) {
        $.extend($.fn.navMenu.defaults, settings);
    };
});