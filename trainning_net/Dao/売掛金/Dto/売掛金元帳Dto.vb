<Serializable>
Public Class 売掛金元帳Dto
    Public Property 得意先 As String
    Public Property 得意先名 As String
    Public Property 種別 As String
    Public Property 対象年月 As String
    Public Property 回収日 As String
    Public Property 集金方法１ As String
    Public Property 集金方法２ As String
    Public Property 締日 As String
    Public Property 日付 As String
    Public Property 伝票番号 As String
    Public Property 受注番号 As String
    Public Property 品名 As String
    Public Property 備考 As String
    Public Property 数量 As Decimal?
    Public Property 単位 As String
    Public Property 単価 As Decimal?
    Public Property 単価正数 As Decimal?
    Public Property 単価小数 As String
    Public Property 課税区分 As String
    Public Property 売上金額 As Decimal?
    Public Property 消費税 As Decimal?
    Public Property 税率 As String
    Public Property 入金金額 As Decimal?
    Public Property 当月売掛残 As Decimal?
End Class
