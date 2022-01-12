@Section Scripts
    <script src="~/Scripts/custom/TPL00020.js"></script>
End Section

@ModelType Web.Models.TPL00020ViewModel

@Code
    ViewData("NameScreen") = "印刷テンプレートシステム　メニュー"
    ViewData("Title") = "印刷テンプレートシステム　メニュー"
    Dim fistIndex = 0
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="~/Content/custom/TPL00020.css">
End Section
<form>
    @Html.AntiForgeryToken()
    <div class="ttl" style="padding-left: 10px">
        <label><b>@Model.MenuRoleName</b></label>
        <input type="button" value="ログアウト" class="btn btn-sm btn-secondary mr-3 float-right" id="logout">
    </div>
    <div class="menu-container">
        <ul>
            @For Each m In Model.MenuName
                Dim ulId = "ul_" + m.Value
                @If fistIndex = 0 Then
                    fistIndex = fistIndex + 1
                    @<li>
                        <a href="#" class="menu_main active " id="@m.Value">@m.Name<i class="fa fa-chevron-left float-right" aria-hidden="true"></i></a>

                        <ul id="@ulId">
                            @For Each detail In Model.ProgramName
                                @<li>
                                    <a href="javascript:;" data-url="@detail.Value" class="menu-item active">@detail.Name</a>
                                </li>
                            Next detail
                        </ul>
                    </li>
                Else
                    fistIndex = fistIndex + 1
                    @<li>
                        <a href="#" class="menu_main" id="@m.Value">@m.Name<i class="fa fa-chevron-right float-right" aria-hidden="true"></i></a>
                        <ul id="@ulId">
                        </ul>
                    </li>
                End If
            Next m

        </ul>
    </div>
</form>


@*@Using Html.BeginForm("DownloadPdf", "TPL00020", FormMethod.Post)
            @Html.AntiForgeryToken()
            @<button type="submit" Class="btn btn-sm btn-secondary  mr-3" id="btn-select" tabindex="253">Download (submit form)</button>
            @<button type="button" Class="btn btn-sm btn-secondary  mr-3" id="btn-download" tabindex="253">Download(js)</button>
            @<button type="button" Class="btn btn-sm btn-secondary  mr-3" id="btn-download-save" tabindex="253">Download(save then download)</button>
    End Using

    @Using Html.BeginForm("CheckTableColJpn", "Base", FormMethod.Post)
        @Html.AntiForgeryToken()
        @<button type="submit" Class="btn btn-sm btn-secondary  mr-3 mt-3" id="btn-check-jp" tabindex="253">Check table, item name in JPL</button>
    End Using*@

@*<label class="mb-0 txt-name">Code:</label>
@CustomHTML.CustomeHTMLHelper.TPLCode("code1", "codeName1", 90, 200, "1001", 50, "1", False, True, 45, Nothing, Nothing)
<label class="mb-0 txt-name">Customer:</label>
@CustomHTML.CustomeHTMLHelper.TPLCustomer("customerCode1", "customerCode1", 90, 200, "1", False, True, 10, Nothing, Nothing)
<label class="mb-0 txt-name">Order:</label>
@CustomHTML.CustomeHTMLHelper.TPLOrderNo("order1", "orderName1", 90, 200, False, 10, Nothing, Nothing)
<label class="mb-0 txt-name">Person:</label>
@CustomHTML.CustomeHTMLHelper.TPLPerson("person1", "personName1", 80, 150, 10, Nothing, Nothing)
<label class="mb-0 txt-name">Dept:</label>
@CustomHTML.CustomeHTMLHelper.TPLDepartment("picCode", "depName", "picName", "depCode", 80, 150, 150, 10, Nothing, Nothing, Nothing, Nothing)
<label class="mb-0 txt-name">Paper:</label>
@CustomHTML.CustomeHTMLHelper.TPLPaper("paper1", "paperName1", 80, 150, False, True, 10, Nothing, Nothing)*@
