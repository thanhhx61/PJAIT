Imports Core.ConstantCore
Imports Core.Session
Imports CrystalDecisions.Shared
Imports Services.Services
Imports Web.Models

Namespace Controllers
    ''' <summary>
    ''' メニュー画面コントローラ
    ''' </summary>
    Public Class TPL00020Controller
        Inherits BaseController
        ''' <summary>
        ''' メニュー画面のサービス
        ''' </summary>
        Private _menuService As ITPL00020Service

        'Public obj As New ReportDocument

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="MenuService"></param>
        Public Sub New(MenuService As ITPL00020Service)
            _menuService = MenuService
        End Sub

        Private Function getNowDate() As String
            getNowDate = Format(Now, "yyMMddHHmmss")
        End Function

        ''' <summary>
        ''' 初期表示
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        Public Function Index() As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            Dim userInfo = loginSession.UserInfo
            Dim EmpCode = userInfo.UserId

            Dim model = New TPL00020ViewModel()
            Dim menuDetail = _menuService.GetMenu(EmpCode)

            If menuDetail.menus IsNot Nothing AndAlso menuDetail.menus.Count <> 0 Then
                Dim menus = menuDetail.menus
                Dim programs = menuDetail.programs
                model.MenuRoleName = menus.FirstOrDefault().メニュー名
                model.MenuName = menus.Select(Function(x) New MenuInfo With {.Name = x.メニュー名, .Value = x.メニューid.ToString}).ToList()
                model.ProgramName = programs.Select(Function(x) New MenuInfo With {.Name = x.MenuName, .Value = x.MenuUrl}).ToList()
            End If

            Return View("Index", model)
        End Function

        ''' <summary>
        ''' Process Name onClick
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function getProgram(model As TPL00020ViewModel) As ActionResult
            Dim programs = _menuService.GetProgram(model.MenuId.ToString)

            Return Json(programs)
        End Function

        ''' <summary>
        ''' Logout onClick
        ''' </summary>
        <HttpPost>
        Public Sub Logout()
            'log
            Me.WriteLog(LogType.LOGOUT, "TPL00020/Logout")
            TempData("Model") = Nothing
            TempData("Message") = Nothing
            Session.RemoveAll()
            FormsAuthentication.SignOut()
        End Sub

    End Class
End Namespace