@ModelType Web.Models.TPL99040WViewModel

@Code
    Dim result As New List(Of Dao.ResultSearchByDepartAndNameDto)
    Dim cbbDepartment As New List(Of Dao.ComboBoxDto)
    If ViewBag.searchResult IsNot Nothing Then
        result = ViewBag.searchResult
    End If
    Dim total As Integer = ViewBag.Total
    Dim pageCurrent As Integer = ViewBag.pageCurrent
    Dim pageSize = ViewBag.pageSize
    Dim tabindex = 1003
    Dim btnDisabled = If(result.Any(), "", "disabled")
End Code

    <div class="tpl99040-tbl mt-2">
        <div class="container-table pb-2">
            <table class="table-striped table-bordered custom-table resize-table tpl99040-cls">
                <thead class="bg-secondary text-white">
                    <tr>
                        <th class="p-col-num1 text-custom-nowrap-header">No</th>
                        <th class="p-col-num2 text-custom-nowrap-header">コード</th>
                        <th class="p-col-num3 text-custom-nowrap-header">氏名</th>
                        <th class="p-col-num4 text-custom-nowrap-header">部署</th>
                        <th class="p-col-num5 text-custom-nowrap-header"> </th>
                    </tr>
                </thead>
                <tbody>
                    @For i As Integer = 0 To result.Count() - 1 Step 1
                        tabindex = tabindex + 5
                        Dim index = i + (10 * (pageCurrent - 1))
                        Dim idFirstElementFocus = If(i = 0, "help-first-el", "")
                        Dim idFirsttd = If(i = 0, "first-td", "")
                        @<tr>
                            <td Class="p-col-num1 text-center @idFirsttd"  title="No@(index)" tabindex="@(tabindex + 1)"><span Class="txt-elipsis-ver">@(index + 1)</span></td>
                            <td class="p-col-num2" title="@result.Item(i).担当" tabindex="@(tabindex + 2)"><span class="txt-elipsis-ver">@result.Item(i).担当</span></td>
                            <td class="p-col-num3" title="@result.Item(i).氏名" tabindex="@(tabindex + 3)"><span class="txt-elipsis-ver">@result.Item(i).氏名</span></td>
                            <td class="p-col-num4" title="@result.Item(i).略称" tabindex="@(tabindex + 4)"><span class="txt-elipsis-ver">@result.Item(i).略称</span></td>
                            <td class="p-col-num5 text-center @idFirstElementFocus" tabindex="@(tabindex + 5)" >
                                <span class="txt-elipsis-ver">
                                <input type="checkbox" tabindex="@(tabindex + 6)" data-id='@result.Item(i).担当' class="p-checkbox" />
                            </span>
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
        <div class="group pb-3 footer-p">
            <div class="row">
                <div class="col-8 d-flex align-items-center">
                    <div class="group-pagination-content">
                        @Html.Partial("_Pagination", New With {.pageCurrent = pageCurrent, .pageSize = pageSize, .Total = total})
                    </div>
                </div>
                <div class="col-4 d-flex align-items-center justify-content-end h-40 pr-0">
                    <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr select-btn" tabindex="@(tabindex + 6)" value="" @btnDisabled>選　択</button>
                </div>

            </div>
        </div>
    </div>
<script>
    var tabNumber = @Html.Raw(tabindex + 6);
    var tabTemp = tabNumber;
    var index = 0;
    var KEY_TAB = 9;
    var KEY_ENTER = 13;
    function setWidthTable() {
        var widthDefHead = [];//700
        widthDefHead.push({ key: "No", value: 7.1 });//50
        widthDefHead.push({ key: "コード", value: 10 });//70
        widthDefHead.push({ key: "名称", value: 50 });//350
        widthDefHead.push({ key: "略称", value: 24.2 });//170
        widthDefHead.push({ key: "Check", value: 8.7 });//60
        for (var i = 0; i < widthDefHead.length; i++) {
            $(".p-col-num" + (i + 1)).css("width", widthDefHead[i].value.toString() + "%");
        }
    }
    setWidthTable();

    $(document).ready(function () {
        $('.tpl99040-p .pagination li').each(function (index, value) {
            $(value).attr('tabindex', tabTemp + index + 1);
        })
        if ($('.tpl99040-p .pagination li').length > 0) {
            tabNumber = tabNumber + $('.tpl99040-p .pagination li').length;
        }
        $('.tpl99040-p .select-btn').attr('tabindex', tabNumber + 1);
        $(function () {
            //$("table").colResizable({ disable: true });
            $('.popup-model .tpl99040-p table').colResizable({
                liveDrag: true,
                //disabledColumns: [0, 1],
            });

            $(".tpl99040-p table tr td span").click(function () {
                $(this).parent().focus();
            });
        });
    });

    $(".tpl99040-p .combobox-cls-p").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (e.shiftKey) {
                if ($(".tpl99040-tbl .select-btn").is(':disabled')) {
                    $(".tpl99040-p .p-tpl-close").focus();
                } else {
                    $(".tpl99040-tbl .select-btn").focus();
                }
                return false;
            }
        }
    });

    $(".tpl99040-p .p-tpl-close").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                if ($(".tpl99040-tbl tbody tr").length > 0) {
                    $(".tpl99040-tbl .first-td").focus();
                    return false;
                } else {
                    if ($(".tpl99040-tbl .select-btn").is(':disabled')) {
                        $(".tpl99040-p .combobox-cls-p").focus();
                    } else {
                        $(".tpl99040-tbl .select-btn").focus();
                    }
                    return false;
                }
            }
        }
    });

    $(".tpl99040-p .select-btn").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                $(".tpl99040-p .combobox-cls-p").focus();
                return false;
            }
        }
    });

    $(".tpl99040-tbl").on("click", "tbody tr", function () {
        currentRecord = $(this).index();
        if (!$(this).hasClass('selected')) {
            $('.tpl99040-tbl tbody tr.selected').removeClass('selected');
            $('.tpl99040-tbl tbody tr:eq(' + currentRecord + ')').addClass('selected');
        }
        //$(this).find("input").focus();
    });

    // ----Function: onKeydown----
    $(".tpl99040-tbl table, .tpl99040-p .footer-p .group-pagination-content").on("keydown", function (e) {
        // ----Keypress: F8----
        if (e.key === "F8") {
            if (e.shiftKey) {
                $('.tpl99040-p .p-tpl-close').focus();
            } else {
                $('.tpl99040-p .select-btn').focus();
            }
            return false;
        }

        // ----Keypress: F7----
        if (e.key === "F7") {
                var pageCurrent = parseInt($(".tpl99040-p input[name='pageCurrent']").val());
                if (pageCurrent - 1 > 0) {
                    ajaxCall4(pageCurrent - 1)
                }
            return false;
        }

        // ----Keypress: F9----
        if (e.key === "F9") {
                var pageCurrent = parseInt($(".tpl99040-p input[name='pageCurrent']").val());
                var pageTotal = $(".tpl99040-p input[name='pageTotal']").val()
                if (pageCurrent + 1 <= pageTotal) {
                    ajaxCall4(pageCurrent + 1)
                }
            return false;
        }
    });
</script>
