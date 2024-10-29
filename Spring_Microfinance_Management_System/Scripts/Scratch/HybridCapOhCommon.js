
function convertIntNaN(param) {

    if (param == null) {
        return 0;
    }

    var num = parseInt(param.toString().replace(/,/g, ""));

    if (isNaN(num)) {
        return 0;
    } else {
        return num;
    }
}


function convertFloatNaN(param) {

    if (param == null) {
        return 0;
    }

    var num = parseFloat(param.toString().replace(/,/g, ""));

    if (isNaN(num)) {
        return 0;
    } else {
        return num;
    }
}


function getComma3(target) {

    var value = target.toString().replace(/,/g, "");

    // カンマ区切り
    while (value != (value = value.replace(/^(-?\d+)(\d{3})/, "$1,$2")));

    // 数値以外の場合は 0
    if (isNaN(parseInt(value))) {
        return target;
    }

    return value;
}


function getZeroFill(target, regit) {

    var value = convertIntNaN(target);

    var str = "";

    for (var i = 0; i < regit; i++) {
        str += "0";
    }

    return (str + value).slice(0 - regit);
}


function isDefaultDate(target) {
    var m = moment(target).format("YYYY/MM/DD");
    if (m == moment(defaultDate).format("YYYY/MM/DD")) {
        return true;
    } else {
        return false;
    }
}


function convertDateFormat(target) {

    if (!target) {
        return '';
    }

    if (target === '') {
        return '';
    }

    if (target == '0001/01/01 0:00:00') {
        return '';
    }

    // 日付の初期値として定義される日付の場合はブランクとする
    if (moment(target).isValid()) {
        if (moment(target).isSame('1900-01-01')) {
            return '';
        }
    }

    return target.replace(/-/g, '/').substr(0, 10);
}


function convertYearMonthFormat(target) {

    if (!target) {
        return '';
    }

    if (target == '0001/01/01 0:00:00') {
        return '';
    }

    // 日付の初期値として定義される日付の場合はブランクとする
    if (target == '1900/01/01') {
        return '';
    }

    return target.replace(/-/g, '/').substr(0, 7);
}


function convertyyyyMMddFormat(target) {

    if (target == '' || target.length != 10) {
        return '';
    }

    var arr = target.split("/");
    if (arr.length != 3 || arr[0].length != 2 || arr[1].length != 2 || arr[2].length != 4) {
        return '';
    }

    var year = Number(arr[2]);
    var month = Number(arr[1]);
    var day = Number(arr[0]);
    if (isNaN(year) || isNaN(month) || isNaN(day)) {
        return '';
    }

    return  arr[2] + "/" + arr[1] + "/" + arr[0];
}


function convertddMMyyyyFormat(target) {

    if (target == '') {
        return '';
    }

    if (isDefaultDate(target)) {
        return '';
    }

    return moment(target).format("DD/MM/YYYY");
}


function getAge(target) {

    if (target == '' || target.length != 10) {
        return '';
    }

    var arr = target.split("/");
    if (arr.length != 3 || arr[0].length != 2 || arr[1].length != 2 || arr[2].length != 4) {
        return '';
    }

    var year = Number(arr[2]);
    var month = Number(arr[1]);
    var day = Number(arr[0]);
    if (isNaN(year) || isNaN(month) || isNaN(day)) {
        return '';
    }

    if (target == '01/01/1900') {
        return '';
    }

    var today = new Date();
    var age = today.getFullYear() - year;

    // 誕生日がまだ来ていなければ、1引く ※getMonth()では月が0～11となっていることに注意
    if (today.getMonth() + 1 < month ||
        (month == today.getMonth() + 1 && today.getDate() < day)) {
        age--;
    }

    return age.toString();
}


function set2fig(num) {
    var ret;
    if (num < 10) {
        ret = "0" + num;
    } else {
        ret = num;
    }

    return ret;
}


function showClock() {
    if (document.getElementById("realtimeClockDate") != null && document.getElementById("realtimeClockTime") != null) {
        var nowDateTime = new Date();

        var year = nowDateTime.getFullYear();
        var month = set2fig(nowDateTime.getMonth() + 1);
        var day = set2fig(nowDateTime.getDate());
        var date = year + "/" + month + "/" + day;

        var nowHour = set2fig(nowDateTime.getHours());
        var nowMin = set2fig(nowDateTime.getMinutes());
        var nowSec = set2fig(nowDateTime.getSeconds());
        var time = nowHour + ":" + nowMin + ":" + nowSec;

        document.getElementById("realtimeClockDate").innerHTML = date;
        document.getElementById("realtimeClockTime").innerHTML = time;
    }
}

function showSearchResultZeroMessage() {
    window.alert("No data found.");
}


function showMustSelectRecordMessage() {
    window.alert("Please select record from list.");
}


function deleteConfirmAndSubmit(arg) {
    arg.message = 'Are you sure you want to delete?';
    confirmAndSubmit(arg);
}


function confirmAndSubmit(arg) {
    
    if (arg.message === undefined) {
        arg.message = 'Are you sure you want to update?';
    }

    if (window.confirm(arg.message)) {
        if (arg.callbackSubmitBefore !== undefined) {
            arg.callbackSubmitBefore();
        }
        
        $("#" + arg.formId).submit();
    } else {
        releaseClickWaitMode();
    }
}


function confirmAndSubmitForReception(arg) {
    if (arg.title === undefined) {
        arg.title = 'confirm';
    }
    if (arg.message === undefined) {
        arg.message = '更新します。よろしいですか？';
    }

    // ダイアログのメッセージを設定
    // <div>タグはサイドバーに保持する
    $("#show-confirm-dialog").html(arg.message);

    // ダイアログを作成
    $("#show-confirm-dialog").dialog({
        modal: true,
        title: arg.title,
        buttons: {
            "はい": function () {
                $("#" + arg.formId).submit();
                $(this).dialog("close");
            },
            "いいえ": function () {
                releaseClickWaitMode();
                $(this).dialog("close");
            }
        },
        open: function () {		// いいえボタンにフォーカスをあてる
            $(this).siblings('.ui-dialog-buttonpane').find('button:eq(1)').focus();
        }
    });

    // ダイアログを表示
    $("#show-confirm-dialog").show();
}


function YesNoModalEditableMessageAndFunc(arg) {
    if (arg.title === undefined) {
        arg.title = '確認';
    }
    if (arg.messages === undefined) {
        arg.messages = ['更新します。よろしいですか？'];
    }

    // ダイアログのメッセージを設定
    // <div>タグはサイドバーに保持する
    $("#show-confirm-dialog").html(function () {
        var rawHtml = "";
        arg.messages.forEach(function (element) {
            rawHtml += "<p>" + element + "</p>";
        });
        return rawHtml;
    });

    // ダイアログを作成
    $("#show-confirm-dialog").dialog({
        modal: true,
        title: arg.title,
        open: function () {		// いいえボタンにフォーカスをあてる
            $(this).siblings('.ui-dialog-buttonpane').find('button:eq(1)').focus();
        }
    });

    var dialog_buttons = {};
    arg.buttonNameAndFunc.forEach(function (element) {
        dialog_buttons[element.message] = function () {
            element.Getfunction()
            $(this).dialog("close");
        }
    });

    $("#show-confirm-dialog").dialog({
        buttons: dialog_buttons
    })

    // ダイアログを表示
    $("#show-confirm-dialog").dialog("open");
}


function showUpdateSucceededMessage() {
    window.alert('Finished update.');
}


function setClickWaitMode() {
    $('button').each(function () {
        var $button = $(this);
        $button.prop("disabled", true);
    });
    document.body.style.cursor = 'wait'
}


function releaseClickWaitMode() {
    $('button').each(function () {
        var $button = $(this);
        $button.prop("disabled", false);
    });
    document.body.style.cursor = 'auto'
}


function showNextScreen(path, queryString) {
    setClickWaitMode();
    if (queryString === undefined) {
        queryString = "";
    }

    location.href = path + queryString;
}


function showScreenOnNewTab(path, queryString) {
    if (queryString === undefined) {
        queryString = "";
    }

    window.open(path + queryString);
}
