$(document).ready(function () {
    $(function () {
        convertTableToDataTable();
    });
});

function handleAfterPersonCodeChange(code) {
    //TODO
}
function handleAfterCustomCodeChange(code) {
     //TODO
}
function handleAfterDepartmentICChange(code) {
    //TODO
}

var idFocus = "";
var KEY_TAB = 9;
var KEY_ENTER = 13;
var typeError = 0;
var currentRecord = -1;
var tpl04020OrderNo = "";
$(".tpl04020 #Customer").addClass("frmheader");
$(".tpl04020 #StartDate").addClass("frmheader");
$(".tpl04020 #EndDate").addClass("frmheader");
$(".tpl04020 #OrderNo").focus();

$(".tpl04020 #btnSearch").off().on("click",function () {
    idFocus = "#btnSearch";
    $('input[name="checkSearch"]').val("True");
    $('#productCode').prop("disabled", false);
    //// Call ajax Load data for table
    LoadDataTable();
});

// Load data for table
function LoadDataTable() {
    ajaxPostForm("/TPL04020/Search", $("#orderFrm")).done(function (response) {
        if (response.Status == "ERR") {
            typeError = response.Data.TypeError;
            idFocus = "#" + response.Focus;
            if (response.Focus == null) {
                idFocus = "#btnSearch";
            }

            setMessageInfo(response.Message);
            $('input[name="checkSearch"]').val("False");
        }
        if (response.Status == "OK") {
            $("#table-container").empty();
            $("#table-container").html(response.DataString);
            if ($('input[name="checkSearch"]').val() == "True") {
                disableControl(true);
            }
            setTimeout(function () {
                $(".left-ver table .td-first-cb").focus();
                currentRecord = 0;
            }, 10);
            typeError = 0;
        }
        $('#productCode').prop("disabled", true)
    });
}

$("#table-container").on("click", "table tbody tr", function () {
    currentRecord = $(this).index()

    if ($(this).hasClass('selected')) {
        $('#table-container .left-ver table tbody tr:eq(' + currentRecord + ')').removeClass('selected');
        $('#table-container .right-ver table tbody tr:eq(' + currentRecord + ')').removeClass('selected');
    }
    else {
        $('#table-container table tbody tr.selected').removeClass('selected');
        $('#table-container .left-ver table tbody tr:eq(' + currentRecord + ')').addClass('selected');
        $('#table-container .right-ver table tbody tr:eq(' + currentRecord + ')').addClass('selected');
    }
});


// ----Start Export CSV----
$(".tpl04020 #btnCSV").off().on("click", function () {
    idFocus = "#btnCSV";
    if ($('input[name="checkSearch"]').val() == "True") {
        disableControl(false);
    }
    $('#productCode').prop("disabled", false);
    screenLock();
    var url = "/TPL04020/ExportCSV";
    $("#orderFrm").attr("action", url);

    $.fileDownload($("#orderFrm").prop("action"), {
        httpMethod: "POST",
        data: $("#orderFrm").serialize(),
        successCallback: function (url) {
            unScreenLock();
        },
        failCallback: function (responseHtml, url, error) {
            unScreenLock();
            try {
                var response = JSON.parse(responseHtml);
                typeError = response.Data.TypeError;
                setMessageInfo(response.Message);
            } catch (e) {
                responseHtml = responseHtml.substr(responseHtml.indexOf("{"), responseHtml.lastIndexOf("}") - responseHtml.indexOf("{") + 1);
                var response = JSON.parse(responseHtml);
                if (response.Focus !== null && response.Focus !== "") {
                    idFocus = "#" + response.Focus;
                }
                if (response.Message == "" || response.Message == null)
                    window.location.href = "/TPL04020";

                setMessageInfo(response.Message);
                disableControl(false);
            }
        }
    });

    if ($('input[name="checkSearch"]').val() == "True") {
        disableControl(true);
    }
    $('#productCode').prop("disabled", true);
});
// ----End Export CSV----

function ajaxCall(pageCurrent) {
    disableControl(false);
    $('#productCode').prop("disabled", false);
    $('input[name ="pageCurrent"]').remove();
    var input = document.createElement("input");
    input.type = "hidden";
    input.name = "pageCurrent";
    input.value = pageCurrent;
    input.id = "pageCurrent";
    $("#orderFrm").append(input);

    ajaxPostForm("/TPL04020/Search", $("#orderFrm")).done(function (response) {
        if (response.Status == "OK") {
            $("#table-container").empty();
            $("#table-container").html(response.DataString);
            $("#table-container .left-ver table td:eq(0)").focus();
            currentRecord = 0;
        }
    });
    disableControl(true);
    $('#productCode').prop("disabled", true);
}

// Disable control when clear
function disableControl(statusDisable) {
    if (statusDisable) {
        enableFooter();
        $(".frmheader").attr("disabled", "disabled");
        $(".form-control.form-control-sm.container-no").attr("disabled", "disabled");
        $(".datepicker-date").attr("disabled", "disabled");
        $(".custom-control-input").attr("disabled", "disabled");
    } else {
        disableFooter();
        $(".frmheader").removeAttr("disabled");
        $(".form-control.form-control-sm.container-no").removeAttr("disabled");
        $(".datepicker-date").removeAttr("disabled");
        $(".custom-control-input").removeAttr("disabled");
    }
}
function disableFooter() {
    $(".frmfooter").attr("disabled", "disabled");
    $(".cell-checkbox").attr("disabled", "disabled");
}
function enableFooter() {
    $(".frmfooter").removeAttr("disabled");
    $(".cell-checkbox").removeAttr("disabled");
}

// Check table selected
function checkTableSelected() {
    return $("#table-container table tr").hasClass("selected");
}

function tpl04020CheckCb() {
    var listChecked = $('.tpl04020 table :checkbox:checked');

    if (listChecked.length == 0) {
        setMessageInfo("対象行を選択してください。");
        return false;
    }
    if (listChecked.length > 1) {
        setMessageInfo("対象行は1行まで選択できます。");
        return false;
    }
    tpl04020OrderNo = listChecked.data('id');

    return true;
}

function tpl04020DownloadPdf(urlDowloadPdf = "") {
    screenLock();
    disableFooter();
    if ($('input[name="checkSearch"]').val() == "True") {
        disableControl(true);
    }
    $('#productCode').prop("disabled", true);
    //TODO
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl04020OrderNo,
        __RequestVerificationToken: token
    };

    var result = ajaxPost(urlDowloadPdf, sendData);
    result.done(function (response) {
        if (response.Status == "OK") {
            window.open(response.DataString, "_blank", "menubar=no,toolbar=no,location=no,status=no,scrollbars=yes,resizable=yes,width=1024,height=800,top=0,left=0");
        } else {
            if (response.Focus !== null && response.Focus !== "") {
                idFocus = response.Focus;
            }
            setMessageInfo(response.Message);
        }
        unScreenLock();
        enableFooter();
    })
    disableControl(true);
}

//---------------------------//keydown---------------------------//
$("#OrderNo").on("keydown", function (e) {
    if (e.keyCode == KEY_TAB || e.keyCode == KEY_ENTER) {
        if (e.shiftKey) {
            $("#btnCSV").focus();
            return false;
        }
    }
})

$("#btnCSV").on("keydown", function (e) {
    if (e.keyCode == KEY_TAB) {
        if (!e.shiftKey) {
            $("#OrderNo").focus();
            return false;
        }
    }
})

function setFocus() {
    setTimeout(function () { $(idFocus).focus(); }, 10);
}
function handleCloseButon() {
    setFocus();
}
function handleCancelButon() {
    $(".frmfooter").removeAttr("disabled");
    $(".cell-checkbox").removeAttr("disabled");
    setFocus();
}

function handleOkButon() {
    switch (idFocus) {
        case "#btnCreate":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl04020OrderNo,
                isSelectBtn: "False",
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL04020/GoToTPL01010", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL01010/", "_blank");
            })
            break;

        case "#btnSelect":

            break;
        case "#btnOrderSlip":
            tpl04020DownloadPdf("/TPL01050P/DownloadPdf");
            break;

        case "#btnIntruction":
            tpl04020DownloadPdf("/TPL01051P/DownloadPdf");
            break;

        case "#btnEstimate":
            tpl04020DownloadPdf("/TPL01052P/DownloadPdf");
            break;

        case "#btnOutsourceOrder":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl04020OrderNo,
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL04020/GoToTPL02010", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL02010/", "_blank");
            })
            break;
        case "#btnPaperOrder":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl04020OrderNo,
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL04020/GoToTPL02030", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL02030/", "_blank");
            })
            break;
        case "#btnSales":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl04020OrderNo,
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL04020/GoToTPL04010", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL04010/", "_blank");
            })
            break;
        default:
            break;
    }
    setFocus();
    return false;
}

//----------------------------------------------------------table----------------------------------------------------------//
function mouseOverRowFunc(index) {
    var clsTr = ".cls-hover-tr-" + index;
    $(clsTr).addClass("highlight");
}

function mouseLeaveRowFunc(index) {
    var clsTr = ".cls-hover-tr-" + index;
    $(clsTr).removeClass("highlight");
}

//9.選択
function btnSelect04020() {
    idFocus = "#btnSelect";
    if (!tpl04020CheckCb()) {
        return false;
    }
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl04020OrderNo,
        isSelectBtn: "True",
        __RequestVerificationToken: token
    };
    var result = ajaxPost("/TPL04020/GoToTPL01010", sendData);
    result.done(function (res) {
        if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
            maintainanceWindow.close();

        maintainanceWindow = window.open("/TPL01010/", "_blank");
    })
}

//10.参照作成
 function btnCreate04020() {
    idFocus = "#btnCreate";
    if (!tpl04020CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注情報を参照作成します。よろしいですか？");
}

//11.クリア
function btnClear04020() {
    disableControl(false);
    setTableHeight(0);

    $('input[name="checkSearch"]').val("False");
    // Call ajax Load data for table
    $('.tpl04020 table tbody').empty();
    $('.tpl04020 .tpl04020-footer').empty();
    // Reset page current
    $("input[name='pageCurrent']").val("1");
    currentRecord = -1;
    $('.tpl04020 #OrderNo').focus();
}

function setTableHeight(row) {
    var screenWidth = document.body.offsetWidth;
    var maxTotalWidth = 690 + 880 + 34 + 2;
    var calHeight = 26 * (row + 1) + 1;
    $(".tpl04020 .tpl04020-tbl .left-ver").height(calHeight);
    if (screenWidth > maxTotalWidth) {
        $(".tpl04020 .tpl04020-tbl .right-ver").height(calHeight);
        $(".tpl04020 .tpl04020-tbl").height(287);
    } else {
        $(".tpl04020 .tpl04020-tbl .right-ver").height(calHeight + 17);
        $(".tpl04020 .tpl04020-tbl").height(304);
    }
}

//12.受注伝票
function btnOrderSlip04020() {
    idFocus = "#btnOrderSlip";
    if (!tpl04020CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注の受注伝票を出力します。よろしいですか？");
}

//13.作業指示書
function btnIntruction04020() {
    // TODO P2
    idFocus = "#btnIntruction";
    if (!tpl04020CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注の作業指示書を出力します。よろしいですか？");
}

//14.精算見積書
function btnEstimate04020() {
    // TODO P2
    idFocus = "#btnEstimate";
    if (!tpl04020CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注の精算指示書を出力します。よろしいですか？");
}

//15.外注発注
 function btnOutsourceOrder04020() {
    idFocus = "#btnOutsourceOrder";
    if (!tpl04020CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注情報を外注発注します。よろしいですか？");
}

//16.用紙発注
function btnPaperOrder04020() {
    idFocus = "#btnPaperOrder";
    if (!tpl04020CheckCb()) {

        return false;
    }
    setMessageConfirm("選択した受注情報を用紙発注します。よろしいですか？");
}

//17.売上
function btnSales04020() {
    idFocus = "#btnSales";
    if (!tpl04020CheckCb()) {
        return false;
    }
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl04020OrderNo,
        __RequestVerificationToken: token
    };
    var result = ajaxPost("/TPL04020/CheckSalesRegister", sendData);
    result.done(function (res) {
        if (res.Status == "OK") {
            if (res.DataString == "True") {
                //error
                setMessageInfo("受注の工程に内外区分「未定」が登録されているため、売上登録できません。");
                return false;
            }
            setMessageConfirm("選択した受注の売上登録を行います。よろしいですか？");
        } else {
            //error
            setMessageInfo("受注の工程に内外区分「未定」が登録されているため、売上登録できません。");
            return false;
        }
    })
}

//18.原価
function btnPrice04020() {
    idFocus = "#btnPrice";
    if (!tpl04020CheckCb()) {
        return false;
    }
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl04020OrderNo,
        __RequestVerificationToken: token
    };
    var result = ajaxPost("/TPL04020/GoToTPL05030", sendData);
    result.done(function (res) {
        if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
            maintainanceWindow.close();

        maintainanceWindow = window.open("/TPL05030/", "_blank");
    })
}