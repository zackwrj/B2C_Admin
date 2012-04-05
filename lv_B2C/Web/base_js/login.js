/// <reference path="jquery-1.5.2.js" />

$(function () {
    //提示语
    var _reg_input_name = '用户名为6~18个字符,<br />包括字母、数字、下划线',
        _reg_input_email = '请输入常用电子邮箱，密码<br />忘记时可用于找回密码',
        _reg_input_pwd = '密码为6~16个字符，<br />区分大小写',
        _reg_input_r_pwd = '请再次输入您<br />设置的密码',
        _log_input_name = '请输入用户名,<a rel="no_name" href="###">没有账号？</a>';

    var _reg_success_msg = '恭喜您，注册成功！是否进入个人中心？',
        _reg_success_url = '/Users/ModifyInfo.aspx';

    var $login = $('#uc_Login a.a_login'), $reg = $('#uc_Login a.a_register,#register_btn'), $logout = $('#uc_Login a.a_login_out'),
        $logCon = $('#new_login'), $regCon = $('#new_reg'), $mask = $('#body-mask-login'), $msg_login_span = $('#new_login .new_login_center dd span'),
        $msg_reg_span = $('#new_reg .new_reg_center dd span'), $log_center_con = $('#new_login .new_login_center'), $reg_center_con = $('#new_reg .new_reg_center'),
        $close = $('#new_login dt i, #new_reg dt i'), $no_name = $('#new_login a[rel="no_name"]'), $has_name = $('#new_reg a[rel="has_name"]'),
        $log_name = $('#uc_log_username'), $log_pwd = $('#uc_log_password'), $log_btn = $('#uc_btn_login'),
        $reg_name = $('#uc_reg_username'), $reg_email = $('#uc_reg_email'), $reg_pwd = $('#uc_reg_password'),
        $reg_r_pwd = $('#uc_reg_r_password'), $reg_reset = $('#uc_btn_reset'), $reg_btn = $('#uc_btn_reg'),
        $log_success = $('#uc_Login .username'), $log_no = $('#uc_Login .uc-Has-logged-on');

    var _center_width = 450, _center_old_width = 258, _center_ok_width = 288, _focuscolor = '#000', _blurcolor = '#686868', _reg_span_bg = '#fcfee9', _reg_span_lineheight = '17.5px', _reg_ok_img = '/base_images/login/ok.png', _reg_loading_img = '/base_images/login/loading.gif';

    var _data_log_name = 0, _data_log_pwd = 0, _log_data = 0, _reg_data = 0;

    var _reg_temp_name = '', _reg_temp_email = '';

    var _bool_name = false, _bool_email = false, _bool_pwd = false, _bool_r_pwd = false, _bool_log = true;

    var timer;

    //登录
    $login.click(function () { ShowLogin(); return false; });

    //注册
    $reg.click(function () { ShowReg(); return false; });

    //没有账号，去注册
    $no_name.live('click', function () { HideLogin(); ShowReg(); });

    //已有账号，去登录
    $has_name.click(function () { HideReg(); ShowLogin(); });

    //关闭
    $close.click(function () { HideReg(); HideLogin(); });

    //登出
    $logout.click(function () {

        return false;
    });

    $(window).resize(function () {
        LogCenter();
        $mask.width($(window).width()).height($(window).height());
    }).keydown(function (event) {
        if (event.keyCode == 27) {
            Close();
            return false;
        }
    });

    //为空时出现提示（登录）
    $msg_login_span.siblings('input').blur(function () {
        var $this = $(this);
        if ($this.val() == '' || $this.val() == '用户名' || $this.val() == '******') {
            if ($this.siblings('span').is(':hidden')) {
                if ($log_center_con.width() != _center_width && !$logCon.is(':animated')) {
                    $logCon.animate({ left: '-=' + (_center_width - _center_old_width) / 2 }, function () {
                        $this.siblings('span').show();
                    });
                    $log_center_con.animate({ width: _center_width });
                }
                else if ($logCon.is(':animated') && $log_center_con.is(':animated')) {
                    $logCon.stop(true, true);
                    $log_center_con.stop(true, true);
                    $this.siblings('span').show();
                }
                else {
                    $this.siblings('span').show();
                }
            }
        }
        else {
            $this.siblings('span').hide();
        }
        IsLogHideSpan();
        if (_log_data == 0) {
            $msg_login_span.hide();
            if ($log_center_con.width() != _center_old_width) {
                $logCon.animate({ left: '+=' + (_center_width - _center_old_width) / 2 });
                $log_center_con.animate({ width: _center_old_width });
            }
        }
        return false;
    });

    var LogEnter = function (e) {
        if (e.keyCode == 13 || $(e.target).attr('id') == 'uc_btn_login') {
            if (_data_log_name == 1 && _data_log_pwd == 1) {
                $(this).blur();
                LogIng();
                $.post('/ashx/login/Login.ashx', { Action: 'post', UName: $log_name.val(), UPwd: $log_pwd.val() }, function (data) {
                    LogEd();
                    if (data == 'True') {
                        LoginSuccess();
                        $log_name.val('用户名').css({ color: _blurcolor });
                        $log_pwd.val('******').css({ color: _blurcolor });
                        $msg_login_span.hide();
                        $log_center_con.width(_center_width);
                        _data_log_name = 0;
                        _data_log_pwd = 0;
                        Close();
                    }
                    else {
                        if ($log_name.siblings('span').is(":hidden")) {
                            $logCon.stop(true, true).animate({ left: $(window).width() / 2 - _center_width / 2 });
                            $log_center_con.stop(true, true).animate({ width: _center_width }, function () {
                                $log_name.siblings('span').html('用户名或密码错误！').show();
                            });
                        }
                    }
                });
            }
            else {
                glint($msg_login_span);
            }
            return false;
        }
    };

    $log_name.keyup(function () {
        if ($.trim($(this).val()).length > 0) {
            _data_log_name = 1;
        }
        else {
            _data_log_name = 0;
        }
    });

    $log_pwd.keyup(function () {
        if ($.trim($(this).val()).length > 0) {
            _data_log_pwd = 1;
        }
        else {
            _data_log_pwd = 0;
        }
    });

    $log_name.focus(function () {
        $(this).siblings('span').html(_log_input_name);
        if (_data_log_name == 0) {
            $(this).val('').css({ color: _focuscolor });
        }
    }).focusout(function () {
        if (_data_log_name == 0) {
            $(this).val('用户名').css({ color: _blurcolor });
        }
    }).keydown(function (e) {
        if (e.keyCode == 13) {
            $log_pwd.focus();
            return false;
        }
    });

    $log_pwd.focus(function () {
        if (_data_log_pwd == 0) {
            $(this).val('').css({ color: _focuscolor });
        }
    }).focusout(function () {
        if (_data_log_pwd == 0) {
            $(this).val('******').css({ color: _blurcolor });
        }
    }).keydown(LogEnter);

    $log_btn.click(LogEnter);

    var RegEnter = function (e) {
        if (e.keyCode == 13 || $(e.target).attr('id') == 'uc_btn_reg') {
            $(this).blur();
            if (_bool_name && _bool_email && _bool_pwd && _bool_r_pwd) {
                RegIng();
                $.post('/ashx/login/Reg.ashx', { Action: 'post', UName: $reg_name.val(), UEmail: $reg_email.val(), UPwd: $reg_pwd.val() }, function (data) {
                    if (data == 'yes') {
                        $regCon.stop(true, true);
                        $reg_center_con.stop(true, true);
                        if (confirm(_reg_success_msg)) {
                            RegEd();
                            window.location = _reg_success_url;
                        }
                        else {
                            LoginSuccess();
                            RegEd();
                            Close();
                        }
                    }
                })
            }
            else {
                $msg_reg_span.siblings('input').each(function () {
                    if ($(this).val() == '') {
                        RegFocus($(this));
                    }
                })
                glint($msg_reg_span);
            }
        }
    };

    $reg_name.blur(function () {
        var $this = $(this);
        if ($.trim($this.val()) != '') {
            var reg = new RegExp("^[a-zA-Z_0-9]+$");
            if ($this.val().length < 6 || $this.val().length > 18) {
                RegSPanError($this, '用户名长度应为6~18个字符');
                _bool_name = false;
            }
            else if (!reg.test($this.val())) {
                RegSPanError($this, '请输入字母、数字和下划线');
                _bool_name = false;
            }
            else {
                _bool_name = false;
                if ($this.val() != _reg_temp_name) {
                    _reg_temp_name = $this.val();
                    RegSpanOK($this);
                    $this.siblings('img').attr('src', _reg_loading_img).show();
                    $.post('/ashx/login/CheckedInput.ashx', { Action: 'post', UName: _reg_temp_name, UType: '1' }, function (data) {
                        if (data == 'False') {
                            $this.siblings('img').attr('src', _reg_ok_img);
                            _bool_name = true;
                            RegSpanOK($this);
                        }
                        else {
                            RegSPanError($this, '该用户名已被注册');
                            _bool_name = false;
                        }
                    });
                }
            }
        }
        else {
            _bool_name = false;
        }
        RegEveryInputFocus($this, _reg_input_name);
    }).focus(function () {
        RegEveryInputFocus($(this), _reg_input_name);
    }).keydown(function (event) {
        if (event.keyCode == 13) {
            $reg_email.focus();
            return false;
        }
    });

    $reg_email.blur(function () {
        var $this = $(this);
        if ($.trim($this.val()) != '') {
            var regexp = new RegExp('^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+[\.]{1}[a-zA-Z]{2,3}$');
            if (!regexp.test($this.val())) {
                RegSPanError($this, '请输入有效的电子邮箱');
                _bool_email = false;
            }
            else {
                _bool_email = false;
                if ($this.val() != _reg_temp_email) {
                    _reg_temp_email = $this.val();
                    RegSpanOK($this);
                    $this.siblings('img').attr('src', _reg_loading_img).show();
                    $.post('/ashx/login/CheckedInput.ashx', { Action: 'post', UEmail: _reg_temp_email, UType: '2' }, function (data) {
                        if (data == 'False') {
                            $this.siblings('img').attr('src', _reg_ok_img);
                            _bool_email = true;
                            RegSpanOK($this);
                        }
                        else {
                            RegSPanError($this, '该邮箱已被注册');
                            _bool_email = false;
                        }
                    });
                }
            }
        }
        else {
            _bool_email = false
        }
        RegEveryInputFocus($this, _reg_input_email);
    }).focus(function () {
        RegEveryInputFocus($(this), _reg_input_email);
    }).keydown(function (event) {
        if (event.keyCode == 13) {
            $reg_pwd.focus();
            return false;
        }
    });

    $reg_pwd.blur(function () {
        _bool_pwd = false;
        var $this = $(this);
        if ($.trim($this.val()) != '') {
            if ($this.val().length < 6 || $this.val().length > 16) {
                RegSPanError($this, '密码长度应为6~16个字符');
            }
            else {
                _bool_pwd = true;
                RegSpanOK($this);
                $this.siblings('img').show();
            }
        }
        RegEveryInputFocus($this, _reg_input_pwd);
    }).focus(function () {
        RegEveryInputFocus($(this), _reg_input_pwd);
    }).keydown(function (event) {
        if (event.keyCode == 13) {
            $reg_r_pwd.focus();
            return false;
        }
    });

    $reg_r_pwd.blur(function () {
        _bool_r_pwd = false;
        var $this = $(this);
        if ($.trim($this.val()) != '') {
            if ($this.val() != $reg_pwd.val()) {
                RegSPanError($this, '两次密码输入不一致');
            }
            else {
                _bool_r_pwd = true;
                RegSpanOK($this);
                $this.siblings('img').show();
            }
        }
        RegEveryInputFocus($this, _reg_input_r_pwd);
    }).focus(function () {
        RegEveryInputFocus($(this), _reg_input_r_pwd);
    }).keydown(RegEnter);

    $reg_reset.click(function () {
        $reg_name.val('');
        $reg_email.val('');
        $reg_pwd.val('');
        $reg_r_pwd.val('');
        RegEveryInputFocus($reg_name, _reg_input_name);
        RegEveryInputFocus($reg_email, _reg_input_email);
        RegEveryInputFocus($reg_pwd, _reg_input_pwd);
        RegEveryInputFocus($reg_r_pwd, _reg_input_r_pwd);
    });

    $reg_btn.click(RegEnter);

    function BodyMaskShow() {
        $mask.width($(window).width()).height($(window).height()).show();
    };
    function BodyMaskHide() {
        $mask.hide();
    };
    function ShowLogin() {
        $msg_login_span.hide();
        $log_center_con.width(_center_old_width);
        BodyMaskShow();
        $logCon.css({ top: $(window).height() / 2.3 - $logCon.height() / 2, left: $(window).width() / 2 - $logCon.width() / 2 }).fadeIn(300);
//        $log_name.focus();
    };
    function HideLogin() {
        BodyMaskHide();
        $logCon.hide();
        $log_name.val('用户名').css({ color: _blurcolor });
        $log_pwd.val('******').css({ color: _blurcolor });
        _data_log_name = 0;
        _data_log_pwd = 0;
    };
    function ShowReg() {
        $msg_reg_span.hide();
        $reg_center_con.width(_center_old_width);
        BodyMaskShow();
        $regCon.css({ top: $(window).height() / 2.3 - $regCon.height() / 2, left: $(window).width() / 2 - $regCon.width() / 2 }).fadeIn(300);
    };
    function HideReg() {
        BodyMaskHide();
        $regCon.hide();
        $msg_reg_span.siblings('img').hide();
        $reg_name.val('');
        $reg_email.val('');
        $reg_pwd.val('');
        $reg_r_pwd.val('');
    };
    function Close() {
        HideReg();
        HideLogin();
    };
    function IsLogHideSpan() {
        for (var i = 0; i < $msg_login_span.siblings('input').length; i++) {
            var _temp = $.trim($msg_login_span.siblings('input').eq(i).val());
            if (_temp == '' || _temp == '用户名' || _temp == '******') {
                _log_data = 1;
                break;
            }
            else {
                _log_data = 0;
            }
        }
    };
    function IsRegHideSpan() {
        for (var i = 0; i < $msg_reg_span.siblings('input').length; i++) {
            var _temp = $.trim($msg_reg_span.siblings('input').eq(i).val());
            if (_temp == '') {
                _reg_data = 1;
                break;
            }
            else {
                _reg_data = 0;
            }
        }
    };
    function LogCenter() {
        if (parseInt($(window).width()) <= parseInt($regCon.width()) + 20) {
            $(window).width(parseInt($regCon.width()) + 20);
        }
        var _reg_tops, _reg_lefts, _log_tops, _log_lefts;

        $logCon.stop().animate({ top: $(window).height() / 2.3 - $logCon.height() / 2, left: $(window).width() / 2 - $logCon.width() / 2 });

        $regCon.stop().animate({
            top: ($(window).height() / 2.3 - $regCon.height() / 2 <= 0) ? 10 : ($(window).height() / 2.3 - $regCon.height() / 2),
            left: ($(window).width() / 2 - $regCon.width() / 2 <= 0) ? 10 : ($(window).width() / 2 - $regCon.width() / 2)
        });
    };
    function RegFocus(val) {
        if ($reg_center_con.width() != _center_width && !$regCon.is(':animated')) {
            $regCon.animate({ left: $(window).width() / 2 - _center_width / 2 }, function () {
                val.siblings('span').show().css({ color: '#888', borderColor: '#dde0c0' });
            });
            $reg_center_con.animate({ width: _center_width });
        }
        else if ($regCon.is(':animated') && $reg_center_con.is(':animated')) {
            $regCon.stop(true, true);
            $reg_center_con.stop(true, true);
            val.siblings('span').show().css({ color: '#888', borderColor: '#dde0c0' });
        }
        else {
            val.siblings('span').show().css({ color: '#888', borderColor: '#dde0c0' });
        }

    };
    function RegSpanMsg(val) {
        val.siblings('span').css({ background: _reg_span_bg, lineHeight: _reg_span_lineheight });
        CenterWidthAnimate();
    };
    function RegSPanError(val, _errorMsg) {
        val.siblings('img').hide();
        val.siblings('span').css({ background: '#FFE6EB', lineHeight: '', color: '#B20000', borderColor: '#EAD0D3' }).html(_errorMsg).show();
        CenterWidthAnimate();
    };
    function RegSpanOK(val) {
        val.siblings('span').hide();
        if (_bool_name && _bool_email && _bool_pwd && _bool_r_pwd) {
            $reg_center_con.animate({ width: _center_ok_width });
            CenterOkWidthAnimate();
        }
    }
    function RegEveryInputFocus(val, _html) {
        if ($.trim(val.val()) == '') {
            val.siblings('img').hide();
            RegFocus(val);
            RegSpanMsg(val);
            if (_html != '') {
                val.siblings('span').html(_html);
            }
        }
    }
    function CenterWidthAnimate() {
        if ($regCon.width() != _center_width) {
            $regCon.animate({ left: $(window).width() / 2 - _center_width / 2 });
            $reg_center_con.animate({ width: _center_width });
        }
    }
    function CenterOkWidthAnimate() {
        if ($regCon.width() != _center_ok_width) {
            $regCon.animate({ left: $(window).width() / 2 - _center_ok_width / 2 });
            $reg_center_con.animate({ width: _center_ok_width });
        }
    }
    function RegIng() {
        $reg_btn.val('正在注册...').attr('disabled', 'disabled');
    }
    function RegEd() {
        $reg_btn.val('注册').attr('disabled', '');
        $reg_name.val('');
        $reg_email.val('');
        $reg_pwd.val('');
        $reg_r_pwd.val('');
        $msg_reg_span.hide().siblings('img').hide();
    }
    function LogIng() {
        $log_btn.val('正在登录...').attr('disabled', 'disabled');
    }
    function LogEd() {
        $log_btn.val('登录').attr('disabled', '');
    }
    function glint(val) {
        for (var i = 0; i < val.length; i++) {
            var $this = $msg_reg_span.eq(i);
            if ($this.is(':visible')) {
                var _color = $this.css('color');
                $this.everyTime(200, "timer", function () {
                    $this.css({ background: '#ffe6eb', color: _color }).oneTime(100, function () {
                        $this.css({ background: '#a10000', color: '#fff' })
                    })
                }, 3).oneTime(800, function () {
                    $this.css({ background: '#ffe6eb', color: _color })
                    $this.siblings('input').select().focus();
                });
                break;
            }
        }
    }
    function LoginSuccess() {
        var _users = ($.trim($log_name.val()) != "" && $log_name.val() != "用户名") ? $log_name.val() : $reg_name.val();
        $log_success.text(_users).parent().show();
        $('div[id$="login_after"]').find("#current_user_zpb").text(_users);
        $('div[id$="login_after"]').find("#current_user_zpb").attr("vclass", _users);
        $.cookie("current_user", _users);
        $('div[id$="login_before"]').hide();
        $('div[id$="login_after"]').show();
        $log_no.hide();
    }
    function LoginNo() {

    }
    $('.new_login_center dd .btn').hover(function () {
        $(this).css({ 'backgroundPosition': '0px -40px', 'color': '#fff' })
    }, function () {
        $(this).css({ 'backgroundPosition': '0px 0px', 'color': '#000' })
    });
    $('.new_login_center dd .reset').hover(function () {
        $(this).css({ 'backgroundPosition': '0px -40px' })
    }, function () {
        $(this).css({ 'backgroundPosition': '0px 0px' })
    });
});