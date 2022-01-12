@ModelType Web.Models.TPL01040ViewModel

@Code
    ViewData("NameScreen") = "受注検索"
    ViewData("Title") = "受注検索"
    Dim cbbProductType As New List(Of Dao.ComboBoxDto)
    If ViewBag.cbbProductType IsNot Nothing Then
        cbbProductType = ViewBag.cbbProductType
    End If
    Dim listDateStartEnd() As String
    If ViewBag.listDateStartEnd IsNot Nothing Then
        listDateStartEnd = ViewBag.listDateStartEnd
    End If

End Code

@Section Scripts
    <script type="text/javascript" src="~/Scripts/custom/TPL99020W.js"></script>
    <script src="~/Scripts/custom/TPL01040.js"></script>
End Section

@Section Styles
    <link rel="stylesheet" href="~/Content/custom/screen-popup.css">
    <link rel="stylesheet" type="text/css" href="~/Content/custom/TPL01040.css">
End Section

<div class="content-page tpl01040">
    <form id="orderFrm" method="post" class="">
        @Html.AntiForgeryToken()
        <div class="header">
            <div class="group border-bottom border-dark">
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">受注番号</label>
                    @Html.TextBoxFor(Function(x) x.OrderNo, New With {.class = "form-control form-control-sm w-100px frmheader only-half-size", .tabindex = "1", .maxlength = "8", .onchange = "addZeroBefore()"})
                </div>
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">製品種別</label>
                    @Html.DropDownListFor(Function(x) x.ProductType, New SelectList(cbbProductType, "コード", "略称"), New With {.class = "form-control form-control-sm w-120px frmheader", .tabindex = "2"})
                    <label class="mb-0 txt-name ml-1cell">得意先</label>
                    @CustomHTML.CustomeHTMLHelper.TPLCustomer("Customer", "CustomerName", 100, 480, "1", False, True, 3, Nothing, Nothing)
                </div>

                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">受注日<a class="lb-required">＊</a></label>
                    @CustomHTML.CustomeHTMLHelper.TPLDatePicker(Model.StartDate, 100, 4, "date", "StartDate", False, "StartDate")
                    <div class="w-34px text-center"> ~ </div>
                    @CustomHTML.CustomeHTMLHelper.TPLDatePicker(Model.EndDate, 100, 5, "date", "EndDate", False, "EndDate")
                    <div class="group-checkbox ml-2cell">
                        <div class="custom-control custom-checkbox content-one">
                            <input type="checkbox" tabindex="6" id="IsAnyOrderBacklog" name="IsAnyOrderBacklog" class="frmheader custom-control-input" />
                            <label class="custom-control-label check-one" for="IsAnyOrderBacklog">受注残あり</label>
                        </div>
                    </div>
                </div>
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">品名</label>
                    @Html.TextBoxFor(Function(x) x.ProductName, New With {.class = "form-control form-control-sm w-480px frmheader", .tabindex = "7", .maxlength = "30"})
                    <label class="mb-0 txt-name ml-1cell">品名備考</label>
                    @Html.TextBoxFor(Function(x) x.ProductRemark, New With {.class = "form-control form-control-sm w-330px frmheader", .tabindex = "8", .maxlength = "20"})

                </div>
                <div class="d-flex align-items-center justify-content-start mb-2">
                    <label class="mb-0 txt-name">担当</label>
                    @Html.TextBoxFor(Function(x) x.Employee, New With {.class = "form-control form-control-sm w-180px frmheader", .tabindex = "9", .maxlength = "10"})
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
            @Html.Partial("_TableTPL01040")
        </div>
    </div>
</div>



