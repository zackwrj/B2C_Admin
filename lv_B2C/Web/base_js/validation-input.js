
jQuery.fn.extend({
    everyTime: function (interval, label, fn, times) {
        return this.each(function () {
            jQuery.timer.add(this, interval, label, fn, times);
        });
    },
    oneTime: function (interval, label, fn) {
        return this.each(function () {
            jQuery.timer.add(this, interval, label, fn, 1);
        });
    },
    stopTime: function (label, fn) {
        return this.each(function () {
            jQuery.timer.remove(this, label, fn);
        });
    }
});

jQuery.extend({
    timer: {
        global: [],
        guid: 1,
        dataKey: "jQuery.timer",
        regex: /^([0-9]+(?:\.[0-9]*)?)\s*(.*s)?$/,
        powers: {
            'ms': 1,
            'cs': 10,
            'ds': 100,
            's': 1000,
            'das': 10000,
            'hs': 100000,
            'ks': 1000000
        },
        timeParse: function (value) {
            if (value == undefined || value == null)
                return null;
            var result = this.regex.exec(jQuery.trim(value.toString()));
            if (result[2]) {
                var num = parseFloat(result[1]);
                var mult = this.powers[result[2]] || 1;
                return num * mult;
            } else {
                return value;
            }
        },
        add: function (element, interval, label, fn, times) {
            var counter = 0;

            if (jQuery.isFunction(label)) {
                if (!times)
                    times = fn;
                fn = label;
                label = interval;
            }

            interval = jQuery.timer.timeParse(interval);

            if (typeof interval != 'number' || isNaN(interval) || interval < 0)
                return;

            if (typeof times != 'number' || isNaN(times) || times < 0)
                times = 0;

            times = times || 0;

            var timers = jQuery.data(element, this.dataKey) || jQuery.data(element, this.dataKey, {});

            if (!timers[label])
                timers[label] = {};

            fn.timerID = fn.timerID || this.guid++;

            var handler = function () {
                if ((++counter > times && times !== 0) || fn.call(element, counter) === false)
                    jQuery.timer.remove(element, label, fn);
            };

            handler.timerID = fn.timerID;

            if (!timers[label][fn.timerID])
                timers[label][fn.timerID] = window.setInterval(handler, interval);

            this.global.push(element);

        },
        remove: function (element, label, fn) {
            var timers = jQuery.data(element, this.dataKey), ret;

            if (timers) {

                if (!label) {
                    for (label in timers)
                        this.remove(element, label, fn);
                } else if (timers[label]) {
                    if (fn) {
                        if (fn.timerID) {
                            window.clearInterval(timers[label][fn.timerID]);
                            delete timers[label][fn.timerID];
                        }
                    } else {
                        for (var fn in timers[label]) {
                            window.clearInterval(timers[label][fn]);
                            delete timers[label][fn];
                        }
                    }

                    for (ret in timers[label]) break;
                    if (!ret) {
                        ret = null;
                        delete timers[label];
                    }
                }

                for (ret in timers) break;
                if (!ret)
                    jQuery.removeData(element, this.dataKey);
            }
        }
    }
});

jQuery(window).bind("unload", function () {
    jQuery.each(jQuery.timer.global, function (index, item) {
        jQuery.timer.remove(item);
    });
});


$(function () {
    $.fn.inputMsg = function (options) {
        var opts = $.extend({}, $.fn.inputMsg.defaults, options);
        var msgcss = "position:absolute;border:1px solid gray;height:16px;width:auto;text-align:center;font-size:12px;background-color:#fff;line-height:16px;padding:2px;display:none;z-index:-9999;";
        var msghtml = '';
        if (opts.msgClass != "") msghtml = '<div msgDiv="msgDiv" class="' + opts.msgClass + '" style="position:absolute;display:none;z-index:-9999;" ></div>';
        else msghtml = '<div msgDiv="msgDiv" style="' + msgcss + '" ></div>';
        var arr = new Array();
        var warnArr = new Array();
        var errorArr = new Array();
        var lengthArr = new Array();
        var regexArr = new Array();
        var definedWarnArr = new Array();
        var definedRegArr = new Array();
        var definedNameArr = new Array();
        var definedErrorArr = new Array();
        $("*[vtype^='data-']").each(function (i) {
            $(this).data("data", { index: i });
            if ($(this).attr('ismust') != 'false') {
                arr[i] = $(this).attr('vtype');
            }
            if ($(this).attr('vdefinedname') != "" && $(this).attr('vdefinedname') != undefined) {
                definedWarnArr[i] = ($(this).attr('vtext') != '') ? $(this).attr('vtext') : "不能为空";
                definedRegArr[i] = ($(this).attr('vregexmsg') != '') ? $(this).attr('vregexmsg') : "输入不合法";
                definedNameArr[i] = ($(this).attr('vdefinedname') != '') ? $(this).attr('vdefinedname') : "此信息";
            }
            else {
                definedWarnArr[i] = '*'; definedRegArr[i] = '*'; definedNameArr[i] = '*';
            }
        });
        $("*[vtype='data-name']").blur(function () {
            blurNull($(this), warnArr[$(this).attr('vtype')])
            blurLength($(this), 4, 16, lengthArr[$(this).attr('vtype')])
            blurRegex($(this), regexArr[$(this).attr('vtype')], '^[A-Za-z0-9_]+$');
        });
        $("*[vtype='data-pwd']").blur(function () {
            if (blurNull($(this), warnArr[$(this).attr('vtype')])) { blurNull($(this), warnArr[$(this).attr('vtype')]) }
            else if (blurLength($(this), 4, 0, lengthArr[$(this).attr('vtype')])) { blurLength($(this), 4, 0, lengthArr[$(this).attr('vtype')]) }
        });
        $("*[vtype='data-rpwd']").blur(function () {
            if (blurNull($(this), warnArr[$(this).attr('vtype')])) {
                blurNull($(this), warnArr[$(this).attr('vtype')])
            }
            else if ($(this).val() != $("*[vtype='data-pwd']").val()) {
                action($(this), regexArr[$(this).attr('vtype')], 'rpwd');
            }
            else {
                removeaction($(this));
            }
        });
        $("*[vtype='data-email']").blur(function () {
            if (blurNull($(this), warnArr[$(this).attr('vtype')])) { blurNull($(this), warnArr[$(this).attr('vtype')]) }
            else { blurRegex($(this), regexArr[$(this).attr('vtype')], '^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$'); }
        });
        $("*[vtype='data-phone']").blur(function () {
            if ($(this).attr('ismust') == 'false') {
                if ($(this).val() != "") { blurRegex($(this), regexArr[$(this).attr('vtype')], '^13\d{9}$'); }
                else { removeaction($(this)); }
            } else {
                if (blurNull($(this), warnArr[$(this).attr('vtype')])) blurNull($(this), warnArr[$(this).attr('vtype')])
                else blurRegex($(this), regexArr[$(this).attr('vtype')], '^[1-9]\d{0,2}-0\d{1,4}-\d{8,9}$');
            }
        });
        $("*[vtype='data-number']").blur(function () {
            valblur($(this), '^[0-9]')
        });
        $("*[vtype='data-defined']").blur(function () {
            if ($(this).attr('ismust') == 'true') {
                if (blurNull($(this), definedWarnArr[$(this).data('data').index])) { blurNull($(this), definedWarnArr[$(this).data('data').index]) }
                else if (blurLength($(this), 4, 20, definedNameArr[$(this).data('data').index])) { blurLength($(this), 4, 20, definedNameArr[$(this).data('data').index]) }
                else { blurRegex($(this), regexArr[$(this).attr('vtype')], '.*'); }
            }
            else if ($(this).val() != "") {
                if (blurLength($(this), 4, 20, definedNameArr[$(this).data('data').index])) { blurLength($(this), 4, 20, definedNameArr[$(this).data('data').index]) }
                else { blurRegex($(this), definedRegArr[$(this).data('data').index], '.*') }
            }
            else {
                removeaction($(this));
            }
        });
        $(this).click(function () {
            if (arr != "") {
                returnfalse();
                return false;
            }
            else {
                if (opts.succeedText != "") { alert(opts.succeedText); }
                return true;
            }
        });
        function valblur(val, regexps) {
            if (val.attr('ismust') == 'false') {
                if (val.val() != "") { blurRegex(val, regexArr[val.attr('vtype')], regexps); }
                else { removeaction(val); }
            } else {
                if (blurNull(val, warnArr[val.attr('vtype')])) { blurNull(val, warnArr[val.attr('vtype')]) }
                else { blurRegex(val, regexArr[val.attr('vtype')], regexps); }
            }
        }
        function blurNull(val, mustmsg) {
            if (val.val() == "") action(val, mustmsg, null);
            return (val.val() == "");
        }
        function blurLength(val, min, max, mustmsg) {
            if (val.val().length > 0) {
                var clength = val.attr('vlength');
                if (clength != "" && clength != undefined) {
                    if (clength.split('-').length > 1) {
                        max = parseInt(clength.split('-')[1]);
                        min = parseInt(clength.split('-')[0]);
                    }
                    else if (clength.split('-').length == 1) {
                        min = parseInt(clength.split('-')[0]);
                        max = 0;
                    }
                }
                if (max != 0) {
                    if (val.val().length < min || val.val().length > max) {
                        action(val, mustmsg + '长度为' + min + '-' + max + '位', 'length');
                    }
                    else {
                        removeaction(val);
                    }
                    return (val.val().length < min || val.val().length > max);
                }
                else {
                    if (val.val().length < min) {
                        action(val, mustmsg + '长度不能小于' + min + '位', 'length');
                    }
                    else {
                        removeaction(val);
                    }
                    return (val.val().length < min)
                }
            }
            else {
                return false;
            }
        }
        function blurAjaxCheckedUsername(val) {
            var _url = val.attr('vcheckednameurl');
            var _returnval = val.attr('vreturnval');
            var _val = val.val();
            var _thisret = "no";
            if (_url != "" && _url != undefined && _url != null) {
                $.post(_url, { Action: "post", UserName: _val }, function (data) {
                    if (_returnval != "" && _returnval != undefined && _returnval != null) _thisret = _returnval;
                    if (data == "no") action(val, "用户名已在", 'checked');
                })
            }
        }
        function blurRegex(val, mustmsg, reg) {
            if (val.val().length > 0) {
                var vreg = val.attr('vregex');
                var vregmsg = val.attr('vregexmsg');
                var tmsg = mustmsg;
                if (vreg != "" && vreg != undefined) { reg = vreg; }
                if (vregmsg != "" && vregmsg != undefined) { tmsg = val.attr('vregexmsg'); }
                var regexp = new RegExp(reg);
                if (!regexp.test(val.val().toString())) { action(val, tmsg, 'regex'); } else { removeaction(val); }
            }
            else {
                return false;
            }
        }
        function action(val, thismsg, types) {
            val.parent().find("*[msgDiv='msgDiv']").remove();
            val.parent().append(msghtml);
            var $animate = val.siblings("*[msgDiv='msgDiv']");
            var _msgText = thismsg;
            if (val.attr('vtext') != "" && val.attr('vtext') != undefined && types == null) {
                _msgText = val.attr('vtext');
            }
            addtoerrorArr(val);
            errorArr[val.attr('vtype')] = _msgText;
            $animate.css({ top: val.offset().top, left: val.offset().left, zIndex: -9999 }).html(_msgText);
            var _wid = opts.msgInputSpace;
            var _css = { left: val.offset().left + val.width() + _wid };
            switch (opts.msgWay) {
                case "top": _css = { top: val.offset().top - val.height() - _wid }; break;
                case "bottom": _css = { top: val.offset().top + val.height() + _wid }; break;
                case "left": _css = { left: val.offset().left - $animate.width() - _wid }; break;
                case "right": _css = { left: val.offset().left + val.width() + _wid }; break;
                default: _css = { left: val.offset().left + val.width() + _wid }; break;
            }
            switch (opts.msgAnimate) {
                case "animate": $animate.show().animate(_css, 300, function () { $animate.css({ zIndex: 9999 }) }); break;
                case "fade": $animate.css(_css).fadeIn(300, function () { $animate.css({ zIndex: 9999 }) }); break;
                case "show": $animate.css(_css).show().css({ zIndex: 9999 }); break;
                default: $animate.css(_css).show().css({ zIndex: 9999 }); break;
            }
            glint(val);
        }
        function addtoerrorArr(val) {
            var isnoaddtoerror = true;
            var rs = splitarr().split(',');
            arr = new Array();
            $.each(rs, function (i) { arr[arr.length] = rs[i] });
            if (rs.length <= 0) {
                arr[arr.length] = val.attr('vtype');
            }
            else {
                for (var i = 0; i < rs.length; i++) {
                    if (rs[i] == val.attr('vtype')) isnoaddtoerror = false;
                }
            }
            if (isnoaddtoerror) arr[arr.length] = val.attr('vtype');
        }
        function removeaction(val) {
            val.css({ backgroundColor: "" }).siblings("[msgDiv='msgDiv']").hide();
            arr = removeArrVal(val);
        }
        function glint(val) {
            if (opts.inputGlint) {
                val.everyTime(200, "timer", function () {
                    val.css({ backgroundColor: opts.glintColor })
                    .oneTime(100, function () { val.css({ backgroundColor: "" }) })
                }, 3)
                .oneTime(800, function () { val.css({ backgroundColor: opts.glintColor }) })
            } else { val.css({ backgroundColor: opts.glintColor }); }
        }
        function splitarr() {
            var sa = arr.join(','); var rs = "";
            $.each(sa.split(','), function (i) {
                if (sa.split(',')[i] != "" && sa.split(',')[i] != undefined)
                    rs += sa.split(',')[i] + ',';
            });
            if (rs != '') rs = rs.substring(0, rs.length - 1);
            return rs;
        }
        function removeArrVal(val) {
            var rs = splitarr().split(',');
            var newArr = new Array();
            for (var i = 0; i < rs.length; i++) {
                if (rs[i] != val.attr('vtype')) {
                    newArr[newArr.length] = rs[i];
                }
            }
            return newArr;
        }
        function returnfalse() {
            $.each(arr, function (i) { if (arr[i] != undefined) { action($("*[vtype='" + arr[i] + "']"), errorArr[arr[i]], 'each'); } });
        }
        warnArr['data-name'] = '请输入用户名';
        warnArr['data-pwd'] = '请输入密码';
        warnArr['data-rpwd'] = '请输入再次密码';
        warnArr['data-email'] = '请输入电子邮箱';
        warnArr['data-phone'] = '请输入手机号码';
        warnArr['data-number'] = '不能为空';
        errorArr = warnArr;
        definedErrorArr = definedWarnArr;
        lengthArr['data-name'] = '用户名';
        lengthArr['data-pwd'] = '密码';
        lengthArr['data-number'] = '';
        regexArr['data-name'] = '用户名只能输入数字、字母、下划线';
        regexArr['data-rpwd'] = '两次密码输入不一致';
        regexArr['data-email'] = '电子邮箱格式错误';
        regexArr['data-phone'] = '手机号码格式错误';
        regexArr['data-number'] = '只能输入数字';
    };
    $.fn.inputMsg.defaults = {
        msgClass: "",
        msgWay: "right",
        msgAnimate: "show",
        inputGlint: false,
        glintColor: "#fefbbd",
        msgInputSpace: 8,
        succeedText: "注册成功!"
    };
    $.fn.inputMsg.setDefaults = function (settings) {
        $.extend($.fn.inputMsg.defaults, settings);
    };
})