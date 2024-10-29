/*****************************************************************
 * Japanese language file for jquery.validationEngine.js (ver2.0)
 *
 * Transrator: tomotomo ( Tomoyuki SUGITA )
 * http://tomotomoSnippet.blogspot.com/
 * Licenced under the MIT Licence
 *******************************************************************/
(function ($) {
    $.fn.validationEngineLanguage = function () {
    };
    $.validationEngineLanguage = {
        newLang: function () {
            $.validationEngineLanguage.allRules = {
                "required": { // Add your regex rules here, you can take telephone as an example
                    "regex": "none",
                    "alertText": "* This field is required",
                    "alertTextCheckboxMultiple": "* Please select an option",
                    "alertTextCheckboxe": "* Both date range fields are required"
                },
                "requiredInFunction": {
                    "func": function (field, rules, i, options) {
                        return (field.val() === "test") ? true : false;
                    },
                    "alertText": "* Field must equal test"
                },
                "minSize": {
                    "regex": "none",
                    "alertText": "* ",
                    "alertText2": " characters allowed"
                },
                "groupRequired": {
                    "regex": "none",
                    "alertText": "*  id or mailaddress required"
                },
                "maxSize": {
                    "regex": "none",
                    "alertText": "* ",
                    "alertText2": " characters allowed"
                },
                "min": {
                    "regex": "none",
                    "alertText": "* ",
                    "alertText2": " 以上の数値にしてください"
                },
                "max": {
                    "regex": "none",
                    "alertText": "* ",
                    "alertText2": " 以下の数値にしてください"
                },
                "maxCheckbox": {
                    "regex": "none",
                    "alertText": "* チェックしすぎです"
                },
                "minCheckbox": {
                    "regex": "none",
                    "alertText": "* ",
                    "alertText2": "つ以上チェックしてください"
                },
                "equals": {
                    "regex": "none",
                    "alertText": "* 入力された値が一致しません"
                },
                "phone": {
                    // credit: jquery.h5validate.js / orefalo
                    // "regex": /^(0[0-9]{1,4}-[0-9]{1,4}-[0-9]{4})+$/,
                    "alertText": "* 電話番号が正しくありません",
                    "func": function (field, rules, i, options) {
                        if (field.val() == "") {
                            return true;
                        }

                        var pattern0120 = /^(0120-[0-9]{6})+$/;
                        var pattern0800 = /^(0800-[0-9]{7})+$/;
                        var pattern0570 = /^(0570-[0-9]{6})+$/;
                        var pattern = /^(0[0-9]{1,4}-[0-9]{1,4}-[0-9]{4})+$/;

                        // 全てのパターンを通らない場合エラーとする。
                        if (!pattern.test(field.val()) &&
                            !pattern0120.test(field.val()) &&
                            !pattern0800.test(field.val()) &&
                            !pattern0570.test(field.val())) {
                            return false;
                        }

                        return true;
                    }
                },
                "FreeDial": {
                    "regex": /^[0-9\-]+$/,
                    "alertText": "* 電話番号に使用できない文字が入力されています"
                },
                "email": {
                    // Shamelessly lifted from Scott Gonzalez via the Bassistance Validation plugin https://projects.scottsplayground.com/email_address_validation/
                    "regex": /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i,
                    "alertText": "* Invalid e-mail address"
                },
                "integer": {
                    "regex": /^[\-\+]?\d+$/,
                    "alertText": "* Not a valid integer"
                },
                "numberWithSign": {
                    // Number, including positive, negative, and floating decimal. credit: orefalo
                    "regex": /^[\-]?((([0-9]{1,3})([,][0-9]{3})*)|([0-9]+))?([\.]([0-9]+))?$/,
                    "alertText": "* Invalid floating decimal number"
                },
                "number": {
                    // Number, including positive, negative, and floating decimal. credit: orefalo
                    //"regex": /^[\-\+]?((([0-9]{1,3})([,][0-9]{3})*)|([0-9]+))?([\.]([0-9]+))?$/,
                    // 符号は無しとする
                    "regex": /^((([0-9]{1,3})([,][0-9]{3})*)|([0-9]+))?([\.]([0-9]+))?$/,
                    "alertText": "* Invalid floating decimal number"
                },
                "date": {
                    //"regex": /^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])$/,
                    "alertText": "",
                    "alertText1": "* Invalid date, must be in DD/MM/YYYY format",
                    "alertText2": "* Invalid date",
                    "func": function (field, rules, i, options) {
                        if (field.val() == "") {
                            return true;
                        }

                        var pattern = /^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[\/]\d{4}$/;
                        if (!pattern.test(field.val())) {
                            options.allrules.date.alertText = options.allrules.date.alertText1;
                            return false;
                        }

                        var m = moment(field.val());
                        if (!moment(field.val(), 'YYYY/MM/DD').isValid() || m <= moment("1900/01/01")) {
                            options.allrules.date.alertText = options.allrules.date.alertText2;
                            return false;
                        }

                        return true;
                    }
                },
                "engdate": {
                    //"regex": /^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])$/,
                    "alertText": "",
                    "alertText1": "* Invalid date, must be in DD/MM/YYYY format",
                    "alertText2": "* Invalid date",
                    "func": function (field, rules, i, options) {
                        if (field.val() == "") {
                            return true;
                        }

                        var pattern = /^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[\/]\d{4}$/;
                        if (!pattern.test(field.val())) {
                            options.allrules.date.alertText = options.allrules.date.alertText1;
                            return false;
                        }

                        var m = moment(field.val());
                        if (!moment(field.val(), 'DD/MM/YYYY').isValid() || m <= moment("01/01/1900")) {
                            options.allrules.date.alertText = options.allrules.date.alertText2;
                            return false;
                        }

                        return true;
                    }
                },
                "yearMonth": {
                    //"regex": /^\d{4}[\/](0?[1-9]|1[012])$/,
                    "alertText": "",
                    "alertText1": "* Invalid Year and Month, must be in MM/YYYY format",
                    "alertText2": "* Invalid date",
                    "func": function (field, rules, i, options) {
                        if (field.val() == "") {
                            return true;
                        }

                        var pattern1 = /^\d{4}[\/]\d{2}$/;
                        var pattern2 = /^\d{4}[\/](0?[1-9]|1[012])$/;
                        if (!pattern1.test(field.val())) {
                            options.allrules.yearMonth.alertText = options.allrules.yearMonth.alertText1;
                            return false;
                        } else if (!pattern2.test(field.val())) {
                            options.allrules.yearMonth.alertText = options.allrules.yearMonth.alertText2;
                            return false;
                        }

                        var m = moment(field.val(), 'YYYY/MM');
                        if (m <= moment('1900/01', 'YYYY/MM')) {
                            options.allrules.yearMonth.alertText = options.allrules.yearMonth.alertText2;
                            return false;
                        }

                        return true;
                    }
                },
                "Monthyear": {
                    //"regex": /^\d{4}[\/](0?[1-9]|1[012])$/,
                    "alertText": "",
                    "alertText1": "* Invalid Year and Month, must be in MM/YYYY format",
                    "alertText2": "* Invalid date",
                    "func": function (field, rules, i, options) {
                        if (field.val() === "") {
                            return true;
                        }

                        var pattern1 = /^\d{2}\/\d{4}$/;
                        var pattern2 = /^(0?[1-9]|1[012])[\/]\d{4}$/;
                        if (!pattern1.test(field.val())) {
                            options.allrules.Monthyear.alertText = options.allrules.Monthyear.alertText1;
                            return false;
                        } else if (!pattern2.test(field.val())) {
                            options.allrules.Monthyear.alertText = options.allrules.Monthyear.alertText2;
                            return false;
                        }

                        var m = moment(field.val(), 'MM/YYYY');
                        if (m <= moment('01/1900', 'MM/YYYY')) {
                            options.allrules.Monthyear.alertText = options.allrules.Monthyear.alertText2;
                            return false;
                        }

                        return true;
                    }
                },
                "time": {
                    "regex": /^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])(:[0-5][0-9])?$/,
                    "alertText": "* Invalid time, must be in HH:mm format"
                },
                "onlyNumber": {
                    "regex": /^[0-9]+$/,
                    "alertText": "* Numbers only"
                },
                "onlyNumberSp": {
                    "regex": /^[0-9\ ]+$/,
                    "alertText": "* Numbers only"
                },
                "onlyNumberSpspecial": {
                    "regex": /^[0-9\ -()+]+$/,
                    "alertText": "* Numbers and special characters allowed"
                },
                "onlyLetterSp": {
                    "regex": /^[a-zA-Z\ ]+$/,
                    "alertText": "* Letters only"
                },
                "onlyLetterNumber": {
                    "regex": /^[0-9a-zA-Z]+$/,
                    "alertText": "* No special characters allowed"
                },
                "containSpecialCharacter": {
                    "regex": /^[0-9a-zA-Z\ ;,.!@#$%:{}[]?"^&*()]+$/,
                    "alertText": "* special characters allowed"
                },
                "NRCCheck": {
                    "regex": /^[0-9{0,2}\/a-zA-Z\(a-zA-Z\)0-9{9}]+$/,
                    "alertText": "* NRC format only"
                },
                "halfKana": {
                    "regex": /^[ ｰ｡｢｣､()･ｦｧｨｩｪｫｬｭｮｯﾀｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾐﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ]+$/,
                    "alertText": "* Katakana only"
                },
                "fullWidth": {
                    "regex": /^[^ -~｡-ﾟ]+$/,
                    "alertText": "* Multibyte Letters only"
                },
                "halfWidth": {
                    "regex": /^[ -~｡-ﾟ]+$/,
                    "alertText": "* Halfbyte Letters only"
                },
                "jpDate": {
                    "regex": /^\d{2}[\/\-](0[1-9]|1[012])[\/\-](0[1-9]|[12][0-9]|3[01])$/,
                    "alertText": "* 日付は半角で YY/MM/DD の形式で入力してください"
                },
                // 口座名義人Validator
                "accountHolderName": {
                    "regex": /^[　ﾞﾟｱ-ﾝ0-9A-Z,.()｢｣/\-\\]+$/,
                    "alertText": "* 口座名義人が正しくありません"
                },
                // CIC報告向け カナ住所
                "halfCICKanaAddress": {
                    "regex": /^[ｰ\-ｱ-ﾝｧｨｩｪｫｬｭｮｯﾞﾟA-Z0-9 \.(),'=&̀`･]+$/,
                    "alertText": "* カナ住所に使用できない文字が入力されています"
                },
                // CIC報告向け カナ勤務先名
                "halfCICKanaWorkplaceName": {
                    "regex": /^[ｰ\-ｱ-ﾝｧｨｩｪｫｬｭｮｯﾞﾟA-Z0-9 \.(),'=&̀`･]+$/,
                    "alertText": "* カナ勤務先名に使用できない文字が入力されています"
                },
                // CIC報告向け カナ氏名
                "halfCICKanaName": {
                    "regex": /^[ｰ\-ｱ-ﾝｧｨｩｪｫｬｭｮｯﾞﾟ]+$/,
                    "alertText": "* カナ氏名に使用できない文字が入力されています"
                },
                // CIC報告向け 半角英字氏名Validator
                "halfCICAlphabetName": {
                    "regex": /^[A-Z]+$/,
                    "alertText": "* 英字氏名に使用できない文字が入力されています"
                },
                "justLength": {
                    "alertText": "",
                    "alertText1": "* ",
                    "alertText2": "文字で入力してください",
                    "func": function (field, rules, i, options) {
                        if (field.val() == "") {
                            return true;
                        }

                        var length = Number(rules[i + 2]);
                        if (field.val().length != length) {
                            options.allrules.justLength.alertText =
                                options.allrules.justLength.alertText1 +
                                length +
                                options.allrules.justLength.alertText2;
                            return false;
                        }
                        return true;
                    }
                },
                "splitNameLength": {
                    "alertText": "",
                    "alertText1": "* 姓名合わせて",
                    "alertText2": "文字以内で入力してください",
                    "func": function (field, rules, i, options) {
                        if (field.val() == "") {
                            return true;
                        }

                        var maxLength = Number(rules[i + 2]);
                        var targetName = rules[i + 3];
                        var target = $('#' + targetName);

                        // スペースが付加されるのでその分を足す
                        var entryLength = field.val().length + target.val().length + 1;
                        if (entryLength > maxLength) {
                            options.allrules.splitNameLength.alertText =
                                options.allrules.splitNameLength.alertText1 +
                                maxLength +
                                options.allrules.splitNameLength.alertText2;
                            return false;
                        }
                        return true;
                    }
                },
            };
        }
    };
    $.validationEngineLanguage.newLang();
})(jQuery);

// チェックボックスをグループ化して必須チェックを行う
function requireCheckBoxeGroup(field, rules, i, options) {
    var form = $(field.closest("form, .validationEngineContainer"));
    var groupName = rules[i + 2];
    var group = form.find("[class*=requireCheckBoxeGroup\\[" + groupName + "\\]]");
    var firstOfGroup = group.eq(0);
    if (firstOfGroup[0] != field[0]) {
        // 常に最初のチェックボックスのバリデーションを動かす
        $(firstOfGroup[0]).validationEngine('validate')
    } else {
        // 最初のチェックボックスのバリデーション時にグループ全体をチェック
        var isChecked = false;
        group.each(function (index, element) {
            if (element.checked) {
                isChecked = true;
                return false;
            }
        });
        if (!isChecked) {
            return options.allrules.minCheckbox.alertText + "1" + options.allrules.minCheckbox.alertText2;
        }
    }
}