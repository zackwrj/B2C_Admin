/// <reference path="jquery-1.5.2.js" />

$(document).ready(function () {
    var input = $("#ChinaArea input");
    var tProvince = input.eq(0);
    var tCity = input.eq(1);
    var tCounty = input.eq(2);

    $("#ChinaArea").jChinaArea({
        aspnet: true,
        s1: tProvince.val(),
        s2: tCity.val(),
        s3: tCounty.val()
    });
});