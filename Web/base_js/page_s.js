//分页
$(function () {
    //默认样式
    var liClass = { "width": "18px", "height": "18px", "line-height": "18px", "border": "1px solid gray", "float": "left", "text-align": "center", "margin-right": "2px", "margin-left": "2px" ,"margin-top":"8px"};
    var ulClass = { "padding": "0", "margin": "0" };
    var hovCss = { "color": "red", "background": "#eee" };
    var outCss = { "color": "", "background": "" };
    var cliCss = { "color": "blue", "background": "#ccc" };
    var upCss = { "color": "", "background": "" };

    $.fn.marsPage = function (options) {
        var opts = $.extend({}, $.fn.marsPage.defaults, options); //通用
        var _count = $(opts.pageTabs).children().length; //总条数
        var _span = "<span style='float:left'>...</span>";

        var pageMax = 0;
        if (_count % opts.pageNum == 0) pageMax = _count / opts.pageNum;
        else pageMax = parseInt(_count / opts.pageNum) + 1;

        //分页按钮添加到this
        var $htmlBtn = "";
        if (opts.hasBackTop) {
            for (var i = 0; i < pageMax; i++) {
                $htmlBtn += '<a href="#" name="' + i + '" class="libtn">' + parseInt(i + 1) + '</a>';
            }
        } else {
            for (var i = 0; i < pageMax; i++) {
                $htmlBtn += '<a name="' + i + '" class="libtn">' + parseInt(i + 1) + '</a>';
            }
        }
        $(this).html($htmlBtn);

        if (opts.clickClass != "") {
            $(this).find("a:first").addClass(opts.clickClass);
        } else {
            $(this).find("a:first").css(cliCss);
        }

        //给每条数据索引
        $(opts.pageTabs).children().each(function (i) {
            $(this).data("data", { index: i });
        })
        //给分页按钮索引
        $(this).children().each(function (i) {
            $(this).data("data", { index: i });
        })

        //只显示0-PageNum条数据
        $(opts.pageTabs).children().hide();
        for (var i = 0; i < opts.pageNum; i++) {
            $(opts.pageTabs).children().eq(i).show();
        }

        //只显示1-showBtnCount个按钮
        $(this).find("a").hide();
        for (var i = 0; i < 5; i++) {
            $(this).children().eq(i).show();
        }
        $(this).children().eq(pageMax - 1).show();
        $(this).children().eq(4).after(_span);

        //添加上一页、下一页按钮
        if (opts.hasBackTop) {
            $(this).children().first().before("<a href='#' style='width:50px' title='上一页'>上一页</a>");
            $(this).children().last().after("<a href='#' style='width:50px' title='下一页'>下一页</a>");
        }
        else {
            $(this).children().first().before("<a style='width:50px' title='上一页'>上一页</a>");
            $(this).children().last().after("<a style='width:50px' title='下一页'>下一页</a>");
        }
        $(this).after("<input style='display:none;width:30px' type='text' value='1' id='js_temp'>");
        if (opts.isNOjump) $("#js_temp").show();

        if (opts.defClass == 0 || opts.defClass == 1) {
            $(this).css(ulClass);
            $(this).find("a").css(liClass);
            $(this).find("a[title='上一页']").width(50);
            $(this).find("a[title='下一页']").width(50);
        }

        //悬浮按钮
        $(this).find("a.libtn").live('mouseover', function () {
            if (opts.hoverClass == "") {
                if ($(this).css("color") != "blue") {
                    $(this).css(hovCss);
                }
            } else {
                $(this).addClass(opts.hoverClass)
            }
        });
        $(this).find("a.libtn").live('mouseout', function () {
            if (opts.hoverClass == "") {
                if ($(this).css("color") != "blue") {
                    $(this).css(outCss);
                }
            } else {
                $(this).removeClass(opts.hoverClass)
            }
        });


        //点击按钮
        $(this).find("a.libtn").live('click', function () {
            var $thisIndex = $(this).data("data").index;
            $("#js_temp").val($thisIndex + 1);      //把当前按钮的索引赋值给temp
            if (opts.clickClass == "") {
                $(this).parent().children().css(upCss);  //移除点击后的样式
                $(this).css(cliCss);  //添加点击后的样式
            } else {
                $(this).parent().children().removeClass(opts.clickClass);  //移除点击后的样式
                $(this).addClass(opts.clickClass);  //添加点击后的样式
            }
            $(opts.pageTabs).children().hide(); //先隐藏掉所有数据
            //再显示当页数据           
            for (var i = 0; i < _count; i++) {
                if (i >= $thisIndex * opts.pageNum && i < ($thisIndex + 1) * opts.pageNum) {
                    $(opts.pageTabs).children().eq(i).show();
                }
            }
            showBtn(this, 1, pageMax, _span, 0);
        })

        //点击上一页
        $(this).find("a[title='上一页']").live('click', function () {
            var $pageIndex = parseInt($("#js_temp").val()) - 1; //当前页索引
            if ($pageIndex > 0) {
                var $prevNum = parseInt($pageIndex) - 1;
                //给当前页码的上一页添加样式
                if (opts.clickClass != "") {
                    $(this).parent().children().removeClass(opts.clickClass);
                    $(this).parent().find("a[name='" + $prevNum + "']").addClass(opts.clickClass);
                }
                else {
                    $(this).parent().children().css(upCss);  //移除点击后的样式
                    $(this).parent().find("a[name='" + $prevNum + "']").css(cliCss);  //添加点击后的样式
                }
                //换掉temp的值
                $("#js_temp").val($prevNum + 1);

                //显示上一页数据
                $(opts.pageTabs).children().hide();
                for (var i = 0; i < _count; i++) {
                    if (i >= $prevNum * opts.pageNum && i < ($prevNum + 1) * opts.pageNum) {
                        $(opts.pageTabs).children().eq(i).show();
                    }
                }

                showBtn(this, 2, pageMax, _span, $prevNum);
            }
        })

        //点击下一页
        $(this).find("a[title='下一页']").live('click', function () {
            var $pageIndex = parseInt($("#js_temp").val()) - 1; //当前页索引
            if ($pageIndex < pageMax - 1) {
                var $nextNum = parseInt($pageIndex) + 1;
                //给当前页码的下一页添加样式
                if (opts.clickClass != "") {
                    $(this).parent().children().removeClass(opts.clickClass);
                    $(this).parent().find("a[name='" + $nextNum + "']").addClass(opts.clickClass);
                }
                else {
                    $(this).parent().children().css(upCss);  //移除点击后的样式
                    $(this).parent().find("a[name='" + $nextNum + "']").css(cliCss);  //添加点击后的样式
                }
                //换掉temp的值
                $("#js_temp").val($nextNum + 1);

                //显示下一页数据
                $(opts.pageTabs).children().hide();
                for (var i = 0; i < _count; i++) {
                    if (i >= $nextNum * opts.pageNum && i < ($nextNum + 1) * opts.pageNum) {
                        $(opts.pageTabs).children().eq(i).show();
                    }
                }
                showBtn(this, 2, pageMax, _span, $nextNum);
            }
        })

        //跳转
        $('#js_temp').live('keydown', function (event) {
            if (event.keyCode == 13) {
                var $pageIndex = parseInt($("#js_temp").val()) - 1; //当前页索引
                if ($pageIndex < pageMax && $pageIndex >= 0) {
                    //给当前页码添加样式
                    $(this).prev().children().removeClass(opts.clickClass);
                    $(this).prev().find("a[name='" + $pageIndex + "']").addClass(opts.clickClass);
                    //显示本页数据
                    $(opts.pageTabs).children().hide();
                    for (var i = 0; i < _count; i++) {
                        if (i >= $pageIndex * opts.pageNum && i < ($pageIndex + 1) * opts.pageNum) {
                            $(opts.pageTabs).children().eq(i).show();
                        }
                    }
                    showBtn(this, 3, pageMax, _span, $pageIndex);
                }
            }
        })

        $('#js_temp').live('mouseover', function () {
            $(this).focus();
            $(this).select();
        })

        $(this).children().css("cursor", "pointer");
    };

    function showBtn(val, types, pageMax, _span, pagEq) {
        var $this = null;
        if (types == 1) {
            $this = $(val)
        }
        else if (types == 2) {
            $this = $(val).parent().find("a").eq(pagEq + 1);
        }
        else if (types == 3) {
            $this = $(val).prev().find("a").eq(pagEq + 1);
        }
        if ($this.next("span").text() == "...") {
            $this.parent().find("span").remove();
            $this.next().show();
            $this.next().next().show();
            $this.next().next().next().show();
            if ($this.next().next().next().next().text() < pageMax) {
                $this.next().next().next().after(_span);
            }
            $this.prev().prev().hide();
            $this.prev().prev().prev().hide();
            if ($this.prev().prev().prev().prev().text() != "1") {
                $this.prev().prev().prev().prev().hide();
            }
            $this.prev().before(_span);

        }
        else if ($this.prev().text() == "...") {
            $this.parent().find("span").remove();
            $this.prev().show();
            $this.prev().prev().show();
            $this.prev().prev().prev().show();
            if ($this.prev().prev().prev().text() > 1) {
                $this.prev().prev().prev().before(_span);
            }
            $this.next().next().hide();
            $this.next().next().next().hide();
            if ($this.next().next().next().next().text() < pageMax) {
                $this.next().next().next().next().hide();
            }
            $this.next().after(_span);
        }
        if ($this.text() == "1") {
            $this.parent().find("a").hide();
            $this.parent().find("span").remove();
            $this.show();
            $this.next().show();
            $this.next().next().show();
            $this.next().next().next().show();
            $this.next().next().next().next().show();
            $this.parent().find("a").eq(pageMax).show();
            $this.parent().find("a[title='下一页']").show();
            $this.parent().find("a[title='上一页']").show();
            $this.parent().find("a").eq(5).after(_span);
        }
        if ($this.text() == pageMax) {
            $this.parent().find("a").hide();
            $this.parent().find("span").remove();
            $this.show();
            $this.prev().show();
            $this.prev().prev().show();
            $this.prev().prev().prev().show();
            $this.prev().prev().prev().prev().show();
            $this.parent().find("a").eq(1).show();
            $this.parent().find("a[title='下一页']").show();
            $this.parent().find("a[title='上一页']").show();
            $this.prev().prev().prev().prev().before(_span);
        }

    }

    function _show() {

    }

    //格式通用
    $.fn.marsPage.defaults = {
        pageTabs: "",     //被分页项的父级容器
        hoverClass: "",   //this添加的样式
        clickClass: "",   //点击后的样式
        pageNum: 5,       //每页条数
        isNOjump: false,  //是否显示跳转框
        defClass: 0,       //0为默认样式，1为用自己写的样式
        hasBackTop: false
    };
    //通用
    $.fn.marsPage.setDefaults = function (settings) {
        $.extend($.fn.marsPage.defaults, settings);
    };

})
