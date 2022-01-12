Namespace Models
    <Serializable>
    Public Class TPL99010WViewModel

        Public Sub New()

        End Sub

        Public Sub New(ident As String, pageCurrent As Integer)
            Me.Ident = ident
            Me.pageCurrent = pageCurrent
        End Sub

        Public Property Ident As String = "0"
        Public Property pageCurrent As Integer = 1
    End Class
End Namespace
