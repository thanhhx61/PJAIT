<Serializable>
Public Class ClosingDateDto
    Public Sub New()
    End Sub

    Public Sub New(買掛金締日 As String, 売掛金締日 As String)
        Me.買掛金締日 = 買掛金締日
        Me.売掛金締日 = 売掛金締日
    End Sub

    Public Property 買掛金締日 As String
    Public Property 売掛金締日 As String
End Class
