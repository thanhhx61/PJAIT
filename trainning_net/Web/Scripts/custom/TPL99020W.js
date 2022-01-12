function callSearchHelp99020(path, pid, code, tid) {
    $("#" + tid).addClass("tpl99020-pitem");
    displaySearchHelp99020(path, pid, code);
}

function displaySearchHelp99020(path, pid, code) {
    var url = "/tplsearchhelp/" + path;
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "Code": code,
        "pageCurrent": $(".tpl99020-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        if (response.Status == "OK") {
            $(".tpl99020-p .popup-div").modal('hide');
            $(".tpl99020-p").empty();
            $(".tpl99020-p").html(response.DataString);
            $(".tpl99020-p #parentId").val(pid);
            $(".tpl99020-p #code").val(code);
            $(".tpl99020-p .combobox-cls-p").val(code);
            $(".tpl99020-p .popup-div").modal({ show: true });
            if (pid) {
                disableParentScreen99020(pid);
            }
            setTimeout(function () {
                $(".tpl99020-p .name-search-p").focus();
            }, 500);
        } else {
            setMessageInfo(response.Message);
        }
    });
}

function searchHpTpl99020() {
    var isDisablebtn = $(".tpl99020-p .select-btn").is(":disabled");
    var url = "/tplsearchhelp/SearchTPL99020/";
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "Code": $(".tpl99020-p #code").val(),
        "NameSearch": $("input[name=NameSearch]").val(),
        "pageCurrent": $(".tpl99020-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        $(".tpl99020-p .tpl99020-table-con").empty();
        $(".tpl99020-p .tpl99020-table-con").html(response.DataString);
        if (response.Status == "OK") {
            $(".tpl99020-p .select-btn").removeAttr("disabled");
            $('.tpl99020-table-con .help-first-el').focus();
        } else {
            if (!isDisablebtn) {
                $(".tpl99020-p .select-btn").removeAttr("disabled");
            }
            inputName = "name-search-p";
            setMessageInfo(response.Message);
        }
    });
}

function disableParentScreen99020(pid) {
    if (pid !== "container-fluid") {
        $("." + pid).hide();
    }
    var nodes = document.getElementsByClassName(pid)[0].getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].disabled) {
            nodes[i].classList.add("tpl99020-disabled");
        } else {
            nodes[i].disabled = true;
        }
    }
}

$(".tpl99020-p").on("click", ".p-tpl-search", function () {
    //$("input[name='POnLoad']").val("false");
    $(".tpl99020-p input[name='pageCurrent']").val("1");
    searchHpTpl99020();
});

function ajaxCall2(pageCurrent) {
    $(".tpl99020-p input[name='pageCurrent']").val(pageCurrent);
    searchHpTpl99020();
}

$(".tpl99020-p").on("click", ".p-tpl-close", function () {
    var pclass = $(".tpl99020-p #parentId").val();
    if (pclass !== "container-fluid") {
        $("." + pclass).show();
    }
    //$(".tpl99020-pitem").val("");
    //$(".tpl99020-pitem").trigger("change");
    $(".tpl99020-pitem").removeClass("tpl99020-pitem");
    closePopup99020();
    $('.tpl99020-p .popup-div').modal('hide');
    $(".tpl99020-p .popup-div").empty();
});

function closePopup99020() {
    setEnableToParent99020();
    $(".tpl99020-p .popup-div").data("resolve", true).modal("hide");
}

function setEnableToParent99020() {
    var pclass = $(".tpl99020-p #parentId").val();
    var nodes = document.getElementsByClassName(pclass)[0].getElementsByTagName('*');

    for (var i = 0; i < nodes.length; i++) {
        if (!nodes[i].classList.contains("tpl99020-disabled")) {
            nodes[i].disabled = false;
        } else {
            nodes[i].classList.remove("tpl99020-disabled");
        }
    }
}

$(".tpl99020-p").on("click", ".select-btn", function () {
    var _checkboxes = $(".tpl99020-p input:checkbox:checked:visible");
    if (_checkboxes.length === 0) {
        setMessageInfo("対象行を選択してください。");
        inputName = "select-btn";
        return;
    }
    if (_checkboxes.length > 1) {
        setMessageInfo("対象行は1行まで選択できます。");
        inputName = "select-btn";
        return;
    }
    var _checkbox = $(_checkboxes[0]);
    var id = _checkbox.data("id");
    closePopup99020();
    $(".tpl99020-pitem").val(id);
    $(".tpl99020-pitem").trigger("change");
    $(".tpl99020-pitem").focus();
    $(".tpl99020-pitem").removeClass("tpl99020-pitem");
    $(".tpl99020-p .popup-div").empty();
});

function checkTableFocused() {
    return $(":focus").is("table td");
}

function handleCloseButon() {
    if (inputName) {
        setTimeout(function () {
            $("." + inputName).focus();
        }, 10);
    }
}