<Serializable>
Public Class 売上基本Dto
    Public Property 売上番号 As String
    Public Property 受注番号 As String
    Public Property 行番号 As Decimal
    Public Property 得意先 As String
    Public Property 得意先名 As String
    Public Property 売上日 As Date
    Public Property 請求日 As Date
    Public Property 請求月 As String
    Public Property 取引区分 As String
    Public Property 品名 As String
    Public Property 売上数量 As Decimal?
    Public Property 売上単価 As Decimal?
    Public Property 売上金額 As Decimal
    Public Property 単位 As String
    Public Property 課税区分 As String
    Public Property 税率 As String
    Public Property 備考 As String
    Public Property 削除フラグ As Boolean?
    Public Property 登録日 As Date?
    Public Property 登録者 As String
    Public Property 更新日 As Date?
    Public Property 更新者 As String

End Class
