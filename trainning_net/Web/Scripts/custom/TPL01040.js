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
var tpl01040OrderNo = "";
$(".tpl01040 #Customer").addClass("frmheader");
$(".tpl01040 #StartDate").addClass("frmheader");
$(".tpl01040 #EndDate").addClass("frmheader");
$(".tpl01040 #OrderNo").focus();

$(".tpl01040 #btnSearch").off().on("click",function () {
    idFocus = "#btnSearch";
    $('input[name="checkSearch"]').val("True");
    $('#productCode').prop("disabled", false);
    //// Call ajax Load data for table
    LoadDataTable();
});

// Load data for table
function LoadDataTable() {
    ajaxPostForm("/TPL01040/Search", $("#orderFrm")).done(function (response) {
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
$(".tpl01040 #btnCSV").off().on("click", function () {
    idFocus = "#btnCSV";
    if ($('input[name="checkSearch"]').val() == "True") {
        disableControl(false);
    }
    $('#productCode').prop("disabled", false);
    screenLock();
    var url = "/TPL01040/ExportCSV";
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
                    window.location.href = "/TPL01040";

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

    ajaxPostForm("/TPL01040/Search", $("#orderFrm")).done(function (response) {
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

function tpl01040CheckCb() {
    var listChecked = $('.tpl01040 table :checkbox:checked');

    if (listChecked.length == 0) {
        setMessageInfo("対象行を選択してください。");
        return false;
    }
    if (listChecked.length > 1) {
        setMessageInfo("対象行は1行まで選択できます。");
        return false;
    }
    tpl01040OrderNo = listChecked.data('id');

    return true;
}

function tpl01040DownloadPdf(urlDowloadPdf = "") {
    screenLock();
    disableFooter();
    if ($('input[name="checkSearch"]').val() == "True") {
        disableControl(true);
    }
    $('#productCode').prop("disabled", true);
    //TODO
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl01040OrderNo,
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
                orderNo: tpl01040OrderNo,
                isSelectBtn: "False",
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL01040/GoToTPL01010", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL01010/", "_blank");
            })
            break;

        case "#btnSelect":

            break;
        case "#btnOrderSlip":
            tpl01040DownloadPdf("/TPL01050P/DownloadPdf");
            break;

        case "#btnIntruction":
            tpl01040DownloadPdf("/TPL01051P/DownloadPdf");
            break;

        case "#btnEstimate":
            tpl01040DownloadPdf("/TPL01052P/DownloadPdf");
            break;

        case "#btnOutsourceOrder":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl01040OrderNo,
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL01040/GoToTPL02010", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL02010/", "_blank");
            })
            break;
        case "#btnPaperOrder":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl01040OrderNo,
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL01040/GoToTPL02030", sendData);
            result.done(function (res) {
                if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
                    maintainanceWindow.close();

                maintainanceWindow = window.open("/TPL02030/", "_blank");
            })
            break;
        case "#btnSales":
            var token = $("input[name=__RequestVerificationToken]").val();
            var sendData = {
                orderNo: tpl01040OrderNo,
                __RequestVerificationToken: token
            };
            var result = ajaxPost("/TPL01040/GoToTPL04010", sendData);
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
function btnSelect01040() {
    idFocus = "#btnSelect";
    if (!tpl01040CheckCb()) {
        return false;
    }
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl01040OrderNo,
        isSelectBtn: "True",
        __RequestVerificationToken: token
    };
    var result = ajaxPost("/TPL01040/GoToTPL01010", sendData);
    result.done(function (res) {
        if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
            maintainanceWindow.close();

        maintainanceWindow = window.open("/TPL01010/", "_blank");
    })
}

//10.参照作成
 function btnCreate01040() {
    idFocus = "#btnCreate";
    if (!tpl01040CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注情報を参照作成します。よろしいですか？");
}

//11.クリア
function btnClear01040() {
    disableControl(false);
    setTableHeight(0);

    $('input[name="checkSearch"]').val("False");
    // Call ajax Load data for table
    $('.tpl01040 table tbody').empty();
    $('.tpl01040 .tpl01040-footer').empty();
    // Reset page current
    $("input[name='pageCurrent']").val("1");
    currentRecord = -1;
    $('.tpl01040 #OrderNo').focus();
}

function setTableHeight(row) {
    var screenWidth = document.body.offsetWidth;
    var maxTotalWidth = 690 + 880 + 34 + 2;
    var calHeight = 26 * (row + 1) + 1;
    $(".tpl01040 .tpl01040-tbl .left-ver").height(calHeight);
    if (screenWidth > maxTotalWidth) {
        $(".tpl01040 .tpl01040-tbl .right-ver").height(calHeight);
        $(".tpl01040 .tpl01040-tbl").height(287);
    } else {
        $(".tpl01040 .tpl01040-tbl .right-ver").height(calHeight + 17);
        $(".tpl01040 .tpl01040-tbl").height(304);
    }
}

//12.受注伝票
function btnOrderSlip01040() {
    idFocus = "#btnOrderSlip";
    if (!tpl01040CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注の受注伝票を出力します。よろしいですか？");
}

//13.作業指示書
function btnIntruction01040() {
    // TODO P2
    idFocus = "#btnIntruction";
    if (!tpl01040CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注の作業指示書を出力します。よろしいですか？");
}

//14.精算見積書
function btnEstimate01040() {
    // TODO P2
    idFocus = "#btnEstimate";
    if (!tpl01040CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注の精算指示書を出力します。よろしいですか？");
}

//15.外注発注
 function btnOutsourceOrder01040() {
    idFocus = "#btnOutsourceOrder";
    if (!tpl01040CheckCb()) {
        return false;
    }
    setMessageConfirm("選択した受注情報を外注発注します。よろしいですか？");
}

//16.用紙発注
function btnPaperOrder01040() {
    idFocus = "#btnPaperOrder";
    if (!tpl01040CheckCb()) {

        return false;
    }
    setMessageConfirm("選択した受注情報を用紙発注します。よろしいですか？");
}

//17.売上
function btnSales01040() {
    idFocus = "#btnSales";
    if (!tpl01040CheckCb()) {
        return false;
    }
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl01040OrderNo,
        __RequestVerificationToken: token
    };
    var result = ajaxPost("/TPL01040/CheckSalesRegister", sendData);
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
function btnPrice01040() {
    idFocus = "#btnPrice";
    if (!tpl01040CheckCb()) {
        return false;
    }
    var token = $("input[name=__RequestVerificationToken]").val();
    var sendData = {
        orderNo: tpl01040OrderNo,
        __RequestVerificationToken: token
    };
    var result = ajaxPost("/TPL01040/GoToTPL05030", sendData);
    result.done(function (res) {
        if (typeof maintainanceWindow !== "undefined" && maintainanceWindow !== null)
            maintainanceWindow.close();

        maintainanceWindow = window.open("/TPL05030/", "_blank");
    })
}