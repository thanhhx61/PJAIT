<Serializable>
Public Class NameDto
    Public Sub New()
    End Sub

    Public Sub New(名称 As String, 略称 As String)
        Me.名称 = 名称
        Me.略称 = 略称
    End Sub

    Public Property 名称 As String

    Public Property 略称 As String
End Class
