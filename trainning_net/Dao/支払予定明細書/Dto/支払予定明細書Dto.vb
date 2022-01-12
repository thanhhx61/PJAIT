<Serializable>
Public Class 支払予定明細書Dto
    Public Property 仕入日 As Date
    Public Property 外注用紙区分 As String
    Public Property 行番号 As Decimal
    Public Property 発注番号 As String
    Public Property 受注番号 As String
    Public Property 品名銘柄名 As String
    Public Property 工程 As String
    Public Property 作業名 As String
    Public Property 連量 As Decimal?
    Public Property 数量 As Decimal?
    Public Property 単位 As String
    Public Property 単価 As Decimal?
    Public Property 課税区分 As String
    Public Property 税率 As Decimal?
    Public Property 支払金額 As Decimal?

    Public Property その他経費課税区分 As String
    Public Property その他経費税率 As Decimal?
    Public Property その他経費金額 As Decimal?
    Public Property 値引課税区分 As String
    Public Property 値引税率 As Decimal?
    Public Property 値引金額 As Decimal?

    Public Property 郵便番号 As String
    Public Property 住所１ As String
    Public Property 住所２ As String
    Public Property 名称 As String
    Public Property 取引先 As String
End Class
