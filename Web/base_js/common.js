function getObj(id) {
    return document.getElementById(id);
}

String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

Array.prototype.remove = function (dx) {
    if (isNaN(dx) || dx > this.length)
        return false;
    for (var i = 0, n = 0; i < this.length; i++) {
        if (this[i] != this[dx]) {
            this[n++] = this[i]
        }
    }
    this.length -= 1
}

function showObj(id) {
    getObj(id).style.display = "";
}

function hideObj(id) {
    getObj(id).style.display = "none";
}

function switchShowHide(id) {
    if (getObj(id).style.display == "") {
        hideObj(id);
    }
    else {
        showObj(id);
    }
}

function changeClassName(obj, className) {
    obj.className = className;
}

function openWindow(url, windowWidth, windowHeight) {
    window.open(url, '', 'width=' + windowWidth + ', height=' + windowHeight + ', top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, status=no');
}

function openPage(url) {
    window.navigate(url);
}

function clearNoNum(obj) {
    //先把非数字的都替换掉，除了数字和.
    obj.value = obj.value.replace(/[^\d.]/g, "");
    //必须保证第一个为数字而不是.
    obj.value = obj.value.replace(/^\./g, "");
    //保证只有出现一个.而没有多个.
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    //保证.只出现一次，而不能出现两次以上

    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
}

function validateNumber(target) {
    if (target != null) {
        var objRe = /^[0-9]+(.[0-9]{2})?$/;
        var value = target.value.trim() == "" ? "" : target.value.trim();
        target.value = value;
        if (target.value == "") {
            return false;
        }
        if (!objRe.test(value)) {
            target.focus();
            return false;
        }
    }
    return true;
}

function resizeImages(id, maxWidth) {
    var imgs = getObj(id).getElementsByTagName("img");
    for (var i = 0; i < imgs.length; i++) {
        if (imgs[i].width > maxWidth || imgs[i].style.width > maxWidth) {
            imgs[i].height = imgs[i].height * (maxWidth / imgs[i].width);
            imgs[i].style.height = imgs[i].height * (maxWidth / imgs[i].width);
            imgs[i].width = maxWidth;
            imgs[i].style.width = maxWidth;
        }
    }
}

function resizeTables(id, maxWidth) {
    var tables = getObj(id).getElementsByTagName("table");
    for (var i = 0; i < tables.length; i++) {
        if (tables[i].width > maxWidth || tables[i].style.width > maxWidth) {
            tables[i].height = tables[i].height * (maxWidth / tables[i].width);
            tables[i].style.height = tables[i].height * (maxWidth / tables[i].width);
            tables[i].width = maxWidth;
            tables[i].style.width = maxWidth;
        }
    }
}

function resizeObj(id, maxWidth, maxHeight) {
    var obj = getObj(id);
    if (obj.width > maxWidth || obj.height > maxHeight || obj.style.width > maxWidth || obj.style.height > maxHeight) {
        obj.width = maxWidth;
        obj.style.width = maxWidth;
        obj.height = maxHeight;
        obj.style.height = maxHeight;
    }
}

function pDel() {
    var msg = "您真的确定要删除吗？\n\n请确认！";
    if (confirm(msg) == true) {
        return true;
    } else {
        return false;
    }
}