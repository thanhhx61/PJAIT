function callSearchHelp99040(path, pid, code, tid) {
    $("#" + tid).addClass("tpl99040-pitem");
    displaySearchHelp99040(path, pid, code);
}

function displaySearchHelp99040(path, pid, code) {
    var url = "/tplsearchhelp/" + path;
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "DepartmentCode": code,
        "pageCurrent": $(".tpl99040-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        if (response.Status == "OK") {
            $(".tpl99040-p .popup-div").modal('hide');
            $(".tpl99040-p").empty();
            $(".tpl99040-p").html(response.DataString);
            $(".tpl99040-p #parentId").val(pid);
            $(".tpl99040-p .popup-div").modal({ show: true });
            if (pid) {
                disableParentScreen99040(pid);
            }
            setTimeout(function () {
                $(".tpl99040-p .combobox-cls-p").focus();
            }, 500);
        } else {
            setMessageInfo(response.Message);
        }
    });
}

function searchHpTpl99040() {
    var isDisablebtn = $(".tpl99040-p .select-btn").is(":disabled");
    var url = "/tplsearchhelp/SearchTPL99040/";
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "DepartmentCode": $(".tpl99040-p .combobox-cls-p").val(),
        "NameSearch": $("input[name=NameSearch]").val(),
        "pageCurrent": $(".tpl99040-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        $(".tpl99040-p .tpl99040-table-con").empty();
        $(".tpl99040-p .tpl99040-table-con").html(response.DataString);
        if (response.Status == "OK") {
            $(".tpl99040-p .select-btn").removeAttr("disabled");
            $(".tpl99040-p .help-first-el").focus();
        } else {
            if (!isDisablebtn) {
                $(".tpl99040-p .select-btn").removeAttr("disabled");
            }
            inputName = "combobox-cls-p";
            setMessageInfo(response.Message);
        }
    });
}

function disableParentScreen99040(pid) {
    if (pid !== "container-fluid") {
        $("." + pid).hide();
    }
    var nodes = document.getElementsByClassName(pid)[0].getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].disabled) {
            nodes[i].classList.add("tpl99040-disabled");
        } else {
            nodes[i].disabled = true;
        }
    }
}

$(".tpl99040-p").on("click", ".p-tpl-search", function () {
    $("input[name='POnLoad']").val("false");
    $(".tpl99040-p input[name='pageCurrent']").val("1")
    searchHpTpl99040();
});

function ajaxCall4(pageCurrent) {
    $(".tpl99040-p input[name='pageCurrent']").val(pageCurrent)
    searchHpTpl99040();
}

$(".tpl99040-p").on("click", ".p-tpl-close", function () {
    closePopup99040();
    //$(".tpl99040-pitem").val("");
    //$(".tpl99040-pitem").trigger("change");
    $(".tpl99040-pitem").removeClass("tpl99040-pitem");
    $(".tpl99040-p .popup-div").empty();
});

function closePopup99040() {
    setEnableToParent99040();
    $(".tpl99040-p .popup-div").data("resolve", true).modal("hide");
}

function setEnableToParent99040() {
    var pclass = $(".tpl99040-p #parentId").val();
    var nodes = document.getElementsByClassName(pclass)[0].getElementsByTagName('*');

    for (var i = 0; i < nodes.length; i++) {
        if (!nodes[i].classList.contains("tpl99040-disabled")) {
            nodes[i].disabled = false;
        } else {
            nodes[i].classList.remove("tpl99040-disabled")
        }
    }
}

$(".tpl99040-p").on("click", ".select-btn", function () {
    var _checkboxes = $(".tpl99040-p input:checkbox:checked:visible");
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
    closePopup99040();
    $(".tpl99040-pitem").val(id);
    $(".tpl99040-pitem").trigger("change");
    $(".tpl99040-pitem").focus();
    $(".tpl99040-pitem").removeClass("tpl99040-pitem");
    $(".tpl99040-p .popup-div").empty();
});

function checkTableFocused() {
    return $(":focus").is("table td");
}

function handleCloseButon() {
    if (inputName && inputName !== "") {
        setTimeout(function () {
            $("." + inputName).focus();
        }, 10);
    }
}