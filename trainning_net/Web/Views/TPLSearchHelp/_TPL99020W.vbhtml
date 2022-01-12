@ModelType Web.Models.TPL99020WViewModel

@Code
    Dim loginInfo = CType(Session(Core.ConstantCore.SessionKey.LOGIN_INFO), Core.Session.LoginInfo)
    Dim empName = ""
    If loginInfo IsNot Nothing Then
        empName = "ログインID: " + loginInfo.UserInfo.UserId
    End If

    Dim comboboxCustomer As New List(Of Dao.ComboBoxDto)
    If ViewBag.comboboxCustomer IsNot Nothing Then
        comboboxCustomer = ViewBag.comboboxCustomer
    End If
End Code

<div class='modal popup-div fade' tabindex='-1' role='dialog' aria-labelledby='staticModalLabel' aria-hidden='true' data-show='true' data-keyboard='false' data-backdrop='static'>
    <div class="modal-dialog modal-xl modal-dialog-centered">
        <div class='modal-content'>
            <div class="modal-header bg-info popup-title">
                <span class="text-white popup-title-sp">取引先選択</span>
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
                                <label class="mb-0 txt-name-p2">取引先区分</label>
                                <div class="pr-0">
                                    <select class="combobox-cls-p form-control form-control-sm" disabled tabindex="1000">
                                        @For i As Integer = 0 To comboboxCustomer.Count() - 1 Step 1
                                            Dim selected = If(comboboxCustomer(i).コード = Model.Code, "selected", "")
                                            @<option value="@comboboxCustomer(i).コード" @selected>@comboboxCustomer(i).略称</option>
                                        Next
                                    </select>
                                </div>
                            </div>
                            <div class="mx-auto d-flex align-items-center justify-content-start mb-2">
                                <label class="mb-0 txt-name-p2">名称／よみ</label>
                                <div class="pr-0">
                                    <input type="text" name="NameSearch" value="@Model.NameSearch" class="form-control form-control-sm name-search-p width-330" maxlength="20" tabindex="1001" />
                                </div>
                                <div class="ml-auto row d-flex">
                                    <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr p-tpl-search" tabindex="1002">検　索</button>
                                    <button type="button" class="btn btn-sm btn-secondary tpl-btn-mr p-tpl-close" data-dismiss="modal" tabindex="1003">閉じる</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tpl99020-table-con">
                        @Html.Partial("_TPL99020W_Table")
                    </div>
                </div>
                <input type="hidden" id="parentId" value="" />
                <input type="hidden" id="code" value="" />
            </form>
        </div>
    </div>
</div>