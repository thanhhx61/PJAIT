@ModelType Web.Models.TPL99050WViewModel

@Code
    Dim loginInfo = CType(Session(Core.ConstantCore.SessionKey.LOGIN_INFO), Core.Session.LoginInfo)
    Dim empName = ""
    If loginInfo IsNot Nothing Then
        empName = "ログインID: " + loginInfo.UserInfo.UserId
    End If
End Code

<div class='modal popup-div fade' tabindex='-1' role='dialog' aria-labelledby='staticModalLabel' aria-hidden='true' data-show='true' data-keyboard='false' data-backdrop='static'>
    <div class="modal-dialog modal-xl modal-dialog-centered">
        <div class='modal-content'>
            <div class="modal-header bg-info popup-title">
                <span class="text-white popup-title-sp">用紙選択</span>
                <div class="text-white login-info">
                    <span class="pr-4">@(empName)</span><span>@(DateTime.Now.ToString(Core.ConstantCore.DateFormat.DATETIMEFULL_NS))</span>
                </div>
            </div>
            <form method="POST" class="popup-frm">
                @Html.AntiForgeryToken()
                <div class="modal-body">
                    <div class="header">
                        <div class="group border-bottom border-dark">
                            <div class="mx-auto d-flex align-items-center justify-content-start mb-2">
                                <label class="mb-0 txt-name-p2">品種</label>
                                @CustomHTML.CustomeHTMLHelper.TPLCode("ProductType", "ProductTypeName", 80, 190, "1010", 4, "2", False, True, 1000, Model.ProductType, Nothing)

                                <label class="mb-0 txt-name-p2 ml-7cell">メーカー</label>
                                @CustomHTML.CustomeHTMLHelper.TPLCode("ProducerCode", "ProducerName", 80, 190, "1011", 4, "2", False, True, 1001, Model.ProducerCode, Nothing)

                            </div>
                            <div class="mx-auto d-flex align-items-center justify-content-start mb-2">
                                <label class="mb-0 txt-name-p2">銘柄名</label>
                                <div class="pr-0">
                                    <input type="text" class="form-control form-control-sm width-270" maxlength="20" tabindex="1002" name="NameSearch" value="@Model.NameSearch" />
                                </div>
                                <div class="ml-auto row d-flex">
                                    <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr p-tpl-search" tabindex="1003">検　索</button>
                                    <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr p-tpl-close" data-dismiss="modal" tabindex="1004">閉じる</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tpl99050-table-con">
                        @Html.Partial("_TPL99050W_Table")
                    </div>
                </div>
                <input type="hidden" id="parentId" value="" />
                <input type="hidden" name="screenPopupCode" value="" />
            </form>
        </div>
    </div>
</div>
