Imports Web.Controllers
Imports Core
Imports Core.ConstantCore

Namespace Attribute
    Public Class CustomActionFilterAttribute
        Inherits ActionFilterAttribute
        Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
            Dim controller = filterContext.Controller
            Dim actionName = filterContext.ActionDescriptor.ActionName
            Dim session = filterContext.HttpContext.Session
            If (TypeOf controller Is TPL00010Controller) = False AndAlso
                (session.Count = 0 OrElse session(SessionKey.LOGIN_INFO) Is Nothing) Then
                filterContext.Result = New RedirectResult("~/TPL00010")
                Return
            Else
                Return
            End If
            session.Timeout = 60
        End Sub

        Public Overrides Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext)

            MyBase.OnActionExecuted(filterContext)
        End Sub
    End Class

End Namespace