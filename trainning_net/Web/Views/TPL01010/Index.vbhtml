<!--@Section Scripts
    <script src="~/Scripts/custom/TPL01010.js"></script>
    <script type="text/javascript" src="~/Scripts/custom/TPL99050W.js"></script>
    <script type="text/javascript" src="~/Scripts/custom/TPL99010W.js"></script>
    <script type="text/javascript" src="~/Scripts/custom/TPL99020W.js"></script>
    <script type="text/javascript" src="~/Scripts/custom/TPL99040W.js"></script>
    <script src="~/Scripts/cleave/cleave.min.js"></script>
    <script src="~/Scripts/common/input-format.js"></script>
    <script src="~/Scripts/common/table-fixed.js"></script>
End Section

@ModelType Web.Models.TPL01010ViewModel
@Code
    ViewData("NameScreen") = "受注登録"
    ViewData("Title") = "受注登録"
    Dim fistIndex = 0
    Dim tplIndex = 27
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="~/Content/custom/TPL01010.css">
    <link rel="stylesheet" href="~/Content/custom/screen-popup.css">
    <link rel="stylesheet" href="~/Content/Common/table-fixed.css">
    <link rel="stylesheet" href="~/Content/Common/table-editable.css">
End Section
@If Model.IsLoadSuccess Then
    @<div Class="content-page">
        <form id="orderFrm" method="post">
            @Html.AntiForgeryToken()
            <input name="HeaderInfo.適用区分" type="hidden" id="適用区分" value="@Model.HeaderInfo.適用区分" />
            <input name="HeaderInfo.受注金額桁数超過" type="hidden" id="受注金額桁数超過" value="@Model.HeaderInfo.受注金額桁数超過" />
            <input name="HeaderInfo.明細仕切金額桁数超過" type="hidden" id="明細仕切金額桁数超過" value="@Model.HeaderInfo.明細仕切金額桁数超過" />

            <input name="ProcessMode" type="hidden" id="ProcessMode" value="@Model.ProcessMode" />
            <input name="RowIndex" type="hidden" id="RowIndex" value="@Model.RowIndex" />
            <input name="ProcessType" type="hidden" id="ProcessType" value="@Model.ProcessType" />
            <input name="InOutValue" type="hidden" id="InOutValue" value="@Model.InOutValue" />
            <input name="DestinationClass" type="hidden" id="DestinationClass" value="@Model.DestinationClass" />
            <input name="WorkCode" type="hidden" id="WorkCode" value="" />
            <input name="BtnName" type="hidden" id="BtnName" value="" />

            <input name="制作金額合計" type="hidden" id="制作金額合計" value="@Model.制作金額合計" />
            <input name="制作仕切金額合計" type="hidden" id="制作仕切金額合計" value="@Model.制作仕切金額合計" />

            <input name="製版金額合計" type="hidden" id="製版金額合計" value="@Model.製版金額合計" />
            <input name="製版仕切金額合計" type="hidden" id="製版仕切金額合計" value="@Model.製版仕切金額合計" />

            <input name="刷版金額合計" type="hidden" id="刷版金額合計" value="@Model.刷版金額合計" />
            <input name="刷版仕切金額合計" type="hidden" id="刷版仕切金額合計" value="@Model.刷版仕切金額合計" />

            <input name="印刷金額合計" type="hidden" id="印刷金額合計" value="@Model.印刷金額合計" />
            <input name="印刷仕切金額合計" type="hidden" id="印刷仕切金額合計" value="@Model.印刷仕切金額合計" />

            <input name="加工金額合計" type="hidden" id="加工金額合計" value="@Model.加工金額合計" />
            <input name="加工仕切金額合計" type="hidden" id="加工仕切金額合計" value="@Model.加工仕切金額合計" />

            <input name="用紙金額合計" type="hidden" id="用紙金額合計" value="@Model.用紙金額合計" />
            <input name="用紙仕切金額合計" type="hidden" id="用紙仕切金額合計" value="@Model.用紙仕切金額合計" />

            <input name="その他金額合計" type="hidden" id="その他金額合計" value="@Model.その他金額合計" />
            <input name="その他仕切金額合計" type="hidden" id="その他仕切金額合計" value="@Model.その他仕切金額合計" />
            <input name="HeaderInfo.更新回数" type="hidden" id="更新回数" value="@Model.HeaderInfo.更新回数" />
            <input name="HeaderInfo.社内原価" type="hidden" id="社内原価" value="@Model.HeaderInfo.社内原価" />
            <div class="ord-header">
                <div class="group group-mb">
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">受注番号</label>
                            @Html.TextBoxFor(Function(x) x.HeaderInfo.受注番号, New With {.class = "form-control form-control-sm width-8", .disabled = "true", .tabindex = "1", .maxlength = "8", .id = "hOrderNo"})

                            <label class="mb-0 txt-name txt-name-ml">参照元</label>
                            @Html.TextBoxFor(Function(x) x.HeaderInfo.参照元, New With {.class = "form-control form-control-sm width-8", .disabled = "true", .tabindex = "2", .maxlength = "8"})

                            <label class="mb-0 txt-name txt-name-ml">先方注番</label>
                            @Html.TextBoxFor(Function(x) x.HeaderInfo.先方注番, New With {.class = "form-control form-control-sm width-10 only-half-size", .tabindex = "3", .maxlength = "10", .id = "destNumber"})
                            <span class="mb-0 text-danger txt-name-ml">@Model.HeaderInfo.SSAvailable</span>
                        </div>
                    </div>

                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">品名<span class="text-danger"> *</span></label>
                            @Html.TextBoxFor(Function(x) x.HeaderInfo.品名, New With {.class = "form-control form-control-sm prd-name-w", .tabindex = "4", .maxlength = "30", .id = "hProductName"})

                            <label class="mb-0 txt-name txt-name-ml5">品名備考</label>
                            @Html.TextBoxFor(Function(x) x.HeaderInfo.品名備考, New With {.class = "form-control form-control-sm prd-name-w", .tabindex = "5", .maxlength = "20"})
                        </div>

                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">得意先<span class="text-danger"> *</span></label>
                            @CustomHTML.CustomeHTMLHelper.TPLCustomer("HeaderInfo.得意先", "HeaderInfo.得意先名", 90, 374, "1", Model.HeaderInfo.DisabledCst, True, 6, Model.HeaderInfo.得意先, Model.HeaderInfo.得意先名, "h得意先")
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">担当<span class="text-danger"> *</span></label>
                            @CustomHTML.CustomeHTMLHelper.TPLDepartment("HeaderInfo.担当", "HeaderInfo.部署名", "HeaderInfo.担当名", "HeaderInfo.部署", 90, 170, 136, 7, Model.HeaderInfo.担当, Model.HeaderInfo.部署名, Model.HeaderInfo.担当名, Model.HeaderInfo.部署, "h担当")
                        </div>
                    </div>

                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">伝票区分</label>
                            @Html.DropDownListFor(Function(x) x.HeaderInfo.伝票区分, New SelectList(Model.SlipClassList, "Value", "Text"), New With {.class = "form-control form-control-sm pl-1 mr-0 combobox-w", .tabindex = "8"})

                            <label class="mb-0 txt-name txt-name-ml1">受注区分</label>
                            @Html.DropDownListFor(Function(x) x.HeaderInfo.受注区分, New SelectList(Model.OrderClassList, "Value", "Text"), New With {.class = "form-control form-control-sm pl-1 mr-0 combobox-w", .tabindex = "9"})

                            <label class="mb-0 txt-name txt-name-ml1">製品種別</label>
                            @Html.DropDownListFor(Function(x) x.HeaderInfo.製品種別, New SelectList(Model.ProducTypeList, "Value", "Text"), New With {.class = "form-control form-control-sm pl-1 mr-0 combobox-w", .tabindex = "10"})
                        </div>
                    </div>
                </div>

                <div class="group group-mb">
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">受注日<span class="text-danger"> *</span></label>
                            @CustomHTML.CustomeHTMLHelper.TPLDatePicker(Model.HeaderInfo.受注日, 100, 11, "date", "HeaderInfo.受注日", Model.HeaderInfo.DisableOrderDate, "orderDate")

                            <label class="mb-0 txt-name txt-name-ml2">納品日<span class="text-danger"> *</span></label>
                            @CustomHTML.CustomeHTMLHelper.TPLDatePicker(Model.HeaderInfo.納品日, 100, 12, "date", "HeaderInfo.納品日", False, "deliveryDate")

                            <label class="mb-0 txt-name txt-name-ml2">検収日</label>
                            @CustomHTML.CustomeHTMLHelper.TPLDatePicker(Model.HeaderInfo.検収日, 100, 13, "date", "HeaderInfo.検収日", False, "acceptanceDate")

                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">製品サイズ</label>
                            @Html.DropDownListFor(Function(x) x.HeaderInfo.製品サイズ, New SelectList(Model.ProductSizeList, "Value", "Text"), New With {.class = "form-control form-control-sm pl-1 mr-0 combobox-w", .tabindex = "14", .id = "productSize"})

                            <label class="mb-0 txt-name txt-name-ml1">縦</label>
                            @If Model.HeaderInfo.DisabledVertical Then
                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.縦, New With {.class = "form-control form-control-sm width-4-5", .id = "hvertical", .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "5", .tabindex = "15", .disabled = "true"})
                            Else
                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.縦, New With {.class = "form-control form-control-sm width-4-5", .id = "hvertical", .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "5", .tabindex = "15"})
                            End If
                            <label class="mb-0 txt-name txt-name-ml3">横</label>
                            @If Model.HeaderInfo.DisableBeside Then
                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.横, New With {.class = "form-control form-control-sm width-4-5", .id = "hbeside", .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "5", .tabindex = "16", .disabled = "true"})
                            Else
                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.横, New With {.class = "form-control form-control-sm width-4-5", .id = "hbeside", .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "5", .tabindex = "16"})
                            End If

                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">頁数</label>
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.頁数, New With {.class = "form-control form-control-sm width-4-5", .id = "hPageNumber", .numeralIntegerScale = 5, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "6", .tabindex = "17"})
                        </div>
                    </div>
                </div>

                <div class="group">
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">受注数量</label>
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.受注数量, New With {.class = "form-control form-control-sm width-9-10", .id = "hOrderQuantity", .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "11", .tabindex = "18"})

                            <label class="mb-0 txt-name txt-name-ml1">受注単価</label>
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.受注単価, New With {.class = "form-control form-control-sm width-9-10", .id = "hUnitPrice", .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .maxlength = "13", .tabindex = "19"})

                            <label class="mb-0 txt-name txt-name-ml1">受注金額<span class="text-danger"> *</span></label>
                            @If Model.HeaderInfo.DisabledOrderAmount Then
                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.受注金額, New With {.class = "form-control form-control-sm width-9-10", .id = "hOrderAmount", .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "11", .disabled = "true", .tabindex = "20"})
                            Else
                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.受注金額, New With {.class = "form-control form-control-sm width-9-10", .id = "hOrderAmount", .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "11", .tabindex = "20"})
                            End If
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">明細金額</label>
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.明細金額, New With {.class = "form-control form-control-sm width-9-10", .id = "hDetailAmount", .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "11", .disabled = "true", .tabindex = "21"})

                            <label class="mb-0 txt-name txt-name-ml1">明細仕切金額</label>
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.明細仕切金額, New With {.class = "form-control form-control-sm width-9-10", .id = "hDetailPAmount", .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "11", .disabled = "true", .tabindex = "22"})

                            <label class="mb-0 txt-name txt-name-ml1">受注利益</label>
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.受注利益, New With {.class = "form-control form-control-sm width-9-10", .id = "hProfit", .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .maxlength = "11", .disabled = "true", .tabindex = "23"})
                            @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.HeaderInfo.受注利益率, New With {.class = "form-control form-control-sm width-9-10", .id = "hProfitMargin", .numeralIntegerScale = 3, .numeralDecimalScale = 1, .style = "text-align: right;", .maxlength = "5", .disabled = "true", .tabindex = "24"})
                            <div class="ml-1 d-flex align-items-center">%</div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">単位</label>
                            @Html.DropDownListFor(Function(x) x.HeaderInfo.単位, New SelectList(Model.ProductUnitList, "Value", "Text"), New With {.class = "form-control form-control-sm pl-1 mr-0 combobox-w1", .tabindex = "25"})

                            <label class="mb-0 txt-name txt-name-ml4">FSC</label>
                            <div class="custom-control custom-checkbox">
                                @Html.CheckBoxFor(Function(x) x.HeaderInfo.FSC, New With {.class = "custom-control-input", .type = "checkbox", .tabIndex = "26"})
                                <label class="custom-control-label" for="HeaderInfo_FSC">
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="ord-body">-->
                @*制作*@
                <!--<div class="group prd-div pt-2">
                    <div class="row">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">制作</label>
                        </div>
                        <div class="col-12 mx-auto d-flex align-items-center">

                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-1">
                        <div class="prd-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped prd-table-w table-fixed table-bordered">
                                <thead>
                                    <tr>
                                        <th class="">内外</th>
                                        <th class="">作業</th>
                                        <th class="">作業名</th>
                                        <th class="">数量</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.ProductionList.Count - 1
                                        If i > 0 Then
                                            tplIndex = tplIndex + 8
                                        End If
                                        @<tr>
                                            <td class="cbo-row">
                                                @Html.DropDownListFor(Function(x) x.ProductionList.Item(i).内外区分, New SelectList(Model.InOutClassList, "Value", "Text", Model.ProductionList.Item(i).内外区分), New With {.class = "form-control in-out-cls prd-col-w1", .id = "prdInOutKbn" + i.ToString(), .tabindex = tplIndex + 1, .Name = "ProductionList[" + i.ToString + "].内外区分"})
                                            </td>
                                            <td>
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("ProductionList[" + i.ToString + "].作業", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.TASK_PRODUCTION, False, tplIndex + 2, Model.ProductionList.Item(i).作業, "input-grid prd-col-w2", "prd作業" + i.ToString)
                                            </td>
                                            <td title="@Model.ProductionList.Item(i).作業名">
                                                <span class="txt-elipsis-ver c-name prd-col-w3">@Model.ProductionList.Item(i).作業名</span>
                                                <input name="ProductionList[@i.ToString].作業名" type="hidden" value="@Model.ProductionList.Item(i).作業名" class="c-name" />
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ProductionList.Item(i).数量, New With {.class = "form-control input-grid prd-quantity prd-col-num-w1", .id = "prdQuantity" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 3})
                                            </td>
                                            <td Class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ProductionList.Item(i).単価, New With {.class = "form-control input-grid prd-unit-price prd-col-num-w2", .id = "prdUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 4})
                                            </td>
                                            <td class="text-right">
                                                @If Model.ProductionList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ProductionList.Item(i).金額, New With {.class = "form-control input-grid prd-amount prd-col-num-w1", .id = "prdAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 5})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ProductionList.Item(i).金額, New With {.class = "form-control input-grid prd-amount prd-col-num-w1", .id = "prdAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 5})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ProductionList.Item(i).仕切単価, New With {.class = "form-control input-grid prd-col-num-w2", .id = "prdPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 6})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ProductionList.Item(i).仕切金額, New With {.class = "form-control input-grid prd-col-num-w2", .id = "prdPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 7})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->

                @*製版・デジタル印刷*@
                <!--<div class="pt-2">
                    <div class="group plt-dgtl-ttl-div ">
                        <div class="row">
                            <div class="col-12 mx-auto d-flex align-items-center">
                                <label class="mb-0 txt-name">製版・デジタル印刷</label>
                            </div>
                            <div class="col-12 mx-auto d-flex align-items-center">

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row plt-dgtl-div">
                    <div class="col-1">
                        <div class="plt-dgtl-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped plt-dgtl-table-w table-fixed table-bordered" colfixed="6">
                                <thead>
                                    <tr>
                                        <th class="sticky-col sticky-col1">内外</th>
                                        <th class="sticky-col sticky-col2">作業</th>
                                        <th class="sticky-col sticky-col3">作業名</th>
                                        <th class="sticky-col sticky-col4">部品</th>
                                        <th class="sticky-col sticky-col5">部品名</th>
                                        <th class="sticky-col sticky-col6">頁数</th>
                                        <th class="">色数</th>
                                        <th class="">数量</th>
                                        <th class="">数量合計</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.PlateMakingDigitalPrintingList.Count - 1
                                        If i = 0 Then
                                            tplIndex = tplIndex + 8
                                        Else
                                            tplIndex = tplIndex + 12
                                        End If
                                        @<tr>
                                            <td class="cbo-row sticky-col sticky-col1">
                                                @Html.DropDownListFor(Function(x) x.PlateMakingDigitalPrintingList.Item(i).内外区分, New SelectList(Model.InOutClassList, "Value", "Text", Model.PlateMakingDigitalPrintingList.Item(i).内外区分), New With {.class = "form-control in-out-cls plt-dgtl-col-w1", .id = "pltDgtlInOutKbn" + i.ToString(), .tabindex = tplIndex + 1, .Name = "PlateMakingDigitalPrintingList[" + i.ToString + "].内外区分"})
                                            </td>
                                            <td class="sticky-col sticky-col2">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PlateMakingDigitalPrintingList[" + i.ToString + "].作業", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.TASK_PLATE_MAKING, False, tplIndex + 2, Model.PlateMakingDigitalPrintingList.Item(i).作業, "input-grid plt-dgtl-col-w2", "pltDgtl作業" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col3" title="@Model.PlateMakingDigitalPrintingList.Item(i).作業名">
                                                <span class="txt-elipsis-ver c-name plt-dgtl-col-w3">@Model.PlateMakingDigitalPrintingList.Item(i).作業名</span>
                                                <input name="PlateMakingDigitalPrintingList[@i.ToString].作業名" type="hidden" value="@Model.PlateMakingDigitalPrintingList.Item(i).作業名" class="c-name plt-dgtl-col-w3" />-->
                                                @*<input type="text" class="form-control input-grid" name="PlateMakingDigitalPrintingList[@i.ToString].作業名" id="pltDgt作業名-@i" maxlength="30" value="@Model.PlateMakingDigitalPrintingList.Item(i).作業">*@
                                            <!--</td>
                                            <td class="sticky-col sticky-col4">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PlateMakingDigitalPrintingList[" + i.ToString + "].部品", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.PARTS, False, tplIndex + 3, Model.PlateMakingDigitalPrintingList.Item(i).部品, "input-grid plt-dgtl-col-w4", "pltDgtl部品" + i.ToString)
                                            </td>
                                            <td Class="sticky-col sticky-col5" title="@Model.PlateMakingDigitalPrintingList.Item(i).部品名">
                                                <span class="txt-elipsis-ver c-name plt-dgtl-col-w5">@Model.PlateMakingDigitalPrintingList.Item(i).部品名</span>
                                                <input name="PlateMakingDigitalPrintingList[@i.ToString].部品名" type="hidden" value="@Model.PlateMakingDigitalPrintingList.Item(i).部品名" class="c-name" />-->
                                                @*<input type="text" class="form-control input-grid" name="PlateMakingDigitalPrintingList[@i.ToString].部品名" id="pltDgt部品名-@i" maxlength="30" value="@Model.PlateMakingDigitalPrintingList.Item(i).部品名">*@
                                            <!--</td>
                                            <td class="text-right sticky-col sticky-col6">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).頁数, New With {.class = "form-control input-grid plt-dgtl-col-w6", .id = "pltDgtlPageNumber" + i.ToString(), .numeralIntegerScale = 5, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 4})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).色数, New With {.class = "form-control input-grid plt-dgtl-color-number plt-dgtl-col-w7", .id = "pltDgtlColorNumber" + i.ToString(), .numeralIntegerScale = 2, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 5})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).数量, New With {.class = "form-control input-grid plt-dgtl-quantity plt-dgtl-col-num-w1", .id = "pltDgtlQuantity" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 6})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).数量合計, New With {.class = "form-control input-grid plt-dgtl-quantity-total plt-dgtl-col-num-w1", .id = "pltDgtlQuantityTotal" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 7})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).単価, New With {.class = "form-control input-grid plt-dgtl-unit-price plt-dgtl-col-num-w2", .id = "pltDgtlUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 8})
                                            </td>
                                            <td class="text-right">
                                                @If Model.PlateMakingDigitalPrintingList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).金額, New With {.class = "form-control input-grid plt-dgtl-amount plt-dgtl-col-num-w1", .id = "pltDgtlAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 9})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).金額, New With {.class = "form-control input-grid plt-dgtl-amount plt-dgtl-col-num-w1", .id = "pltDgtlAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 9})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).仕切単価, New With {.class = "form-control input-grid plt-dgtl-col-num-w2", .id = "pltDgtlPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 10})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlateMakingDigitalPrintingList.Item(i).仕切金額, New With {.class = "form-control input-grid plt-dgtl-col-num-w2", .id = "pltDgtlPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 11})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->

                @*刷版*@
                <!--<div class="pt-2">
                    <div class="group prt-plt-ttl-div">
                        <div class="row">
                            <div class="col-12 mx-auto d-flex align-items-center">
                                <label class="mb-0 txt-name">刷版</label>
                            </div>
                            <div class="col-12 mx-auto d-flex align-items-center">

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row prt-plt-div">
                    <div class="col-1">
                        <div class="pp-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped pp-table-w table-fixed table-bordered" colfixed="8">
                                <thead>
                                    <tr>
                                        <th class="sticky-col sticky-col1">内外</th>
                                        <th class="sticky-col sticky-col2">部品</th>
                                        <th class="sticky-col sticky-col3">部品名</th>
                                        <th class="sticky-col sticky-col4">頁数</th>
                                        <th class="sticky-col sticky-col5">作業</th>
                                        <th class="sticky-col sticky-col6">作業名</th>
                                        <th class="sticky-col sticky-col7">サイズ</th>
                                        <th class="sticky-col sticky-col8">サイズ名</th>
                                        <th class="">面付</th>
                                        <th class="">色表</th>
                                        <th class="">色裏</th>
                                        <th class="">台数</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.PlatePrintingList.Count - 1
                                        If i = 0 Then
                                            tplIndex = tplIndex + 12
                                        Else
                                            tplIndex = tplIndex + 14
                                        End If
                                        @<tr>
                                            <td class="cbo-row sticky-col sticky-col1">
                                                @Html.DropDownListFor(Function(x) x.PlatePrintingList.Item(i).内外区分, New SelectList(Model.InOutClassList, "Value", "Text", Model.PlatePrintingList.Item(i).内外区分), New With {.class = "form-control in-out-cls pp-col-w1", .id = "ppInOutKbn" + i.ToString(), .tabindex = tplIndex + 1, .Name = "PlatePrintingList[" + i.ToString + "].内外区分"})
                                            </td>
                                            <td class="sticky-col sticky-col2">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PlatePrintingList[" + i.ToString + "].部品", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.PARTS, False, tplIndex + 2, Model.PlatePrintingList.Item(i).部品, "input-grid pp-col-w2", "pp部品" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col3" title="@Model.PlatePrintingList.Item(i).部品名">
                                                <span class="txt-elipsis-ver c-name pp-col-w3">@Model.PlatePrintingList.Item(i).部品名</span>
                                                <input name="PlatePrintingList[@i.ToString].部品名" type="hidden" value="@Model.PlatePrintingList.Item(i).部品名" class="c-name" />
                                            </td>
                                            <td class="text-right sticky-col sticky-col4">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).頁数, New With {.class = "form-control input-grid pp-quantity pp-col-w4", .id = "ppQuantity" + i.ToString(), .numeralIntegerScale = 5, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 3})
                                            </td>
                                            <td class="sticky-col sticky-col5">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PlatePrintingList[" + i.ToString + "].作業", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.TASK_PRINTING_PLATE, False, tplIndex + 4, Model.PlatePrintingList.Item(i).作業, "input-grid pp-col-w5", "pp作業" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col6" title="@Model.PlatePrintingList.Item(i).作業名">
                                                <span class="txt-elipsis-ver c-name pp-col-w6">@Model.PlatePrintingList.Item(i).作業名</span>
                                                <input name="PlatePrintingList[@i.ToString].作業名" type="hidden" value="@Model.PlatePrintingList.Item(i).作業名" class="c-name" />
                                            </td>
                                            <td class="sticky-col sticky-col7">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PlatePrintingList[" + i.ToString + "].サイズ", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.PAPER_SIZE, False, tplIndex + 5, Model.PlatePrintingList.Item(i).サイズ, "input-grid pp-col-w7", "ppサイズ" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col8" title="@Model.PlatePrintingList.Item(i).サイズ名">
                                                <span class="txt-elipsis-ver c-name pp-col-w8">@Model.PlatePrintingList.Item(i).サイズ名</span>
                                                <input name="PlatePrintingList[@i.ToString].サイズ名" type="hidden" value="@Model.PlatePrintingList.Item(i).サイズ名" class="c-name" />
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).面付, New With {.class = "form-control input-grid pp-col-num-w1", .id = "ppImpos" + i.ToString(), .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 6})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).色表, New With {.class = "form-control input-grid pp-color-chart pp-col-num-w1", .id = "ppColorChart" + i.ToString(), .numeralIntegerScale = 2, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 7})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).色裏, New With {.class = "form-control input-grid pp-color-back pp-col-num-w1", .id = "ppColorBack" + i.ToString(), .numeralIntegerScale = 2, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 8})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).台数, New With {.class = "form-control input-grid pp-unit-number pp-col-num-w1", .id = "ppUnitNumber" + i.ToString(), .numeralIntegerScale = 3, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 9})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).単価, New With {.class = "form-control input-grid pp-unit-price pp-col-num-w3", .id = "ppUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 10})
                                            </td>
                                            <td class="text-right">
                                                @If Model.PlatePrintingList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).金額, New With {.class = "form-control input-grid pp-amount pp-col-num-w2", .id = "ppAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 11})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).金額, New With {.class = "form-control input-grid pp-amount pp-col-num-w2", .id = "ppAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 11})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).仕切単価, New With {.class = "form-control input-grid pp-col-num-w3", .id = "ppPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 12})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PlatePrintingList.Item(i).仕切金額, New With {.class = "form-control input-grid pp-col-num-w3", .id = "ppPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 13})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->

                @*印刷*@
                <!--<div class="pt-2">
                    <div class="group prt-ttl-div">
                        <div class="row">
                            <div class="col-12 mx-auto d-flex align-items-center">
                                <label class="mb-0 txt-name">印刷</label>
                            </div>
                            <div class="col-12 mx-auto d-flex align-items-center">

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row prt-div">
                    <div class="col-1">
                        <div class="prt-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped prt-table-w table-fixed table-bordered" colfixed="8">
                                <thead>
                                    <tr>
                                        <th class="sticky-col sticky-col1">内外</th>
                                        <th class="sticky-col sticky-col2">部品</th>
                                        <th class="sticky-col sticky-col3">部品名</th>
                                        <th class="sticky-col sticky-col4">頁数</th>
                                        <th class="sticky-col sticky-col5">機種</th>
                                        <th class="sticky-col sticky-col6">機種名</th>
                                        <th class="sticky-col sticky-col7">サイズ</th>
                                        <th class="sticky-col sticky-col8">サイズ名</th>
                                        <th class="">通し数</th>
                                        <th class="">色表</th>
                                        <th class="">色裏</th>
                                        <th class="">台数</th>
                                        <th class="">計算区分</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.PrintingList.Count - 1
                                        If i = 0 Then
                                            tplIndex = tplIndex + 14
                                        Else
                                            tplIndex = tplIndex + 15
                                        End If
                                        @<tr>
                                            <td class="cbo-row sticky-col sticky-col1">
                                                @Html.DropDownListFor(Function(x) x.PrintingList.Item(i).サイズ, New SelectList(Model.InOutClassList, "Value", "Text", Model.PrintingList.Item(i).内外区分), New With {.class = "form-control in-out-cls prt-col-w1", .id = "prtInOutKbn" + i.ToString(), .tabindex = tplIndex + 1, .Name = "PrintingList[" + i.ToString + "].内外区分"})
                                            </td>
                                            <td class="sticky-col sticky-col2">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PrintingList[" + i.ToString + "].部品", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Nothing, True, tplIndex + 2, Model.PrintingList.Item(i).部品, "input-grid prt-col-w2", "prt部品" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col3" title="@Model.PrintingList.Item(i).部品名">
                                                <span class="txt-elipsis-ver c-name prt-col-w3">@Model.PrintingList.Item(i).部品名</span>
                                                <input name="PrintingList[@i.ToString].部品名" type="hidden" value="@Model.PrintingList.Item(i).部品名" class="c-name" />
                                            </td>
                                            <td class="text-right sticky-col sticky-col4">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).頁数, New With {.class = "form-control input-grid prt-col-w4", .id = "prtPageNumber" + i.ToString(), .numeralIntegerScale = 5, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 3})
                                            </td>
                                            <td class="sticky-col sticky-col5">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PrintingList[" + i.ToString + "].機種", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.MODEL, False, tplIndex + 4, Model.PrintingList.Item(i).機種, "input-grid prt-col-w5", "prt機種" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col6" title="@Model.PrintingList.Item(i).機種名">
                                                <span class="txt-elipsis-ver c-name prt-col-w6">@Model.PrintingList.Item(i).機種名</span>
                                                <input name="PrintingList[@i.ToString].機種名" type="hidden" value="@Model.PrintingList.Item(i).機種名" class="c-name" />
                                            </td>
                                            <td class="sticky-col sticky-col7">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PrintingList[" + i.ToString + "].サイズ", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Nothing, True, tplIndex + 5, Model.PrintingList.Item(i).サイズ, "input-grid prt-col-w7", "prtサイズ" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col8" title="@Model.PrintingList.Item(i).サイズ名">
                                                <span class="txt-elipsis-ver c-name prt-col-w8">@Model.PrintingList.Item(i).サイズ名</span>
                                                <input name="PrintingList[@i.ToString].サイズ名" type="hidden" value="@Model.PrintingList.Item(i).サイズ名" class="c-name" />
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).通し数, New With {.class = "form-control input-grid prt-thread-numbe prt-col-num-w1", .id = "prtThreadNumber" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 6})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).色表, New With {.class = "form-control input-grid prt-col-num-w2", .id = "prtColorChart" + i.ToString(), .numeralIntegerScale = 2, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 7})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).色裏, New With {.class = "form-control input-grid prt-col-num-w2", .id = "prtColorBack" + i.ToString(), .numeralIntegerScale = 2, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 8})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).台数, New With {.class = "form-control input-grid prt-col-num-w2", .id = "prtUnitNumber" + i.ToString(), .numeralIntegerScale = 3, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 9})
                                            </td>
                                            <td class="text-right">
                                                @Html.DropDownListFor(Function(x) x.PrintingList.Item(i).計算区分, New SelectList(Model.CalculationClassList, "Value", "Text", Model.PrintingList.Item(i).計算区分), New With {.class = "form-control prt-cal-class prt-col-combo-w1", .id = "prtCalClass" + i.ToString(), .tabindex = tplIndex + 10, .Name = "PrintingList[" + i.ToString + "].計算区分"})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).単価, New With {.class = "form-control input-grid prt-unit-price prt-col-num-w4", .id = "prtUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 11})
                                            </td>
                                            <td class="text-right">
                                                @If Model.PrintingList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).金額, New With {.class = "form-control input-grid prt-amount prt-col-num-w3", .id = "prtAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 12})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).金額, New With {.class = "form-control input-grid prt-amount prt-col-num-w3", .id = "prtAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 12})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).仕切単価, New With {.class = "form-control input-grid prt-col-num-w4", .id = "prtPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 13})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PrintingList.Item(i).仕切金額, New With {.class = "form-control input-grid prt-col-num-w4", .id = "prtPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 14})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->

                @*加工*@
                <!--<div class="group prcs-div pt-2">
                    <div class="row">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">加工</label>
                        </div>
                        <div class="col-12 mx-auto d-flex align-items-center">

                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-1">
                        <div class="prcs-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped prcs-table-w table-fixed table-bordered">
                                <thead>
                                    <tr>
                                        <th class="">内外</th>
                                        <th class="">作業</th>
                                        <th class="">作業名</th>
                                        <th class="">サイズ</th>
                                        <th class="">サイズ名</th>
                                        <th class="">数量</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.ManufacturingList.Count - 1
                                        If i = 0 Then
                                            tplIndex = tplIndex + 15
                                        Else
                                            tplIndex = tplIndex + 9
                                        End If
                                        @<tr>
                                            <td class="cbo-row">
                                                @Html.DropDownListFor(Function(x) x.ManufacturingList.Item(i).内外区分, New SelectList(Model.InOutClassList, "Value", "Text", Model.ManufacturingList.Item(i).内外区分), New With {.class = "form-control in-out-cls prcs-col-w1", .id = "prcsInOutKbn" + i.ToString(), .tabindex = tplIndex + 1, .Name = "ManufacturingList[" + i.ToString + "].内外区分"})
                                            </td>
                                            <td>
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("ManufacturingList[" + i.ToString + "].作業", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.TASK_PROCESSING, False, tplIndex + 2, Model.ManufacturingList.Item(i).作業, "input-grid prcs-col-w2", "prcs作業" + i.ToString)
                                            </td>
                                            <td title="@Model.ManufacturingList.Item(i).作業名">
                                                <span class="txt-elipsis-ver c-name prcs-col-w3">@Model.ManufacturingList.Item(i).作業名</span>
                                                <input name="ManufacturingList[@i.ToString].作業名" type="hidden" value="@Model.ManufacturingList.Item(i).作業名" class="c-name" />
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("ManufacturingList[" + i.ToString + "].サイズ", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.PAPER_SIZE, False, tplIndex + 3, Model.ManufacturingList.Item(i).サイズ, "input-grid prcs-col-w4", "prcsサイズ" + i.ToString)
                                            </td>
                                            <td title="@Model.ManufacturingList.Item(i).サイズ名">
                                                <span class="txt-elipsis-ver c-name prcs-col-w5">@Model.ManufacturingList.Item(i).サイズ名</span>
                                                <input name="ManufacturingList[@i.ToString].サイズ名" type="hidden" value="@Model.ManufacturingList.Item(i).サイズ名" class="c-name" />
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ManufacturingList.Item(i).数量, New With {.class = "form-control input-grid prcs-quantity prcs-col-num-w1", .id = "prcsQuantity" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 4})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ManufacturingList.Item(i).単価, New With {.class = "form-control input-grid prcs-unit-price prcs-col-num-w2", .id = "prcsUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 5})
                                            </td>
                                            <td class="text-right">
                                                @If Model.ManufacturingList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ManufacturingList.Item(i).金額, New With {.class = "form-control input-grid prcs-amount prcs-col-num-w1", .id = "prcsAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 6})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ManufacturingList.Item(i).金額, New With {.class = "form-control input-grid prcs-amount prcs-col-num-w1", .id = "prcsAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 6})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ManufacturingList.Item(i).仕切単価, New With {.class = "form-control input-grid prcs-col-num-w2", .id = "prcsPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 7})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.ManufacturingList.Item(i).仕切金額, New With {.class = "form-control input-grid prcs-col-num-w2", .id = "prcsPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 8})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->

                @*用紙*@
                <!--<div class="pt-2">
                    <div class="group paper-ttl-div">
                        <div class="row">
                            <div class="col-12 mx-auto d-flex align-items-center">
                                <label class="mb-0 txt-name">用紙</label>
                            </div>
                            <div class="col-12 mx-auto d-flex align-items-center">

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row prt-div">
                    <div class="col-1">
                        <div class="paper-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped paper-table-w table-fixed table-bordered" colfixed="10">
                                <thead>
                                    <tr>
                                        <th class="sticky-col sticky-col1">当/先</th>
                                        <th class="sticky-col sticky-col2">部品</th>
                                        <th class="sticky-col sticky-col3">部品名</th>
                                        <th class="sticky-col sticky-col4">頁数</th>
                                        <th class="sticky-col sticky-col5">銘柄</th>
                                        <th class="sticky-col sticky-col6">銘柄名</th>
                                        <th class="sticky-col sticky-col7">規格</th>
                                        <th class="sticky-col sticky-col8">縦</th>
                                        <th class="sticky-col sticky-col9">横</th>
                                        <th class="sticky-col sticky-col10">R/S</th>
                                        <th class="">連量</th>
                                        <th class="">単位区分</th>
                                        <th class="">数量</th>
                                        <th class="">予備</th>
                                        <th class="">数量合計</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.PaperList.Count - 1
                                        If i = 0 Then
                                            tplIndex = tplIndex + 9
                                        Else
                                            tplIndex = tplIndex + 18
                                        End If
                                        @<tr>
                                            <td class="cbo-row sticky-col sticky-col1">
                                                @Html.DropDownListFor(Function(x) x.PaperList.Item(i).当先区分, New SelectList(Model.DestinationClassList, "Value", "Text", Model.PaperList.Item(i).当先区分), New With {.class = "form-control paper当先 paper-col-w1", .id = "paper当先" + i.ToString(), .tabindex = tplIndex + 1, .Name = "PaperList[" + i.ToString + "].当先区分"})
                                            </td>
                                            <td class="sticky-col sticky-col2">
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("PaperList[" + i.ToString + "].部品", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.PARTS, False, tplIndex + 2, Model.PaperList.Item(i).部品, "input-grid paper-col-w2", "paper部品" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col3" title="@Model.PaperList.Item(i).部品名">
                                                <span class="txt-elipsis-ver c-name paper-col-w3">@Model.PaperList.Item(i).部品名</span>
                                                <input name="PaperList[@i.ToString].部品名" type="hidden" value="@Model.PaperList.Item(i).部品名" class="c-name" />
                                            </td>
                                            <td class="text-right sticky-col sticky-col4">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).頁数, New With {.class = "form-control input-grid paper-col-w4", .id = "paperPageNumber" + i.ToString(), .numeralIntegerScale = 5, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 3})
                                            </td>
                                            <td class="sticky-col sticky-col5">
                                                @CustomHTML.CustomeHTMLHelper.TPLPaperForGrid("PaperList[" + i.ToString + "].銘柄", 85, False, tplIndex + 4, Model.PaperList.Item(i).銘柄, "input-grid paper-col-w5", "paper銘柄" + i.ToString)
                                            </td>
                                            <td class="sticky-col sticky-col6" title="@Model.PaperList.Item(i).銘柄名">
                                                <span class="txt-elipsis-ver c-name paper-col-w6">@Model.PaperList.Item(i).銘柄名</span>
                                                <input name="PaperList[@i.ToString].銘柄名" type="hidden" value="@Model.PaperList.Item(i).銘柄名" class="c-name" />
                                            </td>
                                            <td class="sticky-col sticky-col7">
                                                @Html.DropDownListFor(Function(x) x.PaperList.Item(i).規格, New SelectList(Model.PaperSizeClassList, "Value", "Text", Model.PaperList.Item(i).規格), New With {.class = "form-control paper規格 paper-col-w7", .id = "paper規格" + i.ToString(), .tabindex = tplIndex + 5, .Name = "PaperList[" + i.ToString + "].規格"})
                                            </td>
                                            <td class="text-right sticky-col sticky-col8">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).縦, New With {.class = "form-control input-grid pp-vertical paper-col-num-w1", .id = "paperVertical" + i.ToString(), .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 6})
                                            </td>
                                            <td class="text-right sticky-col sticky-col9">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).横, New With {.class = "form-control input-grid pp-beside paper-col-num-w1", .id = "paperBeside" + i.ToString(), .numeralIntegerScale = 4, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 7})
                                            </td>
                                            <td class="sticky-col sticky-col10">
                                                @Html.DropDownListFor(Function(x) x.PaperList.Item(i).RS区分, New SelectList(Model.RsClassList, "Value", "Text", Model.PaperList.Item(i).RS区分), New With {.class = "form-control paper-col-w10", .id = "paperRs" + i.ToString(), .tabindex = tplIndex + 8, .Name = "PaperList[" + i.ToString + "].RS区分"})
                                            </td>

                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).連量, New With {.class = "form-control input-grid paper-col-num-w2", .id = "paperRenAmount" + i.ToString(), .numeralIntegerScale = 3, .numeralDecimalScale = 1, .style = "text-align: right;", .tabindex = tplIndex + 9})
                                            </td>
                                            <td class="">
                                                @Html.DropDownListFor(Function(x) x.PaperList.Item(i).単位区分, New SelectList(Model.UnitClassList, "Value", "Text", Model.PaperList.Item(i).単位区分), New With {.class = "form-control paper-unit-class paper-col-w12", .id = "paperUnitClass" + i.ToString(), .tabindex = tplIndex + 10, .Name = "PaperList[" + i.ToString + "].単位区分"})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).数量, New With {.class = "form-control input-grid paper-quantity paper-col-num-w3", .id = "paperQuantity" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 11})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).予備, New With {.class = "form-control input-grid paper-reserve paper-col-num-w3", .id = "paperReserve" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 12})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).数量合計, New With {.class = "form-control input-grid paper-quantity-total paper-col-num-w3", .id = "paperQuantityTotal" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 13})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).単価, New With {.class = "form-control input-grid paper-unit-price paper-col-num-w4", .id = "paperUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 14})
                                            </td>
                                            <td class="text-right">
                                                @If Model.PaperList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).金額, New With {.class = "form-control input-grid paper-col-num-w3", .id = "paperAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 15})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).金額, New With {.class = "form-control input-grid paper-col-num-w3", .id = "paperAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 15})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).仕切単価, New With {.class = "form-control input-grid paper-col-num-w4", .id = "paperPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 16})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.PaperList.Item(i).仕切金額, New With {.class = "form-control input-grid paper-col-num-w4", .id = "paperPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 17})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->
                @*その他*@
                <!--<div class="group other-ttl-div pt-2">
                    <div class="row">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <label class="mb-0 txt-name">その他</label>
                        </div>
                        <div class="col-12 mx-auto d-flex align-items-center">

                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-1">
                        <div class="other-tb-div container-table wrapper-table-fixed">
                            <table class="table-editable table-striped other-table-w table-fixed table-bordered">
                                <thead>
                                    <tr>
                                        <th class="">内外</th>
                                        <th class="">作業</th>
                                        <th class="">作業名</th>
                                        <th class="">数量</th>
                                        <th class="">単価</th>
                                        <th class="">金額</th>
                                        <th class="">仕切単価</th>
                                        <th class="">仕切金額</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For i = 0 To Model.OtherList.Count - 1
                                        If i = 0 Then
                                            tplIndex = tplIndex + 18
                                        Else
                                            tplIndex = tplIndex + 8
                                        End If
                                        @<tr>
                                            <td class="cbo-row">
                                                @Html.DropDownListFor(Function(x) x.OtherList.Item(i).内外区分, New SelectList(Model.InOutClassList, "Value", "Text", Model.OtherList.Item(i).内外区分), New With {.class = "form-control in-out-cls other-col-w1", .id = "otherInOutKbn" + i.ToString(), .tabindex = tplIndex + 1, .Name = "OtherList[" + i.ToString + "].内外区分"})
                                            </td>
                                            <td>
                                                @CustomHTML.CustomeHTMLHelper.TPLCodeForGrid("OtherList[" + i.ToString + "].作業", 55, 4, Core.ConstantCore.Consts.TypeGetName.SHORT_NAME, Core.ConstantCore.Consts.COMMON_NO.TASK_ETC, False, tplIndex + 2, Model.OtherList.Item(i).作業, "input-grid other-col-w2", "other作業" + i.ToString)
                                            </td>
                                            <td title="@Model.OtherList.Item(i).作業名">
                                                <span class="txt-elipsis-ver c-name other-col-w3">@Model.OtherList.Item(i).作業名</span>
                                                <input name="OtherList[@i.ToString].作業名" type="hidden" value="@Model.OtherList.Item(i).作業名" class="c-name" />
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.OtherList.Item(i).数量, New With {.class = "form-control input-grid other-quantity other-col-num-w1", .id = "otherQuantity" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 3})
                                            </td>
                                            <td Class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.OtherList.Item(i).単価, New With {.class = "form-control input-grid other-unit-price other-col-num-w2", .id = "otherUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .tabindex = tplIndex + 4})
                                            </td>
                                            <td class="text-right">
                                                @If Model.OtherList(i).DisabledAmount Then
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.OtherList.Item(i).金額, New With {.class = "form-control input-grid other-amount other-col-num-w1", .id = "otherAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 5})
                                                Else
                                                    @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.OtherList.Item(i).金額, New With {.class = "form-control input-grid other-amount other-col-num-w1", .id = "otherAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .tabindex = tplIndex + 5})
                                                End If
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.OtherList.Item(i).仕切単価, New With {.class = "form-control input-grid other-col-num-w2", .id = "otherPUnitPrice" + i.ToString(), .numeralIntegerScale = 7, .numeralDecimalScale = 3, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 6})
                                            </td>
                                            <td class="text-right">
                                                @CustomHTML.CustomeHTMLHelper.TPLNumberFor(Html, Function(x) x.OtherList.Item(i).仕切金額, New With {.class = "form-control input-grid other-col-num-w2", .id = "otherPAmount" + i.ToString(), .numeralIntegerScale = 9, .numeralDecimalScale = 0, .style = "text-align: right;", .disabled = "disabled", .tabindex = tplIndex + 7})
                                            </td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="group mt-2">
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <input type="text" class="form-control mr-0 memo-w memo-mr" name="NoteInfo.メモ1" value="@Model.NoteInfo.メモ1" tabindex="@(tplIndex + 9)">
                            <input type="text" class="form-control mr-0 memo-w" name="NoteInfo.メモ2" value="@Model.NoteInfo.メモ2" tabindex="@(tplIndex + 10)">
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <input type="text" class="form-control mr-0 memo-w memo-mr" name="NoteInfo.メモ3" value="@Model.NoteInfo.メモ3" tabindex="@(tplIndex + 11)">
                            <input type="text" class="form-control mr-0 memo-w" name="NoteInfo.メモ4" value="@Model.NoteInfo.メモ4" tabindex="@(tplIndex + 12)">
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <input type="text" class="form-control mr-0 memo-w memo-mr" name="NoteInfo.メモ5" value="@Model.NoteInfo.メモ5" tabindex="@(tplIndex + 13)">
                            <input type="text" class="form-control mr-0 memo-w" name="NoteInfo.メモ6" value="@Model.NoteInfo.メモ6" tabindex="@(tplIndex + 14)">
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <input type="text" class="form-control mr-0 memo-w memo-mr" name="NoteInfo.メモ7" value="@Model.NoteInfo.メモ7" tabindex="@(tplIndex + 15)">
                            <input type="text" class="form-control mr-0 memo-w" name="NoteInfo.メモ8" value="@Model.NoteInfo.メモ8" tabindex="@(tplIndex + 16)">
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-12 mx-auto d-flex align-items-center">
                            <input type="text" class="form-control mr-0 memo-w memo-mr" name="NoteInfo.メモ9" value="@Model.NoteInfo.メモ9" tabindex="@(tplIndex + 17)">
                            <input type="text" class="form-control mr-0 memo-w" name="NoteInfo.メモ10" value="@Model.NoteInfo.メモ10" tabindex="@(tplIndex + 18)">
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-2 f-div-btn-w">
                <div class="col d-flex align-items-baseline">
                    <Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr schedule-btn-w" tabindex="@(tplIndex + 19)" id="scheduleBtn">スケジュール</Button>
                    <Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 20)" id="orderSlipBtn">受注伝票</Button>
                    @If Not Model.DisabledInst Then
                        @<Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 21)" id="workInstBtn">作業指示書</Button>
                    End If
                    @If Not Model.DisabledStt Then
                        @<Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 22)" id="settlementQtBtn">精算見積書</Button>
                    End If
                    @If Not Model.DisabledCost Then
                        @<Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 23)" id="originalPriceBtn">原　価</Button>
                    End If
                    @If Not Model.DisabledCsvIn Then
                        @<Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 24)" id="csvInputBtn">CSV取込</Button>
                    End If
                    @If Not Model.DisabledCsvOut Then
                        @<Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 25)" id="csvOtputBtn">CSV出力</Button>
                    End If
                </div>
                <div class="col d-flex align-items-baseline justify-content-end pr-0">
                    <Button type="button" Class="btn btn-sm btn-secondary tpl-btn-mr" tabindex="@(tplIndex + 26)" id="registerBtn">登　録</Button>
                    @If Not Model.DisabledDeleteBtn Then
                        @<Button type="button" Class="btn btn-sm btn-secondary" tabindex="@(tplIndex + 27)" id="deleteBtn"> 削　除</Button>
                    Else
                        @<Button type="button" Class="btn btn-sm btn-secondary" tabindex="@(tplIndex + 27)" id="deleteBtn" disabled = "disabled"> 削　除</Button>
                    End If
                </div>
            </div>
        </form>
    </div>

    @<div id='tpl01020-popup' tabindex='-1' role='dialog' aria-labelledby='staticModalLabel' aria-hidden='true' data-show='true' data-keyboard='false' data-backdrop='static'>

    </div>
Else
  @<input name = "IsLoadSuccess" type="hidden" id="IsLoadSuccess" value="@Model.IsLoadSuccess" />
End If-->