Imports System.Web
Imports System.Web.Mvc
Imports Web.Attribute

Public Module FilterConfig
    Public Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
        filters.Add(New CustomActionFilterAttribute())
    End Sub
End Module