<Serializable>
Public Class ResultSearchByDepartAndNameDto
    Public Sub New()
    End Sub

    Public Sub New(担当 As String, 氏名 As String, 略称 As String, ふりがな As String)
        Me.担当 = 担当
        Me.氏名 = 氏名
        Me.略称 = 略称
        Me.ふりがな = ふりがな
    End Sub

    Public Property 担当 As String
    Public Property 氏名 As String
    Public Property 略称 As String
    Public Property ふりがな As String
End Class
