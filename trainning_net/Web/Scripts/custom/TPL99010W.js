function callSearchHelp99010(path, pid, ident, tid) {
    $(".tpl99010-p").empty();
    $("#" + tid).addClass("tpl99010-pitem");
    displaySearchHelp99010(path, pid, ident); 
}

function displaySearchHelp99010(path, pid, ident) {
    var url = "/tplsearchhelp/" + path;
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "Ident": ident,
        "pageCurrent": $(".tpl99010-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        $(".tpl99010-p .popup-div").modal('hide');
        $(".tpl99010-p").empty();
        $(".tpl99010-p").html(response.DataString);
        $(".tpl99010-p #parentId").val(pid);
        $(".tpl99010-p #code").val(ident);
        $(".tpl99010-p .popup-div").modal({ show: true });
        if (response.Status == "OK") {
            $(".tpl99010-tbl .help-first-el").focus();
        } else {
            inputName = "p-tpl-close";
            setMessageInfo(response.Message);
        }

        if (pid) {
            disableParentScreen99010(pid);
        }
    });
}

function searchHpTpl99010() {
    var url = "/tplsearchhelp/SearchTPL99010/";
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        "Ident": $(".tpl99010-p #code").val(),
        "pageCurrent": $(".tpl99010-p input[name='pageCurrent']").val(),
        __RequestVerificationToken: token
    };
    var result = ajaxPost(url, sendData);
    result.done(function (response) {
        if (response.Status == "OK") {
            $(".tpl99010-p .modal-body").empty();
            $(".tpl99010-p .modal-body").html(response.DataString);
            $(".tpl99010-tbl .help-first-el").focus();
        } else {
            setMessageInfo(response.Message);
        }
    });
}

function disableParentScreen99010(pid) {
    if (pid !== "container-fluid") {
        $("." + pid).hide();
    }
    var nodes = document.getElementsByClassName(pid)[0].getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].disabled) {
            nodes[i].classList.add("tpl99010-disabled");
        } else {
            nodes[i].disabled = true;
        }
    }
}

$(".tpl99010-p").on("click", ".p-tpl-search", function () {
    $("input[name='POnLoad']").val("false");
    $(".tpl99010-p input[name='pageCurrent']").val("1");
    searchHpTpl99010();
});

function ajaxCall1(pageCurrent) {
    $(".tpl99010-p input[name='pageCurrent']").val(pageCurrent)
    searchHpTpl99010();
}

$(".tpl99010-p").on("click", ".p-tpl-close", function () {
    var pclass = $(".tpl99010-p #parentId").val();
    if (pclass !== "container-fluid") {
        $("." + pclass).show();
        //$('table').colResizable({ disable: true });
        var pColResCls = ".popup-model" + " ." + pclass + " table";
        $(pColResCls).colResizable({
            liveDrag: true,
            //disabledColumns: [0, 1],
        });
    }
    closePopup99010();
    //$(".tpl99010-pitem").val("");
    //$(".tpl99010-pitem").trigger("change");
    $(".tpl99010-pitem").removeClass("tpl99010-pitem");
    $(".tpl99010-p .popup-div").empty();
});

function closePopup99010() {
    setEnableToParent99010();
    $(".tpl99010-p .popup-div").data("resolve", true).modal("hide");
}

function setEnableToParent99010() {
    var pclass = $(".tpl99010-p #parentId").val();
    var nodes = document.getElementsByClassName(pclass)[0].getElementsByTagName('*');

    for (var i = 0; i < nodes.length; i++) {
        if (!nodes[i].classList.contains("tpl99010-disabled")) {
            nodes[i].disabled = false;
        } else {
            nodes[i].classList.remove("tpl99010-disabled")
        }
    }
}

$(".tpl99010-p").on("click", ".select-btn", function () {
    var _checkboxes = $(".tpl99010-p input:checkbox:checked:visible");
    if (_checkboxes.length === 0) {
        //TODO message & focus
        setMessageInfo("対象行を選択してください。");
        inputName = "select-btn";
        return;
    }
    if (_checkboxes.length > 1) {
        //TODO message & focus
        setMessageInfo("対象行は1行まで選択できます。");
        inputName = "select-btn";
        return;
    }

    var pclass = $(".tpl99010-p #parentId").val();
    if (pclass !== "container-fluid") {
        $("." + pclass).show();
        //$('table').colResizable({ disable: true });
        var pColResCls = ".popup-model" + " ." + pclass + " table";
        $(pColResCls).colResizable({
            liveDrag: true,
            //disabledColumns: [0, 1],
        });
    }
    var _checkbox = $(_checkboxes[0]);
    var id = _checkbox.data("id");
    closePopup99010();
    $(".tpl99010-pitem").val(id);
    $(".tpl99010-pitem").trigger("change");
    $(".tpl99010-pitem").focus();
    $(".tpl99010-pitem").removeClass("tpl99010-pitem");
    $(".tpl99010-p .popup-div").empty();
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

$(".popup-model table tr td span").click(function () {
    $(this).parent().focus();
});
