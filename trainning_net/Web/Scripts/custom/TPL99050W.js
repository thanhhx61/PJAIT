function callSearchHelp(path, pid, code, tid) {
    $("#" + tid).addClass("tpl99050-pitem");
    displaySearchHelp(path, pid);
}

function displaySearchHelp(path, pid) {
    var url = "/tplsearchhelp/" + path;
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "ProducerCode": "",
        "pageCurrent": $(".tpl99050-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        if (response.Status == "OK") {
            $(".tpl99050-p .popup-div").modal('hide');
            $(".tpl99050-p").empty();
            $(".tpl99050-p").html(response.DataString);
            $(".tpl99050-p #parentId").val(pid);
            $(".tpl99050-p .popup-div").modal({ show: true });
            if (pid) {
                disableParentScreen(pid);
            } 
            setTimeout(function () {
                $(".tpl99050-p input[name='ProductType']").focus();
            }, 500);
        } else {
            setMessageInfo(response.Message);
        }
    });
}

function searchHp() {
    var isDisablebtn = $(".tpl99050-p .select-btn").is(":disabled");
    var url = "/tplsearchhelp/SearchTPL99050/";
    var token = $("input[name=__RequestVerificationToken]").val();
    var code = $(".tpl99050-p input[name=ProducerCode]").val();
    var ptype = $(".tpl99050-p input[name=ProductType]").val();
    var names = $(".tpl99050-p input[name=NameSearch]").val();
    var sendData = {
        "ProducerCode": code,
        "ProductType": ptype,
        "NameSearch": names,
        "pageCurrent": $(".tpl99050-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        $(".tpl99050-table-con").empty();
        $(".tpl99050-table-con").html(response.DataString);
        if (response.Status == "OK") {
            $(".tpl99050-p .select-btn").removeAttr("disabled");
            $(".tpl99050-tbl .help-first-el").focus();
        } else {
            if (!isDisablebtn) {
                $(".tpl99050-p .select-btn").removeAttr("disabled");
            }
            inputName = "header-first-ele";
            setMessageInfo(response.Message);
        }
    });
}

function disableParentScreen(pid) {
    var nodes = document.getElementsByClassName(pid)[0].getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].disabled) {
            nodes[i].classList.add("tpl99050-disabled");
        } else {
            nodes[i].disabled = true;
        }
    }
}

$(".tpl99050-p").on("click", ".p-tpl-search", function () {
    $("input[name='POnLoad']").val("false");
    $(".tpl99050-p input[name='pageCurrent']").val("1");
    searchHp();
});

function ajaxCall5(pageCurrent) {
    $(".tpl99050-p input[name='pageCurrent']").val(pageCurrent);
    searchHp();
}

$(".tpl99050-p").on("click", ".p-tpl-close", function () {
    closePopup();
    //$(".tpl99050-pitem").val("");
    //$(".tpl99050-pitem").trigger("change");
    $(".tpl99050-pitem").removeClass("tpl99050-pitem");
    $(".tpl99050-p .popup-div").empty();
});

function closePopup() {
    setEnableToParent();
    $(".tpl99050-p .popup-div").data("resolve", true).modal("hide");
}

function setEnableToParent() {
    var pclass = $(".tpl99050-p #parentId").val();
    var nodes = document.getElementsByClassName(pclass)[0].getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        if (!nodes[i].classList.contains("tpl99050-disabled")) {
            nodes[i].disabled = false;
        } else {
            nodes[i].classList.remove("tpl99050-disabled");
        }
    }
}

$(".tpl99050-p").on("click", ".select-btn", function () {
    var _checkboxes = $(".tpl99050-p input:checkbox:checked:visible");
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
    closePopup();
    $(".tpl99050-pitem").val(id);
    $(".tpl99050-pitem").trigger("change");
    $(".tpl99050-pitem").focus();
    $(".tpl99050-pitem").removeClass("tpl99050-pitem");
    $(".tpl99050-p .popup-div").empty();
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