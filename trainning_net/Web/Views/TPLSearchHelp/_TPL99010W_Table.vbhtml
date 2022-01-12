@ModelType Web.Models.TPL99010WViewModel
@Code
    Dim result As New List(Of Dao.コードDto)
    If ViewBag.searchResult IsNot Nothing Then
        result = ViewBag.searchResult
    End If
    Dim total As Integer = ViewBag.Total
    Dim pageCurrent As Integer = ViewBag.pageCurrent
    Dim checkSearch As Boolean = ViewBag.checkSearch
    Dim pageSize = ViewBag.pageSize
    Dim resultCount = result.Count()
    Dim tabindex = 1000
    Dim nameCol2 = If(String.IsNullOrEmpty(ViewBag.idInput), "識別", "コード")
    Dim buttonAddClassFocus = If(result.Count = 0, "help-first-el", "")
End Code
<div class="tpl99010-tbl">
    <div class="container-table pb-2">
        <table class="table-striped table-bordered custom-table resize-table table-screen-popup tpl99010-cls">
            <thead class="bg-secondary text-white">
                <tr>
                    <th class="p-col-num1 text-custom-nowrap-header">No</th>
                    <th class="p-col-num2 text-custom-nowrap-header">@(nameCol2)</th>
                    <th class="p-col-num3 text-custom-nowrap-header">名称</th>
                    <th class="p-col-num4 text-custom-nowrap-header">略称</th>
                    <th class="p-col-num5 text-custom-nowrap-header"> </th>
                    <th class="p-col-num6 text-custom-nowrap-header">文字１</th>
                    <th class="p-col-num7 text-custom-nowrap-header">表示順</th>
                    <th class="p-col-num8 text-custom-nowrap-header">表示しない</th>
                </tr>
            </thead>
            <tbody>
                @For i As Integer = 0 To result.Count() - 1 Step 1
                    tabindex = tabindex + 9
                    Dim valueCol2 = If(nameCol2 = "識別", result.Item(i).識別, result.Item(i).コード)
                    Dim index = i + (10 * (pageCurrent - 1))
                    Dim idFirstElementFocus = If(i = 0, "help-first-el", "")
                    Dim idFirstTd = If(i = 0, "first-td", "")
                    @<tr>
                        <td class="p-col-num1 text-center @idFirstTd" title="No@(index)" tabindex="@(tabindex + 1)"><span class="txt-elipsis-ver">@(index + 1)</span></td>
                        <td class="p-col-num2" title="@valueCol2" tabindex="@(tabindex + 2)"><span class="txt-elipsis-ver">@valueCol2</span></td>
                        <td class="p-col-num3" title="@result.Item(i).名称" tabindex="@(tabindex + 3)"><span class="txt-elipsis-ver">@result.Item(i).名称</span></td>
                        <td class="p-col-num4" title="@result.Item(i).略称" tabindex="@(tabindex + 4)"><span class="txt-elipsis-ver">@result.Item(i).略称</span></td>
                        <td class="p-col-num5 text-center @idFirstElementFocus" title="" tabindex="@(tabindex + 5)">
                            <span class="txt-elipsis-ver"><input type="checkbox" data-id='@valueCol2' tabindex="@(tabindex + 6)" data-col-nm='@nameCol2' class="p-checkbox" /></span>
                        </td>
                        <td Class="p-col-num6" title="@result.Item(i).文字１" tabindex="@(tabindex + 7)"><span class="txt-elipsis-ver">@result.Item(i).文字１</span></td>
                        <td class="p-col-num7 text-right" title="@result.Item(i).表示順" tabindex="@(tabindex + 8)"><span class="txt-elipsis-ver">@String.Format("{0:n0}", result.Item(i).表示順)</span></td>
                        <td class="p-col-num8 text-center" title="@result.Item(i).削除フラグ" tabindex="@(tabindex + 9)"><span class="txt-elipsis-ver">@(If(result.Item(i).削除フラグ, "〇", " "))</span></td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
</div>
<div class="group pb-2 footer-p">
    <div class="row pb-2">
        <div class="col-9 d-flex align-items-center">
            <div class="group-pagination-content">
                @Html.Partial("_Pagination", New With {.pageCurrent = pageCurrent, .pageSize = pageSize, .Total = total})
            </div>
        </div>
        <div class="col-3 d-flex align-items-center justify-content-end h-40 pr-0">
            <button type="button" value="" class="btn btn-sm btn-secondary tpl-btn-mr select-btn">選　択</button>
            <button type="button" value="" class="btn btn-sm btn-secondary tpl-btn-mr p-tpl-close" id="tplBtnClose010">閉じる</button>
        </div>
    </div>
</div>
<script type="text/javascript">
    var tabNumber = @Html.Raw(tabindex + 10);
    var tabTemp = tabNumber;
    var index = 0;

    var KEY_TAB = 9;
    var KEY_ENTER = 13;
    function setWidthTable() {
        var widthDefHead = []; //1030
        widthDefHead.push({ key: "No", value: 5 });//50
        widthDefHead.push({ key: "コード", value: 8 }); //80
        widthDefHead.push({ key: "名称", value: 24 }); //250
        widthDefHead.push({ key: "略称", value: 16 }); //170
        widthDefHead.push({ key: "Check", value: 5 }); //60
        widthDefHead.push({ key: "文字１", value: 24 }); //250
        widthDefHead.push({ key: "表示順", value: 8 }); //80
        widthDefHead.push({ key: "表示しない", value: 10 }); //90
        for (var i = 0; i < widthDefHead.length; i++) {
            $(".tpl99010-p .p-col-num" + (i + 1)).css("width", widthDefHead[i].value.toString() + "%");
        }
    }
    setWidthTable();
    $(document).ready(function () {
        $('.tpl99010-p .pagination li').each(function (index, value) {
            $(value).attr('tabindex', tabTemp + index + 1);
        })
        if ($('.tpl99010-p .pagination li').length > 0) {
            tabNumber = tabNumber + $('.tpl99010-p .pagination li').length;
        }
        $('.tpl99010-p .select-btn').attr('tabindex', tabNumber + 1);
        $('.tpl99010-p .p-tpl-close').attr('tabindex', tabNumber + 2);

        $(function () {
            //$('table').colResizable({ disable: true });
            $('.popup-model .tpl99010-p table').colResizable({
                liveDrag: true,
                //disabledColumns: [0, 1],
            });
        });
        setTimeout(function () {
            $(".tpl99010-tbl .help-first-el").focus();
        }, 500);
    });

    $(".tpl99010-p .p-tpl-close").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                if ($(".tpl99010-tbl tbody tr").length > 0) {
                    $(".tpl99010-tbl .first-td").focus();
                    return false;
                } else {
                    $(".select-btn").focus();
                    return false;
                }
            } else {
                if ($(".tpl99010-tbl tbody tr").length == 0) {
                    $(".select-btn").focus();
                    return false;
                }
            }
        }
    });

    $(".tpl99010-p .select-btn").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (e.shiftKey) {
                if ($(".tpl99010-tbl tbody tr").length == 0) {
                    $(".tpl99010-p .p-tpl-close").focus();
                    return false;
                }
            }
        }
    });


    $(".tpl99010-tbl .first-td").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB || e.keyCode == KEY_ENTER) {
            if (e.shiftKey) {
                $(".tpl99010-p .p-tpl-close").focus();
                return false;
            }
        }
    });

    $(".tpl99010-tbl").on("click", "tbody tr", function () {
        currentRecord = $(this).index();
        if (!$(this).hasClass('selected')) {
            $('.tpl99010-tbl tbody tr.selected').removeClass('selected');
            $('.tpl99010-tbl tbody tr:eq(' + currentRecord + ')').addClass('selected');
        }
        //$(this).find("input").focus();
    });


    // ----Function: onKeydown----
    $(".tpl99010-tbl, .tpl99010-p .footer-p .group-pagination-content").on("keydown", function (e) {
        // ----Keypress: F8----
        if (e.key === "F8") {
            if (e.shiftKey) {
                $('.tpl99010-p .p-tpl-close').focus();
            } else {
                $('.tpl99010-p .select-btn').focus();
            }
            return false;
        }

        // ----Keypress: F7----
        if (e.key === "F7") {
            var pageCurrent = parseInt($(".tpl99010-p input[name='pageCurrent']").val());
            if (pageCurrent - 1 > 0) {
                ajaxCall1(pageCurrent - 1)
            }
            return false;
        }

        // ----Keypress: F9----
        if (e.key === "F9") {
            var pageCurrent = parseInt($(".tpl99010-p input[name='pageCurrent']").val());
            var pageTotal = $(".tpl99010-p input[name='pageTotal']").val()
            if (pageCurrent + 1 <= pageTotal) {
                ajaxCall1(pageCurrent + 1)
            }
            return false;
        }
    });
</script>

