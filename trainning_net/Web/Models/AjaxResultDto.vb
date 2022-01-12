<Serializable>
Public Class AjaxResultDto
    Public Sub New()
        Data = New Dictionary(Of String, Object)
    End Sub

    'コンストラクタ
    Public Property Data As Dictionary(Of String, Object)
    'データ文字列
    Public Property DataString As String
    '検証用エラーメッセージリスト
    Public Property Message As String
    Public Property Focus As String
    Public Property View As String
    'OK:処理・検証成功、NG:検証失敗、ERR:処理失敗etc

    Public Property ViewList As Dictionary(Of String, String)
    Public Property Status As String

    Public Property Mode As String

End Class
