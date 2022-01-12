@ModelType Web.Models.TPL01040ViewModel
@Imports Core.Util.NumberUtil
@Imports Core.Util.DateUtil
@Imports Core.ConstantCore
@Code

    Dim result As New List(Of Dao.SearchOrderResultDto)
    If ViewBag.searchResult IsNot Nothing Then
        result = ViewBag.searchResult
    End If
    Dim total As Integer = ViewBag.Total
    Dim pageCurrent As Integer = ViewBag.pageCurrent
    Dim checkSearch As Boolean = ViewBag.checkSearch
    Dim pageSize = ViewBag.pageSize
    Dim resultLength = result.Count()
    Dim tabindex = 11
    Dim btnCtrlArr() As Boolean
    Dim visibleCostBtn = True
    Dim visibleWorkInstructionBtn = True
    Dim visibleSettlementEstimateBtn = True
    If ViewBag.btnCtrlArr IsNot Nothing Then
        btnCtrlArr = ViewBag.btnCtrlArr
        visibleCostBtn = btnCtrlArr(0)
        visibleWorkInstructionBtn = btnCtrlArr(1)
        visibleSettlementEstimateBtn = btnCtrlArr(2)
    End If
    Dim costBtn = If(visibleCostBtn, "", "hidden")
    Dim workInstructionBtn = If(visibleWorkInstructionBtn, "", "hidden")
    Dim settlementEstimateBtn = If(visibleSettlementEstimateBtn, "", "hidden")
    Dim addRow = 10 - resultLength
End Code
<div class="col col-md-12 container-table tpl01040-tbl mt-2">
    <div class="left-ver">
        <table class="table table-striped table-bordered table-hover custom-table">
            <thead class="bg-secondary text-white">
                <tr>
                    <th class="col-num1 text-custom-nowrap-header">No</th>
                    <th class="col-num2 text-custom-nowrap-header">受注番号</th>
                    <th class="col-num3 text-custom-nowrap-header">得意先</th>
                    <th class="col-num4 text-custom-nowrap-header">品名</th>
                    <th class="col-num5 text-custom-nowrap-header"> </th>
                </tr>
            </thead>
            <tbody>
                @For i As Integer = 0 To resultLength - 1 Step 1
                    tabindex = (i * 14) + 11
                    @<tr class="cls-hover-tr-@i" onmouseover="mouseOverRowFunc(@i)" onmouseleave="mouseLeaveRowFunc(@i)">
                        <td class="col-num1 text-center @(If(i = 0, "first-cell", ""))" title="@((pageCurrent - 1) * pageSize + i + 1)" tabindex="@(tabindex + 1)">@((pageCurrent - 1) * pageSize + i + 1)</td>
                        <td class="col-num2" title="@result.Item(i).受注番号" tabindex="@(tabindex + 2)"><span class="txt-elipsis-ver">@result.Item(i).受注番号</span></td>
                        <td class="col-num3" title="@result.Item(i).得意先名" tabindex="@(tabindex + 3)"><span class="txt-elipsis-ver">@result.Item(i).得意先名</span></td>
                        <td class="col-num4" title="@result.Item(i).品名" tabindex="@(tabindex + 4)"><span class="txt-elipsis-ver">@result.Item(i).品名</span></td>
                        <td class="col-num5 text-center  @(If(i = 0, "td-first-cb", ""))" title="Checkbox@(i)" tabindex="@(tabindex + 5)"><input type="checkbox" data-id="@result.Item(i).受注番号" tabindex="@(tabindex + 6)" class="form-control-sm cell-checkbox @(If(i = 0, "first-cb", ""))" /></td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
    <div class="right-ver">
        <table class="table table-striped table-bordered table-hover custom-table">
            <thead class="bg-secondary text-white">
                <tr>
                    <th class="col-num6 text-custom-nowrap-header">受注数量</th>
                    <th class="col-num7 text-custom-nowrap-header">受注単価</th>
                    <th class="col-num8 text-custom-nowrap-header">受注金額</th>
                    <th class="col-num9 text-custom-nowrap-header">受注日</th>
                    <th class="col-num10 text-custom-nowrap-header">納品日</th>
                    <th class="col-num11 text-custom-nowrap-header">検収日</th>
                    <th class="col-num12 text-custom-nowrap-header">売上金額</th>
                    <th class="col-num13 text-custom-nowrap-header">受注残金額</th>
                </tr>
            </thead>
            <tbody>
                @For i As Integer = 0 To result.Count() - 1 Step 1
                    tabindex = (i * 14) + 11
                    @<tr class="cls-hover-tr-@i" onmouseover="mouseOverRowFunc(@i)" onmouseleave="mouseLeaveRowFunc(@i)">
                        <td class="col-num6 text-right" title="@ConvertNumToStrFormat(result.Item(i).受注数量, NumberFormat.FORMAT_NUMBER)" tabindex="@(tabindex + 7)"><span class="txt-elipsis-ver">@ConvertNumToStrFormat(result.Item(i).受注数量, NumberFormat.FORMAT_NUMBER, True)</span></td>
                        <td Class="col-num7 text-right" title="@ConvertNumToStrFormat(result.Item(i).受注単価, NumberFormat.FORMAT_NUMBER_3_DECIMAL)" tabindex="@(tabindex + 8)"><span class="txt-elipsis-ver">@ConvertNumToStrFormat(result.Item(i).受注単価, NumberFormat.FORMAT_NUMBER_3_DECIMAL, True)</span></td>
                        <td Class="col-num8 text-right" title="@ConvertNumToStrFormat(result.Item(i).受注金額, NumberFormat.FORMAT_NUMBER)" tabindex="@(tabindex + 9)"><span class="txt-elipsis-ver">@ConvertNumToStrFormat(result.Item(i).受注金額, NumberFormat.FORMAT_NUMBER)</span></td>
                        <td Class="col-num9" title="@ConvertDateToString(result.Item(i).受注日, DateFormat.YYYYMMDD)" tabindex="@(tabindex + 10)"><span class="txt-elipsis-ver">@ConvertDateToString(result.Item(i).受注日, DateFormat.YYYYMMDD)</span></td>
                        <td Class="col-num10" title="@ConvertDateToString(result.Item(i).納品日, DateFormat.YYYYMMDD)" tabindex="@(tabindex + 11)"><span class="txt-elipsis-ver">@ConvertDateToString(result.Item(i).納品日, DateFormat.YYYYMMDD)</span></td>
                        <td Class="col-num11" title="@ConvertDateToString(result.Item(i).検収日, DateFormat.YYYYMMDD)" tabindex="@(tabindex + 12)"><span class="txt-elipsis-ver">@ConvertDateToString(result.Item(i).検収日, DateFormat.YYYYMMDD)</span></td>
                        <td Class="col-num12 text-right" title="@ConvertNumToStrFormat(result.Item(i).売上金額, NumberFormat.FORMAT_NUMBER)" tabindex="@(tabindex + 13)"><span class="txt-elipsis-ver">@ConvertNumToStrFormat(result.Item(i).売上金額, NumberFormat.FORMAT_NUMBER)</span></td>
                        <td Class="col-num13 text-right" title="@ConvertNumToStrFormat(result.Item(i).Cal受注残金額(), NumberFormat.FORMAT_NUMBER)" tabindex="@(tabindex + 14)"><span class="txt-elipsis-ver">@ConvertNumToStrFormat(result.Item(i).Cal受注残金額(), NumberFormat.FORMAT_NUMBER)</span></td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
</div>
@If resultLength > 0 Then
    @<div class="row tpl01040-footer">
        <div Class="group-pagination-content col-6 pagination-footer">
            @Html.Partial("_Pagination", New With {.pageCurrent = pageCurrent, .pageSize = pageSize, .Total = total})
        </div>
        <div Class="group-pagination-content col-6 footer-button">
            <div Class="mb-2 row d-flex justify-content-end">
                <div Class=""><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnSelect" onclick="btnSelect01040()">選　択</button></div>
                <div Class=""><button type="button" Class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnCreate" onclick="btnCreate01040()">参照作成</button></div>
                <div Class=""><button type="button" Class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnClear" onclick="btnClear01040()">クリア</button></div>
            </div>
            <div Class="mb-2 row d-flex justify-content-end">
                <div Class=""><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnOrderSlip" onclick="btnOrderSlip01040()">受注伝票</button></div>
                <div Class="div-btn-hide"><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnIntruction" @workInstructionBtn onclick="btnIntruction01040()">作業指示書</button></div>
                <div Class="div-btn-hide"><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnEstimate" @settlementEstimateBtn onclick="btnEstimate01040()">精算見積書</button></div>
            </div>
            <div Class="mb-2 row d-flex justify-content-end">
                <div Class=""><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnOutsourceOrder" onclick="btnOutsourceOrder01040()">外注発注</button></div>
                <div Class=""><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnPaperOrder" onclick="btnPaperOrder01040()">用紙発注</button></div>
                <div Class=""><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnSales" onclick="btnSales01040()">売　上</button></div>
                <div Class="div-btn-hide"><button type="button" class="btn btn-sm btn-secondary frmfooter tpl-btn-mr" id="btnPrice" @costBtn onclick="btnPrice01040()">原　価</button></div>
            </div>
        </div>
    </div>
End If

<script type="text/javascript">
    var tabNumber = @Html.Raw(tabindex + 14);
    var windowWidth = window.innerWidth;
    var leftTableWidth = 690;
    function setWidthTable() {
        var widthSet = $(".container-fluid").width() - leftTableWidth;
        if (widthSet <= 880) {
            widthSet = 880;
        }
        $(".right-ver table").css("width", widthSet + "px");
        var widthDefHead = [];
        // Left table 690
        widthDefHead.push({ key: "No", value: 7.2 });//50
        widthDefHead.push({ key: "受注番号", value: 11.6 }); //80
        widthDefHead.push({ key: "得意先", value: 37.7 });//260
        widthDefHead.push({ key: "品名", value: 37.7 }); //260
        widthDefHead.push({ key: "Checkbox", value: 5.8 }); //40
        // Right table //800
        widthDefHead.push({ key: "受注数量", value: 12.5 }); //100
        widthDefHead.push({ key: "受注単価", value: 12.5 }); //100
        widthDefHead.push({ key: "受注金額", value: 12.5 }); //100
        widthDefHead.push({ key: "受注日", value: 12.5 }); //100
        widthDefHead.push({ key: "納品日", value: 12.5 }); //100
        widthDefHead.push({ key: "検収日", value: 12.5 });//100
        widthDefHead.push({ key: "売上金額", value: 12.5 });//100
        widthDefHead.push({ key: "受注残金額", value: 12.5 }); //100

        for (var i = 0; i < widthDefHead.length; i++) {
            $(".col-num" + (i + 1)).css("width", widthDefHead[i].value.toString() + "%");
        }
    }
    $(document).ready(function () {
        $(".tpl01040-tbl .td-first-cb").focus();
        setTableHeight(@Html.Raw(resultLength));
    });

    var tabTemp = tabNumber;
    setWidthTable();
    convertTableToDataTable();

    $('.tpl01040-footer .pagination li').each(function (index, value) {
        tabNumber++;
        $(value).attr('tabindex', tabTemp + index + 1);
    })

    $('#btnSelect').attr('tabindex', ++tabNumber);
    $('#btnCreate').attr('tabindex', ++tabNumber);
    $('#btnClear').attr('tabindex', ++tabNumber);
    $('#btnOrderSlip').attr('tabindex', ++tabNumber);
    $('#btnIntruction').attr('tabindex', ++tabNumber);
    $('#btnEstimate').attr('tabindex', ++tabNumber);
    $('#btnOutsourceOrder').attr('tabindex', ++tabNumber);
    $('#btnPaperOrder').attr('tabindex', ++tabNumber);
    $('#btnSales').attr('tabindex', ++tabNumber);
    $('#btnPrice').attr('tabindex', ++tabNumber);

    $(window).resize(function () {
        var widthSet = $(".container-fluid").width() - 690;
        if (widthSet <= 880) {
            widthSet = 880;
        }
        $(".right-ver table").css("width", widthSet + "px");
        $(".JCLRgrips").css("width", widthSet + "px");
        setTableHeight(@Html.Raw(resultLength));
        convertTableToDataTable();
    });

    // ----Function: onKeydown----//
    $("#btnPrice").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                $(".first-cell").focus();
                return false;
            }
        }
    })
    $(".first-cell").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB || e.keyCode == KEY_ENTER) {
            if (e.shiftKey) {
                $("#btnPrice").focus();
                return false;
            }
        }
    })

    $(".tpl01040-tbl, .pagination-footer").on("keydown", function (e) {
        // ----Keypress: F8----
        if (e.key === "F8" && e.shiftKey) {
            $("#btnPrice").focus();
            return false;
        }
        if (e.key === "F8" && !e.shiftKey) {
            $("#btnSelect").focus();
            return false;
        }

        // ----Keypress: F7----
        if (e.key === "F7") {
            var pageCurrent = parseInt($("input[name='pageCurrent']").val());
            if (pageCurrent - 1 > 0) {
                ajaxCall(pageCurrent - 1);
            }
            return false;
        }

        // ----Keypress: F9----
        if (e.key === "F9") {
            var pageCurrent = parseInt($("input[name='pageCurrent']").val());
            var pageTotal = $("input[name='pageTotal']").val()
            if (pageCurrent + 1 <= pageTotal) {
                ajaxCall(pageCurrent + 1);
            }
            return false;
        }
    });
</script>
