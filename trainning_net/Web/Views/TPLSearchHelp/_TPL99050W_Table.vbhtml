@ModelType Web.Models.TPL99050WViewModel

@Code
    Dim result As New List(Of Dao.ResultPaperPopupDto)
    If ViewBag.searchResult IsNot Nothing Then
        result = ViewBag.searchResult
    End If
    Dim total As Integer = ViewBag.Total
    Dim pageCurrent As Integer = ViewBag.pageCurrent
    Dim checkSearch As Boolean = ViewBag.checkSearch
    Dim pageSize = ViewBag.pageSize
    Dim resultCount = result.Count()
    Dim tabindex = 1004
    Dim btnDisabled = If(result.Any(), "", "disabled")
End Code

<div class="tpl99050-tbl mt-2">
    <div class="container-table pb-2">
        <table class="table-striped table-bordered custom-table resize-table tpl99050-cls">
            <thead class="bg-secondary text-white">
                <tr>
                    <th class="p-col-num1 text-custom-nowrap-header">No</th>
                    <th class="p-col-num2 text-custom-nowrap-header">銘柄</th>
                    <th class="p-col-num3 text-custom-nowrap-header">銘柄名</th>
                    <th class="p-col-num4 text-custom-nowrap-header"> </th>
                    <th class="p-col-num5 text-custom-nowrap-header">品種</th>
                    <th class="p-col-num6 text-custom-nowrap-header">品種名</th>
                    <th class="p-col-num7 text-custom-nowrap-header">メーカー</th>
                    <th class="p-col-num8 text-custom-nowrap-header">メーカー名</th>
                </tr>
            </thead>
            <tbody>
                @For i As Integer = 0 To result.Count() - 1 Step 1
                    tabindex = tabindex + 8
                    Dim index = i + (10 * (pageCurrent - 1))
                    Dim idFirstElementFocus = If(i = 0, "help-first-el", "")
                    Dim idFirsttd = If(i = 0, "first-td", "")
                    @<tr>
                        <td Class="p-col-num1 text-center @idFirsttd" title="No@(index)" tabindex="@(tabindex + 1)"><span Class="txt-elipsis-ver">@(index + 1)</span></td>
                        <td class="p-col-num2"  title="@result.Item(i).銘柄" tabindex="@(tabindex + 2)"><span class="txt-elipsis-ver">@result.Item(i).銘柄</span></td>
                        <td class="p-col-num3"  title="@result.Item(i).銘柄名" tabindex="@(tabindex + 3)"><span class="txt-elipsis-ver">@result.Item(i).銘柄名</span></td>
                        <td class="p-col-num4 text-center @idFirstElementFocus" title="" tabindex="@(tabindex + 4)">
                            <span class="txt-elipsis-ver"><input type="checkbox" tabindex="@(tabindex + 5)" data-id='@result.Item(i).銘柄' class="p-checkbox" /></span>
                        </td>
                        <td class="p-col-num5" title="@result.Item(i).品種" tabindex="@(tabindex + 6)"><span class="txt-elipsis-ver">@result.Item(i).品種</span></td>
                        <td class="p-col-num6" title="@result.Item(i).品種名" tabindex="@(tabindex + 7)"><span class="txt-elipsis-ver">@result.Item(i).品種名</span></td>
                        <td class="p-col-num7" title="@result.Item(i).メーカー" tabindex="@(tabindex + 8)"><span class="txt-elipsis-ver">@result.Item(i).メーカー</span></td>
                        <td class="p-col-num8" title="@result.Item(i).メーカー名" tabindex="@(tabindex + 9)"><span class="txt-elipsis-ver">@result.Item(i).メーカー名</span></td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
    <div class="group pb-3 footer-p">
        <div class="row">
            <div class="col-10 d-flex align-items-center">
                <div class="group-pagination-content">
                    @Html.Partial("_Pagination", New With {.pageCurrent = pageCurrent, .pageSize = pageSize, .Total = total})
                </div>
            </div>
            <div class="col-2 d-flex align-items-center justify-content-end h-40 pr-0">
                <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr select-btn" tabindex="@(tabindex + 9)" value="" @btnDisabled>選　択</button>
            </div>
        </div>
    </div>
</div>
<script>
    var tabNumber = @Html.Raw(tabindex + 9);
    var tabTemp = tabNumber;
    var index = 0;
    var KEY_TAB = 9;
    var KEY_ENTER = 13;
    function setWidthTable() {
        var widthDefHead = [];//920
        widthDefHead.push({ key: "No", value: 5.4 });//50
        widthDefHead.push({ key: "銘柄", value: 8.7 });//80
        widthDefHead.push({ key: "銘柄名", value: 27.2 });//250
        widthDefHead.push({ key: "check", value: 6.1 });//60
        widthDefHead.push({ key: "品種", value: 7.8 });//70
        widthDefHead.push({ key: "品種名", value: 18.5 });//170
        widthDefHead.push({ key: "メーカー", value: 7.8 });//70
        widthDefHead.push({ key: "メーカー名", value: 18.5 });//170
        for (var i = 0; i < widthDefHead.length; i++) {
            $(".tpl99050-p .p-col-num" + (i + 1)).css("width", widthDefHead[i].value.toString() + "%");
        }
    }
    setWidthTable();

    $(document).ready(function () {
        $('#ProductType').addClass("header-first-ele");
        $('.tpl99050-p .pagination li').each(function (index, value) {
            $(value).attr('tabindex', tabTemp + index + 1);
        })
        if ($('.tpl99050-p .pagination li').length > 0) {
            tabNumber = tabNumber + $('.tpl99050-p .pagination li').length;
        }
        $('.tpl99050-p .select-btn').attr('tabindex', tabNumber + 1);
        $(function () {
            //$("table").colResizable({ disable: true });
            $('.popup-model .tpl99050-p table').colResizable({
                liveDrag: true,
                //disabledColumns: [0, 1],
            });

            $(".tpl99050-p table tr td span").click(function () {
                $(this).parent().focus();
            });

            if ($(".tpl99050-tbl tbody tr").length > 0) {
                $(".tpl99050-tbl .help-first-el").focus();
            }
        });
    });

    $(".tpl99050-p input[name='ProductType']").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB || e.keyCode == KEY_ENTER) {
            if (e.shiftKey) {
                if ($(".tpl99050-tbl .select-btn").is(':disabled')) {
                    $(".tpl99050-p .p-tpl-close").focus();
                } else {
                    $(".tpl99050-tbl .select-btn").focus();
                }
                return false;
            }
        }
    })

    $(".tpl99050-p .p-tpl-close").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                if ($(".tpl99050-tbl tbody tr").length > 0) {
                    $(".tpl99050-tbl .first-td").focus();
                } else {
                    if ($(".tpl99050-tbl .select-btn").is(':disabled')) {
                        $(".tpl99050-p input[name='ProductType']").focus();
                    } else {
                        $(".tpl99050-tbl .select-btn").focus();
                    }
                }
                return false;
            }
        }
    });

    $(".tpl99050-p .select-btn").on("keydown", function (e) {
        if (e.keyCode == KEY_TAB) {
            if (!e.shiftKey) {
                $(".tpl99050-p input[name='ProductType']").focus();
                return false;
            }
        }
    });


    $(".tpl99050-tbl").on("click", "tbody tr", function () {
        currentRecord = $(this).index();
        if (!$(this).hasClass('selected')) {
            $('.tpl99050-tbl tbody tr.selected').removeClass('selected');
            $('.tpl99050-tbl tbody tr:eq(' + currentRecord + ')').addClass('selected');
        }
        //$(this).find("input").focus();
    });

    // ----Function: onKeydown----
    $(".tpl99050-tbl table, .tpl99050-p .group-pagination-content").on("keydown", function (e) {
        // ----Keypress: F8----
        if (e.key === "F8") {
            if (e.shiftKey) {
                $('.tpl99050-p .p-tpl-close').focus();
            } else {
                $('.tpl99050-p .select-btn').focus();
            }
            return false;
        }

        // ----Keypress: F7----
        if (e.key === "F7") {
            var pageCurrent = parseInt($(".tpl99050-p input[name='pageCurrent']").val());
            if (pageCurrent - 1 > 0) {
                ajaxCall5(pageCurrent - 1)
            }
            return false;
        }

        // ----Keypress: F9----
        if (e.key === "F9") {
            var pageCurrent = parseInt($(".tpl99050-p input[name='pageCurrent']").val());
            var pageTotal = $(".tpl99050-p input[name='pageTotal']").val()
            if (pageCurrent + 1 <= pageTotal) {
                ajaxCall5(pageCurrent + 1)
            }
            return false;
        }
    });
</script>
