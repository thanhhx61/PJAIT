@ModelType Web.Models.LoginViewModel
@Code
    ViewData("NameScreen") = "印刷テンプレートシステム　ログイン"
    ViewData("Title") = "印刷テンプレートシステム　ログイン"
End Code

@Using Html.BeginForm("Login", "TPL00010", FormMethod.Post)
    @<div class="row">
         <div class="col-12 mx-auto d-flex align-items-center">
             <label class="mb-0 txt-login">ユーザーID</label>
             @Html.TextBoxFor(Function(model) model.Login.UserId, New With {.class = "form-control only-half-size input-login login-id-cls", .maxlength = "20", .tabindex = "1"})
         </div>
    </div>
    @<div class="row mt-3">
         <div class="col-12 mx-auto d-flex align-items-center">
             <label class="mb-0 txt-login">パスワード</label>
             @Html.TextBoxFor(Function(model) model.Login.Password, New With {.class = "form-control only-half-size input-login", .type = "password", .maxlength = "20", .tabindex = "2"})
             <button type="submit" class="btn btn-secondary btn-sm ml-5" tabindex="3" data-end-tabindex="true">ログイン</button>
         </div>
    </div>
    @<hr style="background-color: black">
End Using
@Section  Scripts
    <script>
        $(document).ready(function () {
            $(".login-id-cls").focus();
        });

        function handleCloseButon() {
            var message = $("#focusName").val();
            if (message != "") {
                $("#" + message.replace(".","_")).focus();
            }
        }      
    </script>
End Section
