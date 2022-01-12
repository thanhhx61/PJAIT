@ModelType Web.Models.TPL99010WViewModel

@Code
    Dim loginInfo = CType(Session(Core.ConstantCore.SessionKey.LOGIN_INFO), Core.Session.LoginInfo)
    Dim empName = ""
    If loginInfo IsNot Nothing Then
        empName = "ログインID: " + loginInfo.UserInfo.UserId
    End If
    Dim titlePopup = "コード選択"
    If String.IsNullOrEmpty(ViewBag.idInput) Then
        titlePopup += " ( 識別 )"
    End If
End Code
<div class='modal popup-div' id='' tabindex='-1' role='dialog' aria-labelledby='staticModalLabel' aria-hidden='true' data-show='true' data-keyboard='false' data-backdrop='static'>
    <div class="modal-dialog modal-xl modal-dialog-centered">
        <div class='modal-content'>
            <div class="modal-header bg-info popup-title">
                <span class="text-white popup-title-sp">@(titlePopup)</span>
                <div class="text-white login-info">
                    <span class="pr-4">@(empName)</span><span>@(DateTime.Now.ToString(Core.ConstantCore.DateFormat.DATETIMEFULL_NS))</span>
                </div>
            </div>
            <div class="modal-body">
                @Html.Partial("_TPL99010W_Table")
            </div>
            <input type="hidden" id="parentId" value="" />
            <input type="hidden" id="code" value="" />
        </div>
    </div>
</div>
