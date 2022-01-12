Namespace Models
    <Serializable>
    Public Class TPL99040WViewModel

        Public Sub New()

        End Sub

        Public Sub New(Code As String, pageCurrent As Integer, NameSearch As String, DepartmentCode As String)
            Me.Code = Code
            Me.pageCurrent = pageCurrent
            Me.NameSearch = NameSearch
            Me.DepartmentCode = DepartmentCode
        End Sub

        Public Property Code As String = "0"
        Public Property pageCurrent As Integer = 1
        Public Property NameSearch As String
        Public Property DepartmentCode As String
    End Class
End Namespace
