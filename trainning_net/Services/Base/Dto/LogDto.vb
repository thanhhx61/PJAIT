<Serializable>
Public Class LogDto
    Public Property ログID As String
    Public Property 処理日時 As DateTime?
    Public Property 区分 As String
    Public Property 担当 As String
    Public Property 画面名 As String
    Public Property 接続元IP As String
    Public Property SQL文 As String = String.Empty
End Class
