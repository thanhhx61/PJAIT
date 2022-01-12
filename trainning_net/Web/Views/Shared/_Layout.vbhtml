@Code
    Dim loginInfo = CType(Session(Core.ConstantCore.SessionKey.LOGIN_INFO), Core.Session.LoginInfo)
    Dim empName = ""
    If loginInfo IsNot Nothing Then
        empName = "ログインID: " + loginInfo.UserInfo.UserId
    End If
End Code
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title </title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @RenderSection("styles", required:=False)
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/scripts")
</head>
<body>
    <div class="content-header bg-info">
        <span><b>@ViewBag.NameScreen</b></span>
        @If loginInfo IsNot Nothing Then
            @<div Class="login-info">
                <Span>@empName</Span>
                <Span id="timeDate">@DateTime.Now.ToString(Core.ConstantCore.DateFormat.DATETIMEFULL)</Span>
            </div>
        End If
    </div>
    <div class="container-fluid layout-div-render-body" id="layoutDivRenderBody">
        @RenderBody()
    </div>
    <div class="content-footer bg-info"></div>
    <div class="popup-model">
        <div class="tpl99020-p">
            <input type="hidden" id="parentId" value="" />
        </div>
        <div class="tpl99040-p">
            <input type="hidden" id="parentId" value="" />
        </div>
        <div class="tpl99050-p">
        </div>
        <div class="tpl99010-p">
        </div>
    </div>
    <div id="messageModel">
        @Html.Partial("_AlertMessage")
    </div>
    <script>
        $(function () {
            if ($("#isMessage").val() != null && $("#isMessage").val() != "") {
                $("#myModal_info").modal();
                var focusName = $("#focusName").val();
                $("input[name='" + focusName + "']").focus()
            }
            $("#message_Info_close").click(function () {
                $("#myModal_info").modal();
            })
        })

        setInterval(setTimeDate, 1000);

        function setMessageConfirm(message) {
            $("#content-message-question").html(message);
            $("#myModal_question").modal();
        }

        function setMessageInfo(message) {
            $("#content-message-info").html(message);
            $("#myModal_info").modal();
        }

        $(".btn-ok").click(function () {
            handleOkButon();
        });

        $(".btn-cancel").click(function () {
            handleCancelButon();
        });

        $(".btn-close").click(function () {
            handleCloseButon();
        });

        function setTimeDate() {
            var momentNow = new Date();
            var month = momentNow.getMonth() + 1;
            var timeHour = momentNow.getHours();
            var timeMinus = momentNow.getMinutes()
            if (timeHour < 10) {
                timeHour = "0" + timeHour
            }
            if (timeMinus < 10) {
                timeMinus = "0" + timeMinus
            }

            $("#timeDate").html(momentNow.getFullYear() + "/" + month + "/" + momentNow.getDate() + " " + timeHour + ":" + timeMinus);
        }

    </script>
    @RenderSection("scripts", required:=False)
</body>
</html>
