<Serializable>
Public Class ComboBoxDto
    Public Sub New()
    End Sub

    Public Sub New(名称 As String, 略称 As String, コード As String, 表示順 As Integer)
        Me.名称 = 名称
        Me.略称 = 略称
        Me.コード = コード
        Me.表示順 = 表示順
    End Sub

    Public Property 名称 As String
    Public Property 略称 As String
    Public Property コード As String
    Public Property 表示順 As Integer
End Class
