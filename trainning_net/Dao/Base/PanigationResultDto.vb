Imports System.Collections.Generic

Public Class PanigationResultDto(Of M As Class)
    Public Property List As List(Of M)
    Public Property Total As Integer
    Public Property PageSize As Integer
End Class