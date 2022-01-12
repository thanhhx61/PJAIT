Imports System.Web.Mvc

Namespace Controllers
    Public Class ErrorController
        Inherits BaseController

        Public Function Index() As ActionResult
            Return View()
        End Function

    End Class
End Namespace