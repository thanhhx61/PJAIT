@ModelType Web.Models.TPL99020WViewModel

@Code
    Dim result As New List(Of Dao.取引先Dto)
    If ViewBag.searchResult IsNot Nothing Then
        result = ViewBag.searchResult
    End If
    Dim total As Integer = ViewBag.Total
    Dim pageCurrent As Integer = ViewBag.pageCurrent
    Dim checkSearch As Boolean = ViewBag.checkSearch
    Dim pageSize = ViewBag.pageSize
    Dim resultCount = result.Count()
    Dim tabindex = 1003
    Dim btnDisabled = If(result.Any(), "", "disabled")
End Code

<div class="tpl99020-tbl mt-2">
    <div class="container-table pb-2">
        <table class="table-striped table-bordered custom-table resize-table tpl99020-cls">
            <thead class="bg-secondary text-white">
                <tr>
                    <th class="p-col-num1 text-custom-nowrap-header">No</th>
                    <th class="p-col-num2 text-custom-nowrap-header">コード</th>
                    <th class="p-col-num3 text-custom-nowrap-header">名称</th>
                    <th class="p-col-num4 text-custom-nowrap-header">略称</th>
                    <th class="p-col-num5 text-custom-nowrap-header"> </th>
                    <th class="p-col-num6 text-custom-nowrap-header">支店名</th>
                </tr>
            </thead>
            <tbody>
                @For i As Integer = 0 To result.Count() - 1 Step 1
                    tabindex = tabindex + 7
                    Dim index = i + (10 * (pageCurrent - 1))
                    Dim idFirstElementFocus = If(i = 0, "help-first-el", "")
                    Dim idFirsttd = If(i = 0, "first-td", "")
                    @<tr>
                        <td Class="p-col-num1 text-center @idFirsttd"  title="No@(index)" tabindex="@(tabindex + 1)"><span Class="txt-elipsis-ver">@(index + 1)</span></td>
                        <td class="p-col-num2" title="@result.Item(i).取引先" tabindex="@(tabindex + 2)"><span class="txt-elipsis-ver">@result.Item(i).取引先</span></td>
                        <td class="p-col-num3" title="@result.Item(i).名称" tabindex="@(tabindex + 3)"><span class="txt-elipsis-ver">@result.Item(i).名称</span></td>
                        <td class="p-col-num4" title="@result.Item(i).略称" tabindex="@(tabindex + 4)"><span class="txt-elipsis-ver">@result.Item(i).略称</span></td>
                        <td class="p-col-num5 text-center @idFirstElementFocus" title="checkOff" tabindex="@(tabindex + 5)">
                            <span class="txt-elipsis-ver"><input type="checkbox" tabindex="@(tabindex + 6)" data-id='@result.Item(i).取引先' class="p-checkbox" /></span>
                        </td>
                        <td Class="p-col-num6" title="@result.Item(i).支店名" tabindex="@(tabindex + 7)"><span class="txt-elipsis-ver">@result.Item(i).支店名</span></td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
    <div class="group pb-3 footer-p">
        <div class="row">
            <div class="col-9 d-flex align-items-center">
                <div class="group-pagination-content">
                    @Html.Partial("_Pagination", New With {.pageCurrent = pageCurrent, .pageSize = pageSize, .Total = total})
                </div>
            </div>
            <div class="col-3 d-flex align-items-center justify-content-end h-40 pr-0">
                <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr select-btn" value="" @btnDisabled>選　択</button>
            </div>

        </div>
    </div>
</div>

<script>
    var tabNumber = @Html.Raw(tabindex + 7);
    var tabTemp = tabNumber;
    var index = 0;
    function setWidthTable() {
        var widthDefHead = [];//860
        widthDefHead.push({ key: "No", value: 5.8 });//50
        widthDefHead.push({ key: "コード", value: 9.2 });//80
        widthDefHead.push({ key: "名称", value: 29 });//250
        widthDefHead.push({ key: "略称", value: 20 });//170
        widthDefHead.push({ key: "Check", value: 7 });//60
        widthDefHead.push({ key: "支店名", value: 29 });//250
        for (var i = 0; i < widthDefHead.length; i++) {
            $(".p-col-num" + (i + 1)).css("width", widthDefHead[i].value.toString() + "%");
        }
    }
    setWidthTable();

    $(document).ready(function () {
        $('.tpl99020-p .pagination li').each(function (index, value) {
            $(value).attr('tabindex', tabTemp + index + 1);
        })
        if ($('.tpl99020-p .pagination li').length > 0) {
            tabNumber = tabNumber + $('.tpl99020-p .pagination li').length;
        }
        $('.tpl99020-p .select-btn').attr('tabindex', tabNumber + 1);
        $(function () {
            //$("table").colResizable({ disable: true });
            $('.popup-model .tpl99020-p table').colResizable({
                liveDrag: true,
                //disabledColumns: [0, 1],
            });
        });
    });

    var KEY_TAB = 9;
    var KEY_ENTER = 13;

    $(".tpl99020-p .name-search-p").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB || e.keyCode == KEY_ENTER) {
            if (e.shiftKey) {
                if ($(".tpl99020-tbl .select-btn").is(':disabled')) {
                    $(".tpl99020-p .p-tpl-close").focus();
                } else {
                    $(".tpl99020-tbl .select-btn").focus();
                }
                return false;
            }
        }
    });

    $(".tpl99020-p .p-tpl-close").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                if ($(".tpl99020-tbl tbody tr").length > 0) {
                    $(".tpl99020-tbl .first-td").focus();
                    return false;
                } else {
                    if ($(".tpl99020-tbl .select-btn").is(':disabled')) {
                        $(".tpl99020-p .name-search-p").focus();
                    } else {
                        $(".tpl99020-tbl .select-btn").focus();
                    }
                    return false;
                }
            }
        }
    });
    $(".tpl99020-tbl .select-btn").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                $(".tpl99020-p .name-search-p").focus();
                return false;
            }
        }
    });

    $(".tpl99020-tbl").on("click", "tbody tr", function () {
        currentRecord = $(this).index();
        if (!$(this).hasClass('selected')) {
            $('.tpl99020-tbl tbody tr.selected').removeClass('selected');
            $('.tpl99020-tbl tbody tr:eq(' + currentRecord + ')').addClass('selected');
        }
        //$(this).find("input").focus();
    });


    // ----Function: onKeydown----
    $(".tpl99020-tbl .tpl99020-cls, .tpl99020-p .footer-p .group-pagination-content").on("keydown", function (e) {
        // ----Keypress: F8----
        if (e.key === "F8") {
            if (e.shiftKey) {
                $('.tpl99020-p .p-tpl-close').focus();
            } else {
                $('.tpl99020-p .select-btn').focus();
            }
            return false;
        }

        // ----Keypress: F7----
        if (e.key === "F7") {
            var pageCurrent = parseInt($(".tpl99020-p input[name='pageCurrent']").val());
            if (pageCurrent - 1 > 0) {
                ajaxCall2(pageCurrent - 1)
            }
            return false;
        }

        // ----Keypress: F9----
        if (e.key === "F9") {
            var pageCurrent = parseInt($(".tpl99020-p input[name='pageCurrent']").val());
            var pageTotal = $(".tpl99020-p input[name='pageTotal']").val()
            if (pageCurrent + 1 <= pageTotal) {
                ajaxCall2(pageCurrent + 1)
            }
            return false;
        }
    });
</script>
