
/**********************************************************
    ブラウザの戻るボタン（bacspace含む）無効化
**********************************************************/
history.pushState(null, null, null);

window.addEventListener("popstate", function () {
    history.pushState(null, null, null);
});

$(function () {
    /* コード code: start  */
    $("body").on("change", ".code-custom", function () {
        var _this = this;
        codeOnchange(_this);
    });

    $("body").on("dblclick", ".code-custom", function () {
        var _this = this;
        if (!_this.disabled) {
            //TPL99010W
            callTPL99010W(_this);
        }
    });

    $("body").on("keydown", ".code-custom", function (e) {
        var _this = this;
        if (!_this.disabled) {
            // ----Keypress: F12----
            if (e.key === "F12") {
                //TPL99010W
                callTPL99010W(_this);
                return false;
            }
        }
    });

    function codeOnchange(_this) {
        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var identify = $(_this).data("code-identify");
        var codeSrch = code;
        if (!identify || identify === '') {
            identify = code;
            codeSrch = '00000000';
        }
        var sendData = {
            "Key": identify,
            "Code": codeSrch,
            "Type": $(_this).data("get-type"),
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetNameByCode", sendData);
        result.done(function (response) {
            var name = response.name;
            $(_this).parent().find(".code-name-custom").val(name);
            handleAfterCodeChange(code);
        });
    }

    function callTPL99010W(_this) {
        var ident = $(_this).data("code-identify");
        var cdiv = verifyContainerDiv(_this);
        callSearchHelp99010("TPL99010W", cdiv, ident, _this.id);
    }
    /* コード code: end  */

    /* コード code grid: start  */
    $(".container-fluid").on("change", ".code-grid-custom", function () {
        var _this = this;
        codeGridOnchange(_this);
    });

    $(".container-fluid").on("dblclick", ".code-grid-custom", function () {
        //TPL99010W
        var _this = this;
        if (!_this.disabled) {
            callTPL99010WFromCodeGrid(_this);
        }
    });

    $(".container-fluid").on("keydown", ".code-grid-custom", function (e) {
        var _this = this;
        // ----Keypress: F12----
        if (!_this.disabled) {
            if (e.key === "F12") {
                //TPL99010W
                callTPL99010WFromCodeGrid(_this);
                return false;
            }
        }
    });

    async function codeGridOnchange(_this) {
        if ($(_this).data("get-task-identifer") === true) {
           await handleCodeGridBeforeNextAction(_this);
        }

        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var identify = $(_this).data("code-identify");
        var codeSrch = code;
        if (!identify || identify === '') {
            identify = code;
            codeSrch = '00000000';
        }
        var sendData = {
            "Key": identify,
            "Code": codeSrch,
            "Type": $(_this).data("get-type"),
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetNameByCode", sendData);
        result.done(function (response) {
            var name = response.name;
            var nextTd = $(_this).closest("td").next();
            nextTd.attr("title", name)
            var nextEl = nextTd.find(".c-name");
            for (var i = 0; i < nextEl.length; i++) {
                var subEl = $(nextEl[i]);
                if (subEl.is("input")) {
                    subEl.val(name);
                } else {
                    subEl.text(name);
                }
            }
            var fromGrid = true;
            handleAfterCodeChange(code, _this, fromGrid);
        });
    }

    async function callTPL99010WFromCodeGrid(_this) {
        if ($(_this).data("get-task-identifer") === true) {
            await handleCodeGridBeforeNextAction(_this);
        }

        var ident = $(_this).data("code-identify");  
        var cdiv = verifyContainerDiv(_this);
        callSearchHelp99010("TPL99010W", cdiv, ident, _this.id);
    }
    /* コード code: end  */

    /* 取引先 customer : start  */
    $(".container-fluid").on("change", ".customer-code", function () {
        var _this = this;
        customerOnchange(_this);
    });

    $(".container-fluid").on("dblclick", ".customer-code", function () {
        //TPL99020W
        var _this = this;
        if (!_this.disabled) {
            callTPL99020W(_this);
        }
    });

    $(".container-fluid").on("keydown", ".customer-code", function (e) {
        var _this = this;
        if (!_this.disabled) {
            // ----Keypress: F12----
            if (e.key === "F12") {
                //TPL99020W
                callTPL99020W(_this);
                return false;
            }
        }
    });

    function customerOnchange(_this) {
        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var sendData = {
            "CustomerType": $(_this).data("customer-type"),
            "Code": code,
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetCustomerByCode", sendData);
        result.done(function (response) {
            var name = response.name;
            $(_this).parent().find(".customer-name ").val(name);
            handleAfterCustomCodeChange(code);
        });
    }

    function callTPL99020W(_this) {
        var csType = $(_this).data("customer-type");
        var cdiv = verifyContainerDiv(_this);
        callSearchHelp99020("TPL99020W", cdiv, csType, _this.id);
    }
    /* 取引先 customer : end  */

    /* 受注番号 order no : start  */
    $(".container-fluid").on("change", ".order-no", function () {
        var _this = this;
        orderNoOnchange(_this);
    });

    function orderNoOnchange(_this) {
        var orderNo = _this.value;
        if (orderNo && _this.maxLength) {
            orderNo = orderNo.padStart(_this.maxLength, '0');
            _this.value = orderNo;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var sendData = {
            "orderNo": orderNo,
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetOrderItemByKey", sendData);
        result.done(function (response) {
            var name = response.name;
            $(_this).parent().find(".order-name ").val(name);
            handleAfterOrderNoChange(orderNo);
        });
    }
    /* 受注番号 order no : end  */

    /* 担当 person : start  */
    $(".container-fluid").on("change", ".person-code", function () {
        var _this = this;
        personOnchange(_this);
    });

    $(".container-fluid").on("dblclick", ".person-code", function () {
        //TPL99040W
        var _this = this;
        if (!_this.disabled) {
            callTPL99040W(_this);
        }
    });

    $(".container-fluid").on("keydown", ".person-code", function (e) {
        var _this = this;
        if (!_this.disabled) {
            // ----Keypress: F12----
            if (e.key === "F12") {
                //TPL99040W
                callTPL99040W(_this);
                return false;
            }
        }
    });

    function personOnchange(_this) {
        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var sendData = {
            "code": code,
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetEmployeeByCode", sendData);
        result.done(function (response) {
            var name = response.name;
            $(_this).parent().find(".person-name").val(name);
            handleAfterPersonCodeChange(code);
        });
    }

    function callTPL99040W(_this) {
        var cdiv = verifyContainerDiv(_this);
        callSearchHelp99040("TPL99040W", cdiv, null, _this.id);
    }
    /* 担当 person : end  */

    /* 担当部署 department : start  */
    $(".container-fluid").on("change", ".pic-code", function () {
        var _this = this;
        picOnchange(_this);
    });

    $(".container-fluid").on("dblclick", ".pic-code", function () {
        //TPL99040W
        var _this = this;
        if (!_this.disabled) {
            callTPL99040W(_this);
        }
    });

    $(".container-fluid").on("keydown", ".pic-code", function (e) {
        var _this = this;
        if (!_this.disabled) {
            // ----Keypress: F12----
            if (e.key === "F12") {
                //TPL99040W
                callTPL99040W(_this);
                return false;
            }
        }
    });

    function picOnchange(_this) {
        var code = _this.value;
        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var sendData = {
            "code": code,
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetDepartmentIC", sendData);
        result.done(function (response) {
            var deptName = response.deptName;
            var picName = response.picName;
            var deptCode = response.deptCode
            $(_this).parent().find(".department-name").val(deptName);
            $(_this).parent().find(".department-code").val(deptCode);
            $(_this).parent().find(".pic-name").val(picName);
            handleAfterDepartmentICChange(code);
        });
    }
    /* 担当部署 department : end  */

    /* 用紙 paper : start  */
        $(".container-fluid").on("change",".paper-code", function () {
        var _this = this;
        paperOnchange(_this);
    });

    $(".container-fluid").on("dblclick", ".paper-code", function () {
        //TPL99050W
        var _this = this;
        if (!_this.disabled) {
            callTPL99050W(_this);
        }
    });

    $(".container-fluid").on("keydown", ".paper-code", function (e) {
        var _this = this;
        if (!_this.disabled) {
            // ----Keypress: F12----
            if (e.key === "F12") {
                //TPL99050W
                callTPL99050W(_this);
                return false;
            }
        }
    });

    function paperOnchange(_this) {
        var code = _this.value;
        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var sendData = {
            "code": code,
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetPaperByCode", sendData);
        result.done(function (response) {
            var name = response.name;
            $(_this).parent().find(".paper-name").val(name);
            handleAfterPaperCodeChange(code);
        });
    }

    function callTPL99050W(_this) {
        var code = _this.value;
        var cdiv = verifyContainerDiv(_this);
        callSearchHelp("TPL99050W", cdiv, code, _this.id);
    }
    /* 用紙 paper : end  */

    /* 用紙 paper grid : start  */
    $(".grid-paper-code").on("change", function () {
        var _this = this;
        paperGridOnchange(_this);
    });

    $(".grid-paper-code").on("dblclick", function () {
        //TPL99050W
        var _this = this;
        if (!_this.disabled) {
            callTPL99050W(_this);
        }
    });

    $(".grid-paper-code").on("keydown", function (e) {
        var _this = this;
        if (!_this.disabled) {
            // ----Keypress: F12----
            if (e.key === "F12") {
                //TPL99050W
                callTPL99050W(_this);
                return false;
            }
        }
    });

    function paperGridOnchange(_this) {
        var code = _this.value;
        var code = _this.value;
        if (code && _this.maxLength) {
            code = code.padStart(_this.maxLength, '0');
            _this.value = code;
        }
        var token = $("input[name=__RequestVerificationToken]").val();
        var sendData = {
            "code": code,
            __RequestVerificationToken: token
        };
        var result = ajaxPost("/Base/GetPaperByCode", sendData);
        result.done(function (response) {
            var name = response.name;
            var nextTd = $(_this).closest("td").next();
            nextTd.attr("title", name)
            var nextEl = nextTd.find(".c-name");
            for (var i = 0; i < nextEl.length; i++) {
                var subEl = $(nextEl[i]);
                if (subEl.is("input")) {
                    subEl.val(name);
                } else {
                    subEl.text(name);
                }
            }
            var fromGrid = true;
            handleAfterPaperCodeChange(code, _this, fromGrid);
        });
    }
    /* 用紙 paper grid : start  */

    function verifyContainerDiv(_this) {
        var cfluid = $(_this).closest(".container-fluid");
        var tpl99010 = $(_this).closest(".tpl99010-p");
        var tpl99020 = $(_this).closest(".tpl99020-p");
        var tpl99040 = $(_this).closest(".tpl99040-p");
        var tpl99050 = $(_this).closest(".tpl99050-p");
        if (cfluid.length > 0) {
            return "container-fluid";
        } else if (tpl99010.length) {
            return "tpl99010-p";
        } else if (tpl99020.length) {
            return "tpl99020-p";
        } else if (tpl99040.length) {
            return "tpl99040-p";
        } else if (tpl99050.length) {
            return "tpl99050-p";
        }
    }

    setDatePicker();
    // only input half size
    $("body").on("keydown keyup change", ".only-half-size", function (e) {
        var regex = /[\u3000-\u303F]|[\u3040-\u309F]|[\u30A0-\u30FF]|[\uFF00-\uFFEF]|[\u4E00-\u9FAF]|[\u2605-\u2606]|[\u2190-\u2195]|\u203B/g;
        var input = $(this).val();
        if (regex.test(input)) {
            $(this).val($(this).val().replace(regex, ''));
        }
    });

    // next tabindex
    $("body").on("keydown", "select", function (e) {
        if (preTabIndex(e) == true) {
            return false;
        }

        if (nextTabIndex(e) == true) {
            return false;
        }
    })
    $("body").on("keydown", "input", function (e) {
        if (e.key === "Enter" && $(this).is("input[type='button']")) {
            $(this).click();
            return false;
        }

        if (e.key === "Enter" && e.keyCode == 229) {
            return false;
        }

        if (preTabIndex(e) == true) {
            return false;
        }

        if (nextTabIndex(e) == true) {
            return false;
        }
    })
    $("body").on("keydown", "button", function (e) {
        if (e.key === "Enter") {
            $(this).click();
            return false;
        }
    })

    $("body").on("keydown", "table tr td", function (e) {
        if (preTabIndex(e) == true) {
            return false;
        }

        if (nextTabIndex(e) == true) {
            return false;
        }
    })

    $("body").on("keydown", ".pagination li", function (e) {
        if (preTabIndex(e) == true) {
            return false;
        }

        if (nextTabIndex(e) == true) {
            return false;
        }
    })

    function preTabIndex(e) {

        if (e.shiftKey && e.key === "Enter") {
            e.preventDefault();
            var check = true;
            var count = 1;
            while (check) {
                var preIndex = $(':focus').prop("tabindex") - count;
                if (preIndex < 0) return true;
                if ($('[tabindex=' + preIndex + ']').is(":disabled") || !$('[tabindex=' + preIndex + ']').length || $('[tabindex=' + preIndex + ']').is(":hidden")) {
                    count++;
                } else {
                    $('[tabindex=' + preIndex + ']').focus();
                    check = false;
                    return true;
                }
            }
        }
        return false;
    }

    function nextTabIndex(e) {
        if (e.key === "Enter") {
            e.preventDefault();
            var current = $(':focus').prop("tabindex");
            if ($('[tabindex=' + current + ']').data("end-tabindex") === true) {
                return true;
            }
            var check = true;
            var count = 1;

            while (check) {
                var nextIndex = $(':focus').prop("tabindex") + count;

                if ($('[tabindex=' + nextIndex + ']').is(":disabled") || !$('[tabindex=' + nextIndex + ']').length || $('[tabindex=' + nextIndex + ']').is(":hidden")) {
                    count++;
                } else {
                    $('[tabindex=' + nextIndex + ']').focus();
                    check = false;
                }

                if ($('[tabindex=' + nextIndex + ']').data("end-tabindex") === true) {
                    check = false;
                }
            }
            return true;
        }
        return false;
    }
});

/**
* Ajax通信前処理(Razor用)
*/
var onBegin = function () {
    // 画面ロック
    screenLock();
};

/**
* Ajax完了処置(Razor用)
*/
var onComplete = function (xhr, status, error) {
    // 画面ロック解除
    unScreenLock();

    ajaxResultProcess(xhr, status, error);
};

/*********************************************************
*   Ajax共通設定
/*********************************************************/
$.ajaxSetup({
    cache: false,   // IEで結果がキャッシュされないようにする
    global: true,   // グローバルハンドラを利用する
    timeout: 30000  // 30秒でタイムアウト
});

// グローバルハンドラを利用して、異常終了時の共通処理を記述
$(document).ajaxError(function (event, xhr, settings, err) {
    /**
    * CSV出力時の列名不正エラーを検出しない苦肉の策
    * 1期では間に合わなかったが、2期では列名不正エラーの出力方法を見直すこと
    **/
    if (xhr.responseText != null && xhr.responseText.indexOf('MSG_CM_ERR_021') > 0) { return false; }

    var redirectUrl = xhr.getResponseHeader("Location");

    switch (xhr.status) {
        case 440:
            // ステータスコード440ならセッションタイムアウト
            window.location.href = "/SessionTimeout/";
            break;
        case 401:
            // ステータスコード401ならユーザ認証エラー
            window.location.href = "/";
            break;
        case 302:
            location.reload;
        case 0:
            if (xhr.statusText == 'timeout') {
                // Ajaxタイムアウトメッセージ
                return false;
                break;
            }
            if (xhr.statusText == 'canceled') {
                return false;
                break;
            }
        default:
            if (xhr.status === 200 || xhr.status === 500) {
                window.location.href = "/TPL00010";
                console.log(err);
                alert('You can not connect to the system. Please log in again.\n status:' + xhr.status + '　errorMessage:' + xhr.statusText);
                xhr.abort();
                break;
            }
            // その他のエラー
            if (redirectUrl != null) {
                // リダイレクトURLが設定されていれば追跡
                window.location.href = redirectUrl;
            } else {
                // メッセージダイアログを表示
                console.log(err);
                alert('An error has occurred. Please contact the person in charge.\n status:' + xhr.status + '　errorMessage:' + xhr.statusText);
                xhr.abort();
                break;
            }
    }
});

$(document).ajaxStart(function () {
    screenLock();
});
// グローバルハンドラを利用して、通信終了時の共通処理を記述
$(document).ajaxStop(function () {
    unScreenLock();
});

$(document).ajaxSuccess(function (event, xhr, settings) {
    var redirectUrl = xhr.getResponseHeader("Location");

    // 正常終了(200)
    if (xhr.status == 200) {
        if (redirectUrl != null) {
            // リダイレクトURLが設定されていれば追跡
            window.location.href = redirectUrl;
        }
    }
});

/***************************************************
* 通常のJsonをポストしてJsonを返すajax処理
***************************************************/
function ajaxGet(url, sendData) {
    // Ajax処理実行
    var result = $.ajax({
        type: 'GET',
        dataType: 'json',
        url: url,
        data: sendData,
        async: false
    })

    return result;
}

function downloadFileAttach(attachid) {
    var url = "/Base/DownloadFile?attachId=" + attachid;
    $.fileDownload(url, {
        httpMethod: 'GET',
        successCallback: function (url) {
        },
        failCallback: function (responseHtml, url, error) {
            try {
                var response = JSON.parse(responseHtml);
                setMessageInfo(response.Message);
                typeError = response.Data.TypeError;
                // Open error and add element error focus
                SetErrorFocus(response.Focus, typeError);
            } catch (e) {
                window.location.href = "/TPL00010"
            }
        }
    });
}

function ajaxGetAsync(url, sendData) {
    // Ajax処理実行
    var result = $.ajax({
        type: 'GET',
        dataType: 'json',
        url: url,
        data: sendData,
        async: true
    })

    return result;
}

/***************************************************
* 通常のJsonをポストしてJsonを返すajax処理
***************************************************/
function ajaxPost(url, sendData) {

    // Ajax処理実行
    var result = $.ajax({
        type: 'post',
        dataType: 'json',
        url: url,
        data: sendData,
        async: true
    });

    return result;
}

/***************************************************
* Jsonをポストして何も返さないAjax処理
* アクションが何も返さない場合、dataType を未指定にしておかないとAjaxErrorとなってしまう
***************************************************/
function ajaxNoReply(url, sendData) {

    // Ajax処理実行
    var result = $.ajax({
        type: 'post',
        contentType: 'application/json', // リクエストの Content-Type
        url: url,
        data: JSON.stringify(sendData),
        async: true
    });

    return result;
}


/****************************************************************************************************
* フォームデータをそのままポストしたいときのajax処理
* Json.stringify(sendData) で シリアライズ化したデータを変換すると、配列周りの name 処理が書き換えられてしまい上手く渡せない
* Json.api と .NET Core の相性の問題なので別関数で対応する
* 利用する場合はフォームデータを $('form') で取得してやればいい
****************************************************************************************************/
function ajaxPostForm(url, formData) {
    // Ajax実行処理
    var result = $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        data: formData.serialize(),       // シリアライズ化しないとajaxフォームがモデルバインドされない
        async: true
    });
    return result;
}

/***************************************************
 * 画面ロック
 **************************************************/
function screenLock() {
    // すでにロード画面が呼ばれていたら追加しない（２重ロック防止）
    if ($('#loading').length > 0) { return; }
    var loadingHtml = "";
    loadingHtml += "<div id='loading' >";
    loadingHtml += "    <div id='screen_lock'></div>";
    loadingHtml += "    <div class='spinner-border' role='status'>";
    loadingHtml += "    </div>";
    loadingHtml += "</div>";
    $('body').append(loadingHtml);
}

/***************************************************
 * 画面ロック解除
 **************************************************/
function unScreenLock() {
    if ($('#loading').length) {
        $('#loading').remove();
    }
}

/***********************************************
モーダルダイアログ関連
***********************************************/
function showConfirm(title, body) {
    var deferred = $.Deferred();
    var dlg = "";
    // 改行コードで分割
    var arr = body.split(/\r\n|\n/);

    // モーダルダイアログ 
    dlg += "  <div class='modal' id='confirmDialog' tabindex='-1' role='dialog' aria-labelledby='staticModalLabel' aria-hidden='true' data-show='true' data-keyboard='false' data-backdrop='static'>";
    dlg += "    <div class='modal-dialog'>";
    dlg += "      <div class='modal-content'>";
    dlg += "        <div class='modal-header modal-header-confirm'>";
    dlg += "          <button type='button' class='close' data-dismiss='modal'>";
    dlg += "            <span aria-hidden='true'>&#215;</span><span class='sr-only'>閉じる</span>";
    dlg += "          </button>";
    dlg += "          <span class='modal-title glyphicon glyphicon-question-sign' aria-hidden='true'></span>";
    dlg += "          " + title + "";
    dlg += "          </span>";
    dlg += "        </div>"; //<!-- /modal-header -->
    dlg += "        <div class='modal-body'>";
    for (var i = 0; i < arr.length; i++) {
        dlg += "<p>" + arr[i] + "</p>"
    }
    dlg += "          <div></div>";
    dlg += "        </div>";
    dlg += "        <div class='modal-footer modal-footer-confirm'>";
    dlg += "          <button type='button' class='btn btn-default' data-dismiss='modal'>キャンセル</button>";
    dlg += "          <button type='button' class='btn btn-primary'>OK</button>";
    dlg += "        </div>";
    dlg += "      </div>"; // <!-- /.modal-content -->
    dlg += "    </div>"; // <!-- /.modal-dialog -->
    dlg += "  </div>"; //  <!-- /.modal -->

    $("#confirmDialog").remove();
    $('body').append(dlg);

    var $element = $("#confirmDialog");
    $element
        .data("resolve", false) // resolve するかどうかのフラグ
        //「はい」ボタンのクリックイベント
        .on("click", ".btn-primary", function () {
            // resolve フラグを立てて、モーダルを閉じる
            $element
                .data("resolve", true)
                .modal("hide");
        })
        // モーダルの非表示イベント
        .one("hidden.bs.modal", function () {
            $(this).off("click", ".btn-primary");

            // resolveフラグをみて resolve か reject
            if ($(this).data("resolve")) {
                deferred.resolve();
            } else {
                deferred.reject();
            }
        })
        .modal({ show: true });

    return deferred.promise();
}

/***********************************************
ファイルアップロード
***********************************************/
// ファイル選択時にファイル名を表示する
$(document).on('change', ':file', function () {
    var input = $(this);
    var numFiles = input.get(0).files ? input.get(0).files.length : 1;
    var label;
    label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.parent().parent().next(':text').val(label);
});


/***********************************************
スマホ、タブレット判定
***********************************************/
/**
 *  ユーザーのデバイスを返す
 *  
 *  @return     スマホ(sp)、タブレット(tab)、その他(other)
 *
 */
var getDevice = (function () {
    var ua = navigator.userAgent;
    // 支給するipadの中にはMacintoshが含まれていたので、条件にMacintoshを含む
    if (ua.indexOf('iPhone') > 0 || ua.indexOf('iPod') > 0 || ua.indexOf('Android') > 0 && ua.indexOf('Mobile') > 0) {
        return 'sp';
    } else if (ua.indexOf('iPad') > 0 || ua.indexOf('Android') > 0 || ua.indexOf('Macintosh') > 0) {
        return 'tab';
    } else {
        return 'other';
    }

})();

/***********************************************
datepickerの基本設定
***********************************************/
function setDatePicker() {
    // datepicker
    if ($(".datepicker-date").length) {
        $(".only-date").datepicker({
            language: "en",
            autoclose: true,
            todayHighlight: true,
            clearBtn: true,
            language: "ja"
        });

        $(".only-month").datepicker({
            language: "en",
            format: "yyyy/mm",
            minViewMode: 1,
            autoclose: true,
            todayHighlight: true,
            clearBtn: true,
            language: "ja"
        });

        $(".datepicker-date").on("keydown", function (e) {
            if (e.keyCode === 8 || e.keyCode === 46) {
                $(this).val("");
            } else if (e.keyCode !== 9 && e.keyCode !== 13) {
                e.preventDefault();
            }
        });

        $(".container-fluid").scroll(function () {
            $(".datepicker-date").datepicker('hide');
        });

        $(".datepicker-date").click(function () {
            $(this).datepicker('show');
        });
    }
}

/*******************************************************************
    スクロール操作
*******************************************************************/
function scrollFocus(selector) {
    $('html, body').animate({
        scrollTop: ($(selector).first().offset().top - $(".header").height() - 100)
    }, 500);
}

function modalScrollFocus(modalId, selector) {
    var scroll = $('#' + modalId + ' .modal-body').scrollTop();
    var bodyTop = $('#' + modalId + ' .modal-body').offset().top;
    var target = $('#' + modalId + ' ' + selector).first().offset().top;

    var distance = scroll + target - bodyTop - 100;

    $('#' + modalId + ', .modal-body').animate({
        scrollTop: (distance)
    }, 500);
}

/*******************************************************************
    インフォメッセージ関連
*******************************************************************/
// エラーメッセージ表示欄をすべてクリアする
function clearInfoMsgs() {
    $('#info-msg-list').remove();
}
// 任意のメッセージをエラーメッセージ表示欄に追加する
function addInfoMsg(msg) {
    addHtml = '<div>' + msg + '</div>'
    $('#info-msg-list').append(addHtml);
}

// ajaxで取得したエラーメッセージjson文字列を走査し、
// エラーメッセージ表示欄に追加する
// 追加したメッセージ数を返す
function addInfoMsgJson(json) {
    var data = JSON.parse(json);
    var count = 0;
    Object.keys(data).forEach(function (key) {
        addInfoMsg(data[key]);
        count++;
    });
    return count;
}

/*******************************************************************
    エラーメッセージ関連
*******************************************************************/
// エラーメッセージ表示欄をすべてクリアする
function clearErrMsgs() {
    $('#err-msg-list').html('');
}
// 任意のメッセージをエラーメッセージ表示欄に追加する
function addErrMsg(msg) {
    addHtml = '<div>' + msg + '</div>'
    $('#err-msg-list').append(addHtml);
}

// ajaxで取得したjsonデータからを
// エラーメッセージを走査し、表示する
// 追加したメッセージ数を返す
function addErrMsgJson(json) {
    var data = json.errMsgs;
    if (data.length == 0) {
        console.log("エラーメッセージはありませんでした。");
    }
    var count = 0;
    Object.keys(data).forEach(function (key) {
        addErrMsg(data[key]);
        count++;
    });
    return count;
}

/*******************************************************************
    モーダル用エラーメッセージ関連
*******************************************************************/
// エラーメッセージ表示欄をすべてクリアする
function clearModalErrMsgs(modalId) {
    $('#' + modalId + ' #err-msg-list').html('');
}
// 任意のメッセージをエラーメッセージ表示欄に追加する
function addModalErrMsg(modalId, msg) {
    // モーダルウィンドウに <ul id="err-msg-list"> がなければ追加
    if ($('#' + modalId + ' #err-msg-list').length == 0) {
        $('<ul>')
            .addClass('text-danger')
            .attr('id', 'err-msg-list')
            .prependTo('#' + modalId + ' .modal-body');
    }

    addHtml = '<li>' + msg + '</li>'
    $('#' + modalId + ' #err-msg-list').append(addHtml);
}

// ajaxで取得したエラーメッセージjson文字列を走査し、
// エラーメッセージ表示欄に追加する
// 追加したメッセージ数を返す
function addModalErrMsgJson(modalId, json) {
    var data = json.errMsgs;
    var count = 0;
    Object.keys(data).forEach(function (key) {
        addModalErrMsg(modalId, data[key]);
        count++;
    });
    return count;
}

/*********************************************************************
    String.Format的な簡易テンプレート置換関数
*********************************************************************/

var Format = function (template, replacement) {
    if (typeof replacement != "object") // 可変長引数時はreplacementを詰め替え
    {
        replacement = Array.prototype.slice.call(arguments, 1);
    }
    return template.replace(/\{(.+?)\}/g, function (m, c) {
        return (replacement[c] != null) ? replacement[c] : m
    });
}

/*********************************************************************
    主要な悪さをしそうなキー操作を無効化制御
*********************************************************************/
$(function () {
    //------------------------
    // jQueryキー制御サンプル
    // return値falseによりキーキャンセル
    //------------------------
    $(document).keydown(function (event) {
        // クリックされたキーのコード
        var keyCode = event.keyCode;
        // Ctrlキーがクリックされたか (true or false)
        var ctrlClick = event.ctrlKey;
        // Altキーがクリックされたか (true or false)
        var altClick = event.altKey;
        // キーイベントが発生した対象のオブジェクト
        var obj = event.target;

        // ファンクションキーを制御する
        // 制限を掛けたくない場合は対象から外す
        if (keyCode == 112 // F1キーの制御
            || keyCode == 113 // F2キーの制御
            || keyCode == 114 // F3キーの制御
            || keyCode == 115 // F4キーの制御
            // || keyCode == 116 // F5キーの制御
            || keyCode == 117 // F6キーの制御
            || keyCode == 122 // F11キーの制御
            // || keyCode == 123 // F12キーの制御
        ) {
            return false;
        }

        // Alt + ←を制御する
        if (altClick && (keyCode == 37 || keyCode == 39)) {
            return false;
        }

        // Ctrl + Nを制御する
        if (ctrlClick && keyCode == 78) {
            return false;
        }
    });
});

// set tab 
function openTabFunc() {
    // listen open tab
    var sessionStorage_transfer = function () {
        var hrefTab = localStorage.getItem("tab-opened");
        if (hrefTab !== null && hrefTab !== "") {
            var urlTab = window.location.pathname.substring(1, window.location.pathname.length);
            if (urlTab.indexOf(hrefTab) !== -1 || hrefTab.indexOf(urlTab) !== -1) {
                window.close();
                localStorage.removeItem("tab-opened");
            }
        }
    };

    // listen for changes to localStorage
    if (window.addEventListener) {
        window.addEventListener("storage", sessionStorage_transfer, false);
    } else {
        window.attachEvent("onstorage", sessionStorage_transfer);
    };
}

/*********************************************************************
    datatable
*********************************************************************/
function convertTableToDataTable() {
    $('table').colResizable({
        liveDrag: true
    });
    // Set focus span
    $("table tr td span").click(function () {
        $(this).parent().focus();
    });
}

/*********************************************************************
    addZeroBefore
*********************************************************************/
function addZeroBefore() {
    var code = event.srcElement.value;
    if (code && event.srcElement.maxLength) {
        code = code.padStart(event.srcElement.maxLength, '0');
        event.srcElement.value = code;
    }
    return false;
}

