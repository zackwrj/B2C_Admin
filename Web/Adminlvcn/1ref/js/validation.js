mini.parse();

function onBeforeSubmit() {
    var form = new mini.Form("#form1");
    form.validate();

    return form.isValid();
}
function resetForm() {
    var form = new mini.Form("#form1");
    form.reset();
}

//////////////////////////////////////
function updateError(e) {
    var control = e.sender;
    removeError(control);
    if (e.isValid == false) {
        addError(control, e.errorText);
    }
}
function focusInput(id) {
    var el = document.getElementById(id);
    if (el) el.focus();
}
function addError(control, errorText) {
    var textId = control.id + "$text";
    var errorId = control.uid + "$errorText";

    removeError(control);
    var jq = jQuery("#validGroup1");
    jq.append('<li id="' + errorId + '"><a href="javascript:focusInput(\'' + textId + '\')">' + errorText + '</a></li>');
}
function removeError(control) {
    var errorId = control.uid + "$errorText";
    var el = document.getElementById(errorId);
    jQuery(el).remove();
}

//////////////////////////////////////////
function isEmail(s) {
    if (s.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
        return true;
    else
        return false;
}
function onEmialValidation(e) {
    if (e.isValid) {
        if (isEmail(e.value) == false) {
            e.errorText = "必须输入邮件地址";
            e.isValid = false;
        }
    }
    updateError(e);
}
function onPwdValidation(e) {
    if (e.isValid) {
        if (e.value.length < 5) {
            e.errorText = "密码不能少于5个字符";
            e.isValid = false;
        }
    }
    updateError(e);
}
function onProductNameVali(e) {
    if (e.isValid) {
        if (e.value.length < 5) {
            e.errorText = "商品名称不能少于5个字符";
            e.isValid = false;
        }
    }
    updateError(e);
}

function onOnlyNotNull(e) {
    if (e.isValid) {
        if (!e.isValid) {
            e.isValid = false;
        }
    }
    updateError(e);
}