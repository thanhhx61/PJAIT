Namespace Models
    <Serializable>
    Public Class TPL00020ViewModel

        Public Sub New()

        End Sub

        Public Property MenuRoleName As String
        Public Property MenuName As New List(Of MenuInfo)
        Public Property ProgramName As New List(Of MenuInfo)
        Public Property MenuId As String
        Public Property ProgramId As String
    End Class
End Namespace
