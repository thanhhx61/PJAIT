Imports System.Web.Mvc
Imports Services

Namespace Controllers
    Public Class TPL05010Controller
        Inherits BaseController
        Private ReadOnly _service As TPL05010Servicelmpl

        ' GET: TPL05010
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace