Imports System.ComponentModel.DataAnnotations
Imports System.Web.Optimization
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Entities
Imports Web.Controllers

Public Class MvcApplication
    Inherits System.Web.HttpApplication
    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        UnityConfig.RegisterComponents()
        DataAnnotationsModelValidatorProvider.RegisterAdapter(GetType(RequiredAttribute), GetType(CustomRequiredAttributeAdapter))
        ModelBinders.Binders.Add(GetType(Decimal), New DecimalModelBinder)
        ModelBinders.Binders.Add(GetType(Decimal?), New DecimalModelBinder)
    End Sub
    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Try
            CustomContext.RollbackDispose()
            Dim message As New StringBuilder()
            Dim ex As Exception = Server.GetLastError()

            Dim pathAbsolute As String = HttpContext.Current.Request.Url.AbsolutePath
            Dim iPAddress As String = HttpContext.Current.Request("REMOTE_ADDR")
            Dim loginID = If(HttpContext.Current.User IsNot Nothing, HttpContext.Current.User.Identity.Name, "Unknown")
            Dim nowStr = DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSSFFF)
            Dim path = If(pathAbsolute.Length > 100, pathAbsolute.Substring(0, 100), pathAbsolute)
            Dim �G���[�ڍ� = String.Empty
            Dim �G���[���e = String.Empty
            If ex IsNot Nothing Then
                �G���[�ڍ� = If(ex.ToString.Length > 1000, ex.ToString.Substring(0, 1000), ex.ToString)
                �G���[���e = If(ex.Message IsNot Nothing AndAlso ex.Message.Length > 1000, ex.Message.Substring(0, 1000), ex.Message)
            End If

            Dim log As New TPL_�G���[���O()
            log.�������� = DateUtil.ConvertStringToDate(nowStr, DateFormat.DATETIMEFULL_F6)
            log.�ڑ���IP = iPAddress
            log.�S�� = loginID
            log.��ʖ� = path
            log.�G���[���e = �G���[���e
            log.�G���[�ڍ� = �G���[�ڍ�
            CustomContext.Current.TPL_�G���[���O.Add(log)

            CustomContext.Current.SaveChanges()
            Response.Redirect("~/Error/Index")
        Catch exx As Exception

        End Try
    End Sub

    Protected Sub Application_BeginRequest()
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
    End Sub
    Protected Sub Application_EndRequest()
        CustomContext.CommitDispose()

        If CustomContext.HasCurrent Then
            CustomContext.Current.Dispose()
        End If
    End Sub

    'Protected Sub Application_AuthenticateRequest()
    '    Dim message As String
    '    If (HttpContext.Current.User IsNot Nothing) Then
    '        message = "loginID: " & HttpContext.Current.User.Identity.Name & " - "
    '    Else
    '        message = "IP Address: " & HttpContext.Current.Request("REMOTE_ADDR") & " - "
    '    End If
    '    message &= "ACTION: " & HttpContext.Current.Request.Url.AbsolutePath
    '    _logger.Info(message)
    'End Sub
End Class
