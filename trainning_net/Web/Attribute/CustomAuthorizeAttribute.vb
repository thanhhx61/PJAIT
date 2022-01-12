Imports Core
Imports Core.Session

Namespace Attribute
    Public Class CustomAuthorizeAttribute
        Inherits AuthorizeAttribute
        Implements IAuthorizationFilter
        Public Property ScreenId As String
        Protected Overrides Function AuthorizeCore(ByVal httpContext As HttpContextBase) As Boolean
            Dim isAuthenticated = False
            Dim screenName = ScreenId

            If httpContext.User.Identity.IsAuthenticated Then
                Dim login = CType(httpContext.Session(ConstantCore.SessionKey.LOGIN_INFO), LoginInfo)

                If login Is Nothing Then
                    isAuthenticated = False
                Else
                    isAuthenticated = login.ScreenRoles.Contains(screenName)
                End If
            End If

            Return isAuthenticated
        End Function

        Public Overrides Sub OnAuthorization(ByVal filterContext As AuthorizationContext)
            MyBase.OnAuthorization(filterContext)
            Dim httpContext = filterContext.HttpContext

            If httpContext.User.Identity.IsAuthenticated Then
                Dim loginInfo = CType(httpContext.Session(ConstantCore.SessionKey.LOGIN_INFO), LoginInfo)

                If loginInfo Is Nothing Then
                    filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary From {
                        {"action", "Index"},
                        {"controller", ConstantCore.ScreenId.TPL00010}
                    })
                End If
            End If
        End Sub

        Protected Overrides Sub HandleUnauthorizedRequest(ByVal filterContext As AuthorizationContext)
            filterContext.Result = New RedirectResult("~/Error/Unauthorized")
        End Sub
    End Class
End Namespace
