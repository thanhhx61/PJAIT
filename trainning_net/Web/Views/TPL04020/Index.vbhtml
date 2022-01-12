@ModelType Web.Models.TPL04020ViewModel
@Code
    ViewData("NameScreen") = "売上検索"
    ViewData("Title") = "売上検索"

End Code

@Section Scripts
    <script type="text/javascript" src="~/Scripts/custom/TPL99020W.js"></script>
    <script src="~/Scripts/custom/TPL04020.js"></script>
End Section

@Section Styles
    <link rel="stylesheet" href="~/Content/custom/screen-popup.css">
    <link rel="stylesheet" type="text/css" href="~/Content/custom/TPL04020.css">
End Section



<div class="content-page tpl04020">
    <form id="orderFrm" method="post" class="">
        @Html.AntiForgeryToken()
        <div class="header">
            <div class="group border-bottom border-dark">

                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">得意先</label>
                    @CustomHTML.CustomeHTMLHelper.TPLCustomer("Customer", "CustomerName", 100, 480, "1", False, True, 3, Nothing, Nothing)
                    <label class="mb-0 txt-name  ml-1cell">請求締日</label>
                    @Html.TextBoxFor(Function(x) x.Billingdeadline, New With {.class = "form-control form-control-sm w-100px frmheader only-half-size", .tabindex = "1", .maxlength = "3", .onchange = "addZeroBefore()"})
                </div>
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">受注担当</label>
                    @CustomHTML.CustomeHTMLHelper.TPLCustomer("Customer", "CustomerName", 100, 250, "1", False, True, 3, Nothing, Nothing)
                </div>
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">受注日<a class="lb-required">＊</a></label>

                    @customhtml.customehtmlHelper.TPLDatePicker(Model.StartDate, 100, 4, "date", "StartDate", False, "StartDate")

                    <div class="w-34px text-center"> ~ </div>

                    @CustomHTML.CustomeHTMLHelper.TPLDatePicker(Model.EndDate, 100, 5, "date", "EndDate", False, "EndDate")

                </div>
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <div class="ml-auto row d-flex ">
                        <button type="button" Class="btn btn-sm btn-secondary frmheader tpl-btn-mr" tabindex="10" id="btnSearch">検　索</button>
                        <button type="button" Class="btn btn-sm btn-secondary frmheader tpl-btn-mr" tabindex="11" id="btnCSV">CSV出力</button>
                    </div>
                </div>
            </div>
        </div>
        <input name="checkSearch" value="" hidden />
    </form>
    <div class="row mx-auto">
        <div id="table-container">
            @Html.Partial("_tabletpl04020")
        </div>
    </div>
</div>

