Imports Core.ConstantCore
Imports Core.Session
Imports Core.Util
Imports Dao.Dto
Imports Entities
Imports Services.Dto
Imports Services.Services
Imports Web.Models

Namespace Controllers
    ''' <summary>
    ''' ログイン画面コントローラ
    ''' </summary>
    Public Class TPL00010Controller
        Inherits BaseController
        ''' <summary>
        ''' ログイン画面のサービス
        ''' </summary>
        Private _loginService As ITPL00010Service

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="LoginService">ITPL00010Service</param>
        Public Sub New(LoginService As ITPL00010Service)
            _loginService = LoginService
        End Sub

        ''' <summary>
        ''' 初期表示
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        Public Function Index() As ActionResult
            SetMessage()
            Dim model = New LoginViewModel
            If TempData("Model") IsNot Nothing Then
                model = CType(TempData("Model"), LoginViewModel)
            End If
            Return View(model)
        End Function

        ''' <summary>
        ''' Loginボタン押下
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HttpPost>
        Public Function Login(model As LoginViewModel) As ActionResult
            TempData("Model") = model
            If Not TryValidateModel(model) Then
                SetMessageModalstate(ModelState)
                TempData("Message") = _layoutBaseModel
                Return RedirectToAction("Index")
            End If

            Dim res = _loginService.Login(New LoginDto(model.Login.UserId, model.Login.Password, Request("REMOTE_ADDR")))

            If res.IsSuccess Then
                Dim userInf As New UserInfo
                userInf.UserId = res.Pic.担当
                userInf.Department = res.Pic.部署

                FormsAuthentication.SetAuthCookie(model.Login.UserId, False)
                Session(SessionKey.LOGIN_INFO) = New LoginInfo With {.UserInfo = userInf, .ScreenRoles = res.ProgramIds}
                Return RedirectToAction("Index", ScreenId.TPL00020)
            Else
                _layoutBaseModel.Focus = res.Message.Focus
                _layoutBaseModel.Message = res.Message.Message
                _layoutBaseModel.IsMessage = res.Message.IsMessage
                TempData("Message") = _layoutBaseModel
            End If

            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace