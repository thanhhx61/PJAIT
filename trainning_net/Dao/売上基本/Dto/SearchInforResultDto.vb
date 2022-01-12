<Serializable>
Public Class SearchInforResultDto
    Public Sub New()
    End Sub
    Public Property 売上番号 As String
    Public Property 受注番号 As String
    Public Property 売上日 As Date?
    Public Property 請求日 As Date?
    Public Property 取引区分 As String
    Public Property 品名 As String
    Public Property 売上数量 As Decimal?
    Public Property 売上金額 As Decimal
    Public Property 消費税 As Decimal?
    Public Property 得意先 As String
    Public Property 受注担当 As String
    Public Property 売上単価 As String
    Public Property 備考 As String

End Class
