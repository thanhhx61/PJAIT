Namespace Session
    ''' <summary>
    ''' セッション格納ログイン情報
    ''' </summary>
    <Serializable>
    Public Class LoginInfo
        Public Property UserInfo As UserInfo

        Public Property ScreenRoles As List(Of String)
    End Class
End Namespace
