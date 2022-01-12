Imports CrystalDecisions

Public Class ExportPDFModel(Of T As Class)
    Public Property RptName As String
    Public Property FileId As String
    Public Property PaperSize As [Shared].PaperSize
    Public Property PaperOrn As [Shared].PaperOrientation
    Public Property Data As List(Of T)
End Class
