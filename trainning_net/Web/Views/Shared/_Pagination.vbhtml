@Code ViewData("Title") = "_Pagination"
    Dim pageCurrent = Model.pageCurrent
    Dim recordEachPage = Model.pageSize
    Dim totalRecord = Model.total
    Dim page As Integer = CType(Math.Ceiling(pageCurrent / 10), Integer)
    Dim pageTotal = CType(Math.Ceiling(totalRecord / recordEachPage), Integer)
    Dim totalPagination = 0
    If pageTotal Mod 10 = 0 Then
        totalPagination = pageTotal / 10
    Else
        totalPagination = CType(Math.Floor(pageTotal / 10), Integer) + 1
    End If
    Dim pageStart = (page - 1) * 10 + 1
    Dim pageEnd = page * 10
    If pageEnd > pageTotal Then
        pageEnd = pageTotal
    End If End Code
<style>
    .pagination > li.page-item {
        display: flex;
        justify-content: center;
        align-items: center;
        margin-left: .25rem;
        outline: none;
    }

        .pagination > li.page-item:first-child {
            margin-left: 0;
        }

    .page-item.active .page-link {
        color: #007bff !important;
        background-color: white !important;
        font-weight: bold;
        border-color: #80bdff;
        padding: 0;
        padding-top: 5px;
    }

    .pagination > li > a {
        width: 100%;
        height: 100%;
        color: blue;
        border: none;
        background-color: white;
        text-align: center;
        padding: 0;
        padding-top: 5px;
    }

    .pagination > li:focus,
    .pagination > li:focus-visible,
    .pagination > li:hover,
    .pagination > li a:focus,
    .pagination > li a:focus-visible,
    .pagination > li a:hover {
        border: 1px solid #80bdff;
        border-color: #80bdff;
        outline: 0;
        box-shadow: 0 0 0 0.2rem rgb(0 123 255 / 25%);
        outline: none;
        background-color: white;
    }

    .pagination > li.page-item {
        height: 32px;
        width: 32px;
    }
</style>
<input type="hidden" value="@pageStart" name="pageStart" />
<input type="hidden" value="@pageEnd" name="pageEnd" />
<input type="hidden" value="@pageCurrent" name="pageCurrent" />
<input type="hidden" value="@pageTotal" name="pageTotal" />
<input type="hidden" value="@page" name="page" />
<nav aria-label="Page navigation example">
    <ul class="pagination" style="margin-bottom: 0px;">
        @If page > 1 Then
            @<li class="page-item"><a class="page-link" href="javascript:;" tabindex="-1"><</a></li>
        End If
        @For pageIndex As Integer = pageStart To pageEnd
            Dim active = If(pageIndex = pageCurrent, "active", "")
            @<li class="page-item @active"><a class="page-link" style="padding-bottom: 0px;" data-id-item="@pageIndex" href="javascript:;" tabindex="-1">@pageIndex</a></li>
        Next
        @If page < totalPagination Then
            @<li class="page-item"><a class="page-link" style="padding-bottom: 0px;" href="javascript:;" tabindex="-1">></a></li>
        End If
    </ul>
</nav>
<script>
    var pageCurrent = parseInt($("input[name='pageCurrent']").val());
    $(".container-fluid .pagination li.page-item a").on("click", function () {
        var pageClick = $(this).data("id-item");
        if (pageClick != undefined) {
            ajaxCall(pageClick);
        }
    })

    $(".container-fluid .pagination li:first-child a").on("click", function () {
        if ($(".pagination li:first-child a").text() == "<") {
            var page = ($("input[name='page']").val() - 1) * 10;
            ajaxCall(page);
        }
    })

    $(".container-fluid .pagination li:last-child a").on("click", function () {
        if ($(".pagination li:last-child a").text() == ">") {
            var page = $("input[name='page']").val() * 10 + 1;
            ajaxCall(page);
        }
    })

    $(".popup-model .pagination li.page-item a").on("click", function () {
        var pageClick = $(this).data("id-item");
        var tpl99010 = $(this).closest(".tpl99010-p");
        var tpl99020 = $(this).closest(".tpl99020-p");
        var tpl99040 = $(this).closest(".tpl99040-p");
        var tpl99050 = $(this).closest(".tpl99050-p");
        if (pageClick != undefined) {
            if (tpl99010.length > 0) {
                ajaxCall1(pageClick);
            } else if (tpl99020.length > 0) {
                ajaxCall2(pageClick);
            } else if (tpl99040.length > 0) {
                ajaxCall4(pageClick);
            } else if (tpl99050.length > 0) {
                ajaxCall5(pageClick);
            }
        }
    })

    $(".popup-model .pagination li:first-child a").on("click", function () {
        var tpl99010 = $(this).closest(".tpl99010-p");
        var tpl99020 = $(this).closest(".tpl99020-p");
        var tpl99040 = $(this).closest(".tpl99040-p");
        var tpl99050 = $(this).closest(".tpl99050-p");
        if ($(".pagination li:first-child a").text() == "<") {
            if (tpl99010.length > 0) {
                var page = (tpl99010.find("input[name='page']").val() - 1) * 10;
                ajaxCall1(page);
            } else if (tpl99020.length > 0) {
                var page = (tpl99020.find("input[name='page']").val() - 1) * 10;
                ajaxCall2(page);
            } else if (tpl99040.length > 0) {
                var page = (tpl99040.find("input[name='page']").val() - 1) * 10;
                ajaxCall4(page);
            } else if (tpl99050.length > 0) {
                var page = (tpl99050.find("input[name='page']").val() - 1) * 10;
                ajaxCall5(page);
            }
        }
    })

    $(".popup-model .pagination li:last-child a").on("click", function () {
        var tpl99010 = $(this).closest(".tpl99010-p");
        var tpl99020 = $(this).closest(".tpl99020-p");
        var tpl99040 = $(this).closest(".tpl99040-p");
        var tpl99050 = $(this).closest(".tpl99050-p");
        if ($(".pagination li:last-child a").text() == ">") {
            var page = $("input[name='page']").val() * 10 + 1;
            if (tpl99010.length > 0) {
                var page = tpl99010.find("input[name='page']").val() * 10 + 1;
                ajaxCall1(page);
            } else if (tpl99020.length > 0) {
                var page = tpl99020.find("input[name='page']").val() * 10 + 1;
                ajaxCall2(page);
            } else if (tpl99040.length > 0) {
                var page = tpl99040.find("input[name='page']").val() * 10 + 1;
                ajaxCall4(page);
            } else if (tpl99050.length > 0) {
                var page = tpl99050.find("input[name='page']").val() * 10 + 1;
                ajaxCall5(page);
            }
        }
    })
</script>